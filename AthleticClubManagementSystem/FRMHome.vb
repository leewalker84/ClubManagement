Public Class FRMHome

    Private Sub btnManageAthletes_Click(sender As Object, e As EventArgs) Handles btnManageAthletes.Click
        ' 1st create a new instance of the form to be opened
        Dim athletesForm As New FRMAthletes
        ' now call the show() of the new form to display and load the form
        athletesForm.Show()
    End Sub

    Private Sub btnManageRaceResults_Click(sender As Object, e As EventArgs) Handles BtnManageRaceResults.Click
        Dim raceResultsForm As New FRMRaceResults()
        raceResultsForm.Show()
    End Sub

    Private Sub btnManageEvents_Click(sender As Object, e As EventArgs) Handles BtnManageEvents.Click
        Dim eventsForm As New FRMEvents()
        eventsForm.Show()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
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

End Class
