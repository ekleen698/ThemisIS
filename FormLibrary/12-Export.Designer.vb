<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmExport
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
        Me.txtFolder = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lnkBrowse = New System.Windows.Forms.LinkLabel()
        Me.cmdExport = New System.Windows.Forms.Button()
        Me.cmdLocation = New System.Windows.Forms.Button()
        Me.cmdSize = New System.Windows.Forms.Button()
        Me.lblSubFolder = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtFolder
        '
        Me.txtFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFolder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.txtFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFolder.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFolder.Location = New System.Drawing.Point(16, 43)
        Me.txtFolder.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtFolder.Name = "txtFolder"
        Me.txtFolder.Size = New System.Drawing.Size(355, 24)
        Me.txtFolder.TabIndex = 0
        Me.txtFolder.WordWrap = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Destination Folder"
        '
        'lnkBrowse
        '
        Me.lnkBrowse.AutoSize = True
        Me.lnkBrowse.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkBrowse.Location = New System.Drawing.Point(171, 19)
        Me.lnkBrowse.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lnkBrowse.Name = "lnkBrowse"
        Me.lnkBrowse.Size = New System.Drawing.Size(54, 16)
        Me.lnkBrowse.TabIndex = 2
        Me.lnkBrowse.TabStop = True
        Me.lnkBrowse.Text = "Browse"
        '
        'cmdExport
        '
        Me.cmdExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExport.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExport.Location = New System.Drawing.Point(368, 75)
        Me.cmdExport.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(117, 27)
        Me.cmdExport.TabIndex = 7
        Me.cmdExport.Text = "Export"
        Me.cmdExport.UseVisualStyleBackColor = True
        '
        'cmdLocation
        '
        Me.cmdLocation.Location = New System.Drawing.Point(237, 11)
        Me.cmdLocation.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmdLocation.Name = "cmdLocation"
        Me.cmdLocation.Size = New System.Drawing.Size(59, 27)
        Me.cmdLocation.TabIndex = 8
        Me.cmdLocation.Text = "Location"
        Me.cmdLocation.UseVisualStyleBackColor = True
        Me.cmdLocation.Visible = False
        '
        'cmdSize
        '
        Me.cmdSize.Location = New System.Drawing.Point(307, 11)
        Me.cmdSize.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmdSize.Name = "cmdSize"
        Me.cmdSize.Size = New System.Drawing.Size(59, 27)
        Me.cmdSize.TabIndex = 9
        Me.cmdSize.Text = "Size"
        Me.cmdSize.UseVisualStyleBackColor = True
        Me.cmdSize.Visible = False
        '
        'lblSubFolder
        '
        Me.lblSubFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSubFolder.AutoSize = True
        Me.lblSubFolder.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubFolder.Location = New System.Drawing.Point(373, 45)
        Me.lblSubFolder.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSubFolder.Name = "lblSubFolder"
        Me.lblSubFolder.Size = New System.Drawing.Size(43, 17)
        Me.lblSubFolder.TabIndex = 10
        Me.lblSubFolder.Text = "\Type"
        '
        'frmExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(507, 124)
        Me.Controls.Add(Me.lblSubFolder)
        Me.Controls.Add(Me.cmdSize)
        Me.Controls.Add(Me.cmdLocation)
        Me.Controls.Add(Me.cmdExport)
        Me.Controls.Add(Me.lnkBrowse)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFolder)
        Me.Location = New System.Drawing.Point(500, 300)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1072, 213)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(492, 163)
        Me.Name = "frmExport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Export Options"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtFolder As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lnkBrowse As System.Windows.Forms.LinkLabel
    Friend WithEvents cmdExport As System.Windows.Forms.Button
    Friend WithEvents cmdLocation As System.Windows.Forms.Button
    Friend WithEvents cmdSize As System.Windows.Forms.Button
    Friend WithEvents lblSubFolder As System.Windows.Forms.Label
End Class
