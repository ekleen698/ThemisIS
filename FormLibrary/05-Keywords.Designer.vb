<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmKeywords
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKeywords))
        Me.cmdKeywords = New System.Windows.Forms.Button()
        Me.cmbSearch = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNoResults = New System.Windows.Forms.Label()
        Me.dgvTerms = New System.Windows.Forms.DataGridView()
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.cmdSelectAll = New System.Windows.Forms.Button()
        Me.cmdSelectNone = New System.Windows.Forms.Button()
        Me.lblHelp = New System.Windows.Forms.Label()
        Me.optReviewed = New System.Windows.Forms.RadioButton()
        Me.optNone = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.dgvTerms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdKeywords
        '
        Me.cmdKeywords.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.cmdKeywords.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdKeywords.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdKeywords.Location = New System.Drawing.Point(390, 35)
        Me.cmdKeywords.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdKeywords.Name = "cmdKeywords"
        Me.cmdKeywords.Size = New System.Drawing.Size(113, 26)
        Me.cmdKeywords.TabIndex = 1
        Me.cmdKeywords.Text = "Show Keywords"
        Me.cmdKeywords.UseVisualStyleBackColor = False
        '
        'cmbSearch
        '
        Me.cmbSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearch.FormattingEnabled = True
        Me.cmbSearch.ItemHeight = 16
        Me.cmbSearch.Location = New System.Drawing.Point(37, 37)
        Me.cmbSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbSearch.Name = "cmbSearch"
        Me.cmbSearch.Size = New System.Drawing.Size(338, 24)
        Me.cmbSearch.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(34, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(237, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Select search term or enter new one"
        '
        'lblNoResults
        '
        Me.lblNoResults.AutoSize = True
        Me.lblNoResults.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoResults.ForeColor = System.Drawing.Color.Red
        Me.lblNoResults.Location = New System.Drawing.Point(404, 85)
        Me.lblNoResults.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblNoResults.Name = "lblNoResults"
        Me.lblNoResults.Size = New System.Drawing.Size(82, 18)
        Me.lblNoResults.TabIndex = 7
        Me.lblNoResults.Text = "No Results"
        Me.lblNoResults.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNoResults.Visible = False
        '
        'dgvTerms
        '
        Me.dgvTerms.AllowUserToAddRows = False
        Me.dgvTerms.AllowUserToDeleteRows = False
        Me.dgvTerms.AllowUserToResizeRows = False
        Me.dgvTerms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTerms.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTerms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTerms.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTerms.Location = New System.Drawing.Point(37, 107)
        Me.dgvTerms.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvTerms.Name = "dgvTerms"
        Me.dgvTerms.RowHeadersVisible = False
        Me.dgvTerms.RowHeadersWidth = 62
        Me.dgvTerms.RowTemplate.Height = 28
        Me.dgvTerms.Size = New System.Drawing.Size(630, 321)
        Me.dgvTerms.TabIndex = 8
        '
        'cmdCopy
        '
        Me.cmdCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(696, 197)
        Me.cmdCopy.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(123, 27)
        Me.cmdCopy.TabIndex = 9
        Me.cmdCopy.Text = "Copy Keywords"
        Me.cmdCopy.UseVisualStyleBackColor = True
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSelectAll.Location = New System.Drawing.Point(37, 79)
        Me.cmdSelectAll.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(73, 24)
        Me.cmdSelectAll.TabIndex = 10
        Me.cmdSelectAll.Text = "Select All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'cmdSelectNone
        '
        Me.cmdSelectNone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSelectNone.Location = New System.Drawing.Point(117, 79)
        Me.cmdSelectNone.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdSelectNone.Name = "cmdSelectNone"
        Me.cmdSelectNone.Size = New System.Drawing.Size(81, 24)
        Me.cmdSelectNone.TabIndex = 11
        Me.cmdSelectNone.Text = "Select None"
        Me.cmdSelectNone.UseVisualStyleBackColor = True
        '
        'lblHelp
        '
        Me.lblHelp.AutoSize = True
        Me.lblHelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHelp.ForeColor = System.Drawing.Color.Blue
        Me.lblHelp.Location = New System.Drawing.Point(345, 17)
        Me.lblHelp.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(29, 13)
        Me.lblHelp.TabIndex = 12
        Me.lblHelp.Text = "Help"
        '
        'optReviewed
        '
        Me.optReviewed.AutoSize = True
        Me.optReviewed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optReviewed.Location = New System.Drawing.Point(5, 43)
        Me.optReviewed.Margin = New System.Windows.Forms.Padding(2)
        Me.optReviewed.Name = "optReviewed"
        Me.optReviewed.Size = New System.Drawing.Size(122, 19)
        Me.optReviewed.TabIndex = 1
        Me.optReviewed.TabStop = True
        Me.optReviewed.Text = "Include Reviewed"
        Me.optReviewed.UseVisualStyleBackColor = True
        '
        'optNone
        '
        Me.optNone.AutoSize = True
        Me.optNone.Checked = True
        Me.optNone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optNone.Location = New System.Drawing.Point(5, 21)
        Me.optNone.Margin = New System.Windows.Forms.Padding(2)
        Me.optNone.Name = "optNone"
        Me.optNone.Size = New System.Drawing.Size(55, 19)
        Me.optNone.TabIndex = 0
        Me.optNone.TabStop = True
        Me.optNone.Text = "None"
        Me.optNone.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.optReviewed)
        Me.GroupBox3.Controls.Add(Me.optNone)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Size = New System.Drawing.Size(123, 65)
        Me.GroupBox3.TabIndex = 23
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "View Options"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Location = New System.Drawing.Point(691, 107)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(134, 75)
        Me.Panel1.TabIndex = 24
        '
        'frmKeywords
        '
        Me.AcceptButton = Me.cmdKeywords
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(852, 447)
        Me.Controls.Add(Me.lblHelp)
        Me.Controls.Add(Me.cmdSelectNone)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.dgvTerms)
        Me.Controls.Add(Me.lblNoResults)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbSearch)
        Me.Controls.Add(Me.cmdKeywords)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmKeywords"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Keyword Search"
        CType(Me.dgvTerms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdKeywords As System.Windows.Forms.Button
    Friend WithEvents cmbSearch As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNoResults As System.Windows.Forms.Label
    Friend WithEvents dgvTerms As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdSelectNone As System.Windows.Forms.Button
    Friend WithEvents lblHelp As System.Windows.Forms.Label
    Friend WithEvents optReviewed As System.Windows.Forms.RadioButton
    Friend WithEvents optNone As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
