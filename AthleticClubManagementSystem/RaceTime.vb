Public Class RaceTime
    Inherits Race
    ' declare the fields for the class
    ' use private access modifer to ensure that the fields are accessed via properties
    Private m_RaceTime As String

    ' constructors for the class
    Public Sub New()
    End Sub

    Public Sub New(raceTimeId As Integer, eventname As String, membershipNumber As String, raceTime As String)
        MyBase.New(raceTimeId, eventname, membershipNumber)
        Me.RaceTime = raceTime
    End Sub

    ' properties of the class
    ' use public access modifiers
    Public Property RaceTime As String
        Get
            Return m_RaceTime
        End Get
        Set(value As String)
            m_RaceTime = value
        End Set
    End Property

    ' methods of the class
    Public Overrides Function GetDisplayText() As String
        ' overrides allows method to override base class method
        Dim text As String = "Member num: " & MembershipNumber & vbCrLf & "  Event: " & EventName & vbCrLf & "  Race time: " & RaceTime & vbCrLf
        Return text
    End Function

    Public Function GetSingleLineDisplayText() As String
        Dim text As String = "Member num: " & MembershipNumber & "  Event: " & EventName & "  Race time: " & RaceTime
        Return text
    End Function

    Public Function ShowNameAndTime() As String
        ' overrides allows method to override base class method
        Dim text As String = "Event: " & EventName & "  Race time: " & RaceTime & vbCrLf
        Return text
    End Function

    Public Function ShowNumberAndTime() As String
        ' overrides allows method to override base class method
        Dim text As String = "Member num: " & MembershipNumber & "  Race time: " & RaceTime & vbCrLf
        Return text
    End Function

End Class
