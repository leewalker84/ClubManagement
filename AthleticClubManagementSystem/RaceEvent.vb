' inhertis from AthleticEvent
' This level of subclass allows for creation of classes for both track and field events
Public Class RaceEvent
    Inherits AthleticEvent
    ' declare the fields for the class
    ' use private access modifer to ensure that the fields are accessed via properties
    Private m_Distance As Decimal

    ' constructors for the class
    Public Sub New()
    End Sub

    Public Sub New(title As String, location As String, dateEvent As String, registration As Decimal, distance As Decimal)
        MyBase.New(title, location, dateEvent, registration)
        Me.Distance = distance
    End Sub

    ' properties of the class
    ' use public access modifiers
    Public Property Distance As Decimal
        Get
            Return m_Distance
        End Get
        Set(value As Decimal)
            m_Distance = value
        End Set
    End Property

    ' methods of the class
    Public Overrides Function GetDisplayText() As String
        ' overrides allows method to override base class method
        Dim text As String = "Title: " & Title & vbCrLf & "Location: " & Location & vbCrLf & "Date: " & DateEvent & vbCrLf & "Registration Fee: " & Registration & vbCrLf & "Distance: " & Distance
        Return text
    End Function
End Class
