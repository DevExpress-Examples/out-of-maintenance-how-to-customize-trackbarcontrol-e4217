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
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Linq
Imports System.ComponentModel
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.Utils.Drawing

Namespace SliderApp
	<UserRepositoryItem("Register")> _
	Public Class RepositoryItemSlider
		Inherits RepositoryItemTrackBar

		Public Property Increment() As Integer
		Public Property Range() As Integer

		Shared Sub New()
		End Sub
		Public Sub New()
			LookAndFeel.UseDefaultLookAndFeel = False
			LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
		End Sub

		Friend Const EditorName As String = "Slider"

		Public Shared Sub Register()
            EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(EditorName, GetType(Slider), GetType(RepositoryItemSlider), GetType(SliderViewInfo), New SliderPainter(), True))
		End Sub
		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return EditorName
			End Get
		End Property

		Private Sub InitializeComponent()
			CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
		End Sub
	End Class

	Public Class Slider
		Inherits TrackBarControl
		Shared Sub New()
			RepositoryItemSlider.Register()
		End Sub
		Public Sub New()
			Properties.Minimum = -22
			Properties.Maximum = 22
			Value = 0
		End Sub

		Private FlagIsValueChangedTacitly As Boolean = False


		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemSlider.EditorName
			End Get
		End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As RepositoryItemSlider
			Get
				Return TryCast(MyBase.Properties, RepositoryItemSlider)
			End Get
		End Property

		Protected Overrides Sub OnPropertiesChanged()
			Properties.Range = Properties.Maximum - Properties.Minimum

			If Properties.Range >= 400 Then
				Me.Properties.Increment = 100
			Else
				If Properties.Range >= 40 Then
					Me.Properties.Increment = 10
				Else
					Me.Properties.Increment = 2
				End If
			End If

			MyBase.OnPropertiesChanged()
		End Sub

		Protected Overrides Sub OnPreviewKeyDown(ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)
			If (e.KeyData = System.Windows.Forms.Keys.Up) OrElse (e.KeyData = System.Windows.Forms.Keys.Down) Then
				e.IsInputKey = True
			End If
			MyBase.OnPreviewKeyDown(e)
		End Sub

		Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
			If (e.KeyData = System.Windows.Forms.Keys.Up) OrElse (e.KeyData = System.Windows.Forms.Keys.Down) Then
				If e.KeyData = System.Windows.Forms.Keys.Up Then
					Select Case Properties.Increment
						Case 2
							Properties.Increment = 10
							Exit Select
						Case 10
							Properties.Increment = 100
							Exit Select
					End Select
				End If
				If e.KeyData = System.Windows.Forms.Keys.Down Then
					Select Case Properties.Increment
						Case 100
							Properties.Increment = 10
							Exit Select
						Case 10
							Properties.Increment = 2
							Exit Select
					End Select
				End If
				MyBase.OnPropertiesChanged()
			Else
				MyBase.OnKeyDown(e)
			End If
		End Sub

		Protected Overrides Sub OnMouseHover(ByVal e As EventArgs)
			Dim newValue As Integer = GetValueUnderPoint(PointToClient(System.Windows.Forms.Cursor.Position).X)

			If ToolTipController Is Nothing Then
				ToolTipController = New DevExpress.Utils.ToolTipController()
			End If
			ToolTipController.ShowHint((Math.Round(CDec(newValue) / Me.Properties.Increment) * Me.Properties.Increment).ToString())
			MyBase.OnMouseHover(e)
		End Sub

		Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
			Dim newValue As Integer = GetValueUnderPoint(e.X)
			If newValue <> Value Then
				Value = newValue
			End If
			MyBase.OnMouseDown(e)
		End Sub

		Private Function GetValueUnderPoint(ByVal MouseX As Integer) As Integer
			Dim trackBarWidth As Integer = Width - 20
			Dim hitPointX As Integer = MouseX - 10
			Dim RealValue As Integer = CInt(Fix(Math.Round(((CDbl(hitPointX) / trackBarWidth) * Properties.Range) + Properties.Minimum)))
			Return RealValue
		End Function

		<Description("Changes the value without calling a special event EditValueChangedManually")> _
		Public Sub SetValue(ByVal value As Integer)
			FlagIsValueChangedTacitly = True
			Value = value
		End Sub

		Protected Overrides Sub OnEditValueChanged()
			If FlagIsValueChangedTacitly Then
				FlagIsValueChangedTacitly = False
			Else
				OnEditValueChangedManually(Me, EventArgs.Empty)
			End If

			MyBase.OnEditValueChanged()
		End Sub

		Public Delegate Sub MyDelegate(ByVal sender As Object, ByVal e As EventArgs)
		<Description("Raised when the Value changes manually"), BrowsableAttribute(True)> _
		Public Event EditValueChangedManually As MyDelegate
		Public Sub OnEditValueChangedManually(ByVal sender As Object, ByVal e As EventArgs)
			RaiseEvent EditValueChangedManually(sender, e)
		End Sub
	End Class
End Namespace
