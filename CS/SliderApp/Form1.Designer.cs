// Developer Express Code Central Example:
// How to customize TrackBarConrol
// 
// This example demonstrates how to customize TrackBarControl. For more
// information, refer to the http://www.devexpress.com/scid=KA18600 Knowledge Base
// article.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4217

namespace SliderApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.seMin = new DevExpress.XtraEditors.SpinEdit();
            this.seMax = new DevExpress.XtraEditors.SpinEdit();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.cbEnabled = new System.Windows.Forms.CheckBox();
            this.gbTickStyle = new System.Windows.Forms.GroupBox();
            this.rbBoth = new System.Windows.Forms.RadioButton();
            this.rbBottomRight = new System.Windows.Forms.RadioButton();
            this.rbTopLeft = new System.Windows.Forms.RadioButton();
            this.btnSetValue = new System.Windows.Forms.Button();
            this.slider1 = new SliderApp.Slider();
            ((System.ComponentModel.ISupportInitialize)(this.seMin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMax.Properties)).BeginInit();
            this.gbTickStyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // seMin
            // 
            this.seMin.EditValue = new decimal(new int[] {
            22,
            0,
            0,
            -2147483648});
            this.seMin.Location = new System.Drawing.Point(192, 78);
            this.seMin.Name = "seMin";
            this.seMin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seMin.Size = new System.Drawing.Size(75, 20);
            this.seMin.TabIndex = 1;
            this.seMin.EditValueChanged += new System.EventHandler(this.seMin_EditValueChanged);
            // 
            // seMax
            // 
            this.seMax.EditValue = new decimal(new int[] {
            22,
            0,
            0,
            0});
            this.seMax.Location = new System.Drawing.Point(192, 104);
            this.seMax.Name = "seMax";
            this.seMax.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seMax.Size = new System.Drawing.Size(75, 20);
            this.seMax.TabIndex = 2;
            this.seMax.EditValueChanged += new System.EventHandler(this.seMax_EditValueChanged);
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(159, 79);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(24, 13);
            this.lblMin.TabIndex = 0;
            this.lblMin.Text = "Min";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(159, 105);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(27, 13);
            this.lblMax.TabIndex = 6;
            this.lblMax.Text = "Max";
            // 
            // lblValue
            // 
            this.lblValue.Location = new System.Drawing.Point(96, 164);
            this.lblValue.Name = "lblValue";
            this.lblValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblValue.Size = new System.Drawing.Size(174, 13);
            this.lblValue.TabIndex = 7;
            this.lblValue.Text = "Value = 0";
            // 
            // cbEnabled
            // 
            this.cbEnabled.AutoSize = true;
            this.cbEnabled.Checked = true;
            this.cbEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnabled.Location = new System.Drawing.Point(12, 163);
            this.cbEnabled.Name = "cbEnabled";
            this.cbEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbEnabled.TabIndex = 4;
            this.cbEnabled.Text = "Enabled";
            this.cbEnabled.UseVisualStyleBackColor = true;
            this.cbEnabled.CheckedChanged += new System.EventHandler(this.cbEnabled_CheckedChanged);
            // 
            // gbTickStyle
            // 
            this.gbTickStyle.Controls.Add(this.rbBoth);
            this.gbTickStyle.Controls.Add(this.rbBottomRight);
            this.gbTickStyle.Controls.Add(this.rbTopLeft);
            this.gbTickStyle.Location = new System.Drawing.Point(12, 64);
            this.gbTickStyle.Name = "gbTickStyle";
            this.gbTickStyle.Size = new System.Drawing.Size(136, 91);
            this.gbTickStyle.TabIndex = 1;
            this.gbTickStyle.TabStop = false;
            this.gbTickStyle.Text = "TickStyle";
            // 
            // rbBoth
            // 
            this.rbBoth.AutoSize = true;
            this.rbBoth.Location = new System.Drawing.Point(19, 64);
            this.rbBoth.Name = "rbBoth";
            this.rbBoth.Size = new System.Drawing.Size(47, 17);
            this.rbBoth.TabIndex = 2;
            this.rbBoth.Text = "Both";
            this.rbBoth.UseVisualStyleBackColor = true;
            this.rbBoth.CheckedChanged += new System.EventHandler(this.rbBoth_CheckedChanged);
            // 
            // rbBottomRight
            // 
            this.rbBottomRight.AutoSize = true;
            this.rbBottomRight.Checked = true;
            this.rbBottomRight.Location = new System.Drawing.Point(19, 19);
            this.rbBottomRight.Name = "rbBottomRight";
            this.rbBottomRight.Size = new System.Drawing.Size(83, 17);
            this.rbBottomRight.TabIndex = 0;
            this.rbBottomRight.TabStop = true;
            this.rbBottomRight.Text = "BottomRight";
            this.rbBottomRight.UseVisualStyleBackColor = true;
            this.rbBottomRight.CheckedChanged += new System.EventHandler(this.rbBottomRight_CheckedChanged);
            // 
            // rbTopLeft
            // 
            this.rbTopLeft.AutoSize = true;
            this.rbTopLeft.Location = new System.Drawing.Point(19, 41);
            this.rbTopLeft.Name = "rbTopLeft";
            this.rbTopLeft.Size = new System.Drawing.Size(62, 17);
            this.rbTopLeft.TabIndex = 1;
            this.rbTopLeft.Text = "TopLeft";
            this.rbTopLeft.UseVisualStyleBackColor = true;
            this.rbTopLeft.CheckedChanged += new System.EventHandler(this.rbTopLeft_CheckedChanged);
            // 
            // btnSetValue
            // 
            this.btnSetValue.Location = new System.Drawing.Point(192, 132);
            this.btnSetValue.Name = "btnSetValue";
            this.btnSetValue.Size = new System.Drawing.Size(75, 23);
            this.btnSetValue.TabIndex = 3;
            this.btnSetValue.Text = "SetValue";
            this.btnSetValue.UseVisualStyleBackColor = true;
            this.btnSetValue.Click += new System.EventHandler(this.btnSetValue_Click);
            // 
            // slider1
            // 
            this.slider1.Dock = System.Windows.Forms.DockStyle.Top;
            this.slider1.Location = new System.Drawing.Point(0, 0);
            this.slider1.Name = "slider1";
            this.slider1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slider1.Properties.Appearance.Options.UseFont = true;
            this.slider1.Properties.Increment = 2;
            this.slider1.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.slider1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.slider1.Properties.Maximum = 22;
            this.slider1.Properties.Minimum = -22;
            this.slider1.Properties.Range = 44;
            this.slider1.Size = new System.Drawing.Size(278, 45);
            this.slider1.TabIndex = 0;
            this.slider1.ToolTip = "-20";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 196);
            this.Controls.Add(this.btnSetValue);
            this.Controls.Add(this.gbTickStyle);
            this.Controls.Add(this.slider1);
            this.Controls.Add(this.cbEnabled);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.seMax);
            this.Controls.Add(this.seMin);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Slider Demo";
            ((System.ComponentModel.ISupportInitialize)(this.seMin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMax.Properties)).EndInit();
            this.gbTickStyle.ResumeLayout(false);
            this.gbTickStyle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit seMin;
        private DevExpress.XtraEditors.SpinEdit seMax;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.CheckBox cbEnabled;
        private Slider slider1;
        private System.Windows.Forms.GroupBox gbTickStyle;
        private System.Windows.Forms.RadioButton rbBottomRight;
        private System.Windows.Forms.RadioButton rbTopLeft;
        private System.Windows.Forms.RadioButton rbBoth;
        private System.Windows.Forms.Button btnSetValue;





    }
}

