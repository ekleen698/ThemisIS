Imports ClassLibrary
Imports ClassLibrary.GlobalObjects
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data.SqlClient


Public Class frmKeywords

    Private _dtComboTerms As New DataTable
    Private _dtDGVTerms As New DataTable
    Private _iViewOption As Integer = 1 '1=None, 2=Include Reviewed
    Private _ScaleFactor As Single

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Create scale factor because value of 'AutoScaleDimensions' changes with screen resolution
        _ScaleFactor = Me.CurrentAutoScaleDimensions.Width / 96

    End Sub

    Private Sub frmPatternSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Initialize form settings on load

        'Form properties
        Me.Text = $"Advanced Text Search"
        Me.MinimumSize = Me.Size

        'Add search terms from DisplayTerms table to combobox
        FillComboTerms()

        'Initialize view options, also fills _ftDGCTerms with an empty row
        Me.optNone.Checked = True
        Me.optReviewed.Checked = False

        'Datagridview properties
        With Me.dgvTerms
            .DataSource = _dtDGVTerms
            .Columns("Select").Width = Convert.ToInt32(53 * _ScaleFactor)
            .Columns("Keyword").Width = Convert.ToInt32(267 * _ScaleFactor)
            .Columns("Keyword").ReadOnly = True
            .Columns("Sender").Width = Convert.ToInt32(60 * _ScaleFactor)
            .Columns("Sender").ReadOnly = True
            .Columns("To/CC/BCC").Width = Convert.ToInt32(75 * _ScaleFactor)
            .Columns("To/CC/BCC").ReadOnly = True
            .Columns("Subject").Width = Convert.ToInt32(60 * _ScaleFactor)
            .Columns("Subject").ReadOnly = True
            .Columns("Body").Width = Convert.ToInt32(50 * _ScaleFactor)
            .Columns("Body").ReadOnly = True
            .Columns("Emails").Width = Convert.ToInt32(60 * _ScaleFactor)
            .Columns("Emails").ReadOnly = True
            .Sort(.Columns("Emails"), ListSortDirection.Descending)
        End With

    End Sub

    Private Sub frmPatternSearch_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Clean up data tables on form close

        Try
            _dtComboTerms.Dispose()
            _dtDGVTerms.Dispose()

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Form Close Error")
            Logger.WriteToLog($"{ex.GetType} occurred while closing Advanced Search form.")
            Logger.WriteToLog(ex.ToString)

        End Try

    End Sub

    Private Sub cmdKeywords_Click(sender As Object, e As EventArgs) Handles cmdKeywords.Click

        Dim sTerm As String

        'Validate input string 
        sTerm = Me.cmbSearch.Text
        If Len(sTerm) = 0 Then
            MsgBox("No Search Term.",, "Invalid Operation")
            Exit Sub
        End If

        Try
            Cursor.Current = Cursors.WaitCursor

            ' 1) add SearchTerms table
            ' 2) below, add item to SearchTerms if it doesn't exist, then exec fDisplayterms
            ' 3) change fDisplayTerms to iterate over all items in SearchTerms
            ' 4) add step after Import Emails to replace all rows in DisplayTerms
            ' 5) add step after Import emails to update progress bar to 'Updating Display terms'


            With CurrProjDB.Connection.CreateCommand
                'Insert new row into dbo.SearchTerms if the current term does not exist
                .CommandText = $"IF NOT EXISTS(SELECT 1 FROM dbo.SearchTerms WHERE search_term=@Term)
	                            INSERT INTO dbo.SearchTerms(search_term)
	                            VALUES(@Term);"
                .Parameters.Add("@Term", SqlDbType.VarChar, 255).Value = sTerm.ToLower
                .ExecuteNonQuery()

                'Iterate all terms in SearchTerms and update DisplayTerms for new search terms
                .Parameters.Clear()
                .CommandTimeout = (New ClassLibrary.My.MySettings).TimeOutSeconds
                .CommandText = $"EXEC dbo.fDisplayTerms @Database;"
                .Parameters.Add("@Database", SqlDbType.NVarChar, 50).Value = CurrProjDB.Name
                .ExecuteNonQuery()
            End With

            'Update datatables for combobox and dgv objects
            FillDGVTerms(sTerm)
            FillComboTerms()

        Catch ex As Exception
            Logger.WriteToLog($"{ex.GetType} occurred while performing keyword search.")
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Keyword Search Error")

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Sub

    Private Sub optNone_CheckedChanged(sender As Object, e As EventArgs) Handles optNone.CheckedChanged

        If Me.optNone.Checked Then
            _iViewOption = 1
            FillDGVTerms(Me.cmbSearch.Text)
        End If

    End Sub

    Private Sub optReviewed_CheckedChanged(sender As Object, e As EventArgs) Handles optReviewed.CheckedChanged

        If Me.optReviewed.Checked Then
            _iViewOption = 2
            FillDGVTerms(Me.cmbSearch.Text)
        End If

    End Sub

    Private Sub cmdCopy_Click(sender As Object, e As EventArgs) Handles cmdCopy.Click

        Dim result() As DataRow
        Dim sKeywords = ""

        ' Get rows of selected keywords, if nothing selected exit
        result = _dtDGVTerms.Select("Select=True")
        If result.Count = 0 Then
            MsgBox("Nothing Selected", vbOKOnly, "Invalid Operation")
            Exit Sub
        End If

        'Create search term list for sql query
        For Each row As DataRow In result
            'replace single quote with escaped quote, needed for sp processing
            sKeywords &= $"{row("Keyword").ToString()}; "
        Next
        If sKeywords.Length > 2 Then
            sKeywords = sKeywords.Remove(sKeywords.Length - 2) 'remove '; '
        End If

        ' Global string used by BasicSearch to append keywords to search string
        GlobalText = sKeywords

        Me.Close()

    End Sub

    Private Sub cmdSelectAll_Click(sender As Object, e As EventArgs) Handles cmdSelectAll.Click
        'Select all rows in dgv object

        For Each row As DataRow In _dtDGVTerms.Rows
            row("Select") = 1
        Next

    End Sub

    Private Sub cmdSelectNone_Click(sender As Object, e As EventArgs) Handles cmdSelectNone.Click
        'Unselect all rows in dgv object

        For Each row As DataRow In _dtDGVTerms.Rows
            row("Select") = 0
        Next

    End Sub

    Private Sub lblHelp_Click(sender As Object, e As EventArgs) Handles lblHelp.Click
        'Display message box when 'Help' label clicked

        Dim sText As String

        sText = "Display keywords which match the selected text pattern." & vbCrLf & vbCrLf &
            "Examples:" & vbCrLf &
            "ExampleWord -> Searches for keywords that EXACTLY MATCH the word." & vbCrLf &
            "Example% -> Searches for keywords that BEGIN WITH certain characters." & vbCrLf &
            "%Word -> Searches for keywords that END WITH certain characters." & vbCrLf &
            "Ex%leW%rd -> Searches for keywords that MATCH a pattern."

        MsgBox(sText, , "Search Help")

    End Sub

    Private Sub FillComboTerms()
        'Refresh combo box data table with all previously used search terms in DisplayTerms
        'Throws exception

        Dim sSQL As String
        Dim sText As String = Me.cmbSearch.Text

        'Clear all items from the datatable
        Me.cmbSearch.DataSource = Nothing
        _dtComboTerms.Clear()

        'Fill datatable with all search terms previously used
        sSQL = $"SELECT DISTINCT [search_term]
            FROM dbo.SearchTerms;"
        With New SqlDataAdapter(sSQL, CurrProjDB.Connection)
            .Fill(_dtComboTerms)
        End With

        With Me.cmbSearch
            .DataSource = _dtComboTerms
            .DisplayMember = _dtComboTerms.Columns("search_term").ToString
            .ValueMember = _dtComboTerms.Columns("search_term").ToString
            .Text = ""
        End With

        _dtComboTerms.DefaultView.Sort = "search_term ASC"
        _dtComboTerms = _dtComboTerms.DefaultView.ToTable

        Me.cmbSearch.Text = sText

    End Sub

    Private Sub FillDGVTerms(sTerm As String)
        'Refresh the datagridview object
        'Throws exception

        Dim sSQL As String

        _dtDGVTerms.Clear()

        sSQL =
            $"SELECT CAST('False' AS BIT) AS [Select]
	            , t1.[display_term] AS [Keyword] 
	            , SUM(IIF(t2.[Sender]>0,1,0)) [Sender]
	            , SUM(IIF(t2.[To/CC/BCC]>0,1,0)) [To/CC/BCC]
	            , SUM(IIF(t2.[Subject]>0,1,0)) [Subject]
	            , SUM(IIF(t2.[Body]>0,1,0)) [Body]
	            , COUNT(DISTINCT t1.EmailID) [Emails]
            FROM (
	            SELECT DISTINCT search_term, display_term, EmailID
	            FROM dbo.DisplayTerms
	            ) t1
            JOIN (
	            SELECT search_term, display_term, EmailID 
		            , SUM(IIF(t.[column_name] IN ('Sender', 'SenderName'),1,0)) [Sender]
		            , SUM(IIF(t.[column_name] IN ('To', 'To_Name', 'CC', 'CC_Name', 'BCC', 'BCC_Name'),1,0)) [To/CC/BCC]
		            , SUM(IIF(t.[column_name] IN ('Subject'),1,0)) [Subject]
		            , SUM(IIF(t.[column_name] IN ('Body'),1,0)) [Body]
	            FROM dbo.DisplayTerms t
	            GROUP BY search_term, display_term, EmailID 
	            ) t2 on t1.EmailID=t2.EmailID and t1.display_term=t2.display_term and t1.search_term=t2.search_term
            WHERE 1=1
            AND t1.search_term = @Term
            AND t1.EmailID IN (SELECT EmailID FROM dbo.Inbox WHERE Duplicate=0)  "

        If _iViewOption = 1 Then
            sSQL &= "AND t1.EmailID NOT IN (SELECT EmailID FROM dbo.EmailExemptStatus) "
        End If

        sSQL &= "GROUP BY t1.display_term;"

        With New SqlDataAdapter(sSQL, CurrProjDB.Connection)
            .SelectCommand.Parameters.Add("@Term", SqlDbType.VarChar, 255).Value = sTerm
            .Fill(_dtDGVTerms)
        End With

    End Sub

End Class