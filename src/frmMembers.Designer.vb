<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMembers
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.dtaGridMembers = New System.Windows.Forms.DataGridView()
        Me.btnChangeMember = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnNewMember = New System.Windows.Forms.Button()
        Me.timerReadMember = New System.Windows.Forms.Timer(Me.components)
        Me.lblRefresh = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtBoxSearch = New System.Windows.Forms.TextBox()
        Me.cntMouseMenue = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cntMenueNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.cntMenueChange = New System.Windows.Forms.ToolStripMenuItem()
        Me.cntMenueDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.cntMenueRefresh = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dtaGridMembers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cntMouseMenue.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnRefresh
        '
        Me.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnRefresh.Location = New System.Drawing.Point(731, 448)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(169, 28)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "Button1"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'dtaGridMembers
        '
        Me.dtaGridMembers.AllowUserToAddRows = False
        Me.dtaGridMembers.AllowUserToDeleteRows = False
        Me.dtaGridMembers.AllowUserToResizeColumns = False
        Me.dtaGridMembers.AllowUserToResizeRows = False
        Me.dtaGridMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtaGridMembers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dtaGridMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtaGridMembers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtaGridMembers.Location = New System.Drawing.Point(11, 31)
        Me.dtaGridMembers.Margin = New System.Windows.Forms.Padding(2)
        Me.dtaGridMembers.MultiSelect = False
        Me.dtaGridMembers.Name = "dtaGridMembers"
        Me.dtaGridMembers.ReadOnly = True
        Me.dtaGridMembers.RowHeadersWidth = 62
        Me.dtaGridMembers.RowTemplate.Height = 28
        Me.dtaGridMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtaGridMembers.ShowEditingIcon = False
        Me.dtaGridMembers.Size = New System.Drawing.Size(1062, 412)
        Me.dtaGridMembers.TabIndex = 6
        '
        'btnChangeMember
        '
        Me.btnChangeMember.Location = New System.Drawing.Point(558, 447)
        Me.btnChangeMember.Margin = New System.Windows.Forms.Padding(2)
        Me.btnChangeMember.Name = "btnChangeMember"
        Me.btnChangeMember.Size = New System.Drawing.Size(169, 29)
        Me.btnChangeMember.TabIndex = 3
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
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Button1"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnNewMember
        '
        Me.btnNewMember.Location = New System.Drawing.Point(378, 447)
        Me.btnNewMember.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNewMember.Name = "btnNewMember"
        Me.btnNewMember.Size = New System.Drawing.Size(169, 29)
        Me.btnNewMember.TabIndex = 2
        Me.btnNewMember.Text = "Button1"
        Me.btnNewMember.UseVisualStyleBackColor = True
        '
        'timerReadMember
        '
        Me.timerReadMember.Enabled = True
        Me.timerReadMember.Interval = 30000
        '
        'lblRefresh
        '
        Me.lblRefresh.AutoSize = True
        Me.lblRefresh.Location = New System.Drawing.Point(8, 455)
        Me.lblRefresh.Name = "lblRefresh"
        Me.lblRefresh.Size = New System.Drawing.Size(39, 13)
        Me.lblRefresh.TabIndex = 11
        Me.lblRefresh.Text = "Label1"
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(12, 9)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(39, 13)
        Me.lblSearch.TabIndex = 12
        Me.lblSearch.Text = "Label1"
        '
        'txtBoxSearch
        '
        Me.txtBoxSearch.Location = New System.Drawing.Point(57, 6)
        Me.txtBoxSearch.MaxLength = 64
        Me.txtBoxSearch.Name = "txtBoxSearch"
        Me.txtBoxSearch.Size = New System.Drawing.Size(1015, 20)
        Me.txtBoxSearch.TabIndex = 1
        '
        'cntMouseMenue
        '
        Me.cntMouseMenue.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cntMenueNew, Me.cntMenueChange, Me.cntMenueDelete, Me.cntMenueRefresh})
        Me.cntMouseMenue.Name = "ContextMenuStrip1"
        Me.cntMouseMenue.Size = New System.Drawing.Size(203, 114)
        '
        'cntMenueNew
        '
        Me.cntMenueNew.Name = "cntMenueNew"
        Me.cntMenueNew.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.cntMenueNew.Size = New System.Drawing.Size(202, 22)
        Me.cntMenueNew.Text = "&Neu erstellen"
        '
        'cntMenueChange
        '
        Me.cntMenueChange.Name = "cntMenueChange"
        Me.cntMenueChange.Size = New System.Drawing.Size(202, 22)
        Me.cntMenueChange.Text = "&Bearbeiten"
        '
        'cntMenueDelete
        '
        Me.cntMenueDelete.Name = "cntMenueDelete"
        Me.cntMenueDelete.Size = New System.Drawing.Size(202, 22)
        Me.cntMenueDelete.Text = "&Löschen"
        '
        'cntMenueRefresh
        '
        Me.cntMenueRefresh.Name = "cntMenueRefresh"
        Me.cntMenueRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.cntMenueRefresh.Size = New System.Drawing.Size(202, 22)
        Me.cntMenueRefresh.Text = "&Ansicht aktualisieren"
        '
        'frmMembers
        '
        Me.AcceptButton = Me.btnNewMember
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1084, 486)
        Me.Controls.Add(Me.txtBoxSearch)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.lblRefresh)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.dtaGridMembers)
        Me.Controls.Add(Me.btnChangeMember)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnNewMember)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "frmMembers"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMembers"
        CType(Me.dtaGridMembers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cntMouseMenue.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnRefresh As Button
    Friend WithEvents dtaGridMembers As DataGridView
    Friend WithEvents btnChangeMember As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnNewMember As Button
    Friend WithEvents timerReadMember As Timer
    Friend WithEvents lblRefresh As Label
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtBoxSearch As TextBox
    Friend WithEvents cntMouseMenue As ContextMenuStrip
    Friend WithEvents cntMenueNew As ToolStripMenuItem
    Friend WithEvents cntMenueChange As ToolStripMenuItem
    Friend WithEvents cntMenueDelete As ToolStripMenuItem
    Friend WithEvents cntMenueRefresh As ToolStripMenuItem
End Class
