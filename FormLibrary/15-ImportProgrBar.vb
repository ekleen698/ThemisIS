Imports System.Windows.Forms
Imports System.Threading
Imports ClassLibrary
Imports ClassLibrary.GlobalObjects

Public Class frmImportProgress
    ' Disable Close button
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim param As CreateParams = MyBase.CreateParams
            param.ClassStyle = param.ClassStyle Or &H200
            Return param
        End Get
    End Property

    ' Declare objects needed for ImportThread in ImportEmails
    Dim WithEvents oImport As ImportEmails
    Public Delegate Sub ImportHandler(ByVal iCount As Integer, ByVal iTotal As Integer,
                              ByVal sFile As String, ByVal bEnd As Boolean)

    Private _PSTFiles As PSTFiles

    Public Sub New(PSTFiles As PSTFiles)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _PSTFiles = PSTFiles
        Me.Text = "Progress"

        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Maximum = 100
        Me.ProgressBar1.Style = ProgressBarStyle.Continuous

    End Sub

    Private Sub frmProgress_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Form properties
        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size

    End Sub

    Private Sub frmImportProgress_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        ' Begin automatically
        Import()

    End Sub

    Private Sub Import()

        ' TODO: Change to Task (see Export)
        oImport = New ImportEmails
        oImport.StartImport(_PSTFiles)

    End Sub

    Private Async Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

        Logger.WriteToLog($"Import cancelled by user.")
        Me.cmdCancel.Enabled = False
        oImport.StopImport()
        Dim oTask = Task.Factory.StartNew(
            Sub()
                While oImport.ImportThread.IsAlive
                    ' Wait for thread to shut down
                End While
            End Sub)
        Await oTask
        Thread.Sleep(500)
        Close()

    End Sub

    Private Sub ImportStatus(ByVal iCount As Integer, ByVal iTotal As Integer,
                        ByVal sFile As String, ByVal bEnd As Boolean)

        ' Update form each time event fires
        Me.lblFile.Text = sFile
        If iCount = -1 Then
            Cursor.Current = Cursors.WaitCursor
            Me.lblCount.Visible = False
            Me.ProgressBar1.Maximum = 100
            Me.ProgressBar1.Value = 100
        Else
            Me.lblCount.Visible = True
            Me.lblCount.Text = $"{iCount} of {iTotal} Emails"
            Me.ProgressBar1.Value = iCount
            Me.ProgressBar1.Maximum = iTotal
        End If

        If bEnd Then
            Close()
        End If

    End Sub

    Private Sub Import_ImportStatus(ByVal sender As Object, ByVal iCount As Integer,
                        ByVal iTotal As Integer, ByVal sFile As String, ByVal bEnd As Boolean
            ) Handles oImport.ImportStatus
        ' BeginInvoke causes asynchronous execution to begin at the address
        ' specified by the delegate. Simply put, it transfers execution of
        ' this method back to the main thread. Any parameters required by
        ' the method contained at the delegate are wrapped in an object and
        ' passed.

        Me.BeginInvoke(New ImportHandler(AddressOf ImportStatus),
                New Object() {iCount, iTotal, sFile, bEnd})

    End Sub

End Class