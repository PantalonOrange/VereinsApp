'frmManamgeUser
'Create or change app user. Store password as md5 hash
'Copyright (C)2019,2020 by Christian Brunner

Imports MySql.Data.MySqlClient

Public Class frmManageUser

    Private getConnection As New service_GetDataBaseInfos
    Private ConnectionString As String = getConnection._returnConnectionString()

    Public NewRecordMode As Boolean
    Private SaveName As String
    Private HashedPassword As String
    Private SaveCheckBoxActive As Boolean
    Private SaveCheckBoxUser As Boolean
    Private SaveCheckBoxMember As Boolean
    Private SaveCheckBoxExpedition As Boolean
    Private SaveCheckBoxCash As Boolean
    Private SaveCheckBoxDocuments As Boolean

    Private Sub frmManageUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load formular and fill in text-constants like buttons and labels
        ' If the variable NewRecordMode is ON the form will start with all empty records
        ' Is the variable NewRecordMode OFF the form loads the values from the table -> key UserID
        lblUserName.Text = "Benutzerkennung"
        lblName.Text = "Name"
        lblPassword.Text = "Passwort"
        lblStatus.Text = "Status"
        lblSecurity.Text = "Berechtigung"
        chkBoxStatus.Text = "A&ktiv"
        chkBoxUser.Text = "&Benutzer"
        chkBoxMember.Text = "&Mitglieder"
        chkBoxExpedition.Text = "A&usrückungen"
        chkBoxCash.Text = "&Kassa"
        chkBoxDocuments.Text = "&Dokumente"
        chkBoxDocuments.Enabled = False 'For the next release r2
        lblLastLogin.Text = "Anmeldung"
        lblChange.Text = "Änderung"
        btnSave.Text = "&Speichern"
        btnCancel.Text = "&Abbrechen"
        txtBoxUserName.Select()

        If NewRecordMode Then
            lblChange.Visible = False
            lblChangeDate.Visible = False
            lblLastLogin.Visible = False
            lblLastLoginDate.Visible = False
        End If

        If txtBoxUserName.Text = "" Then
            chkBoxStatus.Checked = True
        Else
            SaveName = txtBoxName.Text
            readSingleUser()
        End If

        'admin user should not be changed
        If txtBoxUserName.Text = "admin" Then
            chkBoxUser.Enabled = False
            chkBoxMember.Enabled = False
            chkBoxExpedition.Enabled = False
            chkBoxCash.Enabled = False
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Make some checks and write or update the inserted values
        If txtBoxUserName.Text = "" Then
            txtBoxUserName.Select()
            MessageBox.Show("Kein Benutzername", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf txtBoxPassword.Text = "" And NewRecordMode Then
            txtBoxPassword.Select()
            MessageBox.Show("Kein Kennwort", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If txtBoxPassword.Text <> "" Then
                Dim hashPassword As New service_hashString
                HashedPassword = hashPassword.returnHashedValue(txtBoxPassword.Text)
            End If
            If Not NewRecordMode Then
                updateSingleUser()
            Else
                saveSingleUser()
            End If
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub chkBoxStatus_CheckedChanged(sender As Object, e As EventArgs) Handles chkBoxStatus.CheckedChanged
        'admin user should not be changed
        If Not chkBoxStatus.Checked And txtBoxUserName.Text = "admin" Then
            Dim Result As DialogResult
            Result = MessageBox.Show("Den Benutzer ADMIN wirklich deaktivieren?", "Frage zu ADMIN", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            chkBoxStatus.Checked = (Result = System.Windows.Forms.DialogResult.No)
        End If
    End Sub

    Private Sub readSingleUser()
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Connection.Open()
        Dim QueryString As String =
            "SELECT user_name, IFNULL(user_status, '0'), IFNULL(user_sec_user, 0), IFNULL(user_sec_member, 0), 
                    IFNULL(user_sec_expedition, 0), IFNULL(user_sec_cash, 0), IFNULL(user_sec_documents, 0), 
                    user_last_login, user_change, user_user 
               FROM users
              WHERE user_id = ?PARM_ID"
        Dim QueryCommand As New MySqlCommand(QueryString, Connection)
        QueryCommand.Parameters.Add("?PARM_ID", MySqlDbType.VarChar).Value = txtBoxUserName.Text
        Dim SQLReader As MySqlDataReader
        SQLReader = QueryCommand.ExecuteReader
        While (SQLReader.Read)
            txtBoxName.Text = SQLReader(0).ToString
            chkBoxStatus.Checked = Convert.ToInt16(SQLReader(1).ToString)
            chkBoxUser.Checked = Convert.ToInt16(SQLReader(2).ToString)
            chkBoxMember.Checked = Convert.ToInt16(SQLReader(3).ToString)
            chkBoxExpedition.Checked = Convert.ToInt16(SQLReader(4).ToString)
            chkBoxCash.Checked = Convert.ToInt16(SQLReader(5).ToString)
            chkBoxDocuments.Checked = Convert.ToInt16(SQLReader(6).ToString)
            lblLastLoginDate.Text = SQLReader(7).ToString
            lblChangeDate.Text = SQLReader(8).ToString & "/" & SQLReader(9).ToString
            SaveCheckBoxActive = chkBoxStatus.Checked
            SaveCheckBoxUser = chkBoxUser.Checked
            SaveCheckBoxMember = chkBoxMember.Checked
            SaveCheckBoxExpedition = chkBoxExpedition.Checked
            SaveCheckBoxCash = chkBoxCash.Checked
            SaveCheckBoxDocuments = chkBoxDocuments.Checked
            Exit While
        End While
        Connection.Close()
    End Sub

    Private Sub updateSingleUser()
        Dim UpdateConnection As New MySqlConnection
        UpdateConnection.ConnectionString = ConnectionString
        Dim UpdateString As String
        If txtBoxPassword.Text = "" Then
            UpdateString =
                "UPDATE users 
                    SET user_name = ?PARM_USER_NAME, 
                        user_status = NULLIF(?PARM_USER_STATUS, 0),
                        user_sec_user = NULLIF(?PARM_USER_SEC_USER, 0),
                        user_sec_member = NULLIF(?PARM_USER_SEC_MEMBER, 0),
                        user_sec_expedition = NULLIF(?PARM_USER_SEC_EXPEDITION, 0),
                        user_sec_cash = NULLIF(?PARM_USER_SEC_CASH, 0),
                        user_sec_documents = NULLIF(?PARM_USER_SEC_DOCUMENTS, 0),
                        user_change = CURRENT_TIMESTAMP, 
                        user_user = ?PARM_LAST_USER
                  WHERE user_id = ?PARM_ID AND (user_name <> ?PARM_USER_NAME OR 
                                                IFNULL(user_status, 0) <> ?PARM_USER_STATUS OR
                                                IFNULL(user_sec_user, 0) <> ?PARM_USER_SEC_USER OR 
                                                IFNULL(user_sec_member, 0) <> ?PARM_USER_SEC_MEMBER OR
                                                IFNULL(user_sec_expedition, 0) <> ?PARM_USER_SEC_EXPEDITION OR 
                                                IFNULL(user_sec_cash, 0) <> ?PARM_USER_SEC_CASH OR
                                                IFNULL(user_sec_documents, 0) <> ?PARM_USER_SEC_DOCUMENTS)"

        Else
            UpdateString =
                "UPDATE users 
                    SET user_name = ?PARM_USER_NAME, 
                        user_password = ?PARM_USER_PASSWORD, 
                        user_status = NULLIF(?PARM_USER_STATUS, 0), 
                        user_sec_user = NULLIF(?PARM_USER_SEC_USER, 0),
                        user_sec_member = NULLIF(?PARM_USER_SEC_MEMBER, 0),
                        user_sec_expedition = NULLIF(?PARM_USER_SEC_EXPEDITION, 0),
                        user_sec_cash = NULLIF(?PARM_USER_SEC_CASH, 0),
                        user_sec_documents = NULLIF(?PARM_USER_SEC_DOCUMENTS, 0),
                        user_change = CURRENT_TIMESTAMP, 
                        user_user = ?PARM_LAST_USER 
                  WHERE user_id = ?PARM_ID AND (user_name <> ?PARM_USER_NAME OR 
                                                user_password <> ?PARM_USER_PASSWORD OR 
                                                IFNULL(user_status, 0) <> ?PARM_USER_STATUS OR
                                                IFNULL(user_sec_user, 0) <> ?PARM_USER_SEC_USER OR 
                                                IFNULL(user_sec_member, 0) <> ?PARM_USER_SEC_MEMBER OR
                                                IFNULL(user_sec_expedition, 0) <> ?PARM_USER_SEC_EXPEDITION OR 
                                                IFNULL(user_sec_cash, 0) <> ?PARM_USER_SEC_CASH OR
                                                IFNULL(user_sec_documents, 0) <> ?PARM_USER_SEC_DOCUMENTS)"

        End If
        Dim UpdateCommand As New MySqlCommand(UpdateString, UpdateConnection)
        UpdateCommand.Parameters.Add("?PARM_ID", MySqlDbType.VarChar).Value = txtBoxUserName.Text
        UpdateCommand.Parameters.Add("?PARM_USER_NAME", MySqlDbType.VarChar).Value = txtBoxName.Text
        UpdateCommand.Parameters.Add("?PARM_USER_STATUS", MySqlDbType.Int16).Value = chkBoxStatus.Checked
        UpdateCommand.Parameters.Add("PARM_USER_SEC_USER", MySqlDbType.Int16).Value = chkBoxUser.Checked
        UpdateCommand.Parameters.Add("?PARM_USER_SEC_MEMBER", MySqlDbType.Int16).Value = chkBoxMember.Checked
        UpdateCommand.Parameters.Add("?PARM_USER_SEC_EXPEDITION", MySqlDbType.Int16).Value = chkBoxExpedition.Checked
        UpdateCommand.Parameters.Add("?PARM_USER_SEC_CASH", MySqlDbType.Int16).Value = chkBoxCash.Checked
        UpdateCommand.Parameters.Add("?PARM_USER_SEC_DOCUMENTS", MySqlDbType.Int16).Value = chkBoxDocuments.Checked
        UpdateCommand.Parameters.Add("?PARM_LAST_USER", MySqlDbType.VarChar).Value = frmMain.User
        If txtBoxPassword.Text <> "" Then
            UpdateCommand.Parameters.Add("?PARM_USER_PASSWORD", MySqlDbType.VarChar).Value = HashedPassword
        End If
        Try
            UpdateConnection.Open()
            UpdateCommand.ExecuteNonQuery()
            UpdateConnection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub saveSingleUser()
        Dim InsertConnection As New MySqlConnection
        InsertConnection.ConnectionString = ConnectionString
        Dim CheckUserIsActive As Boolean = chkBoxStatus.Checked
        Dim CheckSecUser As Boolean = chkBoxUser.Checked
        Dim CheckSecMember As Boolean = chkBoxMember.Checked
        Dim CheckSecExpedition As Boolean = chkBoxExpedition.Checked
        Dim CheckSecCash As Boolean = chkBoxCash.Checked
        Dim CheckSecDocuments As Boolean = chkBoxDocuments.Checked
        Dim InsertString As String =
            "INSERT INTO users (user_id, user_name, user_password, user_status, user_sec_user, user_sec_member,
                                user_sec_expedition, user_sec_cash, user_sec_documents, user_user) 
             VALUES(?PARM_USER_ID, ?PARM_USER_NAME, ?PARM_USER_PASSWORD, ?PARM_USER_STATUS, NULLIF(?PARM_USER_SEC_USER, 0),
                    NULLIF(?PARM_USER_SEC_MEMBER, 0), NULLIF(?PARM_USER_SEC_EXPEDITION, 0), NULLIF(?PARM_USER_SEC_CASH, 0), 
                    NULLIF(?PARM_USER_SEC_DOCUMENTS, 0), ?PARM_LAST_USER)"
        Dim InsertCommand As New MySqlCommand(InsertString, InsertConnection)
        InsertCommand.Parameters.Add("?PARM_USER_ID", MySqlDbType.VarChar).Value = txtBoxUserName.Text
        InsertCommand.Parameters.Add("?PARM_USER_NAME", MySqlDbType.VarChar).Value = txtBoxName.Text
        InsertCommand.Parameters.Add("?PARM_USER_PASSWORD", MySqlDbType.VarChar).Value = HashedPassword
        InsertCommand.Parameters.Add("?PARM_USER_STATUS", MySqlDbType.Int16).Value = chkBoxStatus.Checked
        InsertCommand.Parameters.Add("?PARM_USER_SEC_USER", MySqlDbType.Int16).Value = chkBoxUser.Checked
        InsertCommand.Parameters.Add("?PARM_USER_SEC_MEMBER", MySqlDbType.Int16).Value = chkBoxMember.Checked
        InsertCommand.Parameters.Add("?PARM_USER_SEC_EXPEDITION", MySqlDbType.Int16).Value = chkBoxExpedition.Checked
        InsertCommand.Parameters.Add("?PARM_USER_SEC_CASH", MySqlDbType.Int16).Value = chkBoxCash.Checked
        InsertCommand.Parameters.Add("?PARM_USER_SEC_DOCUMENTS", MySqlDbType.Int16).Value = chkBoxDocuments.Checked
        InsertCommand.Parameters.Add("?PARM_LAST_USER", MySqlDbType.VarChar).Value = frmMain.User
        Try
            InsertConnection.Open()
            InsertCommand.ExecuteNonQuery()
            InsertConnection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class