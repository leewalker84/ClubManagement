Public Class Race
    ' declare the fields for the class
    ' use private access modifer to ensure that the fields are accessed via properties
    Private m_RaceTimeID As Integer
    Private m_EventName As String
    Private m_MembershipNumber As String

    ' constructors for the class
    Public Sub New()
    End Sub

    Public Sub New(raceTimeID As Integer, eventname As String, membershipNumber As String)
        Me.RaceTimeID = raceTimeID
        Me.EventName = eventname
        Me.MembershipNumber = membershipNumber
    End Sub

    ' properties of the class
    ' use public access modifiers
    Public Property RaceTimeID As Integer
        Get
            Return m_RaceTimeID
        End Get
        Set(value As Integer)
            m_RaceTimeID = value
        End Set
    End Property

    Public Property EventName As String
        Get
            Return m_EventName
        End Get
        Set(value As String)
            m_EventName = value
        End Set
    End Property

    Public Property MembershipNumber As String
        Get
            Return m_MembershipNumber
        End Get
        Set(value As String)
            m_MembershipNumber = value
        End Set
    End Property

    ' methods of the class
    Public Overridable Function GetDisplayText() As String
        ' overridable allows method to be overriden in derived classes
        Dim text As String = EventName & vbCrLf & MembershipNumber
        Return text
    End Function

End Class
