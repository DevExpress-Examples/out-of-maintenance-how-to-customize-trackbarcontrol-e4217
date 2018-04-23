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
Imports DevExpress.XtraEditors.ViewInfo
Imports System.Windows.Forms
Imports System.Drawing
Imports DevExpress.XtraEditors.Repository
Imports System.Collections.Generic
Imports System

Namespace SliderApp
	Public Class SliderViewInfo
		Inherits TrackBarViewInfo
		Private thumbPos As Point
		Private trackLineRect As Rectangle
		Private pointsRect As Rectangle

		Public Sub New(ByVal item As RepositoryItem)
			MyBase.New(item)
			Me.trackLineRect = Rectangle.Empty
			Me.pointsRect = Rectangle.Empty
			Me.thumbPos = Point.Empty
		End Sub

		Public ReadOnly Property SliderPainter() As SliderObjectPainter
			Get
				Return GetSliderPainter()
			End Get
		End Property
		  Public Shadows ReadOnly Property Item() As RepositoryItemSlider
			  Get
				  Return TryCast(MyBase.Item, RepositoryItemSlider)
			  End Get
		  End Property
		  Public Shadows ReadOnly Property Orientation() As Orientation
			  Get
				  Return Orientation.Horizontal
			  End Get
		  End Property


		  Public Overridable Function GetSliderPainter() As SliderObjectPainter
			Return New SliderObjectPainter()
		  End Function

		Public Overrides ReadOnly Property RectThumbRegion() As Point()
			Get
				Dim pt As SliderObjectPainter = SliderPainter
				Dim offsetP1(,) As Integer = { { -pt.GetThumbBestWidth(Me) / 2, 11 }, { -pt.GetThumbBestWidth(Me) / 2, -11 }, { pt.GetThumbBestWidth(Me) / 2, -11 }, { pt.GetThumbBestWidth(Me) / 2, 11 }, { -pt.GetThumbBestWidth(Me) / 2, 11 } }
				Dim polygon(4) As Point
				TransformPoints(offsetP1, polygon, ThumbPos)

				Dim y1 As Integer = 0
				Dim y2 As Integer = 0
				Select Case TickStyle
					Case TickStyle.BottomRight
						y1 = 18
						y2 = 43
						Exit Select
					Case TickStyle.TopLeft
						y1 = 28
						y2 = 3
						Exit Select
					Case TickStyle.Both
						y1 = 35
						y2 = 10
						Exit Select
				End Select
				polygon(0).Y = y1
				polygon(1).Y = y2
				polygon(2).Y = y2
				polygon(3).Y = y1
				polygon(4).Y = y1
				Return polygon
			End Get
		End Property
	End Class
End Namespace

