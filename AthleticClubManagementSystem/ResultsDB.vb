Imports System.Data.OleDb
Public Class ResultsDB

    ' class created to work with the data from the Race result system
    ' Methods are set to Public so they are available to rest of program
    ' Methods set to Shared so that they are accessible without the creation of a ResultsDB object

    ' Description - used to retrieve an athletes race times
    ' @param - the membership number of the athlete
    ' @return - a list of all race times the athlete has recorded
    Public Shared Function GetAthleteRaceTimes(memNumber As String) As List(Of RaceTime)
        Dim raceTimeList As New List(Of RaceTime)
        Dim raceTimeObj As New RaceTime
        Dim connection As OleDbConnection = AthleticClubDB.GetConnection()
        Dim selectQuery As String = "SELECT evtTitle, rctRaceTime FROM T_raceTime WHERE athMemberNum = ?"
        Dim selectCommand As New OleDbCommand(selectQuery, connection)
        selectCommand.Parameters.AddWithValue("athMemberNum", memNumber)
        Try
            connection.Open()

            Dim reader As OleDbDataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection)
            ' retrieve the result set and add to list
            Do While reader.Read()
                raceTimeObj = New RaceTime
                raceTimeObj.EventName = reader("evtTitle").ToString
                raceTimeObj.RaceTime = reader("rctRaceTime").ToString
                raceTimeList.Add(raceTimeObj)
            Loop
            reader.Close()
        Catch ex As OleDbException
            Throw ex
        Finally
            connection.Close()
        End Try
        Return raceTimeList
    End Function

    ' Description - used to retrieve an the race times for an event
    ' @param - the title / name of the event
    ' @return - a list of all race times for the event
    Public Shared Function GetEventRaceTimes(evtTitle As String) As List(Of RaceTime)
        Dim raceTimeList As New List(Of RaceTime)
        Dim raceTimeObj As New RaceTime
        Dim connection As OleDbConnection = AthleticClubDB.GetConnection()
        Dim selectQuery As String = "SELECT athMemberNum, rctRaceTime FROM T_raceTime WHERE evtTitle = ?"
        Dim selectCommand As New OleDbCommand(selectQuery, connection)
        selectCommand.Parameters.AddWithValue("evtTitle", evtTitle)
        Try
            connection.Open()

            Dim reader As OleDbDataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection)
            ' retrieve the result set and add to list
            Do While reader.Read()
                raceTimeObj = New RaceTime
                raceTimeObj.MembershipNumber = reader("athMemberNum").ToString
                raceTimeObj.RaceTime = reader("rctRaceTime").ToString
                raceTimeList.Add(raceTimeObj)
            Loop
            reader.Close()
        Catch ex As OleDbException
            Throw ex
        Finally
            connection.Close()
        End Try
        Return raceTimeList
    End Function

    ' Description - used to see if an athlete has already recorded a time for event
    ' @param - event name and athlete name
    ' @return - a race time object with data values or with the value of nothing
    Public Shared Function EventHasAthlete(evtTitle As String, memNumber As String) As RaceTime
        Dim raceTimeObj As New RaceTime
        Dim connection As OleDbConnection = AthleticClubDB.GetConnection()
        Dim selectQuery As String = "SELECT rctID, evtTitle, athMemberNum, rctRaceTime FROM T_raceTime WHERE evtTitle = ? AND athMemberNum = ?"
        Dim selectCommand As New OleDbCommand(selectQuery, connection)
        selectCommand.Parameters.AddWithValue("evtTitle", evtTitle)
        selectCommand.Parameters.AddWithValue("athMemberNum", memNumber)
        Try
            connection.Open()

            Dim reader As OleDbDataReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow)
            If reader.Read Then
                raceTimeObj.RaceTimeID = CInt(reader("rctID"))
                raceTimeObj.EventName = reader("evtTitle").ToString
                raceTimeObj.MembershipNumber = reader("athMemberNum").ToString
                raceTimeObj.RaceTime = reader("rctRaceTime").ToString
            Else
                raceTimeObj = Nothing
            End If
            reader.Close()
        Catch ex As OleDbException
            Throw ex
        Finally
            connection.Close()
        End Try
        Return raceTimeObj
    End Function

    ' Description - used to see whether an athlete has recorded a time in any event
    ' @param - athlete membership number
    ' @return - Boolean value indicating whether they have competed
    Public Shared Function CanDeleteAthlete(athlete As Athlete) As Boolean
        Dim raceTimeObj As New RaceTime
        Dim connection As OleDbConnection = AthleticClubDB.GetConnection()
        Dim selectQuery As String = "SELECT rctID FROM T_raceTime WHERE athMemberNum = ?"
        Dim selectCommand As New OleDbCommand(selectQuery, connection)
        selectCommand.Parameters.AddWithValue("athMemberNum", athlete.MembershipNumber)
        Try
            connection.Open()

            Dim reader As OleDbDataReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow)
            If reader.Read Then
                raceTimeObj.RaceTimeID = CInt(reader("rctID"))
            Else
                raceTimeObj = Nothing
            End If
            reader.Close()

            If raceTimeObj Is Nothing Then
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

    ' Description - used to see if event has had an athlete compete in the event
    ' @param - Event name
    ' @return - Boolean value indicating whether they have had a athlete compete in the event
    Public Shared Function CanDeleteEvent(raceEvent As RaceEvent) As Boolean
        Dim raceTimeObj As New RaceTime
        Dim connection As OleDbConnection = AthleticClubDB.GetConnection()
        Dim selectQuery As String = "SELECT rctID FROM T_raceTime WHERE evtTitle = ?"
        Dim selectCommand As New OleDbCommand(selectQuery, connection)
        selectCommand.Parameters.AddWithValue("evtTitle", raceEvent.Title)
        Try
            connection.Open()
            Dim reader As OleDbDataReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow)
            If reader.Read Then
                raceTimeObj.RaceTimeID = CInt(reader("rctID"))
            Else
                raceTimeObj = Nothing
            End If
            reader.Close()

            If raceTimeObj Is Nothing Then
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

    ' Description - Used to insert a new event into the database
    ' @param - an race event object containing one events data
    ' @return - an integar value to indicate whether the operation was a success
    Public Shared Function AddRaceResult(raceTimeObj As RaceTime) As Boolean
        Dim connection As OleDbConnection = AthleticClubDB.GetConnection()
        Dim insertQuery As String = "INSERT INTO T_raceTime(evtTitle, athMemberNum, rctRaceTime) VALUES (?, ?, ?)"
        Dim insertCommand As New OleDbCommand(insertQuery, connection)
        insertCommand.Parameters.AddWithValue("evtTitle", raceTimeObj.EventName)
        insertCommand.Parameters.AddWithValue("athMemberNum", raceTimeObj.MembershipNumber)
        insertCommand.Parameters.AddWithValue("rctRaceTime", raceTimeObj.RaceTime)

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
End Class
