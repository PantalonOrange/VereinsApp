<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocuments
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cntMenueRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.cntMenuePrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.cntMenueDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.cntMenueChange = New System.Windows.Forms.ToolStripMenuItem()
        Me.cntMenueNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.cntMouseMenue = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.txtBoxSearch = New System.Windows.Forms.TextBox()
        Me.lblRefresh = New System.Windows.Forms.Label()
        Me.timerReadDocuments = New System.Windows.Forms.Timer(Me.components)
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.dtaGridDocuments = New System.Windows.Forms.DataGridView()
        Me.btnChangeMember = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnNewMember = New System.Windows.Forms.Button()
        Me.cntMouseMenue.SuspendLayout()
        CType(Me.dtaGridDocuments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cntMenueRefresh
        '
        Me.cntMenueRefresh.Name = "cntMenueRefresh"
        Me.cntMenueRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.cntMenueRefresh.Size = New System.Drawing.Size(202, 22)
        Me.cntMenueRefresh.Text = "&Ansicht aktualisieren"
        '
        'cntMenuePrint
        '
        Me.cntMenuePrint.Name = "cntMenuePrint"
        Me.cntMenuePrint.Size = New System.Drawing.Size(202, 22)
        Me.cntMenuePrint.Text = "&Drucken"
        '
        'cntMenueDelete
        '
        Me.cntMenueDelete.Name = "cntMenueDelete"
        Me.cntMenueDelete.Size = New System.Drawing.Size(202, 22)
        Me.cntMenueDelete.Text = "&Löschen"
        '
        'cntMenueChange
        '
        Me.cntMenueChange.Name = "cntMenueChange"
        Me.cntMenueChange.Size = New System.Drawing.Size(202, 22)
        Me.cntMenueChange.Text = "&Bearbeiten"
        '
        'cntMenueNew
        '
        Me.cntMenueNew.Name = "cntMenueNew"
        Me.cntMenueNew.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.cntMenueNew.Size = New System.Drawing.Size(202, 22)
        Me.cntMenueNew.Text = "&Neu erstellen"
        '
        'cntMouseMenue
        '
        Me.cntMouseMenue.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cntMenueNew, Me.cntMenueChange, Me.cntMenueDelete, Me.cntMenuePrint, Me.cntMenueRefresh})
        Me.cntMouseMenue.Name = "ContextMenuStrip1"
        Me.cntMouseMenue.Size = New System.Drawing.Size(203, 114)
        '
        'txtBoxSearch
        '
        Me.txtBoxSearch.Location = New System.Drawing.Point(57, 6)
        Me.txtBoxSearch.MaxLength = 64
        Me.txtBoxSearch.Name = "txtBoxSearch"
        Me.txtBoxSearch.Size = New System.Drawing.Size(1015, 20)
        Me.txtBoxSearch.TabIndex = 13
        '
        'lblRefresh
        '
        Me.lblRefresh.AutoSize = True
        Me.lblRefresh.Location = New System.Drawing.Point(8, 455)
        Me.lblRefresh.Name = "lblRefresh"
        Me.lblRefresh.Size = New System.Drawing.Size(39, 13)
        Me.lblRefresh.TabIndex = 19
        Me.lblRefresh.Text = "Label1"
        '
        'timerReadDocuments
        '
        Me.timerReadDocuments.Enabled = True
        Me.timerReadDocuments.Interval = 60000
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(12, 9)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(39, 13)
        Me.lblSearch.TabIndex = 20
        Me.lblSearch.Text = "Label1"
        '
        'btnRefresh
        '
        Me.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnRefresh.Location = New System.Drawing.Point(731, 448)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(169, 28)
        Me.btnRefresh.TabIndex = 17
        Me.btnRefresh.Text = "Button1"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'dtaGridDocuments
        '
        Me.dtaGridDocuments.AllowUserToAddRows = False
        Me.dtaGridDocuments.AllowUserToDeleteRows = False
        Me.dtaGridDocuments.AllowUserToResizeColumns = False
        Me.dtaGridDocuments.AllowUserToResizeRows = False
        Me.dtaGridDocuments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtaGridDocuments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtaGridDocuments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtaGridDocuments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dtaGridDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtaGridDocuments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtaGridDocuments.Location = New System.Drawing.Point(11, 31)
        Me.dtaGridDocuments.Margin = New System.Windows.Forms.Padding(2)
        Me.dtaGridDocuments.MultiSelect = False
        Me.dtaGridDocuments.Name = "dtaGridDocuments"
        Me.dtaGridDocuments.ReadOnly = True
        Me.dtaGridDocuments.RowHeadersWidth = 62
        Me.dtaGridDocuments.RowTemplate.Height = 28
        Me.dtaGridDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtaGridDocuments.ShowEditingIcon = False
        Me.dtaGridDocuments.Size = New System.Drawing.Size(1062, 412)
        Me.dtaGridDocuments.TabIndex = 14
        '
        'btnChangeMember
        '
        Me.btnChangeMember.Location = New System.Drawing.Point(558, 447)
        Me.btnChangeMember.Margin = New System.Windows.Forms.Padding(2)
        Me.btnChangeMember.Name = "btnChangeMember"
        Me.btnChangeMember.Size = New System.Drawing.Size(169, 29)
        Me.btnChangeMember.TabIndex = 16
        Me.btnChangeMember.Text = "Button1"
        Me.btnChangeMember.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(904, 448)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(169, 28)
        Me.btnClose.TabIndex = 18
        Me.btnClose.Text = "Button1"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnNewMember
        '
        Me.btnNewMember.Location = New System.Drawing.Point(378, 447)
        Me.btnNewMember.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNewMember.Name = "btnNewMember"
        Me.btnNewMember.Size = New System.Drawing.Size(169, 29)
        Me.btnNewMember.TabIndex = 15
        Me.btnNewMember.Text = "Button1"
        Me.btnNewMember.UseVisualStyleBackColor = True
        '
        'frmDocuments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1086, 484)
        Me.Controls.Add(Me.txtBoxSearch)
        Me.Controls.Add(Me.lblRefresh)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.dtaGridDocuments)
        Me.Controls.Add(Me.btnChangeMember)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnNewMember)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmDocuments"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "frmDocuments"
        Me.cntMouseMenue.ResumeLayout(False)
        CType(Me.dtaGridDocuments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cntMenueRefresh As ToolStripMenuItem
    Friend WithEvents cntMenuePrint As ToolStripMenuItem
    Friend WithEvents cntMenueDelete As ToolStripMenuItem
    Friend WithEvents cntMenueChange As ToolStripMenuItem
    Friend WithEvents cntMenueNew As ToolStripMenuItem
    Friend WithEvents cntMouseMenue As ContextMenuStrip
    Friend WithEvents txtBoxSearch As TextBox
    Friend WithEvents lblRefresh As Label
    Friend WithEvents timerReadDocuments As Timer
    Friend WithEvents lblSearch As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents dtaGridDocuments As DataGridView
    Friend WithEvents btnChangeMember As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnNewMember As Button
End Class
