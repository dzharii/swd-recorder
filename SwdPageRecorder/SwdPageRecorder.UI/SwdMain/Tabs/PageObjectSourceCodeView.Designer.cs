namespace SwdPageRecorder.UI
{
    partial class PageObjectSourceCodeView
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
            this.btnGenerateSourceCode = new System.Windows.Forms.Button();
            this.txtSourceCode = new System.Windows.Forms.TextBox();
            this.cbCodeTemplates = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGenerateSourceCode
            // 
            this.btnGenerateSourceCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateSourceCode.Location = new System.Drawing.Point(485, 3);
            this.btnGenerateSourceCode.Name = "btnGenerateSourceCode";
            this.btnGenerateSourceCode.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateSourceCode.TabIndex = 3;
            this.btnGenerateSourceCode.Text = "Generate";
            this.btnGenerateSourceCode.UseVisualStyleBackColor = true;
            this.btnGenerateSourceCode.Click += new System.EventHandler(this.btnGenerateSourceCode_Click);
            // 
            // txtSourceCode
            // 
            this.txtSourceCode.AcceptsReturn = true;
            this.txtSourceCode.AcceptsTab = true;
            this.txtSourceCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceCode.Location = new System.Drawing.Point(3, 31);
            this.txtSourceCode.Multiline = true;
            this.txtSourceCode.Name = "txtSourceCode";
            this.txtSourceCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSourceCode.Size = new System.Drawing.Size(558, 356);
            this.txtSourceCode.TabIndex = 2;
            this.txtSourceCode.WordWrap = false;
            // 
            // cbCodeTemplates
            // 
            this.cbCodeTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCodeTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCodeTemplates.FormattingEnabled = true;
            this.cbCodeTemplates.Location = new System.Drawing.Point(64, 5);
            this.cbCodeTemplates.Name = "cbCodeTemplates";
            this.cbCodeTemplates.Size = new System.Drawing.Size(415, 21);
            this.cbCodeTemplates.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Template:";
            // 
            // PageObjectSourceCodeView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCodeTemplates);
            this.Controls.Add(this.btnGenerateSourceCode);
            this.Controls.Add(this.txtSourceCode);
            this.Name = "PageObjectSourceCodeView";
            this.Size = new System.Drawing.Size(567, 392);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnGenerateSourceCode;
        public System.Windows.Forms.TextBox txtSourceCode;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbCodeTemplates;
    }
}
