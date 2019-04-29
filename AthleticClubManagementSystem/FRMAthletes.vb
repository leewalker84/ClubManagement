Imports System.Data.OleDb
Public Class FRMAthletes
    ' create a collection to hold the athletes and the athletes race results
    Dim athletes As List(Of Athlete)
    Dim athleteRaceTimes As List(Of RaceTime)

    Private Sub FRMAthletes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' get data from database
            ' Sub assigns values to module level variable inside procedure
            athletes = AthletesDB.GetAthletesNumberAndName()
            ' populate the list boxes
            AthletesDB.FillAthleteNameListBox(lstMemberName, athletes)
            AthletesDB.FillAthleteNumberListBox(lstMemberNumber, athletes)
            ' catch exceptions thrown by previous functions
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.GetType.ToString)
        End Try
    End Sub

    Private Sub btnGoAddAthlete_Click(sender As Object, e As EventArgs) Handles BtnGoAddAthlete.Click
        Dim addAthleteForm As New FRMAddAthlete()
        Try
            addAthleteForm.ShowDialog()
            ResetLabels()

            If addAthleteForm.athleteObj IsNot Nothing Then
                ' write objects to the database
                Dim success As Boolean = AthletesDB.AddAthlete(addAthleteForm.athleteObj)

                If success Then
                    athletes = AthletesDB.GetAthletesNumberAndName()
                    ' populate the list boxes
                    AthletesDB.FillAthleteNameListBox(lstMemberName, athletes)
                    AthletesDB.FillAthleteNumberListBox(lstMemberNumber, athletes)
                    MessageBox.Show("Event updated in database", "Success")
                Else
                    MessageBox.Show("Event could not be inserted into the database", "Database Error")
                End If
            End If
        Catch ex As ArgumentNullException
            MessageBox.Show(ex.Message.ToString, "Error: Argument Null Exception")
        Catch ex As InvalidOperationException
            MessageBox.Show(ex.Message.ToString, "Error: Invalid Operation Exception")
        Catch ex As OleDbException
            MessageBox.Show(ex.Message.ToString, "Database Exception")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
        Finally
            addAthleteForm.Dispose()
        End Try
    End Sub


    Private Sub btnGoModifyAthlete_Click(sender As Object, e As EventArgs) Handles BtnGoModifyAthlete.Click
        Dim modifyAthleteForm As New FRMModifyAthlete()
        Try
            modifyAthleteForm.ShowDialog()
            ResetLabels()

            If modifyAthleteForm.athleteObj IsNot Nothing AndAlso modifyAthleteForm.athlete IsNot Nothing Then
                ' write objects to the database 
                Dim success As Boolean = AthletesDB.UpdateAthlete(modifyAthleteForm.athleteObj, modifyAthleteForm.athlete)
                If success Then
                    ' repopulate list boxes
                    athletes = AthletesDB.GetAthletesNumberAndName()
                    AthletesDB.FillAthleteNameListBox(lstMemberName, athletes)
                    AthletesDB.FillAthleteNumberListBox(lstMemberNumber, athletes)
                    MessageBox.Show("Athlete updated in database", "Success")
                Else
                    MessageBox.Show("Event could not be updated", "Database Error")
                End If
            End If
        Catch ex As ArgumentNullException
            MessageBox.Show(ex.Message.ToString, "Error: Argument Null Exception")
        Catch ex As InvalidOperationException
            MessageBox.Show(ex.Message.ToString, "Error: Invalid Operation Exception")
        Catch ex As OleDbException
            MessageBox.Show(ex.Message.ToString, "Database Exception")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
        Finally
            modifyAthleteForm.Dispose()
        End Try
    End Sub

    Private Sub btnGoDeleteAthlete_Click(sender As Object, e As EventArgs) Handles BtnGoDeleteAthlete.Click
        Dim deleteAthleteForm As New FRMDeleteAthlete()
        Try
            deleteAthleteForm.ShowDialog()
            ResetLabels()

            If deleteAthleteForm.athleteObj IsNot Nothing Then
                Dim success As Boolean = AthletesDB.DeleteAthlete(deleteAthleteForm.athleteObj)
                If success Then
                    athletes = AthletesDB.GetAthletesNumberAndName()
                    ' populate the list boxes
                    AthletesDB.FillAthleteNameListBox(lstMemberName, athletes)
                    AthletesDB.FillAthleteNumberListBox(lstMemberNumber, athletes)
                    MessageBox.Show("Athlete deleted from database", "Success")
                Else
                    MessageBox.Show("Athlete could not be deleted from database", "Database Error")
                End If
            End If
        Catch ex As ArgumentNullException
            MessageBox.Show(ex.Message.ToString, "Error: Argument Null Exception")
        Catch ex As InvalidOperationException
            MessageBox.Show(ex.Message.ToString, "Error: Invalid Operation Exception")
        Catch ex As OleDbException
            MessageBox.Show(ex.Message.ToString, "Database Exception")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
        Finally
            deleteAthleteForm.Dispose()
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnCloseAthlete.Click
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

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClearAthlete.Click
        ResetLabels()
        rbMembershipNum.Checked = True
    End Sub

    ' @description - procedure to test which radio button is selected then to enable or disable a control based on selection
    Private Sub athleteSelection_CheckedChanged(sender As Object, e As EventArgs) Handles rbMembershipNum.CheckedChanged, rbAthleteName.CheckedChanged
        SetControlsAfterCheckChanged(rbMembershipNum, lstMemberNumber, lstMemberName)
        SetControlsAfterCheckChanged(rbAthleteName, lstMemberName, lstMemberNumber)
        ResetLabels()
    End Sub

    Private Sub SetControlsAfterCheckChanged(rb As RadioButton, listOne As ListBox, listTwo As ListBox)
        If rb.Checked Then
            listOne.Enabled = True
            listTwo.Enabled = False
        End If
    End Sub

    Private Sub displayAthleteData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMemberNumber.SelectedIndexChanged, lstMemberName.SelectedIndexChanged
        Dim raceTimes As New List(Of RaceTime)
        Dim athleteObj As New Athlete
        Dim tempObj As Athlete
        Dim userSelection As Integer
        Dim displayStr As String = ""

        Try
            If rbMembershipNum.Checked = True Then
                ' userSelection = SelectedListBox(lstMemberNumber)
                userSelection = lstMemberNumber.SelectedIndex
                tempObj = athletes.Item(userSelection)
                athleteObj = AthletesDB.GetAthleteByNumber(tempObj.MembershipNumber)
            Else
                ' userSelection = SelectedListBox(lstMemberName)
                userSelection = lstMemberName.SelectedIndex
                tempObj = athletes.Item(userSelection)
                athleteObj = AthletesDB.GetAthleteByName(tempObj.FirstName, tempObj.Surname)
            End If

            If athleteObj IsNot Nothing Then
                lblMemberDetails.Text = athleteObj.GetDisplayText
                raceTimes = ResultsDB.GetAthleteRaceTimes(athleteObj.MembershipNumber)
                ' display the athletes race data
                If raceTimes IsNot Nothing Then
                    ' loop through each object in list and compose display text
                    For Each raceTime As RaceTime In raceTimes
                        displayStr += raceTime.ShowNameAndTime()
                    Next
                    lblRaceResult.Text = displayStr
                End If
            Else
                MessageBox.Show("Please select an athlete to display", "Selection Error")
            End If
        Catch ex As ArgumentOutOfRangeException
            MessageBox.Show(ex.Message.ToString, "Error: Argument Out of Range Exception")
        Catch ex As ArgumentException
            MessageBox.Show(ex.Message.ToString, "Error: Argument Exception")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
        End Try
    End Sub

    Private Sub ResetLabels()
        lblMemberDetails.Text = ""
        lblRaceResult.Text = ""
    End Sub

End Class