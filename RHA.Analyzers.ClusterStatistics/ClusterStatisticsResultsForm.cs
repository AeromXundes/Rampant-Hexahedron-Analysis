using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
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
                txt += ",";
            }
            this.textBox_Ids.Text = txt;

            this.label_AvgLenX.Text = Math.Round(Stats.ClusterXLengthAvg,3).ToString();
            this.label_AvgLenY.Text = Math.Round(Stats.ClusterYLengthAvg,3).ToString();
            this.label_AvgLenZ.Text = Math.Round(Stats.ClusterZLengthAvg,3).ToString();

            this.label_BlocksPerChunk.Text = Math.Round(Stats.BlocksPerChunkAvg,3).ToString();
            this.label_BlocksPercluster.Text = Math.Round(Stats.BlocksPerClusterAvg,3).ToString();
            this.label_ClustersPerChunk.Text = Math.Round(Stats.ClustersPerChunkAvg,3).ToString();

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
            this.label_CentroidLoc.Text = cluster.CentroidBlock.ToString();
            this.label_NumBlocks.Text = cluster.Blocks.Count.ToString();

            var scene = new ILScene();

            foreach (var MCBlock in cluster.Blocks)
            {
                Block3D ILBlock = new Block3D((double)MCBlock.XWorld, (double)MCBlock.YWorld, (double)MCBlock.ZWorld, Color.Blue);
                scene.Camera.Add(ILBlock);
            }
            //scene.Camera.Add(new Block3D(0, 0, 0, Color.Red));
            scene.Camera.LookAt = new Vector3((float)cluster.CentroidBlock.XWorld + .5f, (float)cluster.CentroidBlock.YWorld + .5f, (float)cluster.CentroidBlock.ZWorld + .5f);
            this.ilPanel_clusterVisual.Scene = scene;
            this.ilPanel_clusterVisual.Scene.Configure();
            this.ilPanel_clusterVisual.Refresh();
        }

        // Renders the X-Z Plane centroid heatmap
        private void ilPanel_Heatmap_XZ_Load(object sender, EventArgs e)
        {
            var scene = new ILScene();
            ILPlotCube plotCube = HeatMap(Stats.CentroidHeatMapChunkXZPlane, 16, 16);
            plotCube.Axes.XAxis.Label.Text = "X-Axis";
            plotCube.Axes.YAxis.Label.Text = "Z-Axis";
            scene.Add(plotCube);
            ilPanel_Heatmap_XZ.Scene = scene;
        }

        private void ilPanel_Heatmap_ZY_Load(object sender, EventArgs e)
        {
            var scene = new ILScene();
            ILPlotCube plotCube = HeatMap(Stats.CentroidHeatMapChunkZYPlane, 16, 256);
            plotCube.Axes.XAxis.Label.Text = "Z-Axis";
            plotCube.Axes.YAxis.Label.Text = "Y-Axis";
            scene.Add(plotCube);
            ilPanel_Heatmap_ZY.Scene = scene;
        }

        private void ilPanel_Heatmap_XY_Load(object sender, EventArgs e)
        {
            var scene = new ILScene();
            ILPlotCube plotCube = HeatMap(Stats.CentroidHeatMapChunkXYPlane, 16, 256);
            scene.Add(plotCube);
            ilPanel_Heatmap_XY.Scene = scene;
        }
        
        private ILPlotCube HeatMap(Dictionary<Tuple<int, int>, int> HeatMapStats, int xDim, int yDim)
        {
            float[,] heatVals = new float[xDim, yDim];
            foreach (var key in HeatMapStats.Keys)
            {
                int x = key.Item1;
                int y = key.Item2;
                int z = HeatMapStats[key];
                heatVals[x, y] = z;
            }
            ILArray<float> heatMap = heatVals;
            ILPlotCube plotCube = new ILPlotCube(twoDMode: true) { new ILSurface(heatMap) };
            plotCube.AllowPan = false;
            plotCube.AllowRotation = false;
            plotCube.AllowZoom = false;
            return plotCube;
        }
        /*
        private void RenderClusterHeatMap(List<ClusterDataPoint> clusters)
        {
            var scene = new ILScene();

            Dictionary<Tuple<int, int, int>, int> heatMap = new Dictionary<Tuple<int, int, int>, int>();

            foreach (var cluster in clusters)
            {
                Tuple<int, int, int> key = new Tuple<int, int, int>(cluster.CentroidBlock.XChunk.Value, cluster.CentroidBlock.YWorld.Value, cluster.CentroidBlock.ZChunk.Value);
                if (heatMap.ContainsKey(key))
                    heatMap[key] += 1;
                else
                    heatMap.Add(key, 1);
            }

            int max = heatMap.Values.Max();
            int min = heatMap.Values.Min();

            foreach (var kvp in heatMap)
            {
                Block3D ILBlock = new Block3D((double)kvp.Key.Item1, (double)kvp.Key.Item2, (double)kvp.Key.Item3, Color.Red, kvp.Value / (float)max);
                scene.Camera.Add(ILBlock);
            }
            scene.Camera.LookAt = new Vector3(8, 64, 8);
            this.ilPanel_ClusterHeatMap.Scene = scene;
            this.ilPanel_ClusterHeatMap.Scene.Configure();
            this.ilPanel_ClusterHeatMap.Refresh();
        }
         */

        
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
