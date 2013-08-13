namespace RHA.Analyzers.DummyAnalyzers.TestAnalyzer
{
    partial class TestAnalyzerResultsForm
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
            this.textBox_Progress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_State = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Progress:";
            // 
            // textBox_Progress
            // 
            this.textBox_Progress.Location = new System.Drawing.Point(79, 12);
            this.textBox_Progress.Name = "textBox_Progress";
            this.textBox_Progress.ReadOnly = true;
            this.textBox_Progress.Size = new System.Drawing.Size(100, 20);
            this.textBox_Progress.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "State:";
            // 
            // textBox_State
            // 
            this.textBox_State.Location = new System.Drawing.Point(79, 38);
            this.textBox_State.Name = "textBox_State";
            this.textBox_State.ReadOnly = true;
            this.textBox_State.Size = new System.Drawing.Size(100, 20);
            this.textBox_State.TabIndex = 3;
            // 
            // TestAnalyzerResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 109);
            this.Controls.Add(this.textBox_State);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Progress);
            this.Controls.Add(this.label1);
            this.Name = "TestAnalyzerResultsForm";
            this.Text = "TestAnalyzerResultsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Progress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_State;
    }
}