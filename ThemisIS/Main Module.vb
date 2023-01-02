Imports ClassLibrary
Imports ClassLibrary.GlobalObjects
Imports ClassLibrary.GlobalFunctions
Imports FormLibrary
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Windows.Forms
'Imports System.Data.SqlClient
'Imports Redemption
'Imports System.Threading

Module Main

    Private ReadOnly sServerName As String = Environment.MachineName
    Private ReadOnly iProjID As Integer = 1


    Public Sub main()

        Try
            Application.EnableVisualStyles()    ' required for marquee animation in progress bar
            LoadLibrary("riched20")     ' prevents error when frmEmail opened due to rich text box

            'frmDirectory()

            'testFrmProjUpdate("Edit")
            testFrmProjDetails()
            'testFrmEmail()
            'testFrmSearch()
            'testFrmKeyword()
            'testFrmSearchUpdate()
            'testFrmEmail_Grouped()
            'testFrmAttachments(27)
            'testFrmExport()
            'testFrmExportProgress()
            'testFrmEmailExemption(1551, "Exemption")    'Insert or Update and Exemption or Redaction
            'testFrmAttachExemption(12, "Exemption")
            'testFrmRedacted()

            'testOpenEmail()
            'testEmailProperties()
            'testImportEmail()
            'testRandom()


        Catch ex As Exception
            Console.WriteLine($"{DateTime.Now} > {ex}")

        End Try

    End Sub

    Private Sub frmDirectory()

        With New frmDirectory
            .ShowDialog()
        End With

    End Sub

    Private Sub testConnect()

        CurrServer = New Server(sServerName)
        CurrDirectory = New ClassLibrary.Directory()
        CurrProject = CurrDirectory.Projects(iProjID)
        CurrProjDB = New ProjectDB(CurrProject.DatabaseName)

    End Sub

    Private Sub testClose()

        CurrProjDB.Close()
        CurrProject = Nothing
        CurrDirectory.Close()   'also closes Server object

    End Sub

    Private Sub testFrmProjUpdate(ByVal sMode As String)

        Try
            testConnect()

            With New frmProjUpdate(CurrProject)
                .ShowDialog()
            End With

        Catch ex As Exception
            Throw ex

        Finally
            testClose()

        End Try

    End Sub

    Private Sub testFrmProjDetails()

        Try
            testConnect()

            With New frmProjDetails
                .ShowDialog()
            End With

        Catch ex As Exception
            Throw ex

        Finally
            testClose()

        End Try

    End Sub

    Private Sub testFrmExport()

        Try
            testConnect()

            Dim sType = "Produce"
            With New frmExport(sType)
                .ShowDialog()
            End With

        Catch ex As Exception
            Throw ex

        Finally
            testClose()

        End Try

    End Sub

    Private Sub testFrmExportProgress()

        Try
            testConnect()

            Dim RootFolder = New DirectoryInfo("C:\Users\eric.kleen\Desktop\HH\Redaction")
            Dim EmailFolder = New DirectoryInfo(Path.Combine(RootFolder.fullname, "Emails"))
            Dim AttachFolder = New DirectoryInfo(Path.Combine(RootFolder.fullname, "Attachments"))

            RootFolder.delete(recursive:=True)
            RootFolder.create()
            EmailFolder.Create()
            AttachFolder.Create()

            With New frmExportProgress(EmailFolder, AttachFolder)
                .ShowDialog()
            End With

        Catch ex As Exception
            Throw ex

        Finally
            testClose()

        End Try

    End Sub

    Private Sub testFrmKeyword()

        Try
            testConnect()

            With New frmKeywords()
                .ShowDialog()
            End With

        Catch ex As Exception
            Throw ex

        Finally
            testClose()

        End Try

    End Sub

    Private Sub testFrmSearch()

        Try
            testConnect()

            With New frmSearch()
                .ShowDialog()
            End With

        Catch ex As Exception
            Throw ex

        Finally
            testClose()

        End Try

    End Sub

    Private Sub testFrmSearchUpdate()

        Try
            testConnect()

            With New frmSearchUpdate()
                .ShowDialog()
            End With

        Catch ex As Exception
            Throw ex

        Finally
            testClose()

        End Try

    End Sub

    Private Sub testFrmEmail()

        Try
            testConnect()

            Dim sWhere = $"AND ib.[FileID] IN (1)"

            ' Update display email list
            With CurrProjDB.Connection.CreateCommand
                .CommandText = $"EXEC dbo.fUpdate_DisplayEmailIDs @Where, @Unreviewed, @Reviewed, @Types, @Flagged;"
                .Parameters.Add("@Where", SqlDbType.NVarChar).Value = sWhere
                .Parameters.Add("@Unreviewed", SqlDbType.Bit).Value = 1
                .Parameters.Add("@Reviewed", SqlDbType.Bit).Value = 1
                .Parameters.Add("@Types", SqlDbType.NVarChar).Value = "'Produce', 'Non-Responsive', 'Exemption', 'Redaction'"
                .Parameters.Add("@Flagged", SqlDbType.Bit).Value = 0
                .ExecuteNonQuery()
            End With

            With New frmEmail()
                .ShowDialog()
            End With

        Catch ex As Exception
            Throw ex

        Finally
            testClose()

        End Try

    End Sub

    Private Sub testFrmEmail_Grouped()

        Try
            testConnect()

            Dim sWhere = ""

            ' Update display email list
            With CurrProjDB.Connection.CreateCommand
                .CommandText = $"EXEC dbo.fUpdate_DisplayEmailIDs @Where, @Unreviewed, @Reviewed, @Types, @Flagged;"
                .Parameters.Add("@Where", SqlDbType.NVarChar).Value = sWhere
                .Parameters.Add("@Unreviewed", SqlDbType.Bit).Value = 1
                .Parameters.Add("@Reviewed", SqlDbType.Bit).Value = 1
                .Parameters.Add("@Types", SqlDbType.NVarChar).Value = "'Produce', 'Non-Responsive', 'Exemption', 'Redaction'"
                .Parameters.Add("@Flagged", SqlDbType.Bit).Value = 0
                .ExecuteNonQuery()
            End With

            ' Ensure there are grouped rows before opening form
            Dim i As Integer
            With CurrProjDB.Connection.CreateCommand()
                .CommandText = "
                    SELECT COUNT(*) AS [count] FROM dbo.vGroups;"
                i = .ExecuteScalar
            End With

            If i = 0 Then
                MsgBox("No grouped emails to view.", vbOKOnly, "System Message")
                Exit Sub
            End If

            With New frmEmail_Grouped()
                .ShowDialog()
            End With

        Catch ex As Exception
            Throw ex

        Finally
            testClose()

        End Try

    End Sub

    Private Sub testFrmEmailExemption(EmailID As Integer, ExemptionType As String)

        Try
            testConnect()

            With New frmEmailExemption(ExemptionType, EmailID)
                .ShowDialog()
            End With

        Catch ex As Exception
            Throw ex

        Finally
            testClose()

        End Try

    End Sub

    Private Sub testFrmAttachExemption(AttachID As Integer, ExemptionType As String)

        Try
            testConnect()

            With New frmAttachExemption("Exemption", New List(Of Integer) From {AttachID})
                .ShowDialog()
            End With

        Catch ex As Exception
            Throw ex

        Finally
            testClose()

        End Try

    End Sub
    Private Sub testFrmAttachments(EmailID As Integer)

        Try
            testConnect()

            With New frmAttachments(EmailID)
                .ShowDialog()
            End With

        Catch ex As Exception
            Throw ex

        Finally
            testClose()

        End Try

    End Sub

    Private Sub testFrmRedacted()

        Try
            testConnect()

            With New frmRedacted()
                .ShowDialog()
            End With

        Catch ex As Exception
            Throw ex

        Finally
            testClose()

        End Try

    End Sub

    Private Sub testOpenEmail()
        'Open current email in new Outlook application

        Dim ol As New Outlook.Application
        Dim olns As Outlook.NameSpace = Nothing
        Dim ols As Outlook.Store = Nothing
        Dim olm As Outlook.MailItem = Nothing
        Dim sFilePath As String
        Dim sEntryID As String

        Try
            'File and email info
            sFilePath = "C:\Users\eric.kleen\Desktop\RW Emails 4-1-21\pst_files\Keyword - Plan\Keyword_-_Plan--leonardc@njrps.org_0.pst"
            sEntryID = "00000000608A0775D6B9B64FA97DAA600DA0526904322000"

            'Initialize Outlook objects
            olns = ol.GetNamespace("MAPI")
            olns.Logon("", "", False, True)
            ol.Session.AddStore(sFilePath)
            For Each s As Outlook.Store In olns.Stores
                'Only way to select a specific Store from Namespace
                If s.FilePath = sFilePath Then
                    ols = s
                    Exit For
                End If
            Next
            olm = olns.GetItemFromID(sEntryID, ols.StoreID)

            'Open Outlook Inspector window, min+max to bring window to front
            olm.Display()
            olm.GetInspector.WindowState = Outlook.OlWindowState.olMinimized
            olm.GetInspector.WindowState = Outlook.OlWindowState.olMaximized

            'Remove pst file from Outlook and logoff
            olns.RemoveStore(olns.Folders(ols.DisplayName))
            ol.Session.Logoff()

        Catch ex As System.Runtime.InteropServices.COMException
            MsgBox($"Cannot open email at this time.  Please open Outlook and try again.",, "Open Email Error")
            Logger.WriteToLog($"{ex.GetType} occurred while opening email in Outlook.")
            Logger.WriteToLog(ex.ToString)

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Open in Outlook Error")
            Logger.WriteToLog($"{ex.GetType} occurred while opening email in Outlook.")
            Logger.WriteToLog(ex.ToString)

        Finally
            olm = Nothing
            ols = Nothing
            olns = Nothing
            ol = Nothing

        End Try

    End Sub

    Private Sub testEmailProperties()

        Dim sFolder As String = "C:\Users\eric.kleen\Desktop\PF\PST Files"
        Dim sFileName As String = "Bp1_1.pst"
        Dim oFile As FileInfo = New FileInfo(Path.Combine(sFolder, sFileName))
        Dim sEntryID As String = "00000000EACD56F67A33E04686C6F8F6993920BBE4552000"

        Try

            Testing.email_properties(oFile.FullName, sEntryID)

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub testImportEmail()


        Try
            testConnect()

            Dim oPSTFile = New PSTFile(2)
            Dim sEntryID As String = "00000000616D240F36596A4D8624AE4BEB7884E9C4DA2000"

            Testing.importEmail(oPSTFile, sEntryID)

        Catch ex As Exception
            Debug.WriteLine(ex)

        Finally
            testClose()

        End Try

    End Sub

    Private Sub testRandom()


        Try
            testConnect()

            Dim RFIDList As New List(Of Integer) From {231, 243}
            Debug.WriteLine(export_redacted(RFIDList))

        Catch ex As Exception
            Debug.WriteLine(ex)
            'Throw ex

        Finally
            testClose()

        End Try

    End Sub


End Module