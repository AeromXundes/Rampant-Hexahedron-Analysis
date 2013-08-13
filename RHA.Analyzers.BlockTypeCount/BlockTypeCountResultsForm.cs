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
