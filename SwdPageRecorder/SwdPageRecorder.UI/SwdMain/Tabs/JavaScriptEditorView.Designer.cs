namespace SwdPageRecorder.UI
{
    partial class JavaScriptEditorView
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
            this.tvJavaScriptFiels = new System.Windows.Forms.TreeView();
            this.groupCode = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.txtJavaScriptEditor = new FastColoredTextBoxNS.FastColoredTextBox();
            this.groupConsoleOutput = new System.Windows.Forms.GroupBox();
            this.txtOutputConsole = new System.Windows.Forms.RichTextBox();
            this.groupJsFilesTree = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnShowFiles = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtJavaScriptEditor)).BeginInit();
            this.groupConsoleOutput.SuspendLayout();
            this.groupJsFilesTree.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvJavaScriptFiels
            // 
            this.tvJavaScriptFiels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvJavaScriptFiels.Location = new System.Drawing.Point(3, 48);
            this.tvJavaScriptFiels.Name = "tvJavaScriptFiels";
            this.tvJavaScriptFiels.Size = new System.Drawing.Size(156, 410);
            this.tvJavaScriptFiels.TabIndex = 0;
            this.tvJavaScriptFiels.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvJavaScriptFiels_NodeMouseDoubleClick);
            // 
            // groupCode
            // 
            this.groupCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCode.Controls.Add(this.btnSave);
            this.groupCode.Controls.Add(this.btnRun);
            this.groupCode.Controls.Add(this.txtJavaScriptEditor);
            this.groupCode.Location = new System.Drawing.Point(168, 3);
            this.groupCode.Name = "groupCode";
            this.groupCode.Size = new System.Drawing.Size(652, 274);
            this.groupCode.TabIndex = 1;
            this.groupCode.TabStop = false;
            this.groupCode.Text = "Code";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(87, 245);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRun.Location = new System.Drawing.Point(6, 245);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 5;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtJavaScriptEditor
            // 
            this.txtJavaScriptEditor.AllowMacroRecording = false;
            this.txtJavaScriptEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJavaScriptEditor.AutoScrollMinSize = new System.Drawing.Size(27, 12);
            this.txtJavaScriptEditor.BackBrush = null;
            this.txtJavaScriptEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJavaScriptEditor.CharHeight = 12;
            this.txtJavaScriptEditor.CharWidth = 8;
            this.txtJavaScriptEditor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtJavaScriptEditor.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtJavaScriptEditor.Font = new System.Drawing.Font("Lucida Console", 9.75F);
            this.txtJavaScriptEditor.IsReplaceMode = false;
            this.txtJavaScriptEditor.Location = new System.Drawing.Point(6, 19);
            this.txtJavaScriptEditor.Name = "txtJavaScriptEditor";
            this.txtJavaScriptEditor.Paddings = new System.Windows.Forms.Padding(0);
            this.txtJavaScriptEditor.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtJavaScriptEditor.Size = new System.Drawing.Size(640, 220);
            this.txtJavaScriptEditor.TabIndex = 4;
            this.txtJavaScriptEditor.WordWrapAutoIndent = false;
            this.txtJavaScriptEditor.Zoom = 100;
            // 
            // groupConsoleOutput
            // 
            this.groupConsoleOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupConsoleOutput.Controls.Add(this.txtOutputConsole);
            this.groupConsoleOutput.Location = new System.Drawing.Point(168, 285);
            this.groupConsoleOutput.Name = "groupConsoleOutput";
            this.groupConsoleOutput.Size = new System.Drawing.Size(654, 166);
            this.groupConsoleOutput.TabIndex = 2;
            this.groupConsoleOutput.TabStop = false;
            this.groupConsoleOutput.Text = "Console";
            // 
            // txtOutputConsole
            // 
            this.txtOutputConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputConsole.Location = new System.Drawing.Point(6, 19);
            this.txtOutputConsole.Name = "txtOutputConsole";
            this.txtOutputConsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtOutputConsole.Size = new System.Drawing.Size(642, 141);
            this.txtOutputConsole.TabIndex = 0;
            this.txtOutputConsole.Text = "";
            // 
            // groupJsFilesTree
            // 
            this.groupJsFilesTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupJsFilesTree.Controls.Add(this.button1);
            this.groupJsFilesTree.Controls.Add(this.btnShowFiles);
            this.groupJsFilesTree.Controls.Add(this.tvJavaScriptFiels);
            this.groupJsFilesTree.Location = new System.Drawing.Point(3, 3);
            this.groupJsFilesTree.Name = "groupJsFilesTree";
            this.groupJsFilesTree.Size = new System.Drawing.Size(162, 458);
            this.groupJsFilesTree.TabIndex = 3;
            this.groupJsFilesTree.TabStop = false;
            this.groupJsFilesTree.Text = "JavaScript Snippets";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Reload";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnShowFiles
            // 
            this.btnShowFiles.Location = new System.Drawing.Point(72, 16);
            this.btnShowFiles.Name = "btnShowFiles";
            this.btnShowFiles.Size = new System.Drawing.Size(84, 23);
            this.btnShowFiles.TabIndex = 1;
            this.btnShowFiles.Text = "Show Files...";
            this.btnShowFiles.UseVisualStyleBackColor = true;
            this.btnShowFiles.Click += new System.EventHandler(this.btnShowFiles_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupConsoleOutput);
            this.panel1.Controls.Add(this.groupCode);
            this.panel1.Controls.Add(this.groupJsFilesTree);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 464);
            this.panel1.TabIndex = 4;
            // 
            // JavaScriptEditorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "JavaScriptEditorView";
            this.Size = new System.Drawing.Size(825, 464);
            this.groupCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtJavaScriptEditor)).EndInit();
            this.groupConsoleOutput.ResumeLayout(false);
            this.groupJsFilesTree.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvJavaScriptFiels;
        private System.Windows.Forms.GroupBox groupCode;
        private System.Windows.Forms.GroupBox groupConsoleOutput;
        private System.Windows.Forms.GroupBox groupJsFilesTree;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnSave;
        public FastColoredTextBoxNS.FastColoredTextBox txtJavaScriptEditor;
        private System.Windows.Forms.RichTextBox txtOutputConsole;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnShowFiles;
        private System.Windows.Forms.Panel panel1;


    }
}
