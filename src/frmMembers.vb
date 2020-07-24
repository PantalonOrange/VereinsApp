'frmMembers
'Handels all members
'Copyright (C)2019,2020 by Christian Brunner

Imports MySql.Data.MySqlClient

Public Class frmMembers

    Private returnConnection As New service_GetDataBaseInfos
    Private ConnectionString As String = returnConnection._returnConnectionString()
    Private SelectedRowSave As Integer = 0
    Private HScrollSave As Integer = 0

    Private Sub frmMembers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load fomular and fill in text-constants like buttons and labels
        ' Read/display the members
        Me.KeyPreview = True
        Me.Text = "Mitglieder verwalten"
        lblSearch.Text = "Suche"
        lblRefresh.Text = "Aktualisiere, bitte warten ..."
        lblRefresh.Visible = False
        btnNewMember.Text = "&Neues Mitglied (F6)"
        btnChangeMember.Text = "&Mitglied bearbeiten"
        btnRefresh.Text = "&Aktualisieren (F5)"
        btnClose.Text = "&Schließen (F3)"
        readMembers(txtBoxSearch.Text)
    End Sub

    Private Sub frmMembers_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        frmMain.RunningModules.Member = False
    End Sub

    Private Sub frmMembers_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'Handle key prints F3, F4, F5 and F6 manually
        Select Case e.KeyCode
            Case Keys.F3
                Me.Close()
            Case Keys.F4
                txtBoxSearch.Select()
            Case Keys.F5
                readMembers(txtBoxSearch.Text)
            Case Keys.F6
                createNewMember()
        End Select
    End Sub

    Private Sub dtaGridMembers_MouseClick(sender As Object, e As MouseEventArgs) Handles dtaGridMembers.MouseClick
        'Shows the drop down menue on the datagridview via mouseclick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            cntMouseMenue.Show(Me, e.Location)
        End If
    End Sub

    Private Sub dtaGridMembers_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dtaGridMembers.CellFormatting
        If e.RowIndex Mod 2 = 0 Then
            'Every second row
            e.CellStyle.ForeColor = Color.Black
            e.CellStyle.BackColor = Color.LightGray
        Else
            e.CellStyle.ForeColor = Color.DarkRed
            e.CellStyle.BackColor = Color.White
        End If

        Select Case e.ColumnIndex
            Case 7 'Birthday
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Case 8 'Startdate
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Case 9 'Enddate
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End Select
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
        readMembers(txtBoxSearch.Text)
    End Sub

    Private Sub cntMenueDelete_Click(sender As Object, e As EventArgs) Handles cntMenueDelete.Click
        deleteMember()
        readMembers(txtBoxSearch.Text)
    End Sub

    Private Sub cntMenuePrint_Click(sender As Object, e As EventArgs) Handles cntMenuePrint.Click
        printMember()
    End Sub

    Private Sub txtBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles txtBoxSearch.TextChanged
        readMembers(txtBoxSearch.Text)
    End Sub

    Private Sub readMembers(ByVal pSearchString As String)
        lblRefresh.Visible = True
        If dtaGridMembers.Rows.Count > 0 Then
            'Save the current position in the datagridview
            Try
                HScrollSave = dtaGridMembers.HorizontalScrollingOffset
                SelectedRowSave = dtaGridMembers.CurrentRow.Index
            Catch ex As Exception
                HScrollSave = 0
                SelectedRowSave = -1
            End Try
        Else
            SelectedRowSave = -1
        End If
        dtaGridMembers.DataSource = Nothing
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Dim SQLQueryString As String =
            "SELECT mem_id 'ID', mem_name 'Familienname', mem_firstname 'Vorname', mem_function 'Funktionen', IFNULL(grade_description, '-') 'Rang',
                    mem_supporter 'Unterstuetzer', mem_phone 'Telefonnummer', mem_mail 'eMail-Adresse', mem_birthday 'Geburtstag', 
                    mem_start 'Eintritt', mem_end 'Austritt' 
               FROM members
               LEFT JOIN grades ON (grade_id = IFNULL(mem_grade, 0))
              WHERE UPPER(mem_name) LIKE ?PARM_SEARCH OR UPPER(mem_firstname) LIKE ?PARM_SEARCH
              ORDER BY mem_end, mem_supporter, mem_name, mem_firstname"
        Try
            Connection.Open()
            Dim SQLCommand As New MySqlCommand(SQLQueryString, Connection)
            SQLCommand.Parameters.Add("?PARM_SEARCH", MySqlDbType.VarChar).Value = "%" & pSearchString.ToUpper & "%"
            Dim Table As New DataTable
            Dim Adapter As New MySqlDataAdapter
            Adapter.SelectCommand = SQLCommand
            Adapter.Fill(Table)
            dtaGridMembers.DataSource = Table
            dtaGridMembers.Columns(0).Visible = False
            If HScrollSave > 0 Then
                'Set original scrolling position
                dtaGridMembers.HorizontalScrollingOffset = HScrollSave
            End If
            If SelectedRowSave >= 0 And SelectedRowSave < dtaGridMembers.Rows.Count Then
                'Set original selected row
                dtaGridMembers.CurrentCell = dtaGridMembers.Rows(SelectedRowSave).Cells(1)
            End If
            dtaGridMembers.Refresh()
            Connection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        lblRefresh.Visible = False
    End Sub

    Private Sub createNewMember()
        Dim frmCreateNewMember As New frmManageMember
        frmCreateNewMember.MdiParent = frmMain
        frmCreateNewMember.Text = "Neues Mitglied erstellen"
        frmCreateNewMember.NewRecordMode = True
        frmCreateNewMember.MemberID = 0
        frmCreateNewMember.Show()
    End Sub

    Private Sub changeMember()
        Dim frmChangeSingleMember As New frmManageMember
        frmChangeSingleMember.MdiParent = frmMain
        frmChangeSingleMember.Text = "Ein Mitglied bearbeiten"
        For Each SelectedRow As DataGridViewRow In dtaGridMembers.SelectedRows
            frmChangeSingleMember.NewRecordMode = False
            frmChangeSingleMember.MemberID = Convert.ToInt32(dtaGridMembers.Rows(SelectedRow.Index).Cells(0).Value)
            frmChangeSingleMember.Show()
        Next
    End Sub

    Private Sub deleteMember()
        Dim Result As DialogResult
        For Each SelectedRow As DataGridViewRow In dtaGridMembers.SelectedRows
            Result = MessageBox.Show("Bitte das Löschen des Mitgliedes bestätigen", "Mitglied wirklich löschen?",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = System.Windows.Forms.DialogResult.Yes Then
                deleteMemberData(Convert.ToInt32(dtaGridMembers.Rows(SelectedRow.Index).Cells(0).Value))
            End If
        Next
    End Sub

    Private Sub deleteMemberData(ByVal pMemberID As Integer)
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

    Private Sub printMember()
        Dim Result As DialogResult
        Static printMemberSheet As New service_PrintMemberSheet
        For Each SelectedRow As DataGridViewRow In dtaGridMembers.SelectedRows
            Result = MessageBox.Show("Möchten Sie das Stammdatenblatt ausdrucken?", "Mitgliederdaten drucken?",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = System.Windows.Forms.DialogResult.Yes Then
                printMemberSheet.printItNow(Convert.ToInt32(dtaGridMembers.Rows(SelectedRow.Index).Cells(0).Value))
            End If
        Next
    End Sub

    Private Sub timerReadMember_Tick(sender As Object, e As EventArgs) Handles timerReadMember.Tick
        readMembers(txtBoxSearch.Text)
    End Sub
End Class