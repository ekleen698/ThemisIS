<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAttachExemption
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAttachExemption))
        Me.dgvExemptions = New System.Windows.Forms.DataGridView()
        Me.cmdSaveClose = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.lblDirty = New System.Windows.Forms.Label()
        CType(Me.dgvExemptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvExemptions
        '
        Me.dgvExemptions.AllowUserToAddRows = False
        Me.dgvExemptions.AllowUserToDeleteRows = False
        Me.dgvExemptions.AllowUserToResizeColumns = False
        Me.dgvExemptions.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvExemptions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvExemptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvExemptions.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvExemptions.Location = New System.Drawing.Point(32, 39)
        Me.dgvExemptions.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvExemptions.Name = "dgvExemptions"
        Me.dgvExemptions.RowHeadersVisible = False
        Me.dgvExemptions.RowHeadersWidth = 62
        Me.dgvExemptions.RowTemplate.Height = 28
        Me.dgvExemptions.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvExemptions.Size = New System.Drawing.Size(817, 261)
        Me.dgvExemptions.TabIndex = 0
        '
        'cmdSaveClose
        '
        Me.cmdSaveClose.Enabled = False
        Me.cmdSaveClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSaveClose.Location = New System.Drawing.Point(644, 330)
        Me.cmdSaveClose.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdSaveClose.Name = "cmdSaveClose"
        Me.cmdSaveClose.Size = New System.Drawing.Size(100, 31)
        Me.cmdSaveClose.TabIndex = 1
        Me.cmdSaveClose.Text = "Save and Close"
        Me.cmdSaveClose.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(757, 330)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(93, 31)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'lblDirty
        '
        Me.lblDirty.AutoSize = True
        Me.lblDirty.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirty.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblDirty.Location = New System.Drawing.Point(37, 315)
        Me.lblDirty.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDirty.Name = "lblDirty"
        Me.lblDirty.Size = New System.Drawing.Size(206, 26)
        Me.lblDirty.TabIndex = 8
        Me.lblDirty.Text = "Unsaved Changes"
        Me.lblDirty.Visible = False
        '
        'frmAttachExemption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(874, 377)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblDirty)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSaveClose)
        Me.Controls.Add(Me.dgvExemptions)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAttachExemption"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Attachment Exemption"
        CType(Me.dgvExemptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvExemptions As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSaveClose As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblDirty As System.Windows.Forms.Label
End Class
