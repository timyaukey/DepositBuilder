<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class BuilderForm
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents cmdBuild As System.Windows.Forms.Button
	Public WithEvents txtInput As System.Windows.Forms.TextBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdBuild = New System.Windows.Forms.Button()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdBuild
        '
        Me.cmdBuild.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBuild.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBuild.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBuild.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBuild.Location = New System.Drawing.Point(274, 390)
        Me.cmdBuild.Name = "cmdBuild"
        Me.cmdBuild.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBuild.Size = New System.Drawing.Size(123, 39)
        Me.cmdBuild.TabIndex = 1
        Me.cmdBuild.Text = "Build Output Files"
        Me.cmdBuild.UseVisualStyleBackColor = False
        '
        'txtInput
        '
        Me.txtInput.AcceptsReturn = True
        Me.txtInput.BackColor = System.Drawing.SystemColors.Window
        Me.txtInput.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInput.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInput.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtInput.Location = New System.Drawing.Point(12, 14)
        Me.txtInput.MaxLength = 0
        Me.txtInput.Multiline = True
        Me.txtInput.Name = "txtInput"
        Me.txtInput.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtInput.Size = New System.Drawing.Size(387, 353)
        Me.txtInput.TabIndex = 0
        '
        'BuilderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(419, 443)
        Me.Controls.Add(Me.cmdBuild)
        Me.Controls.Add(Me.txtInput)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BuilderForm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Daily Deposit Builder"
        Me.ResumeLayout(False)

    End Sub
#End Region
End Class