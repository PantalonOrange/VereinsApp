<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExpeditions
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
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.dtaGridExpeditions = New System.Windows.Forms.DataGridView()
        Me.btnChangeExpedition = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnNewExpedition = New System.Windows.Forms.Button()
        Me.timerReadExpeditions = New System.Windows.Forms.Timer(Me.components)
        Me.lblYear = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.cmbBoxYear = New System.Windows.Forms.ComboBox()
        Me.txtBoxSearch = New System.Windows.Forms.TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.cntMouseMenue = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cntMenueNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.cntMenueChange = New System.Windows.Forms.ToolStripMenuItem()
        Me.cntMenueDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.cntMenueRefresh = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dtaGridExpeditions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cntMouseMenue.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnRefresh
        '
        Me.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnRefresh.Location = New System.Drawing.Point(793, 558)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(80, 28)
        Me.btnRefresh.TabIndex = 6
        Me.btnRefresh.Text = "Button1"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'dtaGridExpeditions
        '
        Me.dtaGridExpeditions.AllowUserToAddRows = False
        Me.dtaGridExpeditions.AllowUserToDeleteRows = False
        Me.dtaGridExpeditions.AllowUserToResizeColumns = False
        Me.dtaGridExpeditions.AllowUserToResizeRows = False
        Me.dtaGridExpeditions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtaGridExpeditions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtaGridExpeditions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtaGridExpeditions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dtaGridExpeditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtaGridExpeditions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtaGridExpeditions.Location = New System.Drawing.Point(11, 37)
        Me.dtaGridExpeditions.Margin = New System.Windows.Forms.Padding(2)
        Me.dtaGridExpeditions.MultiSelect = False
        Me.dtaGridExpeditions.Name = "dtaGridExpeditions"
        Me.dtaGridExpeditions.ReadOnly = True
        Me.dtaGridExpeditions.RowHeadersWidth = 62
        Me.dtaGridExpeditions.RowTemplate.Height = 28
        Me.dtaGridExpeditions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtaGridExpeditions.ShowEditingIcon = False
        Me.dtaGridExpeditions.Size = New System.Drawing.Size(1035, 516)
        Me.dtaGridExpeditions.TabIndex = 2
        '
        'btnChangeExpedition
        '
        Me.btnChangeExpedition.Location = New System.Drawing.Point(536, 558)
        Me.btnChangeExpedition.Margin = New System.Windows.Forms.Padding(2)
        Me.btnChangeExpedition.Name = "btnChangeExpedition"
        Me.btnChangeExpedition.Size = New System.Drawing.Size(169, 28)
        Me.btnChangeExpedition.TabIndex = 4
        Me.btnChangeExpedition.Text = "Button1"
        Me.btnChangeExpedition.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(877, 558)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(169, 28)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Button1"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnNewExpedition
        '
        Me.btnNewExpedition.Location = New System.Drawing.Point(354, 558)
        Me.btnNewExpedition.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNewExpedition.Name = "btnNewExpedition"
        Me.btnNewExpedition.Size = New System.Drawing.Size(169, 29)
        Me.btnNewExpedition.TabIndex = 3
        Me.btnNewExpedition.Text = "Button1"
        Me.btnNewExpedition.UseVisualStyleBackColor = True
        '
        'timerReadExpeditions
        '
        Me.timerReadExpeditions.Enabled = True
        Me.timerReadExpeditions.Interval = 30000
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Location = New System.Drawing.Point(12, 561)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(39, 13)
        Me.lblYear.TabIndex = 16
        Me.lblYear.Text = "Label1"
        '
        'btnDelete
        '
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDelete.Location = New System.Drawing.Point(709, 558)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(80, 28)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "Button1"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'cmbBoxYear
        '
        Me.cmbBoxYear.FormattingEnabled = True
        Me.cmbBoxYear.Location = New System.Drawing.Point(57, 558)
        Me.cmbBoxYear.MaxLength = 4
        Me.cmbBoxYear.Name = "cmbBoxYear"
        Me.cmbBoxYear.Size = New System.Drawing.Size(67, 21)
        Me.cmbBoxYear.TabIndex = 8
        '
        'txtBoxSearch
        '
        Me.txtBoxSearch.Location = New System.Drawing.Point(57, 12)
        Me.txtBoxSearch.MaxLength = 64
        Me.txtBoxSearch.Name = "txtBoxSearch"
        Me.txtBoxSearch.Size = New System.Drawing.Size(989, 20)
        Me.txtBoxSearch.TabIndex = 1
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(12, 15)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(39, 13)
        Me.lblSearch.TabIndex = 18
        Me.lblSearch.Text = "Label1"
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
        'frmExpeditions
        '
        Me.AcceptButton = Me.btnNewExpedition
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1057, 598)
        Me.Controls.Add(Me.txtBoxSearch)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.cmbBoxYear)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.dtaGridExpeditions)
        Me.Controls.Add(Me.btnChangeExpedition)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnNewExpedition)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmExpeditions"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmExpeditions"
        CType(Me.dtaGridExpeditions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cntMouseMenue.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnRefresh As Button
    Friend WithEvents dtaGridExpeditions As DataGridView
    Friend WithEvents btnChangeExpedition As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnNewExpedition As Button
    Friend WithEvents timerReadExpeditions As Timer
    Friend WithEvents lblYear As Label
    Friend WithEvents btnDelete As Button
    Friend WithEvents cmbBoxYear As ComboBox
    Friend WithEvents txtBoxSearch As TextBox
    Friend WithEvents lblSearch As Label
    Friend WithEvents cntMouseMenue As ContextMenuStrip
    Friend WithEvents cntMenueNew As ToolStripMenuItem
    Friend WithEvents cntMenueChange As ToolStripMenuItem
    Friend WithEvents cntMenueDelete As ToolStripMenuItem
    Friend WithEvents cntMenueRefresh As ToolStripMenuItem
End Class
