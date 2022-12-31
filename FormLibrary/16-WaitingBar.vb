'Imports System.Windows.Forms
'Imports System.Threading
'Imports ClassLibrary
Imports ClassLibrary
Imports ClassLibrary.GlobalObjects

Public Class frmWaiting

    ' TODO: Change WaitingArgs to Object

    ' Class variables
    Dim _argArgs As WaitingArgs

    Public Sub New(args As WaitingArgs)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _argArgs = args

    End Sub

    Private Sub frmProgress_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Set form properties
        Me.Text = $"{_argArgs.Operation} Status"
        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size

    End Sub
    Private Sub frmWaiting_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Begin Restore operation once form loads

        BackgroundWorker1.RunWorkerAsync(_argArgs)

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object,
                                         ByVal e As System.ComponentModel.DoWorkEventArgs) _
                                         Handles BackgroundWorker1.DoWork

        Dim a As WaitingArgs = e.Argument

        'Execute operations, exceptions handled by methods
        If a.Operation = "Restore" Then
            CurrDirectory.RestoreProject(a.FilePath)
        ElseIf a.Operation = "Remove" Then
            CurrDirectory.RemoveProject(a.Project)
        ElseIf a.Operation = "Backup" Then
            CurrDirectory.BackupProject(a.Project, a.FilePath)
        End If


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object,
                                                     ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) _
                                                     Handles BackgroundWorker1.RunWorkerCompleted

        ' Close form when BackgroundWorker is completed.
        Me.Close()

    End Sub


End Class