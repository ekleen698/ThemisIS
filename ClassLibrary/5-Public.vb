Imports ClassLibrary.GlobalObjects
Imports System.Windows.Forms
Imports System.IO
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices

Public Class GlobalFunctions
    'Returns "" when string object not instantiated

    Public Shared Function Nz(ByRef Value As Object) As String
        If IsNothing(Value) Then
            Return ""
        Else
            Return Value.ToString
        End If
    End Function

    Shared Function export_attachment(iAttachID As Integer, sSavePath As String) As String
        'Save file to specified location

        Dim rdr As SqlDataReader
        Dim outputFile As FileStream
        Dim iEmailID As Integer
        Dim filename As String
        Dim buffer As Byte()

        With CurrProjDB.Connection.CreateCommand

            'Get filename and binary data from database
            .CommandText = "SELECT [EmailID], [FileName], CAST([FileStream] AS varbinary(max)) AS [Bytes]
                FROM dbo.[Attachments] WHERE [ID]=@AttachID;"
            .Parameters.Add("@AttachID", SqlDbType.Int).Value = iAttachID
            rdr = .ExecuteReader
            rdr.Read()
            iEmailID = rdr.GetSqlInt32(0).Value
            filename = rdr.GetSqlString(1).Value
            buffer = rdr.GetSqlBinary(2).Value
            rdr.Close()

            'Create new file from BLOB data, save in the specified folder
            Dim oFile = New FileInfo(Path.Combine(sSavePath, $"EmailID {iEmailID}-{filename}"))
            oFile = Unique_Filename(oFile)
            outputFile = New FileStream(oFile.FullName, FileMode.Create, FileAccess.Write)
            outputFile.Write(buffer, 0, buffer.Length)
            outputFile.Dispose()

            Return $"{oFile.Name}"

        End With

    End Function

    Shared Function export_redacted(RFIDList As List(Of Integer), Optional oFolder As DirectoryInfo = Nothing,
                                    Optional bMessage As Boolean = True) As Boolean
        ' Save file(s) to selected location

        Dim sDesktop As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim sFolder As String = Path.Combine(sDesktop, "Themis Redacted Emails (Out)")

        ' If no folder provided, get destination folder
        If IsNothing(oFolder) OrElse Not oFolder.Exists Then
            Try
                ' Ensure default folder exists
                oFolder = New DirectoryInfo(sFolder)
                If Not oFolder.Exists Then oFolder.Create()

                ' Open folder dialog to select folder
                Dim dSelect = New FolderBrowserDialog With {
                    .ShowNewFolderButton = True,
                    .SelectedPath = sFolder
                    }

                ' Validate dialog response
                Dim drResult = dSelect.ShowDialog()
                If drResult <> DialogResult.OK Then Return False

                ' Validate selected folder
                oFolder = New DirectoryInfo(dSelect.SelectedPath)
                If Not oFolder.Exists Then Return False

            Catch ex As Exception
                Return False

            End Try

        End If

        ' Save file(s) to selected folder
        Dim rdr As SqlDataReader = Nothing
        Dim outputFile As FileStream
        Dim filename As String
        Dim buffer As Byte()
        Try
            With CurrProjDB.Connection.CreateCommand
                .Parameters.Add("@RFID", SqlDbType.Int)
                For Each iRFID In RFIDList
                    'Get filename and binary data from database
                    .CommandText = "
                        SELECT [FileName], CAST([FileStream] AS VARBINARY(MAX)) AS [Bytes]
                        FROM dbo.RedactedFiles 
                        WHERE [ID]=@RFID;"
                    .Parameters("@RFID").Value = iRFID
                    rdr = .ExecuteReader
                    rdr.Read()
                    filename = rdr.GetSqlString(0).Value
                    buffer = rdr.GetSqlBinary(1).Value
                    rdr.Close()
                    rdr = Nothing

                    'Create new file from BLOB data, save in the specified folder
                    Dim oFile = New FileInfo(Path.Combine(oFolder.FullName, filename))
                    oFile = Unique_Filename(oFile)
                    outputFile = New FileStream(oFile.FullName, FileMode.Create, FileAccess.Write)
                    outputFile.Write(buffer, 0, buffer.Length)
                    outputFile.Dispose()
                Next

            End With

            If bMessage Then MsgBox("Export Successful", vbOKOnly, "Export Status")

            Return True

        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Export Redacted File Error")
            If Not IsNothing(rdr) Then
                rdr.Close()
                Debug.WriteLine("Reader closed")
            End If
            Return False

        End Try

    End Function

    Shared Function Unique_Filename(oFile As FileInfo) As FileInfo

        Dim sFileName = oFile.Name
        Dim sName As String
        Dim sExt As String
        Dim i As Integer = 1

        sExt = oFile.Extension
        sName = Left(sFileName, sFileName.Length - sExt.Length)
        While oFile.Exists
            sFileName = sName & "(" & i & ")" & sExt
            oFile = New FileInfo(Path.Combine(oFile.Directory.FullName, sFileName))
            i += 1
        End While

        Return oFile

    End Function

    <DllImport("kernel32", SetLastError:=True, CharSet:=CharSet.Unicode)>
    Public Shared Function LoadLibrary(ByVal lpFileName As String) As IntPtr

    End Function

