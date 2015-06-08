namespace SwdPageRecorder.UI
{
    partial class BrowserSettingsTabView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserSettingsTabView));
            this.label3 = new System.Windows.Forms.Label();
            this.grpRemoteConnection = new System.Windows.Forms.GroupBox();
            this.lblRemoteHubStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTestRemoteHub = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemoteHubUrl = new System.Windows.Forms.TextBox();
            this.btnStartWebDriver = new System.Windows.Forms.Button();
            this.ddlBrowserToStart = new System.Windows.Forms.ComboBox();
            this.grdDesiredCapabilities = new System.Windows.Forms.PropertyGrid();
            this.grpDesiredCaps = new System.Windows.Forms.GroupBox();
            this.btnLoadCapabilities = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lnkSeleniumDownloadPage = new System.Windows.Forms.LinkLabel();
            this.chkMaximizeBrowserWindow = new System.Windows.Forms.CheckBox();
            this.lblWebDriverStatus = new System.Windows.Forms.Label();
            this.grpRemoteConnection.SuspendLayout();
            this.grpDesiredCaps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Browser:";
            // 
            // grpRemoteConnection
            // 
            this.grpRemoteConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRemoteConnection.Controls.Add(this.lblWebDriverStatus);
            this.grpRemoteConnection.Controls.Add(this.chkMaximizeBrowserWindow);
            this.grpRemoteConnection.Controls.Add(this.lblRemoteHubStatus);
            this.grpRemoteConnection.Controls.Add(this.lnkSeleniumDownloadPage);
            this.grpRemoteConnection.Controls.Add(this.label1);
            this.grpRemoteConnection.Controls.Add(this.label5);
            this.grpRemoteConnection.Controls.Add(this.btnTestRemoteHub);
            this.grpRemoteConnection.Controls.Add(this.pictureBox2);
            this.grpRemoteConnection.Controls.Add(this.label2);
            this.grpRemoteConnection.Controls.Add(this.label4);
            this.grpRemoteConnection.Controls.Add(this.txtRemoteHubUrl);
            this.grpRemoteConnection.Controls.Add(this.label3);
            this.grpRemoteConnection.Controls.Add(this.ddlBrowserToStart);
            this.grpRemoteConnection.Controls.Add(this.btnStartWebDriver);
            this.grpRemoteConnection.Location = new System.Drawing.Point(3, 1);
            this.grpRemoteConnection.Name = "grpRemoteConnection";
            this.grpRemoteConnection.Size = new System.Drawing.Size(688, 147);
            this.grpRemoteConnection.TabIndex = 7;
            this.grpRemoteConnection.TabStop = false;
            this.grpRemoteConnection.Text = "Remote Driver Configuration";
            // 
            // lblRemoteHubStatus
            // 
            this.lblRemoteHubStatus.AutoSize = true;
            this.lblRemoteHubStatus.Location = new System.Drawing.Point(171, 56);
            this.lblRemoteHubStatus.Name = "lblRemoteHubStatus";
            this.lblRemoteHubStatus.Size = new System.Drawing.Size(62, 13);
            this.lblRemoteHubStatus.TabIndex = 4;
            this.lblRemoteHubStatus.Text = "(Not tested)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Remote Hub Status:";
            // 
            // btnTestRemoteHub
            // 
            this.btnTestRemoteHub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestRemoteHub.Location = new System.Drawing.Point(607, 26);
            this.btnTestRemoteHub.Name = "btnTestRemoteHub";
            this.btnTestRemoteHub.Size = new System.Drawing.Size(75, 23);
            this.btnTestRemoteHub.TabIndex = 2;
            this.btnTestRemoteHub.Text = "Test";
            this.btnTestRemoteHub.UseVisualStyleBackColor = true;
            this.btnTestRemoteHub.Click += new System.EventHandler(this.btnTestRemoteHub_Click);
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
            this.txtRemoteHubUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemoteHubUrl.Location = new System.Drawing.Point(69, 28);
            this.txtRemoteHubUrl.Name = "txtRemoteHubUrl";
            this.txtRemoteHubUrl.Size = new System.Drawing.Size(532, 20);
            this.txtRemoteHubUrl.TabIndex = 0;
            this.txtRemoteHubUrl.Text = "http://127.0.0.1:4444/wd/hub";
            // 
            // btnStartWebDriver
            // 
            this.btnStartWebDriver.Location = new System.Drawing.Point(187, 80);
            this.btnStartWebDriver.Name = "btnStartWebDriver";
            this.btnStartWebDriver.Size = new System.Drawing.Size(75, 23);
            this.btnStartWebDriver.TabIndex = 6;
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
            this.ddlBrowserToStart.Location = new System.Drawing.Point(60, 80);
            this.ddlBrowserToStart.Name = "ddlBrowserToStart";
            this.ddlBrowserToStart.Size = new System.Drawing.Size(121, 21);
            this.ddlBrowserToStart.TabIndex = 5;
            // 
            // grdDesiredCapabilities
            // 
            this.grdDesiredCapabilities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDesiredCapabilities.Location = new System.Drawing.Point(6, 49);
            this.grdDesiredCapabilities.Name = "grdDesiredCapabilities";
            this.grdDesiredCapabilities.Size = new System.Drawing.Size(676, 218);
            this.grdDesiredCapabilities.TabIndex = 10;
            // 
            // grpDesiredCaps
            // 
            this.grpDesiredCaps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDesiredCaps.Controls.Add(this.btnLoadCapabilities);
            this.grpDesiredCaps.Controls.Add(this.grdDesiredCapabilities);
            this.grpDesiredCaps.Location = new System.Drawing.Point(3, 150);
            this.grpDesiredCaps.Name = "grpDesiredCaps";
            this.grpDesiredCaps.Size = new System.Drawing.Size(688, 273);
            this.grpDesiredCaps.TabIndex = 11;
            this.grpDesiredCaps.TabStop = false;
            this.grpDesiredCaps.Text = "Capabilities";
            // 
            // btnLoadCapabilities
            // 
            this.btnLoadCapabilities.Location = new System.Drawing.Point(7, 20);
            this.btnLoadCapabilities.Name = "btnLoadCapabilities";
            this.btnLoadCapabilities.Size = new System.Drawing.Size(124, 23);
            this.btnLoadCapabilities.TabIndex = 11;
            this.btnLoadCapabilities.Text = "Load Capabilities";
            this.btnLoadCapabilities.UseVisualStyleBackColor = true;
            this.btnLoadCapabilities.Click += new System.EventHandler(this.btnLoadCapabilities_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(591, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Note: if you are going to use a browser other than Firefox (e.g. Chrome or IE), p" +
    "lease download appropriate driver executable";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(16, 105);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(21, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "and put it near the SWD Page Recorder. ";
            // 
            // lnkSeleniumDownloadPage
            // 
            this.lnkSeleniumDownloadPage.AutoSize = true;
            this.lnkSeleniumDownloadPage.Location = new System.Drawing.Point(270, 122);
            this.lnkSeleniumDownloadPage.Name = "lnkSeleniumDownloadPage";
            this.lnkSeleniumDownloadPage.Size = new System.Drawing.Size(151, 13);
            this.lnkSeleniumDownloadPage.TabIndex = 15;
            this.lnkSeleniumDownloadPage.TabStop = true;
            this.lnkSeleniumDownloadPage.Text = "See Selenium Download Page";
            this.lnkSeleniumDownloadPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSeleniumDownloadPage_LinkClicked);
            // 
            // chkMaximizeBrowserWindow
            // 
            this.chkMaximizeBrowserWindow.AutoSize = true;
            this.chkMaximizeBrowserWindow.Checked = true;
            this.chkMaximizeBrowserWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMaximizeBrowserWindow.Location = new System.Drawing.Point(275, 84);
            this.chkMaximizeBrowserWindow.Name = "chkMaximizeBrowserWindow";
            this.chkMaximizeBrowserWindow.Size = new System.Drawing.Size(148, 17);
            this.chkMaximizeBrowserWindow.TabIndex = 16;
            this.chkMaximizeBrowserWindow.Text = "Maximize browser window";
            this.chkMaximizeBrowserWindow.UseVisualStyleBackColor = true;
            // 
            // lblWebDriverStatus
            // 
            this.lblWebDriverStatus.AutoSize = true;
            this.lblWebDriverStatus.Location = new System.Drawing.Point(607, 70);
            this.lblWebDriverStatus.Name = "lblWebDriverStatus";
            this.lblWebDriverStatus.Size = new System.Drawing.Size(37, 13);
            this.lblWebDriverStatus.TabIndex = 17;
            this.lblWebDriverStatus.Text = "Status";
            // 
            // BrowserSettingsTabView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.grpDesiredCaps);
            this.Controls.Add(this.grpRemoteConnection);
            this.Name = "BrowserSettingsTabView";
            this.Size = new System.Drawing.Size(694, 426);
            this.grpRemoteConnection.ResumeLayout(false);
            this.grpRemoteConnection.PerformLayout();
            this.grpDesiredCaps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.GroupBox grpRemoteConnection;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtRemoteHubUrl;
        public System.Windows.Forms.Button btnStartWebDriver;
        public System.Windows.Forms.ComboBox ddlBrowserToStart;
        private System.Windows.Forms.Label lblRemoteHubStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTestRemoteHub;
        private System.Windows.Forms.GroupBox grpDesiredCaps;
        public System.Windows.Forms.PropertyGrid grdDesiredCapabilities;
        private System.Windows.Forms.Button btnLoadCapabilities;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lnkSeleniumDownloadPage;
        private System.Windows.Forms.CheckBox chkMaximizeBrowserWindow;
        private System.Windows.Forms.Label lblWebDriverStatus;
    }
}
