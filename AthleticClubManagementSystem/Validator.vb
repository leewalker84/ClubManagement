Public Class Validator

    ' Class used for validation purposes
    ' Methods are set to Public so they are available to rest of program
    ' Methods set to Shared so that they are accessible without the creation of a Validator object

    ' use shared members that belong to the class rather than to objects created from the class
    Private Shared Title As String = "Entry Error"

    ' overloaded methods to see if value is there 
    ' valid for textbox, label, string, masked textbox
    Public Shared Function IsPresent(textBox As TextBox) As Boolean
        If Trim(textBox.Text) = "" Then
            MessageBox.Show(textBox.Tag.ToString & " is a required field.", Title)
            textBox.Select()
            Return False
        Else
            Return True
        End If
    End Function

    Public Shared Function IsPresent(label As Label) As Boolean
        If Trim(label.Text) = "" Then
            MessageBox.Show(label.Tag.ToString & " is a required field.", Title)
            Return False
        Else
            Return True
        End If
    End Function

    Public Shared Function IsPresent(maskedTextBox As MaskedTextBox) As Boolean
        If maskedTextBox.Text = "  :  :" Then
            MessageBox.Show(maskedTextBox.Tag.ToString & " is a required field.", Title)
            Return False
        Else
            Return True
        End If
    End Function

    ' method to see if the user has entered the correct race time string
    ' the user enters into a masked text box with ##:##:## so to validate the user must enter a string of length 8
    ' the mask text box will only allow numeric characters
    Public Shared Function IsCorrectLength(textBox As MaskedTextBox) As Boolean
        If textBox.Text.Length() <> 8 Then
            MessageBox.Show(textBox.Tag.ToString & " is a required field. Please enter the time in the format **:**:** (hours:minutes:seconds)", Title)
            Return False
        Else
            Return True
        End If
    End Function

    ' method to test that the race time is within the correct range
    ' hours can be any number up to 99 - this is limited by the mask
    ' minutes can be upto and including 59
    ' seconds can be upto and including 59
    Public Shared Function IsCorrectTime(textBox As MaskedTextBox) As Boolean
        ' split string at the colon characters
        Dim strings() As String = textBox.Text.Split(CChar(":"))
        If strings.Length <> 3 Then
            ' does not contain hours, minutes and seconds
            MessageBox.Show(textBox.Tag.ToString & " is a required field. Please enter the time in the format **:**:** (hours:minutes:seconds)", Title)
            Return False
        Else
            If CDec(strings(1)) <= 59 AndAlso CDec(strings(2)) <= 59 Then
                ' check that both minutes and seconds are 59 or less
                Return True
            Else
                MessageBox.Show(textBox.Tag.ToString & " is a required field. Please ensure that the miuntes and seconds are not over 59", Title)
                Return False
            End If
        End If
    End Function


    ' method to see if list box control is selected
    Public Shared Function IsSelected(listBox As ListBox) As Boolean
        If listBox.SelectedIndex = -1 Then
            MessageBox.Show(listBox.Tag.ToString & " is a required field.", Title)
            Return False
        Else
            Return True
        End If
    End Function


    ' method to see if the user has entered a decimal value
    ' will be used for distance (half and full distance marathans) and payment entries
    Public Shared Function IsDecimal(textBox As TextBox) As Boolean
        Dim number As Decimal = 0
        If Decimal.TryParse(textBox.Text, number) Then
            Return True
        Else
            MessageBox.Show(textBox.Tag.ToString & " must be a numeric value.", Title)
            textBox.Select()
            Return False
        End If
    End Function


    ' method to check if the user has entered a positive number
    Public Shared Function IsPositive(textBox As TextBox) As Boolean
        If CDec(textBox.Text) >= 0 Then
            Return True
        Else
            MessageBox.Show(textBox.Tag.ToString & " must be a positive value.", Title)
            Return False
        End If
    End Function


    ' method to check that a birthday is not after todays date
    Public Shared Function IsValidDOB(dob As DateTimePicker) As Boolean
        Dim today As Date = DateTime.Today
        Dim birthday As Date = dob.Value
        If today > birthday Then
            Return True
        Else
            MessageBox.Show("Date of birth can not be later than todays date", Title)
            Return False
        End If
    End Function

    ' method to check that the join date is not before someone was born
    Public Shared Function IsValidJoinDate(dob As DateTimePicker, join As DateTimePicker) As Boolean
        Dim birthday As Date = dob.Value
        Dim joined As Date = join.Value
        If birthday < joined Then
            Return True
        Else
            MessageBox.Show("You can not register a member before they are born", Title)
            Return False
        End If
    End Function


    ' method to calculate the check digit
    ' @ Return Value - the calculated check digit
    ' return value to be used in the CreateMembershipNumber method
    ' check digit calculated seperatly from membership number to add extra portability. 
    ' Example, staff numbers may use check digit but a different format for the number than what Is used for the membership number
    Public Shared Function CalculateCheckDigit(number As String) As String
        Dim sum As Integer = 0
        Dim c As String
        Dim d As Integer
        Dim q As Integer
        ' loop through each character in the stirng
        For i As Integer = 0 To number.Length - 1
            ' store the character
            c = number(i)
            ' convert the character to its integer value and sum it with the rest of the values
            sum += CInt(c)
        Next

        d = sum Mod 10
        If (d = 0) Then
            q = 0
        Else
            q = (10 - d)
        End If

        'return the value of the check digit
        Return CType(q, String)
    End Function


    ' method to create a new membership number
    Public Shared Function CreateMembershipNumber(dateJoined As DateTimePicker, dob As DateTimePicker) As String
        ' create a variable to hold the memebership number as a string before the creation of check digit
        Dim membershipNumberBeforeCheckDigit As String
        Dim membershipNumber As String

        ' Get the last two digits of the year registered
        Dim yearOfRegStr As String = dateJoined.Value.ToString("yy")

        ' get the year of birth in the format yyyymmdd
        Dim birthdayStr As String = dob.Value.ToString("yyyyMMdd")

        ' create random number between 0 and 999
        Dim randomNumber As Integer
        Dim GeneratorRandom As New Random()
        randomNumber = GeneratorRandom.Next(0, 1000)
        Dim randomNumberStr As String = CType(randomNumber, String)

        ' create the membership number without the check digit
        membershipNumberBeforeCheckDigit = yearOfRegStr + birthdayStr + randomNumberStr
        ' create check digit by calling its function
        Dim checkDigit As String = CalculateCheckDigit(membershipNumberBeforeCheckDigit)

        ' build membership number
        membershipNumber = membershipNumberBeforeCheckDigit + checkDigit

        Return membershipNumber
    End Function

    Public Shared Function IsValidMembershipNumber(number As String) As Boolean
        Dim sum = 0
        Dim isValid As Boolean = False
        Dim c As String
        Dim d As Integer
        ' loop through each character in the stirng
        For i As Integer = 0 To number.Length - 1
            ' store the character
            c = number(i)
            ' convert the character to its integer value and sum it with the rest of the values
            sum += CInt(c)
        Next
        d = sum Mod 10

        If (d = 0) Then
            isValid = True
        End If

        Return isValid
    End Function
End Class
