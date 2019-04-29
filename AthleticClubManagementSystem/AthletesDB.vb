Imports System.Data.OleDb

Public Class AthletesDB
    ' class created to work with the data from the Athlete management system
    ' Methods are set to Public so they are available to rest of program
    ' Methods set to Shared so that they are accessible without the creation of a AtheletesDB object

    Public Shared Function GetAthletesNumberAndName() As List(Of Athlete)
        ' variable to hold list and athlete
        Dim athleteList As New List(Of Athlete)
        Dim athlete As Athlete

        ' create the database connection
        Dim connection As OleDbConnection = AthleticClubDB.GetConnection()
        ' create the SQL query
        Dim selectQuery As String = "SELECT athMemberNum, athName, athSurname FROM t_athlete"

        ' create the command from the query and the connection
        Dim selectCommand As New OleDbCommand(selectQuery, connection)

        Try
            ' open the connection to the databse
            connection.Open()

            ' exucute a command that produces a result set - use the ExecuteReader method
            ' include CommandBehavior.CloseConnection as arg to auto close connection when reader is closed
            Dim reader As OleDbDataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection)
            ' retrieve the result set and add to list
            Do While reader.Read()
                athlete = New Athlete
                athlete.MembershipNumber = reader("athMemberNum").ToString
                athlete.FirstName = reader("athName").ToString
                athlete.Surname = reader("athSurname").ToString
                athleteList.Add(athlete)
            Loop
            reader.Close()
        Catch ex As OleDbException
            ' throw exception so that it can be handled by calling procedure
            Throw ex
        Finally
            connection.Close()
        End Try

        Return athleteList
    End Function

    ' Description - used to get a single athlete from the database
    ' @param - the first name of the athete 
    ' @param - the surname of the athete
    ' @return - a single row of data that is associated with the athlete
    Public Shared Function GetAthleteByName(name As String, surname As String) As Athlete
        ' variable to hold athlete
        Dim athlete As New Athlete
        ' create the database connection
        Dim connection As OleDbConnection = AthleticClubDB.GetConnection()
        ' create the SQL query
        Dim selectQuery As String = "SELECT athMemberNum, athName, athSurname, athDOB, athGender, athDateJoined, athFeeDue, athFeepaid FROM T_athlete WHERE athName = ? AND athSurname = ?"

        ' create the command from the query and the connection
        Dim selectCommand As New OleDbCommand(selectQuery, connection)

        ' create parameter for the command - (para name, value)
        selectCommand.Parameters.AddWithValue("athName", name)
        selectCommand.Parameters.AddWithValue("athSurname", surname)
        Try
            ' open the connection to the databse
            connection.Open()

            ' exucute a command that produces a result set - use the ExecuteReader method
            ' single row is not a singluar value so ExecuteScalar is not appropriate
            ' include CommandBehavior.CloseConnection as arg to auto close connection when reader is closed
            Dim reader As OleDbDataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection)

            ' retrieve the result set and set object properties
            If reader.Read() Then
                SetAthleteProperties(athlete, reader)
            Else
                athlete = Nothing
            End If

            reader.Close()
        Catch ex As OleDbException
            ' throw exception so that it can be handled by calling procedure
            Throw ex
        Finally
            connection.Close()
        End Try

        Return athlete
    End Function

    ' Description - used to get a single athlete from the database
    ' @param - the membership number of the athete 
    ' @return - a single row of data that is associated with the athlete
    Public Shared Function GetAthleteByNumber(number As String) As Athlete
        ' variable to hold athlete
        Dim athlete As New Athlete

        ' create the database connection
        Dim connection As OleDbConnection = AthleticClubDB.GetConnection()
        ' create the SQL query
        Dim selectQuery As String = "SELECT athMemberNum, athName, athSurname, athDOB, athGender, athDateJoined, athFeeDue, athFeepaid FROM T_athlete WHERE athMemberNum = ?"

        ' create the command from the query and the connection
        Dim selectCommand As New OleDbCommand(selectQuery, connection)

        ' create parameter for the command - (para name, value)
        selectCommand.Parameters.AddWithValue("athMemberNum", number)

        Try
            ' open the connection to the databse
            connection.Open()

            ' exucute a command that produces a result set - use the ExecuteReader method
            ' single row is not a singluar value so ExecuteScalar is not appropriate
            ' include CommandBehavior.CloseConnection as arg to auto close connection when reader is closed
            Dim reader As OleDbDataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection)

            ' retrieve the result set and set object properties
            If reader.Read() Then
                SetAthleteProperties(athlete, reader)
            Else
                athlete = Nothing
            End If

            reader.Close()
        Catch ex As OleDbException
            ' throw exception so that it can be handled by calling procedure
            Throw ex
        Finally
            connection.Close()
        End Try

        Return athlete

    End Function

    ' Description - Used to insert a new athlete into the database
    ' @param - an athlete object containing one athletes data
    ' @return - an integar value to indicate whether the operation was a success
    Public Shared Function AddAthlete(ath As Athlete) As Boolean
        ' create the database connection
        Dim connection As OleDbConnection = AthleticClubDB.GetConnection()
        ' create the SQL query
        Dim insertQuery As String = "INSERT INTO T_athlete (athMemberNum, athName, athSurname, athDOB, athGender, athDateJoined, athFeeDue, athFeePaid) VALUES (?, ?, ?, ?, ?, ?, ?, ?)"

        ' create the command from the query and the connection
        Dim insertCommand As New OleDbCommand(insertQuery, connection)
        ' create parameters for the command - (para name, value)
        insertCommand.Parameters.AddWithValue("athMemberNum", ath.MembershipNumber)
        insertCommand.Parameters.AddWithValue("athName", ath.FirstName)
        insertCommand.Parameters.AddWithValue("athSurname", ath.Surname)
        insertCommand.Parameters.AddWithValue("athDOB", DateTime.Parse(ath.DOB))
        insertCommand.Parameters.AddWithValue("athGender", ath.Gender)
        insertCommand.Parameters.AddWithValue("athDateJoined", DateTime.Parse(ath.DateJoined))
        insertCommand.Parameters.AddWithValue("athFeeDue", ath.FeeAmountDue)
        insertCommand.Parameters.AddWithValue("athFeePaid", ath.FeeAmountPaid)

        Try
            connection.Open()
            ' use the ExecuteNonQuery method to run a action query (insert, update, delete)
            Dim count As Integer = insertCommand.ExecuteNonQuery()

            ' test to see if the operation was successful
            If count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As OleDbException
            Throw ex
        Finally
            connection.Close()
        End Try
    End Function

    ' Description - used to update an athletes values in the database
    ' @param - two race event object, one to hold the existing data values and one to hold the new data values
    ' @return - an boolean value to indicate whether the operation was a success
    Public Shared Function UpdateAthlete(newAth As Athlete, oldAth As Athlete) As Boolean
        ' create the database connection
        Dim connection As OleDbConnection = AthleticClubDB.GetConnection()
        ' create the SQL query          athMemberNum, athName, athSurname, athDOB, athGender, athDateJoined, athFeeDue, athFeePaid
        Dim updateQuery As String = "UPDATE T_athlete SET athName = ?, athSurname = ?, athDOB = ?, athGender = ?, athDateJoined = ?, athFeeDue = ?, athFeePaid = ? WHERE athMemberNum = ?"
        Dim updateCommand As New OleDbCommand(updateQuery, connection)

        ' create parameters
        updateCommand.Parameters.AddWithValue("newAthName", newAth.FirstName)
        updateCommand.Parameters.AddWithValue("newAthSurname", newAth.Surname)
        updateCommand.Parameters.AddWithValue("newAthDOB", DateTime.Parse(newAth.DOB))
        updateCommand.Parameters.AddWithValue("newAthGender", newAth.Gender)
        updateCommand.Parameters.AddWithValue("newAthDateJoined", DateTime.Parse(newAth.DateJoined))
        updateCommand.Parameters.AddWithValue("newAthFeeDue", newAth.FeeAmountDue)
        updateCommand.Parameters.AddWithValue("newAthFeePaid", newAth.FeeAmountPaid)
        updateCommand.Parameters.AddWithValue("oldAthMemberNum", oldAth.MembershipNumber)

        Try
            connection.Open()
            ' use the ExecuteNonQuery method to run a action query (insert, update, delete)
            Dim count As Integer = updateCommand.ExecuteNonQuery()
            ' test to see if the operation was successful
            If count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As OleDbException
            Throw ex
        Finally
            connection.Close()
        End Try
    End Function

    ' Description - Used to delete a athlete from the database
    ' @param - an athlete object containing one athletes data
    ' @return - an integar value to indicate whether the operation was a success
    Public Shared Function DeleteAthlete(ath As Athlete) As Boolean
        ' create the database connection
        Dim connection As OleDbConnection = AthleticClubDB.GetConnection()
        ' create the SQL query
        Dim deleteQuery As String = "DELETE FROM T_athlete WHERE athMemberNum = ?"
        Dim deleteCommand As New OleDbCommand(deleteQuery, connection)
        deleteCommand.Parameters.AddWithValue("athMemberNum", ath.MembershipNumber)

        Try
            connection.Open()
            ' use the ExecuteNonQuery method to run a action query (insert, update, delete)
            Dim count As Integer = deleteCommand.ExecuteNonQuery()
            ' test to see if the operation was successful
            If count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As OleDbException
            Throw ex
        Finally
            connection.Close()
        End Try
    End Function

    ' Description - used for for setting the properties of an athlete object
    ' @param - the athlete object that the properties should be set in
    ' @param - the database object for reading the data from
    Private Shared Sub SetAthleteProperties(athlete As Athlete, reader As OleDbDataReader)
        athlete.MembershipNumber = reader("athMemberNum").ToString
        athlete.FirstName = reader("athName").ToString
        athlete.Surname = reader("athSurname").ToString
        Dim DOBString As Date = CDate(reader("athDOB").ToString)
        athlete.DOB = DOBString.ToLongDateString
        athlete.Gender = reader("athGender").ToString
        Dim joinString As Date = CDate(reader("athDateJoined").ToString)
        athlete.DateJoined = joinString.ToLongDateString
        athlete.FeeAmountDue = CDec(reader("athFeeDue").ToString)
        athlete.FeeAmountPaid = CDec(reader("athFeepaid").ToString)
    End Sub


    ' Description - used for for populating the list box with the athletes number
    ' @param - the name of the list box to be populated
    ' @param - the list of items to populate the list box with
    Public Shared Sub FillAthleteNumberListBox(lstEvent As ListBox, athletes As List(Of Athlete))
        ' get rid of exisiting items
        lstEvent.Items.Clear()
        For Each athlete As Athlete In athletes
            lstEvent.Items.Add(athlete.GetAthleteNumber)
        Next
    End Sub

    ' Description - used for for populating the list box with the athletes name
    ' @param - the name of the list box to be populated
    ' @param - the list of items to populate the list box with
    Public Shared Sub FillAthleteNameListBox(lstEvent As ListBox, athletes As List(Of Athlete))
        ' get rid of exisiting items
        lstEvent.Items.Clear()
        For Each athlete As Athlete In athletes
            lstEvent.Items.Add(athlete.GetName)
        Next
    End Sub
End Class
