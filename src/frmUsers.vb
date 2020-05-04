'frmUsers
'Handels all app users
'Copyright (C)2019,2020 by Christian Brunner

Imports System
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class frmUsers

    Private returnConnection As New service_GetDataBaseInfos
    Private ConnectionString As String = returnConnection._returnConnectionString()

    Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = vbTrue
        Me.Text = "App-Benutzer verwalten"
        btnNewUser.Text = "&Neuer Benutzer (F6)"
        btnChangeUser.Text = "&Benutzer bearbeiten"
        btnRefresh.Text = "&Aktualisieren (F5)"
        btnClose.Text = "&Schließen (F3)"
        readUsers()
    End Sub

    Private Sub frmUser_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Me.Close()
            Case Keys.F5
                refreshUser()
            Case Keys.F6
                createNewUser()
        End Select
    End Sub

    Private Sub dtaGridUsers_MouseClick(sender As Object, e As MouseEventArgs) Handles dtaGridUsers.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            cntMouseMenue.Show(Me, e.Location)
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnChangeUser_Click(sender As Object, e As EventArgs) Handles btnChangeUser.Click, cntMenueChange.Click, dtaGridUsers.DoubleClick
        changeUser()
    End Sub

    Private Sub btnNewUser_Click(sender As Object, e As EventArgs) Handles btnNewUser.Click, cntMenueNew.Click
        createNewUser()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click, cntMenueRefresh.Click
        refreshUser()
    End Sub

    Private Sub cntMenueDelete_Click(sender As Object, e As EventArgs) Handles cntMenueDelete.Click
        Dim Result As DialogResult
        timerReadUser.Stop()
        For Each SelectedRow As DataGridViewRow In dtaGridUsers.SelectedRows
            If dtaGridUsers.Rows(SelectedRow.Index).Cells(0).Value = "admin" Then
                MessageBox.Show("Benutzer ADMIN kann nicht gelöscht werden", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Result = MessageBox.Show("Bitte das Löschen des Benutzers bestätigen", "Benutzer wirklich löschen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If Result = System.Windows.Forms.DialogResult.Yes Then
                    deleteUser(dtaGridUsers.Rows(SelectedRow.Index).Cells(0).Value)
                End If
            End If
        Next
        refreshUser()
        timerReadUser.Start()
    End Sub

    Public Sub readUsers()
        dtaGridUsers.DataSource = Nothing
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Dim SQLQueryString As String =
            "SELECT user_id 'Kennung', user_name 'Name', user_last_login 'Letzte Anmeldung', 
                    CASE WHEN IFNULL(user_status, '0') = '1' THEN 'Aktiv' ELSE 'Inaktiv' END 'Benutzer Status',
                    user_sec_user 'Benutzer verwalten', user_sec_member 'Mitlgieder verwalten',
                    user_sec_expedition 'Ausrueckungen verwalten', user_sec_cash 'Kassa verwalten'
               FROM users 
              ORDER BY user_id"
        Try
            Connection.Open()
            Dim SQLCommand As New MySqlCommand(SQLQueryString, Connection)
            Dim Table As New DataTable
            Dim Adapter As New MySqlDataAdapter
            Adapter.SelectCommand = SQLCommand
            Adapter.Fill(Table)
            dtaGridUsers.DataSource = Table
            dtaGridUsers.Refresh()
            Connection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub createNewUser()
        Dim frmCreateNewUser As New frmManageUser
        frmCreateNewUser.MdiParent = frmMain
        frmCreateNewUser.Text = "Neuen Benutzer erstellen"
        frmCreateNewUser.txtBoxUserName.Text = ""
        frmCreateNewUser.txtBoxPassword.Text = ""
        frmCreateNewUser.txtBoxName.Text = ""
        frmCreateNewUser.NewRecordMode = vbTrue
        frmCreateNewUser.Show()
    End Sub

    Private Sub changeUser()
        Dim frmChangeSingleUser As New frmManageUser
        frmChangeSingleUser.MdiParent = frmMain
        frmChangeSingleUser.Text = "Einen Benutzer bearbeiten"
        For Each SelectedRow As DataGridViewRow In dtaGridUsers.SelectedRows
            frmChangeSingleUser.txtBoxUserName.Text = dtaGridUsers.Rows(SelectedRow.Index).Cells(0).Value
            frmChangeSingleUser.txtBoxUserName.Enabled = vbFalse
            frmChangeSingleUser.NewRecordMode = vbFalse
            frmChangeSingleUser.Show()
        Next
    End Sub

    Private Sub refreshUser()
        timerReadUser.Stop()
        readUsers()
        timerReadUser.Start()
    End Sub

    Private Sub deleteUser(ByVal pUserID As String)
        Dim DeleteUserConnection As New MySqlConnection
        DeleteUserConnection.ConnectionString = ConnectionString
        Dim DeleteUserString As String =
            "DELETE FROM users 
              WHERE user_id = ?PARM_USER_ID"
        Dim DeleteCashFlowCommand As New MySqlCommand(DeleteUserString, DeleteUserConnection)
        DeleteCashFlowCommand.Parameters.Add("?PARM_USER_ID", MySqlDbType.VarChar).Value = pUserID
        Try
            DeleteUserConnection.Open()
            DeleteCashFlowCommand.ExecuteNonQuery()
            DeleteUserConnection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub timerReadUser_Tick(sender As Object, e As EventArgs) Handles timerReadUser.Tick
        readUsers()
    End Sub
End Class