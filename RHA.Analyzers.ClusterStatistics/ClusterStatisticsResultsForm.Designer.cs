namespace ClusterStatistics
{
    partial class ClusterStatisticsResultsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClusterStatisticsResultsForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_AvgLenZ = new System.Windows.Forms.Label();
            this.label_AvgLenY = new System.Windows.Forms.Label();
            this.label_AvgLenX = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label_BlocksPerChunk = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label_ClustersPerChunk = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label_BlocksPercluster = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_NumClusters = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_NumChunks = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Ids = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_NumBlocks = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_CentroidLoc = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ilPanel_clusterVisual = new ILNumerics.Drawing.ILPanel();
            this.listBox_clusters = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ilPanel_ClusterHeatMap = new ILNumerics.Drawing.ILPanel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(513, 408);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label_BlocksPerChunk);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label_ClustersPerChunk);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label_BlocksPercluster);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label_NumClusters);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label_NumChunks);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox_Ids);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(505, 382);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General Stats";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_AvgLenZ);
            this.groupBox1.Controls.Add(this.label_AvgLenY);
            this.groupBox1.Controls.Add(this.label_AvgLenX);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(11, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 65);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Average Cluster Length";
            // 
            // label_AvgLenZ
            // 
            this.label_AvgLenZ.AutoSize = true;
            this.label_AvgLenZ.Location = new System.Drawing.Point(29, 42);
            this.label_AvgLenZ.Name = "label_AvgLenZ";
            this.label_AvgLenZ.Size = new System.Drawing.Size(41, 13);
            this.label_AvgLenZ.TabIndex = 5;
            this.label_AvgLenZ.Text = "label17";
            // 
            // label_AvgLenY
            // 
            this.label_AvgLenY.AutoSize = true;
            this.label_AvgLenY.Location = new System.Drawing.Point(29, 29);
            this.label_AvgLenY.Name = "label_AvgLenY";
            this.label_AvgLenY.Size = new System.Drawing.Size(41, 13);
            this.label_AvgLenY.TabIndex = 4;
            this.label_AvgLenY.Text = "label16";
            // 
            // label_AvgLenX
            // 
            this.label_AvgLenX.AutoSize = true;
            this.label_AvgLenX.Location = new System.Drawing.Point(29, 16);
            this.label_AvgLenX.Name = "label_AvgLenX";
            this.label_AvgLenX.Size = new System.Drawing.Size(41, 13);
            this.label_AvgLenX.TabIndex = 3;
            this.label_AvgLenX.Text = "label15";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Z:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Y:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "X:";
            // 
            // label_BlocksPerChunk
            // 
            this.label_BlocksPerChunk.AutoSize = true;
            this.label_BlocksPerChunk.Location = new System.Drawing.Point(94, 121);
            this.label_BlocksPerChunk.Name = "label_BlocksPerChunk";
            this.label_BlocksPerChunk.Size = new System.Drawing.Size(114, 13);
            this.label_BlocksPerChunk.TabIndex = 11;
            this.label_BlocksPerChunk.Text = "label_BlocksPerChunk";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Blocks/Chunk:";
            // 
            // label_ClustersPerChunk
            // 
            this.label_ClustersPerChunk.AutoSize = true;
            this.label_ClustersPerChunk.Location = new System.Drawing.Point(94, 98);
            this.label_ClustersPerChunk.Name = "label_ClustersPerChunk";
            this.label_ClustersPerChunk.Size = new System.Drawing.Size(119, 13);
            this.label_ClustersPerChunk.TabIndex = 9;
            this.label_ClustersPerChunk.Text = "label_ClustersPerChunk";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Clusters/Chunk:";
            // 
            // label_BlocksPercluster
            // 
            this.label_BlocksPercluster.AutoSize = true;
            this.label_BlocksPercluster.Location = new System.Drawing.Point(94, 75);
            this.label_BlocksPercluster.Name = "label_BlocksPercluster";
            this.label_BlocksPercluster.Size = new System.Drawing.Size(115, 13);
            this.label_BlocksPercluster.TabIndex = 7;
            this.label_BlocksPercluster.Text = "label_BlocksPerCluster";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Blocks/Cluster:";
            // 
            // label_NumClusters
            // 
            this.label_NumClusters.AutoSize = true;
            this.label_NumClusters.Location = new System.Drawing.Point(94, 52);
            this.label_NumClusters.Name = "label_NumClusters";
            this.label_NumClusters.Size = new System.Drawing.Size(94, 13);
            this.label_NumClusters.TabIndex = 5;
            this.label_NumClusters.Text = "label_NumClusters";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "# Clusters:";
            // 
            // label_NumChunks
            // 
            this.label_NumChunks.AutoSize = true;
            this.label_NumChunks.Location = new System.Drawing.Point(94, 29);
            this.label_NumChunks.Name = "label_NumChunks";
            this.label_NumChunks.Size = new System.Drawing.Size(93, 13);
            this.label_NumChunks.TabIndex = 3;
            this.label_NumChunks.Text = "label_NumChunks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "# Chunks:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id:Data Pairs:";
            // 
            // textBox_Ids
            // 
            this.textBox_Ids.Location = new System.Drawing.Point(97, 6);
            this.textBox_Ids.Name = "textBox_Ids";
            this.textBox_Ids.Size = new System.Drawing.Size(100, 20);
            this.textBox_Ids.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.ilPanel_clusterVisual);
            this.tabPage2.Controls.Add(this.listBox_clusters);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(505, 382);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cluster Visualization";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label_NumBlocks);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label_CentroidLoc);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(123, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 49);
            this.panel1.TabIndex = 2;
            // 
            // label_NumBlocks
            // 
            this.label_NumBlocks.AutoSize = true;
            this.label_NumBlocks.Location = new System.Drawing.Point(97, 28);
            this.label_NumBlocks.Name = "label_NumBlocks";
            this.label_NumBlocks.Size = new System.Drawing.Size(89, 13);
            this.label_NumBlocks.TabIndex = 3;
            this.label_NumBlocks.Text = "label_NumBlocks";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "# Blocks:";
            // 
            // label_CentroidLoc
            // 
            this.label_CentroidLoc.AutoSize = true;
            this.label_CentroidLoc.Location = new System.Drawing.Point(97, 10);
            this.label_CentroidLoc.Name = "label_CentroidLoc";
            this.label_CentroidLoc.Size = new System.Drawing.Size(92, 13);
            this.label_CentroidLoc.TabIndex = 1;
            this.label_CentroidLoc.Text = "label_CentroidLoc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Centroid (X,Y,Z):";
            // 
            // ilPanel_clusterVisual
            // 
            this.ilPanel_clusterVisual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ilPanel_clusterVisual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ilPanel_clusterVisual.Driver = ILNumerics.Drawing.RendererTypes.OpenGL;
            this.ilPanel_clusterVisual.Editor = null;
            this.ilPanel_clusterVisual.Location = new System.Drawing.Point(123, 3);
            this.ilPanel_clusterVisual.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ilPanel_clusterVisual.Name = "ilPanel_clusterVisual";
            this.ilPanel_clusterVisual.Rectangle = ((System.Drawing.RectangleF)(resources.GetObject("ilPanel_clusterVisual.Rectangle")));
            this.ilPanel_clusterVisual.ShowUIControls = false;
            this.ilPanel_clusterVisual.Size = new System.Drawing.Size(379, 376);
            this.ilPanel_clusterVisual.TabIndex = 1;
            // 
            // listBox_clusters
            // 
            this.listBox_clusters.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox_clusters.FormattingEnabled = true;
            this.listBox_clusters.Location = new System.Drawing.Point(3, 3);
            this.listBox_clusters.Name = "listBox_clusters";
            this.listBox_clusters.Size = new System.Drawing.Size(120, 376);
            this.listBox_clusters.TabIndex = 0;
            this.listBox_clusters.SelectedIndexChanged += new System.EventHandler(this.listBox_clusters_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ilPanel_ClusterHeatMap);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(505, 382);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Heat Map";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ilPanel_ClusterHeatMap
            // 
            this.ilPanel_ClusterHeatMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ilPanel_ClusterHeatMap.Driver = ILNumerics.Drawing.RendererTypes.OpenGL;
            this.ilPanel_ClusterHeatMap.Editor = null;
            this.ilPanel_ClusterHeatMap.Location = new System.Drawing.Point(3, 3);
            this.ilPanel_ClusterHeatMap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ilPanel_ClusterHeatMap.Name = "ilPanel_ClusterHeatMap";
            this.ilPanel_ClusterHeatMap.Rectangle = ((System.Drawing.RectangleF)(resources.GetObject("ilPanel_ClusterHeatMap.Rectangle")));
            this.ilPanel_ClusterHeatMap.ShowUIControls = false;
            this.ilPanel_ClusterHeatMap.Size = new System.Drawing.Size(499, 376);
            this.ilPanel_ClusterHeatMap.TabIndex = 0;
            this.ilPanel_ClusterHeatMap.Load += new System.EventHandler(this.ilPanel_ClusterHeatMap_Load);
            // 
            // ClusterStatisticsResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 408);
            this.Controls.Add(this.tabControl1);
            this.Name = "ClusterStatisticsResultsForm";
            this.Text = "ClusterStatisticsResultsForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_AvgLenZ;
        private System.Windows.Forms.Label label_AvgLenY;
        private System.Windows.Forms.Label label_AvgLenX;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label_BlocksPerChunk;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label_ClustersPerChunk;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_BlocksPercluster;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_NumClusters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_NumChunks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Ids;
        private ILNumerics.Drawing.ILPanel ilPanel_clusterVisual;
        private System.Windows.Forms.ListBox listBox_clusters;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_NumBlocks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_CentroidLoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage3;
        private ILNumerics.Drawing.ILPanel ilPanel_ClusterHeatMap;
    }
}