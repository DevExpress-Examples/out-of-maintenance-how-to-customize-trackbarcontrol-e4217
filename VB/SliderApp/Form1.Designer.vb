' Developer Express Code Central Example:
' How to customize TrackBarConrol
' 
' This example demonstrates how to customize TrackBarControl. For more
' information, refer to the http://www.devexpress.com/scid=KA18600 Knowledge Base
' article.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E4217


Imports Microsoft.VisualBasic
Imports System
Namespace SliderApp
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.seMin = New DevExpress.XtraEditors.SpinEdit()
			Me.seMax = New DevExpress.XtraEditors.SpinEdit()
			Me.lblMin = New System.Windows.Forms.Label()
			Me.lblMax = New System.Windows.Forms.Label()
			Me.lblValue = New System.Windows.Forms.Label()
			Me.cbEnabled = New System.Windows.Forms.CheckBox()
			Me.gbTickStyle = New System.Windows.Forms.GroupBox()
			Me.rbBoth = New System.Windows.Forms.RadioButton()
			Me.rbBottomRight = New System.Windows.Forms.RadioButton()
			Me.rbTopLeft = New System.Windows.Forms.RadioButton()
			Me.btnSetValue = New System.Windows.Forms.Button()
			Me.slider1 = New SliderApp.Slider()
			CType(Me.seMin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.seMax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.gbTickStyle.SuspendLayout()
			CType(Me.slider1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.slider1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' seMin
			' 
			Me.seMin.EditValue = New Decimal(New Integer() { 22, 0, 0, -2147483648})
			Me.seMin.Location = New System.Drawing.Point(192, 78)
			Me.seMin.Name = "seMin"
			Me.seMin.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton()})
			Me.seMin.Size = New System.Drawing.Size(75, 20)
			Me.seMin.TabIndex = 1
'			Me.seMin.EditValueChanged += New System.EventHandler(Me.seMin_EditValueChanged);
			' 
			' seMax
			' 
			Me.seMax.EditValue = New Decimal(New Integer() { 22, 0, 0, 0})
			Me.seMax.Location = New System.Drawing.Point(192, 104)
			Me.seMax.Name = "seMax"
			Me.seMax.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton()})
			Me.seMax.Size = New System.Drawing.Size(75, 20)
			Me.seMax.TabIndex = 2
'			Me.seMax.EditValueChanged += New System.EventHandler(Me.seMax_EditValueChanged);
			' 
			' lblMin
			' 
			Me.lblMin.AutoSize = True
			Me.lblMin.Location = New System.Drawing.Point(159, 79)
			Me.lblMin.Name = "lblMin"
			Me.lblMin.Size = New System.Drawing.Size(24, 13)
			Me.lblMin.TabIndex = 0
			Me.lblMin.Text = "Min"
			' 
			' lblMax
			' 
			Me.lblMax.AutoSize = True
			Me.lblMax.Location = New System.Drawing.Point(159, 105)
			Me.lblMax.Name = "lblMax"
			Me.lblMax.Size = New System.Drawing.Size(27, 13)
			Me.lblMax.TabIndex = 6
			Me.lblMax.Text = "Max"
			' 
			' lblValue
			' 
			Me.lblValue.Location = New System.Drawing.Point(96, 164)
			Me.lblValue.Name = "lblValue"
			Me.lblValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes
			Me.lblValue.Size = New System.Drawing.Size(174, 13)
			Me.lblValue.TabIndex = 7
			Me.lblValue.Text = "Value = 0"
			' 
			' cbEnabled
			' 
			Me.cbEnabled.AutoSize = True
			Me.cbEnabled.Checked = True
			Me.cbEnabled.CheckState = System.Windows.Forms.CheckState.Checked
			Me.cbEnabled.Location = New System.Drawing.Point(12, 163)
			Me.cbEnabled.Name = "cbEnabled"
			Me.cbEnabled.Size = New System.Drawing.Size(65, 17)
			Me.cbEnabled.TabIndex = 4
			Me.cbEnabled.Text = "Enabled"
			Me.cbEnabled.UseVisualStyleBackColor = True
'			Me.cbEnabled.CheckedChanged += New System.EventHandler(Me.cbEnabled_CheckedChanged);
			' 
			' gbTickStyle
			' 
			Me.gbTickStyle.Controls.Add(Me.rbBoth)
			Me.gbTickStyle.Controls.Add(Me.rbBottomRight)
			Me.gbTickStyle.Controls.Add(Me.rbTopLeft)
			Me.gbTickStyle.Location = New System.Drawing.Point(12, 64)
			Me.gbTickStyle.Name = "gbTickStyle"
			Me.gbTickStyle.Size = New System.Drawing.Size(136, 91)
			Me.gbTickStyle.TabIndex = 1
			Me.gbTickStyle.TabStop = False
			Me.gbTickStyle.Text = "TickStyle"
			' 
			' rbBoth
			' 
			Me.rbBoth.AutoSize = True
			Me.rbBoth.Location = New System.Drawing.Point(19, 64)
			Me.rbBoth.Name = "rbBoth"
			Me.rbBoth.Size = New System.Drawing.Size(47, 17)
			Me.rbBoth.TabIndex = 2
			Me.rbBoth.Text = "Both"
			Me.rbBoth.UseVisualStyleBackColor = True
