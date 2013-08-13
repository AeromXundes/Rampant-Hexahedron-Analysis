namespace RHA
{
    partial class AnalyzerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Path = new System.Windows.Forms.TextBox();
            this.button_Browse = new System.Windows.Forms.Button();
            this.label_ProgressText = new System.Windows.Forms.Label();
            this.button_SpecialConfig = new System.Windows.Forms.Button();
            this.button_StartStop = new System.Windows.Forms.Button();
            this.button_Results = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label_AnalyzerName = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "World Folder:";
            // 
            // textBox_Path
            // 
            this.textBox_Path.Location = new System.Drawing.Point(15, 41);
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.Size = new System.Drawing.Size(275, 20);
            this.textBox_Path.TabIndex = 1;
            this.textBox_Path.TextChanged += new System.EventHandler(this.textBox_Path_TextChanged);
            // 
            // button_Browse
            // 
            this.button_Browse.AutoSize = true;
            this.button_Browse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_Browse.Location = new System.Drawing.Point(296, 39);
            this.button_Browse.Name = "button_Browse";
            this.button_Browse.Size = new System.Drawing.Size(26, 23);
            this.button_Browse.TabIndex = 2;
            this.button_Browse.Text = "...";
            this.button_Browse.UseVisualStyleBackColor = true;
            this.button_Browse.Click += new System.EventHandler(this.button_Browse_Click);
            // 
            // label_ProgressText
            // 
            this.label_ProgressText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ProgressText.AutoEllipsis = true;
            this.label_ProgressText.Location = new System.Drawing.Point(12, 95);
            this.label_ProgressText.Name = "label_ProgressText";
            this.label_ProgressText.Size = new System.Drawing.Size(310, 13);
            this.label_ProgressText.TabIndex = 3;
            this.label_ProgressText.Text = "Progress/Status Text";
            this.label_ProgressText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button_SpecialConfig
            // 
            this.button_SpecialConfig.AutoSize = true;
            this.button_SpecialConfig.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_SpecialConfig.Enabled = false;
            this.button_SpecialConfig.Location = new System.Drawing.Point(228, 12);
            this.button_SpecialConfig.Name = "button_SpecialConfig";
            this.button_SpecialConfig.Size = new System.Drawing.Size(94, 23);
            this.button_SpecialConfig.TabIndex = 4;
            this.button_SpecialConfig.Text = "Special Config...";
            this.button_SpecialConfig.UseVisualStyleBackColor = true;
            this.button_SpecialConfig.Click += new System.EventHandler(this.button_SpecialConfig_Click);
            // 
            // button_StartStop
            // 
            this.button_StartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_StartStop.Location = new System.Drawing.Point(12, 111);
            this.button_StartStop.Name = "button_StartStop";
            this.button_StartStop.Size = new System.Drawing.Size(83, 23);
            this.button_StartStop.TabIndex = 5;
            this.button_StartStop.Text = "Start!";
            this.button_StartStop.UseVisualStyleBackColor = true;
            this.button_StartStop.Click += new System.EventHandler(this.button_StartStop_Click);
            // 
            // button_Results
            // 
            this.button_Results.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Results.Enabled = false;
            this.button_Results.Location = new System.Drawing.Point(125, 111);
            this.button_Results.Name = "button_Results";
            this.button_Results.Size = new System.Drawing.Size(83, 23);
            this.button_Results.TabIndex = 6;
            this.button_Results.Text = "Results";
            this.button_Results.UseVisualStyleBackColor = true;
            this.button_Results.Click += new System.EventHandler(this.button_Results_Click);
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Close.Location = new System.Drawing.Point(238, 111);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(83, 23);
            this.button_Close.TabIndex = 7;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.Location = new System.Drawing.Point(12, 69);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(310, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // label_AnalyzerName
            // 
            this.label_AnalyzerName.AutoEllipsis = true;
            this.label_AnalyzerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_AnalyzerName.Location = new System.Drawing.Point(12, 9);
            this.label_AnalyzerName.Name = "label_AnalyzerName";
            this.label_AnalyzerName.Size = new System.Drawing.Size(210, 16);
            this.label_AnalyzerName.TabIndex = 9;
            this.label_AnalyzerName.Text = "Analyzer Name Here";
            this.label_AnalyzerName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AnalyzerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 146);
            this.Controls.Add(this.label_AnalyzerName);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Results);
            this.Controls.Add(this.button_StartStop);
            this.Controls.Add(this.button_SpecialConfig);
            this.Controls.Add(this.label_ProgressText);
            this.Controls.Add(this.button_Browse);
            this.Controls.Add(this.textBox_Path);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(350, 184);
            this.MinimumSize = new System.Drawing.Size(350, 184);
            this.Name = "AnalyzerForm";
            this.Text = "AnalyzerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnalyzerForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AnalyzerForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Path;
        private System.Windows.Forms.Button button_Browse;
        private System.Windows.Forms.Label label_ProgressText;
        private System.Windows.Forms.Button button_SpecialConfig;
        private System.Windows.Forms.Button button_StartStop;
        private System.Windows.Forms.Button button_Results;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label_AnalyzerName;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}