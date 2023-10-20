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
        Dim rAttach As RDOAttachment
        Dim rSender As RDOAddressEntry

        Try
            rStore = rSession.LogonPstStore(sFilePath)
            rMail = rStore.GetMessageFromID(sEntryID)
            rSender = rMail.Sender
            Debug.WriteLine(rMail.SenderName)
            Debug.WriteLine("done")
            'rFolder = rStore.IPMRootFolder.Folders("Unfiled")
            'For Each rMail In rFolder.Items
            '    For Each rAttach In rMail.Attachments
            '        If rAttach.Type = rdoAttachmentType.olEmbeddedItem Then
            '            Dim sFileName = rAttach.FileName
            '            rAttach.SaveAsFile($"C:\Users\eric.kleen\Desktop\Test\{sFileName}")
            '        End If
            '    Next
            'Next

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)

        Finally
            If rSession.LoggedOn Then rSession.Logoff()

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

End Class