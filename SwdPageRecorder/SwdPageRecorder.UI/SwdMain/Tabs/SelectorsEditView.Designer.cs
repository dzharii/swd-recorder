namespace SwdPageRecorder.UI
{
    partial class SelectorsEditView
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCopyWebElement = new System.Windows.Forms.Button();
            this.btnHighlightWebElementInBrowser = new System.Windows.Forms.Button();
            this.btnNewWebElement = new System.Windows.Forms.Button();
            this.btnUpdateDeclaration = new System.Windows.Forms.Button();
            this.txtWebElementName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOtherLocator = new System.Windows.Forms.TextBox();
            this.ddlOtherLocator = new System.Windows.Forms.ComboBox();
            this.rbtnOtherLocator = new System.Windows.Forms.RadioButton();
            this.txtHtmlId = new System.Windows.Forms.TextBox();
            this.rbtnHtmlId = new System.Windows.Forms.RadioButton();
            this.txtXPath = new System.Windows.Forms.TextBox();
            this.rbtnXPath = new System.Windows.Forms.RadioButton();
            this.rbtnCssSelector = new System.Windows.Forms.RadioButton();
            this.txtCssSelector = new System.Windows.Forms.TextBox();
            this.tbElementDetails = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnReadElementProperties = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPropHtmlTag = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.tbElementDetails.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnReadElementProperties);
            this.groupBox2.Controls.Add(this.tbElementDetails);
            this.groupBox2.Controls.Add(this.btnCopyWebElement);
            this.groupBox2.Controls.Add(this.btnHighlightWebElementInBrowser);
            this.groupBox2.Controls.Add(this.btnNewWebElement);
            this.groupBox2.Controls.Add(this.btnUpdateDeclaration);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(732, 169);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "WebElement";
            // 
            // btnCopyWebElement
            // 
            this.btnCopyWebElement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyWebElement.Location = new System.Drawing.Point(645, 42);
            this.btnCopyWebElement.Name = "btnCopyWebElement";
            this.btnCopyWebElement.Size = new System.Drawing.Size(85, 23);
            this.btnCopyWebElement.TabIndex = 16;
            this.btnCopyWebElement.Text = "Copy";
            this.btnCopyWebElement.UseVisualStyleBackColor = true;
            this.btnCopyWebElement.Click += new System.EventHandler(this.btnCopyWebElement_Click);
            // 
            // btnHighlightWebElementInBrowser
            // 
            this.btnHighlightWebElementInBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHighlightWebElementInBrowser.Location = new System.Drawing.Point(645, 76);
            this.btnHighlightWebElementInBrowser.Name = "btnHighlightWebElementInBrowser";
            this.btnHighlightWebElementInBrowser.Size = new System.Drawing.Size(85, 23);
            this.btnHighlightWebElementInBrowser.TabIndex = 15;
            this.btnHighlightWebElementInBrowser.Text = "Highlight";
            this.btnHighlightWebElementInBrowser.UseVisualStyleBackColor = true;
            this.btnHighlightWebElementInBrowser.Click += new System.EventHandler(this.btnHighlightWebElementInBrowser_Click);
            // 
            // btnNewWebElement
            // 
            this.btnNewWebElement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewWebElement.Location = new System.Drawing.Point(645, 17);
            this.btnNewWebElement.Name = "btnNewWebElement";
            this.btnNewWebElement.Size = new System.Drawing.Size(85, 23);
            this.btnNewWebElement.TabIndex = 14;
            this.btnNewWebElement.Text = "New";
            this.btnNewWebElement.UseVisualStyleBackColor = true;
            this.btnNewWebElement.Click += new System.EventHandler(this.btnNewWebElement_Click);
            // 
            // btnUpdateDeclaration
            // 
            this.btnUpdateDeclaration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateDeclaration.Location = new System.Drawing.Point(645, 137);
            this.btnUpdateDeclaration.Name = "btnUpdateDeclaration";
            this.btnUpdateDeclaration.Size = new System.Drawing.Size(85, 23);
            this.btnUpdateDeclaration.TabIndex = 13;
            this.btnUpdateDeclaration.Text = "Update >>";
            this.btnUpdateDeclaration.UseVisualStyleBackColor = true;
            this.btnUpdateDeclaration.Click += new System.EventHandler(this.btnUpdateDeclaration_Click);
            // 
            // txtWebElementName
            // 
            this.txtWebElementName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWebElementName.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWebElementName.Location = new System.Drawing.Point(132, 10);
            this.txtWebElementName.Name = "txtWebElementName";
            this.txtWebElementName.Size = new System.Drawing.Size(471, 20);
            this.txtWebElementName.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Name:";
            // 
            // txtOtherLocator
            // 
            this.txtOtherLocator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOtherLocator.Font = new System.Drawing.Font("Lucida Console", 9.75F);
            this.txtOtherLocator.Location = new System.Drawing.Point(132, 112);
            this.txtOtherLocator.Name = "txtOtherLocator";
            this.txtOtherLocator.Size = new System.Drawing.Size(471, 20);
            this.txtOtherLocator.TabIndex = 9;
            this.txtOtherLocator.Enter += new System.EventHandler(this.txtOtherLocator_Enter);
            // 
            // ddlOtherLocator
            // 
            this.ddlOtherLocator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlOtherLocator.FormattingEnabled = true;
            this.ddlOtherLocator.Location = new System.Drawing.Point(25, 112);
            this.ddlOtherLocator.Name = "ddlOtherLocator";
            this.ddlOtherLocator.Size = new System.Drawing.Size(101, 21);
            this.ddlOtherLocator.TabIndex = 8;
            // 
            // rbtnOtherLocator
            // 
            this.rbtnOtherLocator.AutoSize = true;
            this.rbtnOtherLocator.Location = new System.Drawing.Point(7, 116);
            this.rbtnOtherLocator.Name = "rbtnOtherLocator";
            this.rbtnOtherLocator.Size = new System.Drawing.Size(14, 13);
            this.rbtnOtherLocator.TabIndex = 7;
            this.rbtnOtherLocator.TabStop = true;
            this.rbtnOtherLocator.UseVisualStyleBackColor = true;
            // 
            // txtHtmlId
            // 
            this.txtHtmlId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHtmlId.Font = new System.Drawing.Font("Lucida Console", 9.75F);
            this.txtHtmlId.Location = new System.Drawing.Point(132, 36);
            this.txtHtmlId.Name = "txtHtmlId";
            this.txtHtmlId.Size = new System.Drawing.Size(471, 20);
            this.txtHtmlId.TabIndex = 6;
            this.txtHtmlId.Enter += new System.EventHandler(this.txtHtmlId_Enter);
            // 
            // rbtnHtmlId
            // 
            this.rbtnHtmlId.AutoSize = true;
            this.rbtnHtmlId.Checked = true;
            this.rbtnHtmlId.Location = new System.Drawing.Point(7, 41);
            this.rbtnHtmlId.Name = "rbtnHtmlId";
            this.rbtnHtmlId.Size = new System.Drawing.Size(63, 17);
            this.rbtnHtmlId.TabIndex = 5;
            this.rbtnHtmlId.TabStop = true;
            this.rbtnHtmlId.Text = "Html ID:";
            this.rbtnHtmlId.UseVisualStyleBackColor = true;
            // 
            // txtXPath
            // 
            this.txtXPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXPath.Font = new System.Drawing.Font("Lucida Console", 9.75F);
            this.txtXPath.Location = new System.Drawing.Point(132, 84);
            this.txtXPath.Name = "txtXPath";
            this.txtXPath.Size = new System.Drawing.Size(471, 20);
            this.txtXPath.TabIndex = 4;
            this.txtXPath.Enter += new System.EventHandler(this.txtXPath_Enter);
            // 
            // rbtnXPath
            // 
            this.rbtnXPath.AutoSize = true;
            this.rbtnXPath.Location = new System.Drawing.Point(7, 87);
            this.rbtnXPath.Name = "rbtnXPath";
            this.rbtnXPath.Size = new System.Drawing.Size(57, 17);
            this.rbtnXPath.TabIndex = 3;
            this.rbtnXPath.Text = "XPath:";
            this.rbtnXPath.UseVisualStyleBackColor = true;
            // 
            // rbtnCssSelector
            // 
            this.rbtnCssSelector.AutoSize = true;
            this.rbtnCssSelector.Location = new System.Drawing.Point(7, 64);
            this.rbtnCssSelector.Name = "rbtnCssSelector";
            this.rbtnCssSelector.Size = new System.Drawing.Size(87, 17);
            this.rbtnCssSelector.TabIndex = 2;
            this.rbtnCssSelector.Text = "Css Selector:";
            this.rbtnCssSelector.UseVisualStyleBackColor = true;
            // 
            // txtCssSelector
            // 
            this.txtCssSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCssSelector.Font = new System.Drawing.Font("Lucida Console", 9.75F);
            this.txtCssSelector.Location = new System.Drawing.Point(132, 61);
            this.txtCssSelector.Name = "txtCssSelector";
            this.txtCssSelector.Size = new System.Drawing.Size(471, 20);
            this.txtCssSelector.TabIndex = 1;
            this.txtCssSelector.Enter += new System.EventHandler(this.txtCssSelector_Enter);
            // 
            // tbElementDetails
            // 
            this.tbElementDetails.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tbElementDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbElementDetails.Controls.Add(this.tabPage1);
            this.tbElementDetails.Controls.Add(this.tabPage2);
            this.tbElementDetails.Location = new System.Drawing.Point(3, 14);
            this.tbElementDetails.Multiline = true;
            this.tbElementDetails.Name = "tbElementDetails";
            this.tbElementDetails.SelectedIndex = 0;
            this.tbElementDetails.Size = new System.Drawing.Size(636, 149);
            this.tbElementDetails.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtCssSelector);
            this.tabPage1.Controls.Add(this.rbtnCssSelector);
            this.tabPage1.Controls.Add(this.rbtnXPath);
            this.tabPage1.Controls.Add(this.txtXPath);
            this.tabPage1.Controls.Add(this.txtWebElementName);
            this.tabPage1.Controls.Add(this.rbtnHtmlId);
            this.tabPage1.Controls.Add(this.txtHtmlId);
            this.tabPage1.Controls.Add(this.txtOtherLocator);
            this.tabPage1.Controls.Add(this.rbtnOtherLocator);
            this.tabPage1.Controls.Add(this.ddlOtherLocator);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(609, 141);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Selectors";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtPropHtmlTag);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(609, 141);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Properties";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnReadElementProperties
            // 
            this.btnReadElementProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadElementProperties.Location = new System.Drawing.Point(645, 103);
            this.btnReadElementProperties.Name = "btnReadElementProperties";
            this.btnReadElementProperties.Size = new System.Drawing.Size(85, 23);
            this.btnReadElementProperties.TabIndex = 18;
            this.btnReadElementProperties.Text = "<< Read Prop.";
            this.btnReadElementProperties.UseVisualStyleBackColor = true;
            this.btnReadElementProperties.Click += new System.EventHandler(this.btnReadElementProperties_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Html Tag:";
            // 
            // txtPropHtmlTag
            // 
            this.txtPropHtmlTag.Location = new System.Drawing.Point(66, 10);
            this.txtPropHtmlTag.Name = "txtPropHtmlTag";
            this.txtPropHtmlTag.Size = new System.Drawing.Size(64, 20);
            this.txtPropHtmlTag.TabIndex = 1;
            // 
            // SelectorsEditView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox2);
            this.Name = "SelectorsEditView";
            this.Size = new System.Drawing.Size(736, 175);
            this.groupBox2.ResumeLayout(false);
            this.tbElementDetails.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button btnCopyWebElement;
        public System.Windows.Forms.Button btnHighlightWebElementInBrowser;
        public System.Windows.Forms.Button btnNewWebElement;
        public System.Windows.Forms.Button btnUpdateDeclaration;
        public System.Windows.Forms.TextBox txtWebElementName;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtOtherLocator;
        public System.Windows.Forms.ComboBox ddlOtherLocator;
        public System.Windows.Forms.RadioButton rbtnOtherLocator;
        public System.Windows.Forms.TextBox txtHtmlId;
        public System.Windows.Forms.RadioButton rbtnHtmlId;
        public System.Windows.Forms.TextBox txtXPath;
        public System.Windows.Forms.RadioButton rbtnXPath;
        public System.Windows.Forms.RadioButton rbtnCssSelector;
        public System.Windows.Forms.TextBox txtCssSelector;
        public System.Windows.Forms.TabControl tbElementDetails;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.Button btnReadElementProperties;
        private System.Windows.Forms.TextBox txtPropHtmlTag;
        private System.Windows.Forms.Label label2;
    }
}
