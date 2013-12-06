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
        public ClusterStatistics()
        {
            this.WorldFolderPath = @"C:\Users\Kevin\Cool Apps\Minecraft\MultiMC\instances\CS Project\minecraft\saves\Simple5";
            var temp = new HashSet<Block_BasicInfo>();
            temp.Add(new Block_BasicInfo(15, 0));
            this._options.Ids.Add(temp);
        }
        public override RHA.Analyzers.AnalyzerInfo AnalyzerInfo
        {
            get {
                string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                return new RHA.Analyzers.AnalyzerInfo(
                    "Cluster Statistics",
                    version,
                    "Aerom Xundes",
                    @"Provides a suite to analyze clusters of blocks. Intended for ore blocks, but can be used with any block id.

* Statistics across all clusters in a game world.
	* Perfect for mod developers tuning a mod's ore generation, or server admins tweaking the configs for a bit extra ore for their players and wanting to not give too much extra.
* Gives empirical data on clusters.
	* No more guess-work when trying to figure out how much ore is enough.
	* You don't have to play for hours to establish how much ore you need. Generate a world and analyze!

Limitations of this analyzer:
	Clusters are defined as a single continuous volume of blocks touching each other (horizonally, vertically, and diagonally).
	Meaning this analyzer will not give reliable results with density based ore generation (such as a cloud of ore).
	There is no way for this analyzer to determine when two clusters are generated together—it will assume it is one large cluster.
		Although, the statistics will likely flag these larger clusters as outliers.
",
                    "RampantIntelligence.blogspot.com/rha",
                    "Part of a programming project for CS-1332 at Georgia Tech during the Fall 2013 Semester."
                    );
            }
        }

        protected AggregateClusterStats _results;

        protected override object GetResults()
        {
            return this.Results();
        }

        public new AggregateClusterStats Results()
        {
            return _results;
        }

        protected bool _resultsAvailable = false;
        public override bool ResultsAvailable
        {
            get { return _resultsAvailable; }
        }

        protected bool _resultsFinal = false;
        public override bool ResultsFinal
        {
            get { return _resultsFinal; }
        }

        public override System.Windows.Forms.Form GetResultsForm()
        {
            if (this.ResultsAvailable)
                return new ClusterStatisticsResultsForm(_results);
            else
                return null;
        }

        protected ClusterStatisticsConfigOptions _options = new ClusterStatisticsConfigOptions();
        public override System.Windows.Forms.Form GetConfigForm()
        {
            return new ClusterStatisticsConfigForm(_options);
        }

        public override bool HasSpecialConfig
        {
            get
            {
                return true;
            }
        }

        public override void Reset()
        {
            this._options = new ClusterStatisticsConfigOptions();
            this._results = new AggregateClusterStats();
            this._resultsAvailable = false;
            this._resultsFinal = false;
            base.Reset();
        }

        public override void Start()
        {
            if (Ids.Count == 0)
            {
                this.FinishError("No Ids given. Check the Special Config.");
                return;
            }
            base.Start();
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

            Block_BasicInfo_Location[, ,] possibleNeighbors = FilteredChunk.GetVolume(
                Math.Max(0, OriginBlock.XChunk.Value - xDistMax), Math.Min(FilteredChunk.XDim - 1, OriginBlock.XChunk.Value + xDistMax),
                Math.Max(0, OriginBlock.YWorld.Value - yDistMax), Math.Min(FilteredChunk.YDim - 1, OriginBlock.YWorld.Value + yDistMax),
                Math.Max(0, OriginBlock.ZChunk.Value - zDistMax), Math.Min(FilteredChunk.ZDim - 1, OriginBlock.ZChunk.Value + zDistMax)
                );

            foreach (Block_BasicInfo_Location block in possibleNeighbors)
            {
                if(block != null)
                    if(!block.Equals(OriginBlock))
                        neighbors.Add(block);
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

            System.Threading.Interlocked.Increment(ref this.NumberOfChunksAnalyzed);

            return clusters;
        }

        protected void MergeClustersBottomToTop(List<ClusterDataPoint> Bottom, List<ClusterDataPoint> Top)
        {
        }

        /// <summary>
        /// Determines if two clusters have blocks adjacent to each other based on the DistMax vars. Compares world coordinates.
        /// </summary>
        /// <param name="A">A cluster.</param>
        /// <param name="B">B cluster.</param>
        /// <param name="xDistMax">The abs distance between blocks in the x plane.</param>
        /// <param name="yDistMax">The abs distance between blocks in the y plane.</param>
        /// <param name="zDistMax">The abs distance between blocks in the z plane.</param>
        /// <returns>Returns true if there exists a block in A within the DistMax of another block in B. If A == B, returns false.</returns>
        protected bool AreClustersAdjacent(ClusterDataPoint A, ClusterDataPoint B, int xDistMax, int yDistMax, int zDistMax)
        {
            if (A == B)
                return false;

            foreach (Block_BasicInfo_Location a in A.Blocks)
            {
                foreach (Block_BasicInfo_Location b in B.Blocks)
                {
                    if (Math.Abs(a.XWorld.Value - b.XWorld.Value) <= xDistMax)
                        return true;
                    if (Math.Abs(a.YWorld.Value - b.YWorld.Value) <= yDistMax)
                        return true;
                    if (Math.Abs(a.ZWorld.Value - b.ZWorld.Value) <= zDistMax)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Merges clusters together. Merged clusters are retained in Right and removed from Left.
        /// </summary>
        /// <param name="Left">A KeyValuePair with the chunk coordinates in the Key and a list of ClusterDataPoints in the Value.</param>
        /// <param name="Right">A KeyValuePair with the chunk coordinates in the Key and a list of ClusterDataPoints in the Value.</param>
        /// <param name="xDistMax"></param>
        /// <param name="yDistMax"></param>
        /// <param name="zDistMax"></param>
        /// <returns>Returns the number of chunks merged. Returns -1 if chunks aren't aligned correctly.</returns>
        protected List<KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>>> MergeClustersLeftToRight(KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>> Left, KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>> Right, int xDistMax, int yDistMax, int zDistMax)
        {
            if (Left.Key.Item2 + 1 != Right.Key.Item2)
                return null;

            List<ClusterDataPoint> removeList = new List<ClusterDataPoint>();

            foreach (ClusterDataPoint a in Left.Value.Where(x => x.ZMaxCoordChunk >= 16 - zDistMax))   // where the maxZCoord is the last block in the chunk
            {
                foreach (ClusterDataPoint b in Right.Value.Where(x => x.ZMinCoordChunk <= zDistMax)) // where the minZCoord is the first block of the chunk
                {
                    if (AreClustersAdjacent(a, b, xDistMax, yDistMax, zDistMax))
                    {
                        a.AddBlocks(b.Blocks);
                        b.AddBlocks(a.Blocks);
                        removeList.Add(a);
                    }
                }
            }

            List<KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>>> results = new List<KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>>>();
            
            results.Add(new KeyValuePair<Tuple<int,int>,List<ClusterDataPoint>>(Left.Key, removeList));

            return results;
        }

        /// <summary>
        /// Merges clusters together. Merged clusters are retained in Top and removed from Bottom.
        /// </summary>
        /// <param name="Bottom">A KeyValuePair with the chunk coordinates in the Key and a list of ClusterDataPoints in the Value.</param>
        /// <param name="Top">A KeyValuePair with the chunk coordinates in the Key and a list of ClusterDataPoints in the Value.</param>
        /// <returns>Returns the number of chunks merged. Returns -1 if chunks aren't aligned correctly.</returns>
        protected List<KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>>> MergeClustersBottomToTop(KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>> Bottom, KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>> Top, int xDistMax, int yDistMax, int zDistMax)
        {
            if (Bottom.Key.Item1 + 1 != Top.Key.Item1)
                return null;

            List<ClusterDataPoint> removeList = new List<ClusterDataPoint>();

            foreach (ClusterDataPoint a in Bottom.Value.Where(x => x.XMaxCoordChunk + 1 >= 16 - xDistMax))   // where the maxXCoord is the last block in the chunk
            {
                foreach (ClusterDataPoint b in Top.Value.Where(x => x.XMinCoordChunk + 1 <= xDistMax)) // where the minXCoord is the first block of the chunk
                {
                    if (AreClustersAdjacent(a, b, xDistMax, yDistMax, zDistMax))
                    {
                        a.AddBlocks(b.Blocks);
                        b.AddBlocks(a.Blocks);
                        removeList.Add(a);
                    }
                }
            }

            List<KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>>> results = new List<KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>>>();

            results.Add(new KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>>(Bottom.Key, removeList));

            return results;
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
                Tuple<int,int> key = new Tuple<int, int>(chunkOfClusters.First().Blocks.First().ChunkX.Value, chunkOfClusters.First().Blocks.First().ChunkZ.Value);
                orderedChunkClusters.Add(key, chunkOfClusters);
            }

            int minX = orderedChunkClusters.Keys.Min(tuple => tuple.Item1);
            int maxX = orderedChunkClusters.Keys.Max(tuple => tuple.Item1);
            int minZ = orderedChunkClusters.Keys.Min(tuple => tuple.Item2);
            int maxZ = orderedChunkClusters.Keys.Max(tuple => tuple.Item2);

            List<List<KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>>>> removeList = new List<List<KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>>>>();

            //OPTIMIZE: These two loops are just begging to be parallelized.
            // Theoretically could have a thread for each row and column since merging each row and column is independant from everything else (just lock the necessary chunks).
            // Could alternate threads (even and odd or something like that)

            // For each chunk row in the X-line (-x -> +x), iterate across the Z-line (-z -> +z).
            // Looking down upon the XZ-plane, with +X to the top and +Z to the right, we start at (-x, -z) and move towards +z until we reach maxZ.
            // Upon reaching maxZ, we reset to -z and move up one x-value (-x+1, -z), and repeat moving across the z-line.
            // We keep repeating until we reach (+x,+z).
            for(int x = minX; x <= maxX; x++)
            {
                List<ClusterDataPoint> prevClusters = null;
                Tuple<int, int> prevCoord = null;
                for(int z = minZ; z <= maxZ; z++)
                {
                    List<ClusterDataPoint> currClusters = null;
                    Tuple<int, int> currCoord = new Tuple<int, int>(x, z);
                    if (orderedChunkClusters.TryGetValue(currCoord, out currClusters))
                    {
                        if (prevClusters != null)
                        {
                            var needsToBeRemoved = MergeClustersLeftToRight(
                                new KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>>(prevCoord, prevClusters),
                                new KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>>(currCoord, currClusters),
                                XAbsMaxDist,
                                YAbsMaxDist,
                                ZAbsMaxDist);

                            removeList.Add(needsToBeRemoved);
                            /*
                            // if a merge happened, there are two cluster objects with exactly the same blocks, so get rid of one of those. doesn't matter which one.
                            // actually, it does a bit. it might mean that chunk the cluster is in doesn't get counted in the GUI. probabaly needs to be fixed...
                            if (merged)
                                orderedChunkClusters.Remove(prevCoord);
                                //orderedChunkClusters[prevCoord] = currClusters;
                            */
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

            for (int z = minZ; z <= maxZ; z++)
            {
                List<ClusterDataPoint> prevClusters = null;
                Tuple<int, int> prevCoord = null;
                for (int x = minX; x <= maxX; x++)
                {
                    List<ClusterDataPoint> currClusters = null;
                    Tuple<int, int> currCoord = new Tuple<int, int>(x, z);
                    if (orderedChunkClusters.TryGetValue(currCoord, out currClusters))
                    {
                        if (prevClusters != null)
                        {
                            var needsToBeRemoved = MergeClustersBottomToTop(
                                new KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>>(prevCoord, prevClusters),
                                new KeyValuePair<Tuple<int, int>, List<ClusterDataPoint>>(currCoord, currClusters),
                                XAbsMaxDist,
                                YAbsMaxDist,
                                ZAbsMaxDist);

                            removeList.Add(needsToBeRemoved);

                            /*
                            // if a merge happened, there are two cluster objects with exactly the same blocks, so get rid of one of those. doesn't matter which one.
                            // actually, it does a bit. it might mean that chunk the cluster is in doesn't get counted in the GUI. probabaly needs to be fixed...
                            if (merged)
                                orderedChunkClusters.Remove(prevCoord);
                                //orderedChunkClusters[prevCoord] = currClusters;
                             */
                        }

                        prevClusters = currClusters;
                        prevCoord = currCoord;
                    }
                }
            }

            foreach (var x in removeList)
            {
                foreach (var y in x)
                {
                    var key = y.Key;
                    foreach (var z in y.Value)
                    {
                        orderedChunkClusters[key].Remove(z);
                    }
                }
            }

            this._results = ClusterStats(orderedChunkClusters);
            this._resultsAvailable = true;
            this._resultsFinal = true;
        }

        protected AggregateClusterStats ClusterStats(Dictionary<Tuple<int, int>, List<ClusterDataPoint>> clusterData)
        {
            AggregateClusterStats results = new AggregateClusterStats();

            #region Add Clusters to results.Clusters
            foreach (List<ClusterDataPoint> list_of_cdp in clusterData.Values)
            {
                foreach (ClusterDataPoint cdp in list_of_cdp)
                {
                    results.Clusters.Add(cdp);
                }
            }
            #endregion

            #region BlocksPerClusterAvg
            int totalBlocksInClusters = 0;
            foreach(ClusterDataPoint cdp in results.Clusters)
            {
                totalBlocksInClusters += cdp.Blocks.Count;
            }

            results.BlocksPerClusterAvg = totalBlocksInClusters / results.Clusters.Count;
            #endregion
            #region ChunkMap
            Dictionary<Tuple<int,int>, bool> chunkMap = new Dictionary<Tuple<int,int>,bool>(clusterData.Keys.Count);
            foreach(Tuple<int,int> t in clusterData.Keys)
            {
                chunkMap.Add(t, true);
            }
            results.ChunkMap = chunkMap;
            #endregion
            #region CentroidHeatMapChunkXYPlane
            Dictionary<Tuple<int, int>, int> heatMap = new Dictionary<Tuple<int,int>,int>();
            foreach (ClusterDataPoint cdp in results.Clusters)
            {
                Tuple<int, int> key = new Tuple<int,int>(cdp.CentroidBlock.XChunk.Value, cdp.CentroidBlock.YWorld.Value);
                if (heatMap.ContainsKey(key))
                    heatMap[key] += 1;
                else
                    heatMap.Add(key, 1);
            }
            results.CentroidHeatMapChunkXYPlane = heatMap;
            #endregion
            #region CentroidHeatMapChunkXZPlane
            heatMap = new Dictionary<Tuple<int, int>, int>();
            foreach (ClusterDataPoint cdp in results.Clusters)
            {
                Tuple<int, int> key = new Tuple<int, int>(cdp.CentroidBlock.XChunk.Value, cdp.CentroidBlock.ZChunk.Value);
                if (heatMap.ContainsKey(key))
                    heatMap[key] += 1;
                else
                    heatMap.Add(key, 1);
            }
            results.CentroidHeatMapChunkXZPlane = heatMap;
            #endregion
            #region CentroidHeatMapChunkYZPlane
            heatMap = new Dictionary<Tuple<int, int>, int>();
            foreach (ClusterDataPoint cdp in results.Clusters)
            {
                Tuple<int, int> key = new Tuple<int, int>(cdp.CentroidBlock.YWorld.Value, cdp.CentroidBlock.ZChunk.Value);
                if (heatMap.ContainsKey(key))
                    heatMap[key] += 1;
                else
                    heatMap.Add(key, 1);
            }
            results.CentroidHeatMapChunkYZPlane = heatMap;
            #endregion
            #region ClusterLengthAvg
            int XLengthSum = 0;
            int YLengthSum = 0;
            int ZLengthSum = 0;
            foreach (ClusterDataPoint cdp in results.Clusters)
            {
                XLengthSum += cdp.XLength.Value;
                YLengthSum += cdp.YLength.Value;
                ZLengthSum += cdp.ZLength.Value;
            }
            results.ClusterXLengthAvg = XLengthSum / results.Clusters.Count;
            results.ClusterYLengthAvg = YLengthSum / results.Clusters.Count;
            results.ClusterZLengthAvg = ZLengthSum / results.Clusters.Count;
            #endregion
            results.Ids = this.Ids;
            return results;
        }

        protected List<HashSet<Block_BasicInfo>> Ids { get { return _options.Ids; } }
        protected int XAbsMaxDist { get { return _options.XAbsMaxDist; } }
        protected int YAbsMaxDist { get { return _options.YAbsMaxDist; } }
        protected int ZAbsMaxDist { get { return _options.ZAbsMaxDist; } }
    }
}
