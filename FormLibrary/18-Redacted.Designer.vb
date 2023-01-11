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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRedacted))
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEmails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEmails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEmails.DefaultCellStyle = DataGridViewCellStyle2
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFiles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFiles.DefaultCellStyle = DataGridViewCellStyle4
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
        Me.mnuImportFolder.ToolTipText = "Import all Redacted files in selected folder."
        '
        'mnuImportFiles
        '
        Me.mnuImportFiles.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuImportFiles.Name = "mnuImportFiles"
        Me.mnuImportFiles.Size = New System.Drawing.Size(120, 24)
        Me.mnuImportFiles.Text = "Files"
        Me.mnuImportFiles.ToolTipText = "Import selected Redacted file(s) in selected folder. "
        '
        'mnuExport
        '
        Me.mnuExport.AutoSize = False
        Me.mnuExport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExportAll, Me.mnuExportSelected})
        Me.mnuExport.Name = "mnuExport"
        Me.mnuExport.Size = New System.Drawing.Size(125, 25)
        Me.mnuExport.Text = "Export Current"
        Me.mnuExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mnuExportAll
        '
        Me.mnuExportAll.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuExportAll.Name = "mnuExportAll"
        Me.mnuExportAll.Size = New System.Drawing.Size(135, 24)
        Me.mnuExportAll.Text = "All"
        Me.mnuExportAll.ToolTipText = "Export all items in Current File List."
        '
        'mnuExportSelected
        '
        Me.mnuExportSelected.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuExportSelected.Name = "mnuExportSelected"
        Me.mnuExportSelected.Size = New System.Drawing.Size(135, 24)
        Me.mnuExportSelected.Text = "Selected"
        Me.mnuExportSelected.ToolTipText = "Export one or more item(s) in Current File List."
        '
        'cmdExpand
        '
        Me.cmdExpand.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExpand.ForeColor = System.Drawing.Color.SteelBlue
        Me.cmdExpand.Location = New System.Drawing.Point(472, 32)
        Me.cmdExpand.Name = "cmdExpand"
        Me.cmdExpand.Size = New System.Drawing.Size(76, 24)
        Me.cmdExpand.TabIndex = 3
        Me.cmdExpand.Text = "History >>"
        Me.ToolTip1.SetToolTip(Me.cmdExpand, "Show all imported files for selected Email.")
        Me.cmdExpand.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(752, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "(Double Click Row to Export)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 24)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Current File List"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(588, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 24)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "File History"
        '
        'frmRedacted
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(989, 536)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdExpand)
        Me.Controls.Add(Me.dgvFiles)
        Me.Controls.Add(Me.dgvEmails)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
