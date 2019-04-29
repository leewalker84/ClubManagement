Public Class FRMDeleteAthlete
    ' create a variable to hold the data for selected athlete
    Public athleteObj As Athlete
    ' create a collection to hold the athletes and the athletes race results
    Dim athletes As List(Of Athlete)
    Dim raceTimes As List(Of RaceTime)
    Dim athleteRaceTimes As List(Of RaceTime)
    Dim athlete As Athlete

    Private Sub FRMDeleteAthlete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            athletes = AthletesDB.GetAthletesNumberAndName()
            AthletesDB.FillAthleteNumberListBox(lstMemberNumber, athletes)
            ' catch exceptions thrown by previous functions
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.GetType.ToString)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' athlete object is created each time a user changes their selection in the list box
        If lstMemberNumber.SelectedIndex <> -1 And athlete IsNot Nothing Then
            Try
                ' test if any athletes have competed in the event
                If ResultsDB.CanDeleteAthlete(athlete) Then
                    ' remove object from database 
                    Dim box As DialogResult = MessageBox.Show("Are you sure you want to delete this athlete", "Confirm Delete", MessageBoxButtons.YesNo)
                    If box = DialogResult.Yes Then
                        athleteObj = New Athlete
                        athleteObj = athlete

                        Me.Close()
                    End If
                Else
                    MessageBox.Show("Unable to delete an athlete once an athlete has competed in an event", "Illegal Operation")
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
        Else
            MessageBox.Show("Please select a valid athlete", "Selection Error")
        End If

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
        resetPage()
    End Sub

    Private Sub lstMemberNumber_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMemberNumber.SelectedIndexChanged
        Dim tempObj As Athlete
        Try
            ' get the user selection
            Dim userSelection As Integer = lstMemberNumber.SelectedIndex
            If userSelection <> -1 Then
                ' userSelection = SelectedListBox(lstMemberNumber)
                tempObj = athletes.Item(userSelection)
                ' list currently stores basic data - need to get the membership number to retrive full data for selected athlete
                athlete = New Athlete
                athlete = AthletesDB.GetAthleteByNumber(tempObj.MembershipNumber)

                Dim raceTimes As New List(Of RaceTime)
                raceTimes = ResultsDB.GetAthleteRaceTimes(tempObj.MembershipNumber)

                ' display the athletes personal data
                If athlete IsNot Nothing Then
                    lblMemberDetails.Text = athlete.GetDisplayText
                End If

                ' display the athletes race data
                If raceTimes IsNot Nothing Then
                    Dim displayStr As String = ""
                    ' loop through each object in list and compose display text
                    For Each raceTime As RaceTime In raceTimes
                        displayStr += raceTime.ShowNameAndTime()
                    Next
                    lblRaceResult.Text = displayStr
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
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
        End Try
    End Sub

    Private Sub resetPage()
        lblMemberDetails.Text = ""
        lblRaceResult.Text = ""
    End Sub

End Class