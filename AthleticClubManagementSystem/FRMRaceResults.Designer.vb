<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMRaceResults
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
        Me.btnAddRaceResult = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnFindMember = New System.Windows.Forms.Button()
        Me.txtMemberNumber = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lstMemberName = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rdgSearchPref = New System.Windows.Forms.GroupBox()
        Me.rbName = New System.Windows.Forms.RadioButton()
        Me.rbNum = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lstTitle = New System.Windows.Forms.ListBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblMemberNumber = New System.Windows.Forms.Label()
        Me.lblMemberName = New System.Windows.Forms.Label()
        Me.txtRaceTime = New System.Windows.Forms.MaskedTextBox()
        Me.lblMemberDetails = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.rdgSearchPref.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAddRaceResult
        '
        Me.btnAddRaceResult.Location = New System.Drawing.Point(33, 484)
        Me.btnAddRaceResult.Name = "btnAddRaceResult"
        Me.btnAddRaceResult.Size = New System.Drawing.Size(86, 23)
        Me.btnAddRaceResult.TabIndex = 9
        Me.btnAddRaceResult.Text = "&Add Time"
        Me.btnAddRaceResult.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(135, 484)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(86, 23)
        Me.btnClear.TabIndex = 10
        Me.btnClear.Text = "Clear &Screen"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(237, 484)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(86, 23)
        Me.btnClose.TabIndex = 11
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblMemberDetails)
        Me.GroupBox1.Controls.Add(Me.btnFindMember)
        Me.GroupBox1.Controls.Add(Me.txtMemberNumber)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lstMemberName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.rdgSearchPref)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(332, 340)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Find member:"
        '
        'btnFindMember
        '
        Me.btnFindMember.Location = New System.Drawing.Point(27, 198)
        Me.btnFindMember.Name = "btnFindMember"
        Me.btnFindMember.Size = New System.Drawing.Size(279, 23)
        Me.btnFindMember.TabIndex = 5
        Me.btnFindMember.Text = "&View Member Details"
        Me.btnFindMember.UseVisualStyleBackColor = True
        '
        'txtMemberNumber
        '
        Me.txtMemberNumber.Location = New System.Drawing.Point(163, 91)
        Me.txtMemberNumber.Name = "txtMemberNumber"
        Me.txtMemberNumber.Size = New System.Drawing.Size(100, 20)
        Me.txtMemberNumber.TabIndex = 4
        Me.txtMemberNumber.Tag = "Member number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(160, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Member Num&ber:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 233)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Member details:"
        '
        'lstMemberName
        '
        Me.lstMemberName.FormattingEnabled = True
        Me.lstMemberName.Location = New System.Drawing.Point(10, 91)
        Me.lstMemberName.Name = "lstMemberName"
        Me.lstMemberName.Size = New System.Drawing.Size(120, 95)
        Me.lstMemberName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "&Member name:"
        '
        'rdgSearchPref
        '
        Me.rdgSearchPref.Controls.Add(Me.rbName)
        Me.rdgSearchPref.Controls.Add(Me.rbNum)
        Me.rdgSearchPref.Location = New System.Drawing.Point(10, 19)
        Me.rdgSearchPref.Name = "rdgSearchPref"
        Me.rdgSearchPref.Size = New System.Drawing.Size(280, 48)
        Me.rdgSearchPref.TabIndex = 0
        Me.rdgSearchPref.TabStop = False
        Me.rdgSearchPref.Text = "Select search preference"
        '
        'rbName
        '
        Me.rbName.AutoSize = True
        Me.rbName.Checked = True
        Me.rbName.Location = New System.Drawing.Point(15, 19)
        Me.rbName.Name = "rbName"
        Me.rbName.Size = New System.Drawing.Size(92, 17)
        Me.rbName.TabIndex = 1
        Me.rbName.TabStop = True
        Me.rbName.Text = "Member &name"
        Me.rbName.UseVisualStyleBackColor = True
        '
        'rbNum
        '
        Me.rbNum.AutoSize = True
        Me.rbNum.Location = New System.Drawing.Point(140, 19)
        Me.rbNum.Name = "rbNum"
        Me.rbNum.Size = New System.Drawing.Size(120, 17)
        Me.rbNum.TabIndex = 0
        Me.rbNum.Text = "Membership n&umber"
        Me.rbNum.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 369)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Select &event:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(132, 452)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Enter race &time:"
        '
        'lstTitle
        '
        Me.lstTitle.FormattingEnabled = True
        Me.lstTitle.Location = New System.Drawing.Point(13, 384)
        Me.lstTitle.Name = "lstTitle"
        Me.lstTitle.Size = New System.Drawing.Size(113, 82)
        Me.lstTitle.TabIndex = 2
        Me.lstTitle.Tag = "Select Event"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(132, 369)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Membership number:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(132, 411)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Member Name:"
        '
        'lblMemberNumber
        '
        Me.lblMemberNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMemberNumber.Location = New System.Drawing.Point(243, 368)
        Me.lblMemberNumber.Name = "lblMemberNumber"
        Me.lblMemberNumber.Size = New System.Drawing.Size(100, 23)
        Me.lblMemberNumber.TabIndex = 4
        Me.lblMemberNumber.Tag = "Membership Number"
        '
        'lblMemberName
        '
        Me.lblMemberName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMemberName.Location = New System.Drawing.Point(243, 411)
        Me.lblMemberName.Name = "lblMemberName"
        Me.lblMemberName.Size = New System.Drawing.Size(100, 23)
        Me.lblMemberName.TabIndex = 6
        Me.lblMemberName.Tag = "Membership Name"
        '
        'txtRaceTime
        '
        Me.txtRaceTime.Location = New System.Drawing.Point(243, 445)
        Me.txtRaceTime.Mask = "##:##:##"
        Me.txtRaceTime.Name = "txtRaceTime"
        Me.txtRaceTime.Size = New System.Drawing.Size(100, 20)
        Me.txtRaceTime.TabIndex = 12
        Me.txtRaceTime.Tag = "Race time"
        Me.txtRaceTime.ValidatingType = GetType(Date)
        '
        'lblMemberDetails
        '
        Me.lblMemberDetails.Location = New System.Drawing.Point(94, 233)
        Me.lblMemberDetails.Multiline = True
        Me.lblMemberDetails.Name = "lblMemberDetails"
        Me.lblMemberDetails.ReadOnly = True
        Me.lblMemberDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.lblMemberDetails.Size = New System.Drawing.Size(232, 101)
        Me.lblMemberDetails.TabIndex = 7
        '
        'FRMRaceResults
        '
        Me.AcceptButton = Me.btnAddRaceResult
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(357, 515)
        Me.Controls.Add(Me.txtRaceTime)
        Me.Controls.Add(Me.lblMemberName)
        Me.Controls.Add(Me.lblMemberNumber)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lstTitle)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnAddRaceResult)
        Me.Name = "FRMRaceResults"
        Me.Text = "Race Results"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.rdgSearchPref.ResumeLayout(False)
        Me.rdgSearchPref.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAddRaceResult As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtMemberNumber As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lstMemberName As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents rdgSearchPref As GroupBox
    Friend WithEvents rbName As RadioButton
    Friend WithEvents rbNum As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents btnFindMember As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents lstTitle As ListBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblMemberNumber As Label
    Friend WithEvents lblMemberName As Label
    Friend WithEvents txtRaceTime As MaskedTextBox
    Friend WithEvents lblMemberDetails As TextBox
End Class
