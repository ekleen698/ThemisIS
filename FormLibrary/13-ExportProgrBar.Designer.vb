<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmExportProgress
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
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.lblStep = New System.Windows.Forms.Label()
        Me.lblTotalCount = New System.Windows.Forms.Label()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.cmdBegin = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdLocation = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(333, 83)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(74, 25)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'lblStep
        '
        Me.lblStep.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStep.Location = New System.Drawing.Point(13, 20)
        Me.lblStep.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStep.Name = "lblStep"
        Me.lblStep.Size = New System.Drawing.Size(384, 21)
        Me.lblStep.TabIndex = 8
        Me.lblStep.Text = "Export Progress"
        '
        'lblTotalCount
        '
        Me.lblTotalCount.AutoSize = True
        Me.lblTotalCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCount.Location = New System.Drawing.Point(421, 45)
        Me.lblTotalCount.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTotalCount.Name = "lblTotalCount"
        Me.lblTotalCount.Size = New System.Drawing.Size(94, 18)
        Me.lblTotalCount.TabIndex = 7
        Me.lblTotalCount.Text = "0 of 0 Emails"
        '
        'ProgressBar
        '
        Me.ProgressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ProgressBar.Location = New System.Drawing.Point(13, 45)
        Me.ProgressBar.Margin = New System.Windows.Forms.Padding(2)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(383, 23)
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar.TabIndex = 6
        '
        'cmdBegin
        '
        Me.cmdBegin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdBegin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBegin.Location = New System.Drawing.Point(251, 83)
        Me.cmdBegin.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdBegin.Name = "cmdBegin"
        Me.cmdBegin.Size = New System.Drawing.Size(74, 25)
        Me.cmdBegin.TabIndex = 9
        Me.cmdBegin.Text = "Begin"
        Me.cmdBegin.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(416, 83)
        Me.cmdClose.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(74, 25)
        Me.cmdClose.TabIndex = 10
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdLocation
        '
        Me.cmdLocation.Location = New System.Drawing.Point(64, 88)
        Me.cmdLocation.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdLocation.Name = "cmdLocation"
        Me.cmdLocation.Size = New System.Drawing.Size(59, 24)
        Me.cmdLocation.TabIndex = 11
        Me.cmdLocation.Text = "Location"
        Me.cmdLocation.UseVisualStyleBackColor = True
        '
        'frmExportProgress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(541, 137)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdLocation)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdBegin)
        Me.Controls.Add(Me.lblStep)
        Me.Controls.Add(Me.lblTotalCount)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.cmdCancel)
        Me.Location = New System.Drawing.Point(280, 250)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmExportProgress"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export Progress Bar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblStep As System.Windows.Forms.Label
    Friend WithEvents lblTotalCount As System.Windows.Forms.Label
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdBegin As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdLocation As System.Windows.Forms.Button
End Class
