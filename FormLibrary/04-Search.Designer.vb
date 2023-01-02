<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSearch
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.optAny = New System.Windows.Forms.RadioButton()
        Me.optAll = New System.Windows.Forms.RadioButton()
        Me.optCustom = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optSql = New System.Windows.Forms.RadioButton()
        Me.optExclude = New System.Windows.Forms.RadioButton()
        Me.txtTerms = New System.Windows.Forms.TextBox()
        Me.lblExample = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSearchString = New System.Windows.Forms.LinkLabel()
        Me.lblNoResults = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkSender = New System.Windows.Forms.CheckBox()
        Me.chkTo = New System.Windows.Forms.CheckBox()
        Me.chkBody = New System.Windows.Forms.CheckBox()
        Me.chkSubject = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdGetSize = New System.Windows.Forms.Button()
        Me.lblKeywords = New System.Windows.Forms.LinkLabel()
        Me.optInclude = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkFlagged = New System.Windows.Forms.CheckBox()
        Me.chkRedact = New System.Windows.Forms.CheckBox()
        Me.chkExempt = New System.Windows.Forms.CheckBox()
        Me.chkNonResponsive = New System.Windows.Forms.CheckBox()
        Me.chkProduce = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chkReviewed = New System.Windows.Forms.CheckBox()
        Me.chkUnreviewed = New System.Windows.Forms.CheckBox()
        Me.cmdView = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.mnuViewEmails = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUpdateEmails = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'optAny
        '
        Me.optAny.Checked = True
        Me.optAny.Location = New System.Drawing.Point(16, 24)
        Me.optAny.Margin = New System.Windows.Forms.Padding(2)
        Me.optAny.Name = "optAny"
        Me.optAny.Size = New System.Drawing.Size(115, 17)
        Me.optAny.TabIndex = 0
        Me.optAny.TabStop = True
        Me.optAny.Text = "Any Of These"
        Me.optAny.UseVisualStyleBackColor = True
        '
        'optAll
        '
        Me.optAll.Location = New System.Drawing.Point(148, 24)
        Me.optAll.Margin = New System.Windows.Forms.Padding(2)
        Me.optAll.Name = "optAll"
        Me.optAll.Size = New System.Drawing.Size(110, 17)
        Me.optAll.TabIndex = 1
        Me.optAll.Text = "All Of These"
        Me.optAll.UseVisualStyleBackColor = True
        '
        'optCustom
        '
        Me.optCustom.Location = New System.Drawing.Point(276, 24)
        Me.optCustom.Margin = New System.Windows.Forms.Padding(2)
        Me.optCustom.Name = "optCustom"
        Me.optCustom.Size = New System.Drawing.Size(93, 17)
        Me.optCustom.TabIndex = 2
        Me.optCustom.Text = "Custom"
        Me.optCustom.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optSql)
        Me.GroupBox1.Controls.Add(Me.optAny)
        Me.GroupBox1.Controls.Add(Me.optCustom)
        Me.GroupBox1.Controls.Add(Me.optAll)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(43, 85)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(450, 48)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search Type"
        '
        'optSql
        '
        Me.optSql.Location = New System.Drawing.Point(384, 24)
        Me.optSql.Margin = New System.Windows.Forms.Padding(2)
        Me.optSql.Name = "optSql"
        Me.optSql.Size = New System.Drawing.Size(60, 17)
        Me.optSql.TabIndex = 3
        Me.optSql.Text = "SQL"
        Me.optSql.UseVisualStyleBackColor = True
        '
        'optExclude
        '
        Me.optExclude.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optExclude.Location = New System.Drawing.Point(101, 5)
        Me.optExclude.Margin = New System.Windows.Forms.Padding(2)
        Me.optExclude.Name = "optExclude"
        Me.optExclude.Size = New System.Drawing.Size(106, 17)
        Me.optExclude.TabIndex = 27
        Me.optExclude.Text = "Exclude"
        Me.optExclude.UseVisualStyleBackColor = True
        '
        'txtTerms
        '
        Me.txtTerms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTerms.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTerms.Location = New System.Drawing.Point(43, 166)
        Me.txtTerms.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTerms.Multiline = True
        Me.txtTerms.Name = "txtTerms"
        Me.txtTerms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTerms.Size = New System.Drawing.Size(653, 132)
        Me.txtTerms.TabIndex = 4
        '
        'lblExample
        '
        Me.lblExample.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblExample.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblExample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblExample.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExample.Location = New System.Drawing.Point(41, 337)
        Me.lblExample.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblExample.Name = "lblExample"
        Me.lblExample.Size = New System.Drawing.Size(652, 102)
        Me.lblExample.TabIndex = 5
        Me.lblExample.Text = "Example"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 312)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(269, 19)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Note: all searches are NOT case sensitive"
        '
        'lblSearchString
        '
        Me.lblSearchString.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSearchString.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchString.Location = New System.Drawing.Point(720, 340)
        Me.lblSearchString.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSearchString.Name = "lblSearchString"
        Me.lblSearchString.Size = New System.Drawing.Size(113, 22)
        Me.lblSearchString.TabIndex = 8
        Me.lblSearchString.TabStop = True
        Me.lblSearchString.Text = "View Search String"
        Me.lblSearchString.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNoResults
        '
        Me.lblNoResults.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNoResults.AutoSize = True
        Me.lblNoResults.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoResults.ForeColor = System.Drawing.Color.Red
        Me.lblNoResults.Location = New System.Drawing.Point(609, 139)
        Me.lblNoResults.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblNoResults.Name = "lblNoResults"
        Me.lblNoResults.Size = New System.Drawing.Size(82, 18)
        Me.lblNoResults.TabIndex = 10
        Me.lblNoResults.Text = "No Results"
        Me.lblNoResults.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNoResults.Visible = False
        '
        'chkSender
        '
        Me.chkSender.AutoSize = True
        Me.chkSender.Checked = True
        Me.chkSender.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSender.Location = New System.Drawing.Point(17, 24)
        Me.chkSender.Margin = New System.Windows.Forms.Padding(2)
        Me.chkSender.Name = "chkSender"
        Me.chkSender.Size = New System.Drawing.Size(73, 20)
        Me.chkSender.TabIndex = 12
        Me.chkSender.Text = "Sender"
        Me.ToolTip1.SetToolTip(Me.chkSender, "Email address of sender")
        Me.chkSender.UseVisualStyleBackColor = True
        '
        'chkTo
        '
        Me.chkTo.AutoSize = True
        Me.chkTo.Checked = True
        Me.chkTo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTo.Location = New System.Drawing.Point(112, 24)
        Me.chkTo.Margin = New System.Windows.Forms.Padding(2)
        Me.chkTo.Name = "chkTo"
        Me.chkTo.Size = New System.Drawing.Size(99, 20)
        Me.chkTo.TabIndex = 14
        Me.chkTo.Text = "To/CC/BCC"
        Me.ToolTip1.SetToolTip(Me.chkTo, "Names of recipients")
        Me.chkTo.UseVisualStyleBackColor = True
        '
        'chkBody
        '
        Me.chkBody.AutoSize = True
        Me.chkBody.Checked = True
        Me.chkBody.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBody.Location = New System.Drawing.Point(327, 24)
        Me.chkBody.Margin = New System.Windows.Forms.Padding(2)
        Me.chkBody.Name = "chkBody"
        Me.chkBody.Size = New System.Drawing.Size(59, 20)
        Me.chkBody.TabIndex = 19
        Me.chkBody.Text = "Body"
        Me.ToolTip1.SetToolTip(Me.chkBody, "Body of email")
        Me.chkBody.UseVisualStyleBackColor = True
        '
        'chkSubject
        '
        Me.chkSubject.AutoSize = True
        Me.chkSubject.Checked = True
        Me.chkSubject.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSubject.Location = New System.Drawing.Point(231, 24)
        Me.chkSubject.Margin = New System.Windows.Forms.Padding(2)
        Me.chkSubject.Name = "chkSubject"
        Me.chkSubject.Size = New System.Drawing.Size(74, 20)
        Me.chkSubject.TabIndex = 18
        Me.chkSubject.Text = "Subject"
        Me.ToolTip1.SetToolTip(Me.chkSubject, "Subject line of email")
        Me.chkSubject.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkTo)
        Me.GroupBox2.Controls.Add(Me.chkBody)
        Me.GroupBox2.Controls.Add(Me.chkSender)
        Me.GroupBox2.Controls.Add(Me.chkSubject)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(43, 35)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(450, 51)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search Fields"
        '
        'cmdGetSize
        '
        Me.cmdGetSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGetSize.Location = New System.Drawing.Point(619, 52)
        Me.cmdGetSize.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdGetSize.Name = "cmdGetSize"
        Me.cmdGetSize.Size = New System.Drawing.Size(64, 21)
        Me.cmdGetSize.TabIndex = 39
        Me.cmdGetSize.Text = "Get Size"
        Me.cmdGetSize.UseVisualStyleBackColor = True
        Me.cmdGetSize.Visible = False
        '
        'lblKeywords
        '
        Me.lblKeywords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblKeywords.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKeywords.Location = New System.Drawing.Point(720, 368)
        Me.lblKeywords.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblKeywords.Name = "lblKeywords"
        Me.lblKeywords.Size = New System.Drawing.Size(92, 21)
        Me.lblKeywords.TabIndex = 26
        Me.lblKeywords.TabStop = True
        Me.lblKeywords.Text = "Use Keywords"
        Me.lblKeywords.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'optInclude
        '
        Me.optInclude.Checked = True
        Me.optInclude.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optInclude.Location = New System.Drawing.Point(16, 5)
        Me.optInclude.Margin = New System.Windows.Forms.Padding(2)
        Me.optInclude.Name = "optInclude"
        Me.optInclude.Size = New System.Drawing.Size(80, 17)
        Me.optInclude.TabIndex = 4
        Me.optInclude.TabStop = True
        Me.optInclude.Text = "Include"
        Me.optInclude.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.optInclude)
        Me.GroupBox4.Controls.Add(Me.optExclude)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(43, 133)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Size = New System.Drawing.Size(450, 27)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(718, 139)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(144, 152)
        Me.Panel2.TabIndex = 42
        Me.Panel2.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.chkFlagged)
        Me.GroupBox3.Controls.Add(Me.chkRedact)
        Me.GroupBox3.Controls.Add(Me.chkExempt)
        Me.GroupBox3.Controls.Add(Me.chkNonResponsive)
        Me.GroupBox3.Controls.Add(Me.chkProduce)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Size = New System.Drawing.Size(133, 141)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Filters"
        '
        'chkFlagged
        '
        Me.chkFlagged.AutoSize = True
        Me.chkFlagged.Location = New System.Drawing.Point(11, 115)
        Me.chkFlagged.Margin = New System.Windows.Forms.Padding(2)
        Me.chkFlagged.Name = "chkFlagged"
        Me.chkFlagged.Size = New System.Drawing.Size(71, 19)
        Me.chkFlagged.TabIndex = 0
        Me.chkFlagged.Text = "Flagged"
        Me.chkFlagged.UseVisualStyleBackColor = True
        '
        'chkRedact
        '
        Me.chkRedact.AutoSize = True
        Me.chkRedact.Checked = True
        Me.chkRedact.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRedact.Location = New System.Drawing.Point(11, 83)
        Me.chkRedact.Margin = New System.Windows.Forms.Padding(2)
        Me.chkRedact.Name = "chkRedact"
        Me.chkRedact.Size = New System.Drawing.Size(65, 19)
        Me.chkRedact.TabIndex = 3
        Me.chkRedact.Text = "Redact"
        Me.chkRedact.UseVisualStyleBackColor = True
        '
        'chkExempt
        '
        Me.chkExempt.AutoSize = True
        Me.chkExempt.Checked = True
        Me.chkExempt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkExempt.Location = New System.Drawing.Point(11, 63)
        Me.chkExempt.Margin = New System.Windows.Forms.Padding(2)
        Me.chkExempt.Name = "chkExempt"
        Me.chkExempt.Size = New System.Drawing.Size(68, 19)
        Me.chkExempt.TabIndex = 2
        Me.chkExempt.Text = "Exempt"
        Me.chkExempt.UseVisualStyleBackColor = True
        '
        'chkNonResponsive
        '
        Me.chkNonResponsive.AutoSize = True
        Me.chkNonResponsive.Checked = True
        Me.chkNonResponsive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNonResponsive.Location = New System.Drawing.Point(11, 43)
        Me.chkNonResponsive.Margin = New System.Windows.Forms.Padding(2)
        Me.chkNonResponsive.Name = "chkNonResponsive"
        Me.chkNonResponsive.Size = New System.Drawing.Size(117, 19)
        Me.chkNonResponsive.TabIndex = 1
        Me.chkNonResponsive.Text = "Non-Responsive"
        Me.chkNonResponsive.UseVisualStyleBackColor = True
        '
        'chkProduce
        '
        Me.chkProduce.AutoSize = True
        Me.chkProduce.Checked = True
        Me.chkProduce.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkProduce.Location = New System.Drawing.Point(11, 23)
        Me.chkProduce.Margin = New System.Windows.Forms.Padding(2)
        Me.chkProduce.Name = "chkProduce"
        Me.chkProduce.Size = New System.Drawing.Size(72, 19)
        Me.chkProduce.TabIndex = 0
        Me.chkProduce.Text = "Produce"
        Me.chkProduce.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(718, 40)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(144, 83)
        Me.Panel1.TabIndex = 41
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.chkReviewed)
        Me.GroupBox5.Controls.Add(Me.chkUnreviewed)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Size = New System.Drawing.Size(133, 72)
        Me.GroupBox5.TabIndex = 17
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "View Options"
        '
        'chkReviewed
        '
        Me.chkReviewed.AutoSize = True
        Me.chkReviewed.Location = New System.Drawing.Point(8, 45)
        Me.chkReviewed.Margin = New System.Windows.Forms.Padding(2)
        Me.chkReviewed.Name = "chkReviewed"
        Me.chkReviewed.Size = New System.Drawing.Size(80, 19)
        Me.chkReviewed.TabIndex = 5
        Me.chkReviewed.Text = "Reviewed"
        Me.chkReviewed.UseVisualStyleBackColor = True
        '
        'chkUnreviewed
        '
        Me.chkUnreviewed.AutoSize = True
        Me.chkUnreviewed.Checked = True
        Me.chkUnreviewed.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUnreviewed.Location = New System.Drawing.Point(8, 24)
        Me.chkUnreviewed.Margin = New System.Windows.Forms.Padding(2)
        Me.chkUnreviewed.Name = "chkUnreviewed"
        Me.chkUnreviewed.Size = New System.Drawing.Size(91, 19)
        Me.chkUnreviewed.TabIndex = 4
        Me.chkUnreviewed.Text = "Unreviewed"
        Me.chkUnreviewed.UseVisualStyleBackColor = True
        '
        'cmdView
        '
        Me.cmdView.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdView.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdView.Location = New System.Drawing.Point(488, 300)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(92, 28)
        Me.cmdView.TabIndex = 43
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.Location = New System.Drawing.Point(588, 300)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(92, 28)
        Me.cmdUpdate.TabIndex = 44
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'mnuViewEmails
        '
        Me.mnuViewEmails.AutoSize = False
        Me.mnuViewEmails.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.mnuViewEmails.Name = "mnuViewEmails"
        Me.mnuViewEmails.Size = New System.Drawing.Size(150, 25)
        Me.mnuViewEmails.Text = "View Emails"
        Me.mnuViewEmails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mnuUpdateEmails
        '
        Me.mnuUpdateEmails.AutoSize = False
        Me.mnuUpdateEmails.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.mnuUpdateEmails.Name = "mnuUpdateEmails"
        Me.mnuUpdateEmails.Size = New System.Drawing.Size(150, 25)
        Me.mnuUpdateEmails.Text = "Update Emails"
        Me.mnuUpdateEmails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewEmails, Me.mnuUpdateEmails})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 1, 0, 1)
        Me.MenuStrip1.Size = New System.Drawing.Size(900, 25)
        Me.MenuStrip1.TabIndex = 40
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'frmSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(900, 461)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.cmdView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmdGetSize)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.lblKeywords)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblNoResults)
        Me.Controls.Add(Me.lblSearchString)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblExample)
        Me.Controls.Add(Me.txtTerms)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Search"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents optAny As System.Windows.Forms.RadioButton
    Friend WithEvents optAll As System.Windows.Forms.RadioButton
    Friend WithEvents optCustom As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTerms As System.Windows.Forms.TextBox
    Friend WithEvents lblExample As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSearchString As System.Windows.Forms.LinkLabel
    Friend WithEvents lblNoResults As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents chkSender As System.Windows.Forms.CheckBox
    Friend WithEvents chkTo As System.Windows.Forms.CheckBox
    Friend WithEvents chkBody As System.Windows.Forms.CheckBox
    Friend WithEvents chkSubject As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGetSize As System.Windows.Forms.Button
    Friend WithEvents lblKeywords As System.Windows.Forms.LinkLabel
    Friend WithEvents optSql As System.Windows.Forms.RadioButton
    Friend WithEvents optExclude As System.Windows.Forms.RadioButton
    Friend WithEvents optInclude As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkFlagged As System.Windows.Forms.CheckBox
    Friend WithEvents chkRedact As System.Windows.Forms.CheckBox
    Friend WithEvents chkExempt As System.Windows.Forms.CheckBox
    Friend WithEvents chkNonResponsive As System.Windows.Forms.CheckBox
    Friend WithEvents chkProduce As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chkReviewed As System.Windows.Forms.CheckBox
    Friend WithEvents chkUnreviewed As System.Windows.Forms.CheckBox
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents mnuViewEmails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUpdateEmails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
End Class
