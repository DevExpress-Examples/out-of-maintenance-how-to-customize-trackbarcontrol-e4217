// Developer Express Code Central Example:
// How to customize TrackBarConrol
// 
// This example demonstrates how to customize TrackBarControl. For more
// information, refer to the http://www.devexpress.com/scid=KA18600 Knowledge Base
// article.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4217

using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors.Drawing;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using System.Drawing;
using System.Windows.Forms;

namespace SliderApp
{
    public class SliderPainter : TrackBarPainter
    {
        protected override void DrawContent(ControlGraphicsInfoArgs info)
        {
            SliderViewInfo vi = info.ViewInfo as SliderViewInfo;
            vi.TrackInfo.Bounds = info.Bounds;
            vi.TrackInfo.State = vi.TrackInfo.ViewInfo.State;
            ObjectPainter.DrawObject(info.Cache, vi.SliderPainter, vi.TrackInfo);
        }
        protected override bool IsDrawBorderLast(ControlGraphicsInfoArgs info) { return true; }
    }

    class LabelFormat
    {
        int ContainerWidth = 0;
        public int Count = 0;
        public List<int> Value = new List<int>();
        public List<float> Left = new List<float>();
        public List<float> Width = new List<float>();
        public List<bool> IsPrinting = new List<bool>();
        public float Top = 0;

        public LabelFormat(int containerWidth)
        {
            ContainerWidth = containerWidth;
        }

        public void Add(int value, float left, float top, float width)
        {
            Value.Add(value);
            Left.Add(left);
            Width.Add(width);
            IsPrinting.Add(true);
            Top = top;
            Count++;
        }
        public void Format()
        {
            int Seed = 1;
            bool Ok = false;
            bool Return = false;

            Left[0] = 1;
            Left[Count - 1] = ContainerWidth - Width[Count - 1];

            while (!Ok)
            {
                for (int i = 0; i < Count - 1; i++)
                {
                    if (i % Seed != 0)
                        IsPrinting[i] = false;
                    else
                        IsPrinting[i] = true;
                }
                for (int i = 0; i < Count - 1; i++)
                {
                    if ((i % Seed == 0) && (IsPrinting[i+1]) && (Left[i] + Width[i] > Left[i+1]))
                    {
                        Seed *= 2;
                        Return = true;
                        break;
                    }
                }
                if (!Return) Ok = true;
                else Return = false;
            }
            IsPrinting[0] = true;
            IsPrinting[Count - 1] = true;
        }
        public void Dispose()
        {
            Value.Clear();
            Left.Clear();
            Width.Clear();
            IsPrinting.Clear();
        }
    }


    public class SliderObjectPainter : TrackBarObjectPainter
    {
        public SliderObjectPainter() { }
        protected internal virtual TrackBarInfoCalculator GetCalculator(SliderViewInfo viewInfo) { return new TrackBarInfoCalculator(viewInfo, this); }

        public override void DrawObject(ObjectInfoArgs e)
        {
            TrackBarObjectInfoArgs tbe = e as TrackBarObjectInfoArgs;
            DrawBackground(tbe);
            if (this.AllowTick(tbe.ViewInfo))
                DrawPoints(tbe);
            DrawMarker(tbe);
        }

