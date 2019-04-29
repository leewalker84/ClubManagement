Imports System.Data.OleDb
Public Class EventsDB
    ' class created to work with the data from the Event management system
    ' Methods are set to Public so they are available to rest of program
    ' Methods set to Shared so that they are accessible without the creation of a EventsDB object


    ' Description - used to get the race event titles from the database
    ' @return - List (of RaceEvents)
    Public Shared Function GetRaceEventTitles() As List(Of RaceEvent)
        ' variable to hold list and event
        Dim titleList As New List(Of RaceEvent)
        'Dim evt As New RaceEvent
        Dim evt As RaceEvent
        ' create the database connection
        Dim connection As OleDbConnection = AthleticClubDB.GetConnection()
        ' create the SQL query
        Dim selectQuery As String = "SELECT evtTitle FROM t_events ORDER BY evtTitle"

        ' create the command from the query and the connection
        Dim selectCommand As New OleDbCommand(selectQuery, connection)

        Try
            ' open the connection to the databse
            connection.Open()

            ' exucute a command that produces a result set - use the ExecuteReader method
            Dim reader As OleDbDataReader = selectCommand.ExecuteReader()
            ' retrieve the result set and add to list
            Do While reader.Read()
                ' create a new event at the start of each loop
                evt = New RaceEvent
                evt.Title = reader("evtTitle").ToString
                titleList.Add(evt)
            Loop
            reader.Close()
        Catch ex As OleDbException
            ' throw exception so that it can be handled by calling procedure
            Throw ex
        Finally
            connection.Close()
        End Try

        Return titleList

    End Function

    ' Description - used to get a single race event data from the database
    ' @return - a single row of data that is associated with the race title
    Public Shared Function GetRaceEventByTitle(title As String) As RaceEvent
        ' variable to hold event
        Dim evt As New RaceEvent

        ' create the database connection
        Dim connection As OleDbConnection = AthleticClubDB.GetConnection()
        ' create the SQL query
        Dim selectQuery As String = "SELECT evtTitle, evtLocation, evtDate, evtRegistration, evtDistance FROM t_events WHERE evtTitle = ? ORDER BY evtTitle"

        ' create the command from the query and the connection
        Dim selectCommand As New OleDbCommand(selectQuery, connection)

        ' create parameter for the command - (para name, value)
        Dim evtTitleParameter As New OleDbParameter("evtTitle", title)
        ' add parameter to parameter collection
        selectCommand.Parameters.Add(evtTitleParameter)

        Try
            ' open the connection to the databse
            connection.Open()

            ' exucute a command that produces a result set - use the ExecuteReader method
            ' single row is not a singluar value so ExecuteScalar is not appropriate
            ' include CommandBehavior.CloseConnection as arg to auto close connection when reader is closed
            Dim reader As OleDbDataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection)

            ' retrieve the result set and set object properties
            ' no need to loop through items as it is returning one row
            If reader.Read Then
                evt.Title = reader("evtTitle").ToString
                evt.Location = reader("evtLocation").ToString
                Dim dateString As Date = CDate(reader("evtDate").ToString)
                evt.DateEvent = dateString.ToLongDateString
                evt.Registration = CDec(reader("evtRegistration").ToString)
                evt.Distance = CDec(reader("evtDistance").ToString)
            Else
                evt = Nothing
            End If
            reader.Close()
        Catch ex As OleDbException
            ' throw exception so that it can be handled by calling procedure
            Throw ex
        Finally
            connection.Close()
        End Try

        Return evt
    End Function

    ' Description - Used to insert a new event into the database
    ' @param - an race event object containing one events data
    ' @return - an boolean value to indicate whether the operation was a success
    Public Shared Function AddRaceEvent(evt As RaceEvent) As Boolean
        ' create the database connection
        Dim connection As OleDbConnection = AthleticClubDB.GetConnection()
        ' create the SQL query
        Dim insertQuery As String = "INSERT INTO T_events (evtTitle, evtLocation, evtDate, evtRegistration, evtDistance) VALUES (?, ?, ?, ?, ?)"

        ' create the command from the query and the connection
        Dim insertCommand As New OleDbCommand(insertQuery, connection)
        ' create parameters for the command - (para name, value)

        insertCommand.Parameters.AddWithValue("evtTitle", evt.Title)
        insertCommand.Parameters.AddWithValue("evtLocation", evt.Location)
        insertCommand.Parameters.AddWithValue("evtDate", DateTime.Parse(evt.DateEvent))
        insertCommand.Parameters.AddWithValue("evtRegistration", evt.Registration)
        insertCommand.Parameters.AddWithValue("evtDistance", evt.Distance)

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

    ' Description - Used to update a events properties and store the values in a database
    ' @param - two race event object, one to hold the existing data values and one to hold the new data values
    ' @return - an boolean value to indicate whether the operation was a success
    Public Shared Function UpdateRaceEvent(newEvt As RaceEvent, oldEvt As RaceEvent) As Boolean
        ' create the database connection
        Dim connection As OleDbConnection = AthleticClubDB.GetConnection()
        ' create the SQL query
        Dim updateQuery As String = "UPDATE T_events SET evtTitle = ?, evtLocation = ?, evtDate = ?, evtRegistration = ?, evtDistance = ? WHERE evtTitle = ?"
        Dim updateCommand As New OleDbCommand(updateQuery, connection)

        ' create parameters
        updateCommand.Parameters.AddWithValue("newTitle", newEvt.Title)
        updateCommand.Parameters.AddWithValue("newLocation", newEvt.Location)
        updateCommand.Parameters.AddWithValue("newDate", DateTime.Parse(newEvt.DateEvent))
        updateCommand.Parameters.AddWithValue("newRegistration", newEvt.Registration)
        updateCommand.Parameters.AddWithValue("newDistance", newEvt.Distance)
        updateCommand.Parameters.AddWithValue("oldTitle", oldEvt.Title)

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

    ' Description - used to remove an event from a database
    ' @param - a race event object which contains the data of the event to be deleted
    ' @return - a boolean value indicating whether the operation was a succcess or failure
    Public Shared Function DeleteRaceEvent(evt As RaceEvent) As Boolean
        ' create the database connection
        Dim connection As OleDbConnection = AthleticClubDB.GetConnection()
        ' create the SQL query
        Dim deleteQuery As String = "DELETE FROM T_events WHERE evtTitle = ?"
        Dim deleteCommand As New OleDbCommand(deleteQuery, connection)
        deleteCommand.Parameters.AddWithValue("evtTitle", evt.Title)

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

    ' Description - used for for populating the list box with the race events
    ' @param - the name of the list box to be populated
    ' @param - the list of items to populate the list box with
    Public Shared Sub FillRaceEventListBox(lstEvent As ListBox, raceEvents As List(Of RaceEvent))
        ' get rid of exisiting items
        lstEvent.Items.Clear()
        For Each evt As RaceEvent In raceEvents
            lstEvent.Items.Add(evt.GetTitle)
        Next
    End Sub

End Class
