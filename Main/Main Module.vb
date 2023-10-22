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

    Private sServerName As String = Environment.MachineName
    Private iProjID As Integer = 1
    Private DevMode As Boolean = False


    Public Sub main()

        Try
            Application.EnableVisualStyles()    ' required for marquee animation in progress bar
            LoadLibrary("riched20")     ' prevents error when frmEmail opened due to rich text box

            frmDirectory()

            'testFrmProjUpdate("Edit")
            'testFrmProjDetails()
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
            'testFrmLicenseKey()


        Catch ex As Exception
            Console.WriteLine($"{DateTime.Now} > {ex}")

        End Try

    End Sub

    Private Sub frmDirectory()

        With New frmDirectory(devMode:=DevMode)
            .ShowDialog()
        End With

    End Sub

    Private Sub testConnect()

        CurrServer = New Server(sServerName)
        CurrDirectory = New ClassLibrary.Directory(devMode:=DevMode)
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

            'Dim sWhere = $"AND ib.EmailID IN (select EmailID from dbo.Attachments where OLType='olEmbeddedItem')"
            Dim sWhere = $"AND ib.EmailID=3737"

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

    Private Sub testFrmLicenseKey()

        Try
            'testConnect()

            With New frmLicenseKey()
                .ShowDialog()
            End With

        Catch ex As Exception
            Throw ex

        Finally
            'testClose()

        End Try

    End Sub


End Module