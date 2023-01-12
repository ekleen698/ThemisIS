<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchUpdate
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchUpdate))
        Me.lblNumEmails = New System.Windows.Forms.Label()
        Me.cmdProduce = New System.Windows.Forms.Button()
        Me.cmdExempt = New System.Windows.Forms.Button()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.cmdNonResponsive = New System.Windows.Forms.Button()
        Me.cmdRedact = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblNumEmails
        '
        Me.lblNumEmails.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumEmails.ForeColor = System.Drawing.Color.Red
        Me.lblNumEmails.Location = New System.Drawing.Point(126, 104)
        Me.lblNumEmails.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblNumEmails.Name = "lblNumEmails"
        Me.lblNumEmails.Size = New System.Drawing.Size(173, 21)
        Me.lblNumEmails.TabIndex = 12
        Me.lblNumEmails.Text = "xxxx Email(s) Found"
        Me.lblNumEmails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdProduce
        '
        Me.cmdProduce.BackColor = System.Drawing.SystemColors.Control
        Me.cmdProduce.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdProduce.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.cmdProduce.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdProduce.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProduce.Location = New System.Drawing.Point(144, 137)
        Me.cmdProduce.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdProduce.Name = "cmdProduce"
        Me.cmdProduce.Size = New System.Drawing.Size(122, 27)
        Me.cmdProduce.TabIndex = 19
        Me.cmdProduce.Text = "Produce"
        Me.cmdProduce.UseVisualStyleBackColor = False
        '
        'cmdExempt
        '
        Me.cmdExempt.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExempt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdExempt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.cmdExempt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExempt.Location = New System.Drawing.Point(144, 211)
        Me.cmdExempt.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdExempt.Name = "cmdExempt"
        Me.cmdExempt.Size = New System.Drawing.Size(122, 27)
        Me.cmdExempt.TabIndex = 20
        Me.cmdExempt.Text = "Exempt"
        Me.cmdExempt.UseVisualStyleBackColor = False
        '
        'cmdReset
        '
        Me.cmdReset.BackColor = System.Drawing.SystemColors.Control
        Me.cmdReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.cmdReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReset.Location = New System.Drawing.Point(144, 286)
        Me.cmdReset.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(122, 27)
        Me.cmdReset.TabIndex = 23
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = False
        '
        'cmdNonResponsive
        '
        Me.cmdNonResponsive.BackColor = System.Drawing.SystemColors.Control
        Me.cmdNonResponsive.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdNonResponsive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.cmdNonResponsive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdNonResponsive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNonResponsive.Location = New System.Drawing.Point(144, 173)
        Me.cmdNonResponsive.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdNonResponsive.Name = "cmdNonResponsive"
        Me.cmdNonResponsive.Size = New System.Drawing.Size(122, 27)
        Me.cmdNonResponsive.TabIndex = 26
        Me.cmdNonResponsive.Text = "Non-Responsive"
        Me.cmdNonResponsive.UseVisualStyleBackColor = False
        '
        'cmdRedact
        '
        Me.cmdRedact.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRedact.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdRedact.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.cmdRedact.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRedact.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRedact.Location = New System.Drawing.Point(144, 247)
        Me.cmdRedact.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdRedact.Name = "cmdRedact"
        Me.cmdRedact.Size = New System.Drawing.Size(122, 27)
        Me.cmdRedact.TabIndex = 28
        Me.cmdRedact.Text = "Redact"
        Me.cmdRedact.UseVisualStyleBackColor = False
        Me.cmdRedact.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(13, 0, 13, 0)
        Me.Label1.Size = New System.Drawing.Size(393, 33)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "PERFORM BULK UPDATE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Info
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 64)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(439, 17)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Note: This operation also applies the same status to all attachments."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(272, 256)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Hidden"
        Me.Label3.Visible = False
        '
        'frmSearchUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(458, 332)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdRedact)
        Me.Controls.Add(Me.cmdNonResponsive)
        Me.Controls.Add(Me.cmdReset)
        Me.Controls.Add(Me.cmdExempt)
        Me.Controls.Add(Me.cmdProduce)
        Me.Controls.Add(Me.lblNumEmails)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(100, 100)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmSearchUpdate"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmSearchUpdate"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNumEmails As System.Windows.Forms.Label
    Friend WithEvents cmdProduce As System.Windows.Forms.Button
    Friend WithEvents cmdExempt As System.Windows.Forms.Button
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents cmdNonResponsive As System.Windows.Forms.Button
    Friend WithEvents cmdRedact As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
