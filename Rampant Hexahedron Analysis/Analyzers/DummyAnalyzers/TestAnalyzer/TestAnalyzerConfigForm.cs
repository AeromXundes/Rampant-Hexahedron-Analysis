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