End Class

Public Class GlobalObjects
    'Objects used by all application classes/modules

    ' Instantiate Log object 
    Public Shared Logger As New Log
    Public Shared ErrLogger As New ErrorLog

    ' Define global objects to be instantiated later
    Public Shared CurrServer As Server
    Public Shared CurrDirectory As Directory
    Public Shared CurrProject As Project
    Public Shared CurrProjDB As ProjectDB

    ' Global string used for passing values between forms
    Public Shared GlobalText As String

    ' Global boolean used for passing values between forms
    Public Shared GlobalBool As Boolean

End Class

Public Class Folder

    Public ReadOnly Property FolderPath() As String = "Nothing"
    Public ReadOnly Property Files() As FileInfo()
    Public ReadOnly Property Folders() As List(Of Folder)
    Public ReadOnly Property Exists() As Boolean = False

    Private Sub New(Path)

        _FolderPath = Path
        _Files = New DirectoryInfo(Path).GetFiles
        _Folders = GetSubfolders(Path)
        _Exists = True

    End Sub

    Public Shared Function GetFolder(Path As String) As Folder
        'Creates new Folder object from the input folder path.

        Dim oFolder As Folder

        Try
            ' Create new folder if it doesn't exist
            If Not (New DirectoryInfo(Path).Exists) Then
                System.IO.Directory.CreateDirectory(Path)
            End If

            ' Return new folder object
            oFolder = New Folder(Path)
            Return oFolder

        Catch ex As Exception
            Throw ex
            Return Nothing

        End Try

    End Function

    Private Function GetSubfolders(sPath As String) As List(Of Folder)

        Dim oSubfolder As Folder
        Dim oSubfolders As New List(Of Folder)

        For Each oDir As DirectoryInfo In New DirectoryInfo(sPath).GetDirectories

            oSubfolder = GetFolder(oDir.FullName)
            oSubfolders.Add(oSubfolder)

        Next

        Return oSubfolders

    End Function

End Class

Public Class Log
    ' The Log Class is used to create a Global Logger object used throughout 
    '  the program to log events.

    Private Path As String

    Public Sub New()
        ' Constructor to initialize new Log object

        Dim oFolder As Folder
        Dim timestamp As String = Now.ToString("yyyy-MM-dd_HH-mm-ss")

        ' Define folder path on User's Desktop
        Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Themis Logs"

        ' Creates new folder if it does not exist
        oFolder = Folder.GetFolder(Path)

        ' Define file path of log file and initialize log file
        Path = $"{Path}\LogFile_{timestamp}.txt"
        WriteToLog($"Begin logging for user <{Environment.UserName}>.")

    End Sub

    Public Sub WriteToLog(ByRef sText As Object)
        ' Method used to write text to log file

        'Debug.WriteLine(sText)
        Using writer As New StreamWriter(Path, True)
            writer.Flush()
            writer.WriteLine($"{Now.ToString("MM/dd/yyyy HH:mm:ss")} > {sText.ToString}")
            writer.Flush()
            writer.Close()
        End Using

    End Sub

