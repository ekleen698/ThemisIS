<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLicenseKey
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLicenseKey))
        Me.txtKey = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdContinue = New System.Windows.Forms.Button()
        Me.cmdLocation = New System.Windows.Forms.Button()
        Me.cmdSize = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtKey
        '
        Me.txtKey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.txtKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKey.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKey.Location = New System.Drawing.Point(16, 60)
        Me.txtKey.Margin = New System.Windows.Forms.Padding(2)
        Me.txtKey.Name = "txtKey"
        Me.txtKey.Size = New System.Drawing.Size(316, 24)
        Me.txtKey.TabIndex = 0
        Me.txtKey.WordWrap = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(314, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Enter valid license key to create new project."
        '
        'cmdContinue
        '
        Me.cmdContinue.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdContinue.Location = New System.Drawing.Point(340, 60)
        Me.cmdContinue.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdContinue.Name = "cmdContinue"
        Me.cmdContinue.Size = New System.Drawing.Size(92, 27)
        Me.cmdContinue.TabIndex = 7
        Me.cmdContinue.Text = "Continue"
        Me.cmdContinue.UseVisualStyleBackColor = True
        '
        'cmdLocation
        '
        Me.cmdLocation.AutoSize = True
        Me.cmdLocation.Location = New System.Drawing.Point(324, 8)
        Me.cmdLocation.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdLocation.Name = "cmdLocation"
        Me.cmdLocation.Size = New System.Drawing.Size(80, 28)
        Me.cmdLocation.TabIndex = 8
        Me.cmdLocation.Text = "Location"
        Me.cmdLocation.UseVisualStyleBackColor = True
        Me.cmdLocation.Visible = False
        '
        'cmdSize
        '
        Me.cmdSize.AutoSize = True
        Me.cmdSize.Location = New System.Drawing.Point(420, 8)
        Me.cmdSize.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdSize.Name = "cmdSize"
        Me.cmdSize.Size = New System.Drawing.Size(76, 27)
        Me.cmdSize.TabIndex = 9
        Me.cmdSize.Text = "Size"
        Me.cmdSize.UseVisualStyleBackColor = True
        Me.cmdSize.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(444, 60)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(92, 27)
        Me.cmdCancel.TabIndex = 10
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmLicenseKey
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(558, 124)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSize)
        Me.Controls.Add(Me.cmdLocation)
        Me.Controls.Add(Me.cmdContinue)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtKey)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(400, 300)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(574, 163)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(574, 163)
        Me.Name = "frmLicenseKey"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "License Key"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtKey As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdContinue As System.Windows.Forms.Button
    Friend WithEvents cmdLocation As System.Windows.Forms.Button
    Friend WithEvents cmdSize As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
