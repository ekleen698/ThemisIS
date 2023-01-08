
Imports System.IO
Imports System.Data.SqlClient
Imports System.Threading
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports GemBox.Pdf
Imports GemBox.Pdf.Content
Imports Redemption
Imports ClassLibrary
Imports ClassLibrary.GlobalObjects
Imports ClassLibrary.GlobalFunctions

Public Class Exporter
    ' Used by Export Progress form to export emails and attachments from pst files and create logs

    Public Event ExportStatus(sender As Object, OpStep As String, Count As Integer, Total As Integer)

    Private _EmailFolder As DirectoryInfo
    Private _AttachFolder As DirectoryInfo
    Private _Token As CancellationToken
    Private _Type As String

    Private _EmailsTable As New DataTable
    Private _AttachTable As New DataTable
    Private _Count As Integer = 0
    Private _Total As Integer = 0
    Private _OpStep As String
    Private _EmailID As Integer  ' used for exporting single email

    Public Sub New(EmailFolder As DirectoryInfo, AttachFolder As DirectoryInfo, Token As CancellationToken, Type As String)
        ' Initialize object

        ' Initialize class variables
        _EmailFolder = EmailFolder
        _AttachFolder = AttachFolder
        _Token = Token
        _Type = Type

        ' Get Emails for the specified type
        ' Exclude: Flagged Emails
        Dim sSQL = "
            SELECT DISTINCT f.[FileName], ib.[EmailID]
                , ib.[SentOn], ib.[Sender], ib.[To], ib.[CC], ib.[BCC], ib.[Subject], ib.Attachments
                , ex.Exemption [Reason], st.Description [Reason Description]
	            , f.[FilePath], ib.[EntryID], ISNULL(rf.ID,0) [RFID]
            FROM dbo.[Inbox] ib
            JOIN dbo.[Files] f ON ib.FileID=f.ID
            JOIN dbo.[EmailExemptStatus] st ON ib.EmailID=st.EmailID
            JOIN dbo.[sys_Exemptions] ex ON st.ExemptionID=ex.ID
            JOIN dbo.[sys_ExemptionTypes] ty ON ex.TypeID=ty.ID 
			LEFT JOIN dbo.[vRedactedFiles] rf ON ib.EmailID=rf.EmailID
            WHERE 1=1
            AND st.Flag=0
            AND (IIF(ty.Exemption_Type='Redaction', ISNULL(rf.ID,0), 1))>0
            AND ty.Exemption_Type=@Type
            ORDER BY f.[FileName], ib.EmailID;"
        With New SqlDataAdapter(sSQL, CurrProjDB.Connection)
            .SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar, 50).Value = _Type
            .Fill(_EmailsTable)
        End With

        ' Get Attachments for the specified type
        ' Exclude: Attachments for Flagged emails
        sSQL = $"SELECT DISTINCT f.[FileName], a.[EmailID]
                    , a.ID [AttachID], a.[FileName] [Attachment]
	                , ex.Exemption [Reason], st.[Description] [Reason Description]
                FROM dbo.[Attachments] a 
                JOIN dbo.[Inbox] ib ON a.EmailID=ib.EmailID 
                LEFT JOIN dbo.[EmailExemptStatus] est ON ib.EmailID=est.EmailID
                JOIN dbo.[Files] f ON ib.FileID=f.ID
                JOIN dbo.[AttachExemptStatus] st ON a.[ID]=st.[AttachID]
                JOIN dbo.[sys_Exemptions] ex ON st.[ExemptionID]=ex.[ID]
                JOIN dbo.[sys_ExemptionTypes] ty ON ex.[TypeID]=ty.[ID] 
                WHERE 1=1
                AND ISNULL(est.Flag,0)=0
                AND ty.[Exemption_Type]=@Type
                ORDER BY f.[FileName], a.[EmailID], a.[ID];"
        With New SqlDataAdapter(sSQL, CurrProjDB.Connection)
            .SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar, 50).Value = _Type
            .Fill(_AttachTable)
        End With

    End Sub

    Public Sub New(EmailID As Integer)
        ' Used for redacting a single email

        _EmailID = EmailID

        ' Get pst file and email info
        Dim sSQL = "
            SELECT TOP 1 f.[FilePath], ib.[EntryID]
            FROM dbo.[Inbox] ib
            JOIN dbo.[Files] f ON ib.FileID=f.ID
            WHERE 1=1
            AND ib.EmailID=@EmailID;"
        With New SqlDataAdapter(sSQL, CurrProjDB.Connection)
            .SelectCommand.Parameters.Add("@EmailID", SqlDbType.Int).Value = EmailID
            .Fill(_EmailsTable)
        End With

    End Sub

    Public Function export() As Dictionary(Of String, Object)
        ' Called by Export Progress form to begin the process

        ' Initialize
        Dim Result = New Dictionary(Of String, Object) From {
            {"Cancelled", False},
            {"OpError", Nothing}
            }

        Try
            ' Create email log
            _OpStep = "Creating Logs"
            RaiseEvent ExportStatus(Me, _OpStep, 0, 2)
            emailLog()

            ' Exit if cancelled
            _Token.ThrowIfCancellationRequested()

            ' Create attachment log
            RaiseEvent ExportStatus(Me, _OpStep, 1, 2)
            attachmentLog()

            ' Exit if cancelled
            _Token.ThrowIfCancellationRequested()

            ' Export emails
            _OpStep = "Exporting Emails"
            RaiseEvent ExportStatus(Me, _OpStep, _Count, _Total)
            If _Type = "Redaction" Then
                export_redacted_files()
            Else
                export_emails()
            End If

            ' Export attachments
            _Count = 0
            _Total = 0
            _OpStep = "Exporting Attachments"
            RaiseEvent ExportStatus(Me, _OpStep, _Count, _Total)
            export_attachments()

        Catch ex As OperationCanceledException
            Result("Cancelled") = True

        Catch ex As Exception
            ' Exception logged by Parent
            Result("OpError") = ex

        End Try

        ' Final update to status bar to show total file count
        RaiseEvent ExportStatus(Me, _OpStep, _Count, _Total)

        Return Result

    End Function

    Private Sub export_emails()
        ' Export all non-Redaction emails to a new subfolder for each pst file
        ' Throws exception to stop export process

        Dim drRows() As DataRow
        Dim PSTFile As FileInfo
        Dim sEmailID As String = ""
        Dim sFiles As IEnumerable(Of String)
        Dim SubFolder As DirectoryInfo
        ' Redemption Objects
        Dim oProfiles As New OLProfiles
        Dim rSession As New RDOSession
        Dim rStores As RDOStores
        Dim rStore As RDOStore
        Dim rItem As RDOMail

        Try
            ' Reduce to distinct emails (some emails have multiple exemptions)
            Dim ColsList = {"FilePath", "EntryID", "EmailID"}
            _EmailsTable = _EmailsTable.DefaultView.ToTable(distinct:=True, ColsList)
            _Total = _EmailsTable.Rows.Count
            RaiseEvent ExportStatus(Me, _OpStep, _Count, _Total)

            ' Initialize Redemption objects
            rSession.Logon(oProfiles.Add("Export_Prof"))
            rStores = rSession.Stores

            ' Iterate over unique files, connect to each file only once
            sFiles = _EmailsTable.AsEnumerable().Select(Function(row) row.Field(Of String)("FilePath")).Distinct()

            ' Ensure file exist before entering loop
            For Each sFile As String In sFiles
                PSTFile = New FileInfo(sFile)
                If Not PSTFile.Exists Then Throw New FileNotFoundException(PSTFile.Name)
            Next

            For Each sFile As String In sFiles

                ' Get collection of emails for the current file
                PSTFile = New FileInfo(sFile)
                drRows = _EmailsTable.Select($"FilePath='{sFile}'")

                ' Create subfolder for each pst file
                ' TODO: ensure subfolder name is unique
                SubFolder = New DirectoryInfo(Path.Combine(_EmailFolder.FullName, PSTFile.Name))
                SubFolder.Create()

                ' Initialize loop variables
                rStore = rStores.AddPSTStore(sFile)

                ' Loop
                For Each row As DataRow In drRows

                    ' Exit if cancelled
                    _Token.ThrowIfCancellationRequested()

                    ' Save each email in collection
                    sEmailID = row("EmailID")
                    rItem = rStore.GetMessageFromID(row("EntryID"))
                    export_to_mhtml(rItem, sEmailID, SubFolder)
                    Marshal.ReleaseComObject(rItem)

                    ' Raise Event to update progress bar status
                    _Count += 1
                    If _Count Mod 10 = 0 Then RaiseEvent ExportStatus(Me, _OpStep, _Count, _Total)

                Next
                Marshal.ReleaseComObject(rStore)

            Next
            Marshal.ReleaseComObject(rStores)

            ' Complete, update progress bar with total count
            RaiseEvent ExportStatus(Me, _OpStep, _Count, _Total)
            Thread.Sleep(500)

        Catch ex As Exception
            Throw ex

        Finally
            ' Ensure session is logged off and temp profile removed and release memory of com objects
            If rSession.LoggedOn Then rSession.Logoff()
            Marshal.ReleaseComObject(rSession)
            oProfiles.Remove("Export_Prof") 'oProfiles is not a COM object

        End Try

    End Sub

    Private Function export_to_mhtml(ByRef Item As RDOMail, EmailID As String, Subfolder As DirectoryInfo) As String
        ' Save email to destination folder as .mhtml
        ' Handles exception to allow process to continue for all files

        Dim sFileName As String = $"EmailID {EmailID}.mhtml"
        Dim destFile = New FileInfo(Path.Combine(Subfolder.FullName, sFileName))
        'Dim destFile_msg = New FileInfo(Path.ChangeExtension(destFile.FullName, "msg"))

        ' Save email as .mhtml format
        Try
            Item.SaveAs(destFile.FullName, rdoSaveAsType.olMHTML)
            'Item.SaveAs(destFile_msg.FullName, rdoSaveAsType.olMSG)
            Return destFile.FullName

        Catch ex As Exception
            ' Log exception then move on
            Logger.WriteToLog($"An Error occurred with file {destFile.Name}.")
            Logger.WriteToLog(ex.ToString)
            Return Nothing

        End Try

    End Function

    Private Sub export_redacted_files()
        ' Export all redacted files to a new subfolder for each pst file
        ' Throws exception to stop export process

        Dim drRows() As DataRow
        Dim PSTFile As FileInfo
        Dim sFiles As IEnumerable(Of String)
        Dim SubFolder As DirectoryInfo

        Try
            ' Reduce to distinct emails (some emails have multiple exemptions)
            Dim ColsList = {"FilePath", "RFID"}
            _EmailsTable = _EmailsTable.DefaultView.ToTable(distinct:=True, ColsList)
            _Total = _EmailsTable.Rows.Count
            RaiseEvent ExportStatus(Me, _OpStep, _Count, _Total)

            ' Iterate over unique files, connect to each file only once
            sFiles = _EmailsTable.AsEnumerable().Select(Function(row) row.Field(Of String)("FilePath")).Distinct()

            For Each sFile As String In sFiles

                ' Create subfolder for each pst file
                ' TODO: ensure subfolder name is unique
                PSTFile = New FileInfo(sFile)
                SubFolder = New DirectoryInfo(Path.Combine(_EmailFolder.FullName, PSTFile.Name))
                SubFolder.Create()

                ' Get collection of Redacted File id's for the current pst file
                Dim RFIDList As New List(Of Integer)
                drRows = _EmailsTable.Select($"FilePath='{sFile}'")
                For Each row As DataRow In drRows
                    RFIDList.Add(row("RFID"))
                Next

                ' Export all redacted files to subfolder
                Dim result = export_redacted(RFIDList, SubFolder, False)

                ' Update progress bar
                _Count += RFIDList.Count
                RaiseEvent ExportStatus(Me, _OpStep, _Count, _Total)

            Next

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Public Function export_redact() As FileInfo
        ' Used for redacting a single email

        Dim sEmailID As String = Convert.ToString(_EmailID).Trim()
        Dim RedactedFolder = New DirectoryInfo(Path.Combine(
                                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                                "Themis Redacted Emails"))

        ' Ensure Redacted Email folder exists
        If Not RedactedFolder.Exists Then RedactedFolder.Create()

        Dim sPSTFile = _EmailsTable.Rows()(0)("FilePath")
        Dim sEntryID = _EmailsTable.Rows()(0)("EntryID")
        Dim oPSTFile = New FileInfo(sPSTFile)

        ' Ensure pst file exists
        If Not oPSTFile.Exists Then
            MsgBox($"PST file '{oPSTFile.FullName}' does not exist.")
            Return Nothing
        End If

        ' Redemption Objects
        Dim oProfiles As New OLProfiles
        Dim rSession As New RDOSession
        Dim rStores As RDOStores
        Dim rStore As RDOStore
        Dim rItem As RDOMail

        Try
            ' Initialize Redemption objects
            rSession.Logon(oProfiles.Add("Export_Prof"))
            rStores = rSession.Stores
            rStore = rStores.AddPSTStore(sPSTFile)

            ' Save email
            rItem = rStore.GetMessageFromID(sEntryID)
            Dim TextFile = export_to_mhtml(rItem, sEmailID, RedactedFolder)

            Marshal.ReleaseComObject(rItem)
            Marshal.ReleaseComObject(rStore)
            Marshal.ReleaseComObject(rStores)

            If Not IsNothing(TextFile) AndAlso New FileInfo(TextFile).Exists Then
                Return New FileInfo(TextFile)
            Else
                Return Nothing
            End If

        Catch ex As Exception
            'Throw ex
            Logger.WriteToLog(ex.ToString)
            Return Nothing

        Finally
            ' Ensure session is logged off and temp profile removed and release memory of com objects
            If rSession.LoggedOn Then rSession.Logoff()
            Marshal.ReleaseComObject(rSession)
            oProfiles.Remove("Export_Prof") 'oProfiles is not a COM object

        End Try

    End Function

    Private Sub emailLog()
        ' Create Excel file with email log, save to parent of Email folder
        ' Throws exception to stop export process

        Dim xlApp = New Excel.Application
        Dim wbs As Excel.Workbooks
        Dim wb As Excel.Workbook
        Dim wss As Excel.Sheets
        Dim ws As Excel.Worksheet
        Dim c1 As Excel.Range
        Dim c2 As Excel.Range

        Try
            Dim cols(_EmailsTable.Columns.Count - 4) As String ' exclude last 3 columns + 1 for 0-indexed array
            For c As Integer = 0 To _EmailsTable.Columns.Count - 4
                cols(c) = _EmailsTable.Columns.Item(c).ColumnName
            Next

            Dim arr(_EmailsTable.Rows.Count - 1, cols.Length - 1) As String
            For r As Integer = 0 To _EmailsTable.Rows.Count - 1
                For c As Integer = 0 To cols.Length - 1
                    arr(r, c) = _EmailsTable.Rows.Item(r)(cols(c))
                Next
            Next

            wbs = xlApp.Workbooks
            wb = wbs.Add()
            wss = wb.Worksheets
            ws = wss("Sheet1")
            c1 = ws.Cells(1, 1)
            c2 = ws.Cells(1, cols.Length)
            ws.Range(c1, c2).Value = cols

            c1 = ws.Cells(2, 1)
            c2 = ws.Cells(_EmailsTable.Rows.Count + 1, cols.Length)
            ws.Range(c1, c2).Value = arr

            xlApp.DisplayAlerts = False
            Dim destFile = Path.Combine(_EmailFolder.Parent.FullName, $"{_Type}_Email_Log.xlsx")
            wb.SaveAs(destFile)
            wb.Close(SaveChanges:=False)

            Marshal.ReleaseComObject(wbs)
            Marshal.ReleaseComObject(wb)
            Marshal.ReleaseComObject(wss)
            Marshal.ReleaseComObject(ws)
            Marshal.ReleaseComObject(c1)
            Marshal.ReleaseComObject(c2)
            wbs = Nothing
            wb = Nothing
            wss = Nothing
            ws = Nothing
            c1 = Nothing
            c2 = Nothing

        Catch ex As Exception
            Throw ex

        Finally
            xlApp.Quit()
            Marshal.ReleaseComObject(xlApp)
            xlApp = Nothing

        End Try

    End Sub

    Private Sub export_attachments()
        ' Save all attachment files
        ' Throws exception to stop export process

        Dim iAttachID As Integer

        ' Reduce to distinct attachments (some emails have multiple exemptions)
        Dim ColsList = {"AttachID"}
        _AttachTable = _AttachTable.DefaultView.ToTable(distinct:=True, ColsList)
        _Total = _AttachTable.Rows.Count
        RaiseEvent ExportStatus(Me, _OpStep, _Count, _Total)

        ' Save each attachment to Attachments folder
        For Each row As DataRow In _AttachTable.Rows

            ' Exit if cancelled
            _Token.ThrowIfCancellationRequested()

            ' Save file to Attachments folder
            iAttachID = row("AttachID")
            export_attachment(iAttachID, _AttachFolder.FullName)  'Public.GlobalFunctions

            ' Update progress bar
            _Count += 1
            If _Count Mod 25 = 0 Then RaiseEvent ExportStatus(Me, _OpStep, _Count, _Total)

        Next row

        ' Complete, update progress bar with total count
        RaiseEvent ExportStatus(Me, _OpStep, _Count, _Total)
        Thread.Sleep(500)

    End Sub

    Private Sub attachmentLog()
        ' Create Excel file with attachment log, save to parent of Email folder
        ' Throws exception to stop export process

        Dim xlApp As New Excel.Application
        Dim wbs As Excel.Workbooks
        Dim wb As Excel.Workbook
        Dim wss As Excel.Sheets
        Dim ws As Excel.Worksheet
        Dim c1 As Excel.Range
        Dim c2 As Excel.Range

        Try
            Dim cols(_AttachTable.Columns.Count - 1) As String
            For c As Integer = 0 To _AttachTable.Columns.Count - 1
                cols(c) = _AttachTable.Columns.Item(c).ColumnName
            Next

            Dim arr(_AttachTable.Rows.Count - 1, _AttachTable.Columns.Count - 1) As String
            For r As Integer = 0 To _AttachTable.Rows.Count - 1
                For c As Integer = 0 To _AttachTable.Columns.Count - 1
                    arr(r, c) = _AttachTable.Rows.Item(r)(c)
                Next
            Next

            wbs = xlApp.Workbooks
            wb = wbs.Add()
            wss = wb.Worksheets
            ws = wss("Sheet1")
            c1 = ws.Cells(1, 1)
            c2 = ws.Cells(1, _AttachTable.Columns.Count)
            ws.Range(c1, c2).Value = cols

            c1 = ws.Cells(2, 1)
            c2 = ws.Cells(_AttachTable.Rows.Count + 1, _AttachTable.Columns.Count)
            ws.Range(c1, c2).Value = arr

            wb.SaveAs(Path.Combine(_AttachFolder.Parent.FullName, $"{_Type}_Attachment_Log.xlsx"))
            wb.Close()

            Marshal.ReleaseComObject(wbs)
            Marshal.ReleaseComObject(wb)
            Marshal.ReleaseComObject(wss)
            Marshal.ReleaseComObject(ws)
            Marshal.ReleaseComObject(c1)
            Marshal.ReleaseComObject(c2)
            wbs = Nothing
            wb = Nothing
            wss = Nothing
            ws = Nothing
            c1 = Nothing
            c2 = Nothing

        Catch ex As Exception
            Throw ex

        Finally
            xlApp.Quit()
            Marshal.ReleaseComObject(xlApp)
            xlApp = Nothing

        End Try

    End Sub

