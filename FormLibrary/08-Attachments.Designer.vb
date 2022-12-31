<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAttachments
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmdRedact = New System.Windows.Forms.Button()
        Me.cmdNonResponsive = New System.Windows.Forms.Button()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.cmdExempt = New System.Windows.Forms.Button()
        Me.cmdProduce = New System.Windows.Forms.Button()
        Me.dgvAttachments = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkMarkAll = New System.Windows.Forms.CheckBox()
        CType(Me.dgvAttachments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdRedact
        '
        Me.cmdRedact.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRedact.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRedact.Location = New System.Drawing.Point(648, 171)
        Me.cmdRedact.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdRedact.Name = "cmdRedact"
        Me.cmdRedact.Size = New System.Drawing.Size(122, 27)
        Me.cmdRedact.TabIndex = 33
        Me.cmdRedact.Text = "Redact"
        Me.cmdRedact.UseVisualStyleBackColor = True
        '
        'cmdNonResponsive
        '
        Me.cmdNonResponsive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdNonResponsive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNonResponsive.Location = New System.Drawing.Point(648, 97)
        Me.cmdNonResponsive.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdNonResponsive.Name = "cmdNonResponsive"
        Me.cmdNonResponsive.Size = New System.Drawing.Size(122, 27)
        Me.cmdNonResponsive.TabIndex = 32
        Me.cmdNonResponsive.Text = "Non-Responsive"
        Me.cmdNonResponsive.UseVisualStyleBackColor = False
        '
        'cmdReset
        '
        Me.cmdReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReset.Location = New System.Drawing.Point(648, 210)
        Me.cmdReset.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(122, 27)
        Me.cmdReset.TabIndex = 31
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'cmdExempt
        '
        Me.cmdExempt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExempt.Location = New System.Drawing.Point(648, 135)
        Me.cmdExempt.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdExempt.Name = "cmdExempt"
        Me.cmdExempt.Size = New System.Drawing.Size(122, 27)
        Me.cmdExempt.TabIndex = 30
        Me.cmdExempt.Text = "Exempt"
        Me.cmdExempt.UseVisualStyleBackColor = True
        '
        'cmdProduce
        '
        Me.cmdProduce.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdProduce.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProduce.Location = New System.Drawing.Point(648, 61)
        Me.cmdProduce.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdProduce.Name = "cmdProduce"
        Me.cmdProduce.Size = New System.Drawing.Size(122, 27)
        Me.cmdProduce.TabIndex = 29
        Me.cmdProduce.Text = "Produce"
        Me.cmdProduce.UseVisualStyleBackColor = False
        '
        'dgvAttachments
        '
        Me.dgvAttachments.AllowUserToAddRows = False
        Me.dgvAttachments.AllowUserToDeleteRows = False
        Me.dgvAttachments.AllowUserToResizeRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAttachments.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAttachments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAttachments.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvAttachments.Location = New System.Drawing.Point(25, 38)
        Me.dgvAttachments.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvAttachments.Name = "dgvAttachments"
        Me.dgvAttachments.ReadOnly = True
        Me.dgvAttachments.RowHeadersVisible = False
        Me.dgvAttachments.RowHeadersWidth = 62
        Me.dgvAttachments.RowTemplate.Height = 28
        Me.dgvAttachments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvAttachments.Size = New System.Drawing.Size(577, 199)
        Me.dgvAttachments.TabIndex = 34
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(24, 243)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(451, 15)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Note: Message files (.msg) are included in emails and not treated as attachments." &
    ""
        '
        'chkMarkAll
        '
        Me.chkMarkAll.AutoSize = True
        Me.chkMarkAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMarkAll.Location = New System.Drawing.Point(657, 19)
        Me.chkMarkAll.Margin = New System.Windows.Forms.Padding(2)
        Me.chkMarkAll.Name = "chkMarkAll"
        Me.chkMarkAll.Size = New System.Drawing.Size(104, 34)
        Me.chkMarkAll.TabIndex = 36
        Me.chkMarkAll.Text = "Mark All " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Attachments"
        Me.chkMarkAll.UseVisualStyleBackColor = True
        '
        'frmAttachments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(785, 273)
        Me.Controls.Add(Me.chkMarkAll)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvAttachments)
        Me.Controls.Add(Me.cmdRedact)
        Me.Controls.Add(Me.cmdNonResponsive)
        Me.Controls.Add(Me.cmdReset)
        Me.Controls.Add(Me.cmdExempt)
        Me.Controls.Add(Me.cmdProduce)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmAttachments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmAttachments"
        CType(Me.dgvAttachments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdRedact As System.Windows.Forms.Button
    Friend WithEvents cmdNonResponsive As System.Windows.Forms.Button
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents cmdExempt As System.Windows.Forms.Button
    Friend WithEvents cmdProduce As System.Windows.Forms.Button
    Friend WithEvents dgvAttachments As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkMarkAll As System.Windows.Forms.CheckBox
End Class
