'frmChangePassword
'Change app users password. Store password as md5 hash
'Copyright (C)2019,2020 by Christian Brunner

Imports MySql.Data.MySqlClient

Public Class frmChangePassword

    Private getConnection As New service_GetDataBaseInfos
    Private ConnectionString As String = getConnection._returnConnectionString()

    Private Success As Boolean

    Private Sub frmChangePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Passwort ändern für Benutzer " & frmMain.User
        lblOldPassword.Text = "Aktuelles Passwort"
        lblNewPassword.Text = "Neues Passwort"
        btnSave.Text = "&Speichern"
        btnCancel.Text = "&Abbrechen"
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtBoxOldPassword.Text = "" Then
            MessageBox.Show("Kein Passwort angegeben!", "Kein Passwort", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBoxOldPassword.Select()
        ElseIf txtBoxNewPassword.Text = "" Then
            MessageBox.Show("Kein Passwort angegeben!", "Kein Passwort", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBoxNewPassword.Select()
        ElseIf txtBoxOldPassword.Text = txtBoxNewPassword.Text Then
            MessageBox.Show("Passwörter sind identisch!", "Falsches Passwort", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBoxOldPassword.Select()
        Else
            updateUsersPassword()
            If Success Then
                MessageBox.Show("Passwort geändert", "Passwort geändert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                MessageBox.Show("Ändern des Passwortes fehlgeschlagen", "Ändern fehlgeschlagen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub updateUsersPassword()
        Dim hashPassword As New service_hashString

        Dim UpdateConnection As New MySqlConnection
        UpdateConnection.ConnectionString = ConnectionString
        Dim UpdateString As String =
                "UPDATE users 
                    SET user_password = ?PARM_PASS_NEW,
                        user_change = CURRENT_TIMESTAMP,
                        user_user = ?PARM_ID
                  WHERE user_id = ?PARM_ID AND user_password = ?PARM_PASS_OLD"
        Dim UpdateCommand As New MySqlCommand(UpdateString, UpdateConnection)
        UpdateCommand.Parameters.Add("?PARM_ID", MySqlDbType.VarChar).Value = frmMain.User
        UpdateCommand.Parameters.Add("?PARM_PASS_OLD", MySqlDbType.VarChar).Value = hashPassword.returnHashedValue(txtBoxOldPassword.Text)
        UpdateCommand.Parameters.Add("?PARM_PASS_NEW", MySqlDbType.VarChar).Value = hashPassword.returnHashedValue(txtBoxNewPassword.Text)
        Try
            UpdateConnection.Open()
            Success = (UpdateCommand.ExecuteNonQuery > 0)
            UpdateConnection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class