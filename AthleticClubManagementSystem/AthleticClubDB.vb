' this class is used to get the connection with the MS Access database
Imports System.Data.OleDb
Public Class AthleticClubDB

    ' Description - used to get the connection to the database
    ' @return - a Ole DB connection
    Public Shared Function GetConnection() As OleDbConnection
        ' the Access database is stored in the following location - AthleticClubManagementSystem\bin\Debug
        Dim connectionString As String = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = AthleticClub.accdb"
        Return New OleDbConnection(connectionString)
    End Function
End Class
