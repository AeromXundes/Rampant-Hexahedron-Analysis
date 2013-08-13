namespace RHA
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Analyzers = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Info_RequiresSpecialConfig = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.linkLabel_Info_Url = new System.Windows.Forms.LinkLabel();
            this.textBox_Info_Additional = new System.Windows.Forms.TextBox();
            this.textBox_Info_Description = new System.Windows.Forms.TextBox();
            this.textBox_Info_Authors = new System.Windows.Forms.TextBox();
            this.textBox_Info_Version = new System.Windows.Forms.TextBox();
            this.textBox_Info_Name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_UseAnalyzer = new System.Windows.Forms.Button();
            this.button_About = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Analyzers available:";
            // 
            // comboBox_Analyzers
            // 
            this.comboBox_Analyzers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Analyzers.FormattingEnabled = true;
            this.comboBox_Analyzers.Location = new System.Drawing.Point(12, 25);
            this.comboBox_Analyzers.Name = "comboBox_Analyzers";
            this.comboBox_Analyzers.Size = new System.Drawing.Size(167, 21);
            this.comboBox_Analyzers.TabIndex = 2;
            this.comboBox_Analyzers.SelectedIndexChanged += new System.EventHandler(this.comboBox_Analyzers_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBox_Info_RequiresSpecialConfig);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.linkLabel_Info_Url);
            this.groupBox1.Controls.Add(this.textBox_Info_Additional);
            this.groupBox1.Controls.Add(this.textBox_Info_Description);
            this.groupBox1.Controls.Add(this.textBox_Info_Authors);
            this.groupBox1.Controls.Add(this.textBox_Info_Version);
            this.groupBox1.Controls.Add(this.textBox_Info_Name);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(185, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 240);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Analyzer Info";
            // 
            // textBox_Info_RequiresSpecialConfig
            // 
            this.textBox_Info_RequiresSpecialConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox_Info_RequiresSpecialConfig.Location = new System.Drawing.Point(139, 214);
            this.textBox_Info_RequiresSpecialConfig.Name = "textBox_Info_RequiresSpecialConfig";
            this.textBox_Info_RequiresSpecialConfig.ReadOnly = true;
            this.textBox_Info_RequiresSpecialConfig.Size = new System.Drawing.Size(32, 20);
            this.textBox_Info_RequiresSpecialConfig.TabIndex = 13;
            this.textBox_Info_RequiresSpecialConfig.Text = "No";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Requires Special Config?";
            // 
            // linkLabel_Info_Url
            // 
            this.linkLabel_Info_Url.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel_Info_Url.AutoSize = true;
            this.linkLabel_Info_Url.Location = new System.Drawing.Point(80, 192);
            this.linkLabel_Info_Url.Name = "linkLabel_Info_Url";
            this.linkLabel_Info_Url.Size = new System.Drawing.Size(0, 13);
            this.linkLabel_Info_Url.TabIndex = 11;
            this.linkLabel_Info_Url.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_Info_Url_LinkClicked);
            // 
            // textBox_Info_Additional
            // 
            this.textBox_Info_Additional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Info_Additional.Location = new System.Drawing.Point(83, 127);
            this.textBox_Info_Additional.Multiline = true;
            this.textBox_Info_Additional.Name = "textBox_Info_Additional";
            this.textBox_Info_Additional.ReadOnly = true;
            this.textBox_Info_Additional.Size = new System.Drawing.Size(98, 62);
            this.textBox_Info_Additional.TabIndex = 10;
            // 
            // textBox_Info_Description
            // 
            this.textBox_Info_Description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Info_Description.Location = new System.Drawing.Point(83, 97);
            this.textBox_Info_Description.Multiline = true;
            this.textBox_Info_Description.Name = "textBox_Info_Description";
            this.textBox_Info_Description.ReadOnly = true;
            this.textBox_Info_Description.Size = new System.Drawing.Size(98, 24);
            this.textBox_Info_Description.TabIndex = 9;
            // 
            // textBox_Info_Authors
            // 
            this.textBox_Info_Authors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Info_Authors.Location = new System.Drawing.Point(83, 71);
            this.textBox_Info_Authors.Name = "textBox_Info_Authors";
            this.textBox_Info_Authors.ReadOnly = true;
            this.textBox_Info_Authors.Size = new System.Drawing.Size(98, 20);
            this.textBox_Info_Authors.TabIndex = 8;
            // 
            // textBox_Info_Version
            // 
            this.textBox_Info_Version.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Info_Version.Location = new System.Drawing.Point(83, 45);
            this.textBox_Info_Version.Name = "textBox_Info_Version";
            this.textBox_Info_Version.ReadOnly = true;
            this.textBox_Info_Version.Size = new System.Drawing.Size(98, 20);
            this.textBox_Info_Version.TabIndex = 7;
            // 
            // textBox_Info_Name
            // 
            this.textBox_Info_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Info_Name.Location = new System.Drawing.Point(83, 19);
            this.textBox_Info_Name.Name = "textBox_Info_Name";
            this.textBox_Info_Name.ReadOnly = true;
            this.textBox_Info_Name.Size = new System.Drawing.Size(98, 20);
            this.textBox_Info_Name.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Url:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Additional Info:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Author(s):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // button_UseAnalyzer
            // 
            this.button_UseAnalyzer.Enabled = false;
            this.button_UseAnalyzer.Location = new System.Drawing.Point(12, 52);
            this.button_UseAnalyzer.Name = "button_UseAnalyzer";
            this.button_UseAnalyzer.Size = new System.Drawing.Size(75, 23);
            this.button_UseAnalyzer.TabIndex = 5;
            this.button_UseAnalyzer.Text = "Use!";
            this.button_UseAnalyzer.UseVisualStyleBackColor = true;
            this.button_UseAnalyzer.Click += new System.EventHandler(this.button_UseAnalyzer_Click);
            // 
            // button_About
            // 
            this.button_About.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_About.Location = new System.Drawing.Point(12, 227);
            this.button_About.Name = "button_About";
            this.button_About.Size = new System.Drawing.Size(75, 23);
            this.button_About.TabIndex = 6;
            this.button_About.Text = "About";
            this.button_About.UseVisualStyleBackColor = true;
            this.button_About.Click += new System.EventHandler(this.button_About_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.button_About);
            this.Controls.Add(this.button_UseAnalyzer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox_Analyzers);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "MainForm";
            this.Text = "Rampant Hexahedron Analysis";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Analyzers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Info_RequiresSpecialConfig;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkLabel_Info_Url;
        private System.Windows.Forms.TextBox textBox_Info_Additional;
        private System.Windows.Forms.TextBox textBox_Info_Description;
        private System.Windows.Forms.TextBox textBox_Info_Authors;
        private System.Windows.Forms.TextBox textBox_Info_Version;
        private System.Windows.Forms.TextBox textBox_Info_Name;
        private System.Windows.Forms.Button button_UseAnalyzer;
        private System.Windows.Forms.Button button_About;
    }
}