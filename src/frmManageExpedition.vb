'frmManageExpedition
'Create or change expeditions, add or remove members
'Copyright (C)2019,2020 by Christian Brunner

Imports MySql.Data.MySqlClient

Public Class frmManageExpedition

    Private getConnection As New service_GetDataBaseInfos
    Private ConnectionString As String = getConnection._returnConnectionString()

    Public NewRecordMode As Boolean
    Public ExpeditionID As Long
    Private SelectedMemberID As Integer
    Private NewExpeditionID As Long
    Private TemporaryExpeditionID As Long
    Private Success As Boolean = True

    Private Sub frmManageExpedition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load formular and fill in comboboxes and text-constants like buttons and labels
        ' If the variable NewRecordMode is ON the form will start with all empty records
        '  - On NewRecordMode a temporary expeditionID is generated to add the members
        '     This temporary expeditionID was changed to the new correct one by clicking save
        ' Is the variable NewRecordMode OFF the form loads the values from the table -> key ExpeditionID
        Me.KeyPreview = True
        lblExpeditionName.Text = "Bezeichnung"
        lblExpeditionOrganisation.Text = "Veranstalter"
        lblExpeditionCity.Text = "Ort"
        lblDate.Text = "Von/Bis"
        grpBoxExpeditionMembers.Text = "Mitglieder"
        grpBoxAdditions.Text = "Zusatzinformationen"
        lbltxtid.Text = "ID"
        lblChange.Text = "Änderung"
        btnSave.Text = "&Speichern"
        btnCancel.Text = "&Abbrechen (F12)"
        btnAddExpeditionMember.Text = "&+"
        btnRemoveExpeditionMember.Text = "&-"
        If NewRecordMode Then
            getTemporaryExpeditionID()
            ExpeditionID = TemporaryExpeditionID
            lbltxtid.Visible = False
            lblExpeditionID.Visible = False
            lblChange.Visible = False
            lblChangeDate.Visible = False
        Else
            readExpedition(ExpeditionID)
            readExpeditionMembers(ExpeditionID)
        End If
        lblExpeditionID.Text = Convert.ToString(ExpeditionID)
        fillInComboBoxExpeditionMembers(ExpeditionID)
        fillInCmbBoxExpeditionName()
        fillInCmbBoxExpeditionOrganisation()
        fillInCmbBoxExpeditionCity()
        cmbBoxExpeditionName.Select()
    End Sub

    Private Sub frmManageExpedition_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F12
                Me.Close()
        End Select
    End Sub

    Private Sub frmManageExpedition_Close(sender As Object, e As EventArgs) Handles MyBase.Closed
        If NewRecordMode Then
            removeTemporaryMembers(TemporaryExpeditionID)
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Make some checks and write or update the inserted values
        If cmbBoxExpeditionName.Text = "" Then
            MessageBox.Show("Kein Name eingegeben", "Kein Name", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbBoxExpeditionName.Select()
        Else
            If NewRecordMode Then
                saveNewExpedition()
            Else
                updateExpedition(ExpeditionID)
            End If

            If Success Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If NewRecordMode Then
            removeTemporaryMembers(TemporaryExpeditionID)
        End If
        Me.Close()
    End Sub

    Private Sub btnAddExpeditionMember_Click(sender As Object, e As EventArgs) Handles btnAddExpeditionMember.Click
        If cmbBoxExpeditionMembers.Text = "" Then
            MessageBox.Show("Auswahl leer", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Try
                SelectedMemberID = Convert.ToInt32(cmbBoxExpeditionMembers.Text.Substring(0, cmbBoxExpeditionMembers.Text.IndexOf("-")))
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Fehler bei Konvertierung", MessageBoxButtons.OK, MessageBoxIcon.Error)
                SelectedMemberID = 0
            End Try
            If SelectedMemberID > 0 Then
                insertMemberToExpedition(ExpeditionID, SelectedMemberID)
                readExpeditionMembers(ExpeditionID)
                fillInComboBoxExpeditionMembers(ExpeditionID)
            End If
        End If
    End Sub

    Private Sub btnRemoveExpeditionMember_Click(sender As Object, e As EventArgs) Handles btnRemoveExpeditionMember.Click, cntMenuRemove.Click
        For Each SelectedRow As DataGridViewRow In dtaGridExpeditionMembers.SelectedRows
            removeSingleMemberFromExpedition(ExpeditionID, dtaGridExpeditionMembers.Rows(SelectedRow.Index).Cells(0).Value)
            readExpeditionMembers(ExpeditionID)
            fillInComboBoxExpeditionMembers(ExpeditionID)
        Next
    End Sub

    Private Sub dtaGridExpeditionMembers_MouseClick(sender As Object, e As MouseEventArgs) Handles dtaGridExpeditionMembers.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            cntMouseMenue.Show(Me, e.Location)
        End If
    End Sub
    Private Sub dtaGridExpeditionMembers_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dtaGridExpeditionMembers.CellFormatting
        If e.RowIndex Mod 2 = 0 Then
            'Every second row
            e.CellStyle.ForeColor = Color.Black
            e.CellStyle.BackColor = Color.LightGray
        Else
            e.CellStyle.ForeColor = Color.DarkRed
            e.CellStyle.BackColor = Color.White
        End If
    End Sub

    Private Sub fillInCmbBoxExpeditionName()
        cmbBoxExpeditionName.Items.Clear()
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Connection.Open()
        Dim QueryString As String =
            "SELECT exp_name FROM expeditions GROUP BY exp_name ORDER BY exp_name"
        Dim QueryCommand As New MySqlCommand(QueryString, Connection)
        Dim SQLReader As MySqlDataReader
        SQLReader = QueryCommand.ExecuteReader
        While (SQLReader.Read)
            cmbBoxExpeditionName.Items.Add(SQLReader(0).ToString)
        End While
        Connection.Close()
        With cmbBoxExpeditionName
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With
    End Sub

    Private Sub fillInCmbBoxExpeditionOrganisation()
        cmbBoxExpeditionOrganisation.Items.Clear()
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Connection.Open()
        Dim QueryString As String =
            "SELECT exp_organisation FROM expeditions WHERE exp_organisation IS NOT NULL GROUP BY exp_organisation ORDER BY exp_organisation"
        Dim QueryCommand As New MySqlCommand(QueryString, Connection)
        Dim SQLReader As MySqlDataReader
        SQLReader = QueryCommand.ExecuteReader
        While (SQLReader.Read)
            cmbBoxExpeditionOrganisation.Items.Add(SQLReader(0).ToString)
        End While
        Connection.Close()
        With cmbBoxExpeditionOrganisation
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With
    End Sub

    Private Sub fillInCmbBoxExpeditionCity()
        cmbBoxExpeditionCity.Items.Clear()
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Connection.Open()
        Dim QueryString As String =
            "SELECT exp_city FROM expeditions WHERE exp_city IS NOT NULL GROUP BY exp_city ORDER BY exp_city"
        Dim QueryCommand As New MySqlCommand(QueryString, Connection)
        Dim SQLReader As MySqlDataReader
        SQLReader = QueryCommand.ExecuteReader
        While (SQLReader.Read)
            cmbBoxExpeditionCity.Items.Add(SQLReader(0).ToString)
        End While
        Connection.Close()
        With cmbBoxExpeditionCity
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With
    End Sub

    Private Sub fillInComboBoxExpeditionMembers(ByVal pExpeditionID As Long)
        'Fill in the combobox with the members who where not allready inserted to this expedition
        cmbBoxExpeditionMembers.Items.Clear()
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Connection.Open()
        Dim QueryString As String =
            "SELECT mem_id, mem_name, mem_firstname, mem_grade
               FROM members 
              WHERE mem_id NOT IN (SELECT exp_mem_id FROM expedition_members WHERE exp_mem_exp_id = ?PARM_EXPEDITION_ID)
              ORDER BY mem_end, mem_id"
        Dim QueryCommand As New MySqlCommand(QueryString, Connection)
        QueryCommand.Parameters.Add("?PARM_EXPEDITION_ID", MySqlDbType.Int64).Value = pExpeditionID
        Dim SQLReader As MySqlDataReader
        SQLReader = QueryCommand.ExecuteReader
        While (SQLReader.Read)
            cmbBoxExpeditionMembers.Items.Add(SQLReader(0).ToString & "-" + SQLReader(1).ToString & " " + SQLReader(2).ToString & "-" & SQLReader(3).ToString)
        End While
        Connection.Close()
    End Sub

    Private Sub readExpedition(ByVal pExpeditionID As Long)
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Connection.Open()
        Dim QueryString As String =
            "SELECT exp_name, IFNULL(exp_organisation, ''), IFNULL(exp_city, ''), IFNULL(exp_date_from, CURRENT_DATE), IFNULL(exp_date_to, CURRENT_DATE),
                    IFNULL(exp_additionals, ''), exp_change, exp_user
               FROM expeditions 
              WHERE exp_id = ?PARM_EXPEDITION_ID"
        Dim QueryCommand As New MySqlCommand(QueryString, Connection)
        QueryCommand.Parameters.Add("?PARM_EXPEDITION_ID", MySqlDbType.Int64).Value = pExpeditionID
        Dim SQLReader As MySqlDataReader
        SQLReader = QueryCommand.ExecuteReader
        While (SQLReader.Read)
            cmbBoxExpeditionName.Text = SQLReader(0).ToString
            cmbBoxExpeditionOrganisation.Text = SQLReader(1).ToString
            cmbBoxExpeditionCity.Text = SQLReader(2).ToString
            dateBegin.Value = SQLReader(3).ToString
            dateEnd.Value = SQLReader(4).ToString
            txtBoxAdditionals.Text = SQLReader(5).ToString.Replace("^", vbCrLf)
            lblChangeDate.Text = SQLReader(6).ToString & "/" & SQLReader(7).ToString
            Exit While
        End While
        Connection.Close()
    End Sub

    Private Sub readExpeditionMembers(ByVal pExpeditionID As Long)
        dtaGridExpeditionMembers.DataSource = Nothing
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Connection.Open()
        Dim QueryString As String =
            "SELECT mem_id 'ID', mem_name 'Name', mem_firstname 'Vorname', mem_grade 'Rang', mem_function 'Vereins-Funktion'
               FROM expedition_members 
               JOIN members ON (mem_id = exp_mem_id) 
              WHERE exp_mem_exp_id = ?PARM_EXPEDITION_ID
              ORDER BY mem_id"
        Dim QueryCommand As New MySqlCommand(QueryString, Connection)
        QueryCommand.Parameters.Add("?PARM_EXPEDITION_ID", MySqlDbType.Int64).Value = pExpeditionID
        Dim Table As New DataTable
        Dim Adapter As New MySqlDataAdapter
        Adapter.SelectCommand = QueryCommand
        Adapter.Fill(Table)
        dtaGridExpeditionMembers.DataSource = Table
        dtaGridExpeditionMembers.Columns(0).Visible = False
        dtaGridExpeditionMembers.Refresh()
        Connection.Close()
    End Sub

    Private Sub insertMemberToExpedition(ByVal pExpeditionID As Long, ByVal pMemberID As Integer)
        Dim InsertMemberConnection As New MySqlConnection
        InsertMemberConnection.ConnectionString = ConnectionString
        Dim InsertMemberString As String =
            "INSERT INTO expedition_members (exp_mem_exp_id, exp_mem_id, exp_mem_user) 
             VALUES(?PARM_EXP_MEM_EXP_ID, ?PARM_EXP_MEM_ID, ?PARM_LAST_USER)"
        Dim InsertMemberCommand As New MySqlCommand(InsertMemberString, InsertMemberConnection)
        InsertMemberCommand.Parameters.Add("?PARM_EXP_MEM_EXP_ID", MySqlDbType.Int64).Value = pExpeditionID
        InsertMemberCommand.Parameters.Add("?PARM_EXP_MEM_ID", MySqlDbType.Int32).Value = pMemberID
        InsertMemberCommand.Parameters.Add("?PARM_LAST_USER", MySqlDbType.VarChar).Value = frmMain.User
        Try
            InsertMemberConnection.Open()
            InsertMemberCommand.ExecuteNonQuery()
            InsertMemberConnection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub removeSingleMemberFromExpedition(ByVal pExpeditionID As Long, ByVal pMemberID As Integer)
        Dim RemoveMemberConnection As New MySqlConnection
        RemoveMemberConnection.ConnectionString = ConnectionString
        Dim RemoveMemberString As String =
            "DELETE FROM expedition_members 
              WHERE exp_mem_exp_id = ?PARM_EXP_MEM_EXP_ID AND exp_mem_id = ?PARM_EXP_MEM_ID"
        Dim RemoveMemberCommand As New MySqlCommand(RemoveMemberString, RemoveMemberConnection)
        RemoveMemberCommand.Parameters.Add("?PARM_EXP_MEM_EXP_ID", MySqlDbType.Int64).Value = pExpeditionID
        RemoveMemberCommand.Parameters.Add("?PARM_EXP_MEM_ID", MySqlDbType.Int32).Value = pMemberID
        Try
            RemoveMemberConnection.Open()
            RemoveMemberCommand.ExecuteNonQuery()
            RemoveMemberConnection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub removeTemporaryMembers(ByVal pExpeditionID As Long)
        'On NewRecordMode ON by clicking cancel this subroutine delete all temporary members for this expedition
        Dim DeleteTemporaryMemberConnection As New MySqlConnection
        DeleteTemporaryMemberConnection.ConnectionString = ConnectionString
        Dim DeleteTemporaryMemberString As String =
            "DELETE FROM expedition_members 
              WHERE exp_mem_exp_id = ?PARM_EXP_MEM_EXP_ID"
        Dim DeleteTemporaryMemberCommand As New MySqlCommand(DeleteTemporaryMemberString, DeleteTemporaryMemberConnection)
        DeleteTemporaryMemberCommand.Parameters.Add("?PARM_EXP_MEM_EXP_ID", MySqlDbType.Int64).Value = pExpeditionID
        Try
            DeleteTemporaryMemberConnection.Open()
            DeleteTemporaryMemberCommand.ExecuteNonQuery()
            DeleteTemporaryMemberConnection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub saveNewExpedition()
        'First step get new expedition id and update existing temporary expedition member ids
        getNewExpeditionID()
        Dim UpdateTemporaryMemberConnection As New MySqlConnection
        UpdateTemporaryMemberConnection.ConnectionString = ConnectionString
        Dim UpdateTemporaryMemberString As String =
            "UPDATE expedition_members 
                SET exp_mem_exp_id = ?PARM_EXP_MEM_EXP_ID 
              WHERE exp_mem_exp_id = ?PARM_TEMP_ID"
        Dim UpdateTemporaryMemberCommand As New MySqlCommand(UpdateTemporaryMemberString, UpdateTemporaryMemberConnection)
        UpdateTemporaryMemberCommand.Parameters.Add("?PARM_TEMP_ID", MySqlDbType.Int64).Value = Convert.ToInt64(lblExpeditionID.Text)
        UpdateTemporaryMemberCommand.Parameters.Add("?PARM_EXP_MEM_EXP_ID", MySqlDbType.Int32).Value = NewExpeditionID
        Try
            UpdateTemporaryMemberConnection.Open()
            UpdateTemporaryMemberCommand.ExecuteNonQuery()
            UpdateTemporaryMemberConnection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Next step write new expedition data
        Success = True
        Dim InsertConnection As New MySqlConnection
        InsertConnection.ConnectionString = ConnectionString
        Dim InsertString As String =
            "INSERT INTO expeditions (exp_id, exp_name, exp_organisation, exp_city, exp_date_from, exp_date_to, exp_additionals, exp_user)
             VALUES(?PARM_EXPEDITION_ID, ?PARM_EXPEDITION_NAME, NULLIF(?PARM_EXPEDITION_ORGANISATION, ''), 
                    NULLIF(?PARM_EXPEDITION_CITY, ''), ?PARM_EXPEDITION_DATE_FROM, ?PARM_EXPEDITION_DATE_TO, 
                           NULLIF(RTRIM(?PARM_EXPEDITION_ADDITIONALS), ''), ?PARM_LAST_USER)"
        Dim InsertCommand As New MySqlCommand(InsertString, InsertConnection)
        InsertCommand.Parameters.Add("?PARM_EXPEDITION_ID", MySqlDbType.Int64).Value = NewExpeditionID
        InsertCommand.Parameters.Add("?PARM_EXPEDITION_NAME", MySqlDbType.VarChar).Value = cmbBoxExpeditionName.Text
        InsertCommand.Parameters.Add("?PARM_EXPEDITION_ORGANISATION", MySqlDbType.VarChar).Value = cmbBoxExpeditionOrganisation.Text
        InsertCommand.Parameters.Add("?PARM_EXPEDITION_CITY", MySqlDbType.VarChar).Value = cmbBoxExpeditionCity.Text
        InsertCommand.Parameters.Add("?PARM_EXPEDITION_DATE_FROM", MySqlDbType.Date).Value = dateBegin.Value.ToString("yyyy-MM-dd")
        InsertCommand.Parameters.Add("?PARM_EXPEDITION_DATE_TO", MySqlDbType.Date).Value = dateEnd.Value.ToString("yyyy-MM-dd")
        InsertCommand.Parameters.Add("PARM_EXPEDITION_ADDITIONALS", MySqlDbType.VarChar, 32767).Value = txtBoxAdditionals.Text.Replace(vbCrLf, "^")
        InsertCommand.Parameters.Add("?PARM_LAST_USER", MySqlDbType.VarChar).Value = frmMain.User
        Try
            InsertConnection.Open()
            InsertCommand.ExecuteNonQuery()
            InsertConnection.Close()
        Catch ex As MySqlException
            Success = False
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub updateExpedition(ByVal pEpeditionID As Long)
        Success = True
        Dim UpdateConnection As New MySqlConnection
        UpdateConnection.ConnectionString = ConnectionString
        Dim UpdateString As String =
            "UPDATE expeditions 
                SET exp_name = ?PARM_EXPEDITION_NAME, 
                    exp_organisation = ?PARM_EXPEDITION_ORGANISATION, 
                    exp_city = ?PARM_EXPEDITION_CITY,
                    exp_date_from = ?PARM_EXPEDITION_DATE_FROM, 
                    exp_date_to = ?PARM_EXPEDITION_DATE_TO,
                    exp_additionals = NULLIF(?PARM_EXPEDITION_ADDITIONALS, ''),
                    exp_change = CURRENT_TIMESTAMP, 
                    exp_user = ?PARM_LAST_USER
              WHERE exp_id = ?PARM_EXPEDITION_ID AND (exp_name <> ?PARM_EXPEDITION_NAME OR 
                                                      exp_organisation <> ?PARM_EXPEDITION_ORGANISATION OR
                                                      exp_city <> ?PARM_EXPEDITION_CITY OR 
                                                      exp_date_from <> ?PARM_EXPEDITION_DATE_FROM OR
                                                      exp_date_to <> ?PARM_EXPEDITION_DATE_TO OR
                                                      IFNULL(exp_additionals, '') <> RTRIM(?PARM_EXPEDITION_ADDITIONALS))"
        Dim UpdateCommand As New MySqlCommand(UpdateString, UpdateConnection)
        UpdateCommand.Parameters.Add("?PARM_EXPEDITION_ID", MySqlDbType.Int64).Value = pEpeditionID
        UpdateCommand.Parameters.Add("?PARM_EXPEDITION_NAME", MySqlDbType.VarChar).Value = cmbBoxExpeditionName.Text
        UpdateCommand.Parameters.Add("?PARM_EXPEDITION_ORGANISATION", MySqlDbType.VarChar).Value = cmbBoxExpeditionOrganisation.Text
        UpdateCommand.Parameters.Add("?PARM_EXPEDITION_CITY", MySqlDbType.VarChar).Value = cmbBoxExpeditionCity.Text
        UpdateCommand.Parameters.Add("?PARM_EXPEDITION_DATE_FROM", MySqlDbType.Date).Value = dateBegin.Value.ToString("yyyy-MM-dd")
        UpdateCommand.Parameters.Add("?PARM_EXPEDITION_DATE_TO", MySqlDbType.Date).Value = dateEnd.Value.ToString("yyyy-MM-dd")
        UpdateCommand.Parameters.Add("PARM_EXPEDITION_ADDITIONALS", MySqlDbType.VarChar, 32767).Value = txtBoxAdditionals.Text.Replace(vbCrLf, "^")
        UpdateCommand.Parameters.Add("?PARM_LAST_USER", MySqlDbType.VarChar).Value = frmMain.User
        Try
            UpdateConnection.Open()
            UpdateCommand.ExecuteNonQuery()
            UpdateConnection.Close()
        Catch ex As MySqlException
            Success = False
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub getNewExpeditionID()
        Static getNewExpeditionID As New service_GetNewExpeditionID
        NewExpeditionID = getNewExpeditionID._getNewExpeditionID()
    End Sub

    Private Sub getTemporaryExpeditionID()
        Static randomGenerator As System.Random = New System.Random
        TemporaryExpeditionID = randomGenerator.Next() * -1
    End Sub
End Class