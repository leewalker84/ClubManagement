' base class created for events that club could hold
Public Class BaseEvent
    ' declare the fields for the class
    ' use private access modifer to ensure that the fields are accessed via properties
    Private m_Title As String
    Private m_Location As String
    Private m_DateEvent As String

    ' constructors
    Public Sub New()
    End Sub
    Public Sub New(title As String)
        ' constructor to be able to use when searching for an event by name
        Me.Title = title
    End Sub

    Public Sub New(title As String, location As String, dateEvent As String)
        Me.Title = title
        Me.Location = location
        Me.DateEvent = dateEvent
    End Sub


    ' property declarations
    Public Property Title As String
        Get
            Return m_Title
        End Get
        Set(value As String)
            m_Title = value
        End Set
    End Property

    Public Property Location As String
        Get
            Return m_Location
        End Get
        Set(value As String)
            m_Location = value
        End Set
    End Property

    Public Property DateEvent As String
        Get
            Return m_DateEvent
        End Get
        Set(value As String)
            m_DateEvent = value
        End Set
    End Property

    ' methods
    Public Overridable Function GetDisplayText() As String
        ' overridable allows method to be overriden in derived classes
        Dim text As String = Title & vbCrLf & Location & vbCrLf & DateEvent
        Return text
    End Function

    Public Function GetTitle() As String
        Dim text As String = Title & vbTab
        Return text
    End Function
End Class
