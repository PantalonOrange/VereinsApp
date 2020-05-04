'frmCash
'Handles all cash flows (money, money, money)
'Copyright (C)2019,2020 by Christian Brunner

Imports System
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class frmCash

    Private returnConnection As New service_GetDataBaseInfos
    Private ConnectionString As String = returnConnection._returnConnectionString()

    Private Sub frmCash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = vbTrue
        Me.Text = "Kassa-Buchungen verwalten"
        lblSearch.Text = "Suche"
        lblYear.Text = "Jahr"
        lblTxtTotal.Text = "Total"
        lblTotal.Text = ""
        cmbBoxYear.Text = Convert.ToString(Date.Now.Year)
        btnNewFlow.Text = "&Neue Buchung (F6)"
        btnChangeFlow.Text = "&Buchung bearbeiten"
        btnDelete.Text = "&Lö"
        btnRefresh.Text = "&Akt (F5)"
        btnClose.Text = "&Schließen (F3)"
        refreshCashFlow(txtBoxSearch.Text)
    End Sub

    Private Sub frmCash_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Me.Close()
            Case Keys.F4
                txtBoxSearch.Select()
            Case Keys.F5
                refreshCashFlow(txtBoxSearch.Text)
            Case Keys.F6
                createNewCashFlow()
        End Select
    End Sub

    Private Sub dtaGridCashFlow_MouseClick(sender As Object, e As MouseEventArgs) Handles dtaGridCashFlow.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            cntMouseMenue.Show(Me, e.Location)
        End If
    End Sub

    Private Sub btnNewFlow_Click(sender As Object, e As EventArgs) Handles btnNewFlow.Click, cntMenueNew.Click
        createNewCashFlow()
    End Sub

    Private Sub btnChangeFlow_Click(sender As Object, e As EventArgs) Handles btnChangeFlow.Click, cntMenueChange.Click, dtaGridCashFlow.DoubleClick
        changeCashFlow()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click, cntMenueDelete.Click
        Dim Result As DialogResult
        timeReadCashFlow.Stop()
        For Each SelectedRow As DataGridViewRow In dtaGridCashFlow.SelectedRows
            Result = MessageBox.Show("Bitte das Löschen der Buchung bestätigen", "Buchung wirklich löschen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = System.Windows.Forms.DialogResult.Yes Then
                deleteCashFlow(Convert.ToInt64(dtaGridCashFlow.Rows(SelectedRow.Index).Cells(0).Value))
            End If
        Next
        refreshCashFlow(txtBoxSearch.Text)
        timeReadCashFlow.Start()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click, cntMenueRefresh.Click
        refreshCashFlow(txtBoxSearch.Text)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles txtBoxSearch.TextChanged
        readCashFlow(txtBoxSearch.Text)
    End Sub

    Private Sub cmbBoxYear_TextChanged(sender As Object, e As EventArgs) Handles cmbBoxYear.TextChanged
        Dim CheckYear As Integer
        If cmbBoxYear.Text = "" Or Integer.TryParse(cmbBoxYear.Text, CheckYear) Then
            readCashFlow(txtBoxSearch.Text)
        Else
            MessageBox.Show("Bitte kontrollieren Sie das Jahr", "Fehlerhafte Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbBoxYear.Select()
        End If
    End Sub

    Private Sub fillInCmbBoxYear()
        cmbBoxYear.Items.Clear()
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Connection.Open()
        Dim QueryString As String =
            "SELECT YEAR(flow_cash_date ) FROM cashflow GROUP BY YEAR(flow_cash_date ) ORDER BY YEAR(flow_cash_date )"
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

    Private Sub readCashFlow(ByVal pSearchString As String)
        dtaGridCashFlow.DataSource = Nothing
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Dim SQLQueryString As String =
            "SELECT flow_id ID, IFNULL(flow_description, '') 'Beschreibung', IFNULL(flow_target, '') 'Gegenstelle', 
                    flow_cash_date 'Buchungsdatum',
                    CASE WHEN flow_amount >= 0 THEN ABS(flow_amount) ELSE CAST(NULL AS DECIMAL) END 'Einnahmen', 
                    CASE WHEN flow_amount < 0 THEN ABS(flow_amount) ELSE CAST(NULL AS DECIMAL) END 'Ausgaben', 
                    flow_data_date 'Erstellung'
               FROM cashflow 
              WHERE YEAR(flow_cash_date) = CASE WHEN ?PARM_YEAR = '' THEN YEAR(flow_cash_date) ELSE ?PARM_YEAR END
                AND (UPPER(flow_description) LIKE ?PARM_SEARCH OR UPPER(flow_target) LIKE ?PARM_SEARCH)
              ORDER BY flow_cash_date, flow_id"
        Try
            Connection.Open()
            Dim SQLCommand As New MySqlCommand(SQLQueryString, Connection)
            SQLCommand.Parameters.AddWithValue("?PARM_YEAR", cmbBoxYear.Text)
            SQLCommand.Parameters.Add("?PARM_SEARCH", MySqlDbType.VarChar).Value = "%" & pSearchString.ToUpper & "%"
            Dim Table As New DataTable
            Dim Adapter As New MySqlDataAdapter
            Adapter.SelectCommand = SQLCommand
            Adapter.Fill(Table)
            dtaGridCashFlow.DataSource = Table
            dtaGridCashFlow.Refresh()
            Connection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        readTotal(cmbBoxYear.Text)
    End Sub

    Private Sub createNewCashFlow()
        Dim frmCreateNewCashFlow As New frmManageCashFlow
        frmCreateNewCashFlow.MdiParent = frmMain
        frmCreateNewCashFlow.Text = "Neue Buchung erstellen"
        frmCreateNewCashFlow.NewRecordMode = vbTrue
        frmCreateNewCashFlow.CashFlowID = 0
        frmCreateNewCashFlow.Show()
    End Sub

    Private Sub changeCashFlow()
        Dim frmChangeCashFlow As New frmManageCashFlow
        frmChangeCashFlow.MdiParent = frmMain
        frmChangeCashFlow.Text = "Eine Buchung bearbeiten"
        For Each SelectedRow As DataGridViewRow In dtaGridCashFlow.SelectedRows
            frmChangeCashFlow.NewRecordMode = vbFalse
            frmChangeCashFlow.CashFlowID = Convert.ToInt32(dtaGridCashFlow.Rows(SelectedRow.Index).Cells(0).Value)
            frmChangeCashFlow.Show()
        Next
    End Sub

    Private Sub deleteCashFlow(ByVal pCashFlowID As Long)
        Dim DeleteCashFlowConnection As New MySqlConnection
        DeleteCashFlowConnection.ConnectionString = ConnectionString
        Dim DeleteCashFlowString As String =
            "DELETE FROM cashflow 
              WHERE flow_id = ?PARM_FLOW_ID"
        Dim DeleteCashFlowCommand As New MySqlCommand(DeleteCashFlowString, DeleteCashFlowConnection)
        DeleteCashFlowCommand.Parameters.Add("?PARM_FLOW_ID", MySqlDbType.Int64).Value = pCashFlowID
        Try
            DeleteCashFlowConnection.Open()
            DeleteCashFlowCommand.ExecuteNonQuery()
            DeleteCashFlowConnection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub readTotal(ByVal pYear As String)
        Dim Total As Decimal = 0
        Dim Connection As New MySqlConnection
        Dim returnConnection As New service_GetDataBaseInfos
        Dim ConnectionString As String = returnConnection._returnConnectionString()
        Connection.ConnectionString = ConnectionString
        Try
            Connection.Open()
            Dim QueryString As String =
                "SELECT SUM(flow_amount) FROM cashflow WHERE YEAR(flow_cash_date) = ?PARM_YEAR"
            Dim QueryCommand As New MySqlCommand(QueryString, Connection)
            QueryCommand.Parameters.Add("?PARM_YEAR", MySqlDbType.VarChar).Value = pYear
            Dim SQLReader As MySqlDataReader
            SQLReader = QueryCommand.ExecuteReader
            While (SQLReader.Read)
                Try
                    Total = Convert.ToDecimal(SQLReader(0).ToString)
                Catch ex As Exception
                    Total = 0
                End Try
                Exit While
            End While
            Connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        lblTotal.Text = Convert.ToString(Total)
        If Total < 0 Then
            lblTotal.ForeColor = Color.Red
        Else
            lblTotal.ForeColor = Color.Black
        End If
    End Sub

    Private Sub refreshCashFlow(ByVal pSearch As String)
        timeReadCashFlow.Stop()
        fillInCmbBoxYear()
        readCashFlow(pSearch)
        timeReadCashFlow.Start()
    End Sub

    Private Sub timeReadCashFlow_Tick(sender As Object, e As EventArgs) Handles timeReadCashFlow.Tick
        readCashFlow(txtBoxSearch.Text)
    End Sub
End Class