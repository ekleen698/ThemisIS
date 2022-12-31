<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRedacted
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvEmails = New System.Windows.Forms.DataGridView()
        Me.dgvFiles = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuImportFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuImportFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExportAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExportSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdExpand = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvEmails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvEmails
        '
        Me.dgvEmails.AllowUserToAddRows = False
        Me.dgvEmails.AllowUserToDeleteRows = False
        Me.dgvEmails.AllowUserToResizeRows = False
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEmails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvEmails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEmails.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvEmails.Location = New System.Drawing.Point(12, 64)
        Me.dgvEmails.Name = "dgvEmails"
        Me.dgvEmails.RowHeadersVisible = False
        Me.dgvEmails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvEmails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmails.Size = New System.Drawing.Size(536, 452)
        Me.dgvEmails.TabIndex = 0
        '
        'dgvFiles
        '
        Me.dgvFiles.AllowUserToAddRows = False
        Me.dgvFiles.AllowUserToDeleteRows = False
        Me.dgvFiles.AllowUserToResizeRows = False
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFiles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFiles.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvFiles.Location = New System.Drawing.Point(588, 64)
        Me.dgvFiles.MultiSelect = False
        Me.dgvFiles.Name = "dgvFiles"
        Me.dgvFiles.RowHeadersVisible = False
        Me.dgvFiles.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Gainsboro
        Me.dgvFiles.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvFiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFiles.Size = New System.Drawing.Size(353, 248)
        Me.dgvFiles.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuImport, Me.mnuExport})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 1, 0, 1)
        Me.MenuStrip1.Size = New System.Drawing.Size(989, 25)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuImport
        '
        Me.mnuImport.AutoSize = False
        Me.mnuImport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuImportFolder, Me.mnuImportFiles})
        Me.mnuImport.Name = "mnuImport"
        Me.mnuImport.Size = New System.Drawing.Size(100, 25)
        Me.mnuImport.Text = "Import"
        Me.mnuImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mnuImportFolder
        '
        Me.mnuImportFolder.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuImportFolder.Name = "mnuImportFolder"
        Me.mnuImportFolder.Size = New System.Drawing.Size(120, 24)
        Me.mnuImportFolder.Text = "Folder"
        '
        'mnuImportFiles
        '
        Me.mnuImportFiles.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuImportFiles.Name = "mnuImportFiles"
        Me.mnuImportFiles.Size = New System.Drawing.Size(120, 24)
        Me.mnuImportFiles.Text = "Files"
        '
        'mnuExport
        '
        Me.mnuExport.AutoSize = False
        Me.mnuExport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExportAll, Me.mnuExportSelected})
        Me.mnuExport.Name = "mnuExport"
        Me.mnuExport.Size = New System.Drawing.Size(100, 25)
        Me.mnuExport.Text = "Export"
        Me.mnuExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mnuExportAll
        '
        Me.mnuExportAll.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuExportAll.Name = "mnuExportAll"
        Me.mnuExportAll.Size = New System.Drawing.Size(135, 24)
        Me.mnuExportAll.Text = "All"
        '
        'mnuExportSelected
        '
        Me.mnuExportSelected.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuExportSelected.Name = "mnuExportSelected"
        Me.mnuExportSelected.Size = New System.Drawing.Size(135, 24)
        Me.mnuExportSelected.Text = "Selected"
        '
        'cmdExpand
        '
        Me.cmdExpand.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExpand.ForeColor = System.Drawing.Color.SteelBlue
        Me.cmdExpand.Location = New System.Drawing.Point(472, 32)
        Me.cmdExpand.Name = "cmdExpand"
        Me.cmdExpand.Size = New System.Drawing.Size(76, 24)
        Me.cmdExpand.TabIndex = 3
        Me.cmdExpand.Text = "File List >>"
        Me.cmdExpand.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(588, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "(Double Click Row to Export)"
        '
        'frmRedacted
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(989, 536)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdExpand)
        Me.Controls.Add(Me.dgvFiles)
        Me.Controls.Add(Me.dgvEmails)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRedacted"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Redacted File Manager"
        CType(Me.dgvEmails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvEmails As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuImport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuImportFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuImportFiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExportSelected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExportAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvFiles As System.Windows.Forms.DataGridView
    Friend WithEvents cmdExpand As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