End Class

Public Class Converter
    ' Used by Worker Progress form to convert mhtml files to a merged and locked pdf

    Public Event ConvertStatus(sender As Object, Count As Integer, Total As Integer, Folder As String,
                               OpStep As String, WorkerId As Integer)

    Private _WorkerId As Integer
    Private _Token As CancellationToken

    Private _EmailFolder As DirectoryInfo
    Private _Type As String
    Private _Count As Integer = 0
    Private _Total As Integer = 0
    Private _OpStep As String

    Public WriteOnly Property Folder As DirectoryInfo
        Set(value As DirectoryInfo)
            _EmailFolder = value
            _Type = _EmailFolder.Parent.Parent.Name
        End Set
    End Property
    Public ReadOnly Property WorkerId As Integer
        Get
            Return _WorkerId
        End Get
    End Property
    Public ReadOnly Property Count As Integer
        Get
            Return _Count
        End Get
    End Property
    Public ReadOnly Property Total As Integer
        Get
            Return _Total
        End Get
    End Property

    Public Sub New(WorkerId As Integer, ByRef Token As CancellationToken)

        ' Set license key to use GemBox.Pdf
        ComponentInfo.SetLicense("AN-2022Oct01-KJHIXdjmmz5cppAq/DFZhOLbzHMSEG5CgxaeIjmjT6NTcWdAm95IDVLTaUz5YbCkjp0r4tE2evwYLBS1NlLuO6ddAoA==A")

        ' Set class variables
        _WorkerId = WorkerId
        _Token = Token

    End Sub

    Public Sub New()
        ' Used for converting a single email for redaction

    End Sub

    Public Function convert_to_pdf() As Dictionary(Of String, Object)
        ' Convert all mhtml files in current subfolder to pdf then merge all pdf files

        ' Initialize
        Dim Result = New Dictionary(Of String, Object) From {
            {"Cancelled", False},
            {"OpError", Nothing}
            }
        _Count = 0
        _Total = 0

        Try
            ' Step 1: Convert mhtml file to pdf
            If _Type <> "Redaction" Then
                _OpStep = "Converting mhtml to pdf"
                mhtml_to_pdf_loop()
            End If

            ' Initialize progress bar
            _OpStep = "Merging pdf files"
            _Count = 0
            _Total = 0
            RaiseEvent ConvertStatus(Me, _Count, _Total, _EmailFolder.Name, _OpStep, _WorkerId)

            ' Step 2: Merge pdf files
            merge_pdfs_loop()

            _OpStep = "Folder Complete"
            RaiseEvent ConvertStatus(Me, _Count, _Total, _EmailFolder.Name, _OpStep, _WorkerId)

        Catch ex As OperationCanceledException
            Result("Cancelled") = True

        Catch ex As Exception
            ' Exception logged by Parent
            Logger.WriteToLog($"An error occurred in Worker({_WorkerId}) on folder {_EmailFolder.Name}")
            Result("OpError") = ex

        End Try

        Return Result

    End Function

    Private Sub mhtml_to_pdf_loop()
        ' Loop over each mhtml file in source folder and convert to pdf
        ' Throws exception to stop convert process

        Dim fEmails As List(Of FileInfo)
        Dim wApp = New Word.Application

        Try
            ' Get all non-temporary pdf files
            fEmails = _EmailFolder.GetFiles("*.mhtml").Where(Function(f) Not f.Name.StartsWith("~$")).ToList

            ' Loop 
            _Count = 0
            _Total = fEmails.Count
            For Each SourceFile In fEmails

                ' Exit if cancelled
                _Token.ThrowIfCancellationRequested()

                ' Open file in Word then save as pdf
                mhtml_to_pdf_doc(SourceFile, wApp)

                ' Update progress bar
                _Count += 1
                RaiseEvent ConvertStatus(Me, _Count, _Total, _EmailFolder.Name, _OpStep, _WorkerId)

            Next

        Catch ex As Exception
            Throw ex

        Finally
            wApp.Quit()
            Marshal.ReleaseComObject(wApp)

        End Try

    End Sub

    Private Sub mhtml_to_pdf_doc(SourceFile As FileInfo, ByRef wApp As Word.Application, Optional WithOpen As Boolean = False)
        ' Open source file in Word, save as pdf, and close file
        ' Throws exception to stop convert process

        Dim sDestFile As String
        Dim wDocs As Word.Documents
        Dim wDoc As Word.Document
        Dim iCounter As Integer
        Dim bContinue As Boolean
        Dim iLimit As Integer = 100

        ' Define destination file
        sDestFile = Path.ChangeExtension(SourceFile.FullName, "pdf")

        ' Open source file
        wDocs = wApp.Documents
        wDoc = wDocs.Open(SourceFile.FullName)

        Try
            ' Wait for file to open, error if number of tries exceeds limit
            Thread.Sleep(5)
            iCounter = 0
            bContinue = False
            Do While Not bContinue
                Try
                    iCounter += 1
                    If iCounter > iLimit Then Throw New FileLoadException("Word Document Failed to Open", SourceFile.Name)

                    wDoc.Activate()
                    bContinue = True

                Catch ex As COMException
                    Debug.WriteLine("Document Open COMException")
                    Thread.Sleep(1)

                End Try
            Loop

            ' Format Word doc before exporting pdf
            '  > Set background to remove any images in mhtml file
            With wDoc.Background.Fill
                .Solid()
                .ForeColor.RGB = RGB(255, 255, 255) ' white
            End With
            '  > Set page layout
            With wDoc.PageSetup
                .Orientation = Word.WdOrientation.wdOrientLandscape
                .PaperSize = Word.WdPaperSize.wdPaperLetter
                .LeftMargin = wApp.InchesToPoints(0.5)
                .RightMargin = wApp.InchesToPoints(0.5)
                .TopMargin = wApp.InchesToPoints(0.5)
                .BottomMargin = wApp.InchesToPoints(0.5)
            End With

            ' Wait for file to save, error if number of tries exceeds limit
            Thread.Sleep(5)
            iCounter = 0
            bContinue = False
            Do While Not bContinue
                Try
                    iCounter += 1
                    If iCounter > iLimit Then Throw New FileLoadException("Word Document Failed to Save", SourceFile.Name)

                    wDoc.ExportAsFixedFormat(
                        OutputFileName:=sDestFile,
                        ExportFormat:=Word.WdExportFormat.wdExportFormatPDF,
                        OpenAfterExport:=WithOpen,
                        OptimizeFor:=Word.WdExportOptimizeFor.wdExportOptimizeForPrint,
                        Range:=Word.WdExportRange.wdExportAllDocument,
                        From:=0,
                        To:=0,
                        Item:=Word.WdExportItem.wdExportDocumentContent,
                        IncludeDocProps:=False,
                        KeepIRM:=False,
                        CreateBookmarks:=Word.WdExportCreateBookmarks.wdExportCreateNoBookmarks,
                        DocStructureTags:=False,
                        BitmapMissingFonts:=True,
                        UseISO19005_1:=False)

                    bContinue = True

                Catch ex As COMException
                    Debug.WriteLine("Document Save COMException")
                    Thread.Sleep(1)

                End Try
            Loop

            ' Wait for file to close, error if number of tries exceeds limit
            Thread.Sleep(5)
            iCounter = 0
            bContinue = False
            Do While Not bContinue
                Try
                    iCounter += 1
                    If iCounter > iLimit Then Throw New FileLoadException("Word Document Failed to Close", SourceFile.Name)

                    If Not IsNothing(wDoc) Then wDoc.Close(Word.WdSaveOptions.wdDoNotSaveChanges)
                    bContinue = True

                Catch ex As COMException
                    Debug.WriteLine("Document Close COMException")
                    Thread.Sleep(1)

                End Try
            Loop

        Catch ex As FileLoadException
            Logger.WriteToLog($"{ex.FileName} > {ex.Message}")
            Throw ex

        Catch ex As Exception
            Throw ex

        Finally
            Marshal.ReleaseComObject(wDocs)
            Marshal.ReleaseComObject(wDoc)

        End Try

    End Sub

    Private Sub merge_pdfs_loop()
        ' Loop over each pdf file in current subfolder and combine into a single 'locked' pdf
        ' Throws exception to stop convert process

        Dim DestFile As PdfDocument
        Dim Emails As List(Of FileInfo)
        Dim DestFolder As DirectoryInfo
        Dim DestFileName As String = ""

        ' Get all non-temporary pdf files
        Emails = _EmailFolder.GetFiles("*.pdf").Where(Function(f) Not f.Name.StartsWith("~$")).ToList

        ' Define destination file
        DestFolder = _EmailFolder.Parent
        DestFileName = Path.Combine(DestFolder.FullName, $"{_EmailFolder.Name}.pdf")

        ' New pdf file
        DestFile = New PdfDocument

        ' Loop 
        _Count = 0
        _Total = Emails.Count
        For Each SourceFile In Emails

            ' Exit if cancelled
            _Token.ThrowIfCancellationRequested()

            ' Add image of each page of current pdf file to destination file
            merge_pdfs_doc(SourceFile, DestFile)

            ' Update progress bar
            _Count += 1
            RaiseEvent ConvertStatus(Me, _Count, _Total, _EmailFolder.Name, _OpStep, _WorkerId)

        Next

        ' Save new pdf to root folder
        DestFile.Info.Clear()
        DestFile.SaveOptions.UpdateProducerInformation = False
        DestFile.Save(DestFileName)
        DestFile.Dispose()

    End Sub

    Public Sub merge_pdfs_doc(SourceFile As FileInfo, ByRef DestFile As PdfDocument)
        ' Loop over all pages in source file, convert to png, and add to new page in destination file
        ' Throws exception to stop convert process

        Dim srcDoc As PdfDocument
        Dim destpage As PdfPage
        Dim pdfImage As PdfImage
        Dim options As ImageSaveOptions
        Dim transform As PdfMatrix
        Dim sTempFile As String

        ' Initialize loop variables
        srcDoc = PdfDocument.Load(SourceFile.FullName)
        options = New ImageSaveOptions With {
                            .Format = ImageSaveFormat.Png
                            }

        ' Name of temporary .png file used by current Worker
        sTempFile = Path.Combine(New DirectoryInfo(Path.GetTempPath).FullName, $"pdf_page_Worker({_WorkerId}).png")

        ' Loop
        For Each page As PdfPage In srcDoc.Pages

            ' Exit if cancelled
            _Token.ThrowIfCancellationRequested()

            ' Create temp pdf doc from current page and export png file to temp folder
            With New PdfDocument
                .Pages.Kids.AddClone(page)
                .Save(sTempFile, options)
            End With

            'load the saved png file
            pdfImage = PdfImage.Load(sTempFile)

            ' The steps below add a new page in landscape format to the final pdf document 
            destpage = DestFile.Pages.Add()
            ' Initialize transform object
            transform = PdfMatrix.Identity
            ' Set the image origin (bottom-left corner) to bottom-right of page
            transform.Translate(destpage.Size.Width, 0)
            ' Set the image size for landscape format
            transform.Scale(destpage.Size.Width, destpage.Size.Height)
            ' Rotate image 90 degrees counterclockwise
            transform.Rotate(90)
            ' Draw image
            destpage.Content.DrawImage(pdfImage, transform)
            ' Rotate page 90 degrees clockwise
            destpage.Rotate = 90

        Next

        srcDoc.Dispose()

    End Sub

    Public Sub convert_redact(SourceFile As FileInfo)
        ' Convert a single text file to pdf and open in Adobe for redacting

        Dim PdfFile = New FileInfo(Path.ChangeExtension(SourceFile.FullName, "pdf"))

        ' Ensure pdf file is not open
        While PdfFile.Exists AndAlso IsFileOpen(PdfFile)
            Dim result = MsgBox($"File '{PdfFile.FullName}' is open in another program, please close the file and click OK.",
                    vbOKCancel, "Invalid Operation")
            If result <> MsgBoxResult.Ok Then
                SourceFile.Delete()
                Exit Sub
            End If
        End While

        Dim wApp = New Word.Application

        Try
            ' Open file in Word then save as pdf
            mhtml_to_pdf_doc(SourceFile, wApp, True)
            SourceFile.Delete()

        Catch ex As Exception
            Throw New Exception("Failed to Convet to PDF", ex)

        Finally
            wApp.Quit()
            Marshal.ReleaseComObject(wApp)

        End Try

    End Sub

    Private Function IsFileOpen(file As FileInfo) As Boolean
        ' Test if file is already open by attempting to open it with filestream

        Dim stream As FileStream

        Try
            stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None)
            stream.Close()
            Return False

        Catch ex As Exception
            Return True

        End Try

    End Function

End Class
