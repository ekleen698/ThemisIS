<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEmail_Grouped
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtSentOn = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFrom = New System.Windows.Forms.TextBox()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdPrevious = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdProduce = New System.Windows.Forms.Button()
        Me.cmdExempt = New System.Windows.Forms.Button()
        Me.cmdViewEmail = New System.Windows.Forms.Button()
        Me.cmdNonResponsive = New System.Windows.Forms.Button()
        Me.cmdRedact = New System.Windows.Forms.Button()
        Me.ttMarkAsEmail = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgvEmails = New System.Windows.Forms.DataGridView()
        Me.lblEmailID = New System.Windows.Forms.Label()
        Me.cmdUpdateGroup = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdFind = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblNumEmails = New System.Windows.Forms.Label()
        Me.txtBody = New System.Windows.Forms.RichTextBox()
        Me.cmdGetSize = New System.Windows.Forms.Button()
        Me.txtFind = New System.Windows.Forms.TextBox()
        CType(Me.dgvEmails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSentOn
        '
        Me.txtSentOn.BackColor = System.Drawing.SystemColors.Window
        Me.txtSentOn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSentOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSentOn.Location = New System.Drawing.Point(61, 13)
        Me.txtSentOn.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSentOn.Name = "txtSentOn"
        Me.txtSentOn.ReadOnly = True
        Me.txtSentOn.Size = New System.Drawing.Size(173, 21)
        Me.txtSentOn.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Sent"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 40)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "From"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFrom
        '
        Me.txtFrom.BackColor = System.Drawing.SystemColors.Window
        Me.txtFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFrom.Location = New System.Drawing.Point(61, 38)
        Me.txtFrom.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.ReadOnly = True
        Me.txtFrom.Size = New System.Drawing.Size(381, 21)
        Me.txtFrom.TabIndex = 2
        '
        'cmdNext
        '
        Me.cmdNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdNext.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.cmdNext.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.cmdNext.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark
        Me.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(912, 43)
        Me.cmdNext.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(39, 29)
        Me.cmdNext.TabIndex = 6
        Me.cmdNext.Text = ">"
        Me.cmdNext.UseVisualStyleBackColor = False
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrevious.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.cmdPrevious.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.cmdPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark
        Me.cmdPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.Location = New System.Drawing.Point(865, 43)
        Me.cmdPrevious.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(39, 29)
        Me.cmdPrevious.TabIndex = 7
        Me.cmdPrevious.Text = "<"
        Me.cmdPrevious.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 64)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 17)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Subject"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSubject
        '
        Me.txtSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubject.BackColor = System.Drawing.SystemColors.Window
        Me.txtSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubject.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubject.Location = New System.Drawing.Point(61, 65)
        Me.txtSubject.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.ReadOnly = True
        Me.txtSubject.Size = New System.Drawing.Size(754, 21)
        Me.txtSubject.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 93)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 17)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Body"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdProduce
        '
        Me.cmdProduce.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdProduce.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.cmdProduce.Enabled = False
        Me.cmdProduce.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdProduce.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.cmdProduce.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdProduce.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProduce.Location = New System.Drawing.Point(847, 236)
        Me.cmdProduce.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdProduce.Name = "cmdProduce"
        Me.cmdProduce.Size = New System.Drawing.Size(124, 27)
        Me.cmdProduce.TabIndex = 19
        Me.cmdProduce.Text = "Produce"
        Me.cmdProduce.UseVisualStyleBackColor = False
        '
        'cmdExempt
        '
        Me.cmdExempt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExempt.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.cmdExempt.Enabled = False
        Me.cmdExempt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdExempt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.cmdExempt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExempt.Location = New System.Drawing.Point(847, 310)
        Me.cmdExempt.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdExempt.Name = "cmdExempt"
        Me.cmdExempt.Size = New System.Drawing.Size(124, 27)
        Me.cmdExempt.TabIndex = 20
        Me.cmdExempt.Text = "Exempt"
        Me.cmdExempt.UseVisualStyleBackColor = False
        '
        'cmdViewEmail
        '
        Me.cmdViewEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewEmail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdViewEmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.cmdViewEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdViewEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdViewEmail.Location = New System.Drawing.Point(847, 406)
        Me.cmdViewEmail.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdViewEmail.Name = "cmdViewEmail"
        Me.cmdViewEmail.Size = New System.Drawing.Size(124, 27)
        Me.cmdViewEmail.TabIndex = 25
        Me.cmdViewEmail.Text = "View Email"
        Me.cmdViewEmail.UseVisualStyleBackColor = True
        '
        'cmdNonResponsive
        '
        Me.cmdNonResponsive.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdNonResponsive.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.cmdNonResponsive.Enabled = False
        Me.cmdNonResponsive.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdNonResponsive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.cmdNonResponsive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdNonResponsive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNonResponsive.Location = New System.Drawing.Point(847, 272)
        Me.cmdNonResponsive.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdNonResponsive.Name = "cmdNonResponsive"
        Me.cmdNonResponsive.Size = New System.Drawing.Size(124, 27)
        Me.cmdNonResponsive.TabIndex = 26
        Me.cmdNonResponsive.Text = "Non-Responsive"
        Me.cmdNonResponsive.UseVisualStyleBackColor = False
        '
        'cmdRedact
        '
        Me.cmdRedact.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRedact.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.cmdRedact.Enabled = False
        Me.cmdRedact.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdRedact.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.cmdRedact.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRedact.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRedact.Location = New System.Drawing.Point(847, 346)
        Me.cmdRedact.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdRedact.Name = "cmdRedact"
        Me.cmdRedact.Size = New System.Drawing.Size(124, 27)
        Me.cmdRedact.TabIndex = 28
        Me.cmdRedact.Text = "Redact"
        Me.cmdRedact.UseVisualStyleBackColor = False
        '
        'dgvEmails
        '
        Me.dgvEmails.AllowUserToAddRows = False
        Me.dgvEmails.AllowUserToDeleteRows = False
        Me.dgvEmails.AllowUserToResizeRows = False
        Me.dgvEmails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEmails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvEmails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEmails.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvEmails.Location = New System.Drawing.Point(61, 288)
        Me.dgvEmails.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvEmails.MultiSelect = False
        Me.dgvEmails.Name = "dgvEmails"
        Me.dgvEmails.ReadOnly = True
        Me.dgvEmails.RowHeadersVisible = False
        Me.dgvEmails.RowHeadersWidth = 62
        Me.dgvEmails.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEmails.RowTemplate.Height = 20
        Me.dgvEmails.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEmails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvEmails.Size = New System.Drawing.Size(754, 205)
        Me.dgvEmails.TabIndex = 30
        '
        'lblEmailID
        '
        Me.lblEmailID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEmailID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmailID.Location = New System.Drawing.Point(855, 204)
        Me.lblEmailID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblEmailID.Name = "lblEmailID"
        Me.lblEmailID.Size = New System.Drawing.Size(111, 21)
        Me.lblEmailID.TabIndex = 31
        Me.lblEmailID.Text = "Email ID: xxx"
        Me.lblEmailID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdUpdateGroup
        '
        Me.cmdUpdateGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateGroup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdUpdateGroup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.cmdUpdateGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdUpdateGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdateGroup.Location = New System.Drawing.Point(847, 444)
        Me.cmdUpdateGroup.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdUpdateGroup.Name = "cmdUpdateGroup"
        Me.cmdUpdateGroup.Size = New System.Drawing.Size(124, 27)
        Me.cmdUpdateGroup.TabIndex = 32
        Me.cmdUpdateGroup.Text = "Update Group"
        Me.cmdUpdateGroup.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdClear.Location = New System.Drawing.Point(791, 16)
        Me.cmdClear.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(20, 25)
        Me.cmdClear.TabIndex = 39
        Me.cmdClear.Text = "X"
        Me.cmdClear.UseVisualStyleBackColor = False
        '
        'cmdFind
        '
        Me.cmdFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFind.BackColor = System.Drawing.Color.MidnightBlue
        Me.cmdFind.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue
        Me.cmdFind.FlatAppearance.BorderSize = 0
        Me.cmdFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFind.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdFind.Location = New System.Drawing.Point(732, 16)
        Me.cmdFind.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(49, 25)
        Me.cmdFind.TabIndex = 38
        Me.cmdFind.Text = "Find"
        Me.cmdFind.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.LemonChiffon
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(530, 13)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(199, 26)
        Me.TextBox1.TabIndex = 41
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox1.WordWrap = False
        '
        'lblNumEmails
        '
        Me.lblNumEmails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNumEmails.AutoSize = True
        Me.lblNumEmails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumEmails.Location = New System.Drawing.Point(855, 14)
        Me.lblNumEmails.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblNumEmails.Name = "lblNumEmails"
        Me.lblNumEmails.Size = New System.Drawing.Size(110, 15)
        Me.lblNumEmails.TabIndex = 42
        Me.lblNumEmails.Text = "xx of xxxx Group(s)"
        Me.lblNumEmails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtBody
        '
        Me.txtBody.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBody.BackColor = System.Drawing.SystemColors.Window
        Me.txtBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBody.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBody.Location = New System.Drawing.Point(61, 93)
        Me.txtBody.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBody.Name = "txtBody"
        Me.txtBody.ReadOnly = True
        Me.txtBody.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtBody.Size = New System.Drawing.Size(754, 175)
        Me.txtBody.TabIndex = 15
        Me.txtBody.Text = ""
        '
        'cmdGetSize
        '
        Me.cmdGetSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGetSize.Location = New System.Drawing.Point(886, 88)
        Me.cmdGetSize.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdGetSize.Name = "cmdGetSize"
        Me.cmdGetSize.Size = New System.Drawing.Size(64, 21)
        Me.cmdGetSize.TabIndex = 43
        Me.cmdGetSize.Text = "Get Size"
        Me.cmdGetSize.UseVisualStyleBackColor = True
        Me.cmdGetSize.Visible = False
        '
        'txtFind
        '
        Me.txtFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFind.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFind.Location = New System.Drawing.Point(531, 15)
        Me.txtFind.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(190, 24)
        Me.txtFind.TabIndex = 40
        Me.txtFind.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFind.WordWrap = False
        '
        'frmEmail_Grouped
        '
        Me.AcceptButton = Me.cmdFind
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1015, 525)
        Me.Controls.Add(Me.cmdGetSize)
        Me.Controls.Add(Me.lblNumEmails)
        Me.Controls.Add(Me.txtFind)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.cmdUpdateGroup)
        Me.Controls.Add(Me.lblEmailID)
        Me.Controls.Add(Me.dgvEmails)
        Me.Controls.Add(Me.cmdRedact)
        Me.Controls.Add(Me.cmdNonResponsive)
        Me.Controls.Add(Me.cmdViewEmail)
        Me.Controls.Add(Me.cmdExempt)
        Me.Controls.Add(Me.cmdProduce)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtBody)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.cmdPrevious)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFrom)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSentOn)
        Me.Location = New System.Drawing.Point(100, 100)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmEmail_Grouped"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Grouped Emails"
        CType(Me.dgvEmails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtSentOn As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFrom As System.Windows.Forms.TextBox
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdProduce As System.Windows.Forms.Button
    Friend WithEvents cmdExempt As System.Windows.Forms.Button
    Friend WithEvents cmdViewEmail As System.Windows.Forms.Button
    Friend WithEvents cmdNonResponsive As System.Windows.Forms.Button
    Friend WithEvents cmdRedact As System.Windows.Forms.Button
    Friend WithEvents ttMarkAsEmail As System.Windows.Forms.ToolTip
    Friend WithEvents dgvEmails As System.Windows.Forms.DataGridView
    Friend WithEvents lblEmailID As System.Windows.Forms.Label
    Friend WithEvents cmdUpdateGroup As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lblNumEmails As System.Windows.Forms.Label
    Friend WithEvents txtBody As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdGetSize As System.Windows.Forms.Button
    Friend WithEvents txtFind As System.Windows.Forms.TextBox
End Class
