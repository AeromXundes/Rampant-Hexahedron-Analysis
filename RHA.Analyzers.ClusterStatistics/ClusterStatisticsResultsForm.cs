using ILNumerics.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClusterStatistics
{
    public partial class ClusterStatisticsResultsForm : Form
    {
        public ClusterStatisticsResultsForm(AggregateClusterStats Stats)
        {
            InitializeComponent();
            this.Stats = Stats;
            this.initStats();
        }
        private AggregateClusterStats Stats;

        private void initStats()
        {
            string txt = string.Empty;
            foreach (HashSet<RHA.Analyzers.DataPoints.Blocks.Block_BasicInfo> set in this.Stats.Ids)
            {
                foreach (RHA.Analyzers.DataPoints.Blocks.Block_BasicInfo block in set)
                {
                    txt += ((block.Id.HasValue) ? block.Id.ToString() : string.Empty) + ":" + ((block.Data.HasValue) ? block.Data.Value.ToString() : String.Empty);
                }
                txt += ";";
            }
            this.textBox_Ids.Text = txt;

            this.label_AvgLenX.Text = Stats.ClusterXLengthAvg.ToString();
            this.label_AvgLenY.Text = Stats.ClusterYLengthAvg.ToString();
            this.label_AvgLenZ.Text = Stats.ClusterZLengthAvg.ToString();

            this.label_BlocksPerChunk.Text = Stats.BlocksPerChunkAvg.ToString();
            this.label_BlocksPercluster.Text = Stats.BlocksPerClusterAvg.ToString();
            this.label_ClustersPerChunk.Text = Stats.ClustersPerChunkAvg.ToString();

            this.label_NumChunks.Text = Stats.ChunkMap.Count.ToString();
            this.label_NumClusters.Text = Stats.Clusters.Count.ToString();

            int i = 1;
            foreach (ClusterDataPoint cluster in Stats.Clusters)
            {
                this.listBox_clusters.Items.Add(new ClusterItem(cluster, "Cluster " + i.ToString()));
                i++;
            }
        }

        private void listBox_clusters_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClusterItem curItem = (ClusterItem)listBox_clusters.SelectedItem;
            RenderCluster(curItem.Cluster);
        }

        private void RenderCluster(ClusterDataPoint cluster)
        {
            var scene = new ILScene();

            foreach (var MCBlock in cluster.Blocks)
            {
                Block3D ILBlock = new Block3D((double)MCBlock.XWorld, (double)MCBlock.YWorld, (double)MCBlock.ZWorld, Color.Blue);
                scene.Camera.Add(ILBlock);
            }
            scene.Camera.Add(new Block3D(0, 0, 0, Color.Red));
            //scene.Camera.LookAt = new Vector3((float)cluster.CentroidBlock.XWorld, (float)cluster.CentroidBlock.YWorld, (float)cluster.CentroidBlock.ZWorld);
            this.ilPanel_clusterVisual.Scene = scene;
            this.ilPanel_clusterVisual.Update();
        }
    }

    class ClusterItem
    {
        public ClusterItem(ClusterDataPoint cluster, String name)
        {
            this.Cluster = cluster;
            this.Name = name;
        }
        public ClusterDataPoint Cluster;
        public String Name;
        public override string ToString()
        {
            return Name;
        }
    }
}
