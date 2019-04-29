' sub class to the Person class
' used to hold the data specific to an athlete
Public Class Athlete
    Inherits Person
    ' declare the fields for the class
    ' use private access modifer to ensure that the fields are accessed via properties
    Private m_MembershipNumber As String
    Private m_DateJoined As String
    Private m_FeeAmountDue As Decimal
    Private m_FeeAmountPaid As Decimal

    ' constructors for the class
    Public Sub New()
    End Sub

    Public Sub New(firstName As String, surname As String, dob As String, gender As String, membershipNumber As String,
                   dateJoined As String, feeAmountDue As Decimal, feeAmountPaid As Decimal)
        ' call base class constructor
        MyBase.New(firstName, surname, dob, gender)
        Me.MembershipNumber = membershipNumber
        Me.DateJoined = dateJoined
        Me.FeeAmountDue = feeAmountDue
        Me.FeeAmountPaid = feeAmountPaid
    End Sub

    ' properties of the class
    ' use public access modifiers
    Public Property MembershipNumber As String
        Get
            Return m_MembershipNumber
        End Get
        Set(value As String)
            m_MembershipNumber = value
        End Set
    End Property

    Public Property DateJoined As String
        Get
            Return m_DateJoined
        End Get
        Set(value As String)
            m_DateJoined = value
        End Set
    End Property

    Public Property FeeAmountDue As Decimal
        Get
            Return m_FeeAmountDue
        End Get
        Set(value As Decimal)
            m_FeeAmountDue = value
        End Set
    End Property

    Public Property FeeAmountPaid As Decimal
        Get
            Return m_FeeAmountPaid
        End Get
        Set(value As Decimal)
            m_FeeAmountPaid = value
        End Set
    End Property

    ' methods of the class

    ' function to subtract the amount paid from the membership fee
    ' @ return value - the amount due
    Public Function CalculateOutstandingFee() As Decimal
        Return Me.FeeAmountDue - Me.FeeAmountPaid
    End Function

    Public Overrides Function GetDisplayText() As String
        Dim feeOutstanding As String = CType(Me.CalculateOutstandingFee(), String)
        ' Dim text As String = MembershipNumber & vbCrLf & FirstName & vbCrLf & Surname & vbCrLf & DOB & vbCrLf & Gender & vbCrLf & DateJoined & vbCrLf & "Fee outstanding: R" & feeOutstanding
        Dim text As String = "Membership number: " & MembershipNumber & vbCrLf & "First name: " & FirstName & vbCrLf & "Last name: " & Surname & vbCrLf & "Date of birth: " & DOB & vbCrLf & "Gender: " & Gender & vbCrLf & "Date Joined: " & DateJoined & vbCrLf & "Fee outstanding: R" & feeOutstanding
        Return Text
    End Function

    Public Function GetAthleteNumber() As String
        Return MembershipNumber
    End Function

End Class
