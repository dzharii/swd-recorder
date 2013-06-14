namespace SwdPageRecorder.UI
{
    partial class SwdMainView
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowser_Go = new System.Windows.Forms.Button();
            this.txtBrowserUrl = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.browserSettingsTab1 = new SwdPageRecorder.UI.BrowserSettingsTabView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.selectorsEditView = new SwdPageRecorder.UI.SelectorsEditView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnStartVisualSearch = new System.Windows.Forms.Button();
            this.txtVisualSearchResult = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.lbElements = new System.Windows.Forms.ListBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.txtHtmlNodeProperties = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tvHtmlDoc = new System.Windows.Forms.TreeView();
            this.btnTestLocator = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnGenerateSourceCode = new System.Windows.Forms.Button();
            this.txtSourceCode = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtHtmlPageSource = new System.Windows.Forms.TextBox();
            this.btnGetHtmlSource = new System.Windows.Forms.Button();
            this.validationError = new System.Windows.Forms.ErrorProvider(this.components);
            this.pageObjectDefinitionView = new SwdPageRecorder.UI.PageObjectDefinitionView();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.validationError)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowser_Go);
            this.groupBox1.Controls.Add(this.txtBrowserUrl);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(990, 39);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Browser";
            // 
            // btnBrowser_Go
            // 
            this.btnBrowser_Go.Location = new System.Drawing.Point(650, 13);
            this.btnBrowser_Go.Name = "btnBrowser_Go";
            this.btnBrowser_Go.Size = new System.Drawing.Size(46, 23);
            this.btnBrowser_Go.TabIndex = 1;
            this.btnBrowser_Go.Text = "Go >";
            this.btnBrowser_Go.UseVisualStyleBackColor = true;
            this.btnBrowser_Go.Click += new System.EventHandler(this.btnBrowser_Go_Click);
            // 
            // txtBrowserUrl
            // 
            this.txtBrowserUrl.Location = new System.Drawing.Point(6, 13);
            this.txtBrowserUrl.Name = "txtBrowserUrl";
            this.txtBrowserUrl.Size = new System.Drawing.Size(637, 20);
            this.txtBrowserUrl.TabIndex = 0;
            this.txtBrowserUrl.Text = "http://yandex.ru";
            this.txtBrowserUrl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBrowserUrl_KeyUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 57);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(752, 482);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.browserSettingsTab1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(744, 456);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Browser Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // browserSettingsTab1
            // 
            this.browserSettingsTab1.Location = new System.Drawing.Point(6, 6);
            this.browserSettingsTab1.Name = "browserSettingsTab1";
            this.browserSettingsTab1.Size = new System.Drawing.Size(672, 248);
            this.browserSettingsTab1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.selectorsEditView);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(744, 456);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Locators";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // selectorsEditView
            // 
            this.selectorsEditView.Location = new System.Drawing.Point(4, 3);
            this.selectorsEditView.Name = "selectorsEditView";
            this.selectorsEditView.Size = new System.Drawing.Size(736, 157);
            this.selectorsEditView.TabIndex = 2;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnStartVisualSearch);
            this.groupBox5.Controls.Add(this.txtVisualSearchResult);
            this.groupBox5.Location = new System.Drawing.Point(7, 165);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(731, 51);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Visual Search";
            // 
            // btnStartVisualSearch
            // 
            this.btnStartVisualSearch.Location = new System.Drawing.Point(644, 16);
            this.btnStartVisualSearch.Name = "btnStartVisualSearch";
            this.btnStartVisualSearch.Size = new System.Drawing.Size(75, 23);
            this.btnStartVisualSearch.TabIndex = 1;
            this.btnStartVisualSearch.Text = "Start";
            this.btnStartVisualSearch.UseVisualStyleBackColor = true;
            this.btnStartVisualSearch.Click += new System.EventHandler(this.btnStartVisualSearch_Click);
            // 
            // txtVisualSearchResult
            // 
            this.txtVisualSearchResult.Location = new System.Drawing.Point(6, 19);
            this.txtVisualSearchResult.Name = "txtVisualSearchResult";
            this.txtVisualSearchResult.Size = new System.Drawing.Size(606, 20);
            this.txtVisualSearchResult.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tabControl2);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.btnTestLocator);
            this.groupBox3.Location = new System.Drawing.Point(3, 237);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(735, 214);
            this.groupBox3.TabIndex = 3;
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnGenerateSourceCode);
            this.tabPage3.Controls.Add(this.txtSourceCode);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(744, 456);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Source Code";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnGenerateSourceCode
            // 
            this.btnGenerateSourceCode.Location = new System.Drawing.Point(489, 6);
            this.btnGenerateSourceCode.Name = "btnGenerateSourceCode";
            this.btnGenerateSourceCode.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateSourceCode.TabIndex = 1;
            this.btnGenerateSourceCode.Text = "Generate";
            this.btnGenerateSourceCode.UseVisualStyleBackColor = true;
            this.btnGenerateSourceCode.Click += new System.EventHandler(this.btnGenerateSourceCode_Click);
            // 
            // txtSourceCode
            // 
            this.txtSourceCode.AcceptsReturn = true;
            this.txtSourceCode.AcceptsTab = true;
            this.txtSourceCode.Location = new System.Drawing.Point(6, 29);
            this.txtSourceCode.Multiline = true;
            this.txtSourceCode.Name = "txtSourceCode";
            this.txtSourceCode.Size = new System.Drawing.Size(558, 362);
            this.txtSourceCode.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtHtmlPageSource);
            this.tabPage4.Controls.Add(this.btnGetHtmlSource);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(744, 456);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "HTML Source";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtHtmlPageSource
            // 
            this.txtHtmlPageSource.Location = new System.Drawing.Point(6, 35);
            this.txtHtmlPageSource.Multiline = true;
            this.txtHtmlPageSource.Name = "txtHtmlPageSource";
            this.txtHtmlPageSource.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHtmlPageSource.Size = new System.Drawing.Size(548, 356);
            this.txtHtmlPageSource.TabIndex = 1;
            this.txtHtmlPageSource.WordWrap = false;
            // 
            // btnGetHtmlSource
            // 
            this.btnGetHtmlSource.Location = new System.Drawing.Point(479, 6);
            this.btnGetHtmlSource.Name = "btnGetHtmlSource";
            this.btnGetHtmlSource.Size = new System.Drawing.Size(75, 23);
            this.btnGetHtmlSource.TabIndex = 0;
            this.btnGetHtmlSource.Text = "Get HTML";
            this.btnGetHtmlSource.UseVisualStyleBackColor = true;
            this.btnGetHtmlSource.Click += new System.EventHandler(this.btnGetHtmlSource_Click);
            // 
            // validationError
            // 
            this.validationError.ContainerControl = this;
            // 
            // pageObjectDefinitionView
            // 
            this.pageObjectDefinitionView.Location = new System.Drawing.Point(766, 57);
            this.pageObjectDefinitionView.Name = "pageObjectDefinitionView";
            this.pageObjectDefinitionView.Size = new System.Drawing.Size(246, 482);
            this.pageObjectDefinitionView.TabIndex = 2;
            // 
            // SwdMainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 542);
            this.Controls.Add(this.pageObjectDefinitionView);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "SwdMainView";
            this.Text = "SWD Page Recorder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.validationError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.Button btnTestLocator;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.ListBox lbElements;
        public System.Windows.Forms.ErrorProvider validationError;
        public System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.Button btnGenerateSourceCode;
        public System.Windows.Forms.TextBox txtSourceCode;
        public System.Windows.Forms.TextBox txtBrowserUrl;
        public System.Windows.Forms.TabPage tabPage4;
        public System.Windows.Forms.TextBox txtHtmlPageSource;
        public System.Windows.Forms.Button btnGetHtmlSource;
        public System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.Button btnStartVisualSearch;
        public System.Windows.Forms.TextBox txtVisualSearchResult;
        public System.Windows.Forms.GroupBox groupBox6;
        public System.Windows.Forms.TreeView tvHtmlDoc;
        public System.Windows.Forms.TabControl tabControl2;
        public System.Windows.Forms.TabPage tabPage5;
        public System.Windows.Forms.TabPage tabPage6;
        public System.Windows.Forms.TextBox txtHtmlNodeProperties;
        public System.Windows.Forms.Button btnBrowser_Go;
        private BrowserSettingsTabView browserSettingsTab1;
        public PageObjectDefinitionView pageObjectDefinitionView;
        private SelectorsEditView selectorsEditView;
        

    }
}

