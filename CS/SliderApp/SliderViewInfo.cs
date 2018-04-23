using DevExpress.XtraEditors.ViewInfo;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors.Repository;
using System.Collections.Generic;
using System;

namespace SliderApp 
{
    public class SliderViewInfo : TrackBarViewInfo
    {
        Point thumbPos;
        Rectangle trackLineRect;
        Rectangle pointsRect;

        public SliderViewInfo(RepositoryItem item)
            : base(item)
        {
            this.trackLineRect = Rectangle.Empty;
            this.pointsRect = Rectangle.Empty;
            this.thumbPos = Point.Empty;
        }

          public SliderObjectPainter TrackPainter { get { return GetTrackPainter(); } }
          public new RepositoryItemSlider Item { get { return base.Item as RepositoryItemSlider; } }
          public Orientation Orientation { get { return Orientation.Horizontal; } }


        public virtual SliderObjectPainter GetTrackPainter()
        {
            return new SliderObjectPainter();
        }

        public override Point[] RectThumbRegion
        {
            get
            {
                SliderObjectPainter pt = TrackPainter;
                int[,] offsetP1 = { { -pt.GetThumbBestWidth(this) / 2, 11 }, { -pt.GetThumbBestWidth(this) / 2, -11 }, { pt.GetThumbBestWidth(this) / 2, -11 }, { pt.GetThumbBestWidth(this) / 2, 11 }, { -pt.GetThumbBestWidth(this) / 2, 11 } };
                Point[] polygon = new Point[5];
                TransformPoints(offsetP1, polygon, ThumbPos);

                int y1 = 0;
                int y2 = 0;
                switch (TickStyle)
                {
                    case TickStyle.BottomRight: { y1 = 18; y2 = 43; break; }
                    case TickStyle.TopLeft: { y1 = 28; y2 = 3; break; }
                    case TickStyle.Both: { y1 = 35; y2 = 10; break; }
                }
                polygon[0].Y = y1;
                polygon[1].Y = y2;
                polygon[2].Y = y2;
                polygon[3].Y = y1;
                polygon[4].Y = y1;
                return polygon;
            }
        }
    }
}

