<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMAthletes
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbMembershipNum = New System.Windows.Forms.RadioButton()
        Me.rbAthleteName = New System.Windows.Forms.RadioButton()
        Me.lstMemberNumber = New System.Windows.Forms.ListBox()
        Me.lstMemberName = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnGoDeleteAthlete = New System.Windows.Forms.Button()
        Me.BtnGoModifyAthlete = New System.Windows.Forms.Button()
        Me.BtnGoAddAthlete = New System.Windows.Forms.Button()
        Me.btnClearAthlete = New System.Windows.Forms.Button()
        Me.btnCloseAthlete = New System.Windows.Forms.Button()
        Me.lblMemberDetails = New System.Windows.Forms.TextBox()
        Me.lblRaceResult = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblRaceResult)
        Me.GroupBox1.Controls.Add(Me.lblMemberDetails)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.lstMemberNumber)
        Me.GroupBox1.Controls.Add(Me.lstMemberName)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 132)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(292, 438)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View athlete "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 253)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Race data:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Athlete data:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbMembershipNum)
        Me.GroupBox3.Controls.Add(Me.rbAthleteName)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(277, 37)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Select"
        '
        'rbMembershipNum
        '
        Me.rbMembershipNum.AutoSize = True
        Me.rbMembershipNum.Checked = True
        Me.rbMembershipNum.Location = New System.Drawing.Point(6, 14)
        Me.rbMembershipNum.Name = "rbMembershipNum"
        Me.rbMembershipNum.Size = New System.Drawing.Size(120, 17)
        Me.rbMembershipNum.TabIndex = 0
        Me.rbMembershipNum.TabStop = True
        Me.rbMembershipNum.Text = "Membership n&umber"
        Me.rbMembershipNum.UseVisualStyleBackColor = True
        '
        'rbAthleteName
        '
        Me.rbAthleteName.AutoSize = True
        Me.rbAthleteName.Location = New System.Drawing.Point(149, 13)
        Me.rbAthleteName.Name = "rbAthleteName"
        Me.rbAthleteName.Size = New System.Drawing.Size(87, 17)
        Me.rbAthleteName.TabIndex = 1
        Me.rbAthleteName.Text = "Athlete &name"
        Me.rbAthleteName.UseVisualStyleBackColor = True
        '
        'lstMemberNumber
        '
        Me.lstMemberNumber.FormattingEnabled = True
        Me.lstMemberNumber.Location = New System.Drawing.Point(8, 62)
        Me.lstMemberNumber.Name = "lstMemberNumber"
        Me.lstMemberNumber.Size = New System.Drawing.Size(133, 56)
        Me.lstMemberNumber.TabIndex = 1
        '
        'lstMemberName
        '
        Me.lstMemberName.Enabled = False
        Me.lstMemberName.FormattingEnabled = True
        Me.lstMemberName.Location = New System.Drawing.Point(152, 62)
        Me.lstMemberName.Name = "lstMemberName"
        Me.lstMemberName.Size = New System.Drawing.Size(133, 56)
        Me.lstMemberName.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BtnGoDeleteAthlete)
        Me.GroupBox2.Controls.Add(Me.BtnGoModifyAthlete)
        Me.GroupBox2.Controls.Add(Me.BtnGoAddAthlete)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(292, 113)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Select task"
        '
        'BtnGoDeleteAthlete
        '
        Me.BtnGoDeleteAthlete.Location = New System.Drawing.Point(7, 80)
        Me.BtnGoDeleteAthlete.Name = "BtnGoDeleteAthlete"
        Me.BtnGoDeleteAthlete.Size = New System.Drawing.Size(279, 23)
        Me.BtnGoDeleteAthlete.TabIndex = 2
        Me.BtnGoDeleteAthlete.Text = "&Delete Athlete"
        Me.BtnGoDeleteAthlete.UseVisualStyleBackColor = True
        '
        'BtnGoModifyAthlete
        '
        Me.BtnGoModifyAthlete.Location = New System.Drawing.Point(7, 50)
        Me.BtnGoModifyAthlete.Name = "BtnGoModifyAthlete"
        Me.BtnGoModifyAthlete.Size = New System.Drawing.Size(279, 23)
        Me.BtnGoModifyAthlete.TabIndex = 1
        Me.BtnGoModifyAthlete.Text = "&Modify Athlete"
        Me.BtnGoModifyAthlete.UseVisualStyleBackColor = True
        '
        'BtnGoAddAthlete
        '
        Me.BtnGoAddAthlete.Location = New System.Drawing.Point(7, 20)
        Me.BtnGoAddAthlete.Name = "BtnGoAddAthlete"
        Me.BtnGoAddAthlete.Size = New System.Drawing.Size(279, 23)
        Me.BtnGoAddAthlete.TabIndex = 0
        Me.BtnGoAddAthlete.Text = "&Add Athlete"
        Me.BtnGoAddAthlete.UseVisualStyleBackColor = True
        '
        'btnClearAthlete
        '
        Me.btnClearAthlete.Location = New System.Drawing.Point(117, 576)
        Me.btnClearAthlete.Name = "btnClearAthlete"
        Me.btnClearAthlete.Size = New System.Drawing.Size(86, 23)
        Me.btnClearAthlete.TabIndex = 3
        Me.btnClearAthlete.Text = "Clear &Screen"
        Me.btnClearAthlete.UseVisualStyleBackColor = True
        '
        'btnCloseAthlete
        '
        Me.btnCloseAthlete.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCloseAthlete.Location = New System.Drawing.Point(220, 576)
        Me.btnCloseAthlete.Name = "btnCloseAthlete"
        Me.btnCloseAthlete.Size = New System.Drawing.Size(86, 23)
        Me.btnCloseAthlete.TabIndex = 4
        Me.btnCloseAthlete.Text = "&Close"
        Me.btnCloseAthlete.UseVisualStyleBackColor = True
        '
        'lblMemberDetails
        '
        Me.lblMemberDetails.Location = New System.Drawing.Point(9, 137)
        Me.lblMemberDetails.Multiline = True
        Me.lblMemberDetails.Name = "lblMemberDetails"
        Me.lblMemberDetails.ReadOnly = True
        Me.lblMemberDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.lblMemberDetails.Size = New System.Drawing.Size(275, 113)
        Me.lblMemberDetails.TabIndex = 7
        '
        'lblRaceResult
        '
        Me.lblRaceResult.Location = New System.Drawing.Point(7, 270)
        Me.lblRaceResult.Multiline = True
        Me.lblRaceResult.Name = "lblRaceResult"
        Me.lblRaceResult.ReadOnly = True
        Me.lblRaceResult.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.lblRaceResult.Size = New System.Drawing.Size(277, 162)
        Me.lblRaceResult.TabIndex = 8
        '
        'FRMAthletes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCloseAthlete
        Me.ClientSize = New System.Drawing.Size(320, 607)
        Me.Controls.Add(Me.btnCloseAthlete)
        Me.Controls.Add(Me.btnClearAthlete)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRMAthletes"
        Me.Text = "Athlete Management"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lstMemberName As ListBox
    Friend WithEvents lstMemberNumber As ListBox
    Friend WithEvents rbAthleteName As RadioButton
    Friend WithEvents rbMembershipNum As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BtnGoDeleteAthlete As Button
    Friend WithEvents BtnGoModifyAthlete As Button
    Friend WithEvents BtnGoAddAthlete As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnClearAthlete As Button
    Friend WithEvents btnCloseAthlete As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblRaceResult As TextBox
    Friend WithEvents lblMemberDetails As TextBox
End Class
