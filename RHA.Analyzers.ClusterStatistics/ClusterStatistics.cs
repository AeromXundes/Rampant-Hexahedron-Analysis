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

            for (int x = 0; x < Chunk.XDim; x++)
			{
                for (int z = 0; z < Chunk.ZDim; z++)
                {
                    for (int y = 0; y < Chunk.YDim; y++)
                    {
                        if (IdFilter.Contains(Chunk[x,y,z]))
                            results[x, y, z] = new Block_BasicInfo_Location(
                                Chunk[x, y, z],
                                Chunk.ChunkX * Chunk.XDim + x,
                                y,
                                Chunk.ChunkZ * Chunk.ZDim + z
                                );
                    }
                }
			}
            return results;
        }

        /// <summary>
        /// Gets the neighbors of OriginBlock in FilteredChunk that aren't null and are within DistMax distance of OriginBlock (each plane's distance is independant).
        /// </summary>
        /// <param name="FilteredChunk">A chunk that only has the block types you're interested in.</param>
        /// <param name="OriginBlock">The central block to get the neighbors from.</param>
        /// <param name="xDistMax">The max distance in the x-plane.</param>
        /// <param name="yDistMax">The max distance in the y-plane.</param>
        /// <param name="zDistMax">The max distance in the z-plane.</param>
        /// <returns>A list of all the neighbors within DistMax of the OriginBlock. Does NOT include the OriginBlock.</returns>
        protected List<Block_BasicInfo_Location> GetNeighbors(ChunkBlocks<Block_BasicInfo_Location> FilteredChunk, Block_BasicInfo_Location OriginBlock, int xDistMax, int yDistMax, int zDistMax)
        {
            List<Block_BasicInfo_Location> neighbors = new List<Block_BasicInfo_Location>(xDistMax * yDistMax * zDistMax);
            for (int x = Math.Max(OriginBlock.XChunk.Value - xDistMax, 0); x < Math.Min(xDistMax, FilteredChunk.XDim); x++)
            {
                for (int z = Math.Max(OriginBlock.ZChunk.Value - zDistMax, 0); z < Math.Min(zDistMax, FilteredChunk.XDim); z++)
                {
                    for (int y = Math.Max(OriginBlock.YWorld.Value - yDistMax, 0); y < Math.Min(yDistMax, FilteredChunk.XDim); y++)
                    {
                        if(FilteredChunk[x,y,z] != null)
                            if(!FilteredChunk[x,y,z].Equals(OriginBlock)) // .Equals to compare across the coordinates.
                                neighbors.Add(FilteredChunk[x, y, z]);
                    }
                }
            }
            return neighbors;
        }

        protected ClusterDataPoint ClusterFromSingleBlock(ChunkBlocks<Block_BasicInfo_Location> FilteredChunk, Block_BasicInfo_Location OriginBlock, int xDistMax, int yDistMax, int zDistMax)
        {
            ClusterDataPoint cluster = new ClusterDataPoint();
            Queue<Block_BasicInfo_Location> yetToDiscoverNeighbors = new Queue<Block_BasicInfo_Location>();

            // Obviously OriginBlock is in the cluster...
            cluster.AddBlock(OriginBlock);
            yetToDiscoverNeighbors.Enqueue(OriginBlock);

            while (yetToDiscoverNeighbors.Count != 0)
            {
                Block_BasicInfo_Location current = yetToDiscoverNeighbors.Dequeue();
                List<Block_BasicInfo_Location> neighbors = GetNeighbors(FilteredChunk, current, xDistMax, yDistMax, zDistMax);
                foreach (Block_BasicInfo_Location b in neighbors)
                {
                    if (!cluster.Blocks.Contains(b))
                    {
                        cluster.AddBlock(b);
                        yetToDiscoverNeighbors.Enqueue(b);
                    }
                }
            }
            return cluster;
        }

        protected List<ClusterDataPoint> GetClusters(ChunkBlocks<Block_BasicInfo_Location> FilteredChunk, int xDistMax, int yDistMax, int zDistMax)
        {
            List<ClusterDataPoint> clusters = new List<ClusterDataPoint>();
            for (int x = 0; x < FilteredChunk.XDim; x++)
            {
                for (int z = 0; z < FilteredChunk.ZDim; z++)
                {
                    for (int y = 0; y < FilteredChunk.YDim; y++)
                    {
                        if (FilteredChunk[x, y, z] != null)
                            clusters.Add(ClusterFromSingleBlock(FilteredChunk, FilteredChunk[x, y, z], xDistMax, yDistMax, zDistMax));
                    }
                }
            }
            return clusters;
        }

        protected override List<ClusterDataPoint> Analyze(RHA.Analyzers.IO.ChunkBlocks<Block_BasicInfo> Chunk, System.Threading.CancellationToken CancelToken)
        {
            List<ClusterDataPoint> clusters = new List<ClusterDataPoint>();
            List<ChunkBlocks<Block_BasicInfo_Location>> filteredChunks = new List<ChunkBlocks<Block_BasicInfo_Location>>(Ids.Count);
            foreach (HashSet<Block_BasicInfo> ids in Ids)
            {
                filteredChunks.Add(FilterBlocks(Chunk, ids));
            }
            foreach (ChunkBlocks<Block_BasicInfo_Location> filteredChunk in filteredChunks)
            {
                clusters.AddRange(GetClusters(filteredChunk, this.XAbsMaxDist, this.YAbsMaxDist, this.ZAbsMaxDist));
            }
            return clusters;
        }

        protected override void Summarize(List<ClusterDataPoint>[] Data, System.Threading.CancellationToken CancelToken)
        {
            throw new NotImplementedException();
        }

        protected List<HashSet<Block_BasicInfo>> Ids;
        protected int XAbsMaxDist;
        protected int YAbsMaxDist;
        protected int ZAbsMaxDist;
    }
}
