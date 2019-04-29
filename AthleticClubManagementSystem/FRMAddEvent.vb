
Public Class FRMAddEvent

    ' public property to hold value to be accessed by parent form
    Public raceEventObj As RaceEvent

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
        Try
            resetPage()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.GetType.ToString)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAddEvent.Click
        If IsValidData() Then
            Try
                ' cast to correct data types
                Dim dateStr As String = dtpDate.Value.ToString()
                Dim registrationDec As Decimal = CDec(Trim(txtRegFee.Text))
                Dim distanceDec As Decimal = CDec(Trim(txtDistance.Text))

                raceEventObj = New RaceEvent(Trim(txtTitle.Text), Trim(txtLocation.Text), dateStr, registrationDec, distanceDec)

                Me.Close()
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

    ' Description - used to reset the controls and an object to their original state
    Private Sub resetPage()
        txtTitle.Text = ""
        txtLocation.Text = ""
        txtRegFee.Text = ""
        txtDistance.Text = ""
        raceEventObj = Nothing
        Try
            dtpDate.Value = DateTime.Today
        Catch ex As ArgumentOutOfRangeException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ' Description - used to test the data that the user has entered is correct
    ' @return - a boolean value to indicate whether the data is good or bad
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