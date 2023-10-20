Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Imports ClassLibrary.GlobalObjects

Public Class Directory

    Public ReadOnly Property Name As String = "mlgSys_ProjDir"    'database name
    Public ReadOnly Property Connection As New SqlConnection
    Public ReadOnly Property IsConnected As Boolean = False
    Public ReadOnly Property Projects As New Dictionary(Of Integer, Project)
    Private ReadOnly Property MinAppVersion As Decimal = 3.2
    ' version = {major rev}.{minor rev}.{update}.{build}
    Public ReadOnly Property AppVersion As Decimal = 0.0
    Public ReadOnly Property IsCompatible As Boolean = False

    Public Sub New()
        'Ensure project directory database exists and connect to it
        'Throws exception

        Try
            With CurrServer.Connection.CreateCommand
                .CommandText = $"SELECT COUNT(*) AS [count] FROM sys.databases WHERE name='{_Name}';"
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

                    'Create project directory table
                    .Connection = _Connection
                    .CommandText = My.Resources.CreateDirectory
                    .ExecuteNonQuery()

                    'Create INSERT trigger on table to generate Project Database name
                    .CommandText = My.Resources.CreateDirectoryTrigger
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

    Public Function AddProject(Name As String, Owner As String, District As String, Description As String,
                               ApplicationVersion As String, Optional WithDB As Boolean = False) As Project
        'Add project to directory and create project database
        'Throws Exception

        Dim iID As Integer = 0
        Dim oProject As Project

        'Insert new row into directory table
        With _Connection.CreateCommand
            .CommandText = $"INSERT [ProjectDirectory] ([Name], [Owner], [District], [Description], [ApplicationVersion]) 
                VALUES (@Name, @Owner, @District, @Description, @AppVers); 
                SELECT CAST([last_used_value] AS INT) AS [ID]
                FROM [sys].[sequences] WHERE [name] ='sProjectDirectory_PK';"
            .Parameters.Add("@Name", SqlDbType.VarChar, 15).Value = Name
            .Parameters.Add("@Owner", SqlDbType.VarChar, 25).Value = Owner
            .Parameters.Add("@District", SqlDbType.VarChar, 25).Value = District
            .Parameters.Add("@Description", SqlDbType.VarChar, 255).Value = Description
            .Parameters.Add("@AppVers", SqlDbType.VarChar, 255).Value = ApplicationVersion

            'Execute INSERT and return new row ID for next step
            iID = .ExecuteScalar()

            ' TODO: add check for existing project database with this ID

        End With

        'Update collection of projects -> kills all Project objects and recreates new objects
        'from Project Directory database table
        refreshProjects()
        oProject = _Projects(iID)

        If WithDB Then
            Try
                'Create Project Database for new project using derived database name
                With New ProjectDB()
                    .Create(oProject.DatabaseName)
                    .Close()
                End With

            Catch ex As Exception
                Logger.WriteToLog($"Removing new project due to error.")
                RemoveProject(oProject)
                Throw ex

            End Try
        End If

        Logger.WriteToLog($"Project {iID} added to the Project Directory.")

        'Return Project object for new project
        Return oProject

    End Function

    Public Function UpdateProject(Project As Project, sName As String, sOwner As String, sDistrict As String,
                             sDescription As String, Optional sAppVersion As String = "", Optional dCreatedOn As Date = #1/1/1900#
                             ) As Project
        ' TODO: create overloads for optional parameters
        'Update project properties in directory table
        'Throws exception

        Dim iID As Integer = Project.ID
        Dim sSQL As String = "
            UPDATE [ProjectDirectory] 
            SET [Name]=@Name, [District]=@District, [Owner]=@Owner
                , [Description]=@Description"

        'Execute UPDATE SQL
        With _Connection.CreateCommand
            If sAppVersion <> "" Then
                sSQL += ", [ApplicationVersion]=@AppVers"
                .Parameters.Add("@AppVers", SqlDbType.VarChar, 255).Value = sAppVersion
            End If
            If dCreatedOn <> #1/1/1900# Then
                sSQL += ", [CreatedOn]=@CreatedOn"
                .Parameters.Add("@CreatedOn", SqlDbType.Date).Value = dCreatedOn
            End If

            sSQL += " WHERE [ID]=@ID;"
            .CommandText = sSQL
            .Parameters.Add("@Name", SqlDbType.VarChar, 15).Value = sName
            .Parameters.Add("@Owner", SqlDbType.VarChar, 25).Value = sOwner
            .Parameters.Add("@District", SqlDbType.VarChar, 25).Value = sDistrict
            .Parameters.Add("@Description", SqlDbType.VarChar, 255).Value = sDescription
            .Parameters.Add("@ID", SqlDbType.Int).Value = iID
            .ExecuteNonQuery()
        End With

        'Update collection of projects -> kills all Project objects and recreates new objects
        'from Project Directory database table
        refreshProjects()

        Logger.WriteToLog($"Project {iID} updated.")

        'Return Project object for updated project
        Return _Projects(iID)

    End Function

    Public Sub RemoveProject(Project As Project)
        'Delete project row in project directory table and drop project database

        Dim iID As Integer = Project.ID

        Try
            'Drop project database
            CurrServer.DropDB(Project.DatabaseName)

            ' Reset Primary Key after removing row
            With _Connection.CreateCommand
                .CommandText = "EXEC dbo.fResetSeq;"
                .ExecuteNonQuery()
            End With

            'Update collection of projects
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

        Dim iID As Integer = 0
        Dim sDataFolder As String = My.Settings.DataFolder
        Dim oProject As Project

        'Insert row in project directory table and update Projects
        oProject = AddProject("", "", "", "", "")

        'Restore Project Database from backup file, get Project info from RestoreProjDir table,
        ' and update new project.
        Try
            With _Connection.CreateCommand()
                .CommandTimeout = My.Settings.TimeOutSeconds    'set longer timout value to allow for large databases
                .CommandText = $"RESTORE DATABASE [{oProject.DatabaseName}] 
                FROM  DISK = @FILEPATH 
                WITH 
                MOVE N'Data_File' TO @DATAFILE,  
                MOVE N'Log_File' TO @LOGFILE,  
                MOVE N'FS_Files' TO @FSFOLDER;"
                .Parameters.Add("@FILEPATH", SqlDbType.VarChar, 255).Value = sBakFilePath
                .Parameters.Add("@DATAFILE", SqlDbType.VarChar, 255).Value =
                    Path.Combine(sDataFolder, $"{oProject.DatabaseName}.mdf")
                .Parameters.Add("@LOGFILE", SqlDbType.VarChar, 255).Value =
                    Path.Combine(sDataFolder, $"{oProject.DatabaseName}_log.ldf")
                .Parameters.Add("@FSFOLDER", SqlDbType.VarChar, 255).Value =
                    $"C:\FileStream\{oProject.DatabaseName}"
                .ExecuteNonQuery()

            End With

            'Attempt to read Project Info from restored database, update Project, and refresh Projects collection
            Dim ProjDB = New ProjectDB(oProject.DatabaseName)
            Try
                Dim sSQL = $"
                        IF OBJECT_ID(N'[dbo].[ProjectInfo]') IS NOT NULL
	                        SELECT [Key], [Value]
	                        FROM [dbo].[ProjectInfo]
                            WHERE [Key] IN ('Name', 'Owner', 'District', 'Description', 'ApplicationVersion', 'CreatedOn');
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

                Dim Values = New DataTable
                With New SqlDataAdapter(sSQL, ProjDB.Connection)
                    .SelectCommand.CommandTimeout = 60
                    .Fill(Values)
                End With

                If Values.Rows.Count > 0 Then
                    Dim ValuesDict = New Dictionary(Of String, String)

                    For Each row As DataRow In Values.Rows
                        ValuesDict(row("Key")) = row("Value")
                    Next

                    UpdateProject(
                        Project:=oProject,
                        sName:=ValuesDict("Name"),
                        sOwner:=ValuesDict("Owner"),
                        sDistrict:=ValuesDict("District"),
                        sDescription:=ValuesDict("Description"),
                        sAppVersion:=ValuesDict("ApplicationVersion"),
                        dCreatedOn:=CDate(ValuesDict("CreatedOn"))
                        )
                End If

            Catch ex As Exception
                Debug.WriteLine(ex)

            Finally
                ProjDB.Close()
                ProjDB = Nothing

            End Try

            'No logging needed, Restore is a combination of AddProject and UpdateProject.

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Restore Error")
            Logger.WriteToLog(ex.ToString)
            Logger.WriteToLog($"Removing new project due to error.")
            RemoveProject(oProject)

        Finally
            'Cleanup objects
            oProject = Nothing

        End Try

    End Sub

    Private Sub connect()
        'Called by constructor, connect to project directory database

        _Connection.ConnectionString =
            $"Data Source={CurrServer.Name};Initial Catalog={_Name};Trusted_Connection=Yes;
            Pooling=False;Connection Timeout=10"
        _Connection.Open()
        _IsConnected = True

        Logger.WriteToLog($"Connected to project directory '{_Name}'.")

    End Sub

    Private Sub refreshProjects()
        'Clear and refill _Projects

        Dim dtProjects As New DataTable
        Dim sSQL As String

        'Reset collection
        _Projects.Clear()

        'Create datatable from [ProjectDirectory] table in project directory database
        sSQL = $"SELECT [ID], [Name], [Owner], [District], [Description], 
                    [ApplicationVersion], 
                    CAST(CAST([CreatedOn] AS DATE) AS varchar) AS [CreatedOn], 
                    [ProjectDatabase]
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
                    iID:=row("ID"),
                    sDatabaseName:=row("ProjectDatabase"),
                    dCreatedOn:=row("CreatedOn"),
                    sName:=row("Name"),
                    sOwner:=row("Owner"),
                    sDistrict:=row("District"),
                    sDescription:=row("Description"),
                    sAppVersion:=row("ApplicationVersion")
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
    Public ReadOnly Property DatabaseName As String
    Public ReadOnly Property CreatedOn As Date = #1/1/1900#
    Public ReadOnly Property Name As String
    Public ReadOnly Property Owner As String
    Public ReadOnly Property District As String
    Public ReadOnly Property Description As String
    Public ReadOnly Property ApplicationVersion As String

    Protected Friend Sub New(iID As Integer, sDatabaseName As String, dCreatedOn As Date, sName As String,
                   sOwner As String, sDistrict As String, sDescription As String, sAppVersion As String)
        'Create new object and set property values

        _ID = iID
        _DatabaseName = sDatabaseName
        _CreatedOn = dCreatedOn
        _Name = sName
        _Owner = sOwner
        _District = sDistrict
        _Description = sDescription
        _ApplicationVersion = sAppVersion

    End Sub

End Class
