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
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports System.Drawing
Imports System.Windows.Forms

Namespace SliderApp
	Public Class SliderPainter
		Inherits TrackBarPainter
		Protected Overrides Sub DrawContent(ByVal info As ControlGraphicsInfoArgs)
			Dim vi As SliderViewInfo = TryCast(info.ViewInfo, SliderViewInfo)
			vi.TrackInfo.Bounds = info.Bounds
			vi.TrackInfo.State = vi.TrackInfo.ViewInfo.State
			ObjectPainter.DrawObject(info.Cache, vi.SliderPainter, vi.TrackInfo)
		End Sub
		Protected Overrides Function IsDrawBorderLast(ByVal info As ControlGraphicsInfoArgs) As Boolean
			Return True
		End Function
	End Class

	Friend Class LabelFormat
		Private ContainerWidth As Integer = 0
		Public Count As Integer = 0
		Public Value As New List(Of Integer)()
		Public Left As New List(Of Single)()
		Public Width As New List(Of Single)()
		Public IsPrinting As New List(Of Boolean)()
		Public Top As Single = 0

		Public Sub New(ByVal containerWidth As Integer)
			Me.ContainerWidth = containerWidth
		End Sub

		Public Sub Add(ByVal value As Integer, ByVal left As Single, ByVal top As Single, ByVal width As Single)
			Me.Value.Add(value)
			Me.Left.Add(left)
			Me.Width.Add(width)
			IsPrinting.Add(True)
			Me.Top = top
			Count += 1
		End Sub
		Public Sub Format()
			Dim Seed As Integer = 1
			Dim Ok As Boolean = False
			Dim [Return] As Boolean = False

			Left(0) = 1
			Left(Count - 1) = ContainerWidth - Width(Count - 1)

			Do While Not Ok
				For i As Integer = 0 To Count - 2
					If i Mod Seed <> 0 Then
						IsPrinting(i) = False
					Else
						IsPrinting(i) = True
					End If
				Next i
				For i As Integer = 0 To Count - 2
					If (i Mod Seed = 0) AndAlso (IsPrinting(i+1)) AndAlso (Left(i) + Width(i) > Left(i+1)) Then
						Seed *= 2
						[Return] = True
						Exit For
					End If
				Next i
				If (Not [Return]) Then
					Ok = True
				Else
					[Return] = False
				End If
			Loop
			IsPrinting(0) = True
			IsPrinting(Count - 1) = True
		End Sub
		Public Sub Dispose()
			Value.Clear()
			Left.Clear()
			Width.Clear()
			IsPrinting.Clear()
		End Sub
	End Class


	Public Class SliderObjectPainter
		Inherits TrackBarObjectPainter
		Public Sub New()
		End Sub
		Protected Friend Overridable Function GetCalculator(ByVal viewInfo As SliderViewInfo) As TrackBarInfoCalculator
			Return New TrackBarInfoCalculator(viewInfo, Me)
		End Function

		Public Overrides Sub DrawObject(ByVal e As ObjectInfoArgs)
			Dim tbe As TrackBarObjectInfoArgs = TryCast(e, TrackBarObjectInfoArgs)
			DrawBackground(tbe)
			If Me.AllowTick(tbe.ViewInfo) Then
				DrawPoints(tbe)
			End If
			DrawMarker(tbe)
		End Sub

		Public Overrides Sub DrawPoints(ByVal e As TrackBarObjectInfoArgs, ByVal bMirror As Boolean)
			Dim p1 As Point = Point.Empty, p2 As Point = Point.Empty, p3 As Point = Point.Empty, p4 As Point = Point.Empty, p5 As Point = Point.Empty
			Dim xPos As Single
			Dim tickCount As Integer
			Dim g = e.Graphics
			Dim curValue As Integer

			Dim MyFont As Font = (CType(e.ViewInfo, SliderViewInfo)).Item.Appearance.Font
			Dim TextSize As New SizeF()
			Dim labelFormat As New LabelFormat(e.ViewInfo.Bounds.Width)

			CType(e.ViewInfo, SliderViewInfo).Item.TickFrequency = CInt(Fix(CDbl((CType(e.ViewInfo, SliderViewInfo)).Item.Range) / (e.ViewInfo.Bounds.Width - 20))) * 5

			p1.Y = e.ViewInfo.PointsRect.Y
			xPos = 0
			tickCount = 0
			Do While tickCount < e.ViewInfo.TickCount
				p1.X = CInt(Fix(e.ViewInfo.PointsRect.X + xPos + 0.01f))
				p2.X = p1.X
				p3.X = p2.X
				p4.X = p3.X
				p5.X = p4.X
				If tickCount <> 0 AndAlso tickCount <> e.ViewInfo.TickCount - 1 Then
					p2.Y = p1.Y + Math.Max(e.ViewInfo.PointsRect.Height * 3 \ 4, 1)
				Else
					p2.Y = p1.Y + e.ViewInfo.PointsRect.Height
					p4.Y = p2.Y
					p3.Y = p1.Y
					p3.Y -= 2
					p4.Y += 2

					Select Case e.ViewInfo.TickStyle
						Case TickStyle.BottomRight
							p5.Y = 10
							Exit Select
						Case TickStyle.TopLeft
							p5.Y = 20
							Exit Select
						Case TickStyle.Both
							p5.Y = 15
							Exit Select
					End Select
				End If
				DrawLine(e, e.ViewInfo.TrackBarHelper.RotateAndMirror(p1, e.ViewInfo.MirrorPoint.Y, bMirror), e.ViewInfo.TrackBarHelper.RotateAndMirror(p2, e.ViewInfo.MirrorPoint.Y, bMirror))

				curValue = e.ViewInfo.Item.Minimum + tickCount*(CType(e.ViewInfo, SliderViewInfo)).Item.TickFrequency
				If (curValue Mod (CType(e.ViewInfo, SliderViewInfo)).Item.Increment = 0) OrElse (tickCount = 0 OrElse tickCount = e.ViewInfo.TickCount - 1) Then
					DrawLine(e, e.ViewInfo.TrackBarHelper.RotateAndMirror(p3, e.ViewInfo.MirrorPoint.Y, bMirror), e.ViewInfo.TrackBarHelper.RotateAndMirror(p4, e.ViewInfo.MirrorPoint.Y, bMirror))
					TextSize = g.MeasureString(curValue.ToString(), MyFont)

					labelFormat.Add(curValue, CInt(Fix((e.ViewInfo.PointsRect.X + xPos + 0.01f) - (TextSize.Width / 2))), p5.Y, TextSize.Width)
				End If
				xPos += e.ViewInfo.PointsDelta
				tickCount += 1
			Loop
			labelFormat.Format()

			For i As Integer = 0 To labelFormat.Count - 1
				If labelFormat.IsPrinting(i) Then
					g.DrawString(labelFormat.Value(i).ToString(), MyFont, e.Cache.GetSolidBrush(SystemColors.ControlDarkDark), New PointF(labelFormat.Left(i), labelFormat.Top))
				End If
			Next i
			TextSize = g.MeasureString((CType(e.ViewInfo, SliderViewInfo)).Item.Increment.ToString(), MyFont)
			g.DrawString((CType(e.ViewInfo, SliderViewInfo)).Item.Increment.ToString(), e.Cache.GetFont(MyFont, FontStyle.Regular), e.Cache.GetSolidBrush(SystemColors.ControlDarkDark), New PointF(e.Bounds.Width - TextSize.Width - 1, 0f))
			labelFormat.Dispose()
		End Sub

		Public Overridable Sub DrawMarker(ByVal e As TrackBarObjectInfoArgs)
			Dim p1 As Point = Point.Empty, p2 As Point = Point.Empty
			Dim MarkerPen As New Pen(SystemColors.ActiveBorder, 1)

			p1 = e.ViewInfo.ThumbPos
			p2 = e.ViewInfo.ThumbPos

			Select Case e.ViewInfo.Item.TickStyle
				Case TickStyle.BottomRight
					p1.Y += 7
					p2.Y += 20
					Exit Select
				Case TickStyle.TopLeft
					p1.Y -= 20
					p2.Y -= 7
					Exit Select
				Case TickStyle.Both
					p1.Y -= 7
					p2.Y += 6
					Exit Select
			End Select

			e.Paint.DrawLine(e.Graphics, MarkerPen, p1, p2)
			e.Graphics.FillEllipse(Brushes.WhiteSmoke, p1.X - 3, p1.Y - 6, 6, 6)
			e.Graphics.DrawEllipse(Pens.Coral, p1.X - 3, p1.Y - 6, 6, 6)
			e.Graphics.FillEllipse(Brushes.WhiteSmoke, p2.X - 3, p2.Y - 0, 6, 6)
			e.Graphics.DrawEllipse(Pens.Coral, p2.X - 3, p2.Y - 0, 6, 6)

			MarkerPen.Dispose()
		End Sub
	End Class
End Namespace
