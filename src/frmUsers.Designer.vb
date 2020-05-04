<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsers
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
        Me.btnNewUser = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnChangeUser = New System.Windows.Forms.Button()
        Me.dtaGridUsers = New System.Windows.Forms.DataGridView()
        Me.timerReadUser = New System.Windows.Forms.Timer(Me.components)
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.cntMouseMenue = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cntMenueNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.cntMenueChange = New System.Windows.Forms.ToolStripMenuItem()
        Me.cntMenueDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.cntMenueRefresh = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dtaGridUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cntMouseMenue.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnNewUser
        '
        Me.btnNewUser.Location = New System.Drawing.Point(192, 355)
        Me.btnNewUser.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNewUser.Name = "btnNewUser"
        Me.btnNewUser.Size = New System.Drawing.Size(169, 29)
        Me.btnNewUser.TabIndex = 1
        Me.btnNewUser.Text = "Button1"
        Me.btnNewUser.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(718, 356)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(169, 28)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Button1"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnChangeUser
        '
        Me.btnChangeUser.Location = New System.Drawing.Point(372, 355)
        Me.btnChangeUser.Margin = New System.Windows.Forms.Padding(2)
        Me.btnChangeUser.Name = "btnChangeUser"
        Me.btnChangeUser.Size = New System.Drawing.Size(169, 29)
        Me.btnChangeUser.TabIndex = 2
        Me.btnChangeUser.Text = "Button1"
        Me.btnChangeUser.UseVisualStyleBackColor = True
        '
        'dtaGridUsers
        '
        Me.dtaGridUsers.AllowUserToAddRows = False
        Me.dtaGridUsers.AllowUserToDeleteRows = False
        Me.dtaGridUsers.AllowUserToResizeColumns = False
        Me.dtaGridUsers.AllowUserToResizeRows = False
        Me.dtaGridUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtaGridUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dtaGridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtaGridUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtaGridUsers.Location = New System.Drawing.Point(8, 8)
        Me.dtaGridUsers.Margin = New System.Windows.Forms.Padding(2)
        Me.dtaGridUsers.MultiSelect = False
        Me.dtaGridUsers.Name = "dtaGridUsers"
        Me.dtaGridUsers.ReadOnly = True
        Me.dtaGridUsers.RowHeadersWidth = 62
        Me.dtaGridUsers.RowTemplate.Height = 28
        Me.dtaGridUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtaGridUsers.ShowEditingIcon = False
        Me.dtaGridUsers.Size = New System.Drawing.Size(879, 343)
        Me.dtaGridUsers.TabIndex = 5
        '
        'timerReadUser
        '
        Me.timerReadUser.Enabled = True
        Me.timerReadUser.Interval = 30000
        '
        'btnRefresh
        '
        Me.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnRefresh.Location = New System.Drawing.Point(545, 356)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(169, 28)
        Me.btnRefresh.TabIndex = 3
        Me.btnRefresh.Text = "Button1"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'cntMouseMenue
        '
        Me.cntMouseMenue.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cntMenueNew, Me.cntMenueChange, Me.cntMenueDelete, Me.cntMenueRefresh})
        Me.cntMouseMenue.Name = "ContextMenuStrip1"
        Me.cntMouseMenue.Size = New System.Drawing.Size(203, 92)
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
        'frmUsers
        '
        Me.AcceptButton = Me.btnNewUser
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(898, 395)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.dtaGridUsers)
        Me.Controls.Add(Me.btnChangeUser)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnNewUser)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "frmUsers"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmUsers"
        CType(Me.dtaGridUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cntMouseMenue.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnNewUser As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnChangeUser As Button
    Friend WithEvents dtaGridUsers As DataGridView
    Friend WithEvents timerReadUser As Timer
    Friend WithEvents btnRefresh As Button
    Friend WithEvents cntMouseMenue As ContextMenuStrip
    Friend WithEvents cntMenueNew As ToolStripMenuItem
    Friend WithEvents cntMenueChange As ToolStripMenuItem
    Friend WithEvents cntMenueDelete As ToolStripMenuItem
    Friend WithEvents cntMenueRefresh As ToolStripMenuItem
End Class
