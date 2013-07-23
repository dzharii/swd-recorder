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
            this.btnReadElementProperties = new System.Windows.Forms.Button();
            this.tbElementDetails = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCssSelector = new System.Windows.Forms.TextBox();
            this.rbtnCssSelector = new System.Windows.Forms.RadioButton();
            this.rbtnXPath = new System.Windows.Forms.RadioButton();
            this.txtXPath = new System.Windows.Forms.TextBox();
            this.txtWebElementName = new System.Windows.Forms.TextBox();
            this.rbtnHtmlId = new System.Windows.Forms.RadioButton();
            this.txtHtmlId = new System.Windows.Forms.TextBox();
            this.txtOtherLocator = new System.Windows.Forms.TextBox();
            this.rbtnOtherLocator = new System.Windows.Forms.RadioButton();
            this.ddlOtherLocator = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtHtmlElementFrameId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.btnEditAllElementHtmlProps = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAllElementHtmlProps = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPropArg3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPropArg2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPropArg1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPropHtmlTag = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCopyWebElement = new System.Windows.Forms.Button();
            this.btnHighlightWebElementInBrowser = new System.Windows.Forms.Button();
            this.btnNewWebElement = new System.Windows.Forms.Button();
            this.btnUpdateDeclaration = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.tbElementDetails.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Name:";
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
            // ddlOtherLocator
            // 
            this.ddlOtherLocator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlOtherLocator.FormattingEnabled = true;
            this.ddlOtherLocator.Location = new System.Drawing.Point(25, 112);
            this.ddlOtherLocator.Name = "ddlOtherLocator";
            this.ddlOtherLocator.Size = new System.Drawing.Size(101, 21);
            this.ddlOtherLocator.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtHtmlElementFrameId);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.textBox7);
            this.tabPage2.Controls.Add(this.btnEditAllElementHtmlProps);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtAllElementHtmlProps);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.groupBox1);
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
            // txtHtmlElementFrameId
            // 
            this.txtHtmlElementFrameId.Enabled = false;
            this.txtHtmlElementFrameId.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHtmlElementFrameId.Location = new System.Drawing.Point(9, 115);
            this.txtHtmlElementFrameId.Name = "txtHtmlElementFrameId";
            this.txtHtmlElementFrameId.Size = new System.Drawing.Size(292, 20);
            this.txtHtmlElementFrameId.TabIndex = 18;
            this.txtHtmlElementFrameId.Text = "not implemented";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(9, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "HTML Frame ID:";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(554, 113);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Location = new System.Drawing.Point(318, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Alternative (OR) FindsBy";
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.Enabled = false;
            this.textBox7.Font = new System.Drawing.Font("Lucida Console", 9.75F);
            this.textBox7.Location = new System.Drawing.Point(312, 115);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(238, 20);
            this.textBox7.TabIndex = 18;
            this.textBox7.Text = "not implemented";
            // 
            // btnEditAllElementHtmlProps
            // 
            this.btnEditAllElementHtmlProps.Enabled = false;
            this.btnEditAllElementHtmlProps.Location = new System.Drawing.Point(254, 70);
            this.btnEditAllElementHtmlProps.Name = "btnEditAllElementHtmlProps";
            this.btnEditAllElementHtmlProps.Size = new System.Drawing.Size(47, 23);
            this.btnEditAllElementHtmlProps.TabIndex = 17;
            this.btnEditAllElementHtmlProps.Text = "Edit";
            this.btnEditAllElementHtmlProps.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(9, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "All HTML Element properties:";
            // 
            // txtAllElementHtmlProps
            // 
            this.txtAllElementHtmlProps.Enabled = false;
            this.txtAllElementHtmlProps.Font = new System.Drawing.Font("Lucida Console", 9.75F);
            this.txtAllElementHtmlProps.Location = new System.Drawing.Point(9, 72);
            this.txtAllElementHtmlProps.Name = "txtAllElementHtmlProps";
            this.txtAllElementHtmlProps.Size = new System.Drawing.Size(239, 20);
            this.txtAllElementHtmlProps.TabIndex = 15;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(9, 33);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(263, 17);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Selector returns Array of WebElements (Collection)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtPropArg3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPropArg2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPropArg1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(312, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 91);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Custom Arguments (Parameters)";
            // 
            // txtPropArg3
            // 
            this.txtPropArg3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPropArg3.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPropArg3.Location = new System.Drawing.Point(41, 63);
            this.txtPropArg3.Name = "txtPropArg3";
            this.txtPropArg3.Size = new System.Drawing.Size(244, 20);
            this.txtPropArg3.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Arg3";
            // 
            // txtPropArg2
            // 
            this.txtPropArg2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPropArg2.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPropArg2.Location = new System.Drawing.Point(41, 41);
            this.txtPropArg2.Name = "txtPropArg2";
            this.txtPropArg2.Size = new System.Drawing.Size(244, 20);
            this.txtPropArg2.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Arg2";
            // 
            // txtPropArg1
            // 
            this.txtPropArg1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPropArg1.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPropArg1.Location = new System.Drawing.Point(41, 19);
            this.txtPropArg1.Name = "txtPropArg1";
            this.txtPropArg1.Size = new System.Drawing.Size(244, 20);
            this.txtPropArg1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Arg1";
            // 
            // txtPropHtmlTag
            // 
            this.txtPropHtmlTag.Font = new System.Drawing.Font("Lucida Console", 9.75F);
            this.txtPropHtmlTag.Location = new System.Drawing.Point(66, 7);
            this.txtPropHtmlTag.Name = "txtPropHtmlTag";
            this.txtPropHtmlTag.Size = new System.Drawing.Size(235, 20);
            this.txtPropHtmlTag.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Html Tag:";
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtPropArg1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtPropArg3;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtPropArg2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button btnEditAllElementHtmlProps;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAllElementHtmlProps;
        public System.Windows.Forms.TextBox txtHtmlElementFrameId;
        private System.Windows.Forms.Label label6;
    }
}
