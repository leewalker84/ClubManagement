<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMDeleteEvent
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
        Me.lstTitle = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClearEvent = New System.Windows.Forms.Button()
        Me.btnCloseEvent = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblEventDetails = New System.Windows.Forms.TextBox()
        Me.lblRaceResult = New System.Windows.Forms.TextBox()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstTitle
        '
        Me.lstTitle.FormattingEnabled = True
        Me.lstTitle.Location = New System.Drawing.Point(85, 20)
        Me.lstTitle.Name = "lstTitle"
        Me.lstTitle.Size = New System.Drawing.Size(193, 69)
        Me.lstTitle.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Select &event:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lstTitle)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(288, 103)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Find event"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Event details:"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(26, 476)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(86, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "&Delete Event"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnClearEvent
        '
        Me.btnClearEvent.Location = New System.Drawing.Point(120, 476)
        Me.btnClearEvent.Name = "btnClearEvent"
        Me.btnClearEvent.Size = New System.Drawing.Size(86, 23)
        Me.btnClearEvent.TabIndex = 4
        Me.btnClearEvent.Text = "Clear &Screen"
        Me.btnClearEvent.UseVisualStyleBackColor = True
        '
        'btnCloseEvent
        '
        Me.btnCloseEvent.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCloseEvent.Location = New System.Drawing.Point(214, 476)
        Me.btnCloseEvent.Name = "btnCloseEvent"
        Me.btnCloseEvent.Size = New System.Drawing.Size(86, 23)
        Me.btnCloseEvent.TabIndex = 5
        Me.btnCloseEvent.Text = "&Close"
        Me.btnCloseEvent.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 283)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Event result data:"
        '
        'lblEventDetails
        '
        Me.lblEventDetails.Location = New System.Drawing.Point(13, 139)
        Me.lblEventDetails.Multiline = True
        Me.lblEventDetails.Name = "lblEventDetails"
        Me.lblEventDetails.ReadOnly = True
        Me.lblEventDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.lblEventDetails.Size = New System.Drawing.Size(287, 141)
        Me.lblEventDetails.TabIndex = 8
        '
        'lblRaceResult
        '
        Me.lblRaceResult.Location = New System.Drawing.Point(13, 300)
        Me.lblRaceResult.Multiline = True
        Me.lblRaceResult.Name = "lblRaceResult"
        Me.lblRaceResult.ReadOnly = True
        Me.lblRaceResult.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.lblRaceResult.Size = New System.Drawing.Size(287, 170)
        Me.lblRaceResult.TabIndex = 9
        '
        'FRMDeleteEvent
        '
        Me.AcceptButton = Me.btnDelete
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCloseEvent
        Me.ClientSize = New System.Drawing.Size(324, 509)
        Me.Controls.Add(Me.lblRaceResult)
        Me.Controls.Add(Me.lblEventDetails)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCloseEvent)
        Me.Controls.Add(Me.btnClearEvent)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "FRMDeleteEvent"
        Me.Text = "Delete Event"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstTitle As ListBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnClearEvent As Button
    Friend WithEvents btnCloseEvent As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents lblEventDetails As TextBox
    Friend WithEvents lblRaceResult As TextBox
End Class
