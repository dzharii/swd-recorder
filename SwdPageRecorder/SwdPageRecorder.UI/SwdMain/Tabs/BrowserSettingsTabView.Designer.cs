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
            this.label3 = new System.Windows.Forms.Label();
            this.chkUseRemoteHub = new System.Windows.Forms.CheckBox();
            this.grpRemoteConnection = new System.Windows.Forms.GroupBox();
            this.lblHubConnectionStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemoteHubUrl = new System.Windows.Forms.TextBox();
            this.btnStartWebDriver = new System.Windows.Forms.Button();
            this.ddlBrowserToStart = new System.Windows.Forms.ComboBox();
            this.grpRemoteConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Browser:";
            // 
            // chkUseRemoteHub
            // 
            this.chkUseRemoteHub.AutoSize = true;
            this.chkUseRemoteHub.Location = new System.Drawing.Point(3, 3);
            this.chkUseRemoteHub.Name = "chkUseRemoteHub";
            this.chkUseRemoteHub.Size = new System.Drawing.Size(164, 17);
            this.chkUseRemoteHub.TabIndex = 8;
            this.chkUseRemoteHub.Text = "Use Remote Hub connection";
            this.chkUseRemoteHub.UseVisualStyleBackColor = true;
            this.chkUseRemoteHub.CheckedChanged += new System.EventHandler(this.chkUseRemoteHub_CheckedChanged);
            // 
            // grpRemoteConnection
            // 
            this.grpRemoteConnection.Controls.Add(this.lblHubConnectionStatus);
            this.grpRemoteConnection.Controls.Add(this.label2);
            this.grpRemoteConnection.Controls.Add(this.txtRemoteHubUrl);
            this.grpRemoteConnection.Location = new System.Drawing.Point(3, 26);
            this.grpRemoteConnection.Name = "grpRemoteConnection";
            this.grpRemoteConnection.Size = new System.Drawing.Size(558, 100);
            this.grpRemoteConnection.TabIndex = 7;
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
            this.btnStartWebDriver.Location = new System.Drawing.Point(184, 136);
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
            this.ddlBrowserToStart.Location = new System.Drawing.Point(57, 136);
            this.ddlBrowserToStart.Name = "ddlBrowserToStart";
            this.ddlBrowserToStart.Size = new System.Drawing.Size(121, 21);
            this.ddlBrowserToStart.TabIndex = 5;
            // 
            // BrowserSettingsTabView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkUseRemoteHub);
            this.Controls.Add(this.grpRemoteConnection);
            this.Controls.Add(this.btnStartWebDriver);
            this.Controls.Add(this.ddlBrowserToStart);
            this.Name = "BrowserSettingsTabView";
            this.Size = new System.Drawing.Size(572, 193);
            this.grpRemoteConnection.ResumeLayout(false);
            this.grpRemoteConnection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox chkUseRemoteHub;
        public System.Windows.Forms.GroupBox grpRemoteConnection;
        public System.Windows.Forms.Label lblHubConnectionStatus;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtRemoteHubUrl;
        public System.Windows.Forms.Button btnStartWebDriver;
        public System.Windows.Forms.ComboBox ddlBrowserToStart;
    }
}
