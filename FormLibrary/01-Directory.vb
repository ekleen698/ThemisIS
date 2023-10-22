Imports ClassLibrary
Imports ClassLibrary.GlobalObjects
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.IO

Public Class frmDirectory

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        ' Disable Close button
        Get
            Dim param As CreateParams = MyBase.CreateParams
            param.ClassStyle = param.ClassStyle Or &H200
            Return param
        End Get
    End Property

    Private _dtProjects As New DataTable
    Private _oSettings As New ClassLibrary.My.MySettings
    Private _ScaleFactor As Single
    Private _DevMode As Boolean

    Public Sub New(Optional ByVal devMode As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Create scale factor because value of 'AutoScaleDimensions' changes with screen resolution
        _ScaleFactor = Me.CurrentAutoScaleDimensions.Width / 96
        _DevMode = devMode

    End Sub

    Private Sub frmDirectory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize form settings on load

        Try
            ' Form properties
            Me.MaximumSize = Me.Size
            Me.MinimumSize = Me.Size

            ' Update form footer
            Me.lblThemis.Text = $"{Application.ProductName} v{Application.ProductVersion}"

            ' Add columns to listview -> auto scale does not affect column widths
            With Me.lvProjects.Columns
                .Add("ID", Convert.ToInt32(35 * _ScaleFactor)) '35
                .Add("Name", Convert.ToInt32(216 * _ScaleFactor)) '216
                .Add("District", Convert.ToInt32(216 * _ScaleFactor)) '216
                .Add("Owner", Convert.ToInt32(160 * _ScaleFactor)) '160
                .Add("Description", 0)
            End With

            ' Get server name from user settings, if default value then use computer name
            If _oSettings.Server <> "" Then
                Me.txtServer.Text = _oSettings.Server
            Else
                Me.txtServer.Text = Environment.MachineName
            End If

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Form Load Error")
            Logger.WriteToLog($"[{ex.GetType}] occurred while loading Directory form.")
            Logger.WriteToLog(ex.ToString)
            Me.Close()

        End Try

    End Sub

    Private Sub frmDirectory_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' For developer testing, automatically connect to server

        If _DevMode Then Me.cmdConnectServer.PerformClick()

    End Sub

    Private Sub frmDirectory_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Clear data table and close Directory and Server object connections

        Try
            _oSettings = Nothing
            _dtProjects.Dispose()
            If Not IsNothing(CurrDirectory) Then CurrDirectory.Close()  'executes CurrServer.Close()

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Form Close Error")
            Logger.WriteToLog($"[{ex.GetType}] occurred while closing Directory form.")
            Logger.WriteToLog(ex.ToString)

        End Try

    End Sub

    Private Sub cmdConnectServer_Click(sender As Object, e As EventArgs) Handles cmdConnectServer.Click
        ' Attempt to connect to SQL Server, enable form objects if successful

        Try
            ' Display wait cursor while server object tries to connect
            Cursor.Current = Cursors.WaitCursor
            'Application.DoEvents()

            ' Ensure Filestream folder exists, creates new folder if it doesn't
            If Not (New DirectoryInfo("C:\Filestream").Exists) Then
                System.IO.Directory.CreateDirectory("C:\Filestream")
            End If

            ' Create server object, throws exception if not connected after 10 seconds
            Dim ServerName = IIf(Me.txtServer.Text = "", Environment.MachineName, Me.txtServer.Text)
            CurrServer = New Server(ServerName)

            ' After connection made, save server name in user settings
            txtServer.Text = CurrServer.Name
            _oSettings.Server = CurrServer.Name
            _oSettings.Save()
            _oSettings = New ClassLibrary.My.MySettings

            ' Destroy all mlg databases, used to remove directory for application revision
            If _oSettings.Destroy Then
                CurrServer.destroy()
                _oSettings.Destroy = False
                _oSettings.Save()
                _oSettings = New ClassLibrary.My.MySettings
            End If

            ' Connect to Project Directory database, throws exception if not connected after 10 seconds
            CurrDirectory = New ClassLibrary.Directory(_DevMode)

            ' Check Directory compatibility with current application version
            If Not CurrDirectory.IsCompatible Then
                Logger.WriteToLog("Directory incompatible with current version.")
                MsgBox($"The current directory was created with v{CurrDirectory.AppVersion} of the application and " &
                       "is not compatible with the current version.  Either restore a previous version of the application " &
                       "or open Settings and change 'Destroy' to True, then click Connect.",
                        vbOKOnly, "Incompatible Version")
                CurrServer.Close()
                Exit Sub
            End If

            'CurrDirectory

            'Disable form server objects and update connection status label
            cmdConnectServer.Enabled = False
            txtServer.Enabled = False
            lblConnected.Text = "***Server connected***"
            lblConnected.ForeColor = Drawing.Color.Green

            'Enable form database objects
            cmdOpen.Enabled = True
            cmdEdit.Enabled = True
            cmdCreate.Enabled = True
            cmdBackup.Enabled = True
            cmdRestore.Enabled = True
            cmdRemove.Enabled = True
            lnkActivity.Enabled = True
            Me.lvProjects.Enabled = True

            'Update project listview
            RefreshProjects()

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Server Connection Error")
            Logger.WriteToLog($"[{ex.GetType}] occurred while attempting to connect to the server.")
            Logger.WriteToLog(ex.ToString)

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Sub

    Private Sub cmdSettings_Click(sender As Object, e As EventArgs) Handles cmdSettings.Click

        Try
            With New frmUserSettings
                .ShowDialog()
            End With

            ' Update settings object
            _oSettings = New ClassLibrary.My.MySettings

            ' If server not connected, update server name text box
            If IsNothing(CurrServer) Then Me.txtServer.Text = _oSettings.Server

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "User Settings Form Open Error")
            Logger.WriteToLog($"[{ex.GetType}] occurred with Project Details form.")
            Logger.WriteToLog(ex.ToString)

        End Try

    End Sub

    Private Sub cmdOpen_Click(sender As Object, e As EventArgs) Handles cmdOpen.Click
        'Open the Project Detail form for the currently selected project

        Dim iID As Integer

        If Me.lvProjects.SelectedItems.Count = 0 Then Exit Sub

        Try
            'Get project ID of selected item, create global objects used by frmProjDetails
            iID = Convert.ToInt32((Me.lvProjects.SelectedItems()(0)).SubItems(0).Text)
            CurrProject = CurrDirectory.Projects(iID)
            CurrProjDB = New ProjectDB(CurrProject.DatabaseName)

            ' Check ProjectDB compatibility with current application version
            If CurrProjDB.IsCompatible Then
                'Open Project Details form
                With New frmProjDetails()
                    .ShowDialog(Me)
                End With

            Else
                Logger.WriteToLog($"Project Database '{CurrProjDB.Name}' is incompatible with current version.")
                MsgBox($"The selected project was created with v{CurrProjDB.AppVersion} of the application and " &
                       "is not compatible with the current version.",
                        vbOKOnly, "Incompatible Version")
            End If

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Project Details Form Open Error")
            Logger.WriteToLog($"[{ex.GetType}] occurred with Project Details form.")
            Logger.WriteToLog(ex.ToString)

        Finally
            'Ensure global objects are reset
            CurrProject = Nothing
            If Not IsNothing(CurrProjDB) Then
                CurrProjDB.Close()
                CurrProjDB = Nothing
            End If

        End Try

    End Sub

    Private Sub cmdEdit_Click(sender As Object, e As EventArgs) Handles cmdEdit.Click
        'Open Project Update form in 'Edit' mode for currently selected project

        Dim iID As Integer
        Dim oProject As Project

        Try
            If Me.lvProjects.SelectedItems.Count > 0 Then
                iID = Convert.ToInt32((Me.lvProjects.SelectedItems()(0)).SubItems(0).Text)


                oProject = CurrDirectory.Projects(iID)
                With New frmProjUpdate(oProject)
                    .ShowDialog(Me)
                End With

                'Refresh project list view
                RefreshProjects()

            End If

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Project Update Form Error")
            Logger.WriteToLog($"[{ex.GetType}] occurred with Project Update form.")
            Logger.WriteToLog(ex.ToString)

        Finally
            oProject = Nothing

        End Try

    End Sub

    Private Sub cmdCreate_Click(sender As Object, e As EventArgs) Handles cmdCreate.Click
        'Open Project Update form in 'Create' mode to add new project

        Try

            ' Validate license key, skip if DevMode
            Dim iResult As Integer = 0
            Dim sKey As String = ""
            If _DevMode Then
                iResult = 1
                sKey = "DevMode"
            Else
                With New frmLicenseKey()
                    .ShowDialog(Me)
                    iResult = .Result
                    sKey = .LicenseKey
                End With
            End If

            ' if valid key, create new project
            If iResult = 1 Then

                ' Open Project Update/Create form
                With New frmProjUpdate(sKey)
                    .ShowDialog()

                    If .Result Then
                        ' Update License key table
                        CurrDirectory.UpdateLicense(sKey, CurrProject.ProjectGuid)

                        'Refresh project list view
                        RefreshProjects()

                        'Open Project Details form with new project
                        With New frmProjDetails()
                            .ShowDialog(Me)
                        End With
                    End If

                End With

            End If

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Create Project Form Error")
            Logger.WriteToLog($"[{ex.GetType}] occurred with Project Create form.")
            Logger.WriteToLog(ex.ToString)

        End Try

    End Sub

    Private Sub cmdBackup_Click(sender As Object, e As EventArgs) Handles cmdBackup.Click
        'Create backup file for selected project

        Dim iID As Integer = 0
        Dim oProject As Project
        Dim oDialog As SaveFileDialog
        Dim oResult As DialogResult
        Dim sFilePath As String
        Dim sBUFolder As String = (New ClassLibrary.My.MySettings).BackupFolder

        Try
            If Me.lvProjects.SelectedItems.Count = 1 Then
                'Backup the selected project
                Logger.WriteToLog($"***Begin Project Database Backup***")

                iID = Convert.ToInt32((Me.lvProjects.SelectedItems()(0)).SubItems(0).Text)
                oProject = CurrDirectory.Projects(iID)

                'Select backup file, dialog confirms overwrite
                oDialog = New SaveFileDialog With {
                    .Title = "Save Project Backup File",
                    .InitialDirectory = sBUFolder,
                    .FileName = oProject.DatabaseName,
                    .Filter = "Backup (*.bak)|*.bak"}
                oResult = oDialog.ShowDialog(Me)
                If (oResult <> DialogResult.OK) Then
                    Logger.WriteToLog("Operation cancelled by user.")
                    Exit Sub
                End If
                sFilePath = oDialog.FileName

                ' Ensure backup folder selected, SQL Server cannot access user folders
                Dim oFile As FileInfo = New FileInfo(sFilePath)
                If oFile.Directory.FullName <> sBUFolder Then
                    MsgBox("Project must be saved up to backup folder", vbOKOnly, "Invalid Operation")
                    Exit Sub
                End If

                ' If file already exists, delete so backup can be detected after export
                If oFile.Exists Then
                    oFile.Delete()
                End If

                ' TODO: Open wait bar in task and run Restore from main thread?
                ' Open marquee form which starts backup operation
                With New frmWaiting(New WaitingArgs("Backup", Project:=oProject, FilePath:=sFilePath))
                    .ShowDialog(Me)
                End With

                ' Check if backup file exists
                oFile = New FileInfo(sFilePath)
                If oFile.Exists Then
                    Logger.WriteToLog($"Project {oProject.ID} successfully backed up to {oFile.FullName}.")
                    MsgBox($"Backup file created at {vbCrLf + vbCrLf}{oFile.FullName}")
                End If

                Logger.WriteToLog($"***End Project Database Backup***")

            ElseIf Me.lvProjects.SelectedItems.Count > 1 Then
                'More than 1 project selected
                MsgBox("Select only 1 Project can be selected.", , "Invalid Operation")

            Else
                'No projects selected
                MsgBox("No Project Selected", , "Invalid Operation")

            End If

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Project Backup Error")
            Logger.WriteToLog($"[{ex.GetType}] occurred while backing up project '{iID}'.")
            Logger.WriteToLog(ex.Message)

        Finally
            oProject = Nothing

        End Try

    End Sub

    Private Sub cmdRestore_Click(sender As Object, e As EventArgs) Handles cmdRestore.Click
        'Create new project, restore Project Database from backup file, and update the
        ' new project with the Project info at the time of backup.

        Dim sBakFolder As String = ""
        Dim oDialog As OpenFileDialog
        Dim oResult As DialogResult

        Try
            ' Get default backup folder from user settings
            _oSettings = New ClassLibrary.My.MySettings
            sBakFolder = _oSettings.BackupFolder

            'Select backup file, exit if invalid
            oDialog = New OpenFileDialog With {
                    .Title = "Select a Project Backup File",
                    .InitialDirectory = sBakFolder,
                    .Multiselect = False,
                    .Filter = "Backup (*.bak)|*.bak"}
            oResult = oDialog.ShowDialog()
            Dim sBakFilePath As String = oDialog.FileName
            If (oResult <> DialogResult.OK) Then
                Exit Sub
            End If

            ' Validate file, file path, and file type
            Dim oFile As FileInfo = New FileInfo(sBakFilePath)
            If Not oFile.Exists Then
                MsgBox("Invalid file name", , "Invalid Operation")
                Exit Sub

            ElseIf (Path.GetExtension(oFile.Name) <> ".bak") Then
                MsgBox("File must be .bak file", , "Invalid Operation")
                Exit Sub

            ElseIf oFile.Directory.FullName <> sBakFolder Then
                ' SQL Server cannot access user folders
                If MsgBox($"File must be located in database backup folder.{vbCrLf + vbCrLf}Move file to backup folder?",
                        vbYesNo, "Invalid Operation") <> MsgBoxResult.Yes Then Exit Sub
                Dim oMoveFile As FileInfo = New FileInfo(Path.Combine(sBakFolder, oFile.Name))
                If oMoveFile.Exists Then
                    If MsgBox($"File '{oMoveFile.Name}' already exists in backup folder, replace existing file?",
                              vbYesNo + vbCritical, "Move with Replace Warning") <> MsgBoxResult.Yes Then Exit Sub
                End If
                oFile.CopyTo(oMoveFile.FullName, True)
                oFile.Delete()
                sBakFilePath = oMoveFile.FullName

            End If

            ' Begin restore operation for selected file
            Logger.WriteToLog($"***Begin Project Database Restore***")
            Logger.WriteToLog($"Restoring Project from {sBakFilePath}")

            ' Open marquee form which starts restore operation
            With New frmWaiting(New WaitingArgs("Restore", FilePath:=sBakFilePath))
                .ShowDialog(Me)
            End With

            'Refresh project list view
            RefreshProjects()
            Logger.WriteToLog($"***End Project Database Restore***")

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Restore Project Error")
            Logger.WriteToLog($"[{ex.GetType}] occurred while attempting to restore the project.")
            Logger.WriteToLog(ex.Message)

        Finally
            oDialog = Nothing
            oResult = Nothing

        End Try

    End Sub

    Private Sub cmdRemove_Click(sender As Object, e As EventArgs) Handles cmdRemove.Click
        'Remove selected project from directory and delete project database

        Dim iID As Integer = 0
        Dim oProject As Project

        Try
            ' TODO: update dbo.sys_LicenseKeys 'Removed' date

            If Me.lvProjects.SelectedItems.Count > 0 Then
                iID = Convert.ToInt32((Me.lvProjects.SelectedItems()(0)).SubItems(0).Text)
                oProject = CurrDirectory.Projects(iID)

                If MsgBox($"Are you sure you want to remove project '{oProject.Name}'? " &
                        Constants.vbCrLf & Constants.vbCrLf &
                        "If you continue all items associated with this project will " &
                        "be permanently deleted.", MsgBoxStyle.Critical + MsgBoxStyle.OkCancel,
                        "Confirm Delete") = MsgBoxResult.Ok Then

                    ' Open marquee form which starts remove operation
                    With New frmWaiting(New WaitingArgs("Remove", Project:=oProject))
                        .ShowDialog(Me)
                    End With

                    'Refresh project list view
                    RefreshProjects()

                End If

            End If

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Remove Project Error")
            Logger.WriteToLog($"[{ex.GetType}] occurred while attempting to remove project {iID}.")
            Logger.WriteToLog(ex.Message)

        Finally
            oProject = Nothing

        End Try

    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        'Initiate 'Closing' event for current form

        Me.Close()

    End Sub

    Private Sub lnkActivity_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkActivity.LinkClicked
        ' Generate password-protected Excel file with Project activity log

        Dim desktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim destFile As String = ""
        Dim oFile As FileInfo

        Cursor.Current = Cursors.WaitCursor
        Try
            ' Create Excel file
            destFile = CurrDirectory.ActivityLog(desktopPath)
            oFile = New FileInfo(destFile)
            If oFile.Exists Then
                MsgBox($"Activity Log Exported{vbCrLf & vbCrLf}{destFile}", vbOKOnly, "Operation Complete")

            Else
                ' this should not happen
                Throw New FileNotFoundException

            End If

        Catch ex As OperationCanceledException
            ' Do nothing

        Catch ex As Exception
            If Not IsNothing(ex.InnerException) Then
                ex = ex.InnerException
            End If
            Logger.WriteToLog(ex)
            MsgBox($"{ex.GetType} while exporting file{vbCrLf & vbCrLf}Path: <{destFile}>",
                   vbOKOnly + vbCritical, "File Save Error")


        End Try
        Cursor.Current = Cursors.Default


    End Sub

    Private Sub lvProjects_ItemSelectionChanged(sender As Object,
                e As ListViewItemSelectionChangedEventArgs) Handles _
                lvProjects.ItemSelectionChanged
        'Display description of selected project when a listview row is selected

        Try
            If Me.lvProjects.SelectedItems.Count > 0 Then
                txtDescription.Text = Me.lvProjects.Items(e.ItemIndex).SubItems(4).Text
            End If

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Update Project Description Error")

        End Try

    End Sub

    Private Sub RefreshProjects()
        'Refresh the listview
        'Throws exception

        Dim row(4) As String

        Try
            'Clear all data from listview and project description textbox
            Me.lvProjects.Items.Clear()
            Me.txtDescription.Text = ""

            'Create a new row in the listview for each project
            For Each itm In CurrDirectory.Projects
                row(0) = itm.Value.ID
                row(1) = itm.Value.Name
                row(2) = itm.Value.District
                row(3) = itm.Value.Owner
                row(4) = itm.Value.Description
                lvProjects.Items.Add(New ListViewItem(row))
            Next

            'Select first row
            If lvProjects.Items.Count > 0 Then
                lvProjects.Items(0).Selected = True
            End If

        Catch ex As Exception
            Logger.WriteToLog($"{ex.GetType} occurred while refreshing the Projects view.")
            Logger.WriteToLog(ex.Message)
            Throw ex

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim obj1 = Me.AutoScaleDimensions
        Dim obj2 = Me.CurrentAutoScaleDimensions

        MsgBox($"Autoscale: {obj1.Width} x {obj1.Height}{vbCrLf + vbCrLf}Current: {obj2.Width} x {obj2.Height}")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        MsgBox($"Client: {Me.ClientSize.Width} x {Me.ClientSize.Height}{vbCrLf + vbCrLf}Form: {Me.Width} x {Me.Height}")

    End Sub

End Class