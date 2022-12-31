Imports ClassLibrary.GlobalObjects
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frmExport

    Dim _ExportType As String

    Public Sub New(ExportType As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _ExportType = ExportType

    End Sub

    Private Sub frmExport_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Initialize form properties
        Me.cmdLocation.Visible = False
        Me.cmdSize.Visible = False
        'Me.Location = New Drawing.Point(450, 200)

        ' Set initial Root path to Desktop
        Me.txtFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Me.lblSubFolder.Text = $"\{_ExportType}"

    End Sub

    Private Sub lnkBrowse_LinkClicked(sender As Object,
                            e As LinkLabelLinkClickedEventArgs) Handles lnkBrowse.LinkClicked
        ' Get folder path from dialog and enter into text box

        Dim sFolder As String = Me.txtFolder.Text
        Dim drResult As DialogResult
        Dim dSelect As New FolderBrowserDialog With {
            .Description = "Select Destination Folder",
            .ShowNewFolderButton = True,
            .SelectedPath = sFolder
            }

        drResult = dSelect.ShowDialog
        If drResult <> DialogResult.OK Then
            Exit Sub
        End If

        Me.txtFolder.Text = dSelect.SelectedPath

    End Sub

    Private Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        ' Export Emails/Attachments to selected subfolder


        'Dim sType As String = Me.cmbType.Text
        Dim RootFolder As DirectoryInfo
        Dim TypeFolder As DirectoryInfo
        Dim EmailFolder As DirectoryInfo
        Dim AttachFolder As DirectoryInfo

        ' If root folder doesn't exist, either create new folder or cancel
        RootFolder = New DirectoryInfo(Me.txtFolder.Text)
        If Not RootFolder.Exists Then
            If MsgBox($"Folder does not exist, create new folder?{vbCrLf & vbCrLf}{RootFolder.FullName}",
                      vbInformation + vbYesNo, "Confirm Create Folder") = MsgBoxResult.Yes Then
                Try
                    RootFolder.Create()
                Catch
                    MsgBox("Could not create folder, ensure folder name is valid or use 'browse' to select.", vbCritical + vbOKOnly,
                           "Invalid Folder")
                    Exit Sub
                End Try

            Else
                Exit Sub
            End If
        End If

        ' If root\subfolder exists either delete folder or exit
        TypeFolder = New DirectoryInfo(Path.Combine(RootFolder.FullName, _ExportType))
        If TypeFolder.Exists Then
            If MsgBox($"Folder already exists, delete folder and all contents?{vbCrLf & vbCrLf}{TypeFolder.FullName}",
                    vbCritical + vbYesNo, "Confirm Delete Folder") = MsgBoxResult.Yes Then
                Try
                    TypeFolder.Delete(True)
                Catch ex As IOException
                    MsgBox("Folder could not be deleted, please ensure all files are closed.", vbOKOnly, "Delete Folder Failed")
                    Exit Sub

                End Try

            Else
                Exit Sub
            End If
        End If

        ' Create Type subfolder
        TypeFolder.Create()
        EmailFolder = New DirectoryInfo(Path.Combine(TypeFolder.FullName, "Emails"))
        EmailFolder.Create()
        AttachFolder = New DirectoryInfo(Path.Combine(TypeFolder.FullName, "Attachments"))
        AttachFolder.Create()

        ' Open Export Progress Bar which starts the export operation
        Me.Hide()
        With New frmExportProgress(EmailFolder, AttachFolder)
            .ShowDialog(Me)
        End With
        Me.Close()

    End Sub

    Private Sub cmdLocation_Click(sender As Object, e As EventArgs) Handles cmdLocation.Click
        ' Hidden button

        MsgBox(Me.Location.ToString)
    End Sub

    Private Sub cmdSize_Click(sender As Object, e As EventArgs) Handles cmdSize.Click
        ' Hiddem button

        MsgBox(Me.Size.ToString)
    End Sub

End Class