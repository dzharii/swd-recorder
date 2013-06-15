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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowser_Go = new System.Windows.Forms.Button();
            this.txtBrowserUrl = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.browserSettingsTab1 = new SwdPageRecorder.UI.BrowserSettingsTabView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.htmlDomTesterView1 = new SwdPageRecorder.UI.HtmlDomTesterView();
            this.selectorsEditView = new SwdPageRecorder.UI.SelectorsEditView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnStartVisualSearch = new System.Windows.Forms.Button();
            this.txtVisualSearchResult = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pageObjectDefinitionView = new SwdPageRecorder.UI.PageObjectDefinitionView();
            this.fullHtmlSourceTabView1 = new SwdPageRecorder.UI.FullHtmlSourceTabView();
            this.pageObjectSourceCodeView1 = new SwdPageRecorder.UI.PageObjectSourceCodeView();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
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
            this.tabPage2.Controls.Add(this.htmlDomTesterView1);
            this.tabPage2.Controls.Add(this.selectorsEditView);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(744, 456);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Locators";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // htmlDomTesterView1
            // 
            this.htmlDomTesterView1.Location = new System.Drawing.Point(2, 234);
            this.htmlDomTesterView1.Name = "htmlDomTesterView1";
            this.htmlDomTesterView1.Size = new System.Drawing.Size(743, 222);
            this.htmlDomTesterView1.TabIndex = 5;
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pageObjectSourceCodeView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(744, 456);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Source Code";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.fullHtmlSourceTabView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(744, 456);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "HTML Source";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pageObjectDefinitionView
            // 
            this.pageObjectDefinitionView.Location = new System.Drawing.Point(766, 57);
            this.pageObjectDefinitionView.Name = "pageObjectDefinitionView";
            this.pageObjectDefinitionView.Size = new System.Drawing.Size(246, 482);
            this.pageObjectDefinitionView.TabIndex = 2;
            // 
            // fullHtmlSourceTabView1
            // 
            this.fullHtmlSourceTabView1.Location = new System.Drawing.Point(6, 6);
            this.fullHtmlSourceTabView1.Name = "fullHtmlSourceTabView1";
            this.fullHtmlSourceTabView1.Size = new System.Drawing.Size(552, 389);
            this.fullHtmlSourceTabView1.TabIndex = 0;
            // 
            // pageObjectSourceCodeView1
            // 
            this.pageObjectSourceCodeView1.Location = new System.Drawing.Point(2, 0);
            this.pageObjectSourceCodeView1.Name = "pageObjectSourceCodeView1";
            this.pageObjectSourceCodeView1.Size = new System.Drawing.Size(567, 392);
            this.pageObjectSourceCodeView1.TabIndex = 0;
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
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.TextBox txtBrowserUrl;
        public System.Windows.Forms.TabPage tabPage4;
        public System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.Button btnStartVisualSearch;
        public System.Windows.Forms.TextBox txtVisualSearchResult;
        public System.Windows.Forms.Button btnBrowser_Go;
        private BrowserSettingsTabView browserSettingsTab1;
        public PageObjectDefinitionView pageObjectDefinitionView;
        private SelectorsEditView selectorsEditView;
        private HtmlDomTesterView htmlDomTesterView1;
        private PageObjectSourceCodeView pageObjectSourceCodeView1;
        private FullHtmlSourceTabView fullHtmlSourceTabView1;
        

    }
}

