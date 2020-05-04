'generalClasses
'General classes to use in this project/app
'Copyright (C)2019,2020 by Christian Brunner

Imports System
Imports System.Text
Imports System.Security.Cryptography

Public Class hashString
    'Hash incoming string as md5
    Public Function returnHashedValue(ByVal Original As String) As String
        Dim MD5 As New MD5CryptoServiceProvider
        Dim Data As Byte()
        Dim ResultByte As Byte()
        Dim ResultString As String = ""
        Dim TempString As String = ""

        Data = Encoding.ASCII.GetBytes(Original)
        ResultByte = MD5.ComputeHash(Data)
        For i As Integer = 0 To ResultByte.Length - 1
            TempString = Hex(ResultByte(i))
            If Len(TempString) = 1 Then
                TempString = "0" & TempString
            End If
            ResultString += TempString
        Next
        Return ResultString
    End Function
End Class

Public Class service_ReturnAppVersion

    Private Version As String = "v1r1m0"

    Public Function _appVersion()
        Return Version
    End Function
End Class