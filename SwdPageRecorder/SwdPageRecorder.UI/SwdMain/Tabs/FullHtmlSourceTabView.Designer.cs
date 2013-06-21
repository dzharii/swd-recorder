namespace SwdPageRecorder.UI
{
    partial class FullHtmlSourceTabView
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
            this.txtHtmlPageSource = new System.Windows.Forms.TextBox();
            this.btnGetHtmlSource = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtHtmlPageSource
            // 
            this.txtHtmlPageSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHtmlPageSource.Location = new System.Drawing.Point(3, 31);
            this.txtHtmlPageSource.Multiline = true;
            this.txtHtmlPageSource.Name = "txtHtmlPageSource";
            this.txtHtmlPageSource.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHtmlPageSource.Size = new System.Drawing.Size(548, 356);
            this.txtHtmlPageSource.TabIndex = 3;
            this.txtHtmlPageSource.WordWrap = false;
            // 
            // btnGetHtmlSource
            // 
            this.btnGetHtmlSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetHtmlSource.Location = new System.Drawing.Point(476, 2);
            this.btnGetHtmlSource.Name = "btnGetHtmlSource";
            this.btnGetHtmlSource.Size = new System.Drawing.Size(75, 23);
            this.btnGetHtmlSource.TabIndex = 2;
            this.btnGetHtmlSource.Text = "Get HTML";
            this.btnGetHtmlSource.UseVisualStyleBackColor = true;
            this.btnGetHtmlSource.Click += new System.EventHandler(this.btnGetHtmlSource_Click);
            // 
            // FullHtmlSourceTabView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtHtmlPageSource);
            this.Controls.Add(this.btnGetHtmlSource);
            this.Name = "FullHtmlSourceTabView";
            this.Size = new System.Drawing.Size(552, 389);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtHtmlPageSource;
        public System.Windows.Forms.Button btnGetHtmlSource;
    }
}
