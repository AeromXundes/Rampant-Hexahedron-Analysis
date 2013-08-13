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
    internal sealed class InternalDummyAnalyzer : IAnalyzer
    {
        public string WorldFolderPath
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public AnalysisFinished FinishedCallback
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

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

        private AnalyzerInfo _AnalyzerInfo = new AnalyzerInfo("InternalDummy1", "v1.0.0", "Aerom Xundes");
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
            get { return false; }
        }

        public System.Windows.Forms.Form GetConfigForm()
        {
            throw new NotImplementedException();
        }

        public System.Windows.Forms.Form GetResultsForm()
        {
            throw new NotImplementedException();
        }


        public bool ResultsAvailable
        {
            get { throw new NotImplementedException(); }
        }

        public bool ResultsFinal
        {
            get { throw new NotImplementedException(); }
        }
    }
}
