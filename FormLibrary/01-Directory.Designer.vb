<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDirectory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDirectory))
        Me.lblServer = New System.Windows.Forms.Label()
        Me.cmdConnectServer = New System.Windows.Forms.Button()
        Me.cmdOpen = New System.Windows.Forms.Button()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblConnected = New System.Windows.Forms.Label()
        Me.cmdCreate = New System.Windows.Forms.Button()
        Me.cmdRemove = New System.Windows.Forms.Button()
        Me.lvProjects = New System.Windows.Forms.ListView()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdBackup = New System.Windows.Forms.Button()
        Me.cmdRestore = New System.Windows.Forms.Button()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.lblThemis = New System.Windows.Forms.Label()
        Me.cmdSettings = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lnkActivity = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServer.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblServer.Location = New System.Drawing.Point(21, 4)
        Me.lblServer.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(42, 15)
        Me.lblServer.TabIndex = 2
        Me.lblServer.Text = "Server"
        Me.lblServer.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdConnectServer
        '
        Me.cmdConnectServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdConnectServer.Location = New System.Drawing.Point(325, 20)
        Me.cmdConnectServer.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdConnectServer.Name = "cmdConnectServer"
        Me.cmdConnectServer.Size = New System.Drawing.Size(79, 27)
        Me.cmdConnectServer.TabIndex = 4
        Me.cmdConnectServer.Text = "Connect"
        Me.ToolTip1.SetToolTip(Me.cmdConnectServer, "Connect to server")
        Me.cmdConnectServer.UseVisualStyleBackColor = True
        '
        'cmdOpen
        '
        Me.cmdOpen.Enabled = False
        Me.cmdOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOpen.Location = New System.Drawing.Point(695, 76)
        Me.cmdOpen.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdOpen.Name = "cmdOpen"
        Me.cmdOpen.Size = New System.Drawing.Size(69, 27)
        Me.cmdOpen.TabIndex = 6
        Me.cmdOpen.Text = "Open"
        Me.ToolTip1.SetToolTip(Me.cmdOpen, "Open Project Details form")
        Me.cmdOpen.UseVisualStyleBackColor = True
        '
        'txtDescription
        '
        Me.txtDescription.Enabled = False
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(24, 268)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(644, 59)
        Me.txtDescription.TabIndex = 7
        '
        'lblConnected
        '
        Me.lblConnected.AutoSize = True
        Me.lblConnected.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConnected.ForeColor = System.Drawing.Color.Red
        Me.lblConnected.Location = New System.Drawing.Point(21, 48)
        Me.lblConnected.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblConnected.Name = "lblConnected"
        Me.lblConnected.Size = New System.Drawing.Size(156, 15)
        Me.lblConnected.TabIndex = 10
        Me.lblConnected.Text = "***Server Not Connected***"
        '
        'cmdCreate
        '
        Me.cmdCreate.Enabled = False
        Me.cmdCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCreate.Location = New System.Drawing.Point(695, 141)
        Me.cmdCreate.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCreate.Name = "cmdCreate"
        Me.cmdCreate.Size = New System.Drawing.Size(69, 27)
        Me.cmdCreate.TabIndex = 11
        Me.cmdCreate.Text = "Create"
        Me.ToolTip1.SetToolTip(Me.cmdCreate, "Create new Project")
        Me.cmdCreate.UseVisualStyleBackColor = True
        '
        'cmdRemove
        '
        Me.cmdRemove.Enabled = False
        Me.cmdRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemove.Location = New System.Drawing.Point(695, 237)
        Me.cmdRemove.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(69, 27)
        Me.cmdRemove.TabIndex = 12
        Me.cmdRemove.Text = "Remove"
        Me.ToolTip1.SetToolTip(Me.cmdRemove, "Delete Project from the Directory")
        Me.cmdRemove.UseVisualStyleBackColor = True
        '
        'lvProjects
        '
        Me.lvProjects.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvProjects.FullRowSelect = True
        Me.lvProjects.HideSelection = False
        Me.lvProjects.Location = New System.Drawing.Point(24, 76)
        Me.lvProjects.Margin = New System.Windows.Forms.Padding(2)
        Me.lvProjects.MultiSelect = False
        Me.lvProjects.Name = "lvProjects"
        Me.lvProjects.Size = New System.Drawing.Size(644, 179)
        Me.lvProjects.TabIndex = 13
        Me.lvProjects.UseCompatibleStateImageBehavior = False
        Me.lvProjects.View = System.Windows.Forms.View.Details
        '
        'cmdEdit
        '
        Me.cmdEdit.Enabled = False
        Me.cmdEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEdit.Location = New System.Drawing.Point(695, 108)
        Me.cmdEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(69, 27)
        Me.cmdEdit.TabIndex = 15
        Me.cmdEdit.Text = "Edit"
        Me.ToolTip1.SetToolTip(Me.cmdEdit, "Edit Project information")
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(695, 276)
        Me.cmdClose.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(69, 27)
        Me.cmdClose.TabIndex = 16
        Me.cmdClose.Text = "Close"
        Me.ToolTip1.SetToolTip(Me.cmdClose, "Close Themis Application")
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdBackup
        '
        Me.cmdBackup.Enabled = False
        Me.cmdBackup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBackup.Location = New System.Drawing.Point(695, 173)
        Me.cmdBackup.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdBackup.Name = "cmdBackup"
        Me.cmdBackup.Size = New System.Drawing.Size(69, 27)
        Me.cmdBackup.TabIndex = 18
        Me.cmdBackup.Text = "Backup"
        Me.ToolTip1.SetToolTip(Me.cmdBackup, "Backup Project to file")
        Me.cmdBackup.UseVisualStyleBackColor = True
        '
        'cmdRestore
        '
        Me.cmdRestore.Enabled = False
        Me.cmdRestore.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRestore.Location = New System.Drawing.Point(695, 205)
        Me.cmdRestore.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdRestore.Name = "cmdRestore"
        Me.cmdRestore.Size = New System.Drawing.Size(69, 27)
        Me.cmdRestore.TabIndex = 19
        Me.cmdRestore.Text = "Restore"
        Me.ToolTip1.SetToolTip(Me.cmdRestore, "Restore backup file")
        Me.cmdRestore.UseVisualStyleBackColor = True
        '
        'txtServer
        '
        Me.txtServer.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServer.Location = New System.Drawing.Point(24, 23)
        Me.txtServer.Margin = New System.Windows.Forms.Padding(2)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(268, 21)
        Me.txtServer.TabIndex = 20
        '
        'lblThemis
        '
        Me.lblThemis.AutoSize = True
        Me.lblThemis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThemis.Location = New System.Drawing.Point(256, 336)
        Me.lblThemis.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblThemis.Name = "lblThemis"
        Me.lblThemis.Size = New System.Drawing.Size(194, 15)
        Me.lblThemis.TabIndex = 21
        Me.lblThemis.Text = "Themis Information System vX.X.X"
        '
        'cmdSettings
        '
        Me.cmdSettings.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdSettings.BackgroundImage = Global.FormLibrary.My.Resources.Resources.gear_icon
        Me.cmdSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmdSettings.FlatAppearance.BorderSize = 0
        Me.cmdSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSettings.Location = New System.Drawing.Point(720, 11)
        Me.cmdSettings.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdSettings.MinimumSize = New System.Drawing.Size(37, 37)
        Me.cmdSettings.Name = "cmdSettings"
        Me.cmdSettings.Size = New System.Drawing.Size(37, 37)
        Me.cmdSettings.TabIndex = 22
        Me.ToolTip1.SetToolTip(Me.cmdSettings, "User Settings")
        Me.cmdSettings.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(509, 32)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(59, 27)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(579, 32)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(59, 24)
        Me.Button2.TabIndex = 24
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'lnkActivity
        '
        Me.lnkActivity.Enabled = False
        Me.lnkActivity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkActivity.Location = New System.Drawing.Point(696, 340)
        Me.lnkActivity.Name = "lnkActivity"
        Me.lnkActivity.Size = New System.Drawing.Size(70, 20)
        Me.lnkActivity.TabIndex = 25
        Me.lnkActivity.TabStop = True
        Me.lnkActivity.Text = "Activity Log"
        Me.ToolTip1.SetToolTip(Me.lnkActivity, "Create Project Activity Log")
        '
        'frmDirectory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(787, 369)
        Me.Controls.Add(Me.lnkActivity)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdSettings)
        Me.Controls.Add(Me.lblThemis)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.cmdRestore)
        Me.Controls.Add(Me.cmdBackup)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.lvProjects)
        Me.Controls.Add(Me.cmdRemove)
        Me.Controls.Add(Me.cmdCreate)
        Me.Controls.Add(Me.lblConnected)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.cmdOpen)
        Me.Controls.Add(Me.cmdConnectServer)
        Me.Controls.Add(Me.lblServer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDirectory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Project Directory"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents cmdConnectServer As System.Windows.Forms.Button
    Friend WithEvents cmdOpen As System.Windows.Forms.Button
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblConnected As System.Windows.Forms.Label
    Friend WithEvents cmdCreate As System.Windows.Forms.Button
    Friend WithEvents cmdRemove As System.Windows.Forms.Button
    Friend WithEvents lvProjects As System.Windows.Forms.ListView
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdBackup As System.Windows.Forms.Button
    Friend WithEvents cmdRestore As System.Windows.Forms.Button
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents lblThemis As System.Windows.Forms.Label
    Friend WithEvents cmdSettings As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lnkActivity As System.Windows.Forms.LinkLabel
End Class
