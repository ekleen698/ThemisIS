Imports Redemption
Imports ClassLibrary.GlobalObjects
Imports ClassLibrary.GlobalFunctions
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices.Marshal

Imports System.Data.SqlClient
'Imports System.Data.SqlTypes


Public Class Testing

    Public Shared Sub email_properties(sFilePath As String, sEntryID As String)

        Dim rSession As New RDOSession
        Dim rStore As RDOStore
        Dim rFolder As RDOFolder
        Dim rMail As RDOMail

        Try
            rStore = rSession.LogonPstStore(sFilePath)
            For Each rFolder In rStore.IPMRootFolder.Folders
                For Each rMail In rFolder.Items
                    If rMail.EntryID = sEntryID Then
                        Debug.WriteLine(rMail.Parent.Name)
                    End If
                Next
            Next


        Catch ex As Exception
            Debug.WriteLine(ex.ToString)

        Finally
            rSession.Logoff()

        End Try

    End Sub

    Private Function export_emb_emails(oProjDB As ProjectDB, sFilePath As String,
                        sEntryID As String, iEmailID As Integer, sSavePath As String) As Boolean

        Dim rSession As New RDOSession
        Dim rStores As RDOStores
        Dim rStore As RDOStore
        Dim oProfiles As New OLProfiles
        Dim rItem As RDOMail
        Dim rItem2 As RDOMail
        Dim sSaveFile As String = $"{sSavePath}\EmailID " & iEmailID & ".mhtml"
        Dim bReturn As Boolean = False

        Try
            rSession.Logon(oProfiles.Add("Test_Prof"))
            rStores = rSession.Stores
            rStore = rStores.AddPSTStore(sFilePath)
            rItem = rStore.GetMessageFromID(sEntryID)

            For Each att As RDOAttachment In rItem.Attachments
                If att.Type.ToString = "olEmbeddedItem" Then
                    rItem2 = att.EmbeddedMsg

                    Console.WriteLine($"Begin -> {Now}")
                    rItem2.SaveAs(sSaveFile, rdoSaveAsType.olMHTML)

                    Console.WriteLine($"Create PDF -> {Now}")
                    'ConvertWordToPDF(sSaveFile)

                    Console.WriteLine($"End -> {Now}")
                    Dim oFile As New FileInfo(sSaveFile)
                    If Not IsNothing(oFile) Then oFile.Delete()
                    oFile = Nothing

                End If
            Next

            bReturn = True

        Catch ex As Exception
            Console.WriteLine(ex)

        Finally
            rSession.Logoff()
            oProfiles.Remove("Test_Prof")

        End Try

        Return bReturn

    End Function


    Public Shared Sub importEmail(_File As PSTFile, sEntryID As String)

        ' Testing
        Dim oProfiles As New OLProfiles
        Dim rSession As New RDOSession
        Dim rStores As RDOStores
        Dim rStore As RDOStore
        Dim rMail As RDOMail
        Dim rParent As RDOFolder
        Dim iEmbAttID = 0
        Dim _Trans = CurrProjDB.Connection.BeginTransaction("Current")

        Dim sSQL As String = ""
        'Dim sEntryID As String = ""
        Dim sRecipients As String = ""
        Dim sTo As String = ""
        Dim sTo_Name As String = ""
        Dim sCC As String = ""
        Dim sCC_Name As String = ""
        Dim sBCC As String = ""
        Dim sBCC_Name As String = ""
        Dim sSender As String = ""
        Dim iEmailID As Integer = 0
        Dim rRecipients As RDORecipients = Nothing
        Dim rRecipient As RDORecipient = Nothing
        'Dim rAttachments As RDOAttachments = Nothing
        Dim rSender As RDOAddressEntry = Nothing

        Try
            ' Testing
            rSession.Logon(oProfiles.Add("Test_Prof"))
            rStores = rSession.Stores
            rStore = rStores.AddPSTStore(_File.Path)
            rMail = rStore.GetMessageFromID(sEntryID)
            rParent = rMail.Parent
            Dim sParent = rParent.Name
            ReleaseComObject(rStores)
            ReleaseComObject(rStore)
            ReleaseComObject(rParent)

            'First embedded message returns EntryID of parent email, further embedded messages return nothing
            If Nz(rMail.EntryID) = "" Then
                sEntryID = "Embedded"
            Else
                sEntryID = rMail.EntryID
            End If

            'Resolve common causes of errors
            If Not IsNothing(rMail.Sender) Then
                rSender = rMail.Sender
                sSender = rSender.Address
                ReleaseComObject(rSender)
            End If
            If Len(sSender) = 0 Then sSender = "No Sender"
            If Not IsNothing(rMail.To) Then
                sTo_Name = rMail.To.ToString
            End If
            If Not IsNothing(rMail.CC) Then
                sCC_Name = rMail.CC.ToString
            End If
            If Not IsNothing(rMail.BCC) Then
                sBCC_Name = rMail.BCC.ToString
            End If

            'Build string containing all recipient email addresses (To, CC, BCC)
            If Not IsNothing(rMail.Recipients) Then
                rRecipients = rMail.Recipients

                For i = 1 To rRecipients.Count
                    rRecipient = rRecipients(i)
                    If Not IsNothing(rRecipient.Address) Then
                        sRecipients = sRecipients & rRecipient.Address.ToString & "; "
                        Select Case rRecipient.Type
                            Case 1 'To
                                sTo = sTo & rRecipient.Address.ToString & "; "
                                Exit Select
                            Case 2 'CC
                                sCC = sCC & rRecipient.Address.ToString & "; "
                                Exit Select
                            Case 3 'BCC
                                sBCC = sBCC & rRecipient.Address.ToString & "; "
                                Exit Select
                        End Select
                    End If
                    ReleaseComObject(rRecipient)
                Next
                ReleaseComObject(rRecipients)

                'Trim "; " from end of strings
                If sRecipients.Length > 2 Then
                    sRecipients = sRecipients.Remove(sRecipients.Length - 2)
                End If
                If sTo.Length > 2 Then
                    sTo = sTo.Remove(sTo.Length - 2)
                End If
                If sCC.Length > 2 Then
                    sCC = sCC.Remove(sCC.Length - 2)
                End If
                If sBCC.Length > 2 Then
                    sBCC = sBCC.Remove(sBCC.Length - 2)
                End If

            End If

            'Initialize command object for dbo.Inbox insert
            sSQL = "INSERT INTO [dbo].[Inbox] (
                [FileID], [Parent], [EntryID], [EmbAttID], [Importance], [MessageClass], [Subject], 
                [SentOn], [Sender], [SenderName], [To], [To_Name], [CC], [CC_Name], [BCC], [BCC_Name], 
                [Recipients], [ReceivedTime], [Size], [CreationTime], [Attachments], [Body]) 
            VALUES (@FileID, @Parent, @EntryID, @EmbAttId, @Importance, @MessageClass, @Subject, 
                @SentOn, @Sender, @SenderName, @To, @To_Name, @CC, @CC_Name, @BCC, @BCC_Name,
                @Recipients, @ReceivedTime, @Size, @CreationTime, @Attachments, @Body); 
            SELECT CAST([last_used_value] AS INT) AS [EmailID]
                FROM [sys].[sequences] WHERE [name] ='sInbox_PK';"
            With CurrProjDB.Connection.CreateCommand
                .CommandText = sSQL
                .Parameters.Add("@FileID", SqlDbType.Int)
                .Parameters.Add("@Parent", SqlDbType.VarChar, 255)
                .Parameters.Add("@EntryID", SqlDbType.VarChar, 50)
                .Parameters.Add("@EmbAttID", SqlDbType.Int)
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
                .Parameters("@EmbAttID").Value = iEmbAttID
                .Parameters("@Importance").Value = rMail.Importance
                .Parameters("@MessageClass").Value = rMail.MessageClass
                .Parameters("@Subject").Value = Nz(rMail.Subject)
                .Parameters("@SentOn").Value = rMail.SentOn
                .Parameters("@Sender").Value = sSender
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
                .Parameters("@Attachments").Value = rMail.Attachments.Count
                .Parameters("@Body").Value = Nz(rMail.Body)

                'Row ID of new row, used in dbo.Attachments insert operation
                .Transaction = _Trans
                iEmailID = .ExecuteScalar()

            End With

            ' testing
            _Trans.Commit()
            Debug.WriteLine("Committed")
            ReleaseComObject(rMail)

        Catch ex As SqlException
            If ex.Number = 2601 Then
                Debug.WriteLine("Email skipped due to unique key violation.")
            End If
            _Trans.Rollback()

        Catch ex As Exception
            Debug.WriteLine(ex)
            _Trans.Rollback()

        Finally
            'Close active Session
            If rSession.LoggedOn Then rSession.Logoff()
            oProfiles.Remove("Test_Prof")
            oProfiles = Nothing

            'Release memory of com object
            ReleaseComObject(rSession)

        End Try

    End Sub

End Class