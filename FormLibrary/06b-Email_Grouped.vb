Imports ClassLibrary.GlobalObjects
Imports ClassLibrary.GlobalFunctions
Imports System.Windows.Forms
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.ComponentModel
Imports Microsoft.Office.Interop

Public Class frmEmail_Grouped
    ' This form is used to review groups of emails that have the same Sender, SentOn,
    '  Subject, Body.  Allows opening each email to review individually or updating all
    '  emails in a group using the bulk update form.

    Private _dtChkSum As New DataTable
    Private _bsChkSum As New BindingSource
    Private _dtGroup As New DataTable
    Private _dtEmails As New DataTable
    Private _iRows As Integer = 0
    Private _bByPassUpdate As Boolean = True
    Private _sCurrStatus As String = ""
    Private _cBackcolor As Drawing.Color
    Private _cColor As Drawing.Color
    'Private _Boxes As RichTextBox()
    Private _ScaleFactor As Single

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Create scale factor because value of 'AutoScaleDimensions' changes with screen resolution
        _ScaleFactor = Me.CurrentAutoScaleDimensions.Width / 96

    End Sub

    Private Sub frmEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim sSQL As String
        'Dim i As Integer

        Try
            'Set form properties
            Me.MinimumSize = Me.Size

            ' Hide border on top layer Find text box, 2 layers used to simulate padding
            Me.txtFind.BorderStyle = BorderStyle.None

            ' Disable button due to attachments, color indicates status, button code is retained for future
            ' Updates to status can be made in primary email form
            Me.cmdProduce.Enabled = False
            Me.cmdNonResponsive.Enabled = False
            Me.cmdExempt.Enabled = False
            Me.cmdRedact.Enabled = False

            ' Initialize DataGridView
            With Me.dgvEmails
                _dtEmails.Columns.Add("EmailID")
                _dtEmails.Columns.Add("To")
                _dtEmails.Columns.Add("CC")
                _dtEmails.Columns.Add("BCC")
                _dtEmails.Columns.Add("Attach")
                .DataSource = _dtEmails
                .Columns("EmailID").Visible = False ' use to get EmailID of selected row
                .Columns("To").Width = Convert.ToInt32(250 * _ScaleFactor)
                .Columns("CC").Width = Convert.ToInt32(225 * _ScaleFactor)
                .Columns("BCC").Width = Convert.ToInt32(225 * _ScaleFactor)
                .Columns("Attach").Width = Convert.ToInt32(50 * _ScaleFactor)
            End With

            ' Store default colors, used to reset after Find operation
            _cBackcolor = Me.txtBody.BackColor
            _cColor = Me.txtBody.ForeColor

            ' List of RichTextBoxes
            '_Boxes = {Me.txtFrom, Me.txtSubject, Me.txtBody}

            ' Create temp table variable from view for performance
            ' Get sorted list of checksum values for bindingsource
            'Fill DataTable used by form BindingSource
            sSQL = "
                DROP TABLE IF EXISTS #v;
                SELECT * INTO #v FROM dbo.vGroups;
                SELECT distinct v.ChkSum_Count, v.ChkSum
                FROM #v v
                ORDER BY v.ChkSum_Count desc, v.ChkSum;"
            With New SqlDataAdapter(sSQL, CurrProjDB.Connection)
                .Fill(_dtChkSum)
            End With

            'Sort id's by sent date (oldest to newest), add data to form 
            '  BindingSource, and update the form to display the first group
            _dtChkSum.DefaultView.Sort = "ChkSum_Count DESC"
            _bsChkSum.DataSource = _dtChkSum.DefaultView
            _iRows = _dtChkSum.Rows.Count
            updateForm()

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Form Open Error")
            Logger.WriteToLog($"{ex.GetType} occurred while loading Grouped Email Display form.")
            Logger.WriteToLog(ex.ToString)

        End Try

    End Sub

    Private Sub frmEmail_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Clean up class objects

        Try
            _dtChkSum.Dispose()
            _bsChkSum.Dispose()
            _dtGroup.Dispose()
            _dtEmails.Dispose()

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Form Close Error")
            Logger.WriteToLog($"{ex.GetType} occurred while closing Dupe Email Display form.")
            Logger.WriteToLog(ex.ToString)

        End Try

    End Sub


    Private Sub cmdFind_Click(sender As Object, e As EventArgs) Handles cmdFind.Click
        ' Finds text in the message body and highlights it

        Dim sText As String = Me.txtFind.Text.Trim()
        Dim findIdx As Integer = 0
        Dim bTextFound As Boolean = False

        ' Reset Body text box, allows for consecutive searches
        Me.txtBody.SelectAll()
        Me.txtBody.SelectionColor = _cColor
        Me.txtBody.SelectionBackColor = _cBackcolor

        ' Exit if no text is entered
        If sText.Length = 0 Then
            MsgBox("First enter text to find.", vbOKOnly, "Invalid Operation")
            Exit Sub
        End If

        ' Use the Find() method to find each instace of sText then change the 
        '   formatting to highlight the text. Each iteration starts at the end of
        '   the previous result.
        While findIdx <> -1
            findIdx = Me.txtBody.Find(sText, findIdx + sText.Length, RichTextBoxFinds.None)

            If findIdx <> -1 Then
                Me.txtBody.SelectionStart = findIdx
                Me.txtBody.SelectionLength = sText.Length
                Me.txtBody.SelectionColor = Drawing.Color.Red
                Me.txtBody.SelectionBackColor = Drawing.Color.Yellow
                bTextFound = True
            End If

        End While

        If Not bTextFound Then
            ' If nothing found on first pass, startIdx is never updated
            MsgBox("Text not found.", vbOKOnly, "Find Result")
        End If


    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        ' Reset Find text box value and Body text box formatting

        Me.txtFind.Text = ""
        Me.txtBody.SelectAll()
        Me.txtBody.SelectionColor = _cColor
        Me.txtBody.SelectionBackColor = _cBackcolor

    End Sub

    Private Sub cmdNext_Click(sender As Object, e As EventArgs) Handles cmdNext.Click
        'Move to next record of bindingsource object and refresh form textbox objects
        _bsChkSum.MoveNext()
        updateForm()

    End Sub

    Private Sub cmdPrevious_Click(sender As Object, e As EventArgs) Handles cmdPrevious.Click
        'Move to previous record of bindingsource object and refresh form textbox objects
        _bsChkSum.MovePrevious()
        updateForm()

    End Sub

    Private Sub cmdProduce_Click(sender As Object, e As EventArgs) Handles cmdProduce.Click
        ' Button disabled

        'Dim iEmailID As Integer = dgvEmails.CurrentRow.Cells("EmailID").Value

        ''Ensure current email doesn't have an exemption status set
        'If _sCurrStatus <> "Unreviewed" Then Exit Sub

        '' Create parameters table
        'Dim dt As New DataTable
        'dt.Columns.Add("ID", GetType(Integer))
        'dt.Columns.Add("Description", GetType(String))
        'dt.Rows.Add({-1, "No exemptions identified."})

        'Try
        '    'Insert new row into dbo.EmailExemptStatus for current EmailID
        '    With CurrProjDB.Connection.CreateCommand
        '        .CommandText = "EXEC dbo.fEmailExemption @EmailID, @Exemptions;"
        '        .Parameters.Add("@EmailID", SqlDbType.Int).Value = iEmailID
        '        .Parameters.Add("@Exemptions", SqlDbType.Structured).Value = dt
        '        .Parameters("@Exemptions").TypeName = "TVP"
        '        .ExecuteNonQuery()
        '    End With

        '    'Refresh form to update formatting of 'Produce' button
        '    updateEmailStatus()

        'Catch ex As Exception
        '    MsgBox($"{DateTime.Now} > {ex.GetType}", , "Dupe Email Status Update Error")
        '    Logger.WriteToLog($"{ex.GetType} occurred while marking EmailID={iEmailID} as 'Produce'.")
        '    Logger.WriteToLog(ex.ToString)

        'End Try

    End Sub

    Private Sub cmdNonResponsive_Click(sender As Object, e As EventArgs) Handles cmdNonResponsive.Click
        ' Button disabled

        Dim iEmailID As Integer = dgvEmails.CurrentRow.Cells("EmailID").Value

        ''Ensure current email doesn't have an exemption status set
        'If _sCurrStatus <> "Unreviewed" Then Exit Sub

        '' Create parameters table
        'Dim dt As New DataTable
        'dt.Columns.Add("ID", GetType(Integer))
        'dt.Columns.Add("Description", GetType(String))
        'dt.Rows.Add({0, "Not applicable to this matter."})

        'Try
        '    'Insert new row into dbo.EmailExemptStatus for current EmailID
        '    With CurrProjDB.Connection.CreateCommand
        '        .CommandText = "EXEC dbo.fEmailExemption @EmailID, @Exemptions;"
        '        .Parameters.Add("@EmailID", SqlDbType.Int).Value = iEmailID
        '        .Parameters.Add("@Exemptions", SqlDbType.Structured).Value = dt
        '        .Parameters("@Exemptions").TypeName = "TVP"
        '        .ExecuteNonQuery()
        '    End With

        '    'Refresh form to update formatting of 'Non-Responsive' button
        '    updateEmailStatus()

        'Catch ex As Exception
        '    MsgBox($"{DateTime.Now} > {ex.GetType}", , "Dupe Email Status Update Error")
        '    Logger.WriteToLog($"{ex.GetType} occurred while marking EmailID={iEmailID} as 'Non Responsive'.")
        '    Logger.WriteToLog(ex.ToString)

        'End Try

    End Sub

    Private Sub cmdExempt_Click(sender As Object, e As EventArgs) Handles cmdExempt.Click
        ' Button disabled

        'Dim iEmailID As Integer = dgvEmails.CurrentRow.Cells("EmailID").Value

        'Try
        '    'Exit if email status not 'Exemption' or 'Unreviewed'
        '    If New List(Of String) From {"Unreviewed", "Exemption"}.Contains(_sCurrStatus) Then
        '        'Create new exemption(s) for current email
        '        With New frmEmailExemption(_sCurrStatus, iEmailID)
        '            .ShowDialog()
        '        End With

        '        'Refresh form to update formatting of 'Exempt' button
        '        updateForm()
        '    End If

        'Catch ex As Exception
        '    MsgBox($"{DateTime.Now} > {ex.GetType}", , "Dupe Email Status Update Error")
        '    Logger.WriteToLog($"{ex.GetType} occurred while marking EmailID={iEmailID} as 'Exempt'.")
        '    Logger.WriteToLog(ex.ToString)

        'End Try

    End Sub

    Private Sub cmdRedact_Click(sender As Object, e As EventArgs) Handles cmdRedact.Click
        ' Button disabled

        'Dim iEmailID As Integer = dgvEmails.CurrentRow.Cells("EmailID").Value

        'Try
        '    'Exit if email status not 'Exemption' or 'Unreviewed'
        '    If New List(Of String) From {"Unreviewed", "Redaction"}.Contains(_sCurrStatus) Then
        '        'Create new exemption(s) for current email
        '        With New frmEmailExemption(_sCurrStatus, iEmailID)
        '            .ShowDialog()
        '        End With

        '        'Refresh form to update formatting of 'Exempt' button
        '        updateForm()
        '    End If

        'Catch ex As Exception
        '    MsgBox($"{DateTime.Now} > {ex.GetType}", , "Dupe Email Status Update Error")
        '    Logger.WriteToLog($"{ex.GetType} occurred while marking EmailID={iEmailID} as 'Redact'.")
        '    Logger.WriteToLog(ex.ToString)

        'End Try


    End Sub

    Private Sub cmdViewEmail_Click(sender As Object, e As EventArgs) Handles cmdViewEmail.Click
        'Open current email in Email Display form

        Dim iEmailID As Integer = dgvEmails.CurrentRow.Cells("EmailID").Value
        Dim sWhere As String = $"AND ib.EmailID = {iEmailID}"
        Debug.WriteLine($"{iEmailID} > {sWhere}")

        With CurrProjDB.Connection.CreateCommand
            .CommandText = $"EXEC dbo.fUpdate_DisplayEmailIDs @Where, @Unreviewed, @Reviewed, @Types, @Flagged;"
            .Parameters.Add("@Where", SqlDbType.NVarChar).Value = sWhere
            .Parameters.Add("@Unreviewed", SqlDbType.Bit).Value = 1
            .Parameters.Add("@Reviewed", SqlDbType.Bit).Value = 1
            .Parameters.Add("@Types", SqlDbType.NVarChar).Value = "'Produce', 'Non-Responsive', 'Exemption', 'Redaction'"
            .Parameters.Add("@Flagged", SqlDbType.Bit).Value = 0
            .ExecuteNonQuery()
        End With

        Try
            'Open email display form
            With New frmEmail()
                .ShowDialog()
            End With

            updateEmailStatus()

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Email Form Open Error")

        End Try

    End Sub

    Private Sub cmdUpdateGroup_Click(sender As Object, e As EventArgs) Handles cmdUpdateGroup.Click

        Try
            ' Update Display EmailID table for bulk update operation
            Dim iChkSum As Integer = _bsChkSum.Current.Item("ChkSum")
            Dim sWhere As String = $"AND ib.EmailID IN (SELECT EmailID FROM #v WHERE Chksum={iChkSum})"

            With CurrProjDB.Connection.CreateCommand
                .CommandText = $"EXEC dbo.fUpdate_DisplayEmailIDs @Where, @Unreviewed, @Reviewed, @Types, @Flagged;"
                .Parameters.Add("@Where", SqlDbType.NVarChar).Value = sWhere
                .Parameters.Add("@Unreviewed", SqlDbType.Bit).Value = 1
                .Parameters.Add("@Reviewed", SqlDbType.Bit).Value = 1
                .Parameters.Add("@Types", SqlDbType.NVarChar).Value = "'Produce', 'Non-Responsive', 'Exemption', 'Redaction'"
                .Parameters.Add("@Flagged", SqlDbType.Bit).Value = 0
                .ExecuteNonQuery()
            End With

            ' Open email update form
            With New frmSearchUpdate()
                .ShowDialog()
            End With

            ' Reflect new status
            updateEmailStatus()

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Update Form Open Error")

        End Try

    End Sub

    Private Sub dgvEmails_SelectionChanged(sender As Object, e As EventArgs) _
            Handles dgvEmails.SelectionChanged

        If Not _bByPassUpdate Then updateEmailStatus()

    End Sub

    Private Sub dgvEmails_DoubleClick(sender As Object, e As EventArgs) Handles dgvEmails.DoubleClick
        'Open current email in Email Display form

        Me.cmdViewEmail.PerformClick()

    End Sub

    Private Sub updateForm()
        'Update all form textbox objects from bindingsource object
        'Handles exceptions

        Dim sSQL As String
        Dim iHgt As Integer = 0
        Dim row As DataRowView = _bsChkSum.Current

        Try
            _bByPassUpdate = True

            'Clear ChkSum DataTable and fill with values for current ChkSum in form BindingSource
            _dtGroup.Clear()
            sSQL = $"SELECT DISTINCT v.ChkSum, v.ChkSum_Count, v.SentOn, v.Sender, v.[Subject], v.Body
                    FROM #v v
                    WHERE v.ChkSum = @ChkSum;"
            With New SqlDataAdapter(sSQL, CurrProjDB.Connection)
                .SelectCommand.Parameters.Add("@ChkSum", SqlDbType.Int).Value = row.Item("ChkSum")
                .Fill(_dtGroup)
            End With

            'Set textbox values from Group DataTable
            Me.txtSentOn.Text = _dtGroup.Rows(0).Item("SentOn").ToString
            Me.txtFrom.Text = _dtGroup.Rows(0).Item("Sender").ToString
            Me.txtSubject.Text = _dtGroup.Rows(0).Item("Subject").ToString
            Me.txtBody.Text = _dtGroup.Rows(0).Item("Body").ToString

            'Update count label
            Me.lblNumEmails.Text = $"{_bsChkSum.Position + 1} of {_iRows} Group(s)"

            'Clear email DataTable and fill with values for current ChkSum in form BindingSource
            _dtEmails.Clear()
            sSQL = $"SELECT v.EmailID, v.[To], v.CC, v.BCC, v.Attachments Attach
                FROM #v v
                WHERE v.ChkSum = @ChkSum
                ORDER BY v.EmailID;"
            With New SqlDataAdapter(sSQL, CurrProjDB.Connection)
                .SelectCommand.Parameters.Add("@ChkSum", SqlDbType.Int).Value = row.Item("ChkSum")
                .Fill(_dtEmails)
            End With

            For Each r As DataGridViewRow In dgvEmails.Rows
                iHgt = r.GetPreferredHeight(r.Index, DataGridViewAutoSizeRowMode.AllCells, True)
                If iHgt > 200 Then iHgt = 200
                r.Height = iHgt
            Next

            _bByPassUpdate = False
            updateEmailStatus()

        Catch ex As Exception
            Logger.WriteToLog($"{ex.GetType} occurred while updating Email Display form.")
            Logger.WriteToLog(ex.ToString)

        Finally
            'Cleanup method objects
            row = Nothing

        End Try

    End Sub

    Private Sub updateEmailStatus()

        Dim iEmailID As Integer = 0

        ' Get EmailID of selected row and update label
        iEmailID = dgvEmails.CurrentRow.Cells("EmailID").Value
        Me.lblEmailID.Text = $"EmailID: {iEmailID}"

        ' Get Email Status for selected email
        With CurrProjDB.Connection.CreateCommand
            .CommandText = $"
                SELECT COALESCE(ty.[Exemption_Type],'Unreviewed') AS [Email_Status]
                FROM dbo.Inbox ib
                LEFT JOIN (
	                SELECT t1.[EmailID], MAX(t2.[TypeID]) AS [maxid]
	                FROM dbo.[EmailExemptStatus] t1
	                INNER JOIN dbo.[sys_Exemptions] t2 ON t1.[ExemptionID]=t2.[ID]
	                GROUP BY t1.[EmailID] ) AS es ON ib.EmailID=es.EmailID
                LEFT JOIN dbo.[sys_ExemptionTypes] ty ON es.[maxid]=ty.[ID]
                WHERE ib.[EmailID]=@EmailID;"
            .Parameters.Add("@EmailID", SqlDbType.Int).Value = iEmailID
            _sCurrStatus = .ExecuteScalar
        End With

        'Set all button colors to default settings
        Me.cmdProduce.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
        'Me.cmdProduce.FlatAppearance.MouseOverBackColor = Drawing.Color.Gainsboro
        Me.cmdNonResponsive.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
        'Me.cmdNonResponsive.FlatAppearance.MouseOverBackColor = Drawing.Color.Gainsboro
        Me.cmdExempt.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
        'Me.cmdExempt.FlatAppearance.MouseOverBackColor = Drawing.Color.Gainsboro
        Me.cmdRedact.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
        'Me.cmdRedact.FlatAppearance.MouseOverBackColor = Drawing.Color.Gainsboro

        'Format colors of buttons based on the value of Email_Status
        Select Case _sCurrStatus
            Case "Produce"
                'Update formatting of 'Produce' button
                Me.cmdProduce.BackColor = Drawing.Color.LightSteelBlue
                Me.cmdProduce.FlatAppearance.MouseOverBackColor = Drawing.Color.LightSteelBlue
                Exit Select
            Case "Non-Responsive"
                'Update formatting of 'Non-Responsive' button
                Me.cmdNonResponsive.BackColor = Drawing.Color.LightSteelBlue
                Me.cmdNonResponsive.FlatAppearance.MouseOverBackColor = Drawing.Color.LightSteelBlue
                Exit Select
            Case "Exemption"
                'Update formatting of 'Exempt' button
                Me.cmdExempt.BackColor = Drawing.Color.LightSteelBlue
                Me.cmdExempt.FlatAppearance.MouseOverBackColor = Drawing.Color.LightSteelBlue
                Exit Select
            Case "Redaction"
                'Update formatting of 'Redact' button
                Me.cmdRedact.BackColor = Drawing.Color.LightSteelBlue
                Me.cmdRedact.FlatAppearance.MouseOverBackColor = Drawing.Color.LightSteelBlue
                Exit Select
        End Select

    End Sub

    Private Sub cmdGetSize_Click(sender As Object, e As EventArgs) Handles cmdGetSize.Click
        MsgBox(Me.Size.ToString)
    End Sub
End Class