'			Me.rbBoth.CheckedChanged += New System.EventHandler(Me.rbBoth_CheckedChanged);
			' 
			' rbBottomRight
			' 
			Me.rbBottomRight.AutoSize = True
			Me.rbBottomRight.Checked = True
			Me.rbBottomRight.Location = New System.Drawing.Point(19, 19)
			Me.rbBottomRight.Name = "rbBottomRight"
			Me.rbBottomRight.Size = New System.Drawing.Size(83, 17)
			Me.rbBottomRight.TabIndex = 0
			Me.rbBottomRight.TabStop = True
			Me.rbBottomRight.Text = "BottomRight"
			Me.rbBottomRight.UseVisualStyleBackColor = True
'			Me.rbBottomRight.CheckedChanged += New System.EventHandler(Me.rbBottomRight_CheckedChanged);
			' 
			' rbTopLeft
			' 
			Me.rbTopLeft.AutoSize = True
			Me.rbTopLeft.Location = New System.Drawing.Point(19, 41)
			Me.rbTopLeft.Name = "rbTopLeft"
			Me.rbTopLeft.Size = New System.Drawing.Size(62, 17)
			Me.rbTopLeft.TabIndex = 1
			Me.rbTopLeft.Text = "TopLeft"
			Me.rbTopLeft.UseVisualStyleBackColor = True
'			Me.rbTopLeft.CheckedChanged += New System.EventHandler(Me.rbTopLeft_CheckedChanged);
			' 
			' btnSetValue
			' 
			Me.btnSetValue.Location = New System.Drawing.Point(192, 132)
			Me.btnSetValue.Name = "btnSetValue"
			Me.btnSetValue.Size = New System.Drawing.Size(75, 23)
			Me.btnSetValue.TabIndex = 3
			Me.btnSetValue.Text = "SetValue"
			Me.btnSetValue.UseVisualStyleBackColor = True
'			Me.btnSetValue.Click += New System.EventHandler(Me.btnSetValue_Click);
			' 
			' slider1
			' 
			Me.slider1.Dock = System.Windows.Forms.DockStyle.Top
			Me.slider1.Location = New System.Drawing.Point(0, 0)
			Me.slider1.Name = "slider1"
			Me.slider1.Properties.Appearance.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.slider1.Properties.Appearance.Options.UseFont = True
			Me.slider1.Properties.Increment = 2
			Me.slider1.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
			Me.slider1.Properties.LookAndFeel.UseDefaultLookAndFeel = False
			Me.slider1.Properties.Maximum = 22
			Me.slider1.Properties.Minimum = -22
			Me.slider1.Properties.Range = 44
			Me.slider1.Size = New System.Drawing.Size(278, 45)
			Me.slider1.TabIndex = 0
			Me.slider1.ToolTip = "-20"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(278, 196)
			Me.Controls.Add(Me.btnSetValue)
			Me.Controls.Add(Me.gbTickStyle)
			Me.Controls.Add(Me.slider1)
			Me.Controls.Add(Me.cbEnabled)
			Me.Controls.Add(Me.lblValue)
			Me.Controls.Add(Me.lblMax)
			Me.Controls.Add(Me.lblMin)
			Me.Controls.Add(Me.seMax)
			Me.Controls.Add(Me.seMin)
			Me.Name = "Form1"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Slider Demo"
			CType(Me.seMin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.seMax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.gbTickStyle.ResumeLayout(False)
			Me.gbTickStyle.PerformLayout()
			CType(Me.slider1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.slider1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents seMin As DevExpress.XtraEditors.SpinEdit
		Private WithEvents seMax As DevExpress.XtraEditors.SpinEdit
		Private lblMin As System.Windows.Forms.Label
		Private lblMax As System.Windows.Forms.Label
		Private lblValue As System.Windows.Forms.Label
		Private WithEvents cbEnabled As System.Windows.Forms.CheckBox
		Private slider1 As Slider
		Private gbTickStyle As System.Windows.Forms.GroupBox
		Private WithEvents rbBottomRight As System.Windows.Forms.RadioButton
		Private WithEvents rbTopLeft As System.Windows.Forms.RadioButton
		Private WithEvents rbBoth As System.Windows.Forms.RadioButton
		Private WithEvents btnSetValue As System.Windows.Forms.Button





	End Class
End Namespace

