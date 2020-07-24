'frmUsers
'Handels all app users
'Copyright (C)2019,2020 by Christian Brunner

Imports MySql.Data.MySqlClient

Public Class frmUsers

    Private returnConnection As New service_GetDataBaseInfos
    Private ConnectionString As String = returnConnection._returnConnectionString()
    Private SelectedRowSave As Integer = 0
    Private HScrollSave As Integer = 0

    Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load fomular and fill in text-constants like buttons and labels
        ' Read/display the app-users
        Me.KeyPreview = True
        Me.Text = "App-Benutzer verwalten"
        lblSearch.Text = "Suche"
        btnNewUser.Text = "&Neuer Benutzer (F6)"
        btnChangeUser.Text = "&Benutzer bearbeiten"
        btnRefresh.Text = "&Aktualisieren (F5)"
        btnClose.Text = "&Schließen (F3)"
        readUsers(txtBoxSearch.Text)
    End Sub

    Private Sub frmUsers_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        frmMain.RunningModules.User = False
    End Sub

    Private Sub frmUser_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'Handle key prints F3, F4, F5 and F6 manually
        Select Case e.KeyCode
            Case Keys.F3
                Me.Close()
            Case Keys.F4
                txtBoxSearch.Select()
            Case Keys.F5
                readUsers(txtBoxSearch.Text)
            Case Keys.F6
                createNewUser()
        End Select
    End Sub

    Private Sub dtaGridUsers_MouseClick(sender As Object, e As MouseEventArgs) Handles dtaGridUsers.MouseClick
        'Shows the drop down menue on the datagridview via mouseclick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            cntMouseMenue.Show(Me, e.Location)
        End If
    End Sub

    Private Sub dtaGridUsers_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dtaGridUsers.CellFormatting
        If e.RowIndex Mod 2 = 0 Then
            'Every second row
            e.CellStyle.ForeColor = Color.Black
            e.CellStyle.BackColor = Color.LightGray
        Else
            e.CellStyle.ForeColor = Color.DarkRed
            e.CellStyle.BackColor = Color.White
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
        readUsers(txtBoxSearch.Text)
    End Sub

    Private Sub cntMenueDelete_Click(sender As Object, e As EventArgs) Handles cntMenueDelete.Click
        deleteUser()
        readUsers(txtBoxSearch.Text)
    End Sub

    Private Sub txtBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles txtBoxSearch.TextChanged
        readUsers(txtBoxSearch.Text)
    End Sub

    Public Sub readUsers(ByVal pSearchString As String)
        If dtaGridUsers.Rows.Count > 0 Then
            'Save the current position in the datagridview
            Try
                HScrollSave = dtaGridUsers.HorizontalScrollingOffset
                SelectedRowSave = dtaGridUsers.CurrentRow.Index
            Catch ex As Exception
                HScrollSave = 0
                SelectedRowSave = -1
            End Try
        Else
            SelectedRowSave = -1
        End If
        dtaGridUsers.DataSource = Nothing
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Dim SQLQueryString As String =
            "SELECT user_id 'Kennung', user_name 'Name', user_last_login 'Letzte Anmeldung', 
                    CASE WHEN IFNULL(user_status, '0') = '1' THEN 'Aktiv' ELSE 'Inaktiv' END 'Benutzer Status',
                    user_sec_user 'Benutzer verwalten', user_sec_member 'Mitlgieder verwalten',
                    user_sec_expedition 'Ausrueckungen verwalten', user_sec_cash 'Kassa verwalten',
                    user_sec_documents 'Dokumente verwalten'
               FROM users
              WHERE UPPER(user_name) LIKE ?PARM_SEARCH
              ORDER BY user_id"
        Try
            Connection.Open()
            Dim SQLCommand As New MySqlCommand(SQLQueryString, Connection)
            SQLCommand.Parameters.Add("?PARM_SEARCH", MySqlDbType.VarChar).Value = "%" & pSearchString.ToUpper & "%"
            Dim Table As New DataTable
            Dim Adapter As New MySqlDataAdapter
            Adapter.SelectCommand = SQLCommand
            Adapter.Fill(Table)
            dtaGridUsers.DataSource = Table
            dtaGridUsers.Columns(0).Visible = False
            If HScrollSave > 0 Then
                'Set original scrolling position
                dtaGridUsers.HorizontalScrollingOffset = HScrollSave
            End If
            If SelectedRowSave >= 0 And SelectedRowSave < dtaGridUsers.Rows.Count Then
                'Set original selected row
                dtaGridUsers.CurrentCell = dtaGridUsers.Rows(SelectedRowSave).Cells(1)
            End If
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
        frmCreateNewUser.NewRecordMode = True
        frmCreateNewUser.Show()
    End Sub

    Private Sub changeUser()
        Dim frmChangeSingleUser As New frmManageUser
        frmChangeSingleUser.MdiParent = frmMain
        frmChangeSingleUser.Text = "Einen Benutzer bearbeiten"
        For Each SelectedRow As DataGridViewRow In dtaGridUsers.SelectedRows
            frmChangeSingleUser.txtBoxUserName.Text = dtaGridUsers.Rows(SelectedRow.Index).Cells(0).Value
            frmChangeSingleUser.txtBoxUserName.Enabled = False
            frmChangeSingleUser.NewRecordMode = False
            frmChangeSingleUser.Show()
        Next
    End Sub

    Private Sub deleteUser()
        Dim Result As DialogResult
        For Each SelectedRow As DataGridViewRow In dtaGridUsers.SelectedRows
            If dtaGridUsers.Rows(SelectedRow.Index).Cells(0).Value = "admin" Then
                MessageBox.Show("Benutzer ADMIN kann nicht gelöscht werden", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Result = MessageBox.Show("Bitte das Löschen des Benutzers bestätigen", "Benutzer wirklich löschen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If Result = System.Windows.Forms.DialogResult.Yes Then
                    deleteUserData(dtaGridUsers.Rows(SelectedRow.Index).Cells(0).Value)
                End If
            End If
        Next
    End Sub

    Private Sub deleteUserData(ByVal pUserID As String)
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
        readUsers(txtBoxSearch.Text)
    End Sub
End Class