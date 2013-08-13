namespace RHA.Analyzers.BlockTypeCount
{
    partial class BlockTypeCountResultsForm
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
            this.objectListView_ResultDataList = new BrightIdeasSoftware.ObjectListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_UniqueBlocks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_ChunksAnalyzed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_TotalBlocks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.objectListView_ResultDataList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // objectListView_ResultDataList
            // 
            this.objectListView_ResultDataList.AllColumns.Add(this.olvColumn3);
            this.objectListView_ResultDataList.AllColumns.Add(this.olvColumn1);
            this.objectListView_ResultDataList.AllColumns.Add(this.olvColumn2);
            this.objectListView_ResultDataList.AllColumns.Add(this.olvColumn4);
            this.objectListView_ResultDataList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListView_ResultDataList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn3,
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn4});
            this.objectListView_ResultDataList.FullRowSelect = true;
            this.objectListView_ResultDataList.GridLines = true;
            this.objectListView_ResultDataList.Location = new System.Drawing.Point(12, 12);
            this.objectListView_ResultDataList.Name = "objectListView_ResultDataList";
            this.objectListView_ResultDataList.ShowGroups = false;
            this.objectListView_ResultDataList.Size = new System.Drawing.Size(447, 313);
            this.objectListView_ResultDataList.TabIndex = 0;
            this.objectListView_ResultDataList.UseCompatibleStateImageBehavior = false;
            this.objectListView_ResultDataList.View = System.Windows.Forms.View.Details;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBox_UniqueBlocks);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_ChunksAnalyzed);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_TotalBlocks);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 331);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // textBox_UniqueBlocks
            // 
            this.textBox_UniqueBlocks.Location = new System.Drawing.Point(104, 45);
            this.textBox_UniqueBlocks.Name = "textBox_UniqueBlocks";
            this.textBox_UniqueBlocks.ReadOnly = true;
            this.textBox_UniqueBlocks.Size = new System.Drawing.Size(100, 20);
            this.textBox_UniqueBlocks.TabIndex = 5;
            this.textBox_UniqueBlocks.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Unique Blocks:";
            // 
            // textBox_ChunksAnalyzed
            // 
            this.textBox_ChunksAnalyzed.Location = new System.Drawing.Point(104, 71);
            this.textBox_ChunksAnalyzed.Name = "textBox_ChunksAnalyzed";
            this.textBox_ChunksAnalyzed.ReadOnly = true;
            this.textBox_ChunksAnalyzed.Size = new System.Drawing.Size(100, 20);
            this.textBox_ChunksAnalyzed.TabIndex = 3;
            this.textBox_ChunksAnalyzed.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chunks Analyzed:";
            // 
            // textBox_TotalBlocks
            // 
            this.textBox_TotalBlocks.Location = new System.Drawing.Point(104, 19);
            this.textBox_TotalBlocks.Name = "textBox_TotalBlocks";
            this.textBox_TotalBlocks.ReadOnly = true;
            this.textBox_TotalBlocks.Size = new System.Drawing.Size(100, 20);
            this.textBox_TotalBlocks.TabIndex = 1;
            this.textBox_TotalBlocks.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Blocks:";
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Data";
            this.olvColumn1.Text = "Data";
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Count";
            this.olvColumn2.AspectToStringFormat = "";
            this.olvColumn2.Text = "Count";
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Id";
            this.olvColumn3.DisplayIndex = 1;
            this.olvColumn3.Text = "Id";
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "Name";
            this.olvColumn4.Text = "Name";
            // 
            // BlockTypeCountResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 443);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.objectListView_ResultDataList);
            this.Name = "BlockTypeCountResultsForm";
            this.Text = "BlockTypeCountResultsForm";
            ((System.ComponentModel.ISupportInitialize)(this.objectListView_ResultDataList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView objectListView_ResultDataList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_UniqueBlocks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ChunksAnalyzed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_TotalBlocks;
        private System.Windows.Forms.Label label1;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
    }
}