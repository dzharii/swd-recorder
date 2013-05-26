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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnStartWebDriver = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbElements = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
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
            this.tabControl1.Location = new System.Drawing.Point(12, 57);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(578, 423);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnStartWebDriver);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(570, 397);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Browser Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnStartWebDriver
            // 
            this.btnStartWebDriver.Location = new System.Drawing.Point(151, 7);
            this.btnStartWebDriver.Name = "btnStartWebDriver";
            this.btnStartWebDriver.Size = new System.Drawing.Size(75, 23);
            this.btnStartWebDriver.TabIndex = 1;
            this.btnStartWebDriver.Text = "Start";
            this.btnStartWebDriver.UseVisualStyleBackColor = true;
            this.btnStartWebDriver.Click += new System.EventHandler(this.btnStartWebDriver_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "FireFox",
            "Internet Explorer"});
            this.comboBox1.Location = new System.Drawing.Point(23, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
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
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.textBox1);
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
            // txtOtherLocator
            // 
            this.txtOtherLocator.Location = new System.Drawing.Point(132, 115);
            this.txtOtherLocator.Name = "txtOtherLocator";
            this.txtOtherLocator.Size = new System.Drawing.Size(401, 20);
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
            this.txtHtmlId.Size = new System.Drawing.Size(401, 20);
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
            this.txtXPath.Size = new System.Drawing.Size(401, 20);
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
            this.txtCssSelector.Size = new System.Drawing.Size(401, 20);
            this.txtCssSelector.TabIndex = 1;
            this.txtCssSelector.Enter += new System.EventHandler(this.txtCssSelector_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.propertyGrid1);
            this.groupBox4.Controls.Add(this.listBox1);
            this.groupBox4.Location = new System.Drawing.Point(592, 79);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(237, 397);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(225, 95);
            this.listBox1.TabIndex = 0;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(6, 120);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(225, 271);
            this.propertyGrid1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Awesome source code identifier:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(177, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(277, 20);
            this.textBox1.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(461, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox comboBox1;
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
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;

    }
}

