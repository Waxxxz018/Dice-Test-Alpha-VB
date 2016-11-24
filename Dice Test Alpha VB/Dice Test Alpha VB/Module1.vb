Imports System.Collections.Generic
Imports System.Linq
Imports System.Security.Cryptography

Module Module1

    Private rngCsp As New RNGCryptoServiceProvider()

    Public Enum Die
        ''' <summary>
        ''' This can be considered a double-sided coin;
        ''' used to delimit a 50/50 probability.
        ''' </summary>
        D2 = 2

        ''' <summary>
        ''' A Tetrahedron
        ''' A 4 Sided Die
        ''' </summary>
        D4 = 4

        ''' <summary>
        ''' A Cube
        ''' A 6 Sided Die
        ''' </summary>
        D6 = 6

        ''' <summary>
        ''' A Octahedron
        ''' A 8 Sided Die
        ''' </summary>
        D8 = 8

        ''' <summary>
        ''' A Pentagonal Trapezohedron
        ''' A 10 Sided Die
        ''' </summary>
        D10 = 10

        ''' <summary>
        ''' A Dodecahedron
        ''' A 12 Sided Die
        ''' </summary>
        D12 = 12

        ''' <summary>
        ''' A Icosahedron
        ''' A 20 Sided Die
        ''' </summary>
        D20 = 20

        ''' <summary>
        ''' A Rhombic Triacontahedron
        ''' A 30 Sided Die
        ''' </summary>
        D30 = 30

        ''' <summary>
        ''' A Icosakaipentagonal Trapezohedron
        ''' A 50 Sided Die
        ''' </summary>
        D50 = 50

        ''' <summary>
        ''' A Pentagonal Hexecontahedron
        ''' A 60 Sided Die
        ''' </summary>
        D60 = 60

        ''' <summary>
        ''' A Zocchihedron
        ''' A 100 Sided Die
        ''' </summary>
        D100 = 100
    End Enum

    Public Function RollDice(numberofDice As Integer, numberSides As Byte) As Byte
        If numberofDice <= 0 Then
            Throw New ArgumentOutOfRangeException("numberofDice")
        End If

        If numberSides <= 0 Then
            Throw New ArgumentOutOfRangeException("numberSides")
        End If

        ' Create a byte array to hold the random value.
        Dim randomNumber As Byte() = New Byte(0) {}

        ' Fill the array with a random value.
        rngCsp.GetBytes(randomNumber)

        Return CByte((randomNumber(0) Mod numberSides) + 1)
    End Function

    Sub Main(args As String())

        Dim values = ""
        For Each value As Die In [Enum].GetValues(GetType(Die))
            values = values + ", " + value.ToString
        Next value

        values = values.Substring(1)

        Console.Write("Your dice options:" + values + vbCr & vbLf)


        Dim DieChoice = Console.ReadLine()

        Dim r = RollDice(1, Convert.ToByte(DieChoice.Trim(New [Char]() {"D"c})))
        Console.WriteLine(r)
        Console.ReadLine()
    End Sub

End Module


