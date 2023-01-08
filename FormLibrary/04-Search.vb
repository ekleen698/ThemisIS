Imports ClassLibrary.GlobalObjects
Imports System.Windows.Forms

Public Class frmSearch
    Private _iSearchOption As Integer = 1       '1=Any of These, 2=All of These, 3=Custom, 4=SQL
    Private _iViewOption As Integer = 1         '1=None, 2=Include Reviewed
    Private _iIncludeOption As Integer = 1      '1=Include, 2=Exclude
    Private _ScaleFactor As Single

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Create scale factor because value of 'AutoScaleDimensions' changes with screen resolution
        _ScaleFactor = Me.CurrentAutoScaleDimensions.Width / 96

    End Sub

    Private Sub frmBasicSearch_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Initialize form settings on load

        'Form properties
        Me.Text = $"Text Search"
        Me.MinimumSize = Me.Size

        ' Menu bar properties
        Dim w = Convert.ToInt32(150 * _ScaleFactor)
        Dim h = Convert.ToInt32(25 * _ScaleFactor)
        Dim MenuList = New List(Of ToolStripMenuItem) From {mnuViewEmails, mnuUpdateEmails}
        For Each itm In MenuList
            itm.Width = w
            itm.Height = h
        Next

        ' Initialize search options
        Me.optAny.Checked = True
        Me.optAll.Checked = False
        Me.optCustom.Checked = False
        Me.optSql.Checked = False

        ' Initialize include options
        Me.optInclude.Checked = True
        Me.optExclude.Checked = False

        ' Initialize Results label
        Me.lblNoResults.Visible = False

        ' Update text box with example for the current search option
        updateExample()


    End Sub

    Private Sub optAny_CheckedChanged(sender As Object, e As EventArgs) Handles optAny.CheckedChanged
        'Any of These

        If Me.optAny.Checked Then
            Me.chkSender.Enabled = True
            Me.chkTo.Enabled = True
            Me.chkSubject.Enabled = True
            Me.chkBody.Enabled = True
            Me.optInclude.Enabled = True
            Me.optExclude.Enabled = True
            Me.Panel1.Enabled = True

            _iSearchOption = 1
            updateExample()
        End If

    End Sub

    Private Sub optAll_CheckedChanged(sender As Object, e As EventArgs) Handles optAll.CheckedChanged
        'All of These

        If Me.optAll.Checked Then
            Me.chkSender.Enabled = True
            Me.chkTo.Enabled = True
            Me.chkSubject.Enabled = True
            Me.chkBody.Enabled = True
            Me.optInclude.Enabled = True
            Me.optExclude.Enabled = True
            Me.Panel1.Enabled = True

            _iSearchOption = 2
            updateExample()
        End If

    End Sub

    Private Sub optCustom_CheckedChanged(sender As Object, e As EventArgs) Handles optCustom.CheckedChanged
        ' Custom Search String

        If Me.optCustom.Checked Then
            Me.chkSender.Enabled = True
            Me.chkTo.Enabled = True
            Me.chkSubject.Enabled = True
            Me.chkBody.Enabled = True
            Me.optInclude.Enabled = True
            Me.optExclude.Enabled = True
            Me.Panel1.Enabled = True

            _iSearchOption = 3
            updateExample()
        End If

    End Sub

    Private Sub optSql_CheckedChanged(sender As Object, e As EventArgs) Handles optSql.CheckedChanged
        ' Custom Search String

        If Me.optSql.Checked Then
            ' Confirm usage of the SQL search option
            If MsgBox("This option should only be used when provided a SQL " &
                    "search string by the application admin." & vbCrLf & vbCrLf &
                    "Continue?", vbQuestion + vbYesNo, "Confirm Action") <> MsgBoxResult.Yes Then

                ' If cancelled, reset option button to previous
                optSql.Checked = False
                If _iSearchOption = 1 Then
                    optAny.Checked = True
                ElseIf _iSearchOption = 2 Then
                    optAll.Checked = True
                ElseIf _iSearchOption = 3 Then
                    optCustom.Checked = True
                End If
                ' Exit
                Exit Sub

            End If

            ' Disable selections not used in filter criteria
            Me.chkSender.Enabled = False
            Me.chkTo.Enabled = False
            Me.chkSubject.Enabled = False
            Me.chkBody.Enabled = False
            Me.optInclude.Enabled = False
            Me.optExclude.Enabled = False
            'Me.Panel1.Enabled = False

            _iSearchOption = 4
            updateExample()
        End If

    End Sub

    Private Sub optInclude_CheckedChanged(sender As Object, e As EventArgs) Handles optInclude.CheckedChanged
        ' View Options 'None'

        If Me.optInclude.Checked Then
            _iIncludeOption = 1
        End If

    End Sub

    Private Sub optExclude_CheckedChanged(sender As Object, e As EventArgs) Handles optExclude.CheckedChanged
        ' View Options 'None'

        If Me.optExclude.Checked Then
            _iIncludeOption = 2
        End If

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

    Private Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        ' Update email list, open email display form

        ' Use this to help identify how Full Text is parsing search terms
        ' select * from sys.dm_fts_parser('search_term', 1031, 0, 0);

        Try
            'Update DisplayEmailIDs, if it fails then exit
            If Not updateDisplayEmailIDs() Then Exit Sub

            'Open email display form
            With New frmEmail()
                .ShowDialog()
            End With

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "View Emails Error")

        End Try

    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        'Update email list, open bulk update form

        Try
            'Update DisplayEmailIDs, if it fails then exit
            If Not updateDisplayEmailIDs() Then Exit Sub

            'Open email update form
            With New frmSearchUpdate()
                .ShowDialog(Me)
            End With

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Update Emails Error")

        End Try

    End Sub

    Private Sub mnuViewEmails_Click(sender As Object, e As EventArgs) Handles mnuViewEmails.Click


    End Sub

    Private Sub mnuUpdateEmails_Click(sender As Object, e As EventArgs) Handles mnuUpdateEmails.Click


    End Sub

    Private Sub lblKeywords_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblKeywords.LinkClicked
        'Update email list, open bulk update form
        GlobalText = ""

        Try
            'Open email update form
            With New frmKeywords()
                .ShowDialog(Me)
            End With

            ' Append the keywords selected in frmPatternSearch to txtTerms
            If Me.txtTerms.TextLength = 0 Then
                Me.txtTerms.Text &= GlobalText
            Else
                Me.txtTerms.Text &= $"; {GlobalText}"
            End If

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Keyword Form Open Error")

        End Try


    End Sub

    Private Sub lblSearchString_LinkClicked(sender As Object,
                e As LinkLabelLinkClickedEventArgs) Handles lblSearchString.LinkClicked
        'Form search string and display in message box

        Dim sSearchString As String = ""

        'Call function to form search string and display message box
        sSearchString = formSearchString()
        If sSearchString <> "" Then
            MsgBox(sSearchString,, "Search String")
        End If

    End Sub

    Private Sub updateExample()
        'Update label displaying example text when a Search Type is selected

        Select Case _iSearchOption
            Case 1  'Any of These
                Me.lblExample.Text =
                    $"Search one or more terms or phrases at once, result includes any of the terms." &
                    vbCrLf & vbCrLf &
                    "Examples:" & vbCrLf &
                    "attorney; lawyer  ->  containing 'attorney' or 'lawyer'" & vbCrLf &
                    "attorney; law*    ->  containing 'attorney' or words beginning with 'law'" & vbCrLf &
                    "john smith; doe jane   -> containing 'john smith' or 'doe jane'"
                Exit Select
            Case 2  'All of These
                Me.lblExample.Text =
                    $"Search one or more terms or phrases at once, result must include all of the terms." &
                    vbCrLf & vbCrLf &
                    "Examples:" & vbCrLf &
                    "attorney; lawyer  ->  containing 'attorney' and 'lawyer'" & vbCrLf &
                    "attorney; law*    ->  containing 'attorney' and any word beginning with 'law'" & vbCrLf &
                    "john smith; doe jane   -> containing 'john smith' and 'doe jane'"
                Exit Select
            Case 3  'Custom
                Me.lblExample.Text =
                    $"Custom search string. See 'Full Text Rules.docx' for more information." &
                    vbCrLf & vbCrLf &
                    "Examples:" & vbCrLf &
                    "NEAR(john, smith)" & vbCrLf &
                    "NEAR((john, smith),1,True) AND NOT ""john a. smith"""
                Exit Select
            Case 4  'SQL
                Me.lblExample.Text =
                    $"This search uses a SQL string to search the Project Database." & vbCrLf &
                    "Only to be used when you have been provided a SQL string by the application admin." & vbCrLf &
                    "This function appends the selected text as an 'AND' clause."
                Exit Select
        End Select

    End Sub

    Private Function formFieldList() As String
        'Form string of fields to search, if no fields selected returns ""

        Dim sFields As String = ""
        'Dim sDefault = "ib.[Sender], ib.[SenderName], ib.[Recipients], ib.[To], ib.[CC], ib.[BCC], ib.[Subject], ib.[Body]"

        Try
            'Add selected fields to field list string
            'note: Recipients fields contains email address for To, CC, and BCC
            If Me.chkSender.Checked Then sFields += "ib.[Sender], ib.[SenderName], "
            If Me.chkTo.Checked Then sFields +=
                "ib.[To], ib.To_Name, ib.[CC], ib.CC_Name, ib.[BCC], ib.BCC_Name, ib.[Recipients], "
            If Me.chkSubject.Checked Then sFields += "ib.[Subject], "
            If Me.chkBody.Checked Then sFields += "ib.[Body], "

            If sFields.Length > 2 Then sFields = sFields.Remove(sFields.Length - 2) 'remove ', '

            Return sFields

        Catch
            Return ""

        End Try

    End Function

    Private Function formSearchString() As String
        'Form search string from input text, return "" if invalid
        '
        'rules for SQL Server Full Text Search:
        '  1) phrases enclosed with "" (e.g. "first last")
        '  2) terms separated by AND or OR (e.g. "term1" AND "term2")
        '  3) wildcard (*) only used at end of term (e.g. "ter*")
        '  4) not case sensitive

        Dim sTerms() As String
        Dim sInString = Me.txtTerms.Text.Trim
        Dim sOutString As String = ""

        If sInString.Length = 0 Then Return sOutString

        Try
            'Form search string based on which type of search is selected
            Select Case _iSearchOption
                Case 1  'Any of These
                    sTerms = Split(sInString.Trim, ";")
                    For Each sItm As String In sTerms
                        If Not validateTerm(sItm.Trim) Then Exit Select
                        'Wrap each term in "" and separate with OR
                        sOutString &= $"""{sItm.Trim}"" OR "
                    Next
                    sOutString = sOutString.Remove(sOutString.Length - 4)
                    Exit Select
                Case 2  'All of These
                    sTerms = Split(sInString, ";")
                    For Each sItm As String In sTerms
                        If Not validateTerm(sItm.Trim) Then Exit Select
                        'Wrap each term in "" and separate with AND
                        sOutString &= $"""{sItm.Trim}"" AND "
                    Next
                    sOutString = sOutString.Remove(sOutString.Length - 5)
                    Exit Select
                Case 3  'Custom
                    If Not validateCustom(sInString) Then
                        Exit Select
                    End If
                    sOutString = sInString
                    Exit Select
                Case 4  'SQL
                    sOutString = sInString
                    Exit Select
            End Select

            Return sOutString

        Catch
            Return ""

        End Try

    End Function

    Private Function validateCustom(sSearchString As String) As Boolean
        ' For option 3, test search string to make sure it is valid

        Dim bResult As Boolean
        Dim sSQL As String = $"SELECT TOP 1 ib.EmailID
                    FROM dbo.Inbox ib
                    WHERE CONTAINS((ib.Sender), '{sSearchString}');"    ' for troubleshooting

        Try
            ' Attempt to query database with search string
            With CurrProjDB.Connection.CreateCommand
                .CommandText = sSQL
                .ExecuteNonQuery()
            End With

            ' Test succeeded
            bResult = True

        Catch ex As Exception
            ' Test failed
            bResult = False

        End Try

        Return bResult

    End Function

    Private Function validateTerm(sTerm As String) As Boolean
        'For options 1 and 2, validate each term before adding to search string
        'Throws exception

        Dim sTestTerm As String = ""
        Dim bResult As Boolean = False

        'Remove last character to check remaining for '*'
        If sTerm.Length > 1 Then
            sTestTerm = sTerm.Remove(sTerm.Length - 1)
        Else
            sTestTerm = ""
        End If
        If sTestTerm.Contains("*") Then
            'Ensure '*' only located at end of term
            MsgBox($"'*' can only be used at the end of a search term and" & vbCrLf &
                        "cannot be used with Exact Phrase search.")

        Else
            bResult = True

        End If

        Return bResult

    End Function

    Private Function updateDisplayEmailIDs() As Boolean
        'Update DisplayEmailIDs

        Dim bResult As Boolean = False
        Dim sFieldList As String = ""
        Dim sSearchString As String = ""
        Dim sWhere As String = ""
        Dim bUnreviewed = Me.chkUnreviewed.Checked
        Dim bReviewed = Me.chkReviewed.Checked
        Dim sTypes As String = ""
        Dim bFlagged = False
        Dim iFilterOption As Integer = 0
        Dim iCount As Integer = 0

        Me.lblNoResults.Visible = False

        'Get search terms from text box and field list from selected items
        sSearchString = formSearchString()
        sFieldList = formFieldList()

        ' Validate selections
        If sSearchString = "" Then
            MsgBox("Search string is not valid.",, "Invalid Operation")
            Return bResult
        ElseIf (sFieldList = "" And _iSearchOption <> 4) Then
            MsgBox("No Search Fields selected.",, "Invalid Operation")
            Return bResult
        End If

        ' If View Option is 'Reviewed', create Types list
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

        If _iSearchOption <> 4 Then
            ' Escape single quote in text string 
            sSearchString = sSearchString.Replace("'", "''")

            ' Include or Exclude option
            If _iIncludeOption = 1 Then
                sWhere = $"CONTAINS(({sFieldList}), '{sSearchString}')"
            ElseIf _iIncludeOption = 2 Then
                sWhere = $"NOT CONTAINS(({sFieldList}), '{sSearchString}')"
            End If

        Else
            ' SQL search uses the text string exactly as is wrapped in an 'AND' statement
            sWhere = $"{sSearchString}"
        End If

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
            Me.lblNoResults.Visible = True
        Else
            bResult = True
        End If

        Return bResult

    End Function

    Private Sub cmdGetSize_Click(sender As Object, e As EventArgs) Handles cmdGetSize.Click
        MsgBox(Me.Size.ToString)
    End Sub

End Class