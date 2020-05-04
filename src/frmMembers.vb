'frmMembers
'Handels all members
'Copyright (C)2019,2020 by Christian Brunner

Imports System
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class frmMembers

    Private returnConnection As New service_GetDataBaseInfos
    Private ConnectionString As String = returnConnection._returnConnectionString()

    Private Sub frmMembers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = vbTrue
        Me.Text = "Mitglieder verwalten"
        lblSearch.Text = "Suche"
        lblRefresh.Text = "Aktualisiere, bitte warten ..."
        lblRefresh.Visible = vbFalse
        btnNewMember.Text = "&Neues Mitglied (F6)"
        btnChangeMember.Text = "&Mitglied bearbeiten"
        btnRefresh.Text = "&Aktualisieren (F5)"
        btnClose.Text = "&Schließen (F3)"
        readUsers(txtBoxSearch.Text)
    End Sub

    Private Sub frmMembers_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Me.Close()
            Case Keys.F4
                txtBoxSearch.Select()
            Case Keys.F5
                refreshMembers(txtBoxSearch.Text)
            Case Keys.F6
                createNewMember()
        End Select
    End Sub

    Private Sub dtaGridMembers_MouseClick(sender As Object, e As MouseEventArgs) Handles dtaGridMembers.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            cntMouseMenue.Show(Me, e.Location)
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnChangeMember_Click(sender As Object, e As EventArgs) Handles btnChangeMember.Click, cntMenueChange.Click, dtaGridMembers.DoubleClick
        changeMember()
    End Sub

    Private Sub btnNewMember_Click(sender As Object, e As EventArgs) Handles btnNewMember.Click, cntMenueNew.Click
        createNewMember()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click, cntMenueRefresh.Click
        refreshMembers(txtBoxSearch.Text)
    End Sub

    Private Sub cntMenueDelete_Click(sender As Object, e As EventArgs) Handles cntMenueDelete.Click
        Dim Result As DialogResult
        timerReadMember.Stop()
        For Each SelectedRow As DataGridViewRow In dtaGridMembers.SelectedRows
            Result = MessageBox.Show("Bitte das Löschen des Mitgliedes bestätigen", "Mitglied wirklich löschen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = System.Windows.Forms.DialogResult.Yes Then
                deleteMember(Convert.ToInt32(dtaGridMembers.Rows(SelectedRow.Index).Cells(0).Value))
            End If
        Next
        refreshMembers(txtBoxSearch.Text)
        timerReadMember.Start()
    End Sub

    Private Sub txtBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles txtBoxSearch.TextChanged
        readUsers(txtBoxSearch.Text)
    End Sub

    Private Sub readUsers(ByVal pSearchString As String)
        lblRefresh.Visible = vbTrue
        dtaGridMembers.DataSource = Nothing
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Dim SQLQueryString As String =
            "SELECT mem_id 'Mitglieder-ID', mem_name 'Familienname', mem_firstname 'Vorname', mem_function 'Funktionen', mem_grade 'Rang', mem_phone 'Telefonnummer',
                    mem_mail 'eMail-Adresse', mem_birthday 'Geburtstag', mem_start 'Eintritt', mem_end 'Austritt' 
               FROM members
              WHERE UPPER(mem_name) LIKE ?PARM_SEARCH OR UPPER(mem_firstname) LIKE ?PARM_SEARCH
              ORDER BY mem_id"
        Try
            Connection.Open()
            Dim SQLCommand As New MySqlCommand(SQLQueryString, Connection)
            SQLCommand.Parameters.Add("?PARM_SEARCH", MySqlDbType.VarChar).Value = "%" & pSearchString.ToUpper & "%"
            Dim Table As New DataTable
            Dim Adapter As New MySqlDataAdapter
            Adapter.SelectCommand = SQLCommand
            Adapter.Fill(Table)
            dtaGridMembers.DataSource = Table
            dtaGridMembers.Refresh()
            Connection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        lblRefresh.Visible = vbFalse
    End Sub

    Private Sub createNewMember()
        Dim frmCreateNewMember As New frmManageMember
        frmCreateNewMember.MdiParent = frmMain
        frmCreateNewMember.Text = "Neues Mitglied erstellen"
        frmCreateNewMember.NewRecordMode = vbTrue
        frmCreateNewMember.MemberID = 0
        frmCreateNewMember.Show()
    End Sub

    Private Sub changeMember()
        Dim frmChangeSingleMember As New frmManageMember
        frmChangeSingleMember.MdiParent = frmMain
        frmChangeSingleMember.Text = "Ein Mitglied bearbeiten"
        For Each SelectedRow As DataGridViewRow In dtaGridMembers.SelectedRows
            frmChangeSingleMember.NewRecordMode = vbFalse
            frmChangeSingleMember.MemberID = Convert.ToInt32(dtaGridMembers.Rows(SelectedRow.Index).Cells(0).Value)
            frmChangeSingleMember.Show()
        Next
    End Sub

    Private Sub refreshMembers(ByVal pSearch As String)
        timerReadMember.Stop()
        readUsers(pSearch)
        timerReadMember.Start()
    End Sub

    Private Sub deleteMember(ByVal pMemberID As Integer)
        Dim DeleteMemberConnection As New MySqlConnection
        DeleteMemberConnection.ConnectionString = ConnectionString
        Dim DeleteMemberString As String =
            "DELETE FROM members 
              WHERE mem_id = ?PARM_MEMBER_ID"
        Dim DeleteCashFlowCommand As New MySqlCommand(DeleteMemberString, DeleteMemberConnection)
        DeleteCashFlowCommand.Parameters.Add("?PARM_MEMBER_ID", MySqlDbType.Int32).Value = pMemberID
        Try
            DeleteMemberConnection.Open()
            DeleteCashFlowCommand.ExecuteNonQuery()
            DeleteMemberConnection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub timerReadMember_Tick(sender As Object, e As EventArgs) Handles timerReadMember.Tick
        readUsers(txtBoxSearch.Text)
    End Sub
End Class