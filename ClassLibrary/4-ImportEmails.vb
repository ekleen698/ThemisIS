Imports ClassLibrary.GlobalObjects
Imports ClassLibrary.GlobalFunctions
Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading
Imports System.Runtime.InteropServices.Marshal
Imports Redemption

Public Class ImportEmails

    ' Objects used for Thread
    Public Event ImportStatus(ByVal sender As Object, ByVal iCount As Integer,
                              ByVal iTotal As Integer, ByVal sFile As String, ByVal bEnd As Boolean)
    Public ImportThread As Thread
    Private _iCount As Integer
    Private _bStop As Boolean = False

    ' Other Class variables
    Private _Trans As SqlTransaction
    Private _Session As RDOSession
    Private _Stores As RDOStores
    Private _Store As RDOStore
    Private _IPMRoot As RDOFolder
    Private _Folders As RDOFolders
    Private _File As PSTFile
    Private _Files As PSTFiles
    Private _TotalItems As Integer = 0         'total items in all folders in pst file
    Private _TotalScanned As Integer = 0       'total items iterated over in each pst file
    Private _TotalImported As Integer = 0      'successfully imported items
    Private _TotalSkipped As Integer = 0       'items skipped during import due to Unique Key
    Private _TotalErrors As Integer = 0        'emails that failed to import
    Private _AttachErrors As Integer = 0       'attachments which fail to import

    Public Sub StartImport(PSTFiles As PSTFiles)

        _Files = PSTFiles

        ' Define the thread 
        ImportThread = New Thread(AddressOf getEmails)
        ImportThread.IsBackground = True
        ImportThread.Name = "Import"
        ImportThread.Start()

    End Sub

    Public Sub StopImport()
        _bStop = True
    End Sub

    Private Sub getEmails()
        'Initialize Redemption session and attach each PST file and import all emails
        'Throws exception

        Dim oProfiles As New OLProfiles

        Try
            'Drop all indexes on Foreign Keys and FULLTEXT INDEX
            With CurrProjDB.Connection.CreateCommand
                .CommandText = "EXEC dbo.fDropIndexes;"
                .ExecuteNonQuery()
                Logger.WriteToLog($"Indexes dropped.")
            End With

            'Initialize Session
            _Session = New RDOSession
            _Session.Logon(oProfiles.Add("Import_Prof"))
            _Stores = _Session.Stores

            ' Loop all folders in pst file, import all emails and attachments
            For Each f As PSTFile In _Files.Files
                If _bStop Then Exit For

                _File = f
                Logger.WriteToLog($"Import emails from {_File.Name}.")

                'Reset all counters for each PST file
                _TotalItems = _File.Items
                _TotalScanned = 0
                _TotalImported = 0
                _TotalSkipped = 0
                _TotalErrors = 0

                'Get Folders object from pst file
                _Store = _Stores.AddPSTStore(_File.Path)
                _IPMRoot = _Store.IPMRootFolder
                _Folders = _IPMRoot.Folders

                'Release memory of com objects
                ReleaseComObject(_IPMRoot)

                'iterate each folder in pst file and import all items
                loopPSTFolders(_Folders)

                'Release memory of com object
                ReleaseComObject(_Store)
                ReleaseComObject(_Folders)

                'output results
                Logger.WriteToLog($"{_File.Name} Results >> " &
                                  $"Total Items: {_TotalItems}" & " | " &
                                  $"Imported Items: {_TotalImported}" & " | " &
                                  $"Skipped Items: {_TotalSkipped}" & " | " &
                                  $"Errored Items: {_TotalErrors}")

            Next

            'Release memory of com object
            ReleaseComObject(_Stores)

            ' Raise Event to update progress bar status
            RaiseEvent ImportStatus(Me, -1, -1, "Updating Duplicates", False)

            ' Update Inbox.Duplicate column
            Dim iDups As Integer
            With CurrProjDB.Connection.CreateCommand
                .CommandText = "
                    DECLARE @rows INT;
                    EXEC @rows = dbo.fUpdateDuplicates;
                    SELECT @rows AS [rows];"
                iDups = .ExecuteScalar()
                Logger.WriteToLog($"{iDups} emails marked as duplicate.")
            End With

            ' Raise Event to update progress bar status
            RaiseEvent ImportStatus(Me, -1, -1, "Creating Indexes", False)

            ' Create all indexes on Foreign Keys and FULLTEXT INDEX
            With CurrProjDB.Connection.CreateCommand
                ' Create table indexes
                .CommandText = "EXEC dbo.fCreateIndexes;"
                .ExecuteNonQuery()

                ' Populate FullText index
                .CommandText = "ALTER FULLTEXT INDEX ON dbo.Inbox START FULL POPULATION;"
                .ExecuteNonQuery()

                ' Wait for Full Text Index to be populated before continuing
                .CommandText = $"SELECT FULLTEXTCATALOGPROPERTY('iFullText','PopulateStatus');"
                Dim iResponse As Integer = 1    ' 1-9=populating; 0=complete
                While iResponse > 0
                    Thread.Sleep(1000)
                    iResponse = .ExecuteScalar()
                End While
                Logger.WriteToLog($"Indexes created and populated.")
            End With

            ' Raise Event to update progress bar status
            RaiseEvent ImportStatus(Me, -1, -1, "Updating Keywords", False)

            ' Delete and populate the DisplayTerms table
            With CurrProjDB.Connection.CreateCommand
                .CommandTimeout = My.Settings.TimeOutSeconds
                .CommandText = $"DELETE FROM dbo.DisplayTerms;"
                .ExecuteNonQuery()

                .CommandText = $"EXEC dbo.fDisplayTerms @Database;"
                .Parameters.Add("@Database", SqlDbType.NVarChar, 50).Value = CurrProjDB.Name
                .ExecuteNonQuery()
                Logger.WriteToLog($"DisplayTerms table updated.")
            End With

            ' Display message if any attachments failed to import
            If _AttachErrors > 0 Then
                MsgBox($"{_AttachErrors} attachment(s) failed to import, see log file for details.", vbOKOnly,
                       "Attachment Import Errors")
            End If

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Import Email Error")
            Logger.WriteToLog($"{ex.GetType} occurred while importing emails from '{_File.Name}'.")
            Logger.WriteToLog(ex.ToString)

        Finally
            'Close active Session
            If _Session.LoggedOn Then _Session.Logoff()
            oProfiles.Remove("Import_Prof")

            'Release memory of com object
            ReleaseComObject(_Session)

            ' Raise final import status event to signal Thread has ended to close frmProgress
            RaiseEvent ImportStatus(Me, -1, -1, "Complete", True)

        End Try

        _File = Nothing
        _Files = Nothing
        _Session = Nothing
        _Stores = Nothing
        _Store = Nothing
        _IPMRoot = Nothing
        _Folders = Nothing
        oProfiles = Nothing

    End Sub

    Private Sub loopPSTFolders(ByRef rFolders As RDOFolders)
        'Allows recursive calls for subfolders

        Dim rFolder As RDOFolder
        Dim rSubFolders As RDOFolders
        Dim rItems As RDOItems

        For i = 1 To rFolders.Count
            If _bStop Then Exit For

            'Iterate each folder in collection
            rFolder = rFolders(i)
            rItems = rFolder.Items
            rSubFolders = rFolder.Folders

            'import items from current folder
            If rItems.Count > 0 Then loopItems(rFolder)
            ReleaseComObject(rFolder)
            ReleaseComObject(rItems)

            'recursive call for all subfolders of current folder
            If rSubFolders.Count > 0 Then loopPSTFolders(rSubFolders)
            ReleaseComObject(rSubFolders)

        Next

    End Sub

    Private Sub loopItems(ByRef rFolder As RDOFolder)
        'Iterates all items in current folder and inserts rows into dbo.Inbox and dbo.Attachments

        Dim rItems As RDOItems = rFolder.Items
        Dim rMail As RDOMail = Nothing
        Dim rParent As RDOFolder = Nothing
        Dim sEntryID As String = ""

        'Iterate all items in current folder
        For i = 1 To rItems.Count
            If _bStop Then Exit For

            Try
                'Begin transaction to allow rollback of all insert operations if error occurs
                _Trans = CurrProjDB.Connection.BeginTransaction("Current")

                ' Raise the import status event after each email
                _TotalScanned += 1
                RaiseEvent ImportStatus(Me, _TotalScanned, _TotalItems, _File.Name, False)
                Thread.Sleep(10)

                ' Test for corrupted emails
                rMail = rItems(i)
                rParent = rMail.Parent  'Outlook folder containing rMail
                sEntryID = rMail.EntryID
                Try
                    _Store.GetMessageFromID(sEntryID)

                Catch ex As Runtime.InteropServices.COMException
                    Throw New CorruptEmailException(ex)

                End Try

                ' Insert Email, commit all insert operations if no errors, update imported items counter
                insertEmail(rMail, rParent.Name)
                _Trans.Commit()
                _TotalImported += 1

            Catch ex As SqlException
                _Trans.Rollback()
                If ex.Number = 2627 Then
                    ' Unique Key = FileID + EntryID
                    _TotalSkipped += 1
                    Logger.WriteToLog($"{sEntryID} skipped due to unique key violation.")
                    ErrLogger.WriteToLog($"{Now.ToString("yyyy-MM-dd_HH-mm-ss")}|UniqueKeyViolation|" &
                                     $"{_File.Name}|{sEntryID}")
                Else
                    ' Log error and end operation
                    Debug.WriteLine(ex)
                    Throw New Exception("loopItems SQL Error", ex)
                End If

            Catch ex As CorruptEmailException
                _Trans.Rollback()
                _TotalErrors += 1
                ErrLogger.WriteToLog($"{Now.ToString("yyyy-MM-dd_HH-mm-ss")}|CorruptEmailException|" &
                                     $"{_File.Name}|{sEntryID}")
                'ErrLogger.WriteToLog($"CorruptEmailException ----> {ex.InnerException}") ' for debugging

            Catch ex As Exception
                _Trans.Rollback()
                Logger.WriteToLog($"EntryID :: {sEntryID}")
                Throw New Exception("loopItems Error", ex)

                Finally
                'Release memory of com objects
                ReleaseComObject(rParent)
                ReleaseComObject(rMail)

            End Try

        Next

        ReleaseComObject(rItems)

    End Sub

    Private Sub insertEmail(ByRef rMail As RDOMail, sParent As String)
        'Parent is folder name for regular emails

        Dim sSQL As String = ""
        Dim sEntryID As String = rMail.EntryID
        Dim sSender As String = ""
        Dim sSep As String = "; "
        Dim slstTO As New List(Of String)
        Dim slstCC As New List(Of String)
        Dim slstBCC As New List(Of String)
        Dim sTo As String = ""
        Dim sTo_Name As String = ""
        Dim sCC As String = ""
        Dim sCC_Name As String = ""
        Dim sBCC As String = ""
        Dim sBCC_Name As String = ""
        Dim sRecipients As String = ""
        Dim iEmailID As Integer = 0
        Dim iAttachmentCount As Integer = 0
        'Dim rSender As RDOAddressEntry = Nothing
        Dim rRecipients As RDORecipients = Nothing
        Dim rRecipient As RDORecipient = Nothing
        Dim rAttachments As RDOAttachments = Nothing

        'Properties using OutlookSpy
        Dim PIDTAGSENDERSMTPADDRESS_W As String = "http://schemas.microsoft.com/mapi/proptag/0x5D01001F"
        Dim OTHERSENDERPROP As String = "http://schemas.microsoft.com/mapi/proptag/0x5D0A001F"

        'Get sender email address
        If rMail.SenderEmailType = "EX" Then
            ' Exchange emails
            sSender = rMail.Fields(PIDTAGSENDERSMTPADDRESS_W)
            If IsNothing(sSender) OrElse sSender = "" Then
                sSender = rMail.Fields(OTHERSENDERPROP)
            End If
        Else
            ' SMTP emails
            sSender = rMail.SenderEmailAddress
        End If

        'Get display string for each address type
        If Not IsNothing(rMail.To) Then sTo_Name = rMail.To.ToString
        If Not IsNothing(rMail.CC) Then sCC_Name = rMail.CC.ToString
        If Not IsNothing(rMail.BCC) Then sBCC_Name = rMail.BCC.ToString

        'Build string containing all recipient email addresses (To, CC, BCC)
        Try
            rRecipients = rMail.Recipients
            For i As Integer = 1 To rRecipients.Count
                rRecipient = rRecipients(i)
                If rRecipient.Type = 1 Then  'TO
                    slstTO.Add(rRecipient.SMTPAddress)
                ElseIf rRecipient.Type = 2 Then  'CC
                    slstCC.Add(rRecipient.SMTPAddress)
                ElseIf rRecipient.Type = 3 Then  'BCC
                    slstBCC.Add(rRecipient.SMTPAddress)
                End If
                ReleaseComObject(rRecipient)
            Next
            ReleaseComObject(rRecipients)

            sTo = String.Join(sSep, slstTO)
            sCC = String.Join(sSep, slstCC)
            sBCC = String.Join(sSep, slstBCC)
            sRecipients = String.Join(sSep, {sTo, sCC, sBCC})

        Catch ex As Runtime.InteropServices.COMException
            ' no Recipients object

        End Try

        Try
            rAttachments = rMail.Attachments
            iAttachmentCount = rAttachments.Count
            ReleaseComObject(rAttachments)

        Catch ex As Runtime.InteropServices.COMException
            ' no Attachments object

        End Try

        'Initialize command object for dbo.Inbox insert
        sSQL = "INSERT INTO [dbo].[Inbox] (
                [FileID], [Parent], [EntryID], [Importance], [MessageClass], [Subject], 
                [SentOn], [Sender], [SenderName], [To], [To_Name], [CC], [CC_Name], [BCC], [BCC_Name], 
                [Recipients], [ReceivedTime], [Size], [CreationTime], [Attachments], [Body]) 
            VALUES (@FileID, @Parent, @EntryID, @Importance, @MessageClass, @Subject, 
                @SentOn, @Sender, @SenderName, @To, @To_Name, @CC, @CC_Name, @BCC, @BCC_Name,
                @Recipients, @ReceivedTime, @Size, @CreationTime, @Attachments, @Body); 
            SELECT CAST([last_used_value] AS INT) AS [EmailID]
                FROM [sys].[sequences] WHERE [name] ='sInbox_PK';"

        With CurrProjDB.Connection.CreateCommand
            .CommandText = sSQL
            .Parameters.Add("@FileID", SqlDbType.Int)
            .Parameters.Add("@Parent", SqlDbType.VarChar, 255)
            .Parameters.Add("@EntryID", SqlDbType.VarChar, 50)
            .Parameters.Add("@Importance", SqlDbType.Int)
            .Parameters.Add("@MessageClass", SqlDbType.VarChar, 255)
            .Parameters.Add("@Subject", SqlDbType.VarChar)
            .Parameters.Add("@SentOn", SqlDbType.DateTime)
            .Parameters.Add("@Sender", SqlDbType.VarChar, 255)
            .Parameters.Add("@SenderName", SqlDbType.VarChar, 255)
            .Parameters.Add("@To", SqlDbType.VarChar)
            .Parameters.Add("@To_Name", SqlDbType.VarChar)
            .Parameters.Add("@CC", SqlDbType.VarChar)
            .Parameters.Add("@CC_Name", SqlDbType.VarChar)
            .Parameters.Add("@BCC", SqlDbType.VarChar)
            .Parameters.Add("@BCC_Name", SqlDbType.VarChar)
            .Parameters.Add("@Recipients", SqlDbType.VarChar)
            .Parameters.Add("@ReceivedTime", SqlDbType.DateTime)
            .Parameters.Add("@Size", SqlDbType.Int)
            .Parameters.Add("@CreationTime", SqlDbType.DateTime)
            .Parameters.Add("@Attachments", SqlDbType.Int)
            .Parameters.Add("@Body", SqlDbType.VarChar)

            'Add values to command parameters
            .Parameters("@FileID").Value = _File.ID
            .Parameters("@Parent").Value = sParent
            .Parameters("@EntryID").Value = sEntryID
            .Parameters("@Importance").Value = rMail.Importance
            .Parameters("@MessageClass").Value = rMail.MessageClass
            .Parameters("@Subject").Value = Nz(rMail.Subject)
            .Parameters("@SentOn").Value = rMail.SentOn
            .Parameters("@Sender").Value = Nz(sSender)
            .Parameters("@SenderName").Value = Nz(rMail.SenderName)
            .Parameters("@To").Value = sTo
            .Parameters("@To_Name").Value = sTo_Name
            .Parameters("@CC").Value = sCC
            .Parameters("@CC_Name").Value = sCC_Name
            .Parameters("@BCC").Value = sBCC
            .Parameters("@BCC_Name").Value = sBCC_Name
            .Parameters("@Recipients").Value = sRecipients
            .Parameters("@ReceivedTime").Value = rMail.ReceivedTime
            .Parameters("@Size").Value = rMail.Size
            .Parameters("@CreationTime").Value = rMail.CreationTime
            .Parameters("@Attachments").Value = iAttachmentCount
            .Parameters("@Body").Value = Nz(rMail.Body)

            'Row ID of new row, used in dbo.Attachments insert operation
            .Transaction = _Trans
            iEmailID = .ExecuteScalar()

        End With

        'Iterate all attachments in current item, insert new rows in dbo.Attachments

        If iAttachmentCount > 0 Then
            loopAttachments(iEmailID, rMail)
        End If

    End Sub

    Private Sub loopAttachments(iEmailID As Integer, ByRef rMail As RDOMail)
        'Iterates all attachments in current item and inserts rows into dbo.Attachments

        Dim rAttachments As RDOAttachments
        Dim rAttachment As RDOAttachment
        Dim buffer As Byte()
        Dim sSQL As String = ""
        Dim sFileName As String = ""
        Dim sType As String = ""
        Dim iID As Integer = 0


        sSQL = $"INSERT INTO [Attachments] (EmailID, OLType, FileName, FileExt, FileStream)
                    VALUES (@EmailID, @OLType, @FileName, @FileExt, @BLOB);
                SELECT (SELECT CAST([last_used_value] AS INT) 
                    FROM [sys].[sequences] WHERE [name] ='sAttachments_PK') AS [ID];"

        rAttachments = rMail.Attachments
        For i = 1 To rAttachments.Count
            rAttachment = rAttachments(i)

            'Get filename and extension for attachment
            sFileName = Nz(rAttachment.FileName)
            sType = attType(sFileName)

            With CurrProjDB.Connection.CreateCommand

                'Initialize command object for insert
                .Transaction = _Trans
                .Parameters.Add("@EmailID", SqlDbType.Int).Value = iEmailID
                .Parameters.Add("@OLType", SqlDbType.VarChar, 50).Value = rAttachment.Type.ToString
                .Parameters.Add("@FileName", SqlDbType.VarChar, 255).Value = sFileName
                .Parameters.Add("@FileExt", SqlDbType.VarChar, 20).Value = sType

                'Based on type of attachment, perform insert operation
                If rAttachment.Type = rdoAttachmentType.olEmbeddedItem Then
                    ' save embedded msg to temp folder
                    Dim sSavePath = Path.Combine(Path.GetTempPath, sFileName)
                    rAttachment.SaveAsFile(sSavePath)

                    ' import saved file
                    Using fs As New FileStream(sSavePath, FileMode.Open)
                        Using rdr As New BinaryReader(fs)
                            buffer = rdr.ReadBytes(rdr.BaseStream.Length)
                        End Using
                    End Using
                    .CommandText = sSQL
                    .Parameters.Add("@BLOB", SqlDbType.VarBinary).Value = buffer
                    iID = .ExecuteScalar()

                ElseIf ({"ics", "", "bin"}.Contains(sType)) Then
                    'skip inserting file

                Else
                    'insert new row in table and include file binary data
                    Try
                        If (rAttachment.Type = rdoAttachmentType.olByValue) And (Not rAttachment.Hidden) Then
                            buffer = rAttachment.AsArray
                            .CommandText = sSQL
                            .Parameters.Add("@BLOB", SqlDbType.VarBinary).Value = buffer
                            iID = .ExecuteScalar()
                        End If

                    Catch e As Exception
                        _AttachErrors += 1
                        Logger.WriteToLog(e.ToString)
                        Logger.WriteToLog($"EmailID: {iEmailID} / Filename: {sFileName} / OLType: {sType}")

                    End Try

                End If

            End With
            ReleaseComObject(rAttachment)

        Next
        ReleaseComObject(rAttachments)

    End Sub

    Private Function attType(sFileName As String) As String
        Dim sType As String

        If Len(sFileName) = 0 OrElse (Not sFileName.Contains(".")) Then
            sType = ""
        Else
            sType = Mid(sFileName, InStrRev(sFileName, ".") + 1)
        End If

        Return sType

    End Function

End Class

Public Class CorruptEmailException
    Inherits Exception

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal inner_exception As Exception)
        MyBase.New("", inner_exception)
    End Sub

End Class