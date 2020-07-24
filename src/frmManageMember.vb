'frmManageMember
'Create or change member
'Copyright (C)2019,2020 by Christian Brunner

Imports MySql.Data.MySqlClient

Public Class frmManageMember

    Private getConnection As New service_GetDataBaseInfos
    Private ConnectionString As String = getConnection._returnConnectionString()

    Public NewRecordMode As Boolean
    Public MemberID As Integer
    Private NewMemberID As Integer
    Private Success As Boolean = True

    Private Sub frmManageMember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load formular and fill in comboboxes and text-constants like buttons and labels
        ' If the variable NewRecordMode is ON the form will start with all empty records
        ' Is the variable NewRecordMode OFF the form loads the values from the table -> key MemberID
        ' Important to know: the date 1900-01-01 means NULL for the table-values
        Me.KeyPreview = True
        lblMemberName.Text = "Name/Vorname"
        lblStreet.Text = "Strasse"
        lblZipCity.Text = "Plz/Ort"
        lblCountry.Text = "Land"
        lblPhone.Text = "Telefon"
        lblMail.Text = "Mail"
        lblFunction.Text = "Funktionen"
        lblGrade.Text = "Rang"
        chkBoxSupporter.Text = "Unterstützer"
        lblBirthday.Text = "Geburtstag"
        lblStart.Text = "Eintritt"
        lblEnd.Text = "Austritt"
        lbltxtid.Text = "ID"
        lblid.Text = Convert.ToString(MemberID)
        lblChange.Text = "Änderung"
        btnSave.Text = "&Speichern"
        btnCancel.Text = "&Abbrechen (F12)"
        fillInCmbBoxGrade()
        txtBoxMemberName.Select()

        If NewRecordMode Then
            dateBirthday.Value = Convert.ToDateTime("1900-01-01")
            dateStart.Value = Convert.ToDateTime("1900-01-01")
            chkBoxEnd.Checked = False
            dateEnd.Enabled = chkBoxEnd.Checked
            dateEnd.Value = Convert.ToDateTime("1900-01-01")
            lblChange.Visible = False
            lblChangeDate.Visible = False
            lbltxtid.Visible = False
            lblid.Visible = False
        Else
            readMember(MemberID)
        End If
    End Sub

    Private Sub frmManageMember_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F12
                Me.Close()
        End Select
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Make some checks and write or update the inserted values
        If txtBoxMemberName.Text = "" Then
            MessageBox.Show("Kein Name eingegeben!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBoxMemberName.Select()
            Success = False
        ElseIf txtBoxFirstName.Text = "" Then
            MessageBox.Show("Kein Vornamename eingegeben!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBoxFirstName.Select()
            Success = False
        Else
            If NewRecordMode Then
                saveSingleMember()
            Else
                updateSingleMember(MemberID)
            End If

            If Success Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cmbBoxGrade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBoxGrade.SelectedIndexChanged
        'Change picture to new grade
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Connection.Open()
        Dim QueryString As String =
            "SELECT grade_pic FROM grades WHERE grade_id = ?PARM_ID"
        Dim QueryCommand As New MySqlCommand(QueryString, Connection)
        QueryCommand.Parameters.Add("?PARM_ID", MySqlDbType.VarChar).Value = cmbBoxGrade.SelectedValue
        Dim SQLReader As MySqlDataReader
        SQLReader = QueryCommand.ExecuteReader
        While (SQLReader.Read)
            getAndShowPicture(SQLReader(0).ToString)
            Exit While
        End While
        Connection.Close()
    End Sub

    Private Sub chkBoxEnd_CheckedChanged(sender As Object, e As EventArgs) Handles chkBoxEnd.CheckedChanged
        dateEnd.Enabled = chkBoxEnd.Checked
    End Sub

    Private Sub readMember(ByVal pMemberID As Integer)
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Connection.Open()
        Dim QueryString As String =
            "SELECT IFNULL(mem_name, ''), IFNULL(mem_firstname, ''), IFNULL(mem_street, ''), IFNULL(mem_zip, ''), IFNULL(mem_city, ''), 
                    IFNULL(mem_country, ''), IFNULL(mem_phone, ''), IFNULL(mem_mail, ''), IFNULL(mem_function, ''), IFNULL(mem_grade, 0), 
                    IFNULL(mem_supporter, 0), IFNULL(mem_birthday, '1900-01-01'), IFNULL(mem_start, '1900-01-01'), IFNULL(mem_end, '1900-01-01'), 
                    IFNULL(mem_change, '0001-01-01'), IFNULL(mem_user, '')
               FROM members
              WHERE mem_id = ?PARM_MEMBER_ID"
        Dim QueryCommand As New MySqlCommand(QueryString, Connection)
        QueryCommand.Parameters.Add("?PARM_MEMBER_ID", MySqlDbType.Int32).Value = pMemberID
        Dim SQLReader As MySqlDataReader
        SQLReader = QueryCommand.ExecuteReader
        While (SQLReader.Read)
            txtBoxMemberName.Text = SQLReader(0).ToString
            txtBoxFirstName.Text = SQLReader(1).ToString
            txtBoxStreet.Text = SQLReader(2).ToString
            txtBoxZip.Text = SQLReader(3).ToString
            txtBoxCity.Text = SQLReader(4).ToString
            txtBoxCountry.Text = SQLReader(5).ToString
            txtBoxPhone.Text = SQLReader(6).ToString
            txtBoxMail.Text = SQLReader(7).ToString
            txtBoxFunction.Text = SQLReader(8).ToString
            cmbBoxGrade.SelectedValue = SQLReader(9).ToString
            chkBoxSupporter.Checked = Convert.ToInt16(SQLReader(10).ToString)
            dateBirthday.Value = SQLReader(11).ToString
            dateStart.Value = SQLReader(12).ToString
            dateEnd.Value = SQLReader(13).ToString
            If SQLReader(14).ToString = New Date(1900, 1, 1) Then
                chkBoxEnd.Checked = False
                dateEnd.Enabled = False
            Else
                chkBoxEnd.Checked = True
                dateEnd.Enabled = True
            End If
            lblChangeDate.Text = SQLReader(14).ToString & "/" & SQLReader(15).ToString
            Exit While
        End While
        Connection.Close()
    End Sub

    Private Sub fillInCmbBoxGrade()
        Dim DtaTbl As New DataTable()
        DtaTbl.Columns.Add("ID", Type.GetType("System.Int16"))
        DtaTbl.Columns.Add("Description", Type.GetType("System.String"))
        cmbBoxGrade.Items.Clear()
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Connection.Open()
        Dim QueryString As String =
            "SELECT grade_id 'ID', IFNULL(grade_description, '') 'Description'
               FROM grades 
              ORDER BY grade_id"
        Dim QueryCommand As New MySqlCommand(QueryString, Connection)
        Dim Table As New DataTable
        Dim Adapter As New MySqlDataAdapter
        Adapter.SelectCommand = QueryCommand
        Adapter.Fill(Table)
        cmbBoxGrade.DataSource = Table
        cmbBoxGrade.DisplayMember = "Description"
        cmbBoxGrade.ValueMember = "ID"
        Connection.Close()
    End Sub

    Private Sub updateSingleMember(ByVal pMemberID As Integer)
        Success = True

        Dim UpdateConnection As New MySqlConnection
        UpdateConnection.ConnectionString = ConnectionString

        Dim UpdateString As String =
            "UPDATE members 
                SET mem_name = NULLIF(?PARM_MEMBER_NAME, ''),
                    mem_firstname = NULLIF(?PARM_MEMBER_FIRSTNAME, ''),
                    mem_street = NULLIF(?PARM_MEMBER_STREET, ''),
                    mem_zip = NULLIF(?PARM_MEMBER_ZIP, ''),
                    mem_city = NULLIF(?PARM_MEMBER_CITY, ''), 
                    mem_country = NULLIF(?PARM_MEMBER_COUNTRY, ''),
                    mem_phone = NULLIF(?PARM_MEMBER_PHONE, ''), 
                    mem_mail = NULLIF(?PARM_MEMBER_MAIL, ''),
                    mem_function = NULLIF(RTRIM(?PARM_MEMBER_FUNCTION), ''),
                    mem_grade = NULLIF(?PARM_MEMBER_GRADE, 0),
                    mem_supporter = NULLIF(?PARM_MEMBER_SUPPORTER, 0),
                    mem_birthday = NULLIF(?PARM_MEMBER_BIRTHDAY, '1900-01-01'), 
                    mem_start = NULLIF(?PARM_MEMBER_START, '1900-01-01'), 
                    mem_end = NULLIF(?PARM_MEMBER_END, '1900-01-01'), 
                    mem_change = CURRENT_TIMESTAMP, 
                    mem_user = ?PARM_LAST_USER
              WHERE mem_id = ?PARM_MEMBER_ID AND (IFNULL(mem_name, '') <> ?PARM_MEMBER_NAME OR 
                                                  IFNULL(mem_firstname, '') <> ?PARM_MEMBER_FIRSTNAME OR
                                                  IFNULL(mem_street, '') <> ?PARM_MEMBER_STREET OR
                                                  IFNULL(mem_zip, '') <> ?PARM_MEMBER_ZIP OR 
                                                  IFNULL(mem_city, '') <> ?PARM_MEMBER_CITY OR
                                                  IFNULL(mem_country, '') <> ?PARM_MEMBER_COUNTRY OR 
                                                  IFNULL(mem_phone, '') <> ?PARM_MEMBER_PHONE OR
                                                  IFNULL(mem_mail, '') <> ?PARM_MEMBER_MAIL OR 
                                                  IFNULL(mem_function, '') <> ?PARM_MEMBER_FUNCTION OR
                                                  IFNULL(mem_grade, 0) <> ?PARM_MEMBER_GRADE OR
                                                  IFNULL(mem_supporter, 0) <> ?PARM_MEMBER_SUPPORTER OR
                                                  IFNULL(mem_birthday, '1900-01-01') <> ?PARM_MEMBER_BIRTHDAY OR 
                                                  IFNULL(mem_start, '1900-01-01') <> ?PARM_MEMBER_START OR
                                                  IFNULL(mem_end, '1900-01-01') <> ?PARM_MEMBER_END)"
        Dim UpdateCommand As New MySqlCommand(UpdateString, UpdateConnection)
        UpdateCommand.Parameters.Add("?PARM_MEMBER_NAME", MySqlDbType.VarChar, 128).Value = txtBoxMemberName.Text
        UpdateCommand.Parameters.Add("?PARM_MEMBER_FIRSTNAME", MySqlDbType.VarChar).Value = txtBoxFirstName.Text
        UpdateCommand.Parameters.Add("?PARM_MEMBER_STREET", MySqlDbType.VarChar, 128).Value = txtBoxStreet.Text
        UpdateCommand.Parameters.Add("?PARM_MEMBER_ZIP", MySqlDbType.VarChar, 128).Value = txtBoxZip.Text
        UpdateCommand.Parameters.Add("?PARM_MEMBER_CITY", MySqlDbType.VarChar, 128).Value = txtBoxCity.Text
        UpdateCommand.Parameters.Add("?PARM_MEMBER_COUNTRY", MySqlDbType.VarChar, 128).Value = txtBoxCountry.Text
        UpdateCommand.Parameters.Add("?PARM_MEMBER_PHONE", MySqlDbType.VarChar, 128).Value = txtBoxPhone.Text
        UpdateCommand.Parameters.Add("?PARM_MEMBER_MAIL", MySqlDbType.VarChar, 128).Value = txtBoxMail.Text
        UpdateCommand.Parameters.Add("?PARM_MEMBER_FUNCTION", MySqlDbType.VarChar, 128).Value = txtBoxFunction.Text
        UpdateCommand.Parameters.Add("?PARM_MEMBER_GRADE", MySqlDbType.Int16).Value = cmbBoxGrade.SelectedValue
        UpdateCommand.Parameters.Add("?PARM_MEMBER_SUPPORTER", MySqlDbType.Int16).Value = chkBoxSupporter.Checked
        UpdateCommand.Parameters.Add("?PARM_MEMBER_BIRTHDAY", MySqlDbType.Date).Value = dateBirthday.Value.ToString("yyyy-MM-dd")
        UpdateCommand.Parameters.Add("?PARM_MEMBER_START", MySqlDbType.Date).Value = dateStart.Value.ToString("yyyy-MM-dd")
        If Not chkBoxEnd.Checked Then
            UpdateCommand.Parameters.Add("?PARM_MEMBER_END", MySqlDbType.Date).Value = "1900-01-01"
        Else
            UpdateCommand.Parameters.Add("?PARM_MEMBER_END", MySqlDbType.Date).Value = dateEnd.Value.ToString("yyyy-MM-dd")
        End If

        UpdateCommand.Parameters.Add("?PARM_MEMBER_ID", MySqlDbType.Int16).Value = pMemberID
        UpdateCommand.Parameters.Add("?PARM_LAST_USER", MySqlDbType.VarChar).Value = frmMain.User
        Try
            UpdateConnection.Open()
            UpdateCommand.ExecuteNonQuery()
            UpdateConnection.Close()
        Catch ex As MySqlException
            Success = False
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub saveSingleMember()
        Success = True
        Dim InsertConnection As New MySqlConnection
        InsertConnection.ConnectionString = ConnectionString
        getNewMemberID()

        Dim InsertString As String =
            "INSERT INTO members (mem_id, mem_name, mem_firstname, mem_street, mem_zip, mem_city, mem_country, mem_phone, mem_mail, mem_function, 
                                  mem_grade, mem_supporter, mem_birthday, mem_start, mem_end, mem_user)
             VALUES(?PARM_MEMBER_ID, NULLIF(?PARM_MEMBER_NAME, ''), NULLIF(?PARM_MEMBER_FIRSTNAME, ''),
                    NULLIF(?PARM_MEMBER_STREET, ''), NULLIF(?PARM_MEMBER_ZIP, ''), NULLIF(?PARM_MEMBER_CITY, ''), 
                    NULLIF(?PARM_MEMBER_COUNTRY, ''), NULLIF(?PARM_MEMBER_PHONE, ''), NULLIF(?PARM_MEMBER_MAIL, ''), NULLIF(?PARM_MEMBER_FUNCTION, ''),
                    NULLIF(?PARM_MEMBER_GRADE, 0), NULLIF(?PARM_MEMBER_SUPPORTER, 0), NULLIF(?PARM_MEMBER_BIRTHDAY, '1900-01-01'), 
                    NULLIF(?PARM_MEMBER_START, '1900-01-01'), NULLIF(?PARM_MEMBER_END, '1900-01-01'), ?PARM_LAST_USER)"
        Dim InsertCommand As New MySqlCommand(InsertString, InsertConnection)
        InsertCommand.Parameters.Add("?PARM_MEMBER_ID", MySqlDbType.Int32).Value = NewMemberID
        InsertCommand.Parameters.Add("?PARM_MEMBER_NAME", MySqlDbType.VarChar).Value = txtBoxMemberName.Text
        InsertCommand.Parameters.Add("?PARM_MEMBER_FIRSTNAME", MySqlDbType.VarChar).Value = txtBoxFirstName.Text
        InsertCommand.Parameters.Add("?PARM_MEMBER_STREET", MySqlDbType.VarChar).Value = txtBoxStreet.Text
        InsertCommand.Parameters.Add("?PARM_MEMBER_ZIP", MySqlDbType.VarChar).Value = txtBoxZip.Text
        InsertCommand.Parameters.Add("?PARM_MEMBER_CITY", MySqlDbType.VarChar).Value = txtBoxCity.Text
        InsertCommand.Parameters.Add("?PARM_MEMBER_COUNTRY", MySqlDbType.VarChar).Value = txtBoxCountry.Text
        InsertCommand.Parameters.Add("?PARM_MEMBER_PHONE", MySqlDbType.VarChar).Value = txtBoxPhone.Text
        InsertCommand.Parameters.Add("?PARM_MEMBER_MAIL", MySqlDbType.VarChar).Value = txtBoxMail.Text
        InsertCommand.Parameters.Add("?PARM_MEMBER_FUNCTION", MySqlDbType.VarChar).Value = txtBoxFunction.Text
        InsertCommand.Parameters.Add("?PARM_MEMBER_GRADE", MySqlDbType.Int16).Value = cmbBoxGrade.SelectedValue
        InsertCommand.Parameters.Add("?PARM_MEMBER_SUPPORTER", MySqlDbType.Int16).Value = chkBoxSupporter.Checked
        InsertCommand.Parameters.Add("?PARM_MEMBER_BIRTHDAY", MySqlDbType.Date).Value = dateBirthday.Value.ToString("yyyy-MM-dd")
        InsertCommand.Parameters.Add("?PARM_MEMBER_START", MySqlDbType.Date).Value = dateStart.Value.ToString("yyyy-MM-dd")
        If Not chkBoxEnd.Checked Then
            InsertCommand.Parameters.Add("?PARM_MEMBER_END", MySqlDbType.Date).Value = "1900-01-01"
        Else
            InsertCommand.Parameters.Add("?PARM_MEMBER_END", MySqlDbType.Date).Value = dateEnd.Value.ToString("yyyy-MM-dd")
        End If
        InsertCommand.Parameters.Add("?PARM_LAST_USER", MySqlDbType.VarChar).Value = frmMain.User
        Try
            InsertConnection.Open()
            InsertCommand.ExecuteNonQuery()
            InsertConnection.Close()
        Catch ex As MySqlException
            Success = False
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub getAndShowPicture(ByVal pGradePicture As String)
        If pGradePicture <> "" Then
            picBoxGrade.Image = Image.FromFile(Application.StartupPath & "\pic\" & pGradePicture)
        Else
            picBoxGrade.Image = Nothing
        End If
    End Sub

    Private Sub getNewMemberID()
        Static getNewMemberID As New service_GetNewMemberID
        NewMemberID = getNewMemberID._getNewMemberID()
    End Sub
End Class