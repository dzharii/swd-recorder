namespace SwdPageRecorder.UI.SwdMain.Tabs
{
    partial class BrowserScreenButtonView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imgBox = new Cyotek.Windows.Forms.ImageBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenBrowserScreen = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgBox
            // 
            this.imgBox.AllowZoom = false;
            this.imgBox.AutoPan = false;
            this.imgBox.AutoScroll = false;
            this.imgBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.imgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgBox.GridDisplayMode = Cyotek.Windows.Forms.ImageBoxGridDisplayMode.Image;
            this.imgBox.ImageBorderStyle = Cyotek.Windows.Forms.ImageBoxBorderStyle.FixedSingleGlowShadow;
            this.imgBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.imgBox.Location = new System.Drawing.Point(3, 16);
            this.imgBox.Name = "imgBox";
            this.imgBox.ShortcutsEnabled = false;
            this.imgBox.Size = new System.Drawing.Size(200, 163);
            this.imgBox.SizeMode = Cyotek.Windows.Forms.ImageBoxSizeMode.Stretch;
            this.imgBox.TabIndex = 1;
            this.imgBox.TextBackColor = System.Drawing.Color.White;
            this.imgBox.DoubleClick += new System.EventHandler(this.imgBox_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenBrowserScreen);
            this.groupBox1.Controls.Add(this.imgBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 182);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Browser View";
            // 
            // btnOpenBrowserScreen
            // 
            this.btnOpenBrowserScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenBrowserScreen.Image = global::SwdPageRecorder.UI.Properties.Resources.resize_both_4x;
            this.btnOpenBrowserScreen.Location = new System.Drawing.Point(159, 19);
            this.btnOpenBrowserScreen.Name = "btnOpenBrowserScreen";
            this.btnOpenBrowserScreen.Size = new System.Drawing.Size(40, 40);
            this.btnOpenBrowserScreen.TabIndex = 2;
            this.btnOpenBrowserScreen.UseVisualStyleBackColor = true;
            this.btnOpenBrowserScreen.Click += new System.EventHandler(this.btnOpenBrowserScreen_Click);
            // 
            // BrowserScreenButtonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "BrowserScreenButtonView";
            this.Size = new System.Drawing.Size(206, 182);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Cyotek.Windows.Forms.ImageBox imgBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenBrowserScreen;
    }
}
