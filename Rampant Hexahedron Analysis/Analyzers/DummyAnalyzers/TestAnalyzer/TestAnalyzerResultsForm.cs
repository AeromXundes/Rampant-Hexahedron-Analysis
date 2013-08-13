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
    public partial class TestAnalyzerResultsForm : Form
    {
        public TestAnalyzerResultsForm(float Progress, string State)
        {
            InitializeComponent();
            this.textBox_Progress.Text = Progress.ToString();
            this.textBox_State.Text = State;
        }
    }
}
