'frmDocuments
'Handels all rtf-documents as blob from the database
'Copyright (C)2020 by Christian Brunner

Imports MySql.Data.MySqlClient

Public Class frmDocuments

    Private returnConnection As New service_GetDataBaseInfos
    Private ConnectionString As String = returnConnection._returnConnectionString()
    Private SelectedRowSave As Integer = 0
    Private HScrollSave As Integer = 0

    Private Sub frmDocuments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load formular and fill in text-constants like buttons and labels
        ' Read/display the documents
        Me.KeyPreview = True
        Me.Text = "Dokumente verwalten"
        lblSearch.Text = "Suche"
        lblRefresh.Text = "Aktualisiere, bitte warten ..."
        lblRefresh.Visible = False
        btnNewMember.Text = "&Neues Dokument (F6)"
        btnChangeMember.Text = "&Dokument bearbeiten"
        btnRefresh.Text = "&Aktualisieren (F5)"
        btnClose.Text = "&Schließen (F3)"
        readDocuments(txtBoxSearch.Text)
    End Sub

    Private Sub frmDocuments_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
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
                readDocuments(txtBoxSearch.Text)
            Case Keys.F6
                createNewDocument()
        End Select
    End Sub

    Private Sub dtaGridMembers_MouseClick(sender As Object, e As MouseEventArgs) Handles dtaGridDocuments.MouseClick
        'Shows the drop down menue on the datagridview via mouseclick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            cntMouseMenue.Show(Me, e.Location)
        End If
    End Sub

    Private Sub dtaGridDocument_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dtaGridDocuments.CellFormatting
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

    Private Sub btnChangeMember_Click(sender As Object, e As EventArgs) Handles btnChangeMember.Click, cntMenueChange.Click, dtaGridDocuments.DoubleClick
        changeDocument()
    End Sub

    Private Sub btnNewMember_Click(sender As Object, e As EventArgs) Handles btnNewMember.Click, cntMenueNew.Click
        createNewDocument()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click, cntMenueRefresh.Click
        readDocuments(txtBoxSearch.Text)
    End Sub

    Private Sub cntMenueDelete_Click(sender As Object, e As EventArgs) Handles cntMenueDelete.Click
        deleteDocument()
        readDocuments(txtBoxSearch.Text)
    End Sub

    Private Sub txtBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles txtBoxSearch.TextChanged
        readDocuments(txtBoxSearch.Text)
    End Sub

    Private Sub readDocuments(ByVal pSearchString As String)
        lblRefresh.Visible = True
        If dtaGridDocuments.Rows.Count > 0 Then
            'Save the current position in the datagridview
            Try
                HScrollSave = dtaGridDocuments.HorizontalScrollingOffset
                SelectedRowSave = dtaGridDocuments.CurrentRow.Index
            Catch ex As Exception
                HScrollSave = 0
                SelectedRowSave = -1
            End Try
        Else
            SelectedRowSave = -1
        End If
        dtaGridDocuments.DataSource = Nothing
        Dim Connection As New MySqlConnection
        Connection.ConnectionString = ConnectionString
        Dim SQLQueryString As String =
            "SELECT doc_id 'ID', doc_description 'Beschreibung', LENGTH(doc_data) 'Größe'
               FROM documents
              WHERE UPPER(doc_description) LIKE ?PARM_SEARCH
              ORDER BY doc_description"
        Try
            Connection.Open()
            Dim SQLCommand As New MySqlCommand(SQLQueryString, Connection)
            SQLCommand.Parameters.Add("?PARM_SEARCH", MySqlDbType.VarChar).Value = "%" & pSearchString.ToUpper & "%"
            Dim Table As New DataTable
            Dim Adapter As New MySqlDataAdapter
            Adapter.SelectCommand = SQLCommand
            Adapter.Fill(Table)
            dtaGridDocuments.DataSource = Table
            dtaGridDocuments.Columns(0).Visible = False
            If HScrollSave > 0 Then
                'Set original scrolling position
                dtaGridDocuments.HorizontalScrollingOffset = HScrollSave
            End If
            If SelectedRowSave >= 0 And SelectedRowSave < dtaGridDocuments.Rows.Count Then
                'Set original selected row
                dtaGridDocuments.CurrentCell = dtaGridDocuments.Rows(SelectedRowSave).Cells(1)
            End If
            dtaGridDocuments.Refresh()
            Connection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        lblRefresh.Visible = False
    End Sub

    Private Sub createNewDocument()
        Dim frmCreateNewMember As New frmManageMember
        frmCreateNewMember.MdiParent = frmMain
        frmCreateNewMember.Text = "Neues Dokument erstellen"
        frmCreateNewMember.NewRecordMode = True
        frmCreateNewMember.MemberID = 0
        frmCreateNewMember.Show()
    End Sub

    Private Sub changeDocument()
        Dim frmChangeSingleMember As New frmManageMember
        frmChangeSingleMember.MdiParent = frmMain
        frmChangeSingleMember.Text = "Ein Dokument bearbeiten"
        For Each SelectedRow As DataGridViewRow In dtaGridDocuments.SelectedRows
            frmChangeSingleMember.NewRecordMode = False
            frmChangeSingleMember.MemberID = Convert.ToInt64(dtaGridDocuments.Rows(SelectedRow.Index).Cells(0).Value)
            frmChangeSingleMember.Show()
        Next
    End Sub

    Private Sub deleteDocument()
        Dim Result As DialogResult
        For Each SelectedRow As DataGridViewRow In dtaGridDocuments.SelectedRows
            Result = MessageBox.Show("Bitte das Löschen des Dokumentes bestätigen", "Dokument wirklich löschen?",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = System.Windows.Forms.DialogResult.Yes Then
                deleteDocumentData(Convert.ToInt64(dtaGridDocuments.Rows(SelectedRow.Index).Cells(0).Value))
            End If
        Next
    End Sub

    Private Sub deleteDocumentData(ByVal pDocumentID As Integer)
        Dim DeleteMemberConnection As New MySqlConnection
        DeleteMemberConnection.ConnectionString = ConnectionString
        Dim DeleteMemberString As String =
            "DELETE FROM documents 
              WHERE doc_id = ?PARM_DOC_ID"
        Dim DeleteCashFlowCommand As New MySqlCommand(DeleteMemberString, DeleteMemberConnection)
        DeleteCashFlowCommand.Parameters.Add("?PARM_DOC_ID", MySqlDbType.Int64).Value = pDocumentID
        Try
            DeleteMemberConnection.Open()
            DeleteCashFlowCommand.ExecuteNonQuery()
            DeleteMemberConnection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class