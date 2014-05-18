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
            this.components = new System.ComponentModel.Container();
            this.txtHtmlPageSource = new FastColoredTextBoxNS.FastColoredTextBox();
            this.btnGetHtmlSource = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtHtmlPageSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHtmlPageSource
            // 
            this.txtHtmlPageSource.AllowMacroRecording = false;
            this.txtHtmlPageSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHtmlPageSource.AutoScrollMinSize = new System.Drawing.Size(0, 12);
            this.txtHtmlPageSource.BackBrush = null;
            this.txtHtmlPageSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHtmlPageSource.CharHeight = 12;
            this.txtHtmlPageSource.CharWidth = 8;
            this.txtHtmlPageSource.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHtmlPageSource.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtHtmlPageSource.Font = new System.Drawing.Font("Lucida Console", 9.75F);
            this.txtHtmlPageSource.IsReplaceMode = false;
            this.txtHtmlPageSource.Location = new System.Drawing.Point(3, 31);
            this.txtHtmlPageSource.Name = "txtHtmlPageSource";
            this.txtHtmlPageSource.Paddings = new System.Windows.Forms.Padding(0);
            this.txtHtmlPageSource.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtHtmlPageSource.Size = new System.Drawing.Size(548, 356);
            this.txtHtmlPageSource.TabIndex = 3;
            this.txtHtmlPageSource.WordWrap = true;
            this.txtHtmlPageSource.WordWrapAutoIndent = false;
            this.txtHtmlPageSource.Zoom = 100;
            this.txtHtmlPageSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHtmlPageSource_KeyDown);
            // 
            // btnGetHtmlSource
            // 
            this.btnGetHtmlSource.Location = new System.Drawing.Point(22, 3);
            this.btnGetHtmlSource.Name = "btnGetHtmlSource";
            this.btnGetHtmlSource.Size = new System.Drawing.Size(107, 23);
            this.btnGetHtmlSource.TabIndex = 2;
            this.btnGetHtmlSource.Text = "Get HTML";
            this.btnGetHtmlSource.UseVisualStyleBackColor = true;
            this.btnGetHtmlSource.Click += new System.EventHandler(this.btnGetHtmlSource_Click);
            // 
            // FullHtmlSourceTabView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.txtHtmlPageSource);
            this.Controls.Add(this.btnGetHtmlSource);
            this.Name = "FullHtmlSourceTabView";
            this.Size = new System.Drawing.Size(552, 389);
            ((System.ComponentModel.ISupportInitialize)(this.txtHtmlPageSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public FastColoredTextBoxNS.FastColoredTextBox txtHtmlPageSource;
        public System.Windows.Forms.Button btnGetHtmlSource;
    }
}
