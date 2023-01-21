<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProjDetails
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProjDetails))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvPSTFiles = New System.Windows.Forms.DataGridView()
        Me.cmdSelectAll = New System.Windows.Forms.Button()
        Me.cmdSelectNone = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkReviewed = New System.Windows.Forms.CheckBox()
        Me.chkUnreviewed = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvTotals = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuPSTFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAddPSTFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuImportEmails = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRemovePSTFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewEmails = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewGroups = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSearchEmails = New System.Windows.Forms.ToolStripMenuItem()
        Me.ByEmailIDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEmailID = New System.Windows.Forms.ToolStripTextBox()
        Me.mnuSearchEmailID = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRedacted = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRedactedManage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExportProduce = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExportNonResponsive = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExportExemption = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExportRedaction = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbFilter = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkFlagged = New System.Windows.Forms.CheckBox()
        Me.chkRedact = New System.Windows.Forms.CheckBox()
        Me.chkExempt = New System.Windows.Forms.CheckBox()
        Me.chkNonResponsive = New System.Windows.Forms.CheckBox()
        Me.chkProduce = New System.Windows.Forms.CheckBox()
        Me.cmdUp = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dgvPSTFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvTotals, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 64)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "PST File Catalog"
        '
        'dgvPSTFiles
        '
        Me.dgvPSTFiles.AllowUserToAddRows = False
        Me.dgvPSTFiles.AllowUserToResizeRows = False
        Me.dgvPSTFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPSTFiles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPSTFiles.ColumnHeadersHeight = 34
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPSTFiles.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPSTFiles.Location = New System.Drawing.Point(27, 88)
        Me.dgvPSTFiles.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvPSTFiles.Name = "dgvPSTFiles"
        Me.dgvPSTFiles.RowHeadersVisible = False
        Me.dgvPSTFiles.RowHeadersWidth = 62
        Me.dgvPSTFiles.RowTemplate.Height = 33
        Me.dgvPSTFiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvPSTFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPSTFiles.Size = New System.Drawing.Size(623, 259)
        Me.dgvPSTFiles.TabIndex = 8
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSelectAll.Location = New System.Drawing.Point(27, 357)
        Me.cmdSelectAll.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(100, 29)
        Me.cmdSelectAll.TabIndex = 9
        Me.cmdSelectAll.Text = "Select All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'cmdSelectNone
        '
        Me.cmdSelectNone.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectNone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSelectNone.Location = New System.Drawing.Point(133, 357)
        Me.cmdSelectNone.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdSelectNone.Name = "cmdSelectNone"
        Me.cmdSelectNone.Size = New System.Drawing.Size(100, 29)
        Me.cmdSelectNone.TabIndex = 10
        Me.cmdSelectNone.Text = "Select None"
        Me.cmdSelectNone.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmbFilter)
        Me.GroupBox1.Controls.Add(Me.chkReviewed)
        Me.GroupBox1.Controls.Add(Me.chkUnreviewed)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(133, 107)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View Options"
        '
        'chkReviewed
        '
        Me.chkReviewed.AutoSize = True
        Me.chkReviewed.Location = New System.Drawing.Point(8, 77)
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
        Me.chkUnreviewed.Location = New System.Drawing.Point(8, 56)
        Me.chkUnreviewed.Margin = New System.Windows.Forms.Padding(2)
        Me.chkUnreviewed.Name = "chkUnreviewed"
        Me.chkUnreviewed.Size = New System.Drawing.Size(91, 19)
        Me.chkUnreviewed.TabIndex = 4
        Me.chkUnreviewed.Text = "Unreviewed"
        Me.chkUnreviewed.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(683, 40)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(144, 116)
        Me.Panel1.TabIndex = 19
        '
        'dgvTotals
        '
        Me.dgvTotals.AllowUserToAddRows = False
        Me.dgvTotals.AllowUserToResizeRows = False
        Me.dgvTotals.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTotals.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvTotals.ColumnHeadersHeight = 34
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTotals.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvTotals.Enabled = False
        Me.dgvTotals.Location = New System.Drawing.Point(251, 35)
        Me.dgvTotals.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvTotals.Name = "dgvTotals"
        Me.dgvTotals.RowHeadersVisible = False
        Me.dgvTotals.RowHeadersWidth = 62
        Me.dgvTotals.RowTemplate.Height = 33
        Me.dgvTotals.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvTotals.Size = New System.Drawing.Size(399, 45)
        Me.dgvTotals.TabIndex = 21
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPSTFiles, Me.mnuView, Me.mnuSearch, Me.mnuRedacted, Me.mnuExport})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 1, 0, 1)
        Me.MenuStrip1.Size = New System.Drawing.Size(857, 25)
        Me.MenuStrip1.TabIndex = 22
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuPSTFiles
        '
        Me.mnuPSTFiles.AutoSize = False
        Me.mnuPSTFiles.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAddPSTFiles, Me.mnuImportEmails, Me.mnuRemovePSTFiles})
        Me.mnuPSTFiles.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.mnuPSTFiles.Name = "mnuPSTFiles"
        Me.mnuPSTFiles.Size = New System.Drawing.Size(100, 25)
        Me.mnuPSTFiles.Text = "PST Files"
        Me.mnuPSTFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mnuAddPSTFiles
        '
        Me.mnuAddPSTFiles.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.mnuAddPSTFiles.Name = "mnuAddPSTFiles"
        Me.mnuAddPSTFiles.Size = New System.Drawing.Size(193, 24)
        Me.mnuAddPSTFiles.Text = "Add PST Files"
        '
        'mnuImportEmails
        '
        Me.mnuImportEmails.Enabled = False
        Me.mnuImportEmails.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.mnuImportEmails.Name = "mnuImportEmails"
        Me.mnuImportEmails.Size = New System.Drawing.Size(193, 24)
        Me.mnuImportEmails.Text = "Import Emails"
        '
        'mnuRemovePSTFiles
        '
        Me.mnuRemovePSTFiles.Enabled = False
        Me.mnuRemovePSTFiles.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.mnuRemovePSTFiles.Name = "mnuRemovePSTFiles"
        Me.mnuRemovePSTFiles.Size = New System.Drawing.Size(193, 24)
        Me.mnuRemovePSTFiles.Text = "Remove PST Files"
        '
        'mnuView
        '
        Me.mnuView.AutoSize = False
        Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewEmails, Me.mnuViewGroups})
        Me.mnuView.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Size = New System.Drawing.Size(100, 25)
        Me.mnuView.Text = "View"
        Me.mnuView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mnuViewEmails
        '
        Me.mnuViewEmails.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.mnuViewEmails.Name = "mnuViewEmails"
        Me.mnuViewEmails.Size = New System.Drawing.Size(125, 24)
        Me.mnuViewEmails.Text = "Emails"
        '
        'mnuViewGroups
        '
        Me.mnuViewGroups.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.mnuViewGroups.Name = "mnuViewGroups"
        Me.mnuViewGroups.Size = New System.Drawing.Size(125, 24)
        Me.mnuViewGroups.Text = "Groups"
        '
        'mnuSearch
        '
        Me.mnuSearch.AutoSize = False
        Me.mnuSearch.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSearchEmails, Me.ByEmailIDToolStripMenuItem})
        Me.mnuSearch.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.mnuSearch.Name = "mnuSearch"
        Me.mnuSearch.Size = New System.Drawing.Size(122, 25)
        Me.mnuSearch.Text = "Search"
        Me.mnuSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mnuSearchEmails
        '
        Me.mnuSearchEmails.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.mnuSearchEmails.Name = "mnuSearchEmails"
        Me.mnuSearchEmails.Size = New System.Drawing.Size(169, 24)
        Me.mnuSearchEmails.Text = "Search Emails"
        Me.mnuSearchEmails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ByEmailIDToolStripMenuItem
        '
        Me.ByEmailIDToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEmailID, Me.mnuSearchEmailID})
        Me.ByEmailIDToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.ByEmailIDToolStripMenuItem.Name = "ByEmailIDToolStripMenuItem"
        Me.ByEmailIDToolStripMenuItem.Size = New System.Drawing.Size(169, 24)
        Me.ByEmailIDToolStripMenuItem.Text = "By EmailID"
        '
        'mnuEmailID
        '
        Me.mnuEmailID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mnuEmailID.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.mnuEmailID.Name = "mnuEmailID"
        Me.mnuEmailID.Size = New System.Drawing.Size(100, 27)
        '
        'mnuSearchEmailID
        '
        Me.mnuSearchEmailID.BackColor = System.Drawing.SystemColors.Control
        Me.mnuSearchEmailID.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.mnuSearchEmailID.Name = "mnuSearchEmailID"
        Me.mnuSearchEmailID.Size = New System.Drawing.Size(160, 24)
        Me.mnuSearchEmailID.Text = "View Email"
        '
        'mnuRedacted
        '
        Me.mnuRedacted.AutoSize = False
        Me.mnuRedacted.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRedactedManage})
        Me.mnuRedacted.Name = "mnuRedacted"
        Me.mnuRedacted.Size = New System.Drawing.Size(100, 25)
        Me.mnuRedacted.Text = "Redacted"
        Me.mnuRedacted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mnuRedactedManage
        '
        Me.mnuRedactedManage.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.mnuRedactedManage.Name = "mnuRedactedManage"
        Me.mnuRedactedManage.Size = New System.Drawing.Size(180, 24)
        Me.mnuRedactedManage.Text = "Manage Files"
        '
        'mnuExport
        '
        Me.mnuExport.AutoSize = False
        Me.mnuExport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExportProduce, Me.mnuExportNonResponsive, Me.mnuExportExemption, Me.mnuExportRedaction})
        Me.mnuExport.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.mnuExport.Name = "mnuExport"
        Me.mnuExport.Size = New System.Drawing.Size(100, 25)
        Me.mnuExport.Text = "Export"
        Me.mnuExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mnuExportProduce
        '
        Me.mnuExportProduce.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.mnuExportProduce.Name = "mnuExportProduce"
        Me.mnuExportProduce.Size = New System.Drawing.Size(186, 24)
        Me.mnuExportProduce.Text = "Produce"
        Me.mnuExportProduce.ToolTipText = "Export Produce Emails/Attachments " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "when no Flagged Emails exist."
        '
        'mnuExportNonResponsive
        '
        Me.mnuExportNonResponsive.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.mnuExportNonResponsive.Name = "mnuExportNonResponsive"
        Me.mnuExportNonResponsive.Size = New System.Drawing.Size(186, 24)
        Me.mnuExportNonResponsive.Text = "Non-Responsive"
        Me.mnuExportNonResponsive.ToolTipText = "Export Non-Responsive Emails/Attachments " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "when no Flagged Emails exist." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'mnuExportExemption
        '
        Me.mnuExportExemption.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.mnuExportExemption.Name = "mnuExportExemption"
        Me.mnuExportExemption.Size = New System.Drawing.Size(186, 24)
        Me.mnuExportExemption.Text = "Exemption"
        Me.mnuExportExemption.ToolTipText = "Export Exempt Emails/Attachments " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "when no Flagged Emails exist."
        '
        'mnuExportRedaction
        '
        Me.mnuExportRedaction.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.mnuExportRedaction.Name = "mnuExportRedaction"
        Me.mnuExportRedaction.Size = New System.Drawing.Size(186, 24)
        Me.mnuExportRedaction.Text = "Redaction"
        Me.mnuExportRedaction.ToolTipText = "Export Redaction Emails/Attachments " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "when no Flagged Emails exist and all " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Reda" &
    "cted pdf files have been imported."
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(684, 172)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(144, 156)
        Me.Panel2.TabIndex = 20
        Me.Panel2.Visible = False
        '
        'cmbFilter
        '
        Me.cmbFilter.FormattingEnabled = True
        Me.cmbFilter.Items.AddRange(New Object() {"Emails and Attach.", "Emails Only", "Attach. Only"})
        Me.cmbFilter.Location = New System.Drawing.Point(3, 24)
        Me.cmbFilter.Name = "cmbFilter"
        Me.cmbFilter.Size = New System.Drawing.Size(128, 23)
        Me.cmbFilter.TabIndex = 18
        Me.cmbFilter.Text = "Emails and Attach."
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.chkFlagged)
        Me.GroupBox2.Controls.Add(Me.chkRedact)
        Me.GroupBox2.Controls.Add(Me.chkExempt)
        Me.GroupBox2.Controls.Add(Me.chkNonResponsive)
        Me.GroupBox2.Controls.Add(Me.chkProduce)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 8)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(133, 141)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filters"
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
        'cmdUp
        '
        Me.cmdUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUp.Location = New System.Drawing.Point(512, 365)
        Me.cmdUp.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdUp.Name = "cmdUp"
        Me.cmdUp.Size = New System.Drawing.Size(50, 21)
        Me.cmdUp.TabIndex = 23
        Me.cmdUp.Text = "Up"
        Me.cmdUp.UseVisualStyleBackColor = True
        Me.cmdUp.Visible = False
        '
        'cmdDown
        '
        Me.cmdDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDown.Location = New System.Drawing.Point(571, 365)
        Me.cmdDown.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(53, 21)
        Me.cmdDown.TabIndex = 24
        Me.cmdDown.Text = "Down"
        Me.cmdDown.UseVisualStyleBackColor = True
        Me.cmdDown.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(664, 368)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(712, 368)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Label3"
        Me.Label3.Visible = False
        '
        'frmProjDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(856, 396)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdUp)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.dgvTotals)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmdSelectNone)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.dgvPSTFiles)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimumSize = New System.Drawing.Size(857, 50)
        Me.Name = "frmProjDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Project Details"
        CType(Me.dgvPSTFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvTotals, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvPSTFiles As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdSelectNone As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvTotals As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuPSTFiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAddPSTFiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRemovePSTFiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuImportEmails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewEmails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewGroups As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSearchEmails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExportProduce As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExportNonResponsive As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExportExemption As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExportRedaction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkRedact As System.Windows.Forms.CheckBox
    Friend WithEvents chkExempt As System.Windows.Forms.CheckBox
    Friend WithEvents chkNonResponsive As System.Windows.Forms.CheckBox
    Friend WithEvents chkProduce As System.Windows.Forms.CheckBox
    Friend WithEvents chkFlagged As System.Windows.Forms.CheckBox
    Friend WithEvents chkReviewed As System.Windows.Forms.CheckBox
    Friend WithEvents chkUnreviewed As System.Windows.Forms.CheckBox
    Friend WithEvents cmdUp As System.Windows.Forms.Button
    Friend WithEvents cmdDown As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents mnuRedacted As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRedactedManage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ByEmailIDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEmailID As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents mnuSearchEmailID As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbFilter As System.Windows.Forms.ComboBox
End Class
