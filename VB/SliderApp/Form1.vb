Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms

Namespace SliderApp
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			AddHandler slider1.EditValueChangedManually, AddressOf slider1_EditValueChangedManually
		End Sub

		Private Sub slider1_EditValueChangedManually(ByVal sender As Object, ByVal e As EventArgs)
			lblValue.Text = String.Format("Value changed manually to {0}", slider1.Value)
		End Sub

		Private Sub seMin_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles seMin.EditValueChanged
			slider1.Properties.Minimum = CInt(Fix(seMin.Value))
		End Sub

		Private Sub seMax_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles seMax.EditValueChanged
			slider1.Properties.Maximum = CInt(Fix(seMax.Value))
		End Sub

		Private Sub cbEnabled_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbEnabled.CheckedChanged
			slider1.Enabled = cbEnabled.Checked
		End Sub

		Private Sub rbBottomRight_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rbBottomRight.CheckedChanged
			slider1.Properties.TickStyle = TickStyle.BottomRight
		End Sub

		Private Sub rbTopLeft_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rbTopLeft.CheckedChanged
			slider1.Properties.TickStyle = TickStyle.TopLeft
		End Sub

		Private Sub rbBoth_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rbBoth.CheckedChanged
			slider1.Properties.TickStyle = TickStyle.Both
		End Sub

		Private Sub btnSetValue_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSetValue.Click
			slider1.SetValue(0)
		End Sub
	End Class
End Namespace
