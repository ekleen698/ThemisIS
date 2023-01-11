
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms
Imports ClassLibrary.GlobalObjects

Public Class frmWorkerProgress
    ' Disable Close button
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim param As CreateParams = MyBase.CreateParams
            param.ClassStyle = param.ClassStyle Or &H200
            Return param
        End Get
    End Property

    Public Event ConvertStatus(sender As Object, Count As Integer) ' updates parent form status bar
    Public Event ConvertComplete(sender As Object, Status As String) ' signals all workers complete

    Private Delegate Sub ConvertUpdate(Count As Integer, Total As Integer, Folder As String, OpStep As String, WorkerId As Integer)

    Private _EmailFolders As Queue(Of DirectoryInfo)
    Private _Token As CancellationToken
    Private _ParentResult As Dictionary(Of String, Object)
    Private _ScaleFactor

    Private ReadOnly _POISON = New DirectoryInfo("Poison Pill")  ' signals end of queue
    Private ReadOnly _ACTIVE = Drawing.Color.LightCoral
    Private ReadOnly _INACTIVE = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveBorder)
    Private ReadOnly _MOUSEOVER = Drawing.Color.LightSteelBlue
    Private Const _NUM_WORKERS = 5  'Max of 5

    Public Sub New(EmailFolders As DirectoryInfo(), ByRef Token As CancellationToken,
                   ByRef ParentResult As Dictionary(Of String, Object))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Create scale factor because value of 'AutoScaleDimensions' changes with screen resolution
        _ScaleFactor = Me.CurrentAutoScaleDimensions.Width / 96

        ' Create queue of subfolders in root Email folder
        _EmailFolders = New Queue(Of DirectoryInfo)(EmailFolders)
        _EmailFolders.Enqueue(_POISON)
        ' Token used to signal cancellation
        _Token = Token
        ' Store process results for parent form handling
        _ParentResult = ParentResult

    End Sub

    Private Sub frmWorkerProgress_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Form properties
        Me.Left += System.Convert.ToInt32(300 * _ScaleFactor)
        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size

    End Sub

    Private Async Sub frmWorkerProgress_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        ' Hide Location Button
        cmdLocation.Visible = False

        ' Initialize form objects
        ' > Close Button
        Me.cmdClose.Enabled = False
        Me.cmdClose.BackColor = _INACTIVE
        Me.cmdClose.FlatAppearance.MouseOverBackColor = _MOUSEOVER
        ' > Hide all progress bars
        For WorkerId As Integer = 1 To 5
            Me.Controls($"lblFolder{WorkerId}").Visible = False
            Me.Controls($"lblStep{WorkerId}").Visible = False
            Me.Controls($"lblCount{WorkerId}").Visible = False
            Me.Controls($"ProgressBar{WorkerId}").Visible = False
        Next
        ' > Show selected progress bars
        For WorkerId As Integer = 1 To _NUM_WORKERS
            Me.Controls($"lblFolder{WorkerId}").Visible = True
            Me.Controls($"lblStep{WorkerId}").Visible = True
            Me.Controls($"lblCount{WorkerId}").Visible = True
            Me.Controls($"ProgressBar{WorkerId}").Visible = True
        Next

        ' Initialize parent progress bar and pause to allow form to fully load
        RaiseEvent ConvertStatus(Me, 0)
        Await Task.Delay(100)

        ' Start async process
        start_workers()

    End Sub
    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        ' Button activated once all Worker threads are shut down if cancelled or errors

        Me.Close()

    End Sub

    Private Async Sub start_workers()
        ' Start new thread for each Worker then wait for all threads to shut down

        Dim oTask As Task
        Dim oTasks As New List(Of Task)
        Dim CompletedCount As Integer = 0

        ' Create new thread for each worker
        For i = 1 To _NUM_WORKERS
            Dim Worker = New Converter(i, _Token)
            AddHandler Worker.ConvertStatus, AddressOf EventHandler
            oTask = Task.Factory.StartNew(Sub() convert(Worker, CompletedCount))
            oTasks.Add(oTask)
            Await Task.Delay(100) ' pause to allow worker thread to start
        Next

        ' Wait for all Worker threads to shut down
        Await Task.WhenAll(oTasks.ToArray())

        ' Handle result
        Dim Status As String
        Dim bClose As Boolean = False
        If _Token.IsCancellationRequested Then
            _ParentResult("Cancelled") = True
            Status = "Operation Cancelled"
        ElseIf Not IsNothing(_ParentResult("OpError")) Then
            Status = "Operation Completed With Errors"
        Else
            Status = "All Emails Converted"
            bClose = True
        End If

        ' Send signal to parent that all workers are shut down and update status bar
        RaiseEvent ConvertComplete(Me, Status)

        ' Close form or activate Close button
        If bClose Then
            ' Pause then close
            Await Task.Delay(500)
            Me.Close()
        Else
            ' Activate Close button
            Me.cmdClose.BackColor = _ACTIVE
            Me.cmdClose.Enabled = True
        End If

    End Sub

    Private Sub convert(oConverter As Converter, ByRef CompletedCount As Integer)
        ' Process for each Worker thread

        Dim WorkerId As Integer = oConverter.WorkerId
        Dim EmailFolder As DirectoryInfo
        Dim Result As Dictionary(Of String, Object)
        Dim FolderName As String = ""
        Dim FinalCount As Integer = 1
        Dim FinalTotal As Integer = 1
        Dim FinalFolder As String = ""
        Dim FinalStatus As String = ""
        Dim bStarted As Boolean = False

        Try
            ' Loop until end of queue
            While True

                ' Exit loop when end of queue reached
                EmailFolder = _EmailFolders.Dequeue()
                If EmailFolder.Equals(_POISON) Then
                    _EmailFolders.Enqueue(_POISON)
                    Exit While
                End If

                ' Begin new Process thread and wait for shut down
                bStarted = True
                FolderName = EmailFolder.Name  ' used in Catch
                oConverter.Folder = EmailFolder
                Dim oTask = Task(Of Dictionary(Of String, Object)).Factory.StartNew(AddressOf oConverter.convert_to_pdf)
                oTask.Wait()
                Result = oTask.Result

                ' For final status bar update
                FinalCount = oConverter.Count
                FinalTotal = oConverter.Total
                FinalFolder = EmailFolder.Name

                ' If error occurred in current thread or parent form signals cancellation, shut down thread
                If Not IsNothing(Result("OpError")) Then
                    ' Store first error from all Worker threads, shut down current thread, and perform status bar final update
                    If IsNothing(_ParentResult("OpError")) Then _ParentResult("OpError") = Result("OpError")
                    FinalStatus = "Error"
                    Exit While
                ElseIf Result("Cancelled") Then
                    ' Shut down current thread and perform status bar final update
                    FinalStatus = "Cancelled"
                    Exit While

                End If

                ' Add to completed folder count and update parent form status bar
                CompletedCount += 1
                RaiseEvent ConvertStatus(Me, CompletedCount)

                ' For final status bar update
                FinalCount = 1
                FinalTotal = 1
                FinalFolder = ""
                FinalStatus = "Worker Complete"

            End While
            oConverter = Nothing

            ' Final status bar update for Worker
            If Not bStarted Then
                ' Process thread not started due to end of EmailFolder queue
                Task.Factory.StartNew(Sub() EventHandler(Me, 0, 0, $"Worker({WorkerId})", "Not Started", WorkerId))
            Else
                ' Process thread started at least one time 
                Task.Factory.StartNew(Sub() EventHandler(Me, FinalCount, FinalTotal, FinalFolder, FinalStatus, WorkerId))
            End If

        Catch ex As Exception
            ' Handles errors that occur in this method but not the Process thread to ensure Worker thread shuts down safely
            ' Exception logged by parent form
            Logger.WriteToLog($"An error occurred in Worker({WorkerId}) on folder {FolderName}")
            If IsNothing(_ParentResult("OpError")) Then _ParentResult("OpError") = ex
            Task.Factory.StartNew(Sub() EventHandler(Me, 0, 0, FolderName, "Error", WorkerId))

        End Try

    End Sub

    Private Sub UpdateProgress(Count As Integer, Total As Integer, Folder As String, OpStep As String, WorkerId As Integer)
        ' Update status bar

        ' Define form objects based on WorkerId
        Dim lblFolder As Label = Me.Controls($"lblFolder{WorkerId}")
        Dim lblStep As Label = Me.Controls($"lblStep{WorkerId}")
        Dim lblCount As Label = Me.Controls($"lblCount{WorkerId}")
        Dim prog As ProgressBar = Me.Controls($"ProgressBar{WorkerId}")

        ' Update form objects
        lblFolder.Text = Folder
        lblStep.Text = OpStep
        lblCount.Text = $"{Count} of {Total}"
        prog.Minimum = 0
        prog.Maximum = Total
        prog.Value = Count

    End Sub

    Private Sub EventHandler(sender As Object, Count As Integer, Total As Integer, Folder As String,
                                        OpStep As String, WorkerId As Integer)
        ' Update status bar for current Worker

        Me.BeginInvoke(New ConvertUpdate(AddressOf UpdateProgress),
                New Object() {Count, Total, Folder, OpStep, WorkerId})

    End Sub

    Private Sub cmdLocation_Click(sender As Object, e As EventArgs) Handles cmdLocation.Click
        ' Hidden button, used for determing form location

        MsgBox(Me.Location.ToString)

    End Sub


End Class