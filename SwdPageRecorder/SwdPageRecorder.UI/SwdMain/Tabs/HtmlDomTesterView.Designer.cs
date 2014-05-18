namespace SwdPageRecorder.UI
{
    partial class HtmlDomTesterView
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
            this.btnTestLocator = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvHtmlDoc = new System.Windows.Forms.TreeView();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.lbElements = new System.Windows.Forms.ListBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.txtHtmlNodeProperties = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTestLocator
            // 
            this.btnTestLocator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestLocator.Location = new System.Drawing.Point(656, 11);
            this.btnTestLocator.Name = "btnTestLocator";
            this.btnTestLocator.Size = new System.Drawing.Size(75, 23);
            this.btnTestLocator.TabIndex = 2;
            this.btnTestLocator.Text = "Test";
            this.btnTestLocator.UseVisualStyleBackColor = true;
            this.btnTestLocator.Click += new System.EventHandler(this.btnTestLocator_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.splitContainer1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(743, 222);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Test result";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvHtmlDoc);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(737, 203);
            this.splitContainer1.SplitterDistance = 457;
            this.splitContainer1.TabIndex = 1;
            // 
            // tvHtmlDoc
            // 
            this.tvHtmlDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvHtmlDoc.Location = new System.Drawing.Point(0, 0);
            this.tvHtmlDoc.Name = "tvHtmlDoc";
            this.tvHtmlDoc.Size = new System.Drawing.Size(457, 203);
            this.tvHtmlDoc.TabIndex = 0;
            this.tvHtmlDoc.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvHtmlDoc_BeforeCollapse);
            this.tvHtmlDoc.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvHtmlDoc_BeforeExpand);
            this.tvHtmlDoc.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvHtmlDoc_AfterSelect);
            this.tvHtmlDoc.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvHtmlDoc_NodeMouseDoubleClick);
            this.tvHtmlDoc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvHtmlDoc_MouseDown);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(276, 203);
            this.tabControl2.TabIndex = 4;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.lbElements);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(268, 177);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "WebElements";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // lbElements
            // 
            this.lbElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbElements.FormattingEnabled = true;
            this.lbElements.Location = new System.Drawing.Point(3, 3);
            this.lbElements.Name = "lbElements";
            this.lbElements.Size = new System.Drawing.Size(262, 171);
            this.lbElements.TabIndex = 0;
            this.lbElements.DoubleClick += new System.EventHandler(this.lbElements_DoubleClick);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.txtHtmlNodeProperties);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(268, 177);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "HTML Property";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // txtHtmlNodeProperties
            // 
            this.txtHtmlNodeProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHtmlNodeProperties.Font = new System.Drawing.Font("Lucida Console", 9.75F);
            this.txtHtmlNodeProperties.Location = new System.Drawing.Point(3, 3);
            this.txtHtmlNodeProperties.Multiline = true;
            this.txtHtmlNodeProperties.Name = "txtHtmlNodeProperties";
            this.txtHtmlNodeProperties.Size = new System.Drawing.Size(262, 171);
            this.txtHtmlNodeProperties.TabIndex = 0;
            // 
            // HtmlDomTesterView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btnTestLocator);
            this.Controls.Add(this.groupBox3);
            this.Name = "HtmlDomTesterView";
            this.Size = new System.Drawing.Size(743, 222);
            this.groupBox3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.TreeView tvHtmlDoc;
        public System.Windows.Forms.TabControl tabControl2;
        public System.Windows.Forms.TabPage tabPage5;
        public System.Windows.Forms.ListBox lbElements;
        public System.Windows.Forms.TabPage tabPage6;
        public System.Windows.Forms.TextBox txtHtmlNodeProperties;
        public System.Windows.Forms.Button btnTestLocator;
        public System.Windows.Forms.GroupBox groupBox3;

    }
}
