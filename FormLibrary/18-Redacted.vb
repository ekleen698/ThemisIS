Imports ClassLibrary
Imports ClassLibrary.GlobalObjects
Imports ClassLibrary.GlobalFunctions
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO

Public Class frmRedacted

    Private _dtEmails As New DataTable
    Private _dtFiles As New DataTable
    Private _ScaleFactor As Single
    Private _Expanded As Boolean = False

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Create scale factor because value of 'AutoScaleDimensions' changes with screen resolution
        _ScaleFactor = Me.CurrentAutoScaleDimensions.Width / 96

    End Sub

    Private Sub frmRedacted_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Form properties
        set_form_width()

        ' Menu bar properties
        Dim h = 25
        Dim MenuDict = New Dictionary(Of ToolStripMenuItem, Integer) From {
            {Me.mnuImport, 100},
            {Me.mnuExport, 125}
            }
        For Each itm In MenuDict
            Dim mnu = itm.Key
            Dim w = itm.Value
            mnu.Width = Convert.ToInt32(w * _ScaleFactor)
            mnu.Height = Convert.ToInt32(h * _ScaleFactor)
        Next

        ' Fill data tables
        fill_emails_table()

    End Sub

    Private Sub dgvEmails_SelectionChanged(sender As Object, e As EventArgs) Handles dgvEmails.SelectionChanged

        Dim rowCount = dgvEmails.SelectedRows.Count

        ' Enable/disable 'Selected' menu item(s)
        If rowCount > 0 AndAlso dgvEmails.SelectedRows(0).Cells("RFID").Value > 0 Then
            mnuExportSelected.Enabled = True
        Else
            mnuExportSelected.Enabled = False
        End If

        ' Update Files dgv
        Dim EmailID = 0
        If rowCount = 1 Then
            EmailID = dgvEmails.SelectedRows(0).Cells("EmailID").Value
        End If
        fill_files_table(EmailID)

    End Sub

    Private Sub cmdExpand_Click(sender As Object, e As EventArgs) Handles cmdExpand.Click
        ' Show/Hide Files dgv

        _Expanded = Not _Expanded
        set_form_width()

        If Not _Expanded Then
            Me.cmdExpand.Text = "File List >>"
        Else
            Me.cmdExpand.Text = "File list <<"
        End If

    End Sub

    Private Sub mnuImportFolder_Click(sender As Object, e As EventArgs) Handles mnuImportFolder.Click
        ' Import all files in selected folder

        ' Default folder
        Dim sDesktop As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim sFolder As String = Path.Combine(sDesktop, "Themis Redacted Emails")

        Try
            ' Open folder dialog to select folder
            Dim dSelect = New FolderBrowserDialog With {
                .Description = "Select Folder",
                .ShowNewFolderButton = False,
                .SelectedPath = sFolder
                }

            ' Validate dialog response
            Dim drResult = dSelect.ShowDialog()
            If drResult <> DialogResult.OK Then Exit Sub

            ' Validate selected folder
            Dim oFolder = New DirectoryInfo(dSelect.SelectedPath)
            If Not oFolder.Exists Then Exit Sub

            ' Validate file count
            Dim oFiles = oFolder.GetFiles("EmailID *_Redacted.pdf").ToList()
            If oFiles.Count = 0 Then
                MsgBox("No files like 'EmailID xxx_Redactd.pdf' found in selected folder.",, "File Not Found")
                Exit Sub
            End If

            ' Import files and update data table
            import_files(oFiles)

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", vbCritical, "Project Details Error")

        End Try

    End Sub

    Private Sub mnuImportFiles_Click(sender As Object, e As EventArgs) Handles mnuImportFiles.Click
        ' Import selected files 

        ' Default folder
        Dim sDesktop As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim sFolder As String = Path.Combine(sDesktop, "Themis Redacted Emails")

        Try
            'Select backup file, exit if invalid
            Dim oDialog = New OpenFileDialog With {
                    .Title = "Select One or More Redacted Files",
                    .InitialDirectory = sFolder,
                    .Multiselect = True,
                    .Filter = "PDF (*.pdf)|EmailID *_Redacted.pdf"
                    }
            Dim oResult = oDialog.ShowDialog()
            If (oResult <> DialogResult.OK) Then
                Exit Sub
            End If

            ' Validate selected file names
            Dim oFiles As New List(Of FileInfo)
            For Each sFileName In oDialog.FileNames
                Dim oFile = New FileInfo(sFileName)
                If oFile.Name Like "EmailID *_Redacted.pdf" Then oFiles.Add(oFile)
            Next

            ' Validate file count
            If oFiles.Count = 0 Then Exit Sub

            ' Import files and update data table
            import_files(oFiles)


        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", vbCritical, "Project Details Error")

        End Try

    End Sub

    Private Sub mnuExportAll_Click(sender As Object, e As EventArgs) Handles mnuExportAll.Click
        ' Export latest redacted file for all emails in Emails DGV

        ' Create list of file id's
        Dim RFIDList As New List(Of Integer)
        For Each row As DataGridViewRow In dgvEmails.Rows
            If row.Cells("RFID").Value > 0 Then RFIDList.Add(row.Cells("RFID").Value)
        Next

        ' Export files in list
        If RFIDList.Count > 0 Then
            export_redacted(RFIDList)
        End If

    End Sub

    Private Sub mnuExportSelected_Click(sender As Object, e As EventArgs) Handles mnuExportSelected.Click
        ' Export latest redacted file for all selected emails in Emails DGV

        ' Create list of file id's
        Dim RFIDList As New List(Of Integer)
        For Each row As DataGridViewRow In dgvEmails.SelectedRows
            If row.Cells("RFID").Value > 0 Then RFIDList.Add(row.Cells("RFID").Value)
        Next

        ' Export files in list
        If RFIDList.Count > 0 Then
            export_redacted(RFIDList)
        End If

    End Sub
    Private Sub dgvFiles_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFiles.CellDoubleClick
        ' Export redacted file from selected row in Files DGV

        Dim iRFID = dgvFiles.SelectedRows(0).Cells("RFID").Value
        Dim RFIDList As New List(Of Integer) From {iRFID}
        export_redacted(RFIDList)

    End Sub


    Private Sub set_form_width()

        Dim w As Integer

        ' Reset max/min limits
        Me.MaximumSize = New Drawing.Size(0, 0)
        Me.MinimumSize = New Drawing.Size(0, 0)

        ' Set form width
        If Not _Expanded Then
            w = Convert.ToInt32(600 * _ScaleFactor)
        Else
            w = Convert.ToInt32(1005 * _ScaleFactor)
        End If
        Me.Width = w

        ' Set max/min limits to current form size
        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size

    End Sub

    Private Sub fill_emails_table()

        ' Clear all rows
        dgvEmails.DataSource = Nothing
        _dtEmails.Clear()

        ' Load data table
        Dim sSQL = "
            SELECT rf.EmailID, rf.[FileName], rf.Seq [Files], CAST(rf.[Timestamp] AS DATE) [CreatedOn]
	            , RTRIM(rf.CreatedBy) [CreatedBy], ISNULL(rf.ID,0) [RFID]
            FROM dbo.vRedactedFiles rf
            ORDER BY rf.EmailID;"
        With New SqlDataAdapter(sSQL, CurrProjDB.Connection)
            .Fill(_dtEmails)
        End With

        ' Datagridview properties
        Dim dr As Integer = {_dtEmails.Rows.Count, 17}.Min() ' max of 17 rows of data
        Dim h As Integer = Convert.ToInt32(25 * _ScaleFactor)
        With Me.dgvEmails
            .Height = ((1 + dr) * h + 2) ' column header row + data rows + 2 for scroll bar
            .ColumnHeadersHeight = h
            .RowTemplate.Height = h
            .RowTemplate.ReadOnly = True

            .DataSource = _dtEmails ' must set template row height before datasource
            .Columns("EmailID").Width = Convert.ToInt32(75 * _ScaleFactor)
            .Columns("EmailID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("FileName").Width = Convert.ToInt32(200 * _ScaleFactor)
            .Columns("Files").Width = Convert.ToInt32(50 * _ScaleFactor)
            .Columns("CreatedOn").Width = Convert.ToInt32(100 * _ScaleFactor)
            .Columns("CreatedBy").Width = Convert.ToInt32(128 * _ScaleFactor) ' +28 for vertical scroll bar
            .Columns("RFID").Visible = False
        End With

    End Sub

    Private Sub fill_files_table(EmailID As Integer)

        ' Clear all rows
        dgvFiles.DataSource = Nothing
        _dtFiles.Clear()

        ' Load data table
        Dim sSQL = "
            SELECT rf.EmailID, rf.Seq, CAST(rf.[Timestamp] AS DATE) [CreatedOn]
	            , RTRIM(rf.CreatedBy) [CreatedBy], ISNULL(rf.ID,0) [RFID]
            FROM dbo.RedactedFiles rf
            WHERE rf.EmailID=@EmailID
			ORDER BY rf.Seq;"
        With New SqlDataAdapter(sSQL, CurrProjDB.Connection)
            .SelectCommand.Parameters.Add("@EmailID", SqlDbType.Int).Value = EmailID
            .Fill(_dtFiles)
        End With

        ' Datagridview properties
        Dim dr As Integer = {_dtFiles.Rows.Count, 10}.Min() ' max of 10 rows of data
        Dim h As Integer = Convert.ToInt32(25 * _ScaleFactor)
        With Me.dgvFiles
            .Height = ((1 + dr) * h + 2) ' column header row + data rows + 2 for scroll bar
            .ColumnHeadersHeight = h
            .RowTemplate.Height = h
            .RowTemplate.ReadOnly = True

            .DataSource = _dtFiles
            .Columns("EmailID").Width = Convert.ToInt32(75 * _ScaleFactor)
            .Columns("EmailID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Seq").Width = Convert.ToInt32(50 * _ScaleFactor)
            .Columns("CreatedOn").Width = Convert.ToInt32(100 * _ScaleFactor)
            .Columns("CreatedBy").Width = Convert.ToInt32(128 * _ScaleFactor) ' +28 for vertical scroll bar
            .Columns("RFID").Visible = False
        End With

    End Sub

    Private Sub import_files(oFiles As List(Of FileInfo))

        ' Parse each filename to get the EmailID and create dictionary object
        Dim dict As New Dictionary(Of Integer, FileInfo)
        For Each oFile In oFiles
            Dim sEmailID = oFile.Name.Replace("EmailID ", "").Replace("_Redacted.pdf", "").Trim()
            Dim iEmailID As Integer = 0
            Integer.TryParse(sEmailID, iEmailID)
            If iEmailID > 0 Then dict(iEmailID) = oFile
        Next

        ' Confirm operation
        If MsgBox($"Import {dict.Count} file(s)?", vbYesNo + vbQuestion,
                  "Confirm Import") <> MsgBoxResult.Yes Then Exit Sub

        ' Add each file to the database if the EmailID exists in vRadactedFiles
        Dim iFailed As Integer = 0
        With CurrProjDB.Connection.CreateCommand()
            .Parameters.Add("@EmailID", SqlDbType.Int)
            .Parameters.Add("@FileName", SqlDbType.VarChar, 255)
            .Parameters.Add("@FilePath", SqlDbType.VarChar, 255)
            For Each iEmailID In dict.Keys
                .CommandText = $"EXEC dbo.fRedactedImport @EmailID, @FileName, @FilePath;"
                .Parameters("@EmailID").Value = iEmailID
                .Parameters("@FileName").Value = dict(iEmailID).Name
                .Parameters("@FilePath").Value = dict(iEmailID).FullName
                If (.ExecuteNonQuery()) < 1 Then iFailed += 1
            Next
        End With

        If iFailed > 0 Then MsgBox($"{iFailed} file(s) failed to import because no Redacted email exists.",
            vbOKOnly, "Redacted File Import Status")

        ' Refresh data table
        fill_emails_table()

    End Sub


End Class