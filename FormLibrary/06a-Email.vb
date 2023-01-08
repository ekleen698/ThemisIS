Imports ClassLibrary.GlobalObjects
Imports ClassLibrary.GlobalFunctions
Imports System.Windows.Forms
Imports System.IO
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports Microsoft.Office.Interop

Public Class frmEmail
    Private _dtEmailID As New DataTable
    Private _bsEmailID As New BindingSource
    Private _dtEmail As New DataTable
    Private _dtAttachments As New DataTable
    Private _iRows As Integer = 0
    Private _iTopOffset As Integer
    Private _iLeftOffset As Integer
    Private _cBackcolor As Drawing.Color
    Private _cColor As Drawing.Color
    Private _Boxes As RichTextBox()
    Private _ScaleFactor As Single

    Public Sub New(Optional iTopOffset As Integer = 0, Optional iLeftOffset As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Create scale factor because value of 'AutoScaleDimensions' changes with screen resolution
        _ScaleFactor = Me.CurrentAutoScaleDimensions.Width / 96

        'Initialize class properties
        _iTopOffset = Convert.ToInt32(iTopOffset * _ScaleFactor)
        _iLeftOffset = Convert.ToInt32(iLeftOffset * _ScaleFactor)

    End Sub

    Private Sub frmEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim sSQL As String

        Try
            ' Set form properties
            Me.Text = $"Selected Emails"
            Me.Top += _iTopOffset
            Me.Left += _iLeftOffset
            Me.MinimumSize = Me.Size

            ' TODO: Resize info icon
            'Me.picInfo.Width = Convert.ToInt32(24 * _ScaleFactor)
            'Me.picInfo.Height = Convert.ToInt32(24 * _ScaleFactor)

            ' Hide border on top layer Find text box, 2 layers used to simulate padding
            Me.txtFind.BorderStyle = BorderStyle.None

            ' Initialize checkbox to disabled, status is updated by updateForm()
            Me.chkFlag.Enabled = False

            ' Add columns to Attachments datatable
            _dtAttachments.Columns.Add("FileName", GetType(String))
            _dtAttachments.Columns.Add("FileExt", GetType(String))
            _dtAttachments.Columns.Add("Status", GetType(String))
            _dtAttachments.Columns.Add("EmailID", GetType(Integer))
            _dtAttachments.Columns.Add("ID", GetType(Integer))
            _dtAttachments.Columns.Add("OLType", GetType(String))

            ' Initialize Attachments dgv
            Dim h As Integer = Convert.ToInt32(20 * _ScaleFactor)
            With Me.dgvAttachments
                .DataSource = _dtAttachments
                .ColumnHeadersHeight = h
                .RowTemplate.Height = h
                .Columns("FileName").Width = Convert.ToInt32(300 * _ScaleFactor)
                .Columns("FileExt").Width = Convert.ToInt32(50 * _ScaleFactor)
                .Columns("Status").Width = Convert.ToInt32(77 * _ScaleFactor)
                .Columns("ID").Visible = False
                .Columns("OLType").Visible = False
            End With

            ' Store default colors, used to reset after highlight operations
            _cBackcolor = Me.txtBody.BackColor
            _cColor = Me.txtBody.ForeColor

            ' List of RichTextBoxes
            _Boxes = {Me.txtFrom, Me.txtFromName, Me.txtTo, Me.txtToName, Me.txtCC, Me.txtBCC, Me.txtSubject, Me.txtBody}

            ' Get EmailID data from source, sent date used for sorting id's
            sSQL = $"
                SELECT de.EmailID, de.SentOn 
                FROM dbo.DisplayEmailIDs de;"
            With New SqlDataAdapter(sSQL, CurrProjDB.Connection)
                .Fill(_dtEmailID)
            End With

            ' Sort id's by sent date (oldest to newest), add data to form BindingSource
            '  and update the form to display the first email
            _dtEmailID.DefaultView.Sort = "SentOn ASC"
            _bsEmailID.DataSource = _dtEmailID.DefaultView
            _iRows = _dtEmailID.Rows.Count
            updateForm()

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Form Open Error")
            Logger.WriteToLog($"{ex.GetType} occurred while loading Email Display form.")
            Logger.WriteToLog(ex.ToString)

        End Try

    End Sub

    Private Sub frmEmail_Shown(sender As Object, e As EventArgs) Handles Me.Shown



    End Sub

    Private Sub frmEmail_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Clean up class objects

        Try
            _dtEmailID.Dispose()
            _bsEmailID.Dispose()
            _dtAttachments.Dispose()
            _dtEmail.Dispose()

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Form Close Error")
            Logger.WriteToLog($"{ex.GetType} occurred while closing Email Display form.")
            Logger.WriteToLog(ex.ToString)

        End Try

    End Sub

    Private Sub frmEmail_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ' Hotkeys

        If e.Control AndAlso e.KeyCode = Keys.P Then
            cmdProduce.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.N Then
            cmdNonResponsive.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.E Then
            cmdExempt.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.R Then
            cmdRedact.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.X Then
            cmdReset.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.O Then
            cmdOutlook.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.A Then
            cmdAttachments.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.M Then
            cmdMarkAsEmail.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.F Then
            chkFlag.Checked = Not chkFlag.Checked
            chkFlag_Click(Me, New EventArgs)
        ElseIf e.Control AndAlso (e.KeyCode = Keys.OemPeriod Or e.KeyCode = Keys.Right) Then
            cmdNext.PerformClick()
        ElseIf e.Control AndAlso (e.KeyCode = Keys.Oemcomma Or e.KeyCode = Keys.Left) Then
            cmdPrevious.PerformClick()
        End If

    End Sub

    Private Sub cmdFind_Click(sender As Object, e As EventArgs) Handles cmdFind.Click
        ' Finds text in the message body and highlights it

        Dim Phrase = Me.txtFind.Text.Trim()
        Dim Phrases As New List(Of String) From {Phrase}
        Dim Result As Boolean

        ' Exit if no text is entered
        If Phrase.Length = 0 Then
            MsgBox("First enter text to find.", vbOKOnly, "Invalid Operation")
            Exit Sub
        End If

        ' Search for phrase in all text boxes, highlight if found
        Result = highlight(Phrases, RichTextBoxFinds.None, Drawing.Color.Red, Drawing.Color.Yellow)

        ' Message if nothing found
        If Not Result Then
            MsgBox("Text not found.", vbOKOnly, "Find Result")
        End If

    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        ' Reset Find text box value and Body text box formatting

        Me.txtFind.Text = ""
        clear_highlight()

    End Sub

    Private Sub cmdNext_Click(sender As Object, e As EventArgs) Handles cmdNext.Click
        'Move to next record of bindingsource object and refresh form textbox objects
        _bsEmailID.MoveNext()
        updateForm()

        ' Scroll to top of box
        With Me.txtBody
            .SelectionStart = 0
            .SelectionLength = 1
            .ScrollToCaret()
            .DeselectAll()
        End With

        ' If Find box not blank, highlight search term
        If Me.txtFind.Text.Trim() <> "" Then
            Me.cmdFind.PerformClick()
        End If

    End Sub

    Private Sub cmdPrevious_Click(sender As Object, e As EventArgs) Handles cmdPrevious.Click
        'Move to previous record of bindingsource object and refresh form textbox objects
        _bsEmailID.MovePrevious()
        updateForm()

        ' Scroll to top of box
        With Me.txtBody
            .SelectionStart = 0
            .SelectionLength = 1
            .ScrollToCaret()
            .DeselectAll()
        End With

        ' If Find box not blank, highlight search term
        If Me.txtFind.Text.Trim() <> "" Then
            Me.cmdFind.PerformClick()
        End If

    End Sub

    Private Sub cmdAttachments_Click(sender As Object, e As EventArgs) Handles cmdAttachments.Click
        'Opens Attachment Review form for all attachments other than msg files.

        Try
            With New frmAttachments(_dtEmail.Rows(0).Item("EmailID"))
                .ShowDialog(Me)
            End With

            updateForm()

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Form Open Error")

        End Try

    End Sub

    Private Sub cmdMarkAsEmail_Click(sender As Object, e As EventArgs) Handles cmdMarkAsEmail.Click

        Dim sSQL As String
        Dim iEmailID As Integer = _dtEmail(0)("EmailID")
        Dim sStatus = _dtEmail(0)("Email_Status")
        Dim dt As New DataTable

        Try
            If sStatus = "Unreviewed" Then
                ' If email unreviewed, delete any existing rows
                With CurrProjDB.Connection.CreateCommand()
                    .CommandText = "
                    DELETE [AttachExemptStatus]
                    WHERE [AttachID] IN (
                        SELECT [ID] FROM [Attachments] WHERE [EmailID] = @EmailID
                        );"
                    .Parameters.Add("@EmailID", SqlDbType.Int).Value = iEmailID
                    .ExecuteNonQuery()
                End With

            Else
                ' Get all exemptions for current email
                sSQL = "
                    SELECT ExemptionID [ID], [Description] 
                    FROM dbo.EmailExemptStatus
                    WHERE EmailID=@EmailID;"
                With New SqlDataAdapter(sSQL, CurrProjDB.Connection)
                    .SelectCommand.Parameters.Add("@EmailID", SqlDbType.Int).Value = iEmailID
                    .Fill(dt)
                End With

                ' Add exemptions to each attachment, sp first deletes existing rows
                With CurrProjDB.Connection.CreateCommand
                    .CommandText = "EXEC dbo.fAttachExemption @AttachID, @Exemptions;"
                    .Parameters.Add("@AttachID", SqlDbType.Int)
                    .Parameters.Add("@Exemptions", SqlDbType.Structured).Value = dt
                    .Parameters("@Exemptions").TypeName = "TVP"

                    For Each row As DataRow In _dtAttachments.Rows
                        .Parameters("@AttachID").Value = row("ID")
                        .ExecuteNonQuery()
                    Next

                End With

            End If

            updateForm()

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Attachment Status Update Error")
            Logger.WriteToLog($"{ex.GetType} occurred while marking attachements for EmailID={iEmailID}.")
            Logger.WriteToLog(ex.ToString)

        End Try

    End Sub

    Private Sub chkFlag_Click(sender As Object, e As EventArgs) Handles chkFlag.Click

        Dim sComment = ""
        Dim iEmailID As Integer = _dtEmail.Rows(0).Item("EmailID")

        Try
            If chkFlag.Checked Then
                Dim result As Integer = 0
                With New frmInput("Flag Comment", "Enter comment for flag or click OK to leave blank")
                    result = .ShowDialog()
                    If result = DialogResult.OK Then
                        sComment = .Comment
                    ElseIf result = DialogResult.Cancel Then
                        Me.chkFlag.Checked = False
                        Exit Sub
                    End If
                End With
            End If

            ' Set Flag value based on checkbox
            With CurrProjDB.Connection.CreateCommand
                .CommandText = "
                    UPDATE dbo.EmailExemptStatus
                    SET Flag=@Flag, FlagComment=@Comment
                    WHERE EmailID=@EmailID;"
                .Parameters.Add("@EmailID", SqlDbType.Int).Value = iEmailID
                .Parameters.Add("@Flag", SqlDbType.Bit).Value = Me.chkFlag.Checked
                .Parameters.Add("@Comment", SqlDbType.VarChar).Value = sComment
                .ExecuteNonQuery()
            End With

            updateForm()

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Review Flag Update Error")
            Logger.WriteToLog($"{ex.GetType} occurred while setting flag for EmailID={iEmailID}.")
            Logger.WriteToLog(ex.ToString)

        End Try

    End Sub

    Private Sub cmdProduce_Click(sender As Object, e As EventArgs) Handles cmdProduce.Click

        Dim iEmailID As Integer = _dtEmail.Rows(0).Item("EmailID")

        'Ensure current email doesn't have an exemption status set
        If _dtEmail.Rows(0).Item("Email_Status") <> "Unreviewed" Then Exit Sub

        ' Create parameters table
        Dim dt As New DataTable
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Description", GetType(String))
        dt.Rows.Add({-1, "No exemptions identified."})

        Try
            ' Delete existing and insert new row(s) into dbo.EmailExemptStatus for current EmailID
            With CurrProjDB.Connection.CreateCommand
                .CommandText = "EXEC dbo.fEmailExemption @EmailID, @Exemptions;"
                .Parameters.Add("@EmailID", SqlDbType.Int).Value = iEmailID
                .Parameters.Add("@Exemptions", SqlDbType.Structured).Value = dt
                .Parameters("@Exemptions").TypeName = "TVP"
                .ExecuteNonQuery()
            End With

            'Refresh form to update formatting of 'Produce' button
            updateForm()

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Email Status Update Error")

        End Try

    End Sub

    Private Sub cmdNonResponsive_Click(sender As Object, e As EventArgs) Handles cmdNonResponsive.Click

        Dim iEmailID As Integer = _dtEmail.Rows(0).Item("EmailID")

        'Ensure current email doesn't have an exemption status set
        If _dtEmail.Rows(0).Item("Email_Status") <> "Unreviewed" Then Exit Sub

        ' Create parameters table
        Dim dt As New DataTable
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Description", GetType(String))
        dt.Rows.Add({0, "Not applicable to this matter."})

        Try
            ' Delete existing and insert new row(s) into dbo.EmailExemptStatus for current EmailID
            With CurrProjDB.Connection.CreateCommand
                .CommandText = "EXEC dbo.fEmailExemption @EmailID, @Exemptions;"
                .Parameters.Add("@EmailID", SqlDbType.Int).Value = iEmailID
                .Parameters.Add("@Exemptions", SqlDbType.Structured).Value = dt
                .Parameters("@Exemptions").TypeName = "TVP"
                .ExecuteNonQuery()
            End With

            'Refresh form to update formatting of 'Non-Responsive' button
            updateForm()

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Email Status Update Error")

        End Try

    End Sub

    Private Sub cmdExempt_Click(sender As Object, e As EventArgs) Handles cmdExempt.Click
        'Open Exempt status form for current email in 'Exemption'

        Dim iEmailID As Integer = _dtEmail.Rows()(0)("EmailID")
        Dim sStatus = _dtEmail.Rows()(0)("Email_Status")

        Try
            'Exit if email status not 'Exemption' or 'Unreviewed'
            If New List(Of String) From {"Unreviewed", "Exemption"}.Contains(sStatus) Then
                'Create new exemption(s) for current email
                With New frmEmailExemption("Exemption", iEmailID)
                    .ShowDialog(Me)
                End With

                'Refresh form to update formatting of 'Exempt' button
                updateForm()
            End If

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Email Status Update Error")

        End Try

    End Sub

    Private Sub cmdRedact_Click(sender As Object, e As EventArgs) Handles cmdRedact.Click
        'Open Exempt Status form for current email in 'Redaction' mode

        Dim iEmailID As Integer = _dtEmail.Rows(0).Item("EmailID")
        Dim sOrigStatus = _dtEmail.Rows()(0)("Email_Status")

        Try
            'Exit if email status not 'Exemption' or 'Unreviewed'
            If {"Unreviewed", "Redaction"}.Contains(sOrigStatus) Then
                'Create new exemption(s) for current email
                With New frmEmailExemption("Redaction", iEmailID)
                    .ShowDialog(Me)
                End With

                'Refresh form to update formatting of 'Exempt' button
                updateForm()

                ' Export email, convert to pdf, and then open in Adobe for redacting
                Dim sNewStatus As String = _dtEmail.Rows()(0)("Email_Status")
                If sNewStatus <> "Redaction" Then Exit Sub

                Dim result As MsgBoxResult = MsgBoxResult.No
                If sOrigStatus = "Redaction" Then
                    ' TODO: replace this with a check for a redacted pdf file in the database
                    result = MsgBox("Create pdf?", vbYesNo, "Confirm")
                ElseIf sOrigStatus = "Unreviewed" Then
                    result = MsgBoxResult.Yes
                End If

                If result = MsgBoxResult.Yes Then

                    Me.Cursor = Cursors.WaitCursor

                    ' Export email to text file
                    Dim oExporter = New Exporter(iEmailID)
                    Dim TextFile = oExporter.export_redact()
                    If IsNothing(TextFile) Then Exit Sub

                    ' Convert text file to pdf and open Adobe
                    Dim oConverter = New Converter
                    oConverter.convert_redact(TextFile)

                End If

            End If

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Email Status Update Error")

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub cmdReset_Click(sender As Object, e As EventArgs) Handles cmdReset.Click

        Dim iEmailID As Integer = _dtEmail.Rows(0).Item("EmailID")

        'Exit if not marked either reviewed
        If _dtEmail.Rows(0).Item("Email_Status") = "Unreviewed" Then Exit Sub

        'Exit if cancelled by user
        If MsgBox("Reset status for this email and all attachments?", MsgBoxStyle.YesNo,
                      "Confirm Reset") = MsgBoxResult.No Then
            Exit Sub
        End If

        Try
            'Delete all email and attachments reviews for current email
            ' TODO: Change to store procedure
            With CurrProjDB.Connection.CreateCommand
                .CommandText = "DELETE FROM dbo.[EmailExemptStatus] WHERE [EmailID]=@EmailID;
                    DELETE [AttachExemptStatus]
                    WHERE [AttachID] IN 
                        (SELECT [ID] FROM [Attachments] WHERE [EmailID] = @EmailID);"
                .Parameters.Add("@EmailID", SqlDbType.Int).Value = iEmailID
                .ExecuteNonQuery()
            End With

            'Refresh form for current email
            updateForm()

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Exempt Status Reset Error")
            Logger.WriteToLog($"{ex.GetType} occurred while resetting Exempt Status for EmailID={iEmailID}.")
            Logger.WriteToLog(ex.ToString)

        End Try

    End Sub

    Private Sub cmdOutlook_Click(sender As Object, e As EventArgs) Handles cmdOutlook.Click
        'Open current email in new Outlook application

        Dim ol As New Outlook.Application
        Dim olns As Outlook.NameSpace = Nothing
        Dim ols As Outlook.Store = Nothing
        Dim olm As Outlook.MailItem = Nothing
        Dim oRdr As SqlDataReader
        Dim sFilePath As String
        Dim sEntryID As String
        Dim sParent As String
        Dim iEmailID As Integer = _dtEmail.Rows(0).Item("EmailID")

        Try
            'Get file and email info from project database
            With CurrProjDB.Connection.CreateCommand
                .CommandText = $"
                    SELECT f.[FilePath], ib.[EntryID], ib.[Parent]
                    FROM dbo.[Files] f
                    INNER JOIN dbo.[Inbox] ib ON f.[ID] = ib.[FileID]
                    WHERE ib.[EmailID] = @EmailID;"
                .Parameters.Add("@EmailID", SqlDbType.Int).Value = iEmailID
                oRdr = .ExecuteReader
            End With

            'Store values and close Reader
            oRdr.Read()
            sFilePath = oRdr.GetSqlString(0).Value
            sEntryID = oRdr.GetSqlString(1).Value
            sParent = oRdr.GetSqlString(2).Value
            oRdr.Close()

            If sEntryID = "Embedded" Then
                'Embedded messages have no EntryID and can only be opened from parent email
                MsgBox($"Message is an attachment to EmailID {sParent}.{vbCrLf}" +
                    "To view in Outlook, open parent email in Outlook then select attachment.")

            Else
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

            End If

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Open in Outlook Error")

        Finally
            olm = Nothing
            ols = Nothing
            olns = Nothing
            ol = Nothing

        End Try

    End Sub

    Private Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        ' Export Redacted pdf from database for current email

        Dim iRFID As Integer = _dtEmail.Rows(0)("RFID")
        Dim RFIDList = New List(Of Integer) From {iRFID}

        ' Export redacted file from database
        export_redacted(RFIDList)   ' Global Function

    End Sub

    Private Sub dgvAttachments_CellDoubleClick(sender As Object,
                e As DataGridViewCellEventArgs) Handles dgvAttachments.CellDoubleClick
        'Opens attachment as a temporary file

        Dim iEmailID As Integer = _dtEmail.Rows(0).Item("EmailID")
        Dim iAttachID As Integer
        Dim sExportFile As String

        Try
            'Export attachment file to current user's temp folder and open file
            iAttachID = Convert.ToInt32(dgvAttachments.Rows(e.RowIndex).Cells("ID").Value)
            sExportFile = export_attachment(iAttachID, Path.GetTempPath)
            Process.Start($"{Path.GetTempPath}\{sExportFile}")

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Open Attachment Error")

        End Try

    End Sub

    Private Sub updateForm()
        'Update all form textbox objects from bindingsource object
        'Handles exceptions

        Dim sSQL As String
        Dim row As DataRowView = _bsEmailID.Current

        Try
            'Clear email DataTable and fill with values for current EmailID in form BindingSource
            _dtEmail.Clear()
            sSQL = $"
                SELECT TOP 1 ib.*, ISNULL(ty.[Exemption_Type],'Unreviewed') [Email_Status]
                    , ISNULL(es.Flag,0) [Flag], ISNULL(es.FlagComment, '') [FlagComment]
	                , ISNULL(rf.ID,0) [RFID]
                FROM Inbox ib
                LEFT JOIN (
	                SELECT t1.[EmailID], t1.Flag, t1.FlagComment, MAX(t2.[TypeID]) maxid
	                FROM dbo.[EmailExemptStatus] t1
	                INNER JOIN dbo.[sys_Exemptions] t2 ON t1.[ExemptionID]=t2.[ID]
	                GROUP BY t1.[EmailID], t1.Flag, t1.FlagComment ) AS es ON ib.[EmailID]=es.[EmailID]
                LEFT JOIN dbo.[sys_ExemptionTypes] ty ON es.[maxid]=ty.[ID]
                LEFT JOIN dbo.[vRedactedFiles] rf ON ib.EmailID=rf.EmailID
                WHERE ib.[EmailID]=@EmailID
                ORDER BY ib.EmailID, ISNULL(es.Flag,0) DESC;"
            With New SqlDataAdapter(sSQL, CurrProjDB.Connection)
                .SelectCommand.Parameters.Add("@EmailID", SqlDbType.Int).Value = row("EmailID")
                .Fill(_dtEmail)
            End With

            'Set textbox values from email DataTable
            Me.txtSentOn.Text = _dtEmail.Rows(0).Item("SentOn").ToString
            Me.txtFromName.Text = _dtEmail.Rows(0).Item("SenderName").ToString
            Me.txtFrom.Text = _dtEmail.Rows(0).Item("Sender").ToString
            Me.txtToName.Text = _dtEmail.Rows(0).Item("To_Name").ToString
            Me.txtTo.Text = _dtEmail.Rows(0).Item("To").ToString
            Me.txtCC.Text = _dtEmail.Rows(0).Item("CC").ToString
            Me.txtBCC.Text = _dtEmail.Rows(0).Item("BCC").ToString
            Me.txtSubject.Text = _dtEmail.Rows(0).Item("Subject").ToString
            Me.txtBody.Text = _dtEmail.Rows(0).Item("Body").ToString
            Me.txtFlag.Text = _dtEmail.Rows()(0)("FlagComment").ToString

            'Update Email ID and count labels
            Me.lblEmailID.Text = $"EmailID {_dtEmail.Rows(0).Item("EmailID").ToString}"
            Me.lblNumEmails.Text = $"{_bsEmailID.Position + 1} of {_iRows} Email(s)"

            ' Update Flag checkbox
            Me.chkFlag.Checked = CBool(_dtEmail.Rows(0).Item("Flag").ToString)

            'Set all button colors to default settings
            Me.cmdProduce.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
            Me.cmdProduce.FlatAppearance.MouseOverBackColor = Drawing.Color.Gainsboro
            Me.cmdNonResponsive.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
            Me.cmdNonResponsive.FlatAppearance.MouseOverBackColor = Drawing.Color.Gainsboro
            Me.cmdExempt.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
            Me.cmdExempt.FlatAppearance.MouseOverBackColor = Drawing.Color.Gainsboro
            Me.cmdRedact.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
            Me.cmdRedact.FlatAppearance.MouseOverBackColor = Drawing.Color.Gainsboro
            Me.chkFlag.Enabled = False
            Me.cmdExport.Visible = False

            'Format colors of buttons based on the value of Email_Status
            Select Case _dtEmail.Rows(0).Item("Email_Status")
                Case "Produce"
                    'Update formatting of 'Produce' button
                    Me.cmdProduce.BackColor = Drawing.Color.LightSteelBlue
                    Me.cmdProduce.FlatAppearance.MouseOverBackColor = Drawing.Color.LightSteelBlue
                    Me.chkFlag.Enabled = True
                    Exit Select
                Case "Non-Responsive"
                    'Update formatting of 'Non-Responsive' button
                    Me.cmdNonResponsive.BackColor = Drawing.Color.LightSteelBlue
                    Me.cmdNonResponsive.FlatAppearance.MouseOverBackColor = Drawing.Color.LightSteelBlue
                    Me.chkFlag.Enabled = True
                    Exit Select
                Case "Exemption"
                    'Update formatting of 'Exempt' button
                    Me.cmdExempt.BackColor = Drawing.Color.LightSteelBlue
                    Me.cmdExempt.FlatAppearance.MouseOverBackColor = Drawing.Color.LightSteelBlue
                    Me.chkFlag.Enabled = True
                    Exit Select
                Case "Redaction"
                    'Update formatting of 'Redact' button
                    Me.cmdRedact.BackColor = Drawing.Color.LightSteelBlue
                    Me.cmdRedact.FlatAppearance.MouseOverBackColor = Drawing.Color.LightSteelBlue
                    Me.chkFlag.Enabled = True
                    ' Show Export button if Redacted email has a Redacted File in the database
                    If _dtEmail.Rows(0)("RFID") > 0 Then Me.cmdExport.Visible = True
                    Exit Select
            End Select

            'Clear attachments DataTable and fill with with attachments for current EmailID
            _dtAttachments.Clear()
            sSQL = $"SELECT a.[FileName], a.[FileExt], a.[ID], a.[OLType],
	                COALESCE(ty.[Exemption_Type],'Unreviewed') AS [Status]
                FROM dbo.[Attachments] a
                LEFT JOIN (
	                SELECT t1.[AttachID], MAX(t2.[TypeID]) AS [maxid]
	                FROM dbo.[AttachExemptStatus] t1
	                INNER JOIN dbo.[sys_Exemptions] t2 ON t1.[ExemptionID]=t2.[ID]
	                GROUP BY t1.[AttachID] ) AS st ON a.[ID]=st.[AttachID]
                LEFT JOIN dbo.[sys_ExemptionTypes] ty ON st.[maxid]=ty.[ID]
                WHERE a.[EmailID]=@EmailID 
                AND a.[FileExt]<>'ics';"
            With New SqlDataAdapter(sSQL, CurrProjDB.Connection)
                .SelectCommand.Parameters.Add("@EmailID", SqlDbType.Int).Value = row.Item("EmailID")
                .Fill(_dtAttachments)
            End With

            'Sort attachment filenames in list box and make sure none are selected
            With Me.dgvAttachments
                .Sort(.Columns("FileName"), ListSortDirection.Ascending)
                .CurrentCell = Nothing
            End With

        Catch ex As Exception
            Logger.WriteToLog($"{ex.GetType} occurred while updating Email Display form.")
            Logger.WriteToLog(ex.ToString)

        End Try

    End Sub

    Private Function highlight(Phrases As List(Of String), SearchType As RichTextBoxFinds, ForeColor As Drawing.Color,
                               BackColor As Drawing.Color) As Boolean
        ' Finds all occurrences of input phrase in text boxes and highlights them with input coloring

        Dim FindIdx As Integer
        Dim Result As Boolean = False
        Dim counter As Integer


        For Each Box In _Boxes

            For Each Phrase In Phrases

                'Initialize loop variables
                counter = 0
                FindIdx = 0

                ' First search, if found, enter While loop
                FindIdx = Box.Find(Phrase, FindIdx, SearchType)
                While FindIdx <> -1
                    ' Phrase found at lease once, used by cmdFind
                    Result = True

                    ' Highlight phrase
                    Box.Select(FindIdx, Phrase.Length)
                    Box.SelectionColor = ForeColor
                    Box.SelectionBackColor = BackColor

                    ' If end of text box exit, if not, continue to search
                    If FindIdx + Phrase.Length >= Box.TextLength Then
                        FindIdx = -1
                    Else
                        FindIdx = Box.Find(Phrase, FindIdx + Phrase.Length, SearchType)
                    End If

                    ' protect from infinite loop, should not happen
                    counter += 1
                    If counter > 100 Then
                        Debug.WriteLine("break")
                        Exit While
                    End If

                End While

                Box.DeselectAll()

            Next
        Next

        Return Result


    End Function

    Private Sub clear_highlight()

        For Each Box In _Boxes
            Box.SelectAll()
            Box.SelectionColor = _cColor
            Box.SelectionBackColor = _cBackcolor
            Box.DeselectAll()
        Next

    End Sub

    Private Sub cmdGetSize_Click(sender As Object, e As EventArgs) Handles cmdGetSize.Click
        MsgBox(Me.Size.ToString)
    End Sub

End Class