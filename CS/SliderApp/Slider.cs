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
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Drawing;
using DevExpress.Utils.Drawing;

namespace SliderApp
{
    [UserRepositoryItem("Register")]
    public class RepositoryItemSlider : RepositoryItemTrackBar
    {
      
        public int Increment { get; set; } 
        public int Range { get; set; } 

        static RepositoryItemSlider() { }
        public RepositoryItemSlider()
        {
            LookAndFeel.UseDefaultLookAndFeel = false;
            LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
        }

        internal const string EditorName = "Slider";

        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(Slider),
                typeof(RepositoryItemSlider), typeof(SliderViewInfo),
                new SliderPainter(), true, null));
        }
        public override string EditorTypeName
        {
            get { return EditorName; }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }

    public class Slider : TrackBarControl
    {
        static Slider()
        {
            RepositoryItemSlider.Register();
        }
        public Slider()
        {
            Properties.Minimum = -22;
            Properties.Maximum = 22;
            Value = 0;
        }
       
        bool FlagIsValueChangedTacitly = false;


        public override string EditorTypeName
        {
            get { return RepositoryItemSlider.EditorName; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemSlider Properties
        {
            get { return base.Properties as RepositoryItemSlider; }
        }

        protected override void  OnPropertiesChanged()
        {
            Properties.Range = Properties.Maximum - Properties.Minimum;

            if (Properties.Range >= 400)
                this.Properties.Increment = 100;
            else
                if (Properties.Range >= 40)
                    this.Properties.Increment = 10;
                else
                    this.Properties.Increment = 2;
            
            base.OnPropertiesChanged();
        }

        protected override void OnPreviewKeyDown(System.Windows.Forms.PreviewKeyDownEventArgs e)
        {
            if ((e.KeyData == System.Windows.Forms.Keys.Up) || (e.KeyData == System.Windows.Forms.Keys.Down)) e.IsInputKey = true;
            base.OnPreviewKeyDown(e);
        }

        protected override void  OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if ((e.KeyData == System.Windows.Forms.Keys.Up) || (e.KeyData == System.Windows.Forms.Keys.Down))
            {
                if (e.KeyData == System.Windows.Forms.Keys.Up)
                {
                    switch (Properties.Increment)
                    {
                        case 2: { Properties.Increment = 10; break; }
                        case 10: { Properties.Increment = 100; break; }
                    }
                }
                if (e.KeyData == System.Windows.Forms.Keys.Down)
                {
                    switch (Properties.Increment)
                    {
                        case 100: { Properties.Increment = 10; break; }
                        case 10: { Properties.Increment = 2; break; }
                    }
                }
                base.OnPropertiesChanged();
            }
            else
                base.OnKeyDown(e);
        }

        protected override void OnMouseHover(EventArgs e)
        {
            int newValue = GetValueUnderPoint(PointToClient(System.Windows.Forms.Cursor.Position).X);

            if (ToolTipController == null) ToolTipController = new DevExpress.Utils.ToolTipController();
            ToolTipController.ShowHint((Math.Round((decimal)newValue / this.Properties.Increment) * this.Properties.Increment).ToString());
            base.OnMouseHover(e);
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            int newValue = GetValueUnderPoint(e.X);
            if (newValue != Value)
                Value = newValue;
            base.OnMouseDown(e);
        }

        private int GetValueUnderPoint(int MouseX)
        {
            int trackBarWidth = Width - 20;
            int hitPointX = MouseX - 10;
            int RealValue = (int)Math.Round((((double)hitPointX / trackBarWidth) * Properties.Range) + Properties.Minimum);
            return RealValue;
        }

        [Description("Changes the value without calling a special event EditValueChangedManually")]
        public void SetValue(int value)
        {
            FlagIsValueChangedTacitly = true;
            Value = value;
        }

        protected override void OnEditValueChanged()
        {
            if (FlagIsValueChangedTacitly)
                FlagIsValueChangedTacitly = false;
            else
                OnEditValueChangedManually(this, EventArgs.Empty);

            base.OnEditValueChanged();
        }

        public delegate void MyDelegate(object sender, EventArgs e);
        [Description("Raised when the Value changes manually")]
        [BrowsableAttribute(true)]
        public event MyDelegate EditValueChangedManually;
        public void OnEditValueChangedManually(object sender, EventArgs e)
        {
            if (EditValueChangedManually != null) EditValueChangedManually(sender, e);
        } 
    }
}
