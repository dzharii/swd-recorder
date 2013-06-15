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
            this.SuspendLayout();
            // 
            // btnGenerateSourceCode
            // 
            this.btnGenerateSourceCode.Location = new System.Drawing.Point(486, 2);
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
            this.txtSourceCode.Location = new System.Drawing.Point(3, 25);
            this.txtSourceCode.Multiline = true;
            this.txtSourceCode.Name = "txtSourceCode";
            this.txtSourceCode.Size = new System.Drawing.Size(558, 362);
            this.txtSourceCode.TabIndex = 2;
            // 
            // PageObjectSourceCodeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
    }
}
