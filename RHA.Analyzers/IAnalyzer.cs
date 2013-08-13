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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace RHA.Analyzers
{
    [InheritedExport(typeof(IAnalyzer))]
    public interface IAnalyzer
    {
        string WorldFolderPath { get; set; }
        AnalysisFinished FinishedCallback { get; set; }
        AnalyzerState Status { get; }
        float Progress { get; }
        string Stage { get; }
        AnalyzerInfo AnalyzerInfo { get; }

        object Results();

        /// <summary>
        /// This function should return immediately.
        /// </summary>
        void Start();
        /// <summary>
        /// This function should return immediately. Use <see cref="FinishedCallback"/> to signal the stop.
        /// </summary>
        void Stop();
        /// <summary>
        /// Resets the analyzer to initial condition.
        /// </summary>
        void Reset();

        bool RequiresSpecialConfig { get; }
        bool HasSpecialConfig { get; }
        System.Windows.Forms.Form GetConfigForm();
        bool ResultsAvailable { get; }
        bool ResultsFinal { get; }
        System.Windows.Forms.Form GetResultsForm();
    }
}
