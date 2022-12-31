Imports ClassLibrary.GlobalObjects
Imports ClassLibrary.GlobalFunctions
Imports System.Windows.Forms
Imports System.IO
Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class frmAttachments

    Private _dtAttachments As New DataTable
    Private _EmailID As Integer
    Private _AttachID As Integer
    Private _AttachStatus As String
    Private _RowIndex As String
    Private _ScaleFactor As Single

    Public Sub New(EmailID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _EmailID = EmailID

        ' Create scale factor because value of 'AutoScaleDimensions' changes with screen resolution
        _ScaleFactor = Me.CurrentAutoScaleDimensions.Width / 96

    End Sub

    Private Sub frmAttachments_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            'Set form properties
            Me.Text = $"Attachments"
            Dim iTop = {Me.Top - Convert.ToInt32(130 * _ScaleFactor), 0}.Max()
            Me.Top = iTop
            Me.MaximumSize = Me.Size
            Me.MinimumSize = Me.Size

            ' Add columns to Attachments datatable
            _dtAttachments.Columns.Add("FileName", GetType(String))
            _dtAttachments.Columns.Add("FileExt", GetType(String))
            _dtAttachments.Columns.Add("Status", GetType(String))
            _dtAttachments.Columns.Add("EmailID", GetType(Integer))
            _dtAttachments.Columns.Add("ID", GetType(Integer))
            _dtAttachments.Columns.Add("OLType", GetType(String))

            ' Initialize Attachments dgv
            With Me.dgvAttachments
                .DataSource = _dtAttachments
                .RowTemplate.Height = Convert.ToInt32(20 * _ScaleFactor)
                .Columns("FileName").Width = Convert.ToInt32(500 * _ScaleFactor)
                .Columns("FileExt").Width = Convert.ToInt32(75 * _ScaleFactor)
                .Columns("Status").Visible = False
                .Columns("EmailID").Visible = False
                .Columns("ID").Visible = False
                .Columns("OLType").Visible = False
            End With

            'Set button colors based on status of first attachment
            _RowIndex = 0
            updateForm()

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Form Open Error")

        End Try

    End Sub

    Private Sub frmAttachments_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Clean up class objects

        Try
            _dtAttachments.Dispose()

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Form Close Error")

        End Try

    End Sub

    Private Sub cmdProduce_Click(sender As Object, e As EventArgs) Handles cmdProduce.Click
        'Mark attachment(s) as 'Produce', allows for single attachment or all attachments 
        '  depending on status of "Mark All Attachments" check box

        Dim AttachIDs As New List(Of Integer)
        Dim AttachID As Integer = 0

        'Confirm operation, enter Attachment ID(s) into array, and set SQL string
        If chkMarkAll.Checked Then
            'Exit if cancelled by user
            If MsgBox("Reset all attachments?", MsgBoxStyle.YesNo,
                      "Confirm Reset") <> MsgBoxResult.Yes Then Exit Sub
            'Add all Attachment ID's to list
            For Each row As DataRow In _dtAttachments.Rows
                AttachIDs.Add(row("ID"))
            Next
        Else
            'Ensure current attachment doesn't have an exemption status set
            If _AttachStatus <> "Unreviewed" Then Exit Sub
            'Add Attachment ID of selected attachement only to list
            AttachIDs.Add(_AttachID)
        End If

        ' Create parameters table
        Dim dt As New DataTable
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Description", GetType(String))
        dt.Rows.Add({-1, "No exemptions identified."})

        Try
            'Insert new row(s) into dbo.AttachExemptStatus for each attachment
            With CurrProjDB.Connection.CreateCommand
                ' Insert all selected rows 
                .CommandText = "EXEC dbo.fAttachExemption @AttachID, @Exemptions;"
                .Parameters.Add("@AttachID", SqlDbType.Int)
                .Parameters.Add("@Exemptions", SqlDbType.Structured).Value = dt
                .Parameters("@Exemptions").TypeName = "TVP"

                For Each AttachID In AttachIDs
                    .Parameters("@AttachID").Value = AttachID
                    .ExecuteNonQuery()
                Next

            End With

            'Refresh form 
            updateForm()
            dgvAttachments.CurrentCell() = dgvAttachments.Rows(_RowIndex).Cells("FileName")

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Attachment Status Update Error")

        End Try

    End Sub

    Private Sub cmdNonResponsive_Click(sender As Object, e As EventArgs) Handles cmdNonResponsive.Click
        'Mark attachment(s) as 'Non-Responsive', allows for single attachment or all attachments 
        '  depending on status of "Mark All Attachments" check box

        Dim AttachIDs As New List(Of Integer)
        Dim AttachID As Integer = 0

        'Confirm operation, enter Attachment ID(s) into array, and set SQL string
        If chkMarkAll.Checked Then
            'Exit if cancelled by user
            If MsgBox("Reset all attachments?", MsgBoxStyle.YesNo,
                      "Confirm Reset") <> MsgBoxResult.Yes Then Exit Sub
            'Add all Attachment ID's to list
            For Each row As DataRow In _dtAttachments.Rows
                AttachIDs.Add(row("ID"))
            Next
        Else
            'Ensure current attachment doesn't have an exemption status set
            If _AttachStatus <> "Unreviewed" Then Exit Sub
            'Add Attachment ID of selected attachement only to list
            AttachIDs.Add(_AttachID)
        End If

        ' Create parameters table
        Dim dt As New DataTable
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Description", GetType(String))
        dt.Rows.Add({0, "Not applicable to this matter."})

        Try
            'Insert new row(s) into dbo.AttachExemptStatus for each attachment
            With CurrProjDB.Connection.CreateCommand
                ' Insert all selected rows 
                .CommandText = "EXEC dbo.fAttachExemption @AttachID, @Exemptions;"
                .Parameters.Add("@AttachID", SqlDbType.Int)
                .Parameters.Add("@Exemptions", SqlDbType.Structured).Value = dt
                .Parameters("@Exemptions").TypeName = "TVP"

                For Each AttachID In AttachIDs
                    .Parameters("@AttachID").Value = AttachID
                    .ExecuteNonQuery()
                Next

            End With

            'Refresh form 
            updateForm()
            dgvAttachments.CurrentCell() = dgvAttachments.Rows(_RowIndex).Cells("FileName")

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Attachment Status Update Error")

        End Try

    End Sub

    Private Sub cmdExempt_Click(sender As Object, e As EventArgs) Handles cmdExempt.Click
        'Open Exempt status form in 'Exemption' mode for selected attachment(s) 

        Dim AttachIDs As New List(Of Integer)

        'Exit if 'Mark All' not checked and status already set to another value
        If Not chkMarkAll.Checked And
            Not (_AttachStatus = "Unreviewed" Or _AttachStatus = "Exemption") Then Exit Sub

        Try
            'If 'Mark All' is checked then apply new status to all attachments
            If chkMarkAll.Checked Then
                'Exit if cancelled by user
                If MsgBox("Reset all attachments?", MsgBoxStyle.YesNo,
                              "Confirm Reset") = MsgBoxResult.No Then Exit Sub

                'Add all Attachment ID's to list
                For Each row As DataRow In _dtAttachments.Rows
                    AttachIDs.Add(row("ID"))
                Next

            Else
                'Add Attachment ID of selected attachement only to list
                AttachIDs.Add(_AttachID)

            End If

            ' Create new exemption(s) for current attachment
            With New frmAttachExemption("Exemption", AttachIDs)
                .ShowDialog(Me)
            End With

            'Refresh form to update formatting of 'Exempt' button
            updateForm()

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Attachment Status Update Error")

        End Try

    End Sub

    Private Sub cmdRedact_Click(sender As Object, e As EventArgs) Handles cmdRedact.Click
        'Open Exempt status form for current attachment in 'Redaction'

        Dim AttachIDs As New List(Of Integer)

        'Exit if 'Mark All' not checked and status already set to another value
        If Not chkMarkAll.Checked And
            Not (_AttachStatus = "Unreviewed" Or _AttachStatus = "Redaction") Then Exit Sub

        Try
            'If 'Mark All' is checked then apply new status to all attachments
            If chkMarkAll.Checked Then
                'Exit if cancelled by user
                If MsgBox("Reset all attachments?", MsgBoxStyle.YesNo,
                              "Confirm Reset") <> MsgBoxResult.Yes Then Exit Sub

                ' Add all Attachment ID's to list
                For Each row As DataRow In _dtAttachments.Rows
                    AttachIDs.Add(row("ID"))
                Next

            Else
                ' Add Attachment ID of selected attachement only to list
                AttachIDs.Add(_AttachID)

            End If

            ' Create new exemption(s) for current attachment
            With New frmAttachExemption("Redaction", AttachIDs)
                .ShowDialog(Me)
            End With

            'Refresh form to update formatting of 'Redact' button
            updateForm()

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Attachment Status Update Error")

        End Try

    End Sub

    Private Sub cmdReset_Click(sender As Object, e As EventArgs) Handles cmdReset.Click
        '

        Dim AttachIDs As New List(Of Integer)
        Dim AttachID As Integer

        'Confirm operation, enter Attachment ID(s) into list
        If chkMarkAll.Checked Then
            'Exit if cancelled by user
            If MsgBox("Reset review status for all attachments?", MsgBoxStyle.YesNo,
                      "Confirm Reset") <> MsgBoxResult.Yes Then Exit Sub
            'Add all Attachment ID's to list
            For Each row As DataRow In _dtAttachments.Rows
                AttachIDs.Add(row("ID"))
            Next

        Else
            'Exit if current attachment has no exceptions
            If _AttachStatus = "Unreviewed" Then Exit Sub
            'Exit if cancelled by user
            If MsgBox("Reset review status for current attachment?", MsgBoxStyle.YesNo,
                      "Confirm Reset") = MsgBoxResult.No Then
                Exit Sub
            End If
            ' Add Attachment ID of selected attachement only to list
            AttachIDs.Add(_AttachID)

        End If

        Try
            'Delete all rows in dbo.AttachExemptStatus for selected attachment(s)
            With CurrProjDB.Connection.CreateCommand
                .CommandText = "DELETE FROM dbo.[AttachExemptStatus] WHERE [AttachID]=@AttachID;"
                .Parameters.Add("@AttachID", SqlDbType.Int)
                For Each AttachID In AttachIDs
                    .Parameters("@AttachID").Value = AttachID
                    .ExecuteNonQuery()
                Next
            End With

            'Refresh form 
            updateForm()

        Catch ex As Exception
            Logger.WriteToLog($"{ex.GetType} occurred while resetting Review Status for Attachment ID {AttachID}.")
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Review Status Reset Error")

        End Try

    End Sub

    Private Sub dgvAttachments_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAttachments.CellClick

        If Not e.RowIndex >= 0 Then Exit Sub

        Try
            _RowIndex = e.RowIndex
            updateForm()

        Catch ex As Exception
            MsgBox(ex)

        End Try

    End Sub

    Private Sub dgvAttachments_CellDoubleClick(sender As Object,
                e As DataGridViewCellEventArgs) Handles dgvAttachments.CellDoubleClick
        'Opens attachment as a temporary file

        Dim iAttachID As Integer
        Dim sFileName As String = ""    'used for error reporting

        Try
            'Store attachment information
            iAttachID = Convert.ToInt32(dgvAttachments.Rows(e.RowIndex).Cells("ID").Value)
            sFileName = dgvAttachments.Rows(e.RowIndex).Cells("FileName").Value.ToString

            'Call procedure to open attachment file from SQL FILESTREAM data
            openFile(iAttachID)

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Open Attachment Error")
            Logger.WriteToLog($"{ex.GetType} occurred while opening " &
                $"Attachment '{sFileName}' from Attachment ID={_AttachID}.")
            Logger.WriteToLog(ex.ToString)

        End Try

    End Sub

    Private Sub updateForm()

        Dim sSQL As String

        'Clear attachments datatable and fill with all attachments for current email
        _dtAttachments.Clear()
        sSQL = $"SELECT a.[FileName], a.[FileExt], ib.[EmailID], a.[ID], a.[OLType],
	                COALESCE(ty.[Exemption_Type],'Unreviewed') AS [Status]
                FROM dbo.[Attachments] a
                LEFT JOIN (
	                SELECT t1.[AttachID], MAX(t2.[TypeID]) AS [maxid]
	                FROM dbo.[AttachExemptStatus] t1
	                INNER JOIN dbo.[sys_Exemptions] t2 ON t1.[ExemptionID]=t2.[ID]
	                GROUP BY t1.[AttachID] ) AS st ON a.[ID]=st.[AttachID]
                LEFT JOIN dbo.[sys_ExemptionTypes] ty ON st.[maxid]=ty.[ID]
                LEFT JOIN dbo.[Inbox] ib ON a.[ID]=ib.[EmbAttID]
                WHERE a.[EmailID]=@EmailID 
                AND a.[FileExt]<>'ics' ;"
        With New SqlDataAdapter(sSQL, CurrProjDB.Connection)
            .SelectCommand.Parameters.Add("@EmailID", SqlDbType.Int).Value = _EmailID
            .Fill(_dtAttachments)
        End With

        ' Reset DGV object
        With dgvAttachments
            .Sort(.Columns("FileName"), ListSortDirection.Ascending)
            .CurrentCell() = .Rows(_RowIndex).Cells("FileName")
            _AttachID = .Rows(_RowIndex).Cells("ID").Value
            _AttachStatus = .Rows(_RowIndex).Cells("Status").Value
        End With

        'Reset 'Mark All Attachments' checkbox
        chkMarkAll.Checked = False

        'Set all button colors to default settings
        Me.cmdProduce.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
        Me.cmdProduce.FlatAppearance.MouseOverBackColor = Drawing.Color.Gainsboro
        Me.cmdNonResponsive.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
        Me.cmdNonResponsive.FlatAppearance.MouseOverBackColor = Drawing.Color.Gainsboro
        Me.cmdExempt.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
        Me.cmdExempt.FlatAppearance.MouseOverBackColor = Drawing.Color.Gainsboro
        Me.cmdRedact.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
        Me.cmdRedact.FlatAppearance.MouseOverBackColor = Drawing.Color.Gainsboro

        'Format colors of buttons based on the value of attachment status
        Select Case _AttachStatus
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

    Private Sub openFile(iAttachID As Integer)
        'Create file in current user's temporary file location and open file
        'Throws exception

        Dim sFile As String

        With CurrProjDB.Connection.CreateCommand
            'export file from BLOB data
            sFile = export_attachment(iAttachID, Path.GetTempPath)

            'Open the new file.
            Process.Start($"{Path.GetTempPath}\{sFile}")

        End With

    End Sub


End Class