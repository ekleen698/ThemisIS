Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Runtime.InteropServices
Imports ClassLibrary.GlobalObjects
Imports Microsoft.Office.Interop

Public Class Directory

    Public ReadOnly Property Name As String = "mlgSys_ProjDir"    'database name
    Public ReadOnly Property Connection As New SqlConnection
    Public ReadOnly Property IsConnected As Boolean = False
    Public ReadOnly Property Projects As New Dictionary(Of Integer, Project)
    Public ReadOnly Property IsCompatible As Boolean = False
    Public ReadOnly Property DevMode As Boolean = False
    Public ReadOnly Property AppVersion As Decimal = 0.0
    Private _MinAppVersion As Decimal = 3.1
    ' version = {major rev}.{minor rev}.{released update}.{developer build edition}

    Public Sub New(ByVal devMode As Boolean)
        'Ensure project directory database exists and connect to it
        'Throws exception

        Try
            _DevMode = devMode

            With CurrServer.Connection.CreateCommand
                .CommandText = $"SELECT COUNT(0) AS [count] FROM sys.databases WHERE name='{_Name}';"
                '***Cannot use parameter***

                If .ExecuteScalar > 0 Then
                    'Database already exists, connect to it and fill project collection
                    connect()

                    ' Check minimum version compatibility
                    _IsCompatible = compatible()

                    If _IsCompatible Then refreshProjects()

                Else
                    'Database doesn't exist, create new database
                    .CommandText = $"CREATE DATABASE [{_Name}];"
                    .ExecuteNonQuery()

                    'Connect to new database
                    connect()

                    'Create project directory objects
                    .Connection = _Connection
                    .CommandText = My.Resources.CreateDirectory
                    .ExecuteNonQuery()

                    'Create procedure used to reset the Sequence for the PK
                    .CommandText = My.Resources.fResetSeq
                    .ExecuteNonQuery()

                    ' Add Directory Info
                    .CommandText = $"
                        INSERT INTO dbo.[sys_DirectoryInfo] ([Key], [Value]) 
                        VALUES ('CreatedBy', SYSTEM_USER) 
                        , ('CreatedOn', CONVERT(VARCHAR, GETDATE(), 101)) 
                        , ('ApplicationVersion', @Ver); "
                    .Parameters.Add("@Ver", SqlDbType.VarChar, 100).Value = Application.ProductVersion
                    .ExecuteNonQuery()

                    ' Set compatibility
                    _IsCompatible = True

                End If
            End With

        Catch ex As Exception
            _Connection = Nothing
            _IsConnected = False
            Logger.WriteToLog($"{ex.GetType} occurred while connecting to '{_Name}'.")
            Logger.WriteToLog(ex.Message)
            Throw ex

        End Try

    End Sub

    Public Sub Close()
        'Called by Closing event of frmDirectory

        Try
            'Close Directory connection and clear all properties
            _Name = Nothing
            _Connection.Close()
            _IsConnected = False
            _Projects = Nothing

        Catch

        Finally
            Logger.WriteToLog("Project directory disconnected.")

            'Close Server connection
            If Not IsNothing(CurrServer) Then CurrServer.Close()

        End Try

    End Sub

    Public Function AddNewProject(LicenseKey As String, ApplicationVersion As String, Name As String,
                                Owner As String, District As String, Description As String) As Project
        ' For creating new projects

        ' Insert new row into project directory
        Dim oProject As Project = AddProject(LicenseKey, ApplicationVersion, Name, Owner, District, Description)


        Try
            ' Create Project Database for new project using derived database name
            With New ProjectDB()
                .Create(oProject.DatabaseName, oProject.LicenseKey, oProject.ProjectGuid)
                .Close()
            End With

            ' Add entry to History table
            UpdateHistory(oProject.ProjectGuid, oProject.Name, oProject.District, "Add")

            Return oProject

        Catch ex As Exception
            Logger.WriteToLog($"Removing new project due to error.")
            RemoveProject(oProject)
            Throw New Exception("Create Project Database Error", ex)

        End Try

    End Function

    Private Function AddProject(Optional LicenseKey As String = "", Optional ApplicationVersion As String = "",
                                Optional Name As String = "", Optional Owner As String = "",
                                Optional District As String = "", Optional Description As String = ""
                                ) As Project
        ' Add project to directory
        ' Exception: return Nothing

        Dim iID As Integer = 0
        Dim oProject As Project

        Try
            'Insert new row into directory table
            With _Connection.CreateCommand
                .CommandText = $"
                INSERT INTO [ProjectDirectory] ([ApplicationVersion], [LicenseKey], [Name], [Owner], [District], [Description]) 
                VALUES ( @AppVers, @License, @Name, @Owner, @District, @Description); 
                SELECT CAST([last_used_value] AS INT) AS [ID]
                FROM [sys].[sequences] WHERE [name] ='sProjectDirectory_PK';"
                .Parameters.Add("@License", SqlDbType.VarChar, 255).Value = LicenseKey
                .Parameters.Add("@AppVers", SqlDbType.VarChar, 255).Value = ApplicationVersion
                .Parameters.Add("@Name", SqlDbType.VarChar, 15).Value = Name
                .Parameters.Add("@Owner", SqlDbType.VarChar, 25).Value = Owner
                .Parameters.Add("@District", SqlDbType.VarChar, 25).Value = District
                .Parameters.Add("@Description", SqlDbType.VarChar, 255).Value = Description

                'Execute INSERT and return new row ID for next step
                iID = .ExecuteScalar()

            End With

            ' Update collection of projects -> kills all Project objects and recreates new objects
            ' from Project Directory database table
            refreshProjects()
            oProject = _Projects(iID)

            Logger.WriteToLog($"Project {iID} added to the Project Directory.")

            'Return Project object for new project
            Return oProject

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            Return Nothing

        End Try

    End Function

    Public Sub UpdateProject(ByRef Project As Project, Name As String, Owner As String,
                             District As String, Description As String)
        ' Update project properties in directory table
        ' Throws exception

        Dim iID As Integer = Project.ID

        'Execute UPDATE SQL
        With _Connection.CreateCommand()
            .CommandText = "
                UPDATE [ProjectDirectory] 
                SET [Name]=@Name, [Owner]=@Owner, [District]=@District, [Description]=@Description
                WHERE [ID]=@ID;"
            .Parameters.Add("@Name", SqlDbType.VarChar, 15).Value = Name
            .Parameters.Add("@Owner", SqlDbType.VarChar, 25).Value = Owner
            .Parameters.Add("@District", SqlDbType.VarChar, 25).Value = District
            .Parameters.Add("@Description", SqlDbType.VarChar, 255).Value = Description
            .Parameters.Add("@ID", SqlDbType.Int).Value = iID
            .ExecuteNonQuery()
        End With

        'Update collection of projects -> kills all Project objects and recreates new objects
        'from Project Directory database table
        refreshProjects()
        Project = CurrDirectory.Projects(iID)

        ' Add entry to History table
        UpdateHistory(Project.ProjectGuid, Project.Name, Project.District, "Update")

        Logger.WriteToLog($"Project {iID} updated.")

    End Sub

    Private Sub UpdateProject(ByRef Project As Project, Name As String, Owner As String, District As String,
                             Description As String, ProjectGuid As String, CreatedOn As Date,
                             LicenseKey As String, ApplicationVersion As String)
        ' Update Restored project
        ' Throws exception

        Dim iID As Integer = Project.ID
        Dim sSQL As String = "
            UPDATE [ProjectDirectory] 
            SET [Name]=@Name, [Owner]=@Owner, [District]=@District, [Description]=@Description,
                [GUID]=@Guid, [CreatedOn]=@CreatedOn, [LicenseKey]=@License, [ApplicationVersion]=@AppVers
            WHERE [ID]=@ID;"

        'Execute UPDATE SQL
        With _Connection.CreateCommand
            .CommandText = sSQL
            .Parameters.Add("@Name", SqlDbType.VarChar, 15).Value = Name
            .Parameters.Add("@Owner", SqlDbType.VarChar, 25).Value = Owner
            .Parameters.Add("@District", SqlDbType.VarChar, 25).Value = District
            .Parameters.Add("@Description", SqlDbType.VarChar, 255).Value = Description
            .Parameters.Add("@Guid", SqlDbType.VarChar, 36).Value = ProjectGuid
            .Parameters.Add("@CreatedOn", SqlDbType.Date).Value = CreatedOn
            .Parameters.Add("@License", SqlDbType.VarChar, 32).Value = LicenseKey
            .Parameters.Add("@AppVers", SqlDbType.VarChar, 255).Value = ApplicationVersion
            .Parameters.Add("@ID", SqlDbType.Int).Value = iID
            .ExecuteNonQuery()
        End With

        ' Update collection of projects -> kills all Project objects and recreates new objects
        ' from Project Directory database table
        refreshProjects()
        Project = CurrDirectory.Projects(iID)

        Logger.WriteToLog($"Project {iID} updated.")

    End Sub

    Public Sub RemoveProject(ByRef Project As Project, Optional ByVal History As Boolean = False)
        'Delete project row in project directory table and drop project database

        Dim iID As Integer = Project.ID
        'Dim sGUID As String = Project.ProjectGuid
        'Dim sName As String = Project.Name
        'Dim sDistrict As String = Project.District

        Try
            ' Drop project database
            CurrServer.DropDB(Project.DatabaseName)

            ' Reset Primary Key after removing row
            With Connection.CreateCommand
                .CommandText = "EXEC dbo.fResetSeq;"
                .ExecuteNonQuery()
            End With

            ' Add entry to History table
            If History Then UpdateHistory(Project.ProjectGuid, Project.Name, Project.District, "Remove")

            ' Update collection of projects
            refreshProjects()
            Logger.WriteToLog($"Project {iID} removed from the Project Directory.")

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Remove Project Error")
            Logger.WriteToLog(ex.ToString)

        End Try

    End Sub

    Public Sub BackupProject(Project As Project, FilePath As String)
        'Restore Database and Project from .bak file

        Dim iID As Integer = 0

        Try
            'Create RestoreProjDir table in Project Database with current Project info 
            ' and create backup file (with overwrite)
            With _Connection.CreateCommand()
                .CommandTimeout = My.Settings.TimeOutSeconds    'set longer timout value to allow for large databases

                ' Add directory info to database Project Info table
                .CommandText = $"
                        DELETE FROM {Project.DatabaseName}.dbo.ProjectInfo
                        WHERE [Key] IN ('Name', 'Owner', 'District', 'Description');
                        INSERT INTO {Project.DatabaseName}.dbo.ProjectInfo([Key], [Value])
                        VALUES ('Name', @Name), ('Owner', @Owner), ('District', @District), ('Description', @Description);"
                .Parameters.Add("@Name", SqlDbType.VarChar, 255).Value = Project.Name
                .Parameters.Add("@Owner", SqlDbType.VarChar, 255).Value = Project.Owner
                .Parameters.Add("@Description", SqlDbType.VarChar, 255).Value = Project.Description
                .Parameters.Add("@District", SqlDbType.VarChar, 255).Value = Project.District
                .ExecuteNonQuery()

                'Reset the Command object and execute backup
                .Parameters.Clear()
                .CommandText = $"
                        BACKUP DATABASE {Project.DatabaseName} 
                    	    TO  DISK = @FILEPATH
                    	    WITH
                            NOFORMAT,
                            INIT,
                            NAME = @BUNAME,
                            SKIP,
                            NOREWIND;"
                .Parameters.Add("@FILEPATH", SqlDbType.VarChar, 255).Value = FilePath
                .Parameters.Add("@BUNAME", SqlDbType.VarChar, 100).Value =
                    $"{Project.DatabaseName}-Full Database Backup"
                .ExecuteNonQuery()
            End With

        Catch ex As Exception
            ' Handles all exceptions, used in Catch
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Backup Error")
            Logger.WriteToLog(ex.ToString)

        End Try

    End Sub

    Public Sub RestoreProject(sBakFilePath As String)
        'Restore Database and Project from .bak file

        Dim sDataFolder As String = My.Settings.DataFolder
        Dim oNewProject As Project

        ' Insert row in project directory table to get new PrjectDB name
        oNewProject = AddProject()

        'Restore Project Database from backup file, get Project info from RestoreProjDir table,
        ' and update new project.
        Try
            With Connection.CreateCommand()
                .CommandTimeout = My.Settings.TimeOutSeconds    'set longer timout value to allow for large databases
                .CommandText = $"RESTORE DATABASE [{oNewProject.DatabaseName}] 
                FROM  DISK = @FILEPATH 
                WITH 
                MOVE N'Data_File' TO @DATAFILE,  
                MOVE N'Log_File' TO @LOGFILE,  
                MOVE N'FS_Files' TO @FSFOLDER;"
                .Parameters.Add("@FILEPATH", SqlDbType.VarChar, 255).Value = sBakFilePath
                .Parameters.Add("@DATAFILE", SqlDbType.VarChar, 255).Value =
                    Path.Combine(sDataFolder, $"{oNewProject.DatabaseName}.mdf")
                .Parameters.Add("@LOGFILE", SqlDbType.VarChar, 255).Value =
                    Path.Combine(sDataFolder, $"{oNewProject.DatabaseName}_log.ldf")
                .Parameters.Add("@FSFOLDER", SqlDbType.VarChar, 255).Value =
                    $"C:\FileStream\{oNewProject.DatabaseName}"
                .ExecuteNonQuery()

            End With

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Restore Error - Create Database")
            Logger.WriteToLog(ex.ToString)

        End Try

        Dim ProjDB = New ProjectDB(oNewProject.DatabaseName)
        If Not ProjDB.IsConnected Then Exit Sub

        Try
            ' Read Project Info from restored database

            Dim Values = New DataTable
            Dim sSQL = $"
                IF OBJECT_ID(N'[dbo].[ProjectInfo]') IS NOT NULL
	                SELECT [Key], [Value]
	                FROM [dbo].[ProjectInfo]
                    WHERE [Key] IN ('ProjectGuid', 'CreatedOn', 'LicenseKey', 'ApplicationVersion', 
                        'Name', 'Owner', 'District', 'Description');
                ELSE
                    -- Allow for backward compatibility
	                IF OBJECT_ID(N'[dbo].[RestoreProjDir]') IS NOT NULL
		                SELECT 'Name' AS [Key], [Name] AS [Value]
		                FROM (SELECT TOP 1 * FROM [dbo].[RestoreProjDir]) sub1
		                UNION SELECT 'Owner' AS [Key], [Owner] AS [Value]
		                FROM (SELECT TOP 1 * FROM [dbo].[RestoreProjDir]) sub2
		                UNION SELECT 'District' AS [Key], [District] AS [Value]
		                FROM (SELECT TOP 1 * FROM [dbo].[RestoreProjDir]) sub3
		                UNION SELECT 'Description' AS [Key], [Description] AS [Value]
		                FROM (SELECT TOP 1 * FROM [dbo].[RestoreProjDir]) sub4
                        UNION SELECT 'ApplicationVersion' AS [Key], '2.3' AS [Value]
                        UNION SELECT 'CreatedOn' AS [Key], CONVERT(VARCHAR, GETDATE(), 101) AS [Value];"
            With New SqlDataAdapter(sSQL, ProjDB.Connection)
                .SelectCommand.CommandTimeout = 60
                .Fill(Values)
            End With

            ' Update new project with values from ProjectInfo
            If Values.Rows.Count > 0 Then

                ' Create dict object from ProjectInfo
                Dim ValuesDict = New Dictionary(Of String, String)
                For Each row As DataRow In Values.Rows
                    ValuesDict(row("Key")) = row("Value")
                Next

                ' Add ProjectInfo members to new project, update Project object
                UpdateProject(
                    Project:=oNewProject,
                    Name:=ValuesDict("Name"),
                    Owner:=ValuesDict("Owner"),
                    District:=ValuesDict("District"),
                    Description:=ValuesDict("Description"),
                    ProjectGuid:=ValuesDict("ProjectGuid"),
                    CreatedOn:=ValuesDict("CreatedOn"),
                    LicenseKey:=ValuesDict("LicenseKey"),
                    ApplicationVersion:=ValuesDict("ApplicationVersion")
                    )

                ' Check if license key already used for existing project
                Dim oProjectTest As Project = Nothing
                For Each id As Integer In CurrDirectory.Projects.Keys
                    oProjectTest = CurrDirectory.Projects(id)
                    If oProjectTest.ID <> oNewProject.ID AndAlso oProjectTest.LicenseKey = oNewProject.LicenseKey Then
                        Exit For
                    End If
                    oProjectTest = Nothing
                Next

                ' If license key found for existing project, remove the restored project
                If Not IsNothing(oProjectTest) Then
                    Dim sMsg As String = $"Unable to restore! Project {oProjectTest.ID} ({oProjectTest.Name}) is " &
                        "using the same license key."
                    Logger.WriteToLog(sMsg)
                    RemoveProject(oNewProject)
                    MsgBox(sMsg, vbOKOnly + vbCritical, "Restore Failed")

                Else
                    ' Add entry to History table
                    UpdateHistory(oNewProject.ProjectGuid, oNewProject.Name, oNewProject.District, "Restore")

                End If

            End If

            'No logging needed, Restore is a combination of AddProject and UpdateProject.

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Restore Error - Project Update")
            Logger.WriteToLog(ex.ToString)
            Logger.WriteToLog("Removing new project due to error.")
            RemoveProject(oNewProject)

        End Try

    End Sub

    Public Function ValidateLicenseKey(ByVal licenseKey As String) As Boolean
        ' Check that key exists in table and has not been used

        Dim count As Integer = 0

        With Connection.CreateCommand()
            .CommandText = $"
                SELECT COUNT(0) [Count]
                FROM dbo.sys_LicenseKeys
                WHERE ([Project_GUID] is Null) and ([Key]=@Key);"
            .Parameters.Add("@Key", SqlDbType.VarChar).Value = licenseKey
            count = .ExecuteScalar()
        End With

        Return (count = 1)

    End Function

    Public Sub UpdateLicense(ByVal LicenseKey As String, ProjectGuid As String)

        If Not DevMode Then
            With Connection.CreateCommand()
                .CommandText = "
                UPDATE dbo.sys_LicenseKeys
                SET [Project_GUID] = @Guid
                WHERE [Key] = @Key;"
                .Parameters.Add("@Key", SqlDbType.VarChar).Value = LicenseKey
                .Parameters.Add("@Guid", SqlDbType.VarChar).Value = ProjectGuid
                .ExecuteNonQuery()
            End With
        End If

    End Sub

    Private Sub UpdateHistory(ByVal ProjectGuid As String, ByVal ProjectName As String,
                              ByVal ProjectDistrict As String, ByVal Action As String)

        With Connection.CreateCommand()
            .CommandText = "
                INSERT INTO dbo.ProjectHistory (GUID, ProjectName, ProjectDistrict, Action)
                VALUES (@GUID, @Name, @District, @Action);"
            .Parameters.Add("@GUID", SqlDbType.VarChar).Value = ProjectGuid
            .Parameters.Add("@Name", SqlDbType.VarChar).Value = ProjectName
            .Parameters.Add("@District", SqlDbType.VarChar).Value = ProjectDistrict
            .Parameters.Add("@Action", SqlDbType.VarChar).Value = Action
            .ExecuteNonQuery()

        End With

    End Sub

    Public Function ActivityLog(ByVal desktopPath As String) As String

        Dim destFile = Path.Combine(desktopPath, "Themis_Activity_Log.xlsx")
        Dim oFile As New FileInfo(destFile)

        ' Check for existing file before starting Excel
        If oFile.Exists Then
            Dim rslt = MsgBox($"File already exists, replace?{vbCrLf & vbCrLf}{destFile}", vbOKCancel + vbQuestion, "Overwrite Warning")
            If rslt <> vbOK Then Throw New OperationCanceledException
        End If

        Dim dtActivity As New DataTable
        Dim sSQL As String
        Dim xlApp As New Excel.Application
        Dim wbs As Excel.Workbooks = xlApp.Workbooks
        Dim wb As Excel.Workbook = wbs.Add()
        Dim wss As Excel.Sheets = wb.Worksheets
        Dim ws As Excel.Worksheet = wss("Sheet1")
        Dim c1 As Excel.Range = ws.Cells(1, 1)
        Dim c2 As Excel.Range = ws.Cells(1, 1)

        Try
            ' Fill DataTable
            sSQL = "
            select k.[Key] [LicenseKey], h.[GUID] [ProjectGuid], h.ProjectName, h.ProjectDistrict, h.[Action], h.[TimeStamp]
            from dbo.ProjectHistory h
            join dbo.sys_LicenseKeys k on h.[GUID]=k.Project_GUID
            order by k.[Key], h.[GUID], h.[TimeStamp];"
            With New SqlDataAdapter(sSQL, Connection)
                .Fill(dtActivity)
            End With

            ' Create Excel file
            ' Note: arrays are 0-indexed
            Dim cols(dtActivity.Columns.Count - 1) As String
            For c As Integer = 0 To dtActivity.Columns.Count - 1
                cols(c) = dtActivity.Columns(c).ColumnName
            Next

            Dim arr(dtActivity.Rows.Count - 1, cols.Length - 1) As String
            For r As Integer = 0 To dtActivity.Rows.Count - 1
                For c As Integer = 0 To cols.Length - 1
                    arr(r, c) = dtActivity.Rows(r)(cols(c))
                Next
            Next

            ' Add column names
            c2 = ws.Cells(1, cols.Length)
            ws.Range(c1, c2).Value = cols

            ' Add data rows
            c1 = ws.Cells(2, 1)
            c2 = ws.Cells(dtActivity.Rows.Count + 1, cols.Length)
            ws.Range(c1, c2).Value = arr

            ' Save file without overwrite notification
            xlApp.DisplayAlerts = False
            wb.SaveAs(Filename:=destFile, Password:="Badfish698")

            Return destFile

        Catch ex As Exception
            Throw New Exception("", ex)

        Finally
            wb.Close(SaveChanges:=False)
            xlApp.Quit()
            Marshal.ReleaseComObject(c1)
            Marshal.ReleaseComObject(c2)
            Marshal.ReleaseComObject(ws)
            Marshal.ReleaseComObject(wss)
            Marshal.ReleaseComObject(wb)
            Marshal.ReleaseComObject(wbs)
            Marshal.ReleaseComObject(xlApp)

        End Try

    End Function

    Private Sub connect()
        'Called by constructor, connect to project directory database

        _Connection.ConnectionString =
            $"Data Source={CurrServer.Name};Initial Catalog={Name};Trusted_Connection=Yes;
            Pooling=False;Connection Timeout=10"
        Connection.Open()
        _IsConnected = True

        Logger.WriteToLog($"Connected to project directory '{Name}'.")

    End Sub

    Private Sub refreshProjects()
        'Clear and refill _Projects

        Dim dtProjects As New DataTable
        Dim sSQL As String

        'Reset collection
        _Projects.Clear()

        'Create datatable from [ProjectDirectory] table in project directory database
        sSQL = $"
            SELECT [ID], CAST([GUID] AS VARCHAR(36)) [GUID], CAST([CreatedOn] AS varchar) AS [CreatedOn], [LicenseKey], 
                [ApplicationVersion], [Name], [Owner], [District], [Description], [ProjectDatabase]
            FROM [dbo].[ProjectDirectory]
            ORDER BY [ID];"
        With New SqlDataAdapter
            .SelectCommand = New SqlCommand(sSQL, _Connection)
            .Fill(dtProjects)
        End With

        'Add each project to the project collection
        For Each row As DataRow In dtProjects.Rows
            _Projects.Add(row("ID"),
                New Project(
                    ID:=row("ID"),
                    ProjectGuid:=row("GUID"),
                    CreatedOn:=row("CreatedOn"),
                    LicenseKey:=row("LicenseKey"),
                    ApplicationVersion:=row("ApplicationVersion"),
                    Name:=row("Name"),
                    Owner:=row("Owner"),
                    District:=row("District"),
                    Description:=row("Description"),
                    DatabaseName:=row("ProjectDatabase")
                    ))
        Next

        dtProjects.Dispose()

    End Sub

    Private Function compatible() As Boolean

        Dim version = ""
        Dim verTokens() As String

        Try
            With _Connection.CreateCommand
                .CommandText = "             
                IF OBJECT_ID(N'[dbo].[sys_DirectoryInfo]') IS NOT NULL
                    SELECT [Value] AS [Version]
                    FROM dbo.sys_DirectoryInfo
                    WHERE [Key]='ApplicationVersion';
                ELSE
                    -- Allow for backward compatibility
                    SELECT '2.3' AS [Version];"
                version = .ExecuteScalar
            End With

            verTokens = version.Split(".")
            _AppVersion = CDec($"{verTokens(0)}.{verTokens(1)}")

            If _AppVersion >= _MinAppVersion Then
                Return True
            Else
                Return False
            End If

        Catch
            Return False

        End Try

    End Function

End Class

Public Class Project

    Public ReadOnly Property ID As Integer = 0
    Public ReadOnly Property ProjectGuid As String
    Public ReadOnly Property CreatedOn As Date = #1/1/1900#
    Public ReadOnly Property LicenseKey As String
    Public ReadOnly Property ApplicationVersion As String
    Public ReadOnly Property Name As String
    Public ReadOnly Property Owner As String
    Public ReadOnly Property District As String
    Public ReadOnly Property Description As String
    Public ReadOnly Property DatabaseName As String


    Protected Friend Sub New(ID As Integer, ProjectGuid As String, CreatedOn As Date, LicenseKey As String,
                             ApplicationVersion As String, Name As String, Owner As String,
                             District As String, Description As String, DatabaseName As String
                             )
        'Create new object and set property values

        _ID = ID
        _ProjectGuid = ProjectGuid
        _CreatedOn = CreatedOn
        _LicenseKey = LicenseKey
        _ApplicationVersion = ApplicationVersion
        _Name = Name
        _Owner = Owner
        _District = District
        _Description = Description
        _DatabaseName = DatabaseName

    End Sub

End Class
