
Imports System.IO
Imports System.Threading
Imports ClassLibrary.GlobalObjects

Public Class frmExportProgress

    Private Delegate Sub UpdateDelegate(OpStep As String, Count As Integer, Total As Integer)

    Private WithEvents _Exporter As Exporter
    Private WithEvents _Converter As frmWorkerProgress

    Private _EmailFolder As DirectoryInfo
    Private _AttachFolder As DirectoryInfo

    Private _Type As String
    Private _Cts As CancellationTokenSource
    Private _Token As CancellationToken
    Private _ConvertTotal As Integer = 0
    Private _OpStep As String = ""
    Private _ScaleFactor

    Private ReadOnly _ACTIVE = Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlLight)
    Private ReadOnly _INACTIVE = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveBorder)
    Private ReadOnly _MOUSEOVER = Drawing.Color.LightSteelBlue

    Public Sub New(EmailFolder As DirectoryInfo, AttachFolder As DirectoryInfo)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Create scale factor because value of 'AutoScaleDimensions' changes with screen resolution
        _ScaleFactor = Me.CurrentAutoScaleDimensions.Width / 96

        ' Object variables
        _EmailFolder = EmailFolder
        _AttachFolder = AttachFolder
        _Type = EmailFolder.Parent.Name
        _Cts = New CancellationTokenSource
        _Token = _Cts.Token

    End Sub

    Private Sub frmExportProgress_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Form properties
        Dim iLeft = {Me.Left - System.Convert.ToInt32(300 * _ScaleFactor), 0}.Max()
        Me.Left = iLeft
        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size

    End Sub

    Private Async Sub frmExportProgress_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Initialize form objects

        ' > Hide Location Button
        Me.cmdLocation.Visible = False

        ' > Progress Bar Label
        Me.lblStep.Text = ""
        ' > Begin button
        Me.cmdBegin.Enabled = True
        Me.cmdBegin.BackColor = _ACTIVE
        Me.cmdBegin.FlatAppearance.MouseOverBackColor = _MOUSEOVER
        ' > Cancel Button
        Me.cmdCancel.Enabled = False
        Me.cmdCancel.BackColor = _INACTIVE
        Me.cmdCancel.FlatAppearance.MouseOverBackColor = _MOUSEOVER
        ' > Close Button
        Me.cmdClose.Enabled = True
        Me.cmdClose.BackColor = _ACTIVE
        Me.cmdClose.FlatAppearance.MouseOverBackColor = _MOUSEOVER

        ' Set Active Control
        Me.cmdBegin.Select()

        ' Pause for 1 second then begin
        Await Task.Delay(1000)
        cmdBegin.PerformClick()

    End Sub

    Private Async Sub cmdBegin_Click(sender As Object, e As EventArgs) Handles cmdBegin.Click
        ' Save all emails for specified Type as mhtml documents, convert each mhtml file to pdf
        '    and merge all pdf files to 'locked' pdf

        Dim Result As New Dictionary(Of String, Object)
        Dim oTask As Task(Of Dictionary(Of String, Object))

        ' Update buttons
        ' > Begin button
        Me.cmdBegin.Enabled = False
        Me.cmdBegin.BackColor = _INACTIVE
        ' > Cancel Button
        Me.cmdCancel.Enabled = True
        Me.cmdCancel.BackColor = _ACTIVE
        ' > Close Button
        Me.cmdClose.Enabled = False
        Me.cmdClose.BackColor = _INACTIVE

        'Debug.WriteLine($"Start > {Now.ToString("yyyy-MM-dd_HH-mm-ss")}")

        Try
            ' Initialize status bar
            _OpStep = "Initializing"
            UpdateProgress(_OpStep, 0, 0)
            Await Task.Delay(500)

            ' EXPORT PROCESS 

            'Start exporting process, wait for process to complete
            _OpStep = "Exporting Emails"
            UpdateProgress(_OpStep, 0, 0)
            oTask = Task(Of Dictionary(Of String, Object)).Factory.StartNew(AddressOf export)
            Await oTask
            Result = oTask.Result

            ' If error occurs in export it gets stored in OpError and thread shuts down
            If Not IsNothing(Result("OpError")) Then
                Throw New AggregateException(message:="Export Emails Error", innerException:=Result("OpError"))
            End If
            If Result("Cancelled") Then Throw New OperationCanceledException

            ' Pause to let form catch up
            Await Task.Delay(500)

            ' CONVERT PROCESS

            ' Start convert process, wait for process to complete
            _OpStep = "Creating pdf"
            UpdateProgress(_OpStep, 0, 0)
            oTask = Task(Of Dictionary(Of String, Object)).Factory.StartNew(AddressOf convert)
            Await oTask
            Result = oTask.Result

            ' If error occurred in any thread during convert, first error get stored
            If Not IsNothing(Result("OpError")) Then
                Throw New AggregateException(message:="Convert to pdf Error", innerException:=Result("OpError"))
            End If
            If Result("Cancelled") Then Throw New OperationCanceledException ' not needed

        Catch ex As OperationCanceledException
            UpdateProgress("Cancelled", Me.ProgressBar.Value, Me.ProgressBar.Maximum)

        Catch ex As AggregateException
            ' For errors in export or convert process
            Dim s As String = $"'{ex.InnerException.GetType}' occurred at step {_OpStep}"
            Logger.WriteToLog($"{s}\n{ex.InnerException}")
            MsgBox(s, vbOKOnly + vbCritical, ex.Message)

        Catch ex As Exception
            ' For all other errors
            Dim s As String = $"'{ex.GetType}' occurred at step {_OpStep}"
            Logger.WriteToLog($"{s}\n{ex}")
            MsgBox(s, vbOKOnly + vbCritical, "Export Error")

        End Try

        'Debug.WriteLine($"End > {Now.ToString("yyyy-MM-dd_HH-mm-ss")}")

        ' Process Complete, update buttons
        Me.cmdCancel.Enabled = False
        Me.cmdCancel.BackColor = _INACTIVE
        Me.cmdClose.Enabled = True
        Me.cmdClose.BackColor = _ACTIVE
        Me.cmdClose.Select()

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        ' Send cancellation signal to all child threads to shut them down safely

        ' Update status bar and deactivate Cancel button
        UpdateProgress("Cancelling...Please wait for all workers to complete", Me.ProgressBar.Value, Me.ProgressBar.Maximum)
        Me.cmdCancel.Enabled = False
        Me.cmdCancel.BackColor = _INACTIVE

        ' Send cancel signal to child threads
        _Cts.Cancel()

    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        ' Button activated after all child threads are closed

        Me.Close()

    End Sub

    Private Function export() As Dictionary(Of String, Object)
        ' Export emails and attachments and both logs

        Dim Result As New Dictionary(Of String, Object)

        Try
            ' Start Export Process
            _Exporter = New Exporter(_EmailFolder, _AttachFolder, _Token, _Type)
            Result = _Exporter.export()

            ' Cleanup
            _Exporter = Nothing

        Catch ex As Exception
            ' Store error and shut down thread, loged by main thread
            Result("OpError") = ex

        End Try

        Return Result

    End Function

    Private Function convert() As Dictionary(Of String, Object)
        ' Step 1) Convert all mhtml files to pdf files
        ' Step 2) Merge all pdf files in a subfolder into one pdf file (locked)

        Dim EmailFolders As DirectoryInfo()
        Dim iFiles As Integer

        ' Initialize
        Dim Result = New Dictionary(Of String, Object) From {
            {"Cancelled", False},
            {"OpError", Nothing}
            }

        Try
            ' Get all subfolders (created by email export) in selected email root folder
            EmailFolders = _EmailFolder.GetDirectories()
            _ConvertTotal = EmailFolders.Count

            ' Check File count
            Dim FileFilter As String = IIf(_Type = "Redaction", "*.pdf", "*.mhtml")
            iFiles = 0
            For Each _EmailFolder In EmailFolders
                iFiles += _EmailFolder.GetFiles(FileFilter).Where(Function(f) Not f.Name.StartsWith("~$")).Count
            Next
            If iFiles = 0 Then
                ' If no files found, display message and exit
                MsgBox("No Email Files")
                Return Result
            End If

            ' Update status to set label and total
            Me.BeginInvoke(New UpdateDelegate(AddressOf UpdateProgress), New Object() {_OpStep, 0, _ConvertTotal})

            ' Open Worker form to begin convert process 
            _Converter = New frmWorkerProgress(EmailFolders, _Token, Result)
            With _Converter
                .ShowDialog() ' do not add 'Me'
            End With

        Catch ex As Exception
            ' Store error and shut down thread
            Result("OpError") = ex

        End Try

        Return Result

    End Function

    Private Sub UpdateProgress(OpStep As String, Count As Integer, Total As Integer)
        ' Update progress bar

        Me.lblStep.Text = OpStep
        Me.lblTotalCount.Text = $"{Count} of {Total}"
        Me.ProgressBar.Maximum = Total
        Me.ProgressBar.Value = Count

    End Sub

    Private Sub Export_UpdateProgress(sender As Object, OpStep As String, Count As Integer, Total As Integer
                                        ) Handles _Exporter.ExportStatus
        ' During export process, progress bar updated by Export Thread

        Me.BeginInvoke(New UpdateDelegate(AddressOf UpdateProgress),
                New Object() {OpStep, Count, Total})

    End Sub

    Private Sub Convert_UpdateProgress(sender As Object, Count As Integer
                                        ) Handles _Converter.ConvertStatus
        ' During convert process, progress bar updated by Worker Progress form

        Me.BeginInvoke(New UpdateDelegate(AddressOf UpdateProgress),
                New Object() {Me.lblStep.Text, Count, Me.ProgressBar.Maximum})

    End Sub

    Private Sub ConvertComplete_UpdateProgress(sender As Object, Status As String) Handles _Converter.ConvertComplete
        ' After convert process completes, final update of status bar and deactivate Cancel button

        Me.BeginInvoke(New UpdateDelegate(AddressOf UpdateProgress),
                New Object() {Status, Me.ProgressBar.Value, Me.ProgressBar.Maximum})

        Me.BeginInvoke(
            Sub()
                Me.cmdCancel.Enabled = False
                Me.cmdCancel.BackColor = _INACTIVE
                Me.cmdClose.Select()
            End Sub)

    End Sub

    Private Sub cmdLocation_Click(sender As Object, e As EventArgs) Handles cmdLocation.Click
        ' Hidden button, used for determing form location

        MsgBox(Me.Location.ToString)

    End Sub
End Class