        public override void DrawPoints(TrackBarObjectInfoArgs e, bool bMirror)
        {
            Point p1 = Point.Empty, p2 = Point.Empty, p3 = Point.Empty, p4 = Point.Empty, p5 = Point.Empty;
            float xPos;
            int tickCount;
            var g = e.Graphics;
            int curValue;

            Font MyFont = ((SliderViewInfo)e.ViewInfo).Item.Appearance.Font;
            SizeF TextSize = new SizeF();
            LabelFormat labelFormat = new LabelFormat(e.ViewInfo.Bounds.Width);

            ((SliderViewInfo)e.ViewInfo).Item.TickFrequency = (int)((double)((SliderViewInfo)e.ViewInfo).Item.Range / (e.ViewInfo.Bounds.Width - 20)) * 5;
           
            p1.Y = e.ViewInfo.PointsRect.Y;
            for (xPos = 0, tickCount = 0; tickCount < e.ViewInfo.TickCount; xPos += e.ViewInfo.PointsDelta, tickCount++)
            {
                p5.X = p4.X = p3.X = p2.X = p1.X = (int)(e.ViewInfo.PointsRect.X + xPos + 0.01f);
                if (tickCount != 0 && tickCount != e.ViewInfo.TickCount - 1)
                {
                    p2.Y = p1.Y + Math.Max(e.ViewInfo.PointsRect.Height * 3 / 4, 1);
                }
                else
                {
                    p4.Y = p2.Y = p1.Y + e.ViewInfo.PointsRect.Height;
                    p3.Y = p1.Y;
                    p3.Y -= 2;
                    p4.Y += 2;

                    switch (e.ViewInfo.TickStyle)
                    {
                        case TickStyle.BottomRight: { p5.Y = 10; break; }
                        case TickStyle.TopLeft: { p5.Y = 20; break; }
                        case TickStyle.Both: { p5.Y = 15; break; }
                    }
                }
                DrawLine(e, e.ViewInfo.TrackBarHelper.RotateAndMirror(p1, e.ViewInfo.MirrorPoint.Y, bMirror), e.ViewInfo.TrackBarHelper.RotateAndMirror(p2, e.ViewInfo.MirrorPoint.Y, bMirror));

                curValue = e.ViewInfo.Item.Minimum + tickCount*((SliderViewInfo)e.ViewInfo).Item.TickFrequency;
                if ((curValue % ((SliderViewInfo)e.ViewInfo).Item.Increment == 0) ||
                    (tickCount == 0 || tickCount == e.ViewInfo.TickCount - 1))
                {
                    DrawLine(e, e.ViewInfo.TrackBarHelper.RotateAndMirror(p3, e.ViewInfo.MirrorPoint.Y, bMirror), e.ViewInfo.TrackBarHelper.RotateAndMirror(p4, e.ViewInfo.MirrorPoint.Y, bMirror));
                    TextSize = g.MeasureString(curValue.ToString(), MyFont);

                    labelFormat.Add(curValue, (int)((e.ViewInfo.PointsRect.X + xPos + 0.01f) - (TextSize.Width / 2)), p5.Y, TextSize.Width);
                }
            }
            labelFormat.Format();

            for (int i = 0; i < labelFormat.Count; i++)
            {
                if (labelFormat.IsPrinting[i])
                    g.DrawString(labelFormat.Value[i].ToString(), MyFont, e.Cache.GetSolidBrush(SystemColors.ControlDarkDark),
                                                                            new PointF(labelFormat.Left[i], labelFormat.Top));
            }
            TextSize = g.MeasureString(((SliderViewInfo)e.ViewInfo).Item.Increment.ToString(), MyFont);
            g.DrawString(((SliderViewInfo)e.ViewInfo).Item.Increment.ToString(), e.Cache.GetFont(MyFont, FontStyle.Regular), e.Cache.GetSolidBrush(SystemColors.ControlDarkDark), new PointF(e.Bounds.Width - TextSize.Width - 1, 0f));
            labelFormat.Dispose();
        }

        public virtual void DrawMarker(TrackBarObjectInfoArgs e)
        {
            Point p1 = Point.Empty, p2 = Point.Empty;
            Pen MarkerPen = new Pen(SystemColors.ActiveBorder, 1);

            p1 = e.ViewInfo.ThumbPos; p2 = e.ViewInfo.ThumbPos;

            switch (e.ViewInfo.Item.TickStyle)
            {
                case TickStyle.BottomRight: { p1.Y += 7; p2.Y += 20; break; }
                case TickStyle.TopLeft: { p1.Y -= 20; p2.Y -= 7; break; }
                case TickStyle.Both: { p1.Y -= 7; p2.Y += 6; break; }
            }

            e.Paint.DrawLine(e.Graphics, MarkerPen, p1, p2);
            e.Graphics.FillEllipse(Brushes.WhiteSmoke, p1.X - 3, p1.Y - 6, 6, 6);
            e.Graphics.DrawEllipse(Pens.Coral, p1.X - 3, p1.Y - 6, 6, 6);
            e.Graphics.FillEllipse(Brushes.WhiteSmoke, p2.X - 3, p2.Y - 0, 6, 6);
            e.Graphics.DrawEllipse(Pens.Coral, p2.X - 3, p2.Y - 0, 6, 6);

            MarkerPen.Dispose();
        }
    }
}
