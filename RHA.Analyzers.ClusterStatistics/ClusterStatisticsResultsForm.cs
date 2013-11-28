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
        }
    }
}
