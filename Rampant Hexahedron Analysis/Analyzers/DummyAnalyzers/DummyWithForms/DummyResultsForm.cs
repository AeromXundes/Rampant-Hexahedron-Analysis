using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RHA.Analyzers.DummyAnalyzers.DummyWithForms
{
    public partial class DummyResultsForm : Form
    {
        public DummyResultsForm(string Data)
        {
            InitializeComponent();
            this.Data = Data;
        }

        private string Data;

        private void DummyResultsForm_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = Data;
        }
    }
}
