using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RHA.Analyzers.BlockTypeCount
{
    public partial class BlockTypeCountResultsForm : Form
    {
        public BlockTypeCountResultsForm(BlockTypeCountResults Results)
        {
            InitializeComponent();

            this.Results = Results;
            this.objectListView_ResultDataList.SetObjects(this.Results.Data);
            this.textBox_TotalBlocks.Text = this.Results.TotalNumberOfBlocks.ToString("n0");
            this.textBox_UniqueBlocks.Text = this.Results.NumberOfUniqueTypesOfBlocks.ToString("n0");
            this.textBox_ChunksAnalyzed.Text = this.Results.TotalNumberOfChunks.ToString("n0");
        }

        private BlockTypeCountResults Results;
    }
}
