<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmWorkerProgress
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWorkerProgress))
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblCount1 = New System.Windows.Forms.Label()
        Me.lblFolder1 = New System.Windows.Forms.Label()
        Me.lblStep1 = New System.Windows.Forms.Label()
        Me.cmdLocation = New System.Windows.Forms.Button()
        Me.lblStep2 = New System.Windows.Forms.Label()
        Me.lblFolder2 = New System.Windows.Forms.Label()
        Me.lblCount2 = New System.Windows.Forms.Label()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.lblStep4 = New System.Windows.Forms.Label()
        Me.lblFolder4 = New System.Windows.Forms.Label()
        Me.lblCount4 = New System.Windows.Forms.Label()
        Me.ProgressBar4 = New System.Windows.Forms.ProgressBar()
        Me.lblStep3 = New System.Windows.Forms.Label()
        Me.lblFolder3 = New System.Windows.Forms.Label()
        Me.lblCount3 = New System.Windows.Forms.Label()
        Me.ProgressBar3 = New System.Windows.Forms.ProgressBar()
        Me.lblStep5 = New System.Windows.Forms.Label()
        Me.lblFolder5 = New System.Windows.Forms.Label()
        Me.lblCount5 = New System.Windows.Forms.Label()
        Me.ProgressBar5 = New System.Windows.Forms.ProgressBar()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ProgressBar1.Location = New System.Drawing.Point(24, 35)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(2)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(393, 23)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 0
        '
        'lblCount1
        '
        Me.lblCount1.AutoSize = True
        Me.lblCount1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount1.Location = New System.Drawing.Point(432, 37)
        Me.lblCount1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCount1.Name = "lblCount1"
        Me.lblCount1.Size = New System.Drawing.Size(45, 18)
        Me.lblCount1.TabIndex = 2
        Me.lblCount1.Text = "0 of 0"
        '
        'lblFolder1
        '
        Me.lblFolder1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolder1.Location = New System.Drawing.Point(27, 8)
        Me.lblFolder1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFolder1.Name = "lblFolder1"
        Me.lblFolder1.Size = New System.Drawing.Size(76, 20)
        Me.lblFolder1.TabIndex = 4
        Me.lblFolder1.Text = "Worker(1)"
        '
        'lblStep1
        '
        Me.lblStep1.AutoSize = True
        Me.lblStep1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStep1.Location = New System.Drawing.Point(27, 61)
        Me.lblStep1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStep1.Name = "lblStep1"
        Me.lblStep1.Size = New System.Drawing.Size(70, 18)
        Me.lblStep1.TabIndex = 10
        Me.lblStep1.Text = "Initializing"
        '
        'cmdLocation
        '
        Me.cmdLocation.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLocation.Location = New System.Drawing.Point(360, 13)
        Me.cmdLocation.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdLocation.Name = "cmdLocation"
        Me.cmdLocation.Size = New System.Drawing.Size(56, 21)
        Me.cmdLocation.TabIndex = 11
        Me.cmdLocation.Text = "Location"
        Me.cmdLocation.UseVisualStyleBackColor = True
        '
        'lblStep2
        '
        Me.lblStep2.AutoSize = True
        Me.lblStep2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStep2.Location = New System.Drawing.Point(24, 149)
        Me.lblStep2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStep2.Name = "lblStep2"
        Me.lblStep2.Size = New System.Drawing.Size(70, 18)
        Me.lblStep2.TabIndex = 15
        Me.lblStep2.Text = "Initializing"
        '
        'lblFolder2
        '
        Me.lblFolder2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolder2.Location = New System.Drawing.Point(24, 96)
        Me.lblFolder2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFolder2.Name = "lblFolder2"
        Me.lblFolder2.Size = New System.Drawing.Size(76, 20)
        Me.lblFolder2.TabIndex = 14
        Me.lblFolder2.Text = "Worker(2)"
        '
        'lblCount2
        '
        Me.lblCount2.AutoSize = True
        Me.lblCount2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount2.Location = New System.Drawing.Point(429, 125)
        Me.lblCount2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCount2.Name = "lblCount2"
        Me.lblCount2.Size = New System.Drawing.Size(45, 18)
        Me.lblCount2.TabIndex = 13
        Me.lblCount2.Text = "0 of 0"
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ProgressBar2.Location = New System.Drawing.Point(21, 122)
        Me.ProgressBar2.Margin = New System.Windows.Forms.Padding(2)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(393, 23)
        Me.ProgressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar2.TabIndex = 12
        '
        'lblStep4
        '
        Me.lblStep4.AutoSize = True
        Me.lblStep4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStep4.Location = New System.Drawing.Point(21, 328)
        Me.lblStep4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStep4.Name = "lblStep4"
        Me.lblStep4.Size = New System.Drawing.Size(70, 18)
        Me.lblStep4.TabIndex = 23
        Me.lblStep4.Text = "Initializing"
        '
        'lblFolder4
        '
        Me.lblFolder4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolder4.Location = New System.Drawing.Point(21, 275)
        Me.lblFolder4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFolder4.Name = "lblFolder4"
        Me.lblFolder4.Size = New System.Drawing.Size(76, 20)
        Me.lblFolder4.TabIndex = 22
        Me.lblFolder4.Text = "Worker(4)"
        '
        'lblCount4
        '
        Me.lblCount4.AutoSize = True
        Me.lblCount4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount4.Location = New System.Drawing.Point(427, 304)
        Me.lblCount4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCount4.Name = "lblCount4"
        Me.lblCount4.Size = New System.Drawing.Size(45, 18)
        Me.lblCount4.TabIndex = 21
        Me.lblCount4.Text = "0 of 0"
        '
        'ProgressBar4
        '
        Me.ProgressBar4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ProgressBar4.Location = New System.Drawing.Point(19, 301)
        Me.ProgressBar4.Margin = New System.Windows.Forms.Padding(2)
        Me.ProgressBar4.Name = "ProgressBar4"
        Me.ProgressBar4.Size = New System.Drawing.Size(393, 23)
        Me.ProgressBar4.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar4.TabIndex = 20
        '
        'lblStep3
        '
        Me.lblStep3.AutoSize = True
        Me.lblStep3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStep3.Location = New System.Drawing.Point(24, 240)
        Me.lblStep3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStep3.Name = "lblStep3"
        Me.lblStep3.Size = New System.Drawing.Size(70, 18)
        Me.lblStep3.TabIndex = 19
        Me.lblStep3.Text = "Initializing"
        '
        'lblFolder3
        '
        Me.lblFolder3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolder3.Location = New System.Drawing.Point(24, 187)
        Me.lblFolder3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFolder3.Name = "lblFolder3"
        Me.lblFolder3.Size = New System.Drawing.Size(76, 20)
        Me.lblFolder3.TabIndex = 18
        Me.lblFolder3.Text = "Worker(3)"
        '
        'lblCount3
        '
        Me.lblCount3.AutoSize = True
        Me.lblCount3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount3.Location = New System.Drawing.Point(429, 216)
        Me.lblCount3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCount3.Name = "lblCount3"
        Me.lblCount3.Size = New System.Drawing.Size(45, 18)
        Me.lblCount3.TabIndex = 17
        Me.lblCount3.Text = "0 of 0"
        '
        'ProgressBar3
        '
        Me.ProgressBar3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ProgressBar3.Location = New System.Drawing.Point(21, 213)
        Me.ProgressBar3.Margin = New System.Windows.Forms.Padding(2)
        Me.ProgressBar3.Name = "ProgressBar3"
        Me.ProgressBar3.Size = New System.Drawing.Size(393, 23)
        Me.ProgressBar3.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar3.TabIndex = 16
        '
        'lblStep5
        '
        Me.lblStep5.AutoSize = True
        Me.lblStep5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStep5.Location = New System.Drawing.Point(21, 417)
        Me.lblStep5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStep5.Name = "lblStep5"
        Me.lblStep5.Size = New System.Drawing.Size(70, 18)
        Me.lblStep5.TabIndex = 27
        Me.lblStep5.Text = "Initializing"
        '
        'lblFolder5
        '
        Me.lblFolder5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolder5.Location = New System.Drawing.Point(21, 364)
        Me.lblFolder5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFolder5.Name = "lblFolder5"
        Me.lblFolder5.Size = New System.Drawing.Size(76, 20)
        Me.lblFolder5.TabIndex = 26
        Me.lblFolder5.Text = "Worker(5)"
        '
        'lblCount5
        '
        Me.lblCount5.AutoSize = True
        Me.lblCount5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount5.Location = New System.Drawing.Point(427, 393)
        Me.lblCount5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCount5.Name = "lblCount5"
        Me.lblCount5.Size = New System.Drawing.Size(45, 18)
        Me.lblCount5.TabIndex = 25
        Me.lblCount5.Text = "0 of 0"
        '
        'ProgressBar5
        '
        Me.ProgressBar5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ProgressBar5.Location = New System.Drawing.Point(19, 389)
        Me.ProgressBar5.Margin = New System.Windows.Forms.Padding(2)
        Me.ProgressBar5.Name = "ProgressBar5"
        Me.ProgressBar5.Size = New System.Drawing.Size(393, 23)
        Me.ProgressBar5.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar5.TabIndex = 24
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(397, 443)
        Me.cmdClose.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(74, 25)
        Me.cmdClose.TabIndex = 28
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'frmWorkerProgress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdLocation
        Me.ClientSize = New System.Drawing.Size(500, 481)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.lblStep5)
        Me.Controls.Add(Me.lblFolder5)
        Me.Controls.Add(Me.lblCount5)
        Me.Controls.Add(Me.ProgressBar5)
        Me.Controls.Add(Me.lblStep4)
        Me.Controls.Add(Me.lblFolder4)
        Me.Controls.Add(Me.lblCount4)
        Me.Controls.Add(Me.ProgressBar4)
        Me.Controls.Add(Me.lblStep3)
        Me.Controls.Add(Me.lblFolder3)
        Me.Controls.Add(Me.lblCount3)
        Me.Controls.Add(Me.ProgressBar3)
        Me.Controls.Add(Me.lblStep2)
        Me.Controls.Add(Me.lblFolder2)
        Me.Controls.Add(Me.lblCount2)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Controls.Add(Me.cmdLocation)
        Me.Controls.Add(Me.lblStep1)
        Me.Controls.Add(Me.lblFolder1)
        Me.Controls.Add(Me.lblCount1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(280, 250)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWorkerProgress"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Worker Progress"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblCount1 As System.Windows.Forms.Label
    Friend WithEvents lblFolder1 As System.Windows.Forms.Label
    Friend WithEvents lblStep1 As System.Windows.Forms.Label
    Friend WithEvents cmdLocation As System.Windows.Forms.Button
    Friend WithEvents lblStep2 As System.Windows.Forms.Label
    Friend WithEvents lblFolder2 As System.Windows.Forms.Label
    Friend WithEvents lblCount2 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblStep4 As System.Windows.Forms.Label
    Friend WithEvents lblFolder4 As System.Windows.Forms.Label
    Friend WithEvents lblCount4 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar4 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblStep3 As System.Windows.Forms.Label
    Friend WithEvents lblFolder3 As System.Windows.Forms.Label
    Friend WithEvents lblCount3 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar3 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblStep5 As System.Windows.Forms.Label
    Friend WithEvents lblFolder5 As System.Windows.Forms.Label
    Friend WithEvents lblCount5 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar5 As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdClose As System.Windows.Forms.Button
End Class
