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
        }

        private ClusterStatisticsConfigOptions Options;
    }
}
