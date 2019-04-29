<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMAddEvent
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.txtRegFee = New System.Windows.Forms.TextBox()
        Me.txtDistance = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAddEvent = New System.Windows.Forms.Button()
        Me.btnClearEvent = New System.Windows.Forms.Button()
        Me.btnCloseEvent = New System.Windows.Forms.Button()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Title:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "&Location:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "&Registration fee:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Dista&nce (miles):"
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(102, 15)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(100, 20)
        Me.txtTitle.TabIndex = 1
        Me.txtTitle.Tag = "Title"
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(102, 54)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(100, 20)
        Me.txtLocation.TabIndex = 3
        Me.txtLocation.Tag = "Location"
        '
        'txtRegFee
        '
        Me.txtRegFee.Location = New System.Drawing.Point(102, 93)
        Me.txtRegFee.Name = "txtRegFee"
        Me.txtRegFee.Size = New System.Drawing.Size(100, 20)
        Me.txtRegFee.TabIndex = 5
        Me.txtRegFee.Tag = "Fee"
        '
        'txtDistance
        '
        Me.txtDistance.Location = New System.Drawing.Point(102, 132)
        Me.txtDistance.Name = "txtDistance"
        Me.txtDistance.Size = New System.Drawing.Size(100, 20)
        Me.txtDistance.TabIndex = 7
        Me.txtDistance.Tag = "Distance"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 178)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "&Date:"
        '
        'btnAddEvent
        '
        Me.btnAddEvent.Location = New System.Drawing.Point(18, 216)
        Me.btnAddEvent.Name = "btnAddEvent"
        Me.btnAddEvent.Size = New System.Drawing.Size(86, 23)
        Me.btnAddEvent.TabIndex = 10
        Me.btnAddEvent.Text = "&Add Event"
        Me.btnAddEvent.UseVisualStyleBackColor = True
        '
        'btnClearEvent
        '
        Me.btnClearEvent.Location = New System.Drawing.Point(118, 216)
        Me.btnClearEvent.Name = "btnClearEvent"
        Me.btnClearEvent.Size = New System.Drawing.Size(86, 23)
        Me.btnClearEvent.TabIndex = 11
        Me.btnClearEvent.Text = "Clear &Screen"
        Me.btnClearEvent.UseVisualStyleBackColor = True
        '
        'btnCloseEvent
        '
        Me.btnCloseEvent.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCloseEvent.Location = New System.Drawing.Point(218, 216)
        Me.btnCloseEvent.Name = "btnCloseEvent"
        Me.btnCloseEvent.Size = New System.Drawing.Size(86, 23)
        Me.btnCloseEvent.TabIndex = 12
        Me.btnCloseEvent.Text = "&Close"
        Me.btnCloseEvent.UseVisualStyleBackColor = True
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = ""
        Me.dtpDate.Location = New System.Drawing.Point(102, 171)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(209, 20)
        Me.dtpDate.TabIndex = 13
        '
        'FRMAddEvent
        '
        Me.AcceptButton = Me.btnAddEvent
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCloseEvent
        Me.ClientSize = New System.Drawing.Size(323, 257)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.btnCloseEvent)
        Me.Controls.Add(Me.btnClearEvent)
        Me.Controls.Add(Me.btnAddEvent)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDistance)
        Me.Controls.Add(Me.txtRegFee)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FRMAddEvent"
        Me.Text = "Add Event"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents txtRegFee As TextBox
    Friend WithEvents txtDistance As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnAddEvent As Button
    Friend WithEvents btnClearEvent As Button
    Friend WithEvents btnCloseEvent As Button
    Friend WithEvents dtpDate As DateTimePicker
End Class
