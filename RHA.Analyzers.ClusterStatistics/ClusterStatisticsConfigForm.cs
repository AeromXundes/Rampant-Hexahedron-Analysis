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
    public partial class ClusterStatisticsConfigForm : Form
    {
        public ClusterStatisticsConfigForm(ClusterStatisticsConfigOptions Options)
        {
            InitializeComponent();
            this.Options = Options;

            this.numericUpDown_X.Value = Options.XAbsMaxDist;
            this.numericUpDown_Y.Value = Options.YAbsMaxDist;
            this.numericUpDown_Z.Value = Options.ZAbsMaxDist;
            string txt = string.Empty;
            foreach (HashSet<RHA.Analyzers.DataPoints.Blocks.Block_BasicInfo> set in this.Options.Ids)
            {
                foreach (RHA.Analyzers.DataPoints.Blocks.Block_BasicInfo block in set)
                {
                    txt += ((block.Id.HasValue) ? block.Id.ToString() : string.Empty) + ":" + ((block.Data.HasValue) ? block.Data.Value.ToString() : String.Empty);
                }
                txt += ",";
            }
            this.textBox_Ids.Text = txt;
        }

        private ClusterStatisticsConfigOptions Options;

        private List<HashSet<RHA.Analyzers.DataPoints.Blocks.Block_BasicInfo>> GetIds()
        {
            //HACK: No error checking at all...
            List<HashSet<RHA.Analyzers.DataPoints.Blocks.Block_BasicInfo>> results = new List<HashSet<RHA.Analyzers.DataPoints.Blocks.Block_BasicInfo>>();
            string[] pairs = this.textBox_Ids.Text.Split(',');
            HashSet<RHA.Analyzers.DataPoints.Blocks.Block_BasicInfo> set = new HashSet<RHA.Analyzers.DataPoints.Blocks.Block_BasicInfo>();
            foreach (string s in pairs)
            {
                if (s.Length == 0) continue;
                string[] val = s.Split(':');
                int id = int.Parse(val[0]);
                int data = (val.Length >= 2) ? int.Parse(val[1]) : 0;
                set.Add(new RHA.Analyzers.DataPoints.Blocks.Block_BasicInfo(id, data));
            }
            results.Add(set);
            return results;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Options.Ids = GetIds();

            Options.XAbsMaxDist = (int)this.numericUpDown_X.Value;
            Options.YAbsMaxDist = (int)this.numericUpDown_Y.Value;
            Options.ZAbsMaxDist = (int)this.numericUpDown_Z.Value;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
