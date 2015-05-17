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
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BuilderForm))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdBuild = New System.Windows.Forms.Button
		Me.txtInput = New System.Windows.Forms.TextBox
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Daily Deposit Builder"
		Me.ClientSize = New System.Drawing.Size(419, 443)
		Me.Location = New System.Drawing.Point(3, 23)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "BuilderForm"
		Me.cmdBuild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBuild.Text = "Build Output.gen File"
		Me.cmdBuild.Size = New System.Drawing.Size(123, 39)
		Me.cmdBuild.Location = New System.Drawing.Point(274, 390)
		Me.cmdBuild.TabIndex = 1
		Me.cmdBuild.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdBuild.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBuild.CausesValidation = True
		Me.cmdBuild.Enabled = True
		Me.cmdBuild.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBuild.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBuild.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBuild.TabStop = True
		Me.cmdBuild.Name = "cmdBuild"
		Me.txtInput.AutoSize = False
		Me.txtInput.Size = New System.Drawing.Size(387, 353)
		Me.txtInput.Location = New System.Drawing.Point(12, 14)
		Me.txtInput.MultiLine = True
		Me.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtInput.TabIndex = 0
		Me.txtInput.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtInput.AcceptsReturn = True
		Me.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtInput.BackColor = System.Drawing.SystemColors.Window
		Me.txtInput.CausesValidation = True
		Me.txtInput.Enabled = True
		Me.txtInput.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtInput.HideSelection = True
		Me.txtInput.ReadOnly = False
		Me.txtInput.Maxlength = 0
		Me.txtInput.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtInput.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtInput.TabStop = True
		Me.txtInput.Visible = True
		Me.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtInput.Name = "txtInput"
		Me.Controls.Add(cmdBuild)
		Me.Controls.Add(txtInput)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class