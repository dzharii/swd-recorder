namespace SwdPageRecorder.UI
{
    partial class PlayGroundView
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnRunScript = new System.Windows.Forms.Button();
            this.groupCode = new System.Windows.Forms.GroupBox();
            this.txtJavaScriptCode = new FastColoredTextBoxNS.FastColoredTextBox();
            this.groupOutput = new System.Windows.Forms.GroupBox();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtJavaScriptCode)).BeginInit();
            this.groupOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnRunScript);
            this.splitContainer1.Panel1.Controls.Add(this.groupCode);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupOutput);
            this.splitContainer1.Size = new System.Drawing.Size(707, 423);
            this.splitContainer1.SplitterDistance = 239;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnRunScript
            // 
            this.btnRunScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRunScript.Location = new System.Drawing.Point(3, 205);
            this.btnRunScript.Name = "btnRunScript";
            this.btnRunScript.Size = new System.Drawing.Size(75, 23);
            this.btnRunScript.TabIndex = 1;
            this.btnRunScript.Text = "Run Script";
            this.btnRunScript.UseVisualStyleBackColor = true;
            this.btnRunScript.Click += new System.EventHandler(this.btnRunScript_Click);
            // 
            // groupCode
            // 
            this.groupCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCode.Controls.Add(this.txtJavaScriptCode);
            this.groupCode.Location = new System.Drawing.Point(0, 0);
            this.groupCode.Name = "groupCode";
            this.groupCode.Size = new System.Drawing.Size(703, 199);
            this.groupCode.TabIndex = 0;
            this.groupCode.TabStop = false;
            this.groupCode.Text = "public class MyPageObject";
            // 
            // txtJavaScriptCode
            // 
            this.txtJavaScriptCode.AllowMacroRecording = false;
            this.txtJavaScriptCode.AutoScrollMinSize = new System.Drawing.Size(27, 12);
            this.txtJavaScriptCode.BackBrush = null;
            this.txtJavaScriptCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJavaScriptCode.CharHeight = 12;
            this.txtJavaScriptCode.CharWidth = 8;
            this.txtJavaScriptCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtJavaScriptCode.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtJavaScriptCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtJavaScriptCode.Font = new System.Drawing.Font("Lucida Console", 9.75F);
            this.txtJavaScriptCode.IsReplaceMode = false;
            this.txtJavaScriptCode.Location = new System.Drawing.Point(3, 16);
            this.txtJavaScriptCode.Name = "txtJavaScriptCode";
            this.txtJavaScriptCode.Paddings = new System.Windows.Forms.Padding(0);
            this.txtJavaScriptCode.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtJavaScriptCode.Size = new System.Drawing.Size(697, 180);
            this.txtJavaScriptCode.TabIndex = 5;
            this.txtJavaScriptCode.WordWrapAutoIndent = false;
            this.txtJavaScriptCode.Zoom = 100;
            // 
            // groupOutput
            // 
            this.groupOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupOutput.Controls.Add(this.txtConsole);
            this.groupOutput.Location = new System.Drawing.Point(0, 30);
            this.groupOutput.Name = "groupOutput";
            this.groupOutput.Size = new System.Drawing.Size(703, 150);
            this.groupOutput.TabIndex = 0;
            this.groupOutput.TabStop = false;
            this.groupOutput.Text = "Output";
            // 
            // txtConsole
            // 
            this.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Location = new System.Drawing.Point(3, 16);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(697, 131);
            this.txtConsole.TabIndex = 0;
            this.txtConsole.Text = "";
            // 
            // PlayGroundView
            // 
            this.Controls.Add(this.splitContainer1);
            this.Name = "PlayGroundView";
            this.Size = new System.Drawing.Size(707, 423);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtJavaScriptCode)).EndInit();
            this.groupOutput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupCode;
        private System.Windows.Forms.GroupBox groupOutput;
        public FastColoredTextBoxNS.FastColoredTextBox txtJavaScriptCode;
        private System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.Button btnRunScript;




    }
}
