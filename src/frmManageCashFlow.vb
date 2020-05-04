'frmManageCashFlow
'Create or change cash flows for the current account
'Copyright (C)2019,2020 by Christian Brunner

Imports System
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class frmManageCashFlow

    Private getConnection As New service_GetDataBaseInfos
    Private ConnectionString As String = getConnection._returnConnectionString()

    Public NewRecordMode As Boolean
    Public CashFlowID As Long
    Private Success As Boolean = vbTrue
    Private NewCashFlowID As Long

    Private Sub frmManageCashFlow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = vbTrue
        lblCashFlowDescription.Text = "Beschreibung"
        lblCashFlowTarget.Text = "Gegenstelle"
        lblCashFlowAmount.Text = "Wert"
        lblCashFlowDate.Text = "Buchungsdatum"
        lblCashFlowDataDate.Text = "Datensatzdatum"
        grpBoxAdditions.Text = "Zusatzinformationen"
        lbltxtid.Text = "ID"
        lblCashFlowID.Text = Convert.ToString(CashFlowID)
        lblChange.Text = "Änderung"
        btnSave.Text = "&Speichern"
        btnCancel.Text = "&Abbrechen (F12)"
        fillInCmbBoxCashFlowDescription()
        fillInCmbBoxCashFlowTarget()
        If frmMain.User.ToLower = "admin" Then
            dateCashFlowDataDate.Enabled = vbTrue
        End If
        If NewRecordMode Then
            txtBoxCashFlowAmount.Text = "0.00"
            dateCashFlowDate.Value = Date.Now
            dateCashFlowDataDate.Value = Date.Now
            lbltxtid.Visible = vbFalse
            lblChange.Visible = vbFalse
            lblChangeDate.Visible = vbFalse
            lblCashFlowID.Visible = vbFalse
        Else
            readCashFlow(CashFlowID)
        End If
    End Sub

    Private Sub frmManageCashFlow_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F12
                Me.Close()
        End Select
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim TryAmount As Decimal
        If cmbBoxCashFlowDescription.Text = "" Then
            MessageBox.Show("Keine Beschreibung eingegeben!", "Fehlende Beschreibung", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbBoxCashFlowDescription.Select()
            Success = vbFalse
        ElseIf cmbBoxCashFlowTarget.Text = "" Then
            MessageBox.Show("Keine Gegenstelle eingegeben!", "Fehlende Gegenstelle", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbBoxCashFlowTarget.Select()
            Success = vbFalse
        ElseIf txtBoxCashFlowAmount.Text = "" Then
            MessageBox.Show("Kein Wert eingegeben!", "Fehlender Wert", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBoxCashFlowAmount.Select()
            Success = vbFalse
        ElseIf Not Decimal.TryParse(txtBoxCashFlowAmount.Text, TryAmount) Then
            MessageBox.Show("Es wurde ein ungültiger Wert eingegeben!", "Ungültiger Wert", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBoxCashFlowAmount.Select()
            Success = vbFalse
        Else
            If NewRecordMode Then
                saveCashFlow()
            Else
                updateCashFlow(CashFlowID)
            End If

            If Success Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub fillInCmbBoxCashFlowDescription()
        cmbBoxCashFlowDescription.Items.Clear()
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Connection.Open()
        Dim QueryString As String =
            "SELECT flow_description FROM cashflow GROUP BY flow_description ORDER BY flow_description"
        Dim QueryCommand As New MySqlCommand(QueryString, Connection)
        Dim SQLReader As MySqlDataReader
        SQLReader = QueryCommand.ExecuteReader
        While (SQLReader.Read)
            cmbBoxCashFlowDescription.Items.Add(SQLReader(0).ToString)
        End While
        Connection.Close()
        With cmbBoxCashFlowDescription
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With
    End Sub

    Private Sub fillInCmbBoxCashFlowTarget()
        cmbBoxCashFlowTarget.Items.Clear()
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Connection.Open()
        Dim QueryString As String =
            "SELECT flow_target FROM cashflow GROUP BY flow_target ORDER BY flow_target"
        Dim QueryCommand As New MySqlCommand(QueryString, Connection)
        Dim SQLReader As MySqlDataReader
        SQLReader = QueryCommand.ExecuteReader
        While (SQLReader.Read)
            cmbBoxCashFlowTarget.Items.Add(SQLReader(0).ToString)
        End While
        Connection.Close()
        With cmbBoxCashFlowTarget
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With
    End Sub

    Private Sub readCashFlow(ByVal pCashFlowID As Long)
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Connection.Open()
        Dim QueryString As String =
            "SELECT flow_description, flow_target, flow_amount, flow_cash_date, flow_data_date, flow_additional_information, flow_change, flow_user
               FROM cashflow WHERE flow_id = ?PARM_CASH_FLOW_ID"
        Dim QueryCommand As New MySqlCommand(QueryString, Connection)
        QueryCommand.Parameters.Add("?PARM_CASH_FLOW_ID", MySqlDbType.Int32).Value = pCashFlowID
        Dim SQLReader As MySqlDataReader
        SQLReader = QueryCommand.ExecuteReader
        While (SQLReader.Read)
            cmbBoxCashFlowDescription.Text = SQLReader(0).ToString
            cmbBoxCashFlowTarget.Text = SQLReader(1).ToString
            txtBoxCashFlowAmount.Text = SQLReader(2).ToString
            dateCashFlowDate.Value = SQLReader(3).ToString
            dateCashFlowDataDate.Value = SQLReader(4).ToString()
            txtBoxAdditionalInformation.Text = SQLReader(5).ToString.Replace("^", vbCrLf)
            lblChangeDate.Text = SQLReader(6).ToString & "/" & SQLReader(7).ToString
            Exit While
        End While
        Connection.Close()
    End Sub

    Private Sub saveCashFlow()
        Success = vbTrue

        getNewCashFlowID()

        If NewCashFlowID > 0 Then
            Dim InsertConnection As New MySqlConnection
            InsertConnection.ConnectionString = ConnectionString
            Dim InsertString As String =
                "INSERT INTO cashflow (flow_id, flow_description, flow_target, flow_amount, flow_cash_date, flow_data_date,
                                       flow_additional_information, flow_user)
                 VALUES(?PARM_FLOW_ID, ?PARM_FLOW_DESCRIPTION, ?PARM_FLOW_TARGET, ?PARM_FLOW_AMOUNT, ?PARM_FLOW_CASH_DATE, ?PARM_FLOW_DATA_DATE,
                        NULLIF(RTRIM(?PARM_FLOW_ADDITIONALS), ''), ?PARM_LAST_USER)"
            Dim InsertCommand As New MySqlCommand(InsertString, InsertConnection)
            InsertCommand.Parameters.Add("?PARM_FLOW_ID", MySqlDbType.Int64).Value = NewCashFlowID
            InsertCommand.Parameters.Add("?PARM_FLOW_DESCRIPTION", MySqlDbType.VarChar).Value = cmbBoxCashFlowDescription.Text
            InsertCommand.Parameters.Add("?PARM_FLOW_TARGET", MySqlDbType.VarChar).Value = cmbBoxCashFlowTarget.Text
            InsertCommand.Parameters.Add("?PARM_FLOW_AMOUNT", MySqlDbType.Decimal).Value = Math.Round(Convert.ToDecimal(txtBoxCashFlowAmount.Text), 2)
            InsertCommand.Parameters.Add("?PARM_FLOW_CASH_DATE", MySqlDbType.Date).Value = dateCashFlowDate.Value.ToString("yyyy-MM-dd")
            InsertCommand.Parameters.Add("?PARM_FLOW_DATA_DATE", MySqlDbType.Date).Value = dateCashFlowDataDate.Value.ToString("yyyy-MM-dd")
            InsertCommand.Parameters.Add("?PARM_FLOW_ADDITIONALS", MySqlDbType.VarChar, 32767).Value = txtBoxAdditionalInformation.Text.Replace(vbCrLf, "^")
            InsertCommand.Parameters.Add("?PARM_LAST_USER", MySqlDbType.VarChar).Value = frmMain.User
            Try
                InsertConnection.Open()
                InsertCommand.ExecuteNonQuery()
                InsertConnection.Close()
            Catch ex As MySqlException
                Success = vbFalse
                MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub updateCashFlow(ByVal pCashFlowID As Long)
        Success = vbTrue

        Dim UpdateConnection As New MySqlConnection
        UpdateConnection.ConnectionString = ConnectionString

        Dim UpdateString As String =
            "UPDATE cashflow 
                SET flow_description = ?PARM_FLOW_DESCRIPTION,
                    flow_target = ?PARM_FLOW_TARGET,
                    flow_amount = ?PARM_FLOW_AMOUNT, 
                    flow_cash_date = ?PARM_FLOW_CASH_DATE,
                    flow_data_date = ?PARM_FLOW_DATA_DATE,
                    flow_additional_information = NULLIF(RTRIM(?PARM_FLOW_ADDITIONALS), ''),
                    flow_change = CURRENT_TIMESTAMP,
                    flow_user = ?PARM_LAST_USER
              WHERE flow_id = ?PARM_FLOW_ID AND (flow_description <> ?PARM_FLOW_DESCRIPTION OR 
                                                 flow_target <> ?PARM_FLOW_TARGET OR
                                                 flow_amount <> ?PARM_FLOW_AMOUNT OR 
                                                 flow_cash_date <> ?PARM_FLOW_CASH_DATE OR
                                                 flow_data_date <> ?PARM_FLOW_DATA_DATE OR
                                                 IFNULL(flow_additional_information, '') <> RTRIM(?PARM_FLOW_ADDITIONALS))"
        Dim UpdateCommand As New MySqlCommand(UpdateString, UpdateConnection)
        UpdateCommand.Parameters.Add("?PARM_FLOW_DESCRIPTION", MySqlDbType.VarChar).Value = cmbBoxCashFlowDescription.Text
        UpdateCommand.Parameters.Add("?PARM_FLOW_TARGET", MySqlDbType.VarChar).Value = cmbBoxCashFlowTarget.Text
        UpdateCommand.Parameters.Add("?PARM_FLOW_AMOUNT", MySqlDbType.Decimal).Value = Math.Round(Convert.ToDecimal(txtBoxCashFlowAmount.Text), 2)
        UpdateCommand.Parameters.Add("?PARM_FLOW_CASH_DATE", MySqlDbType.Date).Value = dateCashFlowDate.Value.ToString("yyyy-MM-dd")
        UpdateCommand.Parameters.Add("?PARM_FLOW_DATA_DATE", MySqlDbType.Date).Value = dateCashFlowDataDate.Value.ToString("yyyy-MM-dd")
        UpdateCommand.Parameters.Add("?PARM_FLOW_ADDITIONALS", MySqlDbType.VarChar, 32767).Value = txtBoxAdditionalInformation.Text.Replace(vbCrLf, "^")
        UpdateCommand.Parameters.Add("?PARM_FLOW_ID", MySqlDbType.Int64).Value = pCashFlowID
        UpdateCommand.Parameters.Add("?PARM_LAST_USER", MySqlDbType.VarChar).Value = frmMain.User
        Try
            UpdateConnection.Open()
            UpdateCommand.ExecuteNonQuery()
            UpdateConnection.Close()
        Catch ex As MySqlException
            Success = vbFalse
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub getNewCashFlowID()
        Static getNewCashFlowID As New service_GetNewCashFlowID
        NewCashFlowID = getNewCashFlowID._getNewCashFlowID()
    End Sub
End Class