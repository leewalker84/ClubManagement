Imports System.Data.OleDb
Public Class FRMModifyEvent
    ' public property to hold value to be accessed by parent form
    Public raceEvent As RaceEvent
    Public raceEventObj As RaceEvent
    ' create variables to hold the race event data
    Dim raceEvents As List(Of RaceEvent)

    Private Sub FRMModifyEvent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            raceEvents = EventsDB.GetRaceEventTitles
            EventsDB.FillRaceEventListBox(lstTitle, raceEvents)
            ' catch prevous exceptions thrown
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnCloseEvent.Click
        Try
            raceEventObj = Nothing
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
        ResetControlValues()
        SetControls(False)
    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        If IsValidData() And lstTitle.SelectedIndex <> -1 Then
            Try
                ' cast to correct data types
                Dim dateStr As String = dtpDate.Value.ToString()
                Dim registrationDec As Decimal = CDec(txtRegFee.Text)
                Dim distanceDec As Decimal = CDec(txtDistance.Text)

                raceEventObj = New RaceEvent(Trim(txtTitle.Text), Trim(txtLocation.Text), dateStr, registrationDec, distanceDec)

                Me.Close()
                ' catch the errors thrown by current Try and EventDB methods
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
                ' get event data, enable control, display data
                Dim tempObj As RaceEvent = New RaceEvent
                tempObj = raceEvents.Item(userSelection)
                ' get the event title and retrieve the selected events full details
                raceEvent = New RaceEvent
                raceEvent = EventsDB.GetRaceEventByTitle(tempObj.Title)

                ResetControlValues()

                SetControls(True)
                txtTitle.Text = raceEvent.Title
                txtLocation.Text = raceEvent.Location
                txtRegFee.Text = CType(raceEvent.Registration, String)
                txtDistance.Text = CType(raceEvent.Distance, String)
                dtpDate.Value = DateTime.Parse(raceEvent.DateEvent)
            End If
        Catch ex As ArgumentNullException
            MessageBox.Show(ex.Message.ToString, "Error: Argument Null Exception")
        Catch ex As ArgumentOutOfRangeException
            MessageBox.Show(ex.Message.ToString, "Error: Argument Out of Range Exception")
        Catch ex As ArgumentException
            MessageBox.Show(ex.Message.ToString, "Error: Argument Exception")
        Catch ex As FormatException
            MessageBox.Show(ex.Message.ToString & " .The format of the dates stored in the text file do not match the local date on your machine", "Error: Format Exception")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
        End Try
    End Sub

    Private Sub ResetControlValues()
        txtTitle.Text = ""
        txtLocation.Text = ""
        txtRegFee.Text = ""
        txtDistance.Text = ""
        Try
            dtpDate.Value = DateTime.Today
        Catch ex As ArgumentOutOfRangeException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetControls(bool As Boolean)
        txtTitle.Enabled = bool
        txtLocation.Enabled = bool
        txtRegFee.Enabled = bool
        txtDistance.Enabled = bool
        dtpDate.Enabled = bool
    End Sub

    Private Function IsValidData() As Boolean
        Return Validator.IsPresent(txtTitle) AndAlso
             Validator.IsPresent(txtLocation) AndAlso
             Validator.IsPresent(txtRegFee) AndAlso
             Validator.IsPresent(txtDistance) AndAlso
             Validator.IsDecimal(txtRegFee) AndAlso
             Validator.IsDecimal(txtDistance) AndAlso
             Validator.IsPositive(txtRegFee) AndAlso
             Validator.IsPositive(txtDistance)
    End Function

End Class