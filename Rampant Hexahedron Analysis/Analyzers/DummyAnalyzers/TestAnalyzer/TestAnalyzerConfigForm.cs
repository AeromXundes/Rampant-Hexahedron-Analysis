using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RHA.Analyzers.DummyAnalyzers.TestAnalyzer
{
    public partial class TestAnalyzerConfigForm : Form
    {
        public TestAnalyzerConfigForm(TestAnalyzerConfig Config)
        {
            InitializeComponent();
            this.Config = Config;
        }

        private TestAnalyzerConfig Config;

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Config.Seconds = (int)this.numericUpDown1.Value;
            this.Config.TaskLength = (int)this.numericUpDown2.Value;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TestAnalyzerConfigForm_Load(object sender, EventArgs e)
        {
            this.numericUpDown1.Value = this.Config.Seconds;
            this.numericUpDown2.Value = this.Config.TaskLength;
        }
    }
}