End Class

Public Class ErrorLog
    ' Used by 'ImportEmails' to log email errors which do not end the process (i.e. skip or corrupt email)

    Private Path As String

    Public Sub New()
        ' Constructor to initialize new Log object

        Dim oFolder As Folder
        Dim timestamp As String = Now.ToString("yyyy-MM-dd_HH-mm-ss")

        ' Define folder path on User's Desktop
        Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Themis Logs"

        ' Creates new folder if it does not exist
        oFolder = Folder.GetFolder(Path)

        ' Define file path of log file and initialize log file
        Path = $"{Path}\ErrorLog_{timestamp}.txt"
        WriteToLog($"TimeStamp | Exception | FileName | EntryID")

    End Sub

    Public Sub WriteToLog(ByVal sText As String)
        ' Method used to write text to log file

        'Debug.WriteLine(sText)
        Using writer As New StreamWriter(Path, True)
            writer.Flush()
            writer.WriteLine(sText)
            writer.Flush()
            writer.Close()
        End Using

    End Sub

End Class

Public Class OLProfiles
    ' Used to create a temporary profile when reading PST files (catalog and email import)

    Private _profiles As ProfMan.Profiles

    Public ReadOnly Property Count() As Integer
        Get
            Return _profiles.Count
        End Get
    End Property

    Public Sub New()
        ' Constructor to instantiate new object

        _profiles = New ProfMan.Profiles

    End Sub

    Public Function Add(Name As String) As String
        ' Add named Profile to Profiles collection

        ' Ensures that profile is not named outlook, this name is reserved
        If Name = "outlook" Then Return ""

        ' If Profile already exists, delete it
        Remove(Name)

        ' Create new profile, add to Profiles collection, and return string name of profile
        Return _profiles.Add(Name).Name

    End Function

    Public Sub Remove(Name As String)
        ' Deletes existing Profile by name if it exists in Profiles and name is not "outlook"
        ' Primarily used at the end of reading the PST file to keep Profiles clean

        Dim oProfile As ProfMan.Profile

        ' Ensures that outlook profile is not deleted
        If Name = "outlook" Then Exit Sub

        Dim bContinue = False
        Dim iCounter = 0
        While Not bContinue
            Try
                iCounter += 1

                ' Iterate remaining profiles and delete the specified profile if found
                For i As Integer = 1 To _profiles.Count
                    oProfile = _profiles.Item(i)
                    If oProfile.Name = Name Then
                        _profiles.Delete(i)
                        Exit For
                    End If
                Next
                bContinue = True

            Catch ex As Exception
                Debug.WriteLine(ex)
                Threading.Thread.Sleep(5)
                If iCounter > 10 Then bContinue = True

            End Try

        End While

    End Sub

End Class

