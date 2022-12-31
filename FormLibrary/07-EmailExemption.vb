Imports ClassLibrary.GlobalObjects
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class frmEmailExemption

    Private _dtExemptions As New DataTable  'Store rows from dbo.EmailExemptStatus
    Private _EmailID As Integer             'Current Email
    Private _ExemptionType As String        'Exemption or Redaction
    Private _Dirty As Boolean = False
    Private _ScaleFactor As Single

    Private Property Dirty As Boolean
        Get
            Return _Dirty
        End Get
        Set(value As Boolean)
            _Dirty = value
            Me.lblDirty.Visible = _Dirty
            Me.cmdSaveClose.Enabled = _Dirty

        End Set
    End Property

    Public Sub New(ExemptionType As String, Optional EmailID As Integer = -1)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _EmailID = EmailID
        _ExemptionType = ExemptionType

        ' Create scale factor because value of 'AutoScaleDimensions' changes with screen resolution
        _ScaleFactor = Me.CurrentAutoScaleDimensions.Width / 96

    End Sub

    Private Sub frmExemption_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim sSQL As String

        Try
            'Set form properties
            Me.Text = $"Select Email {_ExemptionType} Codes"
            Dim iLeft = {Me.Left - Convert.ToInt32(50 * _ScaleFactor), 0}.Max()
            Me.Left = iLeft
            Me.MaximumSize = Me.Size
            Me.MinimumSize = Me.Size

            'Fill data table
            sSQL = "
                SELECT 
                    CAST(IIF(st.[ExemptionID] IS NOT NULL, 1, 0) AS BIT) [Select] 
	                , ex.[ID]
                    , ex.[Exemption] AS [Reason] 
	                , IIF(st.[ExemptionID] IS NOT NULL, st.[Description], '') [Description]
                FROM dbo.[sys_Exemptions] ex
				JOIN dbo.[sys_ExemptionTypes] ty ON ex.[TypeID]=ty.[ID]
                LEFT JOIN (
                    SELECT [ExemptionID], [Description] 
                    FROM dbo.[EmailExemptStatus] 
                    WHERE [EmailID]=@EmailID) st ON ex.[ID]=st.[ExemptionID]
                WHERE ty.[Exemption_Type]=@ExemptionType
                ORDER BY ex.[ID];"
            With New SqlDataAdapter(sSQL, CurrProjDB.Connection)
                .SelectCommand.Parameters.Add("@EmailID", SqlDbType.Int).Value = _EmailID
                .SelectCommand.Parameters.Add("@ExemptionType", SqlDbType.VarChar, 20).Value = _ExemptionType
                .Fill(_dtExemptions)
            End With

            'Set properties of datagridview object
            With dgvExemptions
                .DataSource = _dtExemptions
                .RowTemplate.Height = Convert.ToInt32(40 * _ScaleFactor)
                .Columns("Select").Width = Convert.ToInt32(55 * _ScaleFactor)
                .Columns("Select").ReadOnly = True
                .Columns("ID").Visible = False
                .Columns("Reason").Width = Convert.ToInt32(233 * _ScaleFactor)
                .Columns("Reason").ReadOnly = True
                .Columns("Description").Width = Convert.ToInt32(525 * _ScaleFactor)
                .Columns("Description").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .Columns("Description").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
                .Sort(.Columns("ID"), ListSortDirection.Ascending)
                .ClearSelection()
            End With

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Form Load Error")

        End Try

    End Sub

    Private Sub frmExemption_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Cleanup class objects on form close event

        Try
            _dtExemptions.Dispose()

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Form Close Error")

        End Try

    End Sub

    Private Sub cmdSaveClose_Click(sender As Object, e As EventArgs) Handles cmdSaveClose.Click
        'Insert/Update row(s) in dbo.EmailExemptionStatus for all selected exemptions
        'Throws exception

        If Not Me.Dirty Then
            MsgBox("There are no changes to save.", vbOKOnly, "Invalid Operation")
            Exit Sub
        End If

        If _dtExemptions.Select("Select=True").Count = 0 Then
            ' Exit if no rows selected
            MsgBox("Nothing selected, Close to exit without saving.")
            Exit Sub
        Else
            For Each row As DataRow In _dtExemptions.Select("Select=True")
                If row("Reason").ToString = "Other" And Not row("Description").ToString.Trim.Length > 0 Then
                    ' Exit if not Description for 'Other'
                    MsgBox("A description is required for 'Other'.",, "Invalid Entry")
                    Exit Sub
                End If
            Next
        End If

        ' Create datatable for selected rows
        Dim dv = New DataView(_dtExemptions) With {
            .RowFilter = "Select=True"}
        Dim Selected = dv.ToTable(distinct:=True, {"ID", "Description"})

        ' Execute insert/update operations
        If _EmailID = -1 Then
            bulk_exemptions(Selected)
        Else
            single_exemption(Selected)
        End If

        Me.Close()

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        'Close current form

        Me.Close()

    End Sub

    Private Sub dgvExemptions_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExemptions.CellClick
        'Toggle Select check box when clicking on first column, enter edit mode when row selected

        Try
            If e.ColumnIndex = 0 Then
                If dgvExemptions.Rows(e.RowIndex).Cells(0).Value = 0 Then
                    'If cell unchecked then check, move to Description cell, and begin editing
                    dgvExemptions.Rows(e.RowIndex).Cells(0).Value = 1
                    dgvExemptions.CurrentCell = dgvExemptions.Rows(e.RowIndex).Cells("Description")
                    dgvExemptions.BeginEdit(True)
                Else
                    'if cell checked then uncheck and unselect row
                    dgvExemptions.Rows(e.RowIndex).Cells(0).Value = 0
                    dgvExemptions.ClearSelection()
                End If
            End If

        Catch

        End Try

    End Sub

    Private Sub dgvExemptions_CellStateChanged(sender As Object, e As DataGridViewCellStateChangedEventArgs) Handles dgvExemptions.CellStateChanged
        ' Don't allow selecting 'Reason' column

        If e.Cell.ColumnIndex = 2 Then e.Cell.Selected = False

    End Sub

    Private Sub dgvExemptions_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExemptions.CellValueChanged
        ' Set form property, shows 'Unsaved Changes' label and enables 'Save' button

        Me.Dirty = True

    End Sub

    Private Sub single_exemption(Selected As DataTable)
        ' Delete existing and insert new row(s) status table
        ' Throws Exception

        With CurrProjDB.Connection.CreateCommand
            .CommandText = "EXEC dbo.fEmailExemption @EmailID, @Exemptions;"
            .Parameters.Add("@EmailID", SqlDbType.Int).Value = _EmailID
            .Parameters.Add("@Exemptions", SqlDbType.Structured).Value = Selected
            .Parameters("@Exemptions").TypeName = "TVP"
            .ExecuteNonQuery()
        End With

    End Sub

    Private Sub bulk_exemptions(Selected As DataTable)
        ' Delete existing and insert new row(s) into dbo.EmailExemptStatus and dbo.AttachExemptStatus
        '   for all emails in search criteria

        With CurrProjDB.Connection.CreateCommand
            .Parameters.Add("@ID", SqlDbType.Int).Value = -1
            .Parameters.Add("@Exemptions", SqlDbType.Structured).Value = Selected
            .Parameters("@Exemptions").TypeName = "TVP"

            ' Emails
            .CommandText = "EXEC dbo.fEmailExemption @ID, @Exemptions;"
            .ExecuteNonQuery()

            ' Attachments
            .CommandText = "EXEC dbo.fAttachExemption @ID, @Exemptions;"
            .ExecuteNonQuery()

        End With

        MsgBox("Update Successful",, "Update Status")

    End Sub

    Private Sub cmdGetSize_Click(sender As Object, e As EventArgs) Handles cmdGetSize.Click
        MsgBox(Me.Size.ToString)
    End Sub

End Class