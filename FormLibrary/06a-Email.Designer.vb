<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEmail
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmail))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblEmailID = New System.Windows.Forms.Label()
        Me.lblNumEmails = New System.Windows.Forms.Label()
        Me.lblAttachments = New System.Windows.Forms.Label()
        Me.txtSentOn = New System.Windows.Forms.TextBox()
        Me.txtFrom = New System.Windows.Forms.RichTextBox()
        Me.txtTo = New System.Windows.Forms.RichTextBox()
        Me.txtCC = New System.Windows.Forms.RichTextBox()
        Me.txtBCC = New System.Windows.Forms.RichTextBox()
        Me.txtSubject = New System.Windows.Forms.RichTextBox()
        Me.txtBody = New System.Windows.Forms.RichTextBox()
        Me.txtFind = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cmdFind = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdPrevious = New System.Windows.Forms.Button()
        Me.cmdAttachments = New System.Windows.Forms.Button()
        Me.cmdMarkAsEmail = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdProduce = New System.Windows.Forms.Button()
        Me.cmdNonResponsive = New System.Windows.Forms.Button()
        Me.cmdExempt = New System.Windows.Forms.Button()
        Me.cmdRedact = New System.Windows.Forms.Button()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.cmdOutlook = New System.Windows.Forms.Button()
        Me.cmdGetSize = New System.Windows.Forms.Button()
        Me.chkFlag = New System.Windows.Forms.CheckBox()
        Me.dgvAttachments = New System.Windows.Forms.DataGridView()
        Me.ttFrmEmail = New System.Windows.Forms.ToolTip(Me.components)
        Me.picInfo = New System.Windows.Forms.PictureBox()
        Me.txtFromName = New System.Windows.Forms.RichTextBox()
        Me.txtToName = New System.Windows.Forms.RichTextBox()
        Me.txtFlag = New System.Windows.Forms.RichTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmdExport = New System.Windows.Forms.Button()
        CType(Me.dgvAttachments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Sent"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 39)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "From"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 86)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "To"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 131)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "cc"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 155)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "bcc"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 181)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 17)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Subject"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 205)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 17)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Body"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEmailID
        '
        Me.lblEmailID.AutoSize = True
        Me.lblEmailID.BackColor = System.Drawing.Color.Transparent
        Me.lblEmailID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmailID.Location = New System.Drawing.Point(253, 12)
        Me.lblEmailID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblEmailID.Name = "lblEmailID"
        Me.lblEmailID.Size = New System.Drawing.Size(78, 15)
        Me.lblEmailID.TabIndex = 18
        Me.lblEmailID.Text = "Email ID: xxx"
        Me.lblEmailID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNumEmails
        '
        Me.lblNumEmails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNumEmails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumEmails.Location = New System.Drawing.Point(898, 6)
        Me.lblNumEmails.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblNumEmails.Name = "lblNumEmails"
        Me.lblNumEmails.Size = New System.Drawing.Size(125, 21)
        Me.lblNumEmails.TabIndex = 12
        Me.lblNumEmails.Text = "xx of xxxx Email(s)"
        Me.lblNumEmails.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAttachments
        '
        Me.lblAttachments.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAttachments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAttachments.Location = New System.Drawing.Point(462, 8)
        Me.lblAttachments.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAttachments.Name = "lblAttachments"
        Me.lblAttachments.Size = New System.Drawing.Size(93, 21)
        Me.lblAttachments.TabIndex = 27
        Me.lblAttachments.Text = "Attachments:"
        Me.lblAttachments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSentOn
        '
        Me.txtSentOn.BackColor = System.Drawing.SystemColors.Window
        Me.txtSentOn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSentOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSentOn.Location = New System.Drawing.Point(83, 12)
        Me.txtSentOn.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSentOn.Name = "txtSentOn"
        Me.txtSentOn.ReadOnly = True
        Me.txtSentOn.Size = New System.Drawing.Size(149, 21)
        Me.txtSentOn.TabIndex = 0
        '
        'txtFrom
        '
        Me.txtFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFrom.BackColor = System.Drawing.SystemColors.Window
        Me.txtFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFrom.Location = New System.Drawing.Point(83, 61)
        Me.txtFrom.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.ReadOnly = True
        Me.txtFrom.Size = New System.Drawing.Size(367, 20)
        Me.txtFrom.TabIndex = 2
        Me.txtFrom.Text = ""
        '
        'txtTo
        '
        Me.txtTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTo.BackColor = System.Drawing.SystemColors.Window
        Me.txtTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTo.Location = New System.Drawing.Point(83, 109)
        Me.txtTo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.ReadOnly = True
        Me.txtTo.Size = New System.Drawing.Size(367, 20)
        Me.txtTo.TabIndex = 4
        Me.txtTo.Text = ""
        '
        'txtCC
        '
        Me.txtCC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCC.BackColor = System.Drawing.SystemColors.Window
        Me.txtCC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCC.Location = New System.Drawing.Point(83, 133)
        Me.txtCC.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCC.Name = "txtCC"
        Me.txtCC.ReadOnly = True
        Me.txtCC.Size = New System.Drawing.Size(367, 20)
        Me.txtCC.TabIndex = 5
        Me.txtCC.Text = ""
        '
        'txtBCC
        '
        Me.txtBCC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBCC.BackColor = System.Drawing.SystemColors.Window
        Me.txtBCC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBCC.Location = New System.Drawing.Point(83, 157)
        Me.txtBCC.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBCC.Name = "txtBCC"
        Me.txtBCC.ReadOnly = True
        Me.txtBCC.Size = New System.Drawing.Size(367, 20)
        Me.txtBCC.TabIndex = 6
        Me.txtBCC.Text = ""
        '
        'txtSubject
        '
        Me.txtSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubject.BackColor = System.Drawing.SystemColors.Window
        Me.txtSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubject.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubject.Location = New System.Drawing.Point(83, 183)
        Me.txtSubject.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.ReadOnly = True
        Me.txtSubject.Size = New System.Drawing.Size(807, 20)
        Me.txtSubject.TabIndex = 7
        Me.txtSubject.Text = ""
        '
        'txtBody
        '
        Me.txtBody.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBody.BackColor = System.Drawing.SystemColors.Window
        Me.txtBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBody.DetectUrls = False
        Me.txtBody.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBody.Location = New System.Drawing.Point(83, 208)
        Me.txtBody.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBody.Name = "txtBody"
        Me.txtBody.ReadOnly = True
        Me.txtBody.Size = New System.Drawing.Size(809, 328)
        Me.txtBody.TabIndex = 8
        Me.txtBody.Text = ""
        '
        'txtFind
        '
        Me.txtFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFind.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFind.Location = New System.Drawing.Point(606, 8)
        Me.txtFind.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(192, 24)
        Me.txtFind.TabIndex = 35
        Me.txtFind.TabStop = False
        Me.txtFind.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFind.WordWrap = False
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.LemonChiffon
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(605, 7)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(199, 26)
        Me.TextBox1.TabIndex = 37
        Me.TextBox1.TabStop = False
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox1.WordWrap = False
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
        Me.cmdFind.Location = New System.Drawing.Point(808, 8)
        Me.cmdFind.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(49, 25)
        Me.cmdFind.TabIndex = 32
        Me.cmdFind.TabStop = False
        Me.cmdFind.Text = "Find"
        Me.cmdFind.UseVisualStyleBackColor = False
        '
        'cmdNext
        '
        Me.cmdNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdNext.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.cmdNext.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.cmdNext.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark
        Me.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(966, 32)
        Me.cmdNext.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(39, 30)
        Me.cmdNext.TabIndex = 6
        Me.cmdNext.TabStop = False
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
        Me.cmdPrevious.Location = New System.Drawing.Point(911, 32)
        Me.cmdPrevious.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(39, 30)
        Me.cmdPrevious.TabIndex = 7
        Me.cmdPrevious.TabStop = False
        Me.cmdPrevious.Text = "<"
        Me.cmdPrevious.UseVisualStyleBackColor = False
        '
        'cmdAttachments
        '
        Me.cmdAttachments.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAttachments.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAttachments.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdAttachments.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.cmdAttachments.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAttachments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cmdAttachments.Location = New System.Drawing.Point(905, 70)
        Me.cmdAttachments.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdAttachments.Name = "cmdAttachments"
        Me.cmdAttachments.Size = New System.Drawing.Size(113, 39)
        Me.cmdAttachments.TabIndex = 29
        Me.cmdAttachments.TabStop = False
        Me.cmdAttachments.Text = "Review Attachments"
        Me.cmdAttachments.UseVisualStyleBackColor = False
        '
        'cmdMarkAsEmail
        '
        Me.cmdMarkAsEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdMarkAsEmail.BackColor = System.Drawing.SystemColors.Control
        Me.cmdMarkAsEmail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdMarkAsEmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.cmdMarkAsEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMarkAsEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMarkAsEmail.Location = New System.Drawing.Point(905, 115)
        Me.cmdMarkAsEmail.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdMarkAsEmail.Name = "cmdMarkAsEmail"
        Me.cmdMarkAsEmail.Size = New System.Drawing.Size(113, 25)
        Me.cmdMarkAsEmail.TabIndex = 30
        Me.cmdMarkAsEmail.TabStop = False
        Me.cmdMarkAsEmail.Text = "Mark As Email"
        Me.ttFrmEmail.SetToolTip(Me.cmdMarkAsEmail, "Mark all attachments with same review status as email.")
        Me.cmdMarkAsEmail.UseVisualStyleBackColor = False
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdClear.Location = New System.Drawing.Point(867, 8)
        Me.cmdClear.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(20, 25)
        Me.cmdClear.TabIndex = 34
        Me.cmdClear.TabStop = False
        Me.cmdClear.Text = "X"
        Me.cmdClear.UseVisualStyleBackColor = False
        '
        'cmdProduce
        '
        Me.cmdProduce.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdProduce.BackColor = System.Drawing.SystemColors.Control
        Me.cmdProduce.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdProduce.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.cmdProduce.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdProduce.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProduce.Location = New System.Drawing.Point(905, 209)
        Me.cmdProduce.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdProduce.Name = "cmdProduce"
        Me.cmdProduce.Size = New System.Drawing.Size(113, 27)
        Me.cmdProduce.TabIndex = 19
        Me.cmdProduce.TabStop = False
        Me.cmdProduce.Text = "Produce"
        Me.cmdProduce.UseVisualStyleBackColor = False
        '
        'cmdNonResponsive
        '
        Me.cmdNonResponsive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdNonResponsive.BackColor = System.Drawing.SystemColors.Control
        Me.cmdNonResponsive.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdNonResponsive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.cmdNonResponsive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdNonResponsive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNonResponsive.Location = New System.Drawing.Point(905, 245)
        Me.cmdNonResponsive.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdNonResponsive.Name = "cmdNonResponsive"
        Me.cmdNonResponsive.Size = New System.Drawing.Size(113, 27)
        Me.cmdNonResponsive.TabIndex = 26
        Me.cmdNonResponsive.TabStop = False
        Me.cmdNonResponsive.Text = "Non-Responsive"
        Me.cmdNonResponsive.UseVisualStyleBackColor = False
        '
        'cmdExempt
        '
        Me.cmdExempt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExempt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdExempt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.cmdExempt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExempt.Location = New System.Drawing.Point(905, 283)
        Me.cmdExempt.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdExempt.Name = "cmdExempt"
        Me.cmdExempt.Size = New System.Drawing.Size(113, 27)
        Me.cmdExempt.TabIndex = 20
        Me.cmdExempt.TabStop = False
        Me.cmdExempt.Text = "Exempt"
        Me.cmdExempt.UseVisualStyleBackColor = True
        '
        'cmdRedact
        '
        Me.cmdRedact.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRedact.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdRedact.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.cmdRedact.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRedact.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRedact.Location = New System.Drawing.Point(905, 320)
        Me.cmdRedact.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdRedact.Name = "cmdRedact"
        Me.cmdRedact.Size = New System.Drawing.Size(113, 27)
        Me.cmdRedact.TabIndex = 28
        Me.cmdRedact.TabStop = False
        Me.cmdRedact.Text = "Redact"
        Me.cmdRedact.UseVisualStyleBackColor = True
        '
        'cmdReset
        '
        Me.cmdReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.cmdReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReset.Location = New System.Drawing.Point(905, 358)
        Me.cmdReset.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(113, 27)
        Me.cmdReset.TabIndex = 23
        Me.cmdReset.TabStop = False
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'cmdOutlook
        '
        Me.cmdOutlook.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOutlook.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdOutlook.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.cmdOutlook.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOutlook.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOutlook.Location = New System.Drawing.Point(905, 398)
        Me.cmdOutlook.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdOutlook.Name = "cmdOutlook"
        Me.cmdOutlook.Size = New System.Drawing.Size(113, 27)
        Me.cmdOutlook.TabIndex = 25
        Me.cmdOutlook.TabStop = False
        Me.cmdOutlook.Text = "Open in Outlook"
        Me.cmdOutlook.UseVisualStyleBackColor = True
        '
        'cmdGetSize
        '
        Me.cmdGetSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGetSize.Location = New System.Drawing.Point(16, 248)
        Me.cmdGetSize.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdGetSize.Name = "cmdGetSize"
        Me.cmdGetSize.Size = New System.Drawing.Size(64, 21)
        Me.cmdGetSize.TabIndex = 38
        Me.cmdGetSize.Text = "Get Size"
        Me.cmdGetSize.UseVisualStyleBackColor = True
        Me.cmdGetSize.Visible = False
        '
        'chkFlag
        '
        Me.chkFlag.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkFlag.AutoSize = True
        Me.chkFlag.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFlag.Location = New System.Drawing.Point(904, 181)
        Me.chkFlag.Margin = New System.Windows.Forms.Padding(2)
        Me.chkFlag.Name = "chkFlag"
        Me.chkFlag.Size = New System.Drawing.Size(95, 19)
        Me.chkFlag.TabIndex = 36
        Me.chkFlag.TabStop = False
        Me.chkFlag.Text = "Flag Email"
        Me.ttFrmEmail.SetToolTip(Me.chkFlag, "Some Comment Here")
        Me.chkFlag.UseVisualStyleBackColor = True
        '
        'dgvAttachments
        '
        Me.dgvAttachments.AllowUserToAddRows = False
        Me.dgvAttachments.AllowUserToDeleteRows = False
        Me.dgvAttachments.AllowUserToResizeRows = False
        Me.dgvAttachments.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAttachments.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAttachments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAttachments.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAttachments.Location = New System.Drawing.Point(462, 38)
        Me.dgvAttachments.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvAttachments.Name = "dgvAttachments"
        Me.dgvAttachments.ReadOnly = True
        Me.dgvAttachments.RowHeadersVisible = False
        Me.dgvAttachments.RowHeadersWidth = 62
        Me.dgvAttachments.RowTemplate.Height = 28
        Me.dgvAttachments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvAttachments.Size = New System.Drawing.Size(428, 135)
        Me.dgvAttachments.TabIndex = 17
        Me.dgvAttachments.TabStop = False
        '
        'ttFrmEmail
        '
        Me.ttFrmEmail.AutoPopDelay = 30000
        Me.ttFrmEmail.InitialDelay = 500
        Me.ttFrmEmail.ReshowDelay = 100
        '
        'picInfo
        '
        Me.picInfo.BackgroundImage = Global.FormLibrary.My.Resources.Resources.info_24
        Me.picInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picInfo.Location = New System.Drawing.Point(12, 4)
        Me.picInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.picInfo.Name = "picInfo"
        Me.picInfo.Size = New System.Drawing.Size(24, 24)
        Me.picInfo.TabIndex = 44
        Me.picInfo.TabStop = False
        Me.ttFrmEmail.SetToolTip(Me.picInfo, resources.GetString("picInfo.ToolTip"))
        '
        'txtFromName
        '
        Me.txtFromName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFromName.BackColor = System.Drawing.SystemColors.Window
        Me.txtFromName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFromName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFromName.Location = New System.Drawing.Point(83, 37)
        Me.txtFromName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFromName.Name = "txtFromName"
        Me.txtFromName.ReadOnly = True
        Me.txtFromName.Size = New System.Drawing.Size(367, 20)
        Me.txtFromName.TabIndex = 1
        Me.txtFromName.Text = ""
        '
        'txtToName
        '
        Me.txtToName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtToName.BackColor = System.Drawing.SystemColors.Window
        Me.txtToName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtToName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtToName.Location = New System.Drawing.Point(83, 85)
        Me.txtToName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtToName.Name = "txtToName"
        Me.txtToName.ReadOnly = True
        Me.txtToName.Size = New System.Drawing.Size(367, 20)
        Me.txtToName.TabIndex = 3
        Me.txtToName.Text = ""
        '
        'txtFlag
        '
        Me.txtFlag.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFlag.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFlag.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFlag.Location = New System.Drawing.Point(84, 540)
        Me.txtFlag.Name = "txtFlag"
        Me.txtFlag.ReadOnly = True
        Me.txtFlag.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtFlag.Size = New System.Drawing.Size(808, 36)
        Me.txtFlag.TabIndex = 45
        Me.txtFlag.TabStop = False
        Me.txtFlag.Text = ""
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 536)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 17)
        Me.Label8.TabIndex = 46
        Me.Label8.Text = "Flag"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdExport
        '
        Me.cmdExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.cmdExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExport.Location = New System.Drawing.Point(904, 488)
        Me.cmdExport.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(113, 40)
        Me.cmdExport.TabIndex = 47
        Me.cmdExport.TabStop = False
        Me.cmdExport.Text = "Export " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Redacted"
        Me.cmdExport.UseVisualStyleBackColor = True
        '
        'frmEmail
        '
        Me.AcceptButton = Me.cmdFind
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1034, 581)
        Me.Controls.Add(Me.cmdExport)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtFlag)
        Me.Controls.Add(Me.picInfo)
        Me.Controls.Add(Me.txtToName)
        Me.Controls.Add(Me.txtFromName)
        Me.Controls.Add(Me.txtFrom)
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.txtCC)
        Me.Controls.Add(Me.txtBCC)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.txtBody)
        Me.Controls.Add(Me.cmdGetSize)
        Me.Controls.Add(Me.chkFlag)
        Me.Controls.Add(Me.txtFind)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.cmdMarkAsEmail)
        Me.Controls.Add(Me.cmdAttachments)
        Me.Controls.Add(Me.cmdRedact)
        Me.Controls.Add(Me.lblAttachments)
        Me.Controls.Add(Me.cmdNonResponsive)
        Me.Controls.Add(Me.cmdOutlook)
        Me.Controls.Add(Me.cmdReset)
        Me.Controls.Add(Me.cmdExempt)
        Me.Controls.Add(Me.cmdProduce)
        Me.Controls.Add(Me.lblEmailID)
        Me.Controls.Add(Me.dgvAttachments)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblNumEmails)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdPrevious)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSentOn)
        Me.Controls.Add(Me.TextBox1)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(25, 25)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmEmail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmEmail"
        CType(Me.dgvAttachments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtFrom As System.Windows.Forms.RichTextBox
    Friend WithEvents txtTo As System.Windows.Forms.RichTextBox
    Friend WithEvents txtCC As System.Windows.Forms.RichTextBox
    Friend WithEvents txtBCC As System.Windows.Forms.RichTextBox
    Friend WithEvents txtSubject As System.Windows.Forms.RichTextBox
    Friend WithEvents txtBody As System.Windows.Forms.RichTextBox
    Friend WithEvents txtSentOn As System.Windows.Forms.TextBox
    Friend WithEvents txtFind As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblNumEmails As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgvAttachments As System.Windows.Forms.DataGridView
    Friend WithEvents lblEmailID As System.Windows.Forms.Label
    Friend WithEvents cmdProduce As System.Windows.Forms.Button
    Friend WithEvents cmdExempt As System.Windows.Forms.Button
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents cmdOutlook As System.Windows.Forms.Button
    Friend WithEvents cmdNonResponsive As System.Windows.Forms.Button
    Friend WithEvents lblAttachments As System.Windows.Forms.Label
    Friend WithEvents cmdRedact As System.Windows.Forms.Button
    Friend WithEvents cmdAttachments As System.Windows.Forms.Button
    Friend WithEvents cmdMarkAsEmail As System.Windows.Forms.Button
    Friend WithEvents ttFrmEmail As System.Windows.Forms.ToolTip
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents chkFlag As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cmdGetSize As System.Windows.Forms.Button
    Friend WithEvents txtFromName As System.Windows.Forms.RichTextBox
    Friend WithEvents txtToName As System.Windows.Forms.RichTextBox
    Friend WithEvents picInfo As System.Windows.Forms.PictureBox
    Friend WithEvents txtFlag As System.Windows.Forms.RichTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdExport As System.Windows.Forms.Button
End Class
