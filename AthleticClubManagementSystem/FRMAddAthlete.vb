Imports System.Data.OleDb
Public Class FRMAddAthlete
    ' public property to hold value to be accessed by parent form
    Public athleteObj As Athlete

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
        resetPage()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If IsValidData() Then
            Try
                ' get the data entered by user
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

                ' create the membership number
                Dim membershipNumber = Validator.CreateMembershipNumber(dtpDateJoined, dtpDOB)

                ' validate membership number
                If Validator.IsValidMembershipNumber(membershipNumber) Then
                    ' create new athelte
                    athleteObj = New Athlete(firstname, surname, dob, gender, membershipNumber, dateJoined, amountDue, amountPaid)

                    Me.Close()
                Else
                    MessageBox.Show("Membership number creation incorrect. Please try again", "Validation Error")
                    resetPage()
                End If
            Catch ex As ArgumentNullException
                MessageBox.Show(ex.Message.ToString, "Error: Argument Null Exception")
            Catch ex As FormatException
                MessageBox.Show(ex.Message.ToString & " .The format of the dates stored in the text file do not match the local date on your machine", "Error: Format Exception")
            Catch ex As ObjectDisposedException
                MessageBox.Show(ex.Message.ToString, "Object Disposed Exception")
            Catch ex As InvalidOperationException
                MessageBox.Show(ex.Message.ToString, "Invalid Operation Exception")
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
            End Try
        End If
    End Sub

    Private Sub resetPage()
        txtName.Text = ""
        txtSurname.Text = ""
        rbMale.Checked = True
        txtAmountDue.Text = ""
        txtAmountPaid.Text = ""
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