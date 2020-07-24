<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCash
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
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.dtaGridCashFlow = New System.Windows.Forms.DataGridView()
        Me.btnChangeFlow = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnNewFlow = New System.Windows.Forms.Button()
        Me.timeReadCashFlow = New System.Windows.Forms.Timer(Me.components)
        Me.lblTxtTotal = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.cmbBoxYear = New System.Windows.Forms.ComboBox()
        Me.txtBoxSearch = New System.Windows.Forms.TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.cntMouseMenue = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cntMenueNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.cntMenueChange = New System.Windows.Forms.ToolStripMenuItem()
        Me.cntMenueDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.cntMenueRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblRefresh = New System.Windows.Forms.Label()
        CType(Me.dtaGridCashFlow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cntMouseMenue.SuspendLayout()
        Me.SuspendLayout()
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
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Location = New System.Drawing.Point(13, 566)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(39, 13)
        Me.lblYear.TabIndex = 24
        Me.lblYear.Text = "Label1"
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
        'dtaGridCashFlow
        '
        Me.dtaGridCashFlow.AllowUserToAddRows = False
        Me.dtaGridCashFlow.AllowUserToDeleteRows = False
        Me.dtaGridCashFlow.AllowUserToResizeColumns = False
        Me.dtaGridCashFlow.AllowUserToResizeRows = False
        Me.dtaGridCashFlow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtaGridCashFlow.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtaGridCashFlow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtaGridCashFlow.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dtaGridCashFlow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtaGridCashFlow.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtaGridCashFlow.Location = New System.Drawing.Point(11, 37)
        Me.dtaGridCashFlow.Margin = New System.Windows.Forms.Padding(2)
        Me.dtaGridCashFlow.MultiSelect = False
        Me.dtaGridCashFlow.Name = "dtaGridCashFlow"
        Me.dtaGridCashFlow.ReadOnly = True
        Me.dtaGridCashFlow.RowHeadersWidth = 62
        Me.dtaGridCashFlow.RowTemplate.Height = 28
        Me.dtaGridCashFlow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtaGridCashFlow.ShowEditingIcon = False
        Me.dtaGridCashFlow.Size = New System.Drawing.Size(1035, 516)
        Me.dtaGridCashFlow.TabIndex = 2
        '
        'btnChangeFlow
        '
        Me.btnChangeFlow.Location = New System.Drawing.Point(536, 558)
        Me.btnChangeFlow.Margin = New System.Windows.Forms.Padding(2)
        Me.btnChangeFlow.Name = "btnChangeFlow"
        Me.btnChangeFlow.Size = New System.Drawing.Size(169, 28)
        Me.btnChangeFlow.TabIndex = 4
        Me.btnChangeFlow.Text = "Button1"
        Me.btnChangeFlow.UseVisualStyleBackColor = True
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
        'btnNewFlow
        '
        Me.btnNewFlow.Location = New System.Drawing.Point(354, 558)
        Me.btnNewFlow.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNewFlow.Name = "btnNewFlow"
        Me.btnNewFlow.Size = New System.Drawing.Size(169, 29)
        Me.btnNewFlow.TabIndex = 3
        Me.btnNewFlow.Text = "Button1"
        Me.btnNewFlow.UseVisualStyleBackColor = True
        '
        'timeReadCashFlow
        '
        Me.timeReadCashFlow.Enabled = True
        Me.timeReadCashFlow.Interval = 30000
        '
        'lblTxtTotal
        '
        Me.lblTxtTotal.AutoSize = True
        Me.lblTxtTotal.Location = New System.Drawing.Point(131, 566)
        Me.lblTxtTotal.Name = "lblTxtTotal"
        Me.lblTxtTotal.Size = New System.Drawing.Size(39, 13)
        Me.lblTxtTotal.TabIndex = 25
        Me.lblTxtTotal.Text = "Label1"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Location = New System.Drawing.Point(188, 566)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(41, 15)
        Me.lblTotal.TabIndex = 26
        Me.lblTotal.Text = "Label1"
        '
        'cmbBoxYear
        '
        Me.cmbBoxYear.FormattingEnabled = True
        Me.cmbBoxYear.Location = New System.Drawing.Point(58, 563)
        Me.cmbBoxYear.MaxLength = 4
        Me.cmbBoxYear.Name = "cmbBoxYear"
        Me.cmbBoxYear.Size = New System.Drawing.Size(67, 21)
        Me.cmbBoxYear.TabIndex = 8
        '
        'txtBoxSearch
        '
        Me.txtBoxSearch.Location = New System.Drawing.Point(54, 12)
        Me.txtBoxSearch.MaxLength = 64
        Me.txtBoxSearch.Name = "txtBoxSearch"
        Me.txtBoxSearch.Size = New System.Drawing.Size(992, 20)
        Me.txtBoxSearch.TabIndex = 1
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(9, 15)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(39, 13)
        Me.lblSearch.TabIndex = 29
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
        'lblRefresh
        '
        Me.lblRefresh.AutoSize = True
        Me.lblRefresh.Location = New System.Drawing.Point(13, 566)
        Me.lblRefresh.Name = "lblRefresh"
        Me.lblRefresh.Size = New System.Drawing.Size(39, 13)
        Me.lblRefresh.TabIndex = 30
        Me.lblRefresh.Text = "Label1"
        '
        'frmCash
        '
        Me.AcceptButton = Me.btnNewFlow
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1055, 595)
        Me.Controls.Add(Me.lblRefresh)
        Me.Controls.Add(Me.txtBoxSearch)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.cmbBoxYear)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblTxtTotal)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.dtaGridCashFlow)
        Me.Controls.Add(Me.btnChangeFlow)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnNewFlow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmCash"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCash"
        CType(Me.dtaGridCashFlow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cntMouseMenue.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnDelete As Button
    Friend WithEvents lblYear As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents dtaGridCashFlow As DataGridView
    Friend WithEvents btnChangeFlow As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnNewFlow As Button
    Friend WithEvents timeReadCashFlow As Timer
    Friend WithEvents lblTxtTotal As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents cmbBoxYear As ComboBox
    Friend WithEvents txtBoxSearch As TextBox
    Friend WithEvents lblSearch As Label
    Friend WithEvents cntMouseMenue As ContextMenuStrip
    Friend WithEvents cntMenueNew As ToolStripMenuItem
    Friend WithEvents cntMenueChange As ToolStripMenuItem
    Friend WithEvents cntMenueDelete As ToolStripMenuItem
    Friend WithEvents cntMenueRefresh As ToolStripMenuItem
    Friend WithEvents lblRefresh As Label
End Class