Public Class PSTFile

    Public ReadOnly Property ID() As Integer = 0            ' File ID in database
    Public ReadOnly Property Path() As String = "Nothing"   ' Path to PST file
    Public ReadOnly Property Folder() As String = "Nothing" ' Path to folder of PST File
    Public ReadOnly Property Name() As String = "Nothing"   ' Filename of PST File
    Public ReadOnly Property Items() As Integer = 0         ' Total items in PST file

    Public Sub New(FileID As Integer)
        'Create new instance with properties from specific row in the Files table.
        'Throws exception

        Dim dtFiles As New DataTable
        Dim sSQL As String

        Try
            sSQL = $"SELECT fi.ID, fi.FilePath, fi.FolderPath, fi.[FileName]
                        , COALESCE(SUM(fo.ItemCount),0) Items
                    FROM dbo.[Files] fi
                    LEFT JOIN dbo.PSTFolders fo ON fi.ID=fo.FileID
                    WHERE fi.[ID]=@FileID
                    GROUP BY fi.ID, fi.FilePath, fi.FolderPath, fi.[FileName];"
            With New SqlDataAdapter
                .SelectCommand = New SqlCommand(sSQL, CurrProjDB.Connection)
                .SelectCommand.Parameters.Add("@FileID", SqlDbType.Int).Value = FileID
                .Fill(dtFiles)
            End With

            With dtFiles.Rows
                If .Count > 0 Then
                    _ID = .Item(0)("ID")
                    _Path = .Item(0)("FilePath")
                    _Folder = .Item(0)("FolderPath")
                    _Name = .Item(0)("FileName")
                    _Items = .Item(0)("Items")
                End If
            End With

        Catch ex As Exception
            Throw ex

        Finally
            dtFiles.Dispose()

        End Try

    End Sub

    Public Sub New(FilePath As String)
        'Called by Project Details form to create an instance with properties from
        '  specific row in the Files table.
        'Throws exception

        Dim dtFiles As New DataTable
        Dim sSQL As String

        Try
            sSQL = $"SELECT fi.ID, fi.FilePath, fi.FolderPath, fi.[FileName], SUM(fo.ItemCount) Items
                    FROM dbo.[Files] fi
                    LEFT JOIN dbo.[PSTFolders] fo ON fi.ID=fo.FileID
                    WHERE fi.[FilePath]=@FilePath
                    GROUP BY fi.ID, fi.FilePath, fi.FolderPath, fi.[FileName];"
            With New SqlDataAdapter
                .SelectCommand = New SqlCommand(sSQL, CurrProjDB.Connection)
                .SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar, 255).Value = FilePath
                .Fill(dtFiles)
            End With

            With dtFiles.Rows
                If .Count > 0 Then
                    _ID = .Item(0)("ID")
                    _Path = .Item(0)("FilePath")
                    _Folder = .Item(0)("FolderPath")
                    _Name = .Item(0)("FileName")
                    _Items = .Item(0)("Items")
                End If
            End With

        Catch ex As Exception
            Throw ex

        Finally
            dtFiles.Dispose()

        End Try

    End Sub

    Protected Friend Sub New(ID As Integer, FilePath As String, FileFolder As String,
                             FileName As String, Items As Integer)
        'Called by PSTFiles.Fill to create an instance for each row in a data table, allows for one
        '  database query to fill the data table instead of a query query for each file object.

        _ID = ID
        _Path = FilePath
        _Folder = FileFolder
        _Name = FileName
        _Items = Items

    End Sub

End Class

Public Class PSTFiles
    'Collection of PSTFile objects for each row in the Files table

    Public Property Files() As New List(Of PSTFile)
    Public ReadOnly Property Count() As Integer
        Get
            Return _Files.Count
        End Get
    End Property

    Public Sub New()

    End Sub

    Public Sub Add(File As PSTFile)
        'Add new PSTFile object to collection

        _Files.Add(File)

    End Sub

    Public Sub Clear()
        'Remove all objects from collection

        _Files.Clear()

    End Sub

    Public Sub Fill()
        'Fill collection with PSTFile objects

        Dim dtFiles As New DataTable
        Dim sSQL As String

        Try
            sSQL = $"SELECT fi.ID, fi.FilePath, fi.FolderPath, fi.[FileName], SUM(fo.ItemCount) Items
                    FROM dbo.[Files] fi
                    LEFT JOIN dbo.[PSTFolders] fo ON fi.ID=fo.FileID
                    GROUP BY fi.ID, fi.FilePath, fi.FolderPath, fi.[FileName]
                    ORDER BY fi.ID;"
            With New SqlDataAdapter(sSQL, CurrProjDB.Connection)
                .Fill(dtFiles)
            End With

            Clear()
            For Each row As DataRow In dtFiles.Rows
                _Files.Add(New PSTFile(
                                row("ID"),
                                row("FilePath"),
                                row("FolderPath"),
                                row("FileName"),
                                row("Items")))
            Next

        Catch ex As Exception
            Clear()
            Throw ex

        Finally
            dtFiles.Dispose()

        End Try

    End Sub

End Class

Public Class WaitingArgs

    Public ReadOnly Property Operation As String
    Public ReadOnly Property Project As Project
    Public ReadOnly Property FilePath As String

    Public Sub New(Operation As String, Optional Project As Project = Nothing,
                   Optional FilePath As String = "")

        _Operation = Operation
        _Project = Project
        _FilePath = FilePath

    End Sub

End Class