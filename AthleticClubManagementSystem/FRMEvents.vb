Imports System.Data.OleDb
Public Class FRMEvents
    ' create variables to hold the race event data
    Dim raceEvents As List(Of RaceEvent)
    Dim raceEvent As RaceEvent

    Private Sub FRMEvents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            raceEvents = EventsDB.GetRaceEventTitles()
            EventsDB.FillRaceEventListBox(lstTitle, raceEvents)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
        End Try
    End Sub



    Private Sub btnGoAdd_Click(sender As Object, e As EventArgs) Handles btnGoAddEvent.Click
        Dim addEventForm As New FRMAddEvent()
        Try
            addEventForm.ShowDialog()
            lblEventDetails.Text = ""

            If addEventForm.raceEventObj IsNot Nothing Then

                ' check if event name is already in the system
                Dim eventName As String = addEventForm.raceEventObj.Title
                ' if method returns a object the event name is already taken
                If EventsDB.GetRaceEventByTitle(eventName) IsNot Nothing Then
                    MessageBox.Show("Event names must be unique. Please enter a different event name", "Entry Error")
                Else
                    ' write objects to the database
                    Dim success As Boolean = EventsDB.AddRaceEvent(addEventForm.raceEventObj)

                    If success Then
                        raceEvents = EventsDB.GetRaceEventTitles()
                        EventsDB.FillRaceEventListBox(lstTitle, raceEvents)
                        MessageBox.Show("Event updated in database", "Success")
                    Else
                        MessageBox.Show("Event could not be inserted into the database", "Database Error")
                    End If
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
            addEventForm.Dispose()
        End Try
    End Sub

    Private Sub btnGoModify_Click(sender As Object, e As EventArgs) Handles btnGoModifyEvent.Click
        Dim modifyEventForm As New FRMModifyEvent()
        Try
            modifyEventForm.ShowDialog()
            lblEventDetails.Text = ""

            If modifyEventForm.raceEventObj IsNot Nothing AndAlso modifyEventForm.raceEvent IsNot Nothing Then
                ' write objects to the database 
                Dim success As Boolean = EventsDB.UpdateRaceEvent(modifyEventForm.raceEventObj, modifyEventForm.raceEvent)
                If success Then
                    ' repopulate list boxes
                    raceEvents = EventsDB.GetRaceEventTitles
                    EventsDB.FillRaceEventListBox(lstTitle, raceEvents)
                    MessageBox.Show("Event updated in database", "Success")
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
            modifyEventForm.Dispose()
        End Try
    End Sub

    Private Sub btnGoDelete_Click(sender As Object, e As EventArgs) Handles btnGoDeleteEvent.Click
        Dim deleteEventForm As New FRMDeleteEvent()
        Try
            deleteEventForm.ShowDialog()
            lblEventDetails.Text = ""

            If deleteEventForm.raceEventObj IsNot Nothing Then
                Dim success As Boolean = EventsDB.DeleteRaceEvent(deleteEventForm.raceEventObj)
                If success Then
                    ' repopulate list boxes
                    raceEvents = EventsDB.GetRaceEventTitles
                    EventsDB.FillRaceEventListBox(lstTitle, raceEvents)
                    MessageBox.Show("Event deleted from database", "Success")
                Else
                    MessageBox.Show("Event could not be deleted from database", "Database Error")
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
            deleteEventForm.Dispose()
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
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

    Private Sub btnClearAthleticEvent_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        lblEventDetails.Text = ""
    End Sub

    Private Sub lstTitle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstTitle.SelectedIndexChanged
        Try
            ' get the user selection
            Dim userSelection As Integer = lstTitle.SelectedIndex
            If userSelection <> -1 Then
                Dim tempObj As RaceEvent = New RaceEvent
                tempObj = raceEvents.Item(userSelection)
                raceEvent = EventsDB.GetRaceEventByTitle(tempObj.Title)
                lblEventDetails.Text = raceEvent.GetDisplayText
            Else
                MessageBox.Show("Please select an event to display", "Selection Error")
            End If
        Catch ex As ArgumentOutOfRangeException
            MessageBox.Show(ex.Message.ToString, "Error: Argument Out of Range Exception")
        Catch ex As ArgumentException
            MessageBox.Show(ex.Message.ToString, "Error: Argument Exception")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
        End Try
    End Sub


End Class