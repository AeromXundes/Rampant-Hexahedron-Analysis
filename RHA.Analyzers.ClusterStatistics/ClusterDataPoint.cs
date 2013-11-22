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
        public HashSet<Block_BasicInfo> IdsWithinThisCluster { get; }
        public List<Block_BasicInfo_Location> Blocks { get; }
        public void AddBlock(Block_BasicInfo_Location block)
        {
            UpdateMinMaxCoords(block);
            IdsWithinThisCluster.Add(block);
            Blocks.Add(block);
            this._CentroidBlockValid = false;
        }
        public void AddBlocks(IEnumerable<Block_BasicInfo_Location> blocks)
        {
            foreach (Block_BasicInfo_Location b in blocks)
                AddBlock(b);
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
        public Block_BasicInfo_Location CentroidBlock { get { _UpdateCentroidBlock(); return _CentroidBlock; } }
        #endregion

        public int YHeight { get { return YMaxCoord - YMinCoord; } }
        public int XLength { get { return XMaxCoord - XMinCoord; } }
        public int ZLength { get { return ZMaxCoord - ZMinCoord; } }

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
        public int XMaxCoord { get; private set; }
        public int XMinCoord { get; private set; }
        public int YMaxCoord { get; private set; }
        public int YMinCoord { get; private set; }
        public int ZMaxCoord { get; private set; }
        public int ZMinCoord { get; private set; }
    }
}
