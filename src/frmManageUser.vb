'frmManamgeUser
'Create or change app user. Store password as md5 hash
'Copyright (C)2019,2020 by Christian Brunner

Imports System
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class frmManageUser

    Private getConnection As New service_GetDataBaseInfos
    Private ConnectionString As String = getConnection._returnConnectionString()

    Public NewRecordMode As String
    Private SaveName As String
    Private HashedPassword As String
    Private SaveCheckBoxActive As Boolean
    Private SaveCheckBoxUser As Boolean
    Private SaveCheckBoxMember As Boolean
    Private SaveCheckBoxExpedition As Boolean
    Private SaveCheckBoxCash As Boolean

    Private Sub frmManageUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUserName.Text = "Benutzerkennung"
        lblName.Text = "Name"
        lblPassword.Text = "Passwort"
        lblStatus.Text = "Status"
        lblSecurity.Text = "Berechtigung"
        chkBoxStatus.Text = "Aktiv"
        chkBoxUser.Text = "Benutzer"
        chkBoxMember.Text = "Mitglieder"
        chkBoxExpedition.Text = "Ausrückungen"
        chkBoxCash.Text = "Kassa"
        lblLastLogin.Text = "Anmeldung"
        lblChange.Text = "Änderung"
        btnSave.Text = "&Speichern"
        btnCancel.Text = "&Abbrechen"
        txtBoxUserName.Select()

        If NewRecordMode Then
            lblChange.Visible = vbFalse
            lblChangeDate.Visible = vbFalse
            lblLastLogin.Visible = vbFalse
            lblLastLoginDate.Visible = vbFalse
        End If

        If txtBoxUserName.Text = "" Then
            chkBoxStatus.Checked = vbTrue
        Else
            SaveName = txtBoxName.Text
            readSingleUser()
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtBoxUserName.Text = "" Then
            txtBoxUserName.Select()
            MessageBox.Show("Kein Benutzername", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf txtBoxPassword.Text = "" And NewRecordMode Then
            txtBoxPassword.Select()
            MessageBox.Show("Kein Kennwort", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If txtBoxPassword.Text <> "" Then
                Dim hashPassword As New hashString
                HashedPassword = hashPassword.returnHashedValue(txtBoxPassword.Text)
            End If
            If Not NewRecordMode Then
                If ((txtBoxName.Text <> SaveName) Or (txtBoxPassword.Text <> "") Or (chkBoxStatus.Checked <> SaveCheckBoxActive) Or
                    (chkBoxUser.Checked <> SaveCheckBoxUser) Or (chkBoxMember.Checked <> SaveCheckBoxMember) Or
                    (chkBoxExpedition.Checked <> SaveCheckBoxExpedition) Or (chkBoxCash.Checked <> SaveCheckBoxCash)) Then
                    updateSingleUser()
                End If
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
                    IFNULL(user_sec_expedition, 0), IFNULL(user_sec_cash, 0), user_last_login, user_change, user_user 
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
            lblLastLoginDate.Text = SQLReader(6).ToString
            lblChangeDate.Text = SQLReader(7).ToString & "/" & SQLReader(8).ToString
            SaveCheckBoxActive = chkBoxStatus.Checked
            SaveCheckBoxUser = chkBoxUser.Checked
            SaveCheckBoxMember = chkBoxMember.Checked
            SaveCheckBoxExpedition = chkBoxExpedition.Checked
            SaveCheckBoxCash = chkBoxCash.Checked
            Exit While
        End While
        Connection.Close()
    End Sub

    Private Sub updateSingleUser()
        Dim UpdateConnection As New MySqlConnection
        UpdateConnection.ConnectionString = ConnectionString
        Dim CheckUserIsActive As Boolean = chkBoxStatus.Checked
        Dim CheckSecUser As Boolean = chkBoxUser.Checked
        Dim CheckSecMember As Boolean = chkBoxMember.Checked
        Dim CheckSecExpedition As Boolean = chkBoxExpedition.Checked
        Dim CheckSecCash As Boolean = chkBoxCash.Checked
        Dim UpdateString As String
        If txtBoxPassword.Text = "" Then
            UpdateString =
                "UPDATE users 
                    SET user_name = ?PARM_USER_NAME, 
                        user_status = ?PARM_USER_STATUS,
                        user_sec_user = NULLIF(?PARM_USER_SEC_USER, 0),
                        user_sec_member = NULLIF(?PARM_USER_SEC_MEMBER, 0),
                        user_sec_expedition = NULLIF(?PARM_USER_SEC_EXPEDITION, 0),
                        user_sec_cash = NULLIF(?PARM_USER_SEC_CASH, 0),
                        user_change = CURRENT_TIMESTAMP, 
                        user_user = ?PARM_LAST_USER
                  WHERE user_id = ?PARM_ID"
        Else
            UpdateString =
                "UPDATE users 
                    SET user_name = ?PARM_USER_NAME, 
                        user_password = ?PARM_USER_PASSWORD, 
                        user_status = ?PARM_USER_STATUS, 
                        user_sec_user = NULLIF(?PARM_USER_SEC_USER, 0),
                        user_sec_member = NULLIF(?PARM_USER_SEC_MEMBER, 0),
                        user_sec_expedition = NULLIF(?PARM_USER_SEC_EXPEDITION, 0),
                        user_sec_cash = NULLIF(?PARM_USER_SEC_CASH, 0),
                        user_change = CURRENT_TIMESTAMP, 
                        user_user = ?PARM_LAST_USER 
                  WHERE user_id = ?PARM_ID"
        End If
        Dim UpdateCommand As New MySqlCommand(UpdateString, UpdateConnection)
        UpdateCommand.Parameters.Add("?PARM_ID", MySqlDbType.VarChar).Value = txtBoxUserName.Text
        UpdateCommand.Parameters.Add("?PARM_USER_NAME", MySqlDbType.VarChar).Value = txtBoxName.Text
        UpdateCommand.Parameters.Add("?PARM_USER_STATUS", MySqlDbType.Int16).Value = Convert.ToInt16(CheckUserIsActive)
        UpdateCommand.Parameters.Add("PARM_USER_SEC_USER", MySqlDbType.Int16).Value = Convert.ToInt16(CheckSecUser)
        UpdateCommand.Parameters.Add("?PARM_USER_SEC_MEMBER", MySqlDbType.Int16).Value = Convert.ToInt16(CheckSecMember)
        UpdateCommand.Parameters.Add("?PARM_USER_SEC_EXPEDITION", MySqlDbType.Int16).Value = Convert.ToInt16(CheckSecExpedition)
        UpdateCommand.Parameters.Add("?PARM_USER_SEC_CASH", MySqlDbType.Int16).Value = Convert.ToInt16(CheckSecCash)
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
        Dim InsertString As String =
            "INSERT INTO users (user_id, user_name, user_password, user_status, user_sec_user, user_sec_member,
                                user_sec_expedition, user_sec_cash, user_user) 
             VALUES(?PARM_USER_ID, ?PARM_USER_NAME, ?PARM_USER_PASSWORD, ?PARM_USER_STATUS, NULLIF(?PARM_USER_SEC_USER, 0),
                    NULLIF(?PARM_USER_SEC_MEMBER, 0), NULLIF(?PARM_USER_SEC_EXPEDITION, 0), NULLIF(?PARM_USER_SEC_CASH, 0), ?PARM_LAST_USER)"
        Dim InsertCommand As New MySqlCommand(InsertString, InsertConnection)
        InsertCommand.Parameters.Add("?PARM_USER_ID", MySqlDbType.VarChar).Value = txtBoxUserName.Text
        InsertCommand.Parameters.Add("?PARM_USER_NAME", MySqlDbType.VarChar).Value = txtBoxName.Text
        InsertCommand.Parameters.Add("?PARM_USER_PASSWORD", MySqlDbType.VarChar).Value = HashedPassword
        InsertCommand.Parameters.Add("?PARM_USER_STATUS", MySqlDbType.Int16).Value = Convert.ToInt16(CheckUserIsActive)
        InsertCommand.Parameters.Add("?PARM_USER_SEC_USER", MySqlDbType.Int16).Value = Convert.ToInt16(CheckSecUser)
        InsertCommand.Parameters.Add("?PARM_USER_SEC_MEMBER", MySqlDbType.Int16).Value = Convert.ToInt16(CheckSecMember)
        InsertCommand.Parameters.Add("?PARM_USER_SEC_EXPEDITION", MySqlDbType.Int16).Value = Convert.ToInt16(CheckSecExpedition)
        InsertCommand.Parameters.Add("?PARM_USER_SEC_CASH", MySqlDbType.Int16).Value = Convert.ToInt16(CheckSecCash)
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