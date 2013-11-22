using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RHA.Analyzers.DataPoints.Blocks;

namespace ClusterStatistics
{
    public class ClusterDataPoint
    {
        /// <summary>
        /// All the Id:Data pairs this cluster has.
        /// </summary>
        public HashSet<Block_BasicInfo> IdsWithinThisCluster { get; private set; }
        /// <summary>
        /// The blocks in this cluster.
        /// </summary>
        public List<Block_BasicInfo_Location> Blocks { get; private set; }
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

        /// <summary>
        /// Determines whether the block location is in this cluster. Only compares location data; it ignores Id:Data values.
        /// If location lies outside of the cubiod bounded by the min-max coords, it fails in O(1) time; otherwise, it is O(n).
        /// </summary>
        /// <param name="block">Block location</param>
        /// <returns>Returns true if this cluster has this block location in it.</returns>
        public bool ContainsLocation(Block_BasicInfo_Location block)
        {
            if (!block.XWorld.HasValue || !block.YWorld.HasValue || !block.ZWorld.HasValue)
                throw new ArgumentException("block has a null coordinate.");
            int x = block.XWorld.Value;
            int y = block.YWorld.Value;
            int z = block.ZWorld.Value;
            
            // check the O(1) stuff first
            if (x > XMaxCoord)
                return false;
            if (x < XMinCoord)
                return false;
            if (y > YMaxCoord)
                return false;
            if (y < YMinCoord)
                return false;
            if (z > ZMaxCoord)
                return false;
            if (z < ZMinCoord)
                return false;
            
            // okay, it /might/ be in the collection, run the O(n) operation.
            return Blocks.Contains(block);
        }
        /// <summary>
        /// Determines whether the block location is in this cluster. Only compares location data; it ignores Id:Data values.
        /// If location lies outside of the cubiod bounded by the min-max coords, it fails in O(1) time; otherwise, it is O(n).
        /// </summary>
        /// <returns>Returns true if this cluster has this block location in it.</returns>
        public bool ContainsLocation(int x, int y, int z)
        {
            return ContainsLocation(new Block_BasicInfo_Location(x, y, z));
        }

        #region Centroid Stuff
        /// <summary>
        /// Returns a location-info-only block with the centroid as the coordinates. Thread safe-ish.
        /// </summary>
        /// <returns></returns>
        private void _UpdateCentroidBlock()
        {
            lock (Blocks)
            {
                if (_CentroidBlockValid)
                    return;

                int x = 0;
                int y = 0;
                int z = 0;

                foreach (Block_BasicInfo_Location b in Blocks)
                {
                    x += b.XWorld.Value;
                    y += b.YWorld.Value;
                    z += b.ZWorld.Value;
                }

                x /= Blocks.Count;
                y /= Blocks.Count;
                z /= Blocks.Count;

                _CentroidBlock = new Block_BasicInfo_Location(x, y, z);
                _CentroidBlockValid = true;
            }
        }
        private Block_BasicInfo_Location _CentroidBlock;
        private bool _CentroidBlockValid = false;
        /// <summary>
        /// The average Euclidian center of all the points.
        /// The first operation and after invalidating operations (add, remove, etc.) is O(n), later operations are O(1).
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
        public int YHeight { get { return YMaxCoord - YMinCoord; } }
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
