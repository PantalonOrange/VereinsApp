<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageCashFlow
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
        Me.cmbBoxCashFlowTarget = New System.Windows.Forms.ComboBox()
        Me.lblCashFlowTarget = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblCashFlowDescription = New System.Windows.Forms.Label()
        Me.cmbBoxCashFlowDescription = New System.Windows.Forms.ComboBox()
        Me.txtBoxCashFlowAmount = New System.Windows.Forms.TextBox()
        Me.lblCashFlowAmount = New System.Windows.Forms.Label()
        Me.lblCashFlowDate = New System.Windows.Forms.Label()
        Me.dateCashFlowDate = New System.Windows.Forms.DateTimePicker()
        Me.lblCashFlowDataDate = New System.Windows.Forms.Label()
        Me.dateCashFlowDataDate = New System.Windows.Forms.DateTimePicker()
        Me.lblChangeDate = New System.Windows.Forms.Label()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.lblCashFlowID = New System.Windows.Forms.Label()
        Me.lbltxtid = New System.Windows.Forms.Label()
        Me.txtBoxAdditionalInformation = New System.Windows.Forms.TextBox()
        Me.grpBoxAdditions = New System.Windows.Forms.GroupBox()
        Me.grpBoxAdditions.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbBoxCashFlowTarget
        '
        Me.cmbBoxCashFlowTarget.FormattingEnabled = True
        Me.cmbBoxCashFlowTarget.Location = New System.Drawing.Point(113, 31)
        Me.cmbBoxCashFlowTarget.MaxLength = 128
        Me.cmbBoxCashFlowTarget.Name = "cmbBoxCashFlowTarget"
        Me.cmbBoxCashFlowTarget.Size = New System.Drawing.Size(676, 21)
        Me.cmbBoxCashFlowTarget.TabIndex = 2
        '
        'lblCashFlowTarget
        '
        Me.lblCashFlowTarget.AutoSize = True
        Me.lblCashFlowTarget.Location = New System.Drawing.Point(12, 34)
        Me.lblCashFlowTarget.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCashFlowTarget.Name = "lblCashFlowTarget"
        Me.lblCashFlowTarget.Size = New System.Drawing.Size(39, 13)
        Me.lblCashFlowTarget.TabIndex = 46
        Me.lblCashFlowTarget.Text = "Label1"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(658, 418)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(131, 44)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Button1"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(465, 418)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(183, 44)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Button1"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblCashFlowDescription
        '
        Me.lblCashFlowDescription.AutoSize = True
        Me.lblCashFlowDescription.Location = New System.Drawing.Point(12, 14)
        Me.lblCashFlowDescription.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCashFlowDescription.Name = "lblCashFlowDescription"
        Me.lblCashFlowDescription.Size = New System.Drawing.Size(39, 13)
        Me.lblCashFlowDescription.TabIndex = 43
        Me.lblCashFlowDescription.Text = "Label1"
        '
        'cmbBoxCashFlowDescription
        '
        Me.cmbBoxCashFlowDescription.FormattingEnabled = True
        Me.cmbBoxCashFlowDescription.Location = New System.Drawing.Point(113, 9)
        Me.cmbBoxCashFlowDescription.MaxLength = 128
        Me.cmbBoxCashFlowDescription.Name = "cmbBoxCashFlowDescription"
        Me.cmbBoxCashFlowDescription.Size = New System.Drawing.Size(676, 21)
        Me.cmbBoxCashFlowDescription.TabIndex = 1
        '
        'txtBoxCashFlowAmount
        '
        Me.txtBoxCashFlowAmount.Location = New System.Drawing.Point(113, 53)
        Me.txtBoxCashFlowAmount.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBoxCashFlowAmount.MaxLength = 20
        Me.txtBoxCashFlowAmount.Name = "txtBoxCashFlowAmount"
        Me.txtBoxCashFlowAmount.Size = New System.Drawing.Size(165, 20)
        Me.txtBoxCashFlowAmount.TabIndex = 3
        Me.txtBoxCashFlowAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCashFlowAmount
        '
        Me.lblCashFlowAmount.AutoSize = True
        Me.lblCashFlowAmount.Location = New System.Drawing.Point(11, 56)
        Me.lblCashFlowAmount.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCashFlowAmount.Name = "lblCashFlowAmount"
        Me.lblCashFlowAmount.Size = New System.Drawing.Size(39, 13)
        Me.lblCashFlowAmount.TabIndex = 49
        Me.lblCashFlowAmount.Text = "Label1"
        '
        'lblCashFlowDate
        '
        Me.lblCashFlowDate.AutoSize = True
        Me.lblCashFlowDate.Location = New System.Drawing.Point(11, 77)
        Me.lblCashFlowDate.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCashFlowDate.Name = "lblCashFlowDate"
        Me.lblCashFlowDate.Size = New System.Drawing.Size(39, 13)
        Me.lblCashFlowDate.TabIndex = 51
        Me.lblCashFlowDate.Text = "Label1"
        '
        'dateCashFlowDate
        '
        Me.dateCashFlowDate.Location = New System.Drawing.Point(113, 74)
        Me.dateCashFlowDate.Name = "dateCashFlowDate"
        Me.dateCashFlowDate.Size = New System.Drawing.Size(200, 20)
        Me.dateCashFlowDate.TabIndex = 4
        '
        'lblCashFlowDataDate
        '
        Me.lblCashFlowDataDate.AutoSize = True
        Me.lblCashFlowDataDate.Location = New System.Drawing.Point(11, 98)
        Me.lblCashFlowDataDate.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCashFlowDataDate.Name = "lblCashFlowDataDate"
        Me.lblCashFlowDataDate.Size = New System.Drawing.Size(39, 13)
        Me.lblCashFlowDataDate.TabIndex = 53
        Me.lblCashFlowDataDate.Text = "Label1"
        '
        'dateCashFlowDataDate
        '
        Me.dateCashFlowDataDate.Enabled = False
        Me.dateCashFlowDataDate.Location = New System.Drawing.Point(113, 95)
        Me.dateCashFlowDataDate.Name = "dateCashFlowDataDate"
        Me.dateCashFlowDataDate.Size = New System.Drawing.Size(200, 20)
        Me.dateCashFlowDataDate.TabIndex = 5
        '
        'lblChangeDate
        '
        Me.lblChangeDate.AutoSize = True
        Me.lblChangeDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChangeDate.Location = New System.Drawing.Point(60, 454)
        Me.lblChangeDate.Name = "lblChangeDate"
        Me.lblChangeDate.Size = New System.Drawing.Size(27, 9)
        Me.lblChangeDate.TabIndex = 57
        Me.lblChangeDate.Text = "Label1"
        '
        'lblChange
        '
        Me.lblChange.AutoSize = True
        Me.lblChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChange.Location = New System.Drawing.Point(13, 453)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(27, 9)
        Me.lblChange.TabIndex = 56
        Me.lblChange.Text = "Label1"
        '
        'lblCashFlowID
        '
        Me.lblCashFlowID.AutoSize = True
        Me.lblCashFlowID.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCashFlowID.Location = New System.Drawing.Point(60, 433)
        Me.lblCashFlowID.Name = "lblCashFlowID"
        Me.lblCashFlowID.Size = New System.Drawing.Size(27, 9)
        Me.lblCashFlowID.TabIndex = 55
        Me.lblCashFlowID.Text = "Label1"
        '
        'lbltxtid
        '
        Me.lbltxtid.AutoSize = True
        Me.lbltxtid.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxtid.Location = New System.Drawing.Point(13, 433)
        Me.lbltxtid.Name = "lbltxtid"
        Me.lbltxtid.Size = New System.Drawing.Size(27, 9)
        Me.lbltxtid.TabIndex = 54
        Me.lbltxtid.Text = "Label1"
        '
        'txtBoxAdditionalInformation
        '
        Me.txtBoxAdditionalInformation.AcceptsReturn = True
        Me.txtBoxAdditionalInformation.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBoxAdditionalInformation.Location = New System.Drawing.Point(6, 15)
        Me.txtBoxAdditionalInformation.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBoxAdditionalInformation.Multiline = True
        Me.txtBoxAdditionalInformation.Name = "txtBoxAdditionalInformation"
        Me.txtBoxAdditionalInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBoxAdditionalInformation.Size = New System.Drawing.Size(773, 269)
        Me.txtBoxAdditionalInformation.TabIndex = 6
        '
        'grpBoxAdditions
        '
        Me.grpBoxAdditions.Controls.Add(Me.txtBoxAdditionalInformation)
        Me.grpBoxAdditions.Location = New System.Drawing.Point(5, 121)
        Me.grpBoxAdditions.Name = "grpBoxAdditions"
        Me.grpBoxAdditions.Size = New System.Drawing.Size(785, 292)
        Me.grpBoxAdditions.TabIndex = 60
        Me.grpBoxAdditions.TabStop = False
        Me.grpBoxAdditions.Text = "GroupBox1"
        '
        'frmManageCashFlow
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(798, 473)
        Me.Controls.Add(Me.lblChangeDate)
        Me.Controls.Add(Me.lblChange)
        Me.Controls.Add(Me.lblCashFlowID)
        Me.Controls.Add(Me.lbltxtid)
        Me.Controls.Add(Me.lblCashFlowDataDate)
        Me.Controls.Add(Me.dateCashFlowDataDate)
        Me.Controls.Add(Me.lblCashFlowDate)
        Me.Controls.Add(Me.dateCashFlowDate)
        Me.Controls.Add(Me.txtBoxCashFlowAmount)
        Me.Controls.Add(Me.lblCashFlowAmount)
        Me.Controls.Add(Me.cmbBoxCashFlowDescription)
        Me.Controls.Add(Me.cmbBoxCashFlowTarget)
        Me.Controls.Add(Me.lblCashFlowTarget)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblCashFlowDescription)
        Me.Controls.Add(Me.grpBoxAdditions)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmManageCashFlow"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmManageCashFlow"
        Me.grpBoxAdditions.ResumeLayout(False)
        Me.grpBoxAdditions.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbBoxCashFlowTarget As ComboBox
    Friend WithEvents lblCashFlowTarget As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents lblCashFlowDescription As Label
    Friend WithEvents cmbBoxCashFlowDescription As ComboBox
    Friend WithEvents txtBoxCashFlowAmount As TextBox
    Friend WithEvents lblCashFlowAmount As Label
    Friend WithEvents lblCashFlowDate As Label
    Friend WithEvents dateCashFlowDate As DateTimePicker
    Friend WithEvents lblCashFlowDataDate As Label
    Friend WithEvents dateCashFlowDataDate As DateTimePicker
    Friend WithEvents lblChangeDate As Label
    Friend WithEvents lblChange As Label
    Friend WithEvents lblCashFlowID As Label
    Friend WithEvents lbltxtid As Label
    Friend WithEvents txtBoxAdditionalInformation As TextBox
    Friend WithEvents grpBoxAdditions As GroupBox
End Class
