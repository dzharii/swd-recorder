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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Pages");
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.chkUseRemoteHub = new System.Windows.Forms.CheckBox();
            this.grpRemoteConnection = new System.Windows.Forms.GroupBox();
            this.lblHubConnectionStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemoteHubUrl = new System.Windows.Forms.TextBox();
            this.btnStartWebDriver = new System.Windows.Forms.Button();
            this.ddlBrowserToStart = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbElements = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdateDeclaration = new System.Windows.Forms.Button();
            this.txtWebElementName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOtherLocator = new System.Windows.Forms.TextBox();
            this.btnTestLocator = new System.Windows.Forms.Button();
            this.ddlOtherLocator = new System.Windows.Forms.ComboBox();
            this.rbtnOtherLocator = new System.Windows.Forms.RadioButton();
            this.txtHtmlId = new System.Windows.Forms.TextBox();
            this.rbtnHtmlId = new System.Windows.Forms.RadioButton();
            this.txtXPath = new System.Windows.Forms.TextBox();
            this.rbtnXPath = new System.Windows.Forms.RadioButton();
            this.rbtnCssSelector = new System.Windows.Forms.RadioButton();
            this.txtCssSelector = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tvWebElements = new System.Windows.Forms.TreeView();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.validationError = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtSourceCode = new System.Windows.Forms.TextBox();
            this.btnGenerateSourceCode = new System.Windows.Forms.Button();
            this.txtBrowserUrl = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnGetHtmlSource = new System.Windows.Forms.Button();
            this.txtHtmlPageSource = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpRemoteConnection.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.validationError)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBrowserUrl);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(772, 39);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Browser";
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
            this.tabControl1.Size = new System.Drawing.Size(578, 423);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.chkUseRemoteHub);
            this.tabPage1.Controls.Add(this.grpRemoteConnection);
            this.tabPage1.Controls.Add(this.btnStartWebDriver);
            this.tabPage1.Controls.Add(this.ddlBrowserToStart);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(570, 397);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Browser Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Browser:";
            // 
            // chkUseRemoteHub
            // 
            this.chkUseRemoteHub.AutoSize = true;
            this.chkUseRemoteHub.Location = new System.Drawing.Point(6, 19);
            this.chkUseRemoteHub.Name = "chkUseRemoteHub";
            this.chkUseRemoteHub.Size = new System.Drawing.Size(164, 17);
            this.chkUseRemoteHub.TabIndex = 3;
            this.chkUseRemoteHub.Text = "Use Remote Hub connection";
            this.chkUseRemoteHub.UseVisualStyleBackColor = true;
            this.chkUseRemoteHub.CheckedChanged += new System.EventHandler(this.chkUseRemoteHub_CheckedChanged);
            // 
            // grpRemoteConnection
            // 
            this.grpRemoteConnection.Controls.Add(this.lblHubConnectionStatus);
            this.grpRemoteConnection.Controls.Add(this.label2);
            this.grpRemoteConnection.Controls.Add(this.txtRemoteHubUrl);
            this.grpRemoteConnection.Location = new System.Drawing.Point(6, 42);
            this.grpRemoteConnection.Name = "grpRemoteConnection";
            this.grpRemoteConnection.Size = new System.Drawing.Size(558, 100);
            this.grpRemoteConnection.TabIndex = 2;
            this.grpRemoteConnection.TabStop = false;
            this.grpRemoteConnection.Text = "Remote Driver Configuration";
            // 
            // lblHubConnectionStatus
            // 
            this.lblHubConnectionStatus.AutoSize = true;
            this.lblHubConnectionStatus.Location = new System.Drawing.Point(508, 31);
            this.lblHubConnectionStatus.Name = "lblHubConnectionStatus";
            this.lblHubConnectionStatus.Size = new System.Drawing.Size(37, 13);
            this.lblHubConnectionStatus.TabIndex = 2;
            this.lblHubConnectionStatus.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hub URL:";
            // 
            // txtRemoteHubUrl
            // 
            this.txtRemoteHubUrl.Location = new System.Drawing.Point(69, 28);
            this.txtRemoteHubUrl.Name = "txtRemoteHubUrl";
            this.txtRemoteHubUrl.Size = new System.Drawing.Size(433, 20);
            this.txtRemoteHubUrl.TabIndex = 0;
            this.txtRemoteHubUrl.Text = "http://127.0.0.1:4444/wd/hub";
            // 
            // btnStartWebDriver
            // 
            this.btnStartWebDriver.Location = new System.Drawing.Point(187, 152);
            this.btnStartWebDriver.Name = "btnStartWebDriver";
            this.btnStartWebDriver.Size = new System.Drawing.Size(75, 23);
            this.btnStartWebDriver.TabIndex = 1;
            this.btnStartWebDriver.Text = "Start";
            this.btnStartWebDriver.UseVisualStyleBackColor = true;
            this.btnStartWebDriver.Click += new System.EventHandler(this.btnStartWebDriver_Click);
            // 
            // ddlBrowserToStart
            // 
            this.ddlBrowserToStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBrowserToStart.FormattingEnabled = true;
            this.ddlBrowserToStart.Items.AddRange(new object[] {
            "FireFox",
            "Internet Explorer"});
            this.ddlBrowserToStart.Location = new System.Drawing.Point(60, 152);
            this.ddlBrowserToStart.Name = "ddlBrowserToStart";
            this.ddlBrowserToStart.Size = new System.Drawing.Size(121, 21);
            this.ddlBrowserToStart.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(570, 397);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Locators";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbElements);
            this.groupBox3.Location = new System.Drawing.Point(3, 201);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(547, 178);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Result";
            // 
            // lbElements
            // 
            this.lbElements.FormattingEnabled = true;
            this.lbElements.Location = new System.Drawing.Point(7, 33);
            this.lbElements.Name = "lbElements";
            this.lbElements.Size = new System.Drawing.Size(260, 134);
            this.lbElements.TabIndex = 0;
            this.lbElements.DoubleClick += new System.EventHandler(this.lbElements_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUpdateDeclaration);
            this.groupBox2.Controls.Add(this.txtWebElementName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtOtherLocator);
            this.groupBox2.Controls.Add(this.btnTestLocator);
            this.groupBox2.Controls.Add(this.ddlOtherLocator);
            this.groupBox2.Controls.Add(this.rbtnOtherLocator);
            this.groupBox2.Controls.Add(this.txtHtmlId);
            this.groupBox2.Controls.Add(this.rbtnHtmlId);
            this.groupBox2.Controls.Add(this.txtXPath);
            this.groupBox2.Controls.Add(this.rbtnXPath);
            this.groupBox2.Controls.Add(this.rbtnCssSelector);
            this.groupBox2.Controls.Add(this.txtCssSelector);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(544, 189);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selectors";
            // 
            // btnUpdateDeclaration
            // 
            this.btnUpdateDeclaration.Location = new System.Drawing.Point(458, 160);
            this.btnUpdateDeclaration.Name = "btnUpdateDeclaration";
            this.btnUpdateDeclaration.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateDeclaration.TabIndex = 13;
            this.btnUpdateDeclaration.Text = "Update >>";
            this.btnUpdateDeclaration.UseVisualStyleBackColor = true;
            this.btnUpdateDeclaration.Click += new System.EventHandler(this.btnUpdateDeclaration_Click);
            // 
            // txtWebElementName
            // 
            this.txtWebElementName.Location = new System.Drawing.Point(132, 13);
            this.txtWebElementName.Name = "txtWebElementName";
            this.txtWebElementName.Size = new System.Drawing.Size(383, 20);
            this.txtWebElementName.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Name:";
            // 
            // txtOtherLocator
            // 
            this.txtOtherLocator.Location = new System.Drawing.Point(132, 115);
            this.txtOtherLocator.Name = "txtOtherLocator";
            this.txtOtherLocator.Size = new System.Drawing.Size(383, 20);
            this.txtOtherLocator.TabIndex = 9;
            this.txtOtherLocator.Enter += new System.EventHandler(this.txtOtherLocator_Enter);
            // 
            // btnTestLocator
            // 
            this.btnTestLocator.Location = new System.Drawing.Point(0, 160);
            this.btnTestLocator.Name = "btnTestLocator";
            this.btnTestLocator.Size = new System.Drawing.Size(75, 23);
            this.btnTestLocator.TabIndex = 2;
            this.btnTestLocator.Text = "Test";
            this.btnTestLocator.UseVisualStyleBackColor = true;
            this.btnTestLocator.Click += new System.EventHandler(this.btnTestLocator_Click);
            // 
            // ddlOtherLocator
            // 
            this.ddlOtherLocator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlOtherLocator.FormattingEnabled = true;
            this.ddlOtherLocator.Location = new System.Drawing.Point(25, 115);
            this.ddlOtherLocator.Name = "ddlOtherLocator";
            this.ddlOtherLocator.Size = new System.Drawing.Size(101, 21);
            this.ddlOtherLocator.TabIndex = 8;
            this.ddlOtherLocator.Click += new System.EventHandler(this.ddlOtherLocator_Click);
            // 
            // rbtnOtherLocator
            // 
            this.rbtnOtherLocator.AutoSize = true;
            this.rbtnOtherLocator.Location = new System.Drawing.Point(7, 119);
            this.rbtnOtherLocator.Name = "rbtnOtherLocator";
            this.rbtnOtherLocator.Size = new System.Drawing.Size(14, 13);
            this.rbtnOtherLocator.TabIndex = 7;
            this.rbtnOtherLocator.TabStop = true;
            this.rbtnOtherLocator.UseVisualStyleBackColor = true;
            // 
            // txtHtmlId
            // 
            this.txtHtmlId.Location = new System.Drawing.Point(132, 39);
            this.txtHtmlId.Name = "txtHtmlId";
            this.txtHtmlId.Size = new System.Drawing.Size(383, 20);
            this.txtHtmlId.TabIndex = 6;
            this.txtHtmlId.Enter += new System.EventHandler(this.txtHtmlId_Enter);
            // 
            // rbtnHtmlId
            // 
            this.rbtnHtmlId.AutoSize = true;
            this.rbtnHtmlId.Checked = true;
            this.rbtnHtmlId.Location = new System.Drawing.Point(7, 44);
            this.rbtnHtmlId.Name = "rbtnHtmlId";
            this.rbtnHtmlId.Size = new System.Drawing.Size(63, 17);
            this.rbtnHtmlId.TabIndex = 5;
            this.rbtnHtmlId.TabStop = true;
            this.rbtnHtmlId.Text = "Html ID:";
            this.rbtnHtmlId.UseVisualStyleBackColor = true;
            // 
            // txtXPath
            // 
            this.txtXPath.Location = new System.Drawing.Point(132, 87);
            this.txtXPath.Name = "txtXPath";
            this.txtXPath.Size = new System.Drawing.Size(383, 20);
            this.txtXPath.TabIndex = 4;
            this.txtXPath.Enter += new System.EventHandler(this.txtXPath_Enter);
            // 
            // rbtnXPath
            // 
            this.rbtnXPath.AutoSize = true;
            this.rbtnXPath.Location = new System.Drawing.Point(7, 90);
            this.rbtnXPath.Name = "rbtnXPath";
            this.rbtnXPath.Size = new System.Drawing.Size(57, 17);
            this.rbtnXPath.TabIndex = 3;
            this.rbtnXPath.Text = "XPath:";
            this.rbtnXPath.UseVisualStyleBackColor = true;
            // 
            // rbtnCssSelector
            // 
            this.rbtnCssSelector.AutoSize = true;
            this.rbtnCssSelector.Location = new System.Drawing.Point(7, 67);
            this.rbtnCssSelector.Name = "rbtnCssSelector";
            this.rbtnCssSelector.Size = new System.Drawing.Size(87, 17);
            this.rbtnCssSelector.TabIndex = 2;
            this.rbtnCssSelector.Text = "Css Selector:";
            this.rbtnCssSelector.UseVisualStyleBackColor = true;
            // 
            // txtCssSelector
            // 
            this.txtCssSelector.Location = new System.Drawing.Point(132, 64);
            this.txtCssSelector.Name = "txtCssSelector";
            this.txtCssSelector.Size = new System.Drawing.Size(383, 20);
            this.txtCssSelector.TabIndex = 1;
            this.txtCssSelector.Enter += new System.EventHandler(this.txtCssSelector_Enter);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnGenerateSourceCode);
            this.tabPage3.Controls.Add(this.txtSourceCode);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(570, 397);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Source Code";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tvWebElements);
            this.groupBox4.Controls.Add(this.propertyGrid1);
            this.groupBox4.Location = new System.Drawing.Point(592, 79);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(237, 397);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Page Object";
            // 
            // tvWebElements
            // 
            this.tvWebElements.LabelEdit = true;
            this.tvWebElements.Location = new System.Drawing.Point(6, 19);
            this.tvWebElements.Name = "tvWebElements";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Pages";
            this.tvWebElements.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.tvWebElements.Size = new System.Drawing.Size(225, 156);
            this.tvWebElements.TabIndex = 2;
            this.tvWebElements.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvWebElements_NodeMouseDoubleClick);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(6, 179);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(225, 212);
            this.propertyGrid1.TabIndex = 1;
            // 
            // validationError
            // 
            this.validationError.ContainerControl = this;
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
            // txtBrowserUrl
            // 
            this.txtBrowserUrl.Location = new System.Drawing.Point(6, 13);
            this.txtBrowserUrl.Name = "txtBrowserUrl";
            this.txtBrowserUrl.Size = new System.Drawing.Size(760, 20);
            this.txtBrowserUrl.TabIndex = 0;
            this.txtBrowserUrl.Text = "http://blog.zhariy.com/";
            this.txtBrowserUrl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBrowserUrl_KeyUp);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtHtmlPageSource);
            this.tabPage4.Controls.Add(this.btnGetHtmlSource);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(570, 397);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "HTML Source";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            // txtHtmlPageSource
            // 
            this.txtHtmlPageSource.Location = new System.Drawing.Point(6, 35);
            this.txtHtmlPageSource.Multiline = true;
            this.txtHtmlPageSource.Name = "txtHtmlPageSource";
            this.txtHtmlPageSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHtmlPageSource.Size = new System.Drawing.Size(548, 356);
            this.txtHtmlPageSource.TabIndex = 1;
            // 
            // SwdMainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 492);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "SwdMainView";
            this.Text = "SWD Page Recorder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.grpRemoteConnection.ResumeLayout(false);
            this.grpRemoteConnection.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.validationError)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox ddlBrowserToStart;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnStartWebDriver;
        private System.Windows.Forms.Button btnTestLocator;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtHtmlId;
        private System.Windows.Forms.RadioButton rbtnHtmlId;
        private System.Windows.Forms.TextBox txtXPath;
        private System.Windows.Forms.RadioButton rbtnXPath;
        private System.Windows.Forms.RadioButton rbtnCssSelector;
        private System.Windows.Forms.TextBox txtCssSelector;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lbElements;
        private System.Windows.Forms.ComboBox ddlOtherLocator;
        private System.Windows.Forms.RadioButton rbtnOtherLocator;
        private System.Windows.Forms.TextBox txtOtherLocator;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.TextBox txtWebElementName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdateDeclaration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkUseRemoteHub;
        private System.Windows.Forms.GroupBox grpRemoteConnection;
        private System.Windows.Forms.Label lblHubConnectionStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRemoteHubUrl;
        private System.Windows.Forms.TreeView tvWebElements;
        private System.Windows.Forms.ErrorProvider validationError;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnGenerateSourceCode;
        private System.Windows.Forms.TextBox txtSourceCode;
        private System.Windows.Forms.TextBox txtBrowserUrl;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtHtmlPageSource;
        private System.Windows.Forms.Button btnGetHtmlSource;

    }
}

