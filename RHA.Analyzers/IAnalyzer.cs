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
