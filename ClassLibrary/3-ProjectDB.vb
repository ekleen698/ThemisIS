Imports ClassLibrary.GlobalObjects
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.InteropServices.Marshal
Imports Redemption


Public Class ProjectDB

    Public ReadOnly Property Name As String = ""
    Public ReadOnly Property Connection As New SqlConnection
    Public ReadOnly Property IsConnected As Boolean = False
    Public ReadOnly Property MinAppVer As String = "3.0"
    Public ReadOnly Property AppVersion As String = "0.0"
    Public ReadOnly Property IsCompatible As Boolean = False

    Public Sub New()
        'Used to create new object to execute Create method

    End Sub

    Public Sub New(DatabaseName As String)
        'Create new object from project database name
        'Handles exceptions

        Try
            _Name = DatabaseName
            Connect()

            ' Check minimum version compatibility
            _IsCompatible = compatible()

        Catch ex As Exception
            _Name = Nothing
            _Connection = Nothing
            _IsConnected = False
            Logger.WriteToLog($"{ex.GetType} occurred while connecting to '{DatabaseName}'.")
            Logger.WriteToLog(ex.Message)

        End Try

    End Sub

    Public Sub Close()
        'Close connection to project database
        'Handles exceptions

        Dim sName As String
        sName = _Name

        Try
            'Clear object properties
            _Name = Nothing
            _Connection.Close()
            _IsConnected = False

            Logger.WriteToLog($"Disconnected project database [{sName}].")

        Catch ex As Exception
            Logger.WriteToLog($"{ex.GetType} occurred while disconnecting '{sName}'.")
            Logger.WriteToLog(ex.Message)

        End Try

    End Sub

    Public Sub Create(ByRef Project As Project)
        'Create new project database on current server.
        'Throws exception

        Try
            'Create DB
            'Update logical file names to allow for Restore operation
            'Add Filestream file
            With CurrServer.Connection.CreateCommand
                .CommandText = $"
                    CREATE DATABASE [{Project.DatabaseName}];
                    ALTER DATABASE [{Project.DatabaseName}] MODIFY File(name=N'{Project.DatabaseName}', 
                        NEWNAME=N'Data_File');
                    ALTER DATABASE [{Project.DatabaseName}] MODIFY File(name=N'{Project.DatabaseName}_log', 
                        NEWNAME=N'Log_File');
                    ALTER DATABASE [{Project.DatabaseName}] ADD FILEGROUP [FILESTREAM] CONTAINS FILESTREAM;
                    ALTER DATABASE [{Project.DatabaseName}] ADD FILE ( 
                        NAME = N'FS_Files', 
	                    FILENAME = N'C:\FileStream\{Project.DatabaseName}' ) 
	                    TO FILEGROUP [FILESTREAM];"
                .ExecuteNonQuery()
            End With

            'Update Name property
            _Name = Project.DatabaseName

            Logger.WriteToLog($"Project database '{Project.DatabaseName}' created.")

            'Connect new database
            Connect()

        Catch ex As Exception
            _Name = Nothing
            _Connection = Nothing
            _IsConnected = False
            Logger.WriteToLog($"{ex.GetType} occurred while creating project database '{Project.DatabaseName}'.")
            Logger.WriteToLog(ex.Message)
            Throw ex     'for frmProjectUpdate error handling

        End Try

        Try
            'Execute Resource sql files to create database objects
            CreateSystemObjects()

            ' Add Project Info
            With _Connection.CreateCommand
                .CommandText = $"
                    INSERT INTO dbo.[ProjectInfo] ([Key], [Value]) 
                    VALUES ('CreatedBy', dbo.fUsername()) 
                    , ('ProjectGuid', @Guid)
                    , ('CreatedOn', @Created) 
                    , ('LicenseKey', @License)
                    , ('ApplicationVersion', @AppVersion)
                    , ('RequestDate', @RequestDate)
                    , ('District', @District); "
                .Parameters.Add("@Guid", SqlDbType.VarChar).Value = Project.ProjectGuid
                .Parameters.Add("@Created", SqlDbType.VarChar).Value = Project.CreatedOn.ToString("d")
                .Parameters.Add("@License", SqlDbType.VarChar).Value = Project.LicenseKey
                .Parameters.Add("@AppVersion", SqlDbType.VarChar).Value = Project.ApplicationVersion
                .Parameters.Add("@RequestDate", SqlDbType.VarChar).Value = Project.RequestDate.ToString("d")
                .Parameters.Add("@District", SqlDbType.VarChar).Value = Project.District

                .ExecuteNonQuery()

            End With

            ' Set compatibility
            _IsCompatible = True

        Catch ex As Exception
            _Name = Nothing
            _Connection = Nothing
            _IsConnected = False
            Logger.WriteToLog($"{ex.GetType} occurred while setting up project database objects.")
            Logger.WriteToLog(ex.Message)
            Throw ex     'for frmProjectUpdate error handling

        End Try

    End Sub

    Private Sub Connect()
        'Open connection to Project Database
        'Throws exception

        _Connection.ConnectionString =
                $"Data Source={CurrServer.Name};Initial Catalog={_Name};
                Trusted_Connection=Yes;Pooling=False;"
        _Connection.Open()
        _IsConnected = True

        Logger.WriteToLog($"Connected to project database '{_Name}'.")

    End Sub

    Private Sub CreateSystemObjects()
        'Read and execute sql files to create required project database objects
        'Throws exception

        'Execute SQL code from Resource files
        With _Connection.CreateCommand()
            .CommandText = My.Resources.fUsername
            .ExecuteNonQuery()

            .CommandText = My.Resources.CreateTables
            .ExecuteNonQuery()

            .CommandText = My.Resources.fAttachExemption
            .ExecuteNonQuery()

            .CommandText = My.Resources.fCreateIndexes
            .ExecuteNonQuery()

            .CommandText = My.Resources.fDisplayTerms
            .ExecuteNonQuery()

            .CommandText = My.Resources.fDropIndexes
            .ExecuteNonQuery()

            .CommandText = My.Resources.fEmailExemption
            .ExecuteNonQuery()

            .CommandText = My.Resources.fRedactedImport
            .ExecuteNonQuery()

            .CommandText = My.Resources.fUpdateDuplicate
            .ExecuteNonQuery()

            .CommandText = My.Resources.fUpdate_DisplayEmailIDs
            .ExecuteNonQuery()

            .CommandText = My.Resources.fUpdateReset
            .ExecuteNonQuery()

        End With

        Logger.WriteToLog($"All required database objects created.")

    End Sub

    Private Function compatible() As Boolean

        Dim result = False
        Dim version = ""

        Try
            With _Connection.CreateCommand
                .CommandText = "
                    IF OBJECT_ID(N'[dbo].[ProjectInfo]') IS NOT NULL
                        SELECT [Value] AS [Version]
                        FROM dbo.ProjectInfo
                        WHERE [Key]='ApplicationVersion';
                    ELSE
                        -- Allow for backward compatibility
                        SELECT '2.3' AS [Version];"
                version = .ExecuteScalar
            End With

            _AppVersion = version.Substring(0, 3)
            Dim major = version.Split(".")(0)
            Dim minor = version.Split(".")(1)
            Dim min_major = _MinAppVer.Split(".")(0)
            Dim min_minor = _MinAppVer.Split(".")(1)

            If CInt(major) >= CInt(min_major) Then
                If CInt(minor) >= CInt(min_minor) Then
                    result = True
                End If
            End If

        Catch

        End Try

        Return result

    End Function

    Public Sub AddPSTFiles()
        'Called by frmProjDetails, uses Windows FolderBrowserDialog
        ' to choose the folder at run time

        Dim oFolder As Folder
        Dim oFolderDialog As New FolderBrowserDialog With {
            .Description = "Select Folder With .pst Files",
            .ShowNewFolderButton = False}

        'Open dialog to get folder for .pst file location
        If oFolderDialog.ShowDialog() = DialogResult.OK Then

            oFolder = Folder.GetFolder(oFolderDialog.SelectedPath)

            If oFolder.Exists Then
                'Add .pst files in selected folder (subfolders optional).
                loopFolders(oFolder, True)
            Else
                MsgBox($"Folder doesn't exist.", vbOKOnly, "Invalid Operation")
            End If

        End If

        oFolderDialog.Dispose()
        oFolder = Nothing

    End Sub

    Private Sub loopFolders(ByRef oFolder As Folder, bIncludeSubs As Boolean)
        ' Get .pst files from folder.
        ' Allow recursive call for subfolders if bIncludeSub=True.
        ' Throws exception

        Dim oProfiles As New OLProfiles
        Dim rSession As New RDOSession
        Dim rStores As RDOStores
        Dim rStore As RDOPstStore
        Dim rFolders As RDOFolders
        Dim rFolder As RDOFolder
        Dim oPSTFile As PSTFile = Nothing
        Dim sCurrentFile As String = ""
        Dim iCount As Integer = 0

        Try
            Logger.WriteToLog($"Adding .pst files from {oFolder.FolderPath}.")

            'Logon session using temp profile
            rSession.Logon(oProfiles.Add("Add_Prof"))
            rStores = rSession.Stores

            'Iterate all files in current folder and insert new record for every .pst file.
            For Each file As FileInfo In oFolder.Files
                sCurrentFile = file.Name

                If New PSTFile(file.FullName).ID <> 0 Then
                    'File already exists in Files table
                    Logger.WriteToLog($"Skipping file '{sCurrentFile}' because it already " &
                            "exists in this project.")

                ElseIf file.Extension = ".pst" Then
                    'Ignore files other than .pst files

                    'Connect to .pst file
                    rStore = rStores.AddPSTStore(file.FullName)

                    'Insert file info into database and get PSTFile object
                    oPSTFile = InsertFile(oFolder.FolderPath, file.Name)

                    'Catalog names and item counts for each folder
                    If Not IsNothing(oPSTFile) Then
                        iCount += 1
                        rFolder = rStore.IPMRootFolder
                        rFolders = rFolder.Folders

                        ' Begin recursive calls for all subfolders
                        loopPSTFolders(rFolders, oPSTFile.ID)

                        ' Release memory for com objects
                        ReleaseComObject(rFolder)
                        ReleaseComObject(rFolders)

                        Logger.WriteToLog($"File '{sCurrentFile}' added to project. ({iCount} Items)")
                    End If

                    'Disconnect .pst file and release memory for com object
                    rStore.Remove()
                    ReleaseComObject(rStore)

                End If
            Next

            ' Release memory for com object
            ReleaseComObject(rStores)

        Catch ex As Exception
            Logger.WriteToLog($"An error occurred while adding file '{sCurrentFile}'.")
            Throw ex

        Finally
            'Logoff session and cleanup objects
            If rSession.LoggedOn Then rSession.Logoff()
            ReleaseComObject(rSession)
            oProfiles.Remove("Add_Prof") 'oProfiles is not a COM object

        End Try

        'Recursive call to catalog files in each subfolder of current folder.
        If bIncludeSubs And oFolder.Folders.Count > 0 Then
            For Each oSubfolder In oFolder.Folders
                loopFolders(oSubfolder, bIncludeSubs)
            Next
        End If

    End Sub

    Private Function InsertFile(sFileFolder As String, sFileName As String) As PSTFile
        'Execute SQL command to insert a new row in Files table
        'Throws exception

        Dim iID As Integer

        Try
            'Execute SQL command to insert new file into Files table and return [ID] value of inserted row
            With _Connection.CreateCommand
                .CommandText = $"INSERT INTO [dbo].[Files] ([FolderPath], [FileName]) 
                VALUES (@FolderPath, @FileName);
                SELECT CAST([last_used_value] AS INT) AS [FileID]
                FROM [sys].[sequences] WHERE [name] ='sFiles_PK';"
                .Parameters.Add("@FolderPath", SqlDbType.VarChar).Value = sFileFolder
                .Parameters.Add("@FileName", SqlDbType.VarChar).Value = sFileName

                'Execute INSERT operation for current file, return [ID] value of new row
                iID = .ExecuteScalar()
            End With

            Return New PSTFile(iID)

        Catch ex As SqlException
            'Error 2627 is Unique Key Violation, FileName already exists
            If ex.Number = 2627 Then
                MsgBox($"{sFileName}{vbCrLf}File already exists in the database.",
                       vbOKOnly + vbCritical, "Unique Filename Violation")
                Logger.WriteToLog($"Skipping {sFileName} because of unique filename violation.")
                Logger.WriteToLog($"{sFileFolder} > {sFileName}")
            Else
                Throw ex
            End If
            Return Nothing

        End Try

    End Function

    Private Sub loopPSTFolders(ByRef rFolders As RDOFolders, iFileID As Integer)
        'Insert record into PST Folders table for each folder in .pst file
        '  cataloging the name, parent folder, and number of items

        Dim rFolder As RDOFolder
        Dim rSubFolders As RDOFolders
        Dim rParent As RDOFolder
        Dim rItems As RDOItems

        With _Connection.CreateCommand
            .CommandText = "INSERT INTO [dbo].[PSTFolders] ([FileID], [ParentFolder], " &
                "[FolderName], [ItemCount], [SubfolderCount]) " &
                "VALUES (@FileID, @ParentFolder, @FolderName, @ItemCount, @SubfolderCount);"
            .Parameters.Add("@FileID", SqlDbType.Int)
            .Parameters.Add("@ParentFolder", SqlDbType.VarChar, 255)
            .Parameters.Add("@FolderName", SqlDbType.VarChar, 255)
            .Parameters.Add("@ItemCount", SqlDbType.Int)
            .Parameters.Add("@SubfolderCount", SqlDbType.Int)

            For i = 1 To rFolders.Count
                'Execute INSERT operation
                rFolder = rFolders(i)
                rParent = rFolder.Parent
                rItems = rFolder.Items
                rSubFolders = rFolder.Folders

                .Parameters("@FileID").Value = iFileID
                .Parameters("@ParentFolder").Value = rParent.Name
                .Parameters("@FolderName").Value = rFolder.Name
                .Parameters("@ItemCount").Value = rItems.Count
                .Parameters("@SubfolderCount").Value = rSubFolders.Count
                .ExecuteNonQuery()

                ' Release memory for com objects
                ReleaseComObject(rFolder)
                ReleaseComObject(rParent)
                ReleaseComObject(rItems)

                ' Recursive call for all subfolders
                If rSubFolders.Count > 0 Then loopPSTFolders(rSubFolders, iFileID)

                ' Release memory for com objects
                ReleaseComObject(rSubFolders)

            Next

        End With

        rFolder = Nothing
        rSubFolders = Nothing
        rParent = Nothing
        rItems = Nothing

    End Sub

End Class



