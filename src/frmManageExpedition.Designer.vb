<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageExpedition
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
        Me.lblExpeditionName = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblExpeditionOrganisation = New System.Windows.Forms.Label()
        Me.lblExpeditionCity = New System.Windows.Forms.Label()
        Me.cmbBoxExpeditionMembers = New System.Windows.Forms.ComboBox()
        Me.btnAddExpeditionMember = New System.Windows.Forms.Button()
        Me.dtaGridExpeditionMembers = New System.Windows.Forms.DataGridView()
        Me.btnRemoveExpeditionMember = New System.Windows.Forms.Button()
        Me.dateBegin = New System.Windows.Forms.DateTimePicker()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.dateEnd = New System.Windows.Forms.DateTimePicker()
        Me.lblChangeDate = New System.Windows.Forms.Label()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.lblExpeditionID = New System.Windows.Forms.Label()
        Me.lbltxtid = New System.Windows.Forms.Label()
        Me.txtBoxAdditionals = New System.Windows.Forms.TextBox()
        Me.cmbBoxExpeditionName = New System.Windows.Forms.ComboBox()
        Me.cmbBoxExpeditionOrganisation = New System.Windows.Forms.ComboBox()
        Me.cmbBoxExpeditionCity = New System.Windows.Forms.ComboBox()
        Me.grpBoxAdditions = New System.Windows.Forms.GroupBox()
        Me.grpBoxExpeditionMembers = New System.Windows.Forms.GroupBox()
        Me.cntMouseMenue = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cntMenuRemove = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dtaGridExpeditionMembers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBoxExpeditionMembers.SuspendLayout()
        Me.cntMouseMenue.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblExpeditionName
        '
        Me.lblExpeditionName.AutoSize = True
        Me.lblExpeditionName.Location = New System.Drawing.Point(11, 14)
        Me.lblExpeditionName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblExpeditionName.Name = "lblExpeditionName"
        Me.lblExpeditionName.Size = New System.Drawing.Size(39, 13)
        Me.lblExpeditionName.TabIndex = 15
        Me.lblExpeditionName.Text = "Label1"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(658, 570)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(131, 44)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "Button1"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(465, 570)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(183, 44)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Button1"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblExpeditionOrganisation
        '
        Me.lblExpeditionOrganisation.AutoSize = True
        Me.lblExpeditionOrganisation.Location = New System.Drawing.Point(11, 35)
        Me.lblExpeditionOrganisation.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblExpeditionOrganisation.Name = "lblExpeditionOrganisation"
        Me.lblExpeditionOrganisation.Size = New System.Drawing.Size(39, 13)
        Me.lblExpeditionOrganisation.TabIndex = 19
        Me.lblExpeditionOrganisation.Text = "Label1"
        '
        'lblExpeditionCity
        '
        Me.lblExpeditionCity.AutoSize = True
        Me.lblExpeditionCity.Location = New System.Drawing.Point(11, 57)
        Me.lblExpeditionCity.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblExpeditionCity.Name = "lblExpeditionCity"
        Me.lblExpeditionCity.Size = New System.Drawing.Size(39, 13)
        Me.lblExpeditionCity.TabIndex = 21
        Me.lblExpeditionCity.Text = "Label1"
        '
        'cmbBoxExpeditionMembers
        '
        Me.cmbBoxExpeditionMembers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBoxExpeditionMembers.FormattingEnabled = True
        Me.cmbBoxExpeditionMembers.Location = New System.Drawing.Point(112, 96)
        Me.cmbBoxExpeditionMembers.Name = "cmbBoxExpeditionMembers"
        Me.cmbBoxExpeditionMembers.Size = New System.Drawing.Size(547, 21)
        Me.cmbBoxExpeditionMembers.TabIndex = 6
        '
        'btnAddExpeditionMember
        '
        Me.btnAddExpeditionMember.Location = New System.Drawing.Point(660, 96)
        Me.btnAddExpeditionMember.Name = "btnAddExpeditionMember"
        Me.btnAddExpeditionMember.Size = New System.Drawing.Size(57, 21)
        Me.btnAddExpeditionMember.TabIndex = 7
        Me.btnAddExpeditionMember.TabStop = False
        Me.btnAddExpeditionMember.Text = "Button1"
        Me.btnAddExpeditionMember.UseVisualStyleBackColor = True
        '
        'dtaGridExpeditionMembers
        '
        Me.dtaGridExpeditionMembers.AllowUserToAddRows = False
        Me.dtaGridExpeditionMembers.AllowUserToDeleteRows = False
        Me.dtaGridExpeditionMembers.AllowUserToResizeColumns = False
        Me.dtaGridExpeditionMembers.AllowUserToResizeRows = False
        Me.dtaGridExpeditionMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtaGridExpeditionMembers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtaGridExpeditionMembers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtaGridExpeditionMembers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dtaGridExpeditionMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtaGridExpeditionMembers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtaGridExpeditionMembers.Location = New System.Drawing.Point(8, 20)
        Me.dtaGridExpeditionMembers.Margin = New System.Windows.Forms.Padding(2)
        Me.dtaGridExpeditionMembers.MultiSelect = False
        Me.dtaGridExpeditionMembers.Name = "dtaGridExpeditionMembers"
        Me.dtaGridExpeditionMembers.ReadOnly = True
        Me.dtaGridExpeditionMembers.RowHeadersWidth = 62
        Me.dtaGridExpeditionMembers.RowTemplate.Height = 28
        Me.dtaGridExpeditionMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtaGridExpeditionMembers.ShowEditingIcon = False
        Me.dtaGridExpeditionMembers.Size = New System.Drawing.Size(766, 185)
        Me.dtaGridExpeditionMembers.TabIndex = 9
        Me.dtaGridExpeditionMembers.TabStop = False
        '
        'btnRemoveExpeditionMember
        '
        Me.btnRemoveExpeditionMember.Location = New System.Drawing.Point(717, 96)
        Me.btnRemoveExpeditionMember.Name = "btnRemoveExpeditionMember"
        Me.btnRemoveExpeditionMember.Size = New System.Drawing.Size(57, 21)
        Me.btnRemoveExpeditionMember.TabIndex = 8
        Me.btnRemoveExpeditionMember.TabStop = False
        Me.btnRemoveExpeditionMember.Text = "Button1"
        Me.btnRemoveExpeditionMember.UseVisualStyleBackColor = True
        '
        'dateBegin
        '
        Me.dateBegin.Location = New System.Drawing.Point(112, 75)
        Me.dateBegin.Name = "dateBegin"
        Me.dateBegin.Size = New System.Drawing.Size(200, 20)
        Me.dateBegin.TabIndex = 4
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(11, 78)
        Me.lblDate.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(39, 13)
        Me.lblDate.TabIndex = 31
        Me.lblDate.Text = "Label1"
        '
        'dateEnd
        '
        Me.dateEnd.Location = New System.Drawing.Point(313, 75)
        Me.dateEnd.Name = "dateEnd"
        Me.dateEnd.Size = New System.Drawing.Size(200, 20)
        Me.dateEnd.TabIndex = 5
        '
        'lblChangeDate
        '
        Me.lblChangeDate.AutoSize = True
        Me.lblChangeDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChangeDate.Location = New System.Drawing.Point(59, 606)
        Me.lblChangeDate.Name = "lblChangeDate"
        Me.lblChangeDate.Size = New System.Drawing.Size(27, 9)
        Me.lblChangeDate.TabIndex = 61
        Me.lblChangeDate.Text = "Label1"
        '
        'lblChange
        '
        Me.lblChange.AutoSize = True
        Me.lblChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChange.Location = New System.Drawing.Point(12, 605)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(27, 9)
        Me.lblChange.TabIndex = 60
        Me.lblChange.Text = "Label1"
        '
        'lblExpeditionID
        '
        Me.lblExpeditionID.AutoSize = True
        Me.lblExpeditionID.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExpeditionID.Location = New System.Drawing.Point(59, 585)
        Me.lblExpeditionID.Name = "lblExpeditionID"
        Me.lblExpeditionID.Size = New System.Drawing.Size(27, 9)
        Me.lblExpeditionID.TabIndex = 59
        Me.lblExpeditionID.Text = "Label1"
        '
        'lbltxtid
        '
        Me.lbltxtid.AutoSize = True
        Me.lbltxtid.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxtid.Location = New System.Drawing.Point(12, 585)
        Me.lbltxtid.Name = "lbltxtid"
        Me.lbltxtid.Size = New System.Drawing.Size(27, 9)
        Me.lbltxtid.TabIndex = 58
        Me.lbltxtid.Text = "Label1"
        '
        'txtBoxAdditionals
        '
        Me.txtBoxAdditionals.AcceptsReturn = True
        Me.txtBoxAdditionals.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBoxAdditionals.Location = New System.Drawing.Point(13, 328)
        Me.txtBoxAdditionals.Multiline = True
        Me.txtBoxAdditionals.Name = "txtBoxAdditionals"
        Me.txtBoxAdditionals.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBoxAdditionals.Size = New System.Drawing.Size(766, 231)
        Me.txtBoxAdditionals.TabIndex = 10
        '
        'cmbBoxExpeditionName
        '
        Me.cmbBoxExpeditionName.FormattingEnabled = True
        Me.cmbBoxExpeditionName.Location = New System.Drawing.Point(112, 9)
        Me.cmbBoxExpeditionName.MaxLength = 128
        Me.cmbBoxExpeditionName.Name = "cmbBoxExpeditionName"
        Me.cmbBoxExpeditionName.Size = New System.Drawing.Size(677, 21)
        Me.cmbBoxExpeditionName.TabIndex = 1
        '
        'cmbBoxExpeditionOrganisation
        '
        Me.cmbBoxExpeditionOrganisation.FormattingEnabled = True
        Me.cmbBoxExpeditionOrganisation.Location = New System.Drawing.Point(112, 31)
        Me.cmbBoxExpeditionOrganisation.MaxLength = 128
        Me.cmbBoxExpeditionOrganisation.Name = "cmbBoxExpeditionOrganisation"
        Me.cmbBoxExpeditionOrganisation.Size = New System.Drawing.Size(677, 21)
        Me.cmbBoxExpeditionOrganisation.TabIndex = 2
        '
        'cmbBoxExpeditionCity
        '
        Me.cmbBoxExpeditionCity.FormattingEnabled = True
        Me.cmbBoxExpeditionCity.Location = New System.Drawing.Point(112, 53)
        Me.cmbBoxExpeditionCity.MaxLength = 128
        Me.cmbBoxExpeditionCity.Name = "cmbBoxExpeditionCity"
        Me.cmbBoxExpeditionCity.Size = New System.Drawing.Size(677, 21)
        Me.cmbBoxExpeditionCity.TabIndex = 3
        '
        'grpBoxAdditions
        '
        Me.grpBoxAdditions.Location = New System.Drawing.Point(5, 312)
        Me.grpBoxAdditions.Name = "grpBoxAdditions"
        Me.grpBoxAdditions.Size = New System.Drawing.Size(783, 253)
        Me.grpBoxAdditions.TabIndex = 63
        Me.grpBoxAdditions.TabStop = False
        Me.grpBoxAdditions.Text = "GroupBox1"
        '
        'grpBoxExpeditionMembers
        '
        Me.grpBoxExpeditionMembers.Controls.Add(Me.dtaGridExpeditionMembers)
        Me.grpBoxExpeditionMembers.Location = New System.Drawing.Point(5, 102)
        Me.grpBoxExpeditionMembers.Name = "grpBoxExpeditionMembers"
        Me.grpBoxExpeditionMembers.Size = New System.Drawing.Size(784, 210)
        Me.grpBoxExpeditionMembers.TabIndex = 64
        Me.grpBoxExpeditionMembers.TabStop = False
        Me.grpBoxExpeditionMembers.Text = "GroupBox1"
        '
        'cntMouseMenue
        '
        Me.cntMouseMenue.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cntMenuRemove})
        Me.cntMouseMenue.Name = "cntMenu"
        Me.cntMouseMenue.Size = New System.Drawing.Size(126, 26)
        '
        'cntMenuRemove
        '
        Me.cntMenuRemove.Name = "cntMenuRemove"
        Me.cntMenuRemove.Size = New System.Drawing.Size(125, 22)
        Me.cntMenuRemove.Text = "&Entfernen"
        '
        'frmManageExpedition
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(798, 625)
        Me.Controls.Add(Me.cmbBoxExpeditionCity)
        Me.Controls.Add(Me.cmbBoxExpeditionOrganisation)
        Me.Controls.Add(Me.cmbBoxExpeditionName)
        Me.Controls.Add(Me.txtBoxAdditionals)
        Me.Controls.Add(Me.lblChangeDate)
        Me.Controls.Add(Me.lblChange)
        Me.Controls.Add(Me.lblExpeditionID)
        Me.Controls.Add(Me.lbltxtid)
        Me.Controls.Add(Me.dateEnd)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.dateBegin)
        Me.Controls.Add(Me.btnRemoveExpeditionMember)
        Me.Controls.Add(Me.btnAddExpeditionMember)
        Me.Controls.Add(Me.cmbBoxExpeditionMembers)
        Me.Controls.Add(Me.lblExpeditionCity)
        Me.Controls.Add(Me.lblExpeditionOrganisation)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblExpeditionName)
        Me.Controls.Add(Me.grpBoxAdditions)
        Me.Controls.Add(Me.grpBoxExpeditionMembers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmManageExpedition"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmManageExpedition"
        CType(Me.dtaGridExpeditionMembers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBoxExpeditionMembers.ResumeLayout(False)
        Me.cntMouseMenue.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblExpeditionName As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents lblExpeditionOrganisation As Label
    Friend WithEvents lblExpeditionCity As Label
    Friend WithEvents cmbBoxExpeditionMembers As ComboBox
    Friend WithEvents btnAddExpeditionMember As Button
    Friend WithEvents dtaGridExpeditionMembers As DataGridView
    Friend WithEvents btnRemoveExpeditionMember As Button
    Friend WithEvents dateBegin As DateTimePicker
    Friend WithEvents lblDate As Label
    Friend WithEvents dateEnd As DateTimePicker
    Friend WithEvents lblChangeDate As Label
    Friend WithEvents lblChange As Label
    Friend WithEvents lblExpeditionID As Label
    Friend WithEvents lbltxtid As Label
    Friend WithEvents txtBoxAdditionals As TextBox
    Friend WithEvents cmbBoxExpeditionName As ComboBox
    Friend WithEvents cmbBoxExpeditionOrganisation As ComboBox
    Friend WithEvents cmbBoxExpeditionCity As ComboBox
    Friend WithEvents grpBoxAdditions As GroupBox
    Friend WithEvents grpBoxExpeditionMembers As GroupBox
    Friend WithEvents cntMouseMenue As ContextMenuStrip
    Friend WithEvents cntMenuRemove As ToolStripMenuItem
End Class
