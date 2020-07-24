'generalClasses
'General classes to use in this project/app
'Copyright (C)2019,2020 by Christian Brunner

Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Structure StructDataBaseConnect
    Public Server As String
    Public Port As String
    Public Database As String
    Public UserID As String
    Public Password As String
End Structure

Public Class service_hashString
    'Return string as Hash md5

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
    'Return the current version for this app to check with the databaseversion

    Private Version As String = "v1r1m2"

    Public Function _appVersion() As String
        Return Version
    End Function
End Class

Public Class service_RunningModules
    'Save the current stae for each module

    Public User As Boolean
    Public Member As Boolean
    Public Expedition As Boolean
    Public CashFlow As Boolean
    Public Documents As Boolean
End Class


Public Class service_ReadAppSettings
    'Read the login information from settings file

    Private ReadOnly Key As String = "hidden"

    Private crypto As New service_crypto(Key)
    Private textFileStreamer As New StreamReader(Application.StartupPath & "\settings.cfg")
    Private DatabaseSettings As StructDataBaseConnect

    Public Function readSettings() As StructDataBaseConnect
        DatabaseSettings.Server = textFileStreamer.ReadLine
        DatabaseSettings.Port = textFileStreamer.ReadLine
        DatabaseSettings.Database = textFileStreamer.ReadLine
        DatabaseSettings.UserID = crypto.decryptData(textFileStreamer.ReadLine)
        DatabaseSettings.Password = crypto.decryptData(textFileStreamer.ReadLine)
        textFileStreamer.Close()
        Return DatabaseSettings
    End Function

End Class

Public NotInheritable Class service_crypto
    'Encrypt and decrypt 3des strings

    Private tripleDes As New TripleDESCryptoServiceProvider

    Sub New(ByVal pKey As String)
        tripleDes.Key = truncateHash(pKey, tripleDes.KeySize \ 8)
        tripleDes.IV = truncateHash("", tripleDes.BlockSize \ 8)
    End Sub

    Private Function truncateHash(ByVal pKey As String, ByVal pLength As Integer) As Byte()
        Dim Sha1 As New SHA1CryptoServiceProvider
        Dim KeyBytes() As Byte = Encoding.Unicode.GetBytes(pKey)
        Dim Hash() As Byte = Sha1.ComputeHash(KeyBytes)
        ReDim Preserve Hash(pLength - 1)
        Return Hash
    End Function

    Public Function encryptData(ByVal pPlaintext As String) As String
        Dim PlaintextBytes() As Byte = Encoding.Unicode.GetBytes(pPlaintext)
        Dim MemStream As New MemoryStream
        Dim EncStream As New CryptoStream(MemStream, tripleDes.CreateEncryptor(), CryptoStreamMode.Write)
        EncStream.Write(PlaintextBytes, 0, PlaintextBytes.Length)
        EncStream.FlushFinalBlock()
        Return Convert.ToBase64String(MemStream.ToArray)
    End Function

    Public Function decryptData(ByVal pEncryptedText As String) As String
        Dim EncryptedBytes() As Byte = Convert.FromBase64String(pEncryptedText)
        Dim MemStream As New MemoryStream
        Dim DecStream As New CryptoStream(MemStream, tripleDes.CreateDecryptor(), CryptoStreamMode.Write)
        DecStream.Write(EncryptedBytes, 0, EncryptedBytes.Length)
        DecStream.FlushFinalBlock()
        Return Encoding.Unicode.GetString(MemStream.ToArray)
    End Function

End Class