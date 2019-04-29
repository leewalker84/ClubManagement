<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMEvents
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
        Me.btnGoDeleteEvent = New System.Windows.Forms.Button()
        Me.btnGoModifyEvent = New System.Windows.Forms.Button()
        Me.btnGoAddEvent = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstTitle = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblEventDetails = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnGoDeleteEvent)
        Me.GroupBox1.Controls.Add(Me.btnGoModifyEvent)
        Me.GroupBox1.Controls.Add(Me.btnGoAddEvent)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(292, 113)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select task"
        '
        'btnGoDeleteEvent
        '
        Me.btnGoDeleteEvent.Location = New System.Drawing.Point(7, 80)
        Me.btnGoDeleteEvent.Name = "btnGoDeleteEvent"
        Me.btnGoDeleteEvent.Size = New System.Drawing.Size(279, 23)
        Me.btnGoDeleteEvent.TabIndex = 2
        Me.btnGoDeleteEvent.Text = "&Delete Event"
        Me.btnGoDeleteEvent.UseVisualStyleBackColor = True
        '
        'btnGoModifyEvent
        '
        Me.btnGoModifyEvent.Location = New System.Drawing.Point(7, 50)
        Me.btnGoModifyEvent.Name = "btnGoModifyEvent"
        Me.btnGoModifyEvent.Size = New System.Drawing.Size(279, 23)
        Me.btnGoModifyEvent.TabIndex = 1
        Me.btnGoModifyEvent.Text = "&Modify Event"
        Me.btnGoModifyEvent.UseVisualStyleBackColor = True
        '
        'btnGoAddEvent
        '
        Me.btnGoAddEvent.Location = New System.Drawing.Point(7, 20)
        Me.btnGoAddEvent.Name = "btnGoAddEvent"
        Me.btnGoAddEvent.Size = New System.Drawing.Size(279, 23)
        Me.btnGoAddEvent.TabIndex = 0
        Me.btnGoAddEvent.Text = "&Add Event"
        Me.btnGoAddEvent.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblEventDetails)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lstTitle)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 133)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(292, 291)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "View event "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Event data:"
        '
        'lstTitle
        '
        Me.lstTitle.FormattingEnabled = True
        Me.lstTitle.Location = New System.Drawing.Point(8, 32)
        Me.lstTitle.Name = "lstTitle"
        Me.lstTitle.Size = New System.Drawing.Size(277, 69)
        Me.lstTitle.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select event:"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(117, 430)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(86, 23)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear &Screen"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(220, 430)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(86, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblEventDetails
        '
        Me.lblEventDetails.Location = New System.Drawing.Point(10, 131)
        Me.lblEventDetails.Multiline = True
        Me.lblEventDetails.Name = "lblEventDetails"
        Me.lblEventDetails.ReadOnly = True
        Me.lblEventDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.lblEventDetails.Size = New System.Drawing.Size(276, 154)
        Me.lblEventDetails.TabIndex = 3
        '
        'FRMEvents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(320, 465)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRMEvents"
        Me.Text = "Event Management"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnGoDeleteEvent As Button
    Friend WithEvents btnGoModifyEvent As Button
    Friend WithEvents btnGoAddEvent As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lstTitle As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnClear As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents lblEventDetails As TextBox
End Class
