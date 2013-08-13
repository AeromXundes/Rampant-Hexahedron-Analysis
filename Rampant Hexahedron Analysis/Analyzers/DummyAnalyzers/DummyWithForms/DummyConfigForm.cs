#region Copyright Information
// This file is part of Rampant Hexahedron Analysis.
// 
// Copyright 2013 Aerom Xundes
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// 
// Email: Aerom.Xundes@gmail.com
// Website: http://RampantIntelligence.blogspot.com/RHA
// GitHub project: https://github.com/AeromXundes/Rampant-Hexahedron-Analysis
#endregion

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
