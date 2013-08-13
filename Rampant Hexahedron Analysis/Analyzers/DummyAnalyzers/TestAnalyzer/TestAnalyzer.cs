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
using System.Threading;
using System.Threading.Tasks;

namespace RHA.Analyzers.DummyAnalyzers.TestAnalyzer
{
    internal sealed class TestAnalyzer : IAnalyzer
    {
        public TestAnalyzer()
        {
            this.Status = AnalyzerState.WaitingToRun;
        }
        private Task FakeAnalysisTask;
        private CancellationTokenSource CancelSource;

        private void FakeAnalysis(CancellationToken CancelToken)
        {
            if (CancelSource.IsCancellationRequested)
            {
                FinishCancelled();
                return;
            }

            for (int i = 0; i < Config.Seconds; i += 1)
            {
                if (CancelSource.IsCancellationRequested)
                {
                    FinishCancelled();
                    return;
                }

                this.Progress = (float)i / (float)Config.Seconds;
                this.Stage = i.ToString() + " / " + Config.Seconds.ToString() + " (" + Math.Round(this.Progress * 100).ToString() + " %)";
                System.Threading.Thread.Sleep(this.Config.TaskLength * 1000);
            }

            this.Progress = 1f;
            this.Stage = "Completed!";
            this.Status = AnalyzerState.RanToCompletion;
            if(this.FinishedCallback != null)
                this.FinishedCallback(AnalyzerFinishState.Complete, this, "Finished!");
        }

        private TestAnalyzerConfig Config = new TestAnalyzerConfig() { Seconds = 10, TaskLength = 1 };

        private void FinishCancelled()
        {
            this.Status = AnalyzerState.Cancelled;
            FinishedCallback(AnalyzerFinishState.Cancelled, this, "Analysis cancelled.");
        }

        #region IAnalyzer Implementation
        public string WorldFolderPath { get; set; }

        public AnalysisFinished FinishedCallback { get; set; }

        public AnalyzerState Status { get; set; }

        public float Progress { get; private set; }

        public string Stage { get; private set; }

        private AnalyzerInfo _AnalyzerInfo = new AnalyzerInfo("TestAnalyzer","v0.0.1","Aerom Xundes","Analyzer that implements everything, but does nothing.");
        public AnalyzerInfo AnalyzerInfo { get { return _AnalyzerInfo; } }

        public object Results()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            if (WorldFolderPath == null || WorldFolderPath == string.Empty)
            {
                FinishedCallback(AnalyzerFinishState.Faulted, this, "WorldFolderPath is empty!");
                this.Stage = "Error: WorldFolderPath is empty.";
                return;
            }
            this.Stage = "Analysis starting...";
            this.Status = AnalyzerState.Running;
            this.CancelSource = new CancellationTokenSource();
            this.FakeAnalysisTask = new Task(() => this.FakeAnalysis(this.CancelSource.Token));
            this.FakeAnalysisTask.Start();
        }

        public void Stop()
        {
            if (this.Status != AnalyzerState.Running)
                return;
            this.Stage = "Cancelling...";
            this.Status = AnalyzerState.Cancelling;
            this.CancelSource.Cancel();
        }

        public void Reset()
        {
            this.FinishedCallback = null;
            this.Progress = 0;
            this.Stage = string.Empty;
            this.Status = AnalyzerState.WaitingToRun;
            this.WorldFolderPath = string.Empty;
            this.CancelSource = null;
            this.Config = new TestAnalyzerConfig() { Seconds = 10, TaskLength = 1 };
        }

        public bool RequiresSpecialConfig { get { return true; } }

        public bool HasSpecialConfig { get { return true; } }

        public System.Windows.Forms.Form GetConfigForm()
        {
            return new TestAnalyzerConfigForm(this.Config);
        }

        public bool ResultsAvailable { get { return true; } }

        public bool ResultsFinal { get; private set; }

        public System.Windows.Forms.Form GetResultsForm()
        {
            return new TestAnalyzerResultsForm(this.Progress, this.Status.ToString());
        }
        #endregion
    }
}
