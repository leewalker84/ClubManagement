' base class created for people that the system could hold
' allows for reuse of code if the system is expanded - for example, to hold employee data
Public Class Person
    ' declare the fields for the class
    ' use private access modifer to ensure that the fields are accessed via properties
    Private m_FirstName As String
    Private m_Surname As String
    Private m_DOB As String
    Private m_Gender As String

    ' constructors for the class
    Public Sub New()
    End Sub

    Public Sub New(firstName As String, surname As String, dob As String, gender As String)
        Me.FirstName = firstName
        Me.Surname = surname
        Me.DOB = dob
        Me.Gender = gender
    End Sub

    ' properties of the class
    ' use public access modifiers
    Public Property FirstName As String
        Get
            Return m_FirstName
        End Get
        Set(value As String)
            m_FirstName = value
        End Set
    End Property

    Public Property Surname As String
        Get
            Return m_Surname
        End Get
        Set(value As String)
            m_Surname = value
        End Set
    End Property

    Public Property DOB As String
        Get
            Return m_DOB
        End Get
        Set(value As String)
            m_DOB = value
        End Set
    End Property

    Public Property Gender As String
        Get
            Return m_Gender
        End Get
        Set(value As String)
            m_Gender = value
        End Set
    End Property

    ' methods of the class
    Public Overridable Function GetDisplayText() As String
        ' overridable allows method to be overriden in derived classes
        Dim text As String = FirstName & vbCrLf & Surname & vbCrLf & DOB & vbCrLf & Gender
        Return text
    End Function

    Public Function GetName() As String
        Dim text As String = FirstName & " " & Surname
        Return text
    End Function

End Class
