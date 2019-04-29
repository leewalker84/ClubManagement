Public Class FRMRaceResults
    ' create collections to hold the athletes, events and race results
    Private athletes As List(Of Athlete)
    Private raceEvents As List(Of RaceEvent)
    Private raceTimes As List(Of RaceTime)

    Dim athleteObj As Athlete

    Private Sub FRMRaceResults_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            athletes = AthletesDB.GetAthletesNumberAndName()
            raceEvents = EventsDB.GetRaceEventTitles
            AthletesDB.FillAthleteNameListBox(lstMemberName, athletes)
            EventsDB.FillRaceEventListBox(lstTitle, raceEvents)
        Catch ex As Exception
            ' catch exceptions thrown previously
            MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
        End Try
    End Sub

    Private Sub btnFindMember_Click(sender As Object, e As EventArgs) Handles btnFindMember.Click
        Try
            FindMemberDetails()
        Catch ex As Exception
            ' catch exceptions thrown previously
            MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
        End Try
    End Sub

    Private Sub btnAddRaceResult_Click(sender As Object, e As EventArgs) Handles btnAddRaceResult.Click
        If isValidData() Then
            Try
                ' get event title, member num and race time
                Dim raceEventobj As RaceEvent
                raceEventobj = New RaceEvent
                raceEventObj = raceEvents(lstTitle.SelectedIndex)
                Dim eventName As String = raceEventObj.Title
                Dim membershipNumber As String = lblMemberNumber.Text
                Dim time As String = txtRaceTime.Text

                ' test to see if user has a result recored in the race
                Dim obj As New RaceTime

                obj = ResultsDB.EventHasAthlete(eventName, membershipNumber)

                If obj Is Nothing Then
                    ' create object
                    Dim raceTimeObj As RaceTime
                    raceTimeObj = New RaceTime
                    raceTimeObj.EventName = eventName
                    raceTimeObj.MembershipNumber = membershipNumber
                    raceTimeObj.RaceTime = time

                    If raceTimeObj IsNot Nothing Then
                        ' write objects to the database
                        Dim success As Boolean = ResultsDB.AddRaceResult(raceTimeObj)

                        If success Then
                            MessageBox.Show("Race Time added to database", "Success")
                        Else
                            MessageBox.Show("Race Time could not be inserted into the database", "Database Error")
                        End If
                    End If
                Else
                    MessageBox.Show("An athlete can not record two results in the same event" & vbCrLf & vbCrLf & "Existing entry: " & vbCrLf & obj.GetSingleLineDisplayText, "Entry Error")
                End If
            Catch ex As ArgumentOutOfRangeException
                MessageBox.Show(ex.Message.ToString, "Error: Argument Out of Range Exception")
            Catch ex As ArgumentException
                MessageBox.Show(ex.Message.ToString, "Error: Argument Exception")
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
            End Try
        End If
    End Sub

    Private Sub btnCloseRaceResult_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            Me.Close()
        Catch ex As ObjectDisposedException
            MessageBox.Show(ex.Message.ToString, "Object Disposed Exception")
        Catch ex As InvalidOperationException
            MessageBox.Show(ex.Message.ToString, "Invalid Operation Exception")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
        End Try
    End Sub

    Private Sub btnClearRaceResult_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        resetPage()
    End Sub

    Private Sub memberSelection_CheckedChanged(sender As Object, e As EventArgs) Handles rbNum.CheckedChanged, rbName.CheckedChanged
        If rbName.Checked = True Then
            lstMemberName.Enabled = True
            txtMemberNumber.Enabled = False
        End If
        If rbNum.Checked = True Then
            txtMemberNumber.Enabled = True
            lstMemberName.Enabled = False
        End If
        resetLabels()
    End Sub

    Private Sub lstResultsAthleteName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMemberName.SelectedIndexChanged
        Try
            FindMemberDetails()
        Catch ex As Exception
            ' catch exceptions thrown previously
            MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
        End Try
    End Sub

    Private Sub DisplayMemberData()
        lblMemberDetails.Text = athleteObj.GetDisplayText
        lblMemberName.Text = athleteObj.GetName
        lblMemberNumber.Text = athleteObj.GetAthleteNumber
    End Sub
    Private Sub lstTitle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstTitle.SelectedIndexChanged
        txtRaceTime.Text = ""
    End Sub

    Private Sub resetPage()
        resetLabels()
        rbName.Checked = True
        lstTitle.SelectedIndex = -1
    End Sub

    Private Sub resetLabels()
        lblMemberDetails.Text = ""
        lblMemberNumber.Text = ""
        lblMemberName.Text = ""
        txtMemberNumber.Text = ""
        txtRaceTime.Text = ""
    End Sub

    Private Sub FindMemberDetails()
        Try
            athleteObj = New Athlete

            If rbName.Checked Then
                ' get the user selection
                Dim userSelection As Integer = lstMemberName.SelectedIndex
                If userSelection <> -1 Then
                    ' get athlete data and display it
                    Dim athlete As New Athlete
                    athlete = athlete
                    athlete = athletes.Item(userSelection)
                    athleteObj = AthletesDB.GetAthleteByName(athlete.FirstName, athlete.Surname)
                    DisplayMemberData()
                Else
                    MessageBox.Show("Please select an athlete", "Selection Error")
                End If
            End If

            If rbNum.Checked AndAlso Validator.IsDecimal(txtMemberNumber) Then
                ' get the user input
                Dim userInput As String = txtMemberNumber.Text
                ' validate check digit
                If Validator.IsValidMembershipNumber(userInput) Then
                    athleteObj = AthletesDB.GetAthleteByNumber(userInput)
                    If athleteObj IsNot Nothing Then
                        ' display data
                        DisplayMemberData()
                    Else
                        MessageBox.Show("The membership number you entered is not assigned to a member. Please Enter a valid membership number", "Entry Error")
                    End If
                Else
                    MessageBox.Show("The membership number you entered is not valid. Please Enter a valid membership number", "Entry Error")
                End If
            End If
        Catch ex As ArgumentNullException
            Throw ex
        Catch ex As ArgumentOutOfRangeException
            Throw ex
        Catch ex As FormatException
            Throw ex
        Catch ex As ArgumentException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function isValidData() As Boolean
        Return Validator.IsPresent(lblMemberNumber) AndAlso
            Validator.IsPresent(txtRaceTime) AndAlso
            Validator.IsCorrectLength(txtRaceTime) AndAlso
            Validator.IsCorrectTime(txtRaceTime) AndAlso
            Validator.IsSelected(lstTitle)
    End Function
End Class