'service_PrintMemberSheet
'This class prints the member detail sheet
'Copyright (C)2020 by Christian Brunner

Imports MySql.Data.MySqlClient

Public Class service_PrintMemberSheet

    Private returnConnection As New service_GetDataBaseInfos
    Private ConnectionString As String = returnConnection._returnConnectionString()

    Private MemberData As struct_MemberSheetData

    Public Function printItNow(ByVal pMemberID As Int16)
        If readMemberData(pMemberID) Then
            frmMembers.prtDocument.DocumentName = "Mitgliederdatenstammblatt"
            AddHandler frmMembers.prtDocument.PrintPage, AddressOf printPage
            frmMembers.prtDialog.ShowIcon = False
            frmMembers.prtDialog.ShowInTaskbar = False
            frmMembers.prtDialog.Document = frmMembers.prtDocument
            frmMembers.prtDialog.WindowState = FormWindowState.Maximized
            frmMembers.prtDialog.ShowDialog()
        End If
    End Function

    Private Function readMemberData(ByVal pMemberID As Int16) As Boolean
        Dim Success As Boolean = True
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Connection.Open()
        Dim QueryString As String =
            "SELECT IFNULL(mem_name, '----'), IFNULL(mem_firstname, '----'), IFNULL(mem_street, '----'), IFNULL(mem_zip, '----'), IFNULL(mem_city, '----'), 
                    IFNULL(mem_country, '----'), IFNULL(mem_phone, '----'), IFNULL(mem_mail, '----'), IFNULL(mem_function, ''), IFNULL(grade_description, '----'), 
                    IFNULL(grade_pic, ''), IFNULL(mem_birthday, '1900-01-01'), IFNULL(mem_start, '1900-01-01'), IFNULL(mem_end, '1900-01-01')
               FROM members
               LEFT OUTER JOIN grades ON (grade_id = mem_grade)
              WHERE mem_id = ?PARM_MEMBER_ID"
        Dim QueryCommand As New MySqlCommand(QueryString, Connection)
        QueryCommand.Parameters.Add("?PARM_MEMBER_ID", MySqlDbType.Int32).Value = pMemberID
        Dim SQLReader As MySqlDataReader
        SQLReader = QueryCommand.ExecuteReader
        While (SQLReader.Read)
            MemberData.Name = SQLReader(0).ToString
            MemberData.FirstName = SQLReader(1).ToString
            MemberData.Street = SQLReader(2).ToString
            MemberData.ZipCode = SQLReader(3).ToString
            MemberData.City = SQLReader(4).ToString
            MemberData.Country = SQLReader(5).ToString
            MemberData.Phone = SQLReader(6).ToString
            MemberData.Mail = SQLReader(7).ToString
            MemberData.MemberFunction = SQLReader(8).ToString
            MemberData.Grade = SQLReader(9).ToString
            MemberData.GradePic = SQLReader(10).ToString
            MemberData.Birthday = SQLReader(11).ToString
            MemberData.StartDate = SQLReader(12).ToString
            MemberData.EndDate = SQLReader(13).ToString
            Exit While
        End While
        Success = SQLReader.HasRows
        Connection.Close()
        Return Success
    End Function

    Private Sub printPage(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs)
        Dim BrushColor = New SolidBrush(Color.Black)
        Dim FontHead1 As Font = New Font("Arial", 28, FontStyle.Bold)
        Dim FontHead2 As Font = New Font("Arial", 18, FontStyle.Bold)
        Dim FontNormal As Font = New Font("Arial", 12)
        Dim FontNormalBold As Font = New Font("Arial", 12, FontStyle.Bold)
        Dim FontFooter As Font = New Font("Arial", 8, FontStyle.Italic)
        Dim Work As string
        e.Graphics.PageUnit = GraphicsUnit.Millimeter
        e.Graphics.DrawString("Mitgliederdatenblatt", FontHead1, BrushColor, 59, 30)
        e.Graphics.DrawString("K.u.K. Tiroler und Vorarlberger", FontHead2, BrushColor, 58, 50)
        e.Graphics.DrawString("Gebirgsartillerie Regiment Kaiser Nr. 14", FontHead2, BrushColor, 45, 57)
        e.Graphics.DrawString("1. Batterie", FontHead2, BrushColor, 90, 64)
        e.Graphics.DrawString("ZVR: 260329051", FontNormal, BrushColor, 91, 71)

        e.Graphics.DrawString("Name:", FontNormalBold, BrushColor, 20, 106)
        Work = MemberData.FirstName & " " & MemberData.Name
        e.Graphics.DrawString(Work, FontNormal, BrushColor, 45, 106)

        e.Graphics.DrawString("Straße:", FontNormalBold, BrushColor, 20, 116)
        e.Graphics.DrawString(MemberData.Street, FontNormal, BrushColor, 45, 116)

        e.Graphics.DrawString("Ort:", FontNormalBold, BrushColor, 20, 126)
        Work = MemberData.ZipCode & " / " & MemberData.City
        e.Graphics.DrawString(Work, FontNormal, BrushColor, 45, 126)

        e.Graphics.DrawString("Land:", FontNormalBold, BrushColor, 20, 136)
        e.Graphics.DrawString(MemberData.Country, FontNormal, BrushColor, 45, 136)

        e.Graphics.DrawString("Telefon:", FontNormalBold, BrushColor, 20, 156)
        e.Graphics.DrawString(MemberData.Phone, FontNormal, BrushColor, 45, 156)

        e.Graphics.DrawString("Mail:", FontNormalBold, BrushColor, 20, 166)
        e.Graphics.DrawString(MemberData.Mail, FontNormal, BrushColor, 45, 166)

        e.Graphics.DrawString("Geburtstag:", FontNormalBold, BrushColor, 20, 176)
        If MemberData.Birthday = Convert.ToDateTime("1900-01-01").ToString("yyyy-MM-dd") Then
            e.Graphics.DrawString("----", FontNormal, BrushColor, 45, 176)
        Else
            e.Graphics.DrawString(MemberData.Birthday, FontNormal, BrushColor, 45, 176)
        End If

        e.Graphics.DrawString("Eintritt:", FontNormalBold, BrushColor, 20, 186)
        If MemberData.StartDate = Convert.ToDateTime("1900-01-01").ToString("yyyy-MM-dd") Then
            e.Graphics.DrawString("----", FontNormal, BrushColor, 45, 186)
        Else
            e.Graphics.DrawString(MemberData.StartDate, FontNormal, BrushColor, 45, 186)
        End If

        e.Graphics.DrawString("Austritt:", FontNormalBold, BrushColor, 20, 196)
        If MemberData.EndDate = Convert.ToDateTime("1900-01-01").ToString("yyyy-MM-dd") Then
            e.Graphics.DrawString("----", FontNormal, BrushColor, 45, 196)
        Else
            e.Graphics.DrawString(MemberData.EndDate, FontNormal, BrushColor, 45, 196)
        End If

        e.Graphics.DrawString("Rang:", FontNormalBold, BrushColor, 20, 216)
        e.Graphics.DrawString(MemberData.Grade, FontNormal, BrushColor, 45, 216)
        If (MemberData.GradePic <> "") Then
            e.Graphics.DrawImage(Image.FromFile(Application.StartupPath & "/pic/" & MemberData.GradePic), 150, 216)
        End If

        If MemberData.MemberFunction <> "" Then
            e.Graphics.DrawString("Funktion:", FontNormalBold, BrushColor, 20, 226)
            e.Graphics.DrawString(MemberData.MemberFunction, FontNormal, BrushColor, 45, 226)
        End If

        Work = "Ausgedruckt am " & Date.Now.ToString & " von " & frmMain.User
        e.Graphics.DrawString(Work, FontFooter, BrushColor, 20, 277)
        e.HasMorePages = False
    End Sub

End Class

Public Structure struct_MemberSheetData
    Dim Name As String
    Dim FirstName As String
    Dim Street As String
    Dim ZipCode As String
    Dim City As String
    Dim Country As String
    Dim Phone As String
    Dim Mail As String
    Dim MemberFunction As String
    Dim Grade As String
    Dim GradePic As String
    Dim Birthday As Date
    Dim StartDate As Date
    Dim EndDate As Date
End Structure