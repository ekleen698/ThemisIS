Imports ClassLibrary
Imports ClassLibrary.GlobalObjects
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO

Public Class frmProjDetails

    Private _dtFiles As New DataTable
    Private _dtFilesCols = New List(Of Object())
    Private _dtTotals As New DataTable
    Private _dtTotalsCols = New List(Of Object())
    Private _Selected As Boolean = False
    Private _ScaleFactor As Single
    Private _DGV_Offset As Integer = 0

    Private Property Selected As Boolean
        ' Enables functions if at least one file is selected

        Get
            Return _Selected
        End Get
        Set(value As Boolean)
            _Selected = value
            mnuRemovePSTFiles.Enabled = _Selected
            mnuImportEmails.Enabled = _Selected
        End Set

    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Create scale factor because value of 'AutoScaleDimensions' changes with screen resolution
        _ScaleFactor = Me.CurrentAutoScaleDimensions.Width / 96

        ' Offset used to re-calculate DGV width on form resize
        _DGV_Offset = (Me.Width - Me.dgvPSTFiles.Width)

    End Sub

    Private Sub frmProjDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Initialize form on load

        Dim h As Integer
        Dim w As Integer

        Try
            ' Form properties
            Me.Text = $"Project {CurrProject.Name} Details"
            Me.MinimumSize = Me.Size

            ' Define DGV columns => {Name, Width, Visible, ReadOnly}
            _dtFilesCols.Add({"Select", Convert.ToInt32(47 * _ScaleFactor), True, True})
            _dtFilesCols.Add({"ID", 0, False, True})
            _dtFilesCols.Add({"FilePath", 0, False, True})
            _dtFilesCols.Add({"Filename", Convert.ToInt32(233 * _ScaleFactor), True, True})
            _dtFilesCols.Add({"Folders", Convert.ToInt32(57 * _ScaleFactor), True, True})
            _dtFilesCols.Add({"Emails", Convert.ToInt32(57 * _ScaleFactor), True, True})
            _dtFilesCols.Add({"Imported", Convert.ToInt32(57 * _ScaleFactor), True, True})
            _dtFilesCols.Add({"Unique", Convert.ToInt32(57 * _ScaleFactor), True, True})
            _dtFilesCols.Add({"Reviewed", Convert.ToInt32(60 * _ScaleFactor), True, True})
            _dtFilesCols.Add({"Flagged", Convert.ToInt32(57 * _ScaleFactor), True, True})
            _dtFilesCols.Add({"Produce", Convert.ToInt32(57 * _ScaleFactor), True, True})
            _dtFilesCols.Add({"Non-Responsive", Convert.ToInt32(87 * _ScaleFactor), True, True})
            _dtFilesCols.Add({"Exemption", Convert.ToInt32(60 * _ScaleFactor), True, True})
            _dtFilesCols.Add({"Redaction", Convert.ToInt32(60 * _ScaleFactor), True, True})

            _dtTotalsCols.Add({"Files", Convert.ToInt32(57 * _ScaleFactor), True, True})
            _dtTotalsCols.Add({"Folders", Convert.ToInt32(57 * _ScaleFactor), True, True})
            _dtTotalsCols.Add({"Emails", Convert.ToInt32(57 * _ScaleFactor), True, True})
            _dtTotalsCols.Add({"Imported", Convert.ToInt32(57 * _ScaleFactor), True, True})
            _dtTotalsCols.Add({"Unique", Convert.ToInt32(57 * _ScaleFactor), True, True})
            _dtTotalsCols.Add({"Reviewed", Convert.ToInt32(60 * _ScaleFactor), True, True})
            _dtTotalsCols.Add({"Flagged", Convert.ToInt32(57 * _ScaleFactor), True, True})
            _dtTotalsCols.Add({"Produce", Convert.ToInt32(57 * _ScaleFactor), True, True})
            _dtTotalsCols.Add({"Non-Responsive", Convert.ToInt32(87 * _ScaleFactor), True, True})
            _dtTotalsCols.Add({"Exemption", Convert.ToInt32(60 * _ScaleFactor), True, True})
            _dtTotalsCols.Add({"Redaction", Convert.ToInt32(60 * _ScaleFactor), True, True})

            ' Datagridview properties
            h = Convert.ToInt32(22 * _ScaleFactor)
            With Me.dgvPSTFiles
                .DataSource = _dtFiles
                .ColumnHeadersHeight = h
                .RowTemplate.Height = h
            End With
            With Me.dgvTotals
                .DataSource = _dtTotals
                .ColumnHeadersHeight = h
                .RowTemplate.Height = h
            End With

            ' Menu bar properties
            w = Convert.ToInt32(100 * _ScaleFactor)
            h = Convert.ToInt32(25 * _ScaleFactor)
            Dim MenuList = New List(Of ToolStripMenuItem) From {mnuPSTFiles, mnuView, mnuSearch, mnuExport, mnuRedacted}
            For Each itm In MenuList
                itm.Width = w
                itm.Height = h
            Next

            'Get .pst file names from the Files table and add to listview
            fillDataTable()

            ' Reset Selected property after DGV filled
            Selected = False

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Form Load Error")

        End Try

    End Sub

    Private Sub frmProjDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Validate filepaths of all pst files

        Dim bPass As Boolean
        Dim oFolder As Folder
        Dim oFolderDialog As New FolderBrowserDialog With {
            .Description = "Select Folder With .pst Files",
            .ShowNewFolderButton = False}

        ' If any file path is not valid, attempt to select new folder
        bPass = validateFilePaths()
        While Not bPass
            If MsgBox($"One or more pst file paths have changed.{vbCrLf}Update pst file folder?",
                      vbQuestion + vbYesNo, "File Not Found") = MsgBoxResult.Yes Then

                'Open dialog to get folder for .pst file location
                If oFolderDialog.ShowDialog() = DialogResult.OK Then

                    oFolder = Folder.GetFolder(oFolderDialog.SelectedPath)
                    If oFolder.Exists Then
                        ' Loop all files in selected folder and subfolders
                        loopFolders(oFolder)
                        ' Update datatable with new file info
                        fillDataTable()
                        ' Re-perform file path validation, exits While if all paths are valid
                        bPass = validateFilePaths()
                    Else
                        ' If invalid folder try again
                        MsgBox($"Folder doesn't exist.", vbOKOnly, "Invalid Operation")
                    End If

                End If
            Else
                ' Cancelled by user
                Exit While
            End If

        End While

    End Sub

    Private Sub frmProjDetails_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Clean up data table on form closing

        Try
            _dtFiles.Dispose()
            _dtTotals.Dispose()

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Project Details Error")

        End Try

    End Sub

    Private Sub frmProjDetails_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        If _DGV_Offset > 0 Then resize_dgv()

    End Sub

    Private Sub mnuAddPSTFiles_Click(sender As Object, e As EventArgs) Handles mnuAddPSTFiles.Click
        'Catalog .pst files into database and update dgv

        Try
            Cursor.Current = Cursors.WaitCursor
            Logger.WriteToLog($"***Begin Adding PST Files***")

            'Select folder, import file info for each pst file
            CurrProjDB.AddPSTFiles()
            fillDataTable()

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Project Details Error")

        Finally
            Logger.WriteToLog($"***End Adding PST Files***")
            Cursor.Current = Cursors.Default

        End Try

    End Sub

    Private Sub mnuRemovePSTFiles_Click(sender As Object, e As EventArgs) Handles mnuRemovePSTFiles.Click
        'For each file selected in dgv delete all emails, attachments, and embedded msgs

        Dim result() As DataRow

        Try
            'Collection of selected rows, exit if no rows selected
            result = _dtFiles.Select("Select=True")
            If result.Count = 0 Then
                MsgBox("Nothing selected", , "Invalid Operation")
                result = Nothing
                Cursor.Current = Cursors.Default
                Exit Sub
            End If

            'User confirmation, exit if not "Yes"
            If MsgBox("Permanently remove emails from project?", MsgBoxStyle.YesNo,
                       "Confirm Remove") <> MsgBoxResult.Yes Then
                result = Nothing
                Cursor.Current = Cursors.Default
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            'Iterate selected rows deleting the file from the Project database
            For Each row As DataRow In result
                With CurrProjDB.Connection.CreateCommand
                    .CommandText = "DELETE dbo.[Files] WHERE [id]=@FileId"
                    .Parameters.Add("@FileId", SqlDbType.Int).Value = Convert.ToInt32(row("ID"))
                    .ExecuteNonQuery()
                End With

                Logger.WriteToLog($"{row("FileName").ToString} removed from project.")

            Next

            ' Update duplicates after removing emails (function protects emails with Email/Attachment Exemptions)
            Dim iDups As Integer
            With CurrProjDB.Connection.CreateCommand
                .CommandText = "
                    DECLARE @rows INT;
                    EXEC @rows = dbo.fUpdateDuplicates;
                    SELECT @rows AS [rows];"
                iDups = .ExecuteScalar()
                Logger.WriteToLog($"{iDups} emails marked as duplicate.")
            End With

            'Refresh dgv
            fillDataTable()

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Project Details Error")

        Finally
            Cursor.Current = Cursors.Default
            result = Nothing

        End Try

    End Sub

    Private Sub mnuImportEmails_Click(sender As Object, e As EventArgs) Handles mnuImportEmails.Click
        'For each file selected in dgv import all email, attachments, and embedded msgs

        Dim PSTFiles As New PSTFiles
        Dim result() As DataRow
        Dim iImportedItems As Integer
        Dim iRowID As Integer

        Try
            'Collection of dgv selected rows, exit if no rows selected
            result = _dtFiles.Select("Select=True")
            If result.Count = 0 Then
                MsgBox("At least 1 file must be selected.", vbOKOnly, "Invalid Operation")
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor
            Logger.WriteToLog($"***Begin Importing***")

            'Create collection of selected pst files 
            For Each row As DataRow In result
                iImportedItems = Convert.ToInt32(row("Imported"))
                iRowID = Convert.ToInt32(row("ID"))
                PSTFiles.Add(New PSTFile(iRowID))
            Next

            'Import all emails for each pst file in collection
            If PSTFiles.Count > 0 Then
                With New frmImportProgress(PSTFiles)
                    .ShowDialog(Me)
                End With

                'Update ListView
                fillDataTable()
            End If

        Catch ex As Exception

            MsgBox($"{DateTime.Now} > {ex.GetType}" + vbCr + $"{ex.Message}", , "Project Details Error")

        Finally
            Cursor.Current = Cursors.Default
            Logger.WriteToLog($"***End Importing***")
            PSTFiles = Nothing
            result = Nothing

        End Try

    End Sub

    Private Sub mnuViewEmails_Click(sender As Object, e As EventArgs) Handles mnuViewEmails.Click
        'View all emails 

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim sWhere As String = ""
            Dim bUnreviewed = Me.chkUnreviewed.Checked
            Dim bReviewed = Me.chkReviewed.Checked
            Dim sTypes As String = ""
            Dim bFlagged = False
            Dim iFilterOption As Integer = 0

            ' If View Option is 'Reviewed', create Types list and set Flagged option
            If chkReviewed.Checked Then
                If Me.chkProduce.Checked Then sTypes += "'Produce', "
                If Me.chkNonResponsive.Checked Then sTypes += "'Non-Responsive', "
                If Me.chkExempt.Checked Then sTypes += "'Exemption', "
                If Me.chkRedact.Checked Then sTypes += "'Redaction', "
                sTypes = sTypes.Remove(sTypes.Length - 2)
                bFlagged = Me.chkFlagged.Checked
                If cmbFilter.Text = "Emails Only" Then
                    iFilterOption = 1
                ElseIf cmbFilter.Text = "Attach. Only" Then
                    iFilterOption = 2
                End If
            End If

            If Not updateDisplayEmailIDs(sWhere, bUnreviewed, bReviewed, sTypes, bFlagged, iFilterOption) Then
                Exit Sub
            End If

            'Open email display form
            With New frmEmail()
                .ShowDialog(Me)
            End With

            'Refresh dgv after Email Display form closes to update Reviewed items
            fillDataTable()

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Project Details Error")

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub mnuViewGroups_Click(sender As Object, e As EventArgs) Handles mnuViewGroups.Click
        ' Open grouped emails form

        Dim i As Integer

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim sWhere As String = ""
            Dim bUnreviewed = Me.chkUnreviewed.Checked
            Dim bReviewed = Me.chkReviewed.Checked
            Dim sTypes As String = ""
            Dim bFlagged = (Me.chkReviewed.Checked And Me.chkFlagged.Checked)
            Dim iFilterOption As Integer = 0

            ' If View Option is 'Reviewed', create Types list
            If chkReviewed.Checked Then
                If Me.chkProduce.Checked Then sTypes += "'Produce', "
                If Me.chkNonResponsive.Checked Then sTypes += "'Non-Responsive', "
                If Me.chkExempt.Checked Then sTypes += "'Exemption', "
                If Me.chkRedact.Checked Then sTypes += "'Redaction', "
                sTypes = sTypes.Remove(sTypes.Length - 2)
                If cmbFilter.Text = "Emails Only" Then
                    iFilterOption = 1
                ElseIf cmbFilter.Text = "Attach. Only" Then
                    iFilterOption = 2
                End If
            End If

            If Not updateDisplayEmailIDs(sWhere, bUnreviewed, bReviewed, sTypes, bFlagged, iFilterOption) Then
                Exit Sub
            End If

            ' Ensure there are grouped rows before opening form
            With CurrProjDB.Connection.CreateCommand()
                .CommandText = "
                    SELECT COUNT(*) AS [count] FROM dbo.vGroups;"
                i = .ExecuteScalar
            End With

            If i = 0 Then
                MsgBox("No grouped emails to view.", vbOKOnly, "System Message")
                Exit Sub
            End If

            ' Open grouped emails display form
            With New frmEmail_Grouped
                .ShowDialog(Me)
            End With

            'Refresh dgv after form closes to update Reviewed items
            fillDataTable()

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Project Details Error")

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub mnuSearchEmails_Click(sender As Object, e As EventArgs) Handles mnuSearchEmails.Click
        'Open Search form for basic search

        Try
            With New frmSearch
                .ShowDialog(Me)
            End With

            'Refresh dgv after form closes to update Reviewed items
            fillDataTable()

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Project Details Error")

        End Try

    End Sub

    Private Sub mnuSearchEmailID_Click(sender As Object, e As EventArgs) Handles mnuSearchEmailID.Click
        ' Open email display form with selected EmailID

        ' Ensure input text is integer
        Dim sEmailID As String = Me.mnuEmailID.Text.Trim()
        Dim iEmailID As Integer = 0
        Integer.TryParse(sEmailID, iEmailID)
        If iEmailID = 0 Then
            MsgBox($"Unable to convert '{sEmailID}' to EmailID.")
            Exit Sub
        End If

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Call stored procedure to update display email list
            Dim sWhere As String = $"ib.EmailID={iEmailID}"
            Dim bUnreviewed = True
            Dim bReviewed = True
            Dim sTypes As String = "'Produce', 'Non-Responsive', 'Exemption', 'Redaction'"
            Dim bFlagged = False
            Dim iFilterOption As Integer = 0
            If Not updateDisplayEmailIDs(sWhere, bUnreviewed, bReviewed, sTypes, bFlagged, iFilterOption) Then
                Exit Sub
            End If

            'Open email display form
            With New frmEmail()
                .ShowDialog(Me)
            End With

            'Refresh dgv after Email Display form closes to update Reviewed items
            fillDataTable()

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Project Details Error")

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub mnuExportProduce_Click(sender As Object, e As EventArgs) Handles mnuExportProduce.Click

        begin_export("Produce")

    End Sub

    Private Sub mnuExportNonResponsive_Click(sender As Object, e As EventArgs) Handles mnuExportNonResponsive.Click

        begin_export("Non-Responsive")

    End Sub

    Private Sub mnuExportExemption_Click(sender As Object, e As EventArgs) Handles mnuExportExemption.Click

        begin_export("Exemption")

    End Sub

    Private Sub mnuExportRedaction_Click(sender As Object, e As EventArgs) Handles mnuExportRedaction.Click

        begin_export("Redaction")

    End Sub

    Private Sub mnuRedactedManage_Click(sender As Object, e As EventArgs) Handles mnuRedactedManage.Click

        With New frmRedacted()
            .ShowDialog(Me)
        End With

    End Sub

    Private Sub chkUnreviewed_CheckedChanged(sender As Object, e As EventArgs) Handles chkUnreviewed.CheckedChanged

        If Not (chkUnreviewed.Checked Or chkReviewed.Checked) Then chkUnreviewed.Checked = True

    End Sub

    Private Sub chkReviewed_CheckedChanged(sender As Object, e As EventArgs) Handles chkReviewed.CheckedChanged

        If Not (chkUnreviewed.Checked Or chkReviewed.Checked) Then chkReviewed.Checked = True

        Me.Panel2.Visible = Me.chkReviewed.Checked

    End Sub

    Private Sub chkProduce_CheckedChanged(sender As Object, e As EventArgs) Handles chkProduce.CheckedChanged

        If Not (chkProduce.Checked Or chkNonResponsive.Checked Or chkExempt.Checked _
                Or chkRedact.Checked) Then chkProduce.Checked = True

    End Sub

    Private Sub chkNonResponsive_CheckedChanged(sender As Object, e As EventArgs) Handles chkNonResponsive.CheckedChanged

        If Not (chkProduce.Checked Or chkNonResponsive.Checked Or chkExempt.Checked _
                Or chkRedact.Checked) Then chkNonResponsive.Checked = True

    End Sub

    Private Sub chkExempt_CheckedChanged(sender As Object, e As EventArgs) Handles chkExempt.CheckedChanged

        If Not (chkProduce.Checked Or chkNonResponsive.Checked Or chkExempt.Checked _
                Or chkRedact.Checked) Then chkExempt.Checked = True

    End Sub

    Private Sub chkRedact_CheckedChanged(sender As Object, e As EventArgs) Handles chkRedact.CheckedChanged

        If Not (chkProduce.Checked Or chkNonResponsive.Checked Or chkExempt.Checked _
                Or chkRedact.Checked) Then chkRedact.Checked = True

    End Sub

    Private Sub cmdSelectAll_Click(sender As Object, e As EventArgs) Handles cmdSelectAll.Click
        'Select all rows in dgv

        For Each row As DataRow In _dtFiles.Rows
            row("Select") = True
        Next

        ' Set Selected property
        Me.Selected = True

    End Sub

    Private Sub cmdSelectNone_Click(sender As Object, e As EventArgs) Handles cmdSelectNone.Click
        'Unselect all rows in dgv

        For Each row As DataRow In _dtFiles.Rows
            row("Select") = False
        Next

        ' Set Selected property
        Me.Selected = False

    End Sub

    Private Sub dgvPSTFiles_CellStateChanged(sender As Object, e As DataGridViewCellStateChangedEventArgs) Handles dgvPSTFiles.CellStateChanged
        ' Toggle value of Select column when clicked

        If e.Cell.ColumnIndex = 0 And e.Cell.Selected Then

            ' Update value in data table
            Dim row As DataRow = _dtFiles.Rows()(e.Cell.RowIndex)
            row("Select") = Not row("Select")

            ' Set Selected property
            Dim dv = New DataView(_dtFiles) With {.RowFilter = "Select=True"}
            Selected = (dv.Count > 0)

            ' Unselect cell
            e.Cell.Selected = False

        End If

    End Sub

    Private Function validateFilePaths() As Boolean
        ' Validate each pst file path, return False if any path is invalid

        Dim sFilePath As String = ""
        Dim bPass As Boolean = True

        For Each row As DataRow In _dtFiles.Rows
            sFilePath = row("FilePath").ToString
            If Not My.Computer.FileSystem.FileExists(sFilePath) Then
                bPass = False
                Exit For
            End If
        Next
        Return bPass

    End Function

    Private Sub loopFolders(Folder As Folder)
        ' Iterate each file in the selected folder, if the file is a pst file and is found in
        '  the database, update the folder path

        Dim rows() As DataRow

        For Each file As FileInfo In Folder.Files
            If file.Extension = ".pst" Then
                rows = _dtFiles.Select($"Filename='{file.Name}'")
                If rows.Count > 0 Then
                    ' File is pst and found in database, update folder path
                    With CurrProjDB.Connection.CreateCommand()
                        .CommandText = $"
                            UPDATE dbo.[Files]
                            SET FolderPath =@FolderPath
                            WHERE ID=@ID;"
                        .Parameters.Add("@FolderPath", SqlDbType.VarChar).Value = Folder.FolderPath
                        .Parameters.Add("@ID", SqlDbType.Int).Value = rows(0)("ID")
                        .ExecuteNonQuery()
                    End With
                End If
            End If
        Next

        ' Recursive call for each subfolder
        For Each subFolder As Folder In Folder.Folders
            loopFolders(subFolder)
        Next

    End Sub

    Private Sub fillDataTable()
        'Refresh the datagridview object

        Dim sSQL As String

        'Clear all data from listview
        _dtFiles.Clear()

        'Create dataset of files, folder count, item totals, and reviewed items
        sSQL = $"
			SELECT CAST('False' AS BIT) AS [Select], f.[ID], f.[FileName], f.[FilePath]
                , pf.[Folders], pf.[Total] AS [Emails]
				, COALESCE(ibx.[Imported], 0) [Imported]
				, COALESCE(ibx.[Unique],0) [Unique]
				, COALESCE(ibx.[Reviewed], 0) [Reviewed]
				, COALESCE(ibx.[Flagged], 0) [Flagged]
				, COALESCE(ibx.[Produce], 0) [Produce]
				, COALESCE(ibx.[Non-Responsive], 0) [Non-Responsive]
				, COALESCE(ibx.[Exemption], 0) [Exemption]
				, COALESCE(ibx.[Redaction], 0) [Redaction]
            FROM dbo.[Files] f
            LEFT JOIN (SELECT [FileID], COUNT(*) AS [Folders], SUM([ItemCount]) AS [Total] 
	            FROM dbo.[PSTFolders] WHERE [ItemCount]>0 GROUP BY [FileID]) pf ON f.ID=pf.FileID
            LEFT JOIN (
				SELECT [FileID]
					, COUNT(ib.[EmailID]) AS [Imported]
					, SUM(IIF(ib.[Duplicate]=0,1,0)) AS [Unique]
					, COUNT(st.[EmailID]) AS [Reviewed]
					, SUM(st.[Flag]) AS [Flagged]
					, SUM(IIF(st.Exemption_Type='Produce',1,0)) [Produce]
					, SUM(IIF(st.Exemption_Type='Non-Responsive',1,0)) [Non-Responsive]
					, SUM(IIF(st.Exemption_Type='Exemption',1,0)) [Exemption]
					, SUM(IIF(st.Exemption_Type='Redaction',1,0)) [Redaction]
				FROM [Inbox] ib
				LEFT JOIN (
					SELECT ees.EmailID, ty.Exemption_Type, MAX(CAST(ees.Flag AS INT)) [Flag]
					FROM dbo.EmailExemptStatus ees
					JOIN dbo.sys_Exemptions ex ON ees.ExemptionID=ex.ID
					JOIN dbo.sys_ExemptionTypes ty ON ex.TypeID=ty.ID
					GROUP BY EmailID, ty.Exemption_Type
					) st ON ib.[EmailID]=st.[EmailID]
				WHERE ib.EntryID<>'Embedded'
				GROUP BY [FileID]
				) ibx ON f.ID=ibx.FileID
			ORDER BY f.Filename;"
        With New SqlDataAdapter
            .SelectCommand = New SqlCommand(sSQL, CurrProjDB.Connection)
            .Fill(_dtFiles)
        End With

        ' Set Files DGV properties
        For Each oCol In _dtFilesCols
            Dim sName As String = oCol(0)
            Dim col = Me.dgvPSTFiles.Columns()(sName)
            With col
                .Width = oCol(1)
                .Visible = oCol(2)
                .ReadOnly = oCol(3)
            End With
        Next
        With Me.dgvPSTFiles
            .Sort(.Columns("FileName"), ListSortDirection.Ascending)
        End With

        ' Create Totals data table
        _dtTotals = New DataTable
        _dtTotals.Columns.Add("Files", GetType(Integer))
        _dtTotals.Rows.Add(_dtTotals.NewRow())
        _dtTotals.Rows(0)("Files") = _dtFiles.Rows.Count

        Dim Columns = {"Folders", "Emails", "Imported", "Unique", "Reviewed", "Flagged",
            "Produce", "Non-Responsive", "Exemption", "Redaction"}
        For Each c In Columns
            _dtTotals.Columns.Add(c, GetType(Integer))
            _dtTotals.Rows(0)(c) = _dtFiles.AsEnumerable().Sum(Function(row) row.Field(Of Integer)(c))
        Next
        dgvTotals.DataSource = _dtTotals

        ' Set Files DGV properties
        For Each oCol In _dtTotalsCols
            Dim sName As String = oCol(0)
            Dim col = Me.dgvTotals.Columns()(sName)
            With col
                .Width = oCol(1)
                .Visible = oCol(2)
                .ReadOnly = oCol(3)
            End With
        Next
        With Me.dgvTotals
            .ClearSelection()
        End With

        ' Enable menu items if at least one email is imported
        Dim bEnabled = (_dtTotals(0)("Imported") > 0)
        Me.Panel1.Enabled = bEnabled
        Me.mnuView.Enabled = bEnabled
        Me.mnuSearch.Enabled = bEnabled
        Me.mnuRedacted.Enabled = bEnabled
        Me.mnuExport.Enabled = bEnabled

        ' Enable Export menu items if at least one email is reviewed
        Me.mnuExportProduce.Enabled = (_dtTotals(0)("Produce") > 0)
        Me.mnuExportNonResponsive.Enabled = (_dtTotals(0)("Non-Responsive") > 0)
        Me.mnuExportExemption.Enabled = (_dtTotals(0)("Exemption") > 0)
        Me.mnuExportRedaction.Enabled = (_dtTotals(0)("Redaction") > 0)

        resize_dgv()

    End Sub

    Private Function updateDisplayEmailIDs(sWhere As String, bUnreviewed As Boolean,
                    bReviewed As Boolean, sTypes As String, bFlagged As Boolean, iFilterOption As Integer) As Boolean
        'Update DisplayEmailIDs

        Dim iCount As Integer = 0

        ' Update table of EmailIDs to be used by frmEmail or frmSearchUpdate
        With CurrProjDB.Connection.CreateCommand
            .CommandText = $"
                EXEC dbo.fUpdate_DisplayEmailIDs @Where, @Unreviewed, @Reviewed, @Types, @Flagged, @FilterOption;
                SELECT COUNT(0) FROM dbo.DisplayEmailIDs;"
            .Parameters.Add("@Where", SqlDbType.NVarChar).Value = sWhere
            .Parameters.Add("@Unreviewed", SqlDbType.Bit).Value = bUnreviewed
            .Parameters.Add("@Reviewed", SqlDbType.Bit).Value = bReviewed
            .Parameters.Add("@Types", SqlDbType.NVarChar).Value = sTypes
            .Parameters.Add("@Flagged", SqlDbType.Bit).Value = bFlagged
            .Parameters.Add("@FilterOption", SqlDbType.TinyInt).Value = iFilterOption
            iCount = .ExecuteScalar
        End With

        If iCount = 0 Then
            MsgBox("No emails found.", vbOKOnly, "Search Result")
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub begin_export(ExportType As String)
        Try
            With New frmExport(ExportType)
                .ShowDialog(Me)
            End With

        Catch ex As IOException
            Logger.WriteToLog(ex.ToString)
            MsgBox($"A File System Error occurred, ensure all files in the target folder are closed.", , "File System Error")


        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{ex.GetType}{vbCrLf}{ex}", , "Export Error")

        End Try

    End Sub

    Private Sub resize_dgv()

        Dim RowHeight = Me.dgvPSTFiles.ColumnHeadersHeight
        Dim RowCount = _dtFiles.Rows.Count + 1  ' add 1 for column headers
        Dim BaseWidth = (Me.Width - _DGV_Offset)


        If dgvPSTFiles.Height <= (RowCount * RowHeight + 1) Then
            dgvPSTFiles.Width = (BaseWidth + Convert.ToInt32(19 * _ScaleFactor))
        Else
            dgvPSTFiles.Width = BaseWidth
        End If

    End Sub

    Private Sub cmdUp_Click(sender As Object, e As EventArgs) Handles cmdUp.Click

        Me.Height -= 1
        'Debug.WriteLine(Me.dgvPSTFiles.Height)
        Me.Label1.Text = Me.dgvPSTFiles.Height
        Me.Label3.Text = Me.dgvPSTFiles.ColumnHeadersHeight

    End Sub

    Private Sub cmdDown_Click(sender As Object, e As EventArgs) Handles cmdDown.Click

        Me.Height += 1
        'Debug.WriteLine(Me.dgvPSTFiles.Height)
        Me.Label1.Text = Me.dgvPSTFiles.Height

    End Sub

    Private Sub mnuSearchEmailID_MouseHover(sender As Object, e As EventArgs) Handles mnuSearchEmailID.MouseHover

    End Sub
End Class