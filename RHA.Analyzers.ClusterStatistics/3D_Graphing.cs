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
    public partial class _3D_Graphing : Form
    {
        public _3D_Graphing(AggregateClusterStats ResultsData)
        {
            InitializeComponent();
            this.ResultsData = ResultsData;
        }

        private AggregateClusterStats ResultsData;

        private void ilPanel1_Load(object sender, EventArgs e)
        {
            var scene = new ILScene();
            
            Block3D block = new Block3D(-1, -1, -1, Color.Red,.5f);
            Block3D block2 = new Block3D(0, 0, 0, Color.Blue, .5f);
            Block3D block3 = new Block3D(-1, 0, 0, Color.Yellow, .5f);
            Block3D block4 = new Block3D(-1, -1, 0, Color.Violet, .5f);
            scene.Camera.Add(block);
            scene.Camera.Add(block2);
            scene.Camera.Add(block3);
            scene.Camera.Add(block4);
            
            ilPanel1.Scene = scene; 
        }
    }
}
