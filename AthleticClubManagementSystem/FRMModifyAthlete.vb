Imports System.Data.OleDb

Public Class FRMModifyAthlete
    ' public property to hold value to be accessed by parent form
    Public athlete As Athlete
    Public athleteObj As Athlete

    ' create a collection to hold the athletes
    Dim athletes As List(Of Athlete)
    Dim raceTimes As List(Of RaceTime)
    Dim athleteRaceTimes As List(Of RaceTime)

    Private Sub FRMModifyAthlete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            athletes = AthletesDB.GetAthletesNumberAndName()
            AthletesDB.FillAthleteNumberListBox(lstMemberNumber, athletes)
            ' catch exceptions thrown by previous functions
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.GetType.ToString)
        End Try
    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        Try
            ' athlete object is created each time a user changes their selection in the list box
            If IsValidData() And athlete IsNot Nothing Then
                Dim membershipNumber As String = athlete.MembershipNumber
                ' get the data that is entered on the form
                Dim firstname As String = Trim(txtName.Text)
                Dim surname As String = Trim(txtSurname.Text)
                Dim dob As String = dtpDOB.Value.ToString()
                Dim gender As String
                If rbMale.Checked = True Then
                    gender = "M"
                Else
                    gender = "F"
                End If
                Dim dateJoined As String = dtpDateJoined.Value.ToString()
                Dim amountDue As Decimal = CDec(Trim(txtAmountDue.Text))
                Dim amountPaid As Decimal = CDec(Trim(txtAmountPaid.Text))
                ' create a new object that holds the updated athlete data
                athleteObj = New Athlete(firstname, surname, dob, gender, membershipNumber, dateJoined, amountDue, amountPaid)

                Me.Close()
                'If athleteObj IsNot Nothing Then
                '    ' write objects to the database 
                '    Dim success As Boolean = AthletesDB.UpdateAthlete(athleteObj, athlete)
                '    If success Then
                '        MessageBox.Show("Athlete updated in database", "Success")
                '        ResetControlValues()
                '        SetControls(False)
                '        ' repopulate list boxes
                '        athletes = AthletesDB.GetAthletesNumberAndName()
                '        AthletesDB.FillAthleteNumberListBox(lstMemberNumber, athletes)
                '    Else
                '        MessageBox.Show("Event could not be updated", "Database Error")
                '    End If
                'End If
            Else
                MessageBox.Show("Please select an athlete to update", "Selection Error")
            End If
            ' catch the errors thrown by current Try and EventDB methods
        Catch ex As ArgumentNullException
            MessageBox.Show(ex.Message.ToString, "Error: Argument Null Exception")
        Catch ex As ArgumentException
            MessageBox.Show(ex.Message.ToString, "Error: Argument Exception")
        Catch ex As FormatException
            MessageBox.Show(ex.Message.ToString & " .The format of the dates stored in the text file do not match the local date on your machine", "Error: Format Exception")
        Catch ex As ObjectDisposedException
            MessageBox.Show(ex.Message.ToString, "Object Disposed Exception")
        Catch ex As InvalidOperationException
            MessageBox.Show(ex.Message.ToString, "Invalid Operation Exception")
        Catch ex As OleDbException
            MessageBox.Show(ex.Message.ToString, "Database Exception")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            athleteObj = Nothing
            Me.Close()
        Catch ex As ObjectDisposedException
            MessageBox.Show(ex.Message.ToString, "Object Disposed Exception")
        Catch ex As InvalidOperationException
            MessageBox.Show(ex.Message.ToString, "Invalid Operation Exception")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ResetControlValues()
        SetControls(False)
    End Sub

    Private Sub lstMemberNumber_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMemberNumber.SelectedIndexChanged
        Dim tempObj As Athlete
        Try
            ' get the user selection
            ' userSelection = lstMemberNumber.SelectedIndex
            Dim userSelection As Integer = lstMemberNumber.SelectedIndex
            If userSelection <> -1 Then
                ' userSelection = SelectedListBox(lstMemberNumber)
                tempObj = athletes.Item(userSelection)
                ' list currently stores basic data - need to get the membership number to retrive full data for selected athlete
                athlete = New Athlete
                athlete = AthletesDB.GetAthleteByNumber(tempObj.MembershipNumber)

                ' display the current values that are held for the athlete and enable the controls
                If athlete IsNot Nothing Then
                    SetControls(True)
                    txtName.Text = athlete.FirstName
                    txtSurname.Text = athlete.Surname
                    dtpDOB.Value = DateTime.Parse(athlete.DOB)
                    If athlete.Gender = "M" Then
                        rbMale.Checked = True
                    Else
                        rbFemale.Checked = True
                    End If
                    dtpDateJoined.Value = DateTime.Parse(athlete.DateJoined)
                    txtAmountDue.Text = CType(athlete.FeeAmountDue, String)
                    txtAmountPaid.Text = CType(athlete.FeeAmountPaid, String)
                End If
            Else
                MessageBox.Show("Please select an athlete to update", "Selection Error")
            End If
        Catch ex As ArgumentNullException
            MessageBox.Show(ex.Message.ToString, "Error: Argument Null Exception")
        Catch ex As ArgumentOutOfRangeException
            MessageBox.Show(ex.Message.ToString, "Error: Argument Out of Range Exception")
        Catch ex As FormatException
            MessageBox.Show(ex.Message.ToString & " .The format of the dates stored in the text file do not match the local date on your machine", "Error: Format Exception")
        Catch ex As ArgumentException
            MessageBox.Show(ex.Message.ToString, "Error: Argument Exception")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
        End Try
    End Sub

    Private Sub ResetControlValues()
        txtName.Text = ""
        txtSurname.Text = ""
        rbMale.Checked = True
        txtAmountDue.Text = ""
        txtAmountPaid.Text = ""
    End Sub

    Private Sub SetControls(bool As Boolean)
        txtName.Enabled = bool
        txtSurname.Enabled = bool
        dtpDOB.Enabled = bool
        rbMale.Enabled = bool
        rbFemale.Enabled = bool
        dtpDateJoined.Enabled = bool
        txtAmountDue.Enabled = bool
        txtAmountPaid.Enabled = bool
        Try
            dtpDOB.Value = DateTime.Today
            dtpDateJoined.Value = DateTime.Today
        Catch ex As ArgumentOutOfRangeException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub resetPage()
        txtName.Text = ""
        txtSurname.Text = ""
        rbMale.Checked = True
        txtAmountDue.Text = ""
        txtAmountPaid.Text = ""
        txtName.Enabled = False
        txtSurname.Enabled = False
        dtpDOB.Enabled = False
        rbMale.Enabled = False
        rbFemale.Enabled = False
        dtpDateJoined.Enabled = False
        txtAmountDue.Enabled = False
        txtAmountPaid.Enabled = False
        athleteObj = Nothing
        Try
            dtpDOB.Value = DateTime.Today
            dtpDateJoined.Value = DateTime.Today
        Catch ex As ArgumentOutOfRangeException
            MessageBox.Show(ex.Message.ToString, "Error: Argument Out of Range Exception")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
        End Try

    End Sub

    Private Function IsValidData() As Boolean
        Return Validator.IsPresent(txtName) AndAlso
             Validator.IsPresent(txtSurname) AndAlso
             Validator.IsPresent(txtAmountDue) AndAlso
             Validator.IsPresent(txtAmountPaid) AndAlso
             Validator.IsDecimal(txtAmountDue) AndAlso
             Validator.IsDecimal(txtAmountPaid) AndAlso
             Validator.IsPositive(txtAmountDue) AndAlso
             Validator.IsPositive(txtAmountPaid) AndAlso
             Validator.IsValidDOB(dtpDOB) AndAlso
             Validator.IsValidJoinDate(dtpDOB, dtpDateJoined)
    End Function


End Class