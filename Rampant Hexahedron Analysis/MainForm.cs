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

using RHA.Analyzers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RHA
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Plugins = new PluginsComposer();
            Analyzers = new List<IAnalyzer>(Plugins.Analyzers);
            this.PopulateAnalyzers();
        }

        PluginsComposer Plugins;
        List<IAnalyzer> Analyzers;

        private void PopulateAnalyzers()
        {
            List<IAnalyzer> badAnalyzers = new List<IAnalyzer>(0);

            foreach (IAnalyzer a in Analyzers)
            {
                try
                {
                    this.comboBox_Analyzers.Items.Add(a.AnalyzerInfo.Name);
                }
                catch (NotImplementedException)
                {
                    badAnalyzers.Add(a);
                    MessageBox.Show("One of the analyzers does not properly implement the AnalyzerInfo property." +
                        "\n" +
                        "\n" +
                        "The name of the analyzer type is:\n" +
                        a.GetType().ToString()
                        );
                }
            }

            // You can't alter the enumeration while enumerating, so deal with the bad analyzers after enumerating.
            if (badAnalyzers.Count > 0)
            {
                foreach (IAnalyzer a in badAnalyzers)
                    this.Analyzers.Remove(a);
            }
        }

        private void button_About_Click(object sender, EventArgs e)
        {
            (new AboutBox()).Show();
        }

        private void comboBox_Analyzers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox_Analyzers.SelectedIndex >= 0)
                this.button_UseAnalyzer.Enabled = true;

            AnalyzerInfo a = this.Analyzers[this.comboBox_Analyzers.SelectedIndex].AnalyzerInfo;
            this.textBox_Info_Name.Text = a.Name;
            this.textBox_Info_Version.Text = a.Version;
            
            this.textBox_Info_Description.Text = a.Description;
            this.textBox_Info_Authors.Text = a.Author;
            this.textBox_Info_Additional.Text = a.AdditionalInfo;
            this.linkLabel_Info_Url.Text = a.Url;

            try
            {
                this.textBox_Info_RequiresSpecialConfig.Text = this.Analyzers[this.comboBox_Analyzers.SelectedIndex].RequiresSpecialConfig ? "Yes" : "No";
            }
            catch (NotImplementedException)
            {
                MessageBox.Show(this.Analyzers[this.comboBox_Analyzers.SelectedIndex].GetType().ToString() + "\n\nThis Analyzer does not properly implement the IAnalyzer interface.");
            }
        }

        private void linkLabel_Info_Url_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string target = this.linkLabel_Info_Url.Text;
            if (target != null)
            {
                if ( !target.StartsWith("http") && !target.StartsWith("www"))
                {
                    target = "http://" + target;
                }
                System.Diagnostics.Process.Start(target);
            }
        }

        private void button_UseAnalyzer_Click(object sender, EventArgs e)
        {
            if (this.comboBox_Analyzers.SelectedIndex >= 0 && this.comboBox_Analyzers.SelectedIndex < this.Analyzers.Count)
            {
                (new AnalyzerForm(this.Analyzers[this.comboBox_Analyzers.SelectedIndex])).Show();
            }
        }
    }
}
