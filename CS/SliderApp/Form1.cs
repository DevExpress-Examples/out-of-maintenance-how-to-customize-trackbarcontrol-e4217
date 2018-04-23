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
using System.Windows.Forms;

namespace SliderApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            slider1.EditValueChangedManually += new Slider.MyDelegate(slider1_EditValueChangedManually);
        }

        void slider1_EditValueChangedManually(object sender, EventArgs e)
        {
            lblValue.Text = string.Format("Value changed manually to {0}", slider1.Value);
        }

        private void seMin_EditValueChanged(object sender, EventArgs e)
        {
            slider1.Properties.Minimum = (int)seMin.Value;
        }

        private void seMax_EditValueChanged(object sender, EventArgs e)
        {
            slider1.Properties.Maximum = (int)seMax.Value;
        }

        private void cbEnabled_CheckedChanged(object sender, EventArgs e)
        {
            slider1.Enabled = cbEnabled.Checked;
        }

        private void rbBottomRight_CheckedChanged(object sender, EventArgs e)
        {
            slider1.Properties.TickStyle = TickStyle.BottomRight;
        }

        private void rbTopLeft_CheckedChanged(object sender, EventArgs e)
        {
            slider1.Properties.TickStyle = TickStyle.TopLeft;
        }

        private void rbBoth_CheckedChanged(object sender, EventArgs e)
        {
            slider1.Properties.TickStyle = TickStyle.Both;
        }

        private void btnSetValue_Click(object sender, EventArgs e)
        {
            slider1.SetValue(0);
        }
    }
}
