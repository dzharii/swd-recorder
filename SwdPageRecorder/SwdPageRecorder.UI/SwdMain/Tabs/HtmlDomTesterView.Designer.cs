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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.lbElements = new System.Windows.Forms.ListBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.txtHtmlNodeProperties = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tvHtmlDoc = new System.Windows.Forms.TreeView();
            this.btnTestLocator = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tabControl2);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.btnTestLocator);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(735, 214);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Test result";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Location = new System.Drawing.Point(451, 48);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(278, 160);
            this.tabControl2.TabIndex = 4;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.lbElements);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(270, 134);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "WebElements";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // lbElements
            // 
            this.lbElements.FormattingEnabled = true;
            this.lbElements.Location = new System.Drawing.Point(3, 6);
            this.lbElements.Name = "lbElements";
            this.lbElements.Size = new System.Drawing.Size(261, 121);
            this.lbElements.TabIndex = 0;
            this.lbElements.DoubleClick += new System.EventHandler(this.lbElements_DoubleClick);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.txtHtmlNodeProperties);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(270, 134);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "HTML Property";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // txtHtmlNodeProperties
            // 
            this.txtHtmlNodeProperties.Location = new System.Drawing.Point(6, 6);
            this.txtHtmlNodeProperties.Multiline = true;
            this.txtHtmlNodeProperties.Name = "txtHtmlNodeProperties";
            this.txtHtmlNodeProperties.Size = new System.Drawing.Size(258, 122);
            this.txtHtmlNodeProperties.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tvHtmlDoc);
            this.groupBox6.Location = new System.Drawing.Point(6, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(445, 189);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Html Document";
            // 
            // tvHtmlDoc
            // 
            this.tvHtmlDoc.Location = new System.Drawing.Point(6, 16);
            this.tvHtmlDoc.Name = "tvHtmlDoc";
            this.tvHtmlDoc.Size = new System.Drawing.Size(433, 173);
            this.tvHtmlDoc.TabIndex = 0;
            this.tvHtmlDoc.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvHtmlDoc_BeforeCollapse);
            this.tvHtmlDoc.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvHtmlDoc_BeforeExpand);
            this.tvHtmlDoc.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvHtmlDoc_AfterSelect);
            this.tvHtmlDoc.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvHtmlDoc_NodeMouseDoubleClick);
            this.tvHtmlDoc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvHtmlDoc_MouseDown);
            // 
            // btnTestLocator
            // 
            this.btnTestLocator.Location = new System.Drawing.Point(648, 19);
            this.btnTestLocator.Name = "btnTestLocator";
            this.btnTestLocator.Size = new System.Drawing.Size(75, 23);
            this.btnTestLocator.TabIndex = 2;
            this.btnTestLocator.Text = "Test";
            this.btnTestLocator.UseVisualStyleBackColor = true;
            this.btnTestLocator.Click += new System.EventHandler(this.btnTestLocator_Click);
            // 
            // HtmlDomTesterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Name = "HtmlDomTesterView";
            this.Size = new System.Drawing.Size(743, 222);
            this.groupBox3.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.TabControl tabControl2;
        public System.Windows.Forms.TabPage tabPage5;
        public System.Windows.Forms.ListBox lbElements;
        public System.Windows.Forms.TabPage tabPage6;
        public System.Windows.Forms.TextBox txtHtmlNodeProperties;
        public System.Windows.Forms.GroupBox groupBox6;
        public System.Windows.Forms.TreeView tvHtmlDoc;
        public System.Windows.Forms.Button btnTestLocator;
    }
}
