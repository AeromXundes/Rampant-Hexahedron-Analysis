using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RHA.Analyzers.BaseImplementations;
using RHA.Analyzers.DataPoints;

namespace ClusterStatistics
{
    class ClusterStatistics : ParallelChunkAnalyzer<List<object>>
    {
        public override RHA.Analyzers.AnalyzerInfo AnalyzerInfo
        {
            get {
                string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                return new RHA.Analyzers.AnalyzerInfo(
                    "Cluster Statistics",
                    version,
                    "Aerom Xundes",
                    "Provides a suite to analyze clusters of blocks. Intended for ore blocks, but can be used with any block id.",
                    "RampantIntelligence.blogspot.com/rha",
                    @"Part of a programming project for CS-1332 at Georgia Tech during the Fall 2013 Semester.

* Statistics across all clusters in a game world.
	* Perfect for mod developers tuning a mod's ore generation, or server admins tweaking the configs for a bit extra ore for their players and wanting to not give too much extra.
* Gives empirical data on clusters.
	* No more guess-work when trying to figure out how much ore is enough.
	* You don't have to play for hours to establish how much ore you need. Generate a world and analyze!

Limitations of this analyzer:
	Clusters are defined as a single continuous volume of blocks touching each other (horizonally, vertically, and diagonally).
	Meaning this analyzer will not give reliable results with density based ore generation (such as a cloud of ore).
	There is no way for this analyzer to determine when two clusters are generated together—it will assume it is one large cluster.
		Although, the statistics will likely flag these larger clusters as outliers."
                    );
            }
        }

        protected override object GetResults()
        {
            throw new NotImplementedException();
        }

        public override bool ResultsAvailable
        {
            get { throw new NotImplementedException(); }
        }

        public override bool ResultsFinal
        {
            get { throw new NotImplementedException(); }
        }

        public override System.Windows.Forms.Form GetResultsForm()
        {
            throw new NotImplementedException();
        }

        protected override List<object> Analyze(RHA.Analyzers.IO.ChunkBlocks Chunk, System.Threading.CancellationToken CancelToken)
        {
            throw new NotImplementedException();
        }

        protected override void Summarize(List<object>[] Data, System.Threading.CancellationToken CancelToken)
        {
            throw new NotImplementedException();
        }
    }
}
