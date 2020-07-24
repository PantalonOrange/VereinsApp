'frmExpeditions
'Handels all expeditions
'Copyright (C)2019,2020 by Christian Brunner

Imports MySql.Data.MySqlClient

Public Class frmExpeditions

    Private returnConnection As New service_GetDataBaseInfos
    Private ConnectionString As String = returnConnection._returnConnectionString()
    Private SelectedRowSave As Integer = 0
    Private HScrollSave As Integer = 0

    Private Sub frmExpeditions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load fomular and fill in text-constants like buttons and labels
        ' Fills the combobox (year) wit values from the database and read/display the expeditions
        Me.KeyPreview = True
        Me.Text = "Ausrückungen verwalten"
        btnNewExpedition.Text = "&Neue Ausrückung (F6)"
        btnChangeExpedition.Text = "&Ausrückung bearbeiten"
        btnDelete.Text = "&Lö"
        btnRefresh.Text = "&Akt (F5)"
        btnClose.Text = "&Schließen (F3)"
        lblSearch.Text = "Suche"
        lblYear.Text = "Jahr:"
        lblRefresh.Text = "Aktualisiere, bitte warten ..."
        lblRefresh.Visible = False
        cmbBoxYear.Text = Convert.ToString(Date.Now.Year)
        refreshExpedition(txtBoxSearch.Text)
    End Sub

    Private Sub frmExpeditions_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        frmMain.RunningModules.Expedition = False
    End Sub

    Private Sub frmExpeditions_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'Handle key prints F3, F4, F5, F6 and F7 manually
        Select Case e.KeyCode
            Case Keys.F3
                Me.Close()
            Case Keys.F4
                txtBoxSearch.Select()
            Case Keys.F5
                refreshExpedition(txtBoxSearch.Text)
            Case Keys.F6
                createNewExpedition()
            Case Keys.F7
                cmbBoxYear.Select()
        End Select
    End Sub

    Private Sub dtaGridExpeditions_MouseClick(sender As Object, e As MouseEventArgs) Handles dtaGridExpeditions.MouseClick
        'Shows the drop down menue on the datagridview via mouseclick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            cntMouseMenue.Show(Me, e.Location)
        End If
    End Sub

    Private Sub dtaGridExpeditions_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dtaGridExpeditions.CellFormatting
        If e.RowIndex Mod 2 = 0 Then
            'Every second row
            e.CellStyle.ForeColor = Color.Black
            e.CellStyle.BackColor = Color.LightGray
        Else
            e.CellStyle.ForeColor = Color.DarkRed
            e.CellStyle.BackColor = Color.White
        End If

        Select Case e.ColumnIndex
            Case 4 'From
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Case 5 'To
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End Select
    End Sub

    Private Sub btnNewExpedition_Click(sender As Object, e As EventArgs) Handles btnNewExpedition.Click, cntMenueNew.Click
        createNewExpedition()
    End Sub

    Private Sub btnChangeExpedition_Click(sender As Object, e As EventArgs) Handles btnChangeExpedition.Click, cntMenueChange.Click, dtaGridExpeditions.DoubleClick
        changeExpedition()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click, cntMenueDelete.Click
        deleteExpedition()
        readExpeditions(txtBoxSearch.Text)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click, cntMenueRefresh.Click
        refreshExpedition(txtBoxSearch.Text)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cmbBoxYear_TextChanged(sender As Object, e As EventArgs) Handles cmbBoxYear.TextChanged
        'Check the new year value and read/display the selected expeditions
        Dim CheckYear As Integer
        If cmbBoxYear.Text = "" Or Integer.TryParse(cmbBoxYear.Text, CheckYear) Then
            readExpeditions(txtBoxSearch.Text)
        Else
            MessageBox.Show("Bitte kontrollieren Sie das Jahr", "Fehlerhafte Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbBoxYear.Select()
        End If
    End Sub

    Private Sub txtBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles txtBoxSearch.TextChanged
        readExpeditions(txtBoxSearch.Text)
    End Sub

    Private Sub fillInCmbBoxYear()
        'Select all saved years from table and fill the combobox with this informations
        cmbBoxYear.Items.Clear()
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Connection.Open()
        Dim QueryString As String =
            "SELECT YEAR(exp_date_from) 
               FROM expeditions 
              GROUP BY YEAR(exp_date_from) 
              ORDER BY YEAR(exp_date_from)"
        Dim QueryCommand As New MySqlCommand(QueryString, Connection)
        Dim SQLReader As MySqlDataReader
        SQLReader = QueryCommand.ExecuteReader
        While (SQLReader.Read)
            cmbBoxYear.Items.Add(SQLReader(0).ToString)
        End While
        Connection.Close()
        With cmbBoxYear
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With
    End Sub

    Private Sub readExpeditions(ByVal pSearchString As String)
        If dtaGridExpeditions.Rows.Count > 0 Then
            'Save the current position in the datagridview
            Try
                HScrollSave = dtaGridExpeditions.HorizontalScrollingOffset
                SelectedRowSave = dtaGridExpeditions.CurrentRow.Index
            Catch ex As Exception
                HScrollSave = 0
                SelectedRowSave = -1
            End Try
        Else
            SelectedRowSave = -1
        End If
        dtaGridExpeditions.DataSource = Nothing
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Dim SQLQueryString As String =
            "SELECT exp_id ID, exp_name 'Bezeichnung', IFNULL(exp_organisation, '') 'Veranstalter', IFNULL(exp_city, '') 'Veranstaltungs-Ort', 
                    exp_date_from 'Veranstaltung-Von', exp_date_to 'Veranstaltung-Bis', 
                    (SELECT count(*) FROM expedition_members WHERE exp_mem_exp_id = exp_id) 'Teilnehmer', exp_artillery 'Kanone'
               FROM expeditions 
              WHERE YEAR(exp_date_from) = CASE WHEN ?PARM_YEAR = '' THEN YEAR(exp_date_from) ELSE ?PARM_YEAR END
                AND (UPPER(exp_name) LIKE ?PARM_SEARCH OR UPPER(exp_organisation) LIKE ?PARM_SEARCH OR UPPER(exp_city) LIKE ?PARM_SEARCH)
              ORDER BY exp_date_from DESC, exp_id"
        Try
            Connection.Open()
            Dim SQLCommand As New MySqlCommand(SQLQueryString, Connection)
            SQLCommand.Parameters.AddWithValue("?PARM_YEAR", cmbBoxYear.Text)
            SQLCommand.Parameters.Add("?PARM_SEARCH", MySqlDbType.VarChar).Value = "%" & pSearchString.ToUpper & "%"
            Dim Table As New DataTable
            Dim Adapter As New MySqlDataAdapter
            Adapter.SelectCommand = SQLCommand
            Adapter.Fill(Table)
            dtaGridExpeditions.DataSource = Table
            dtaGridExpeditions.Columns(0).Visible = False
            If HScrollSave > 0 Then
                'Set original scrolling position
                dtaGridExpeditions.HorizontalScrollingOffset = HScrollSave
            End If
            If SelectedRowSave >= 0 And SelectedRowSave < dtaGridExpeditions.Rows.Count Then
                'Set original selected row
                dtaGridExpeditions.CurrentCell = dtaGridExpeditions.Rows(SelectedRowSave).Cells(1)
            End If
            dtaGridExpeditions.Refresh()
            Connection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub deleteExpedition()
        Dim Result As DialogResult
        timerReadExpeditions.Stop()
        For Each SelectedRow As DataGridViewRow In dtaGridExpeditions.SelectedRows
            Result = MessageBox.Show("Bitte das Löschen der Ausrückung bestätigen", "Ausrückung wirklich löschen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = System.Windows.Forms.DialogResult.Yes Then
                deleteExpeditionData(Convert.ToInt64(dtaGridExpeditions.Rows(SelectedRow.Index).Cells(0).Value))
            End If
        Next
    End Sub

    Private Sub deleteExpeditionData(ByVal pExpeditionID As Long)
        'First step, remove all members from current expedition
        Dim RemoveAllMemberConnection As New MySqlConnection
        RemoveAllMemberConnection.ConnectionString = ConnectionString
        Dim RemoveAllMemberString As String =
            "DELETE FROM expedition_members 
              WHERE exp_mem_exp_id = ?PARM_EXP_MEM_EXP_ID"
        Dim RemoveAllMemberCommand As New MySqlCommand(RemoveAllMemberString, RemoveAllMemberConnection)
        RemoveAllMemberCommand.Parameters.Add("?PARM_EXP_MEM_EXP_ID", MySqlDbType.Int64).Value = pExpeditionID
        Try
            RemoveAllMemberConnection.Open()
            RemoveAllMemberCommand.ExecuteNonQuery()
            RemoveAllMemberConnection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Next step, delete expedition
        Dim DeleteExpeditionConnection As New MySqlConnection
        DeleteExpeditionConnection.ConnectionString = ConnectionString
        Dim DeleteExpeditionString As String =
            "DELETE FROM expeditions 
              WHERE exp_id = ?PARM_EXP_MEM_EXP_ID"
        Dim DeleteExpeditionCommand As New MySqlCommand(DeleteExpeditionString, DeleteExpeditionConnection)
        DeleteExpeditionCommand.Parameters.Add("?PARM_EXP_MEM_EXP_ID", MySqlDbType.Int64).Value = pExpeditionID
        Try
            DeleteExpeditionConnection.Open()
            DeleteExpeditionCommand.ExecuteNonQuery()
            DeleteExpeditionConnection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub createNewExpedition()
        Dim frmCreateNewExpedition As New frmManageExpedition
        frmCreateNewExpedition.MdiParent = frmMain
        frmCreateNewExpedition.Text = "Neue Ausrückung erstellen"
        frmCreateNewExpedition.NewRecordMode = True
        frmCreateNewExpedition.ExpeditionID = 0
        frmCreateNewExpedition.Show()
    End Sub

    Private Sub changeExpedition()
        Dim frmChangeSingleExpedition As New frmManageExpedition
        frmChangeSingleExpedition.MdiParent = frmMain
        frmChangeSingleExpedition.Text = "Eine Ausrückung bearbeiten"
        For Each SelectedRow As DataGridViewRow In dtaGridExpeditions.SelectedRows
            frmChangeSingleExpedition.NewRecordMode = False
            frmChangeSingleExpedition.ExpeditionID = Convert.ToInt32(dtaGridExpeditions.Rows(SelectedRow.Index).Cells(0).Value)
            frmChangeSingleExpedition.Show()
        Next
    End Sub

    Private Sub refreshExpedition(ByVal pSearch As String)
        lblYear.Visible = False
        cmbBoxYear.Visible = False
        lblRefresh.Visible = True

        fillInCmbBoxYear()
        readExpeditions(pSearch)

        lblRefresh.Visible = False
        lblYear.Visible = True
        cmbBoxYear.Visible = True
    End Sub

    Private Sub timerReadExpeditions_Tick(sender As Object, e As EventArgs) Handles timerReadExpeditions.Tick
        readExpeditions(txtBoxSearch.Text)
    End Sub

End Class