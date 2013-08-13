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
    public partial class DummyConfigForm : Form
    {
        public DummyConfigForm(DummyWithFormConfig config)
        {
            InitializeComponent();
            this.Config = config;
        }

        private DummyWithFormConfig Config;

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Config.Config1 = this.textBox_Config1.Text;
            this.Config.Config2 = this.textBox_Config2.Text;
            this.Config.Config3 = this.textBox_Config3.Text;
            this.Config.Config4 = this.textBox_Config4.Text;

            this.Config.boolConfig = this.radioButton_BoolTrue.Checked;
            this.Config.intConfig = (int)this.numericUpDown1.Value;

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DummyConfigForm_Load(object sender, EventArgs e)
        {
            this.textBox_Config1.Text = this.Config.Config1;
            this.textBox_Config2.Text = this.Config.Config2;
            this.textBox_Config3.Text = this.Config.Config3;
            this.textBox_Config4.Text = this.Config.Config4;

            this.radioButton_BoolTrue.Checked = this.Config.boolConfig;
            this.radioButton_BoolFalse.Checked = !this.Config.boolConfig;
            this.numericUpDown1.Value = this.Config.intConfig;
        }
    }
}
