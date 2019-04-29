Imports System.Data.OleDb
Public Class FRMDeleteEvent
    ' public property to hold value to be accessed by parent form
    Public raceEventObj As RaceEvent

    ' create variables to hold the race event data
    Dim raceEvents As List(Of RaceEvent)
    Dim raceEvent As RaceEvent

    Private Sub FRMDeleteEvent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            raceEvents = EventsDB.GetRaceEventTitles
            EventsDB.FillRaceEventListBox(lstTitle, raceEvents)
        Catch ex As Exception
            ' catch errors thrown previously
            MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnCloseEvent.Click
        raceEventObj = Nothing
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

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClearEvent.Click
        ResetLabels()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' raceEvent object is created each time a user changes their selection in the list box
        If lstTitle.SelectedIndex <> -1 And raceEvent IsNot Nothing Then
            Try
                ' test if any athletes have competed in the event
                If ResultsDB.CanDeleteEvent(raceEvent) Then
                    ' remove object from database 
                    Dim box As DialogResult = MessageBox.Show("Are you sure you want to delete this event", "Confirm Delete", MessageBoxButtons.YesNo)
                    If box = DialogResult.Yes Then
                        raceEventObj = New RaceEvent
                        raceEventObj = raceEvent

                        Me.Close()
                    End If
                Else
                    MessageBox.Show("Unable to delete an event once an athlete has competed in it", "Illegal Operation")
                End If
            Catch ex As ArgumentNullException
                MessageBox.Show(ex.Message.ToString, "Error: Argument Null Exception")
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
        Else
            MessageBox.Show("Please select a valid event", "Selection Error")
        End If

    End Sub

    Private Sub lstTitle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstTitle.SelectedIndexChanged
        Try
            ' get the user selection
            Dim userSelection As Integer = lstTitle.SelectedIndex
            If userSelection <> -1 Then
                ' get event data and display it
                Dim tempObj As RaceEvent = New RaceEvent
                tempObj = raceEvents.Item(userSelection)
                ' get the event title and retrieve the selected events full details
                raceEvent = EventsDB.GetRaceEventByTitle(tempObj.Title)
                lblEventDetails.Text = raceEvent.GetDisplayText

                Dim raceTimes As New List(Of RaceTime)
                raceTimes = ResultsDB.GetEventRaceTimes(raceEvent.Title)
                If raceTimes IsNot Nothing Then
                    Dim displayStr As String = ""
                    ' loop through each object in list and compose display text
                    For Each raceTime As RaceTime In raceTimes
                        displayStr += raceTime.ShowNumberAndTime()
                    Next
                    lblRaceResult.Text = displayStr
                End If
            Else
                MessageBox.Show("Please select an event to update", "Selection Error")
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
        lblEventDetails.Text = ""
        lblRaceResult.Text = ""
    End Sub

End Class



