' creates a derived class from BaseEvent
' This level of subclass allows for the creation of athletic and non athletic event - i.e General meetings, concerts, athletic events
Public Class AthleticEvent
    Inherits BaseEvent
    ' declare the fields for the class
    ' use private access modifer to ensure that the fields are accessed via properties
    Private m_Registration As Decimal
    Private m_Distance As String

    ' constructor
    Public Sub New()
    End Sub
    Public Sub New(title As String, location As String, dateEvent As String, registration As Decimal)
        ' call the base class construtor
        MyBase.New(title, location, dateEvent)
        Me.Registration = registration
    End Sub

    ' properties of the class
    ' use public access modifiers
    Public Property Registration As Decimal
        Get
            Return m_Registration
        End Get
        Set(value As Decimal)
            m_Registration = value
        End Set
    End Property


    ' methods of the class
    Public Overrides Function GetDisplayText() As String
        ' overrides allows method to override base class method
        Dim text As String = Title & vbCrLf & Location & vbCrLf & DateEvent & vbCrLf & Registration
        Return text
    End Function

End Class
