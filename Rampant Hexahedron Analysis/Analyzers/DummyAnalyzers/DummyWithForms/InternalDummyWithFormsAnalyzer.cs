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
