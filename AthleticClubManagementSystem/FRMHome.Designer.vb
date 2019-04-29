<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRMHome
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
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnManageEvents = New System.Windows.Forms.Button()
        Me.BtnManageRaceResults = New System.Windows.Forms.Button()
        Me.btnManageAthletes = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnExit
        '
        Me.BtnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnExit.Location = New System.Drawing.Point(225, 207)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 1
        Me.BtnExit.Text = "E&xit"
        Me.BtnExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnManageEvents)
        Me.GroupBox1.Controls.Add(Me.BtnManageRaceResults)
        Me.GroupBox1.Controls.Add(Me.btnManageAthletes)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 88)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(292, 113)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select system"
        '
        'BtnManageEvents
        '
        Me.BtnManageEvents.Location = New System.Drawing.Point(7, 78)
        Me.BtnManageEvents.Name = "BtnManageEvents"
        Me.BtnManageEvents.Size = New System.Drawing.Size(279, 23)
        Me.BtnManageEvents.TabIndex = 2
        Me.BtnManageEvents.Text = "Manage Athletic &Event"
        Me.BtnManageEvents.UseVisualStyleBackColor = True
        '
        'BtnManageRaceResults
        '
        Me.BtnManageRaceResults.Location = New System.Drawing.Point(7, 49)
        Me.BtnManageRaceResults.Name = "BtnManageRaceResults"
        Me.BtnManageRaceResults.Size = New System.Drawing.Size(279, 23)
        Me.BtnManageRaceResults.TabIndex = 1
        Me.BtnManageRaceResults.Text = "&Record Race Result"
        Me.BtnManageRaceResults.UseVisualStyleBackColor = True
        '
        'btnManageAthletes
        '
        Me.btnManageAthletes.Location = New System.Drawing.Point(7, 20)
        Me.btnManageAthletes.Name = "btnManageAthletes"
        Me.btnManageAthletes.Size = New System.Drawing.Size(279, 23)
        Me.btnManageAthletes.TabIndex = 0
        Me.btnManageAthletes.Text = "Manage &Athlete"
        Me.btnManageAthletes.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Gauteng Far West Running Club"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(288, 25)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Athletic Club Management"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(191, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Copyright (c) 2018. All rights reservered"
        '
        'FRMHome
        '
        Me.AcceptButton = Me.btnManageAthletes
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnExit
        Me.ClientSize = New System.Drawing.Size(316, 240)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnExit)
        Me.Name = "FRMHome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Athletic Club Management"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnExit As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BtnManageEvents As Button
    Friend WithEvents BtnManageRaceResults As Button
    Friend WithEvents btnManageAthletes As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
