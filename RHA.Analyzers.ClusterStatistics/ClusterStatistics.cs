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
// Website: http://RampantIntelligence.blogspot.com/p/RHA
// GitHub project: https://github.com/AeromXundes/Rampant-Hexahedron-Analysis
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RHA.Analyzers.BaseImplementations;
using RHA.Analyzers.DataPoints;
using RHA.Analyzers.DataPoints.Blocks;
using RHA.Analyzers.IO;

namespace ClusterStatistics
{
    class ClusterStatistics : ParallelChunkAnalyzer<List<ClusterDataPoint>>
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

        protected RHA.Analyzers.IO.ChunkBlocks<Block_BasicInfo_Location> FilterBlocks(RHA.Analyzers.IO.ChunkBlocks<Block_BasicInfo> Chunk, HashSet<Block_BasicInfo> IdFilter)
        {
            ChunkBlocks<Block_BasicInfo_Location> results = new ChunkBlocks<Block_BasicInfo_Location>(Chunk.ChunkX, Chunk.ChunkZ);

            foreach (Block_BasicInfo b in Chunk)
            {
                if (!Ids.Contains(b))
                    continue;   // If the block Id:Data pair isn't in the Id set, skip this block.

            }
            return null;
        }

        protected override List<ClusterDataPoint> Analyze(RHA.Analyzers.IO.ChunkBlocks<Block_BasicInfo> Chunk, System.Threading.CancellationToken CancelToken)
        {
            throw new NotImplementedException();
        }

        protected override void Summarize(List<ClusterDataPoint>[] Data, System.Threading.CancellationToken CancelToken)
        {
            throw new NotImplementedException();
        }

        protected HashSet<Block_BasicInfo> Ids;
    }
}
