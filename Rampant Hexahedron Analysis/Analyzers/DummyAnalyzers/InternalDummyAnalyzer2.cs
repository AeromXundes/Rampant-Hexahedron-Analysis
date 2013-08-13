using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHA.Analyzers
{
    internal sealed class InternalDummyAnalyzer2 : IAnalyzer
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

        private AnalyzerInfo _AnalyzerInfo = new AnalyzerInfo(
            "InternalDummy2",
            "v10.23.2",
            "Aerom Xundes, Arladris, Phii, The Stench",
            "This is a description. A super description indeed. It really doesn't mean anything at all, but it needs to be long enough to fill the space. I think that should do it.",
            "RampantIntelligence.blogspot.com",
            "Additional information. Information!! Data! Super-de-duper! Woo whoo! This is almost done! Yay! Don't go anywhere! Don't touch that remote!"
            );

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
