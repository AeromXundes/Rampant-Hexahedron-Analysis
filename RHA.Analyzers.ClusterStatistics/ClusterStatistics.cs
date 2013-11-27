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

        /// <summary>
        /// Filters a chunk based on an IdFilter. The Id:Data pairs are both compared, not just the Id.
        /// </summary>
        /// <param name="Chunk">The chunk to filter. It won't be altered.</param>
        /// <param name="IdFilter">The Id:Data pairs to keep.</param>
        /// <returns>Returns a new filtered chunk with only the blocks with matching Id:Data pairs in IdFilter.</returns>
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

        /// <summary>
        /// Finds the cluster OriginBlock is contained within.
        /// </summary>
        /// <param name="FilteredChunk">A chunk with only the types of blocks we care about.</param>
        /// <param name="OriginBlock">The block we want to start from.</param>
        /// <param name="xDistMax">Max abs distance in the x plane.</param>
        /// <param name="yDistMax">Max abs distance in the y plane.</param>
        /// <param name="zDistMax">Max abs distance in the z plane.</param>
        /// <returns>Returns a ClusterDataPoint containing all the blocks within the distance of the DistMax vars.</returns>
        /// <remarks>
        /// It is important to note this function considers blocks in a cluster by finding any block within the DistMax vars, not just OriginBlock.
        /// 
        /// For example, consider these blocks in the x-plane. We will only concern ourselves with one dimension, but it trivial to extend to the others.
        /// 
        ///  Location: 0 1 2 3 4 5 6 7 8
        /// Block T/F: _ X X X X _ X X _
        /// 
        /// With xDistMax = 1, blocks {1,2,3,4} are a cluster and blocks {6,7} are another.
        /// Starting at block 1, we still get {1,2,3,4} as a cluster, even though block 4 is farther than 1 block from the OriginBlock.
        /// This is because block 2 is within xDistMax of the OriginBlock, block 3 is within xDistMax from block 2, and so on.
        /// Regardless of what block in a cluster is the OriginBlock, all blocks within the cluster will be found.
        /// </remarks>
        protected ClusterDataPoint ClusterFromSingleBlock(ChunkBlocks<Block_BasicInfo_Location> FilteredChunk, Block_BasicInfo_Location OriginBlock, int xDistMax, int yDistMax, int zDistMax)
        {
            if (OriginBlock == null)
                throw new ArgumentNullException("OriginBlock");
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
            // Get all the blocks that aren't null.
            List<Block_BasicInfo_Location> blocksNotInACluster = new List<Block_BasicInfo_Location>(FilteredChunk.Where(x => x != null));

            while (blocksNotInACluster.Count != 0)
            {
                // It doesn't matter which block we choose. Choose the last to hopefully reduce the element shifting required a bit when we remove the blocks we find in the cluster.
                Block_BasicInfo_Location block = blocksNotInACluster.Last();
                ClusterDataPoint tempCluster = ClusterFromSingleBlock(FilteredChunk, block, xDistMax, yDistMax, zDistMax);
                // Remove all the blocks in blocksNotInACluster that are in tempCluster.
                blocksNotInACluster.RemoveAll(x => tempCluster.Blocks.Contains(x));
                clusters.Add(tempCluster);
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

        protected void MergeClustersBottomToTop(List<ClusterDataPoint> Bottom, List<ClusterDataPoint> Top)
        {
        }

        /// <summary>
        /// Determines if two clusters have blocks adjacent to each other based on the DistMax vars.
        /// </summary>
        /// <param name="A">A cluster.</param>
        /// <param name="B">B cluster.</param>
        /// <param name="xDistMax">The abs distance between blocks in the x plane.</param>
        /// <param name="yDistMax">The abs distance between blocks in the y plane.</param>
        /// <param name="zDistMax">The abs distance between blocks in the z plane.</param>
        /// <returns>Returns true if there exists a block in A within the DistMax of another block in B.</returns>
        /// <exception cref="ArgumentExcpetion">Thrown when A == B.</exception>
        protected bool AreClustersAdjacent(ClusterDataPoint A, ClusterDataPoint B, int xDistMax, int yDistMax, int zDistMax)
        {
            if (A == B)
                throw new ArgumentException("Comparing a cluster to itself doesn't make any sense.");

            foreach (Block_BasicInfo_Location b in A.Blocks)
            {
                foreach (Block_BasicInfo_Location c in B.Blocks)
                {
                    if (Math.Abs(b.XWorld.Value - c.XWorld.Value) <= xDistMax)
                        return true;
                    if (Math.Abs(b.YWorld.Value - c.YWorld.Value) <= yDistMax)
                        return true;
                    if (Math.Abs(b.ZWorld.Value - c.ZWorld.Value) <= zDistMax)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Merges clusters together. Returns true if clusters where actually merged.
        /// </summary>
        /// <param name="Bottom"></param>
        /// <param name="Top"></param>
        /// <param name="xDistMax"></param>
        /// <param name="yDistMax"></param>
        /// <param name="zDistMax"></param>
        /// <returns></returns>
        protected bool MergeClustersBottomToTop(KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>> Bottom, KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>> Top, int xDistMax, int yDistMax, int zDistMax)
        {
            if (Bottom.Key.Item2 != Top.Key.Item2 + 1)
                return false;

            bool changed = false;

            foreach (ClusterDataPoint a in Bottom.Value.Where(x => x.ZMaxCoord % 16 >= 15 - zDistMax))   // where the maxZCoord is the last block in the chunk
            {
                foreach (ClusterDataPoint b in Top.Value.Where(x => x.ZMinCoord % 16 <= zDistMax)) // where the minZCoord is the first block of the chunk
                {
                    if (AreClustersAdjacent(a, b, xDistMax, yDistMax, zDistMax))
                    {
                        a.AddBlocks(b.Blocks);
                        b.AddBlocks(a.Blocks);
                        changed = true;
                    }
                }
            }
            return changed;
        }

        /// <summary>
        /// Merges clusters together. Returns true if clusters where actually merged.
        /// </summary>
        /// <param name="Left"></param>
        /// <param name="Right"></param>
        /// <returns></returns>
        protected bool MergeClustersLeftToRight(KeyValuePair<Tuple<int,int>, List<ClusterDataPoint>> Left, KeyValuePair<Tuple<int,int>, List<ClusterDataPoint>> Right, int xDistMax, int yDistMax, int zDistMax)
        {
            if (Left.Key.Item1 != Right.Key.Item1 + 1)
                return false;

            bool changed = false;

            foreach (ClusterDataPoint a in Left.Value.Where(x => x.XMaxCoord % 16 >= 15 - xDistMax))   // where the maxXCoord is the last block in the chunk
            {
                foreach (ClusterDataPoint b in Right.Value.Where(x => x.XMinCoord % 16 <= xDistMax)) // where the minXCoord is the first block of the chunk
                {
                    if (AreClustersAdjacent(a, b, xDistMax, yDistMax, zDistMax))
                    {
                        a.AddBlocks(b.Blocks);
                        b.AddBlocks(a.Blocks);
                        changed = true;
                    }
                }
            }
            return changed;
        }

        protected override void Summarize(List<ClusterDataPoint>[] Data, System.Threading.CancellationToken CancelToken)
        {
            Dictionary<Tuple<int, int>, List<ClusterDataPoint>> orderedChunkClusters = new Dictionary<Tuple<int, int>, List<ClusterDataPoint>>(Data.Length);

            // Sort the chunksOfClusters by their chunk coordinates
            foreach (List<ClusterDataPoint> chunkOfClusters in Data)
            {
                if(chunkOfClusters.Count == 0)
                    continue;   // Nothing we can do about chunks with no clusters in them.
                // Get the chunk coordinates of the cluster and add the chunk of clusters to that coordinate pair.
                orderedChunkClusters.Add(new Tuple<int, int>(chunkOfClusters.First().Blocks.First().ChunkX.Value, chunkOfClusters.First().Blocks.First().ChunkZ.Value), chunkOfClusters);
            }

            int minX = orderedChunkClusters.Keys.Min(tuple => tuple.Item1);
            int maxX = orderedChunkClusters.Keys.Max(tuple => tuple.Item1);
            int minZ = orderedChunkClusters.Keys.Min(tuple => tuple.Item2);
            int maxZ = orderedChunkClusters.Keys.Max(tuple => tuple.Item2);

            // merge clusters in the X+ direction
            for(int x = minX; x < maxX; x++)
            {
                List<ClusterDataPoint> prevClusters = null;
                Tuple<int, int> prevCoord = null;
                for(int z = minZ; z < maxZ; z++)
                {
                    List<ClusterDataPoint> currClusters;
                    Tuple<int, int> currCoord = new Tuple<int, int>(x, z);
                    if (orderedChunkClusters.TryGetValue(currCoord, out currClusters))
                    {
                        if (prevClusters != null)
                        {
                            bool merged = MergeClustersLeftToRight(
                                new KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>>(prevCoord, prevClusters),
                                new KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>>(currCoord, currClusters),
                                XAbsMaxDist,
                                YAbsMaxDist,
                                ZAbsMaxDist);

                            // if a merge happened, there are two cluster objects with exactly the same blocks, so get rid of one of those. doesn't matter which one.
                            // assumes what is in the dictionary is what we return, not what is in the Data array.
                            if (merged)
                                orderedChunkClusters[prevCoord] = currClusters;
                        }

                        prevClusters = currClusters;
                        prevCoord = currCoord;
                    }
                }
            }

            // this loop is very, very similar to the one above. it very well could be refactored a lot, but the direction is different (even though expressing that direction change
            // is a simple swap of the loops) and the merging function is different, too. all in all: refactor later, this need to get done.
            // I suppose in other words:
            //HACK: this whole loop

            // merge clusters in the +Z direction
            for (int z = minZ; z < maxZ; z++)
            {
                List<ClusterDataPoint> prevClusters = null;
                Tuple<int, int> prevCoord = null;
                for (int x = minX; x < maxX; x++)
                {
                    List<ClusterDataPoint> currClusters;
                    Tuple<int, int> currCoord = new Tuple<int, int>(x, z);
                    if (orderedChunkClusters.TryGetValue(currCoord, out currClusters))
                    {
                        if (prevClusters != null)
                        {
                            bool merged = MergeClustersBottomToTop(
                                new KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>>(prevCoord, prevClusters),
                                new KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>>(currCoord, currClusters),
                                XAbsMaxDist,
                                YAbsMaxDist,
                                ZAbsMaxDist);

                            // if a merge happened, there are two cluster objects with exactly the same blocks, so get rid of one of those. doesn't matter which one.
                            // assumes what is in the dictionary is what we return, not what is in the Data array.
                            if (merged)
                                orderedChunkClusters[prevCoord] = currClusters;
                        }

                        prevClusters = currClusters;
                        prevCoord = currCoord;
                    }
                }
            }
            
            throw new NotImplementedException();
        }

        protected List<HashSet<Block_BasicInfo>> Ids;
        protected int XAbsMaxDist;
        protected int YAbsMaxDist;
        protected int ZAbsMaxDist;
    }
}
