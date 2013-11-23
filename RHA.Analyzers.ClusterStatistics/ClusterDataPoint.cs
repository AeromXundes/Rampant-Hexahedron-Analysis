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

using RHA.Analyzers.DataPoints.Blocks;

namespace ClusterStatistics
{
    /// <summary>
    /// A class for everything regarding a cluster of blocks.
    /// Very much thread-unsafe, especially regarding centroid computation.
    /// </summary>
    /// <remarks>
    /// Designed for a set of connected blocks, but there's no reason why it couldn't be used for an unconnected set of blocks.
    /// You can only have one block in one block location. It just doesn't make sense any other way, and it allows the use of a HashSet for performance look ups.
    /// </remarks>
    public class ClusterDataPoint
    {
        /// <summary>
        /// All the Id:Data pairs this cluster has.
        /// </summary>
        public HashSet<Block_BasicInfo> IdsWithinThisCluster { get; private set; }
        /// <summary>
        /// The blocks in this cluster.
        /// It's a HashSet because you can't have more than one block in one location!
        /// </summary>
        public HashSet<Block_BasicInfo_Location> Blocks { get; private set; }
        /// <summary>
        /// Add a block to this cluster.
        /// </summary>
        /// <param name="block"></param>
        public void AddBlock(Block_BasicInfo_Location block)
        {
            UpdateMinMaxCoords(block);
            IdsWithinThisCluster.Add(block);
            Blocks.Add(block);
            this._CentroidBlockValid = false;
        }
        /// <summary>
        /// Add a range of blocks to this cluster.
        /// </summary>
        /// <param name="blocks"></param>
        public void AddBlocks(IEnumerable<Block_BasicInfo_Location> blocks)
        {
            foreach (Block_BasicInfo_Location b in blocks)
                AddBlock(b);
        }
        /// <summary>
        /// Removes a block from this cluster.
        /// This is an O(n) operation, where n is the number of blocks in the cluster..
        /// </summary>
        /// <param name="block"></param>
        public void RemoveBlock(Block_BasicInfo_Location block)
        {
            this._CentroidBlockValid = false;
            Blocks.Remove(block);
            InitMinMaxCoords();
        }

        /// <summary>
        /// Amount of blocks in this cluster.
        /// </summary>
        public int Count { get { return Blocks.Count; } }

        #region Centroid Stuff
        /// <summary>
        /// Returns a location-info-only block with the centroid as the coordinates.
        /// </summary>
        /// <returns></returns>
        private void _UpdateCentroidBlock()
        {
            if (_CentroidBlockValid)
                return;

            int x = 0;
            int y = 0;
            int z = 0;

            foreach (Block_BasicInfo_Location b in Blocks)
            {
                x += b.XWorld.GetValueOrDefault();
                y += b.YWorld.GetValueOrDefault();
                z += b.ZWorld.GetValueOrDefault();
            }

            x /= Blocks.Count;
            y /= Blocks.Count;
            z /= Blocks.Count;

            _CentroidBlock = new Block_BasicInfo_Location(x, y, z);
            _CentroidBlockValid = true;
        }
        private Block_BasicInfo_Location _CentroidBlock;
        private bool _CentroidBlockValid = false;
        /// <summary>
        /// The average Euclidian center of all the points.
        /// Null coordinates are considered to be 0 for centroid computation.
        /// Caches the result until an Add or Remove operation.
        /// O(n) time for computation. O(1) time for retrieving the cached result.
        /// </summary>
        public Block_BasicInfo_Location CentroidBlock { get { _UpdateCentroidBlock(); return _CentroidBlock; } }
        #endregion

        /// <summary>
        /// The distance between XMaxCoord and XMinCoord
        /// </summary>
        public int XLength { get { return XMaxCoord - XMinCoord; } }
        /// <summary>
        /// The distance between YMaxCoord and YMinCoord
        /// </summary>
        public int YLength { get { return YMaxCoord - YMinCoord; } }
        /// <summary>
        /// The distance between ZMaxCoord and ZMinCoord
        /// </summary>
        public int ZLength { get { return ZMaxCoord - ZMinCoord; } }

        /// <summary>
        /// Recalculates the min-max coords. O(n) operation.
        /// Useful when removing blocks.
        /// </summary>
        private void InitMinMaxCoords()
        {
            XMaxCoord = 0;
            XMinCoord = 0;
            YMaxCoord = 0;
            YMinCoord = 0;
            ZMaxCoord = 0;
            ZMinCoord = 0;
            foreach (Block_BasicInfo_Location b in Blocks)
            {
                UpdateMinMaxCoords(b);
            }
        }
        /// <summary>
        /// Updates the min-max coords when adding a new block. Does not work with removing.
        /// </summary>
        /// <param name="block"></param>
        private void UpdateMinMaxCoords(Block_BasicInfo_Location block)
        {
            if (XMaxCoord < block.XWorld.Value)
                XMaxCoord = block.XWorld.Value;
            if (XMinCoord > block.XWorld.Value)
                XMinCoord = block.XWorld.Value;

            if (YMaxCoord < block.YWorld.Value)
                YMaxCoord = block.YWorld.Value;
            if (YMinCoord > block.YWorld.Value)
                YMinCoord = block.YWorld.Value;

            if (ZMaxCoord < block.ZWorld.Value)
                ZMaxCoord = block.ZWorld.Value;
            if (ZMinCoord > block.ZWorld.Value)
                ZMinCoord = block.ZWorld.Value;
        }
        /// <summary>
        /// The largest x-coord of all the blocks. O(1) operation.
        /// </summary>
        public int XMaxCoord { get; private set; }
        /// <summary>
        /// The smallest x-coord of all the blocks. O(1) operation.
        /// </summary>
        public int XMinCoord { get; private set; }
        /// <summary>
        /// The largest y-coord of all the blocks. O(1) operation.
        /// </summary>
        public int YMaxCoord { get; private set; }
        /// <summary>
        /// The smallest y-coord of all the blocks. O(1) operation.
        /// </summary>
        public int YMinCoord { get; private set; }
        /// <summary>
        /// The largest z-coord of all the blocks. O(1) operation.
        /// </summary>
        public int ZMaxCoord { get; private set; }
        /// <summary>
        /// The smallest z-coord of all the blocks. O(1) operation.
        /// </summary>
        public int ZMinCoord { get; private set; }
    }
}
