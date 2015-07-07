using Cyotek.Windows.Forms;
namespace SwdPageRecorder.UI.SwdMain.Popups
{
    partial class BrowserScreenView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserScreenView));
            this.imgBox = new Cyotek.Windows.Forms.ImageBox();
            this.grpWebPage = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.webDriverBrowserComponentView1 = new SwdPageRecorder.UI.SwdMain.Popups.Components.WebDriver.WebDriverBrowserComponentView();
            this.grpWebPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgBox
            // 
            this.imgBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.imgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgBox.GridDisplayMode = Cyotek.Windows.Forms.ImageBoxGridDisplayMode.Image;
            this.imgBox.ImageBorderStyle = Cyotek.Windows.Forms.ImageBoxBorderStyle.FixedSingleGlowShadow;
            this.imgBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.imgBox.Location = new System.Drawing.Point(3, 16);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(750, 520);
            this.imgBox.TabIndex = 0;
            this.imgBox.TextBackColor = System.Drawing.Color.White;
            this.imgBox.Zoom = 1600;
            this.imgBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.imgBox_MouseWheel);
            this.imgBox.Click += new System.EventHandler(this.imgBox_Click);
            this.imgBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.imgBox_KeyPress);
            this.imgBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imgBox_MouseClick);
            this.imgBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgBox_MouseDown);
            this.imgBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgBox_MouseMove);
            this.imgBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgBox_MouseUp);
            // 
            // grpWebPage
            // 
            this.grpWebPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpWebPage.Controls.Add(this.imgBox);
            this.grpWebPage.Location = new System.Drawing.Point(12, 63);
            this.grpWebPage.Name = "grpWebPage";
            this.grpWebPage.Size = new System.Drawing.Size(756, 539);
            this.grpWebPage.TabIndex = 1;
            this.grpWebPage.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(878, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Take Screenshot";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(878, 172);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(205, 100);
            this.txtLog.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(878, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(12, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1152, 35);
            this.panel1.TabIndex = 5;
            // 
            // button5
            // 
            this.button5.Image = global::SwdPageRecorder.UI.Properties.Resources.reload_2x;
            this.button5.Location = new System.Drawing.Point(65, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(29, 29);
            this.button5.TabIndex = 3;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Image = global::SwdPageRecorder.UI.Properties.Resources.arrow_right_2x;
            this.button4.Location = new System.Drawing.Point(34, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(29, 29);
            this.button4.TabIndex = 2;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Image = global::SwdPageRecorder.UI.Properties.Resources.arrow_left_2x;
            this.button3.Location = new System.Drawing.Point(3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(29, 29);
            this.button3.TabIndex = 1;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(356, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(790, 20);
            this.textBox1.TabIndex = 0;
            // 
            // webDriverBrowserComponentView1
            // 
            this.webDriverBrowserComponentView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.webDriverBrowserComponentView1.Location = new System.Drawing.Point(890, 307);
            this.webDriverBrowserComponentView1.Name = "webDriverBrowserComponentView1";
            this.webDriverBrowserComponentView1.Size = new System.Drawing.Size(193, 208);
            this.webDriverBrowserComponentView1.TabIndex = 6;
            // 
            // BrowserScreenView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 614);
            this.Controls.Add(this.webDriverBrowserComponentView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grpWebPage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BrowserScreenView";
            this.Text = "BrowserScreenView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BrowserScreenView_FormClosing);
            this.grpWebPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ImageBox imgBox;
        private System.Windows.Forms.GroupBox grpWebPage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button5;
        private Components.WebDriver.WebDriverBrowserComponentView webDriverBrowserComponentView1;
    }
}