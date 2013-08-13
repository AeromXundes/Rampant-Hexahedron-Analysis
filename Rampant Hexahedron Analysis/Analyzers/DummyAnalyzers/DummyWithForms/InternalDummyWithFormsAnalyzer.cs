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

namespace RHA.Analyzers.DummyAnalyzers.DummyWithForms
{
    internal sealed class InternalDummyWithFormsAnalyzer : IAnalyzer
    {
        public string WorldFolderPath {get;set;}

        public AnalysisFinished FinishedCallback {get;set;}

        public AnalyzerState Status
        {
            get { throw new NotImplementedException(); }
        }

        public float Progress
        {
            get { throw new NotImplementedException(); }
        }

        public string Stage
        {
            get { throw new NotImplementedException(); }
        }

        private AnalyzerInfo _AnalyzerInfo = new AnalyzerInfo("DummyWithForms", "v1.2.3", "Aerom Xundes", "A dummy analyzer with config and result forms.");
        public AnalyzerInfo AnalyzerInfo
        {
            get { return _AnalyzerInfo; }
        }

        public object Results()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public bool RequiresSpecialConfig
        {
            get { return false; }
        }

        public bool HasSpecialConfig
        {
            get { return true; }
        }

        public System.Windows.Forms.Form GetConfigForm()
        {
            return new DummyConfigForm(config);
        }

        public System.Windows.Forms.Form GetResultsForm()
        {
            return new DummyResultsForm("It worked! :-)");
        }

        private DummyWithFormConfig config = new DummyWithFormConfig();


        public bool ResultsAvailable
        {
            get { return true; }
        }

        public bool ResultsFinal
        {
            get { throw new NotImplementedException(); }
        }
    }
}
