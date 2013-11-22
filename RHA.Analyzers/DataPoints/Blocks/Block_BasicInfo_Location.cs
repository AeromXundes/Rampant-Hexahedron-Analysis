using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHA.Analyzers.DataPoints.Blocks
{
    /// <summary>
    /// This class extends the Block_BasicInfo to include location information that can be compared.
    /// Compares based on location within the global game world, and will not match a block in another location. It doesn't care about ID:Data when comparing.
    /// </summary>
    public class Block_BasicInfo_Location
        : Block_BasicInfo, IEquatable<Block_BasicInfo_Location>,
        System.Collections.Generic.IEqualityComparer<Block_BasicInfo_Location>,
        IComparable<Block_BasicInfo_Location>,
        IComparer<Block_BasicInfo_Location>
    {
        #region Constructors
        public Block_BasicInfo_Location()
        {

        }
        public Block_BasicInfo_Location(Block_BasicInfo BasicBlock, int xWorld, int yWorld, int zWorld)
            :base(BasicBlock)
        {
            this.XWorld = xWorld;
            this.YWorld = yWorld;
            this.ZWorld = zWorld;
        }
        public Block_BasicInfo_Location(int xWorld, int yWorld, int zWorld)
        {
            this.XWorld = xWorld;
            this.YWorld = yWorld;
            this.ZWorld = zWorld;
        }
        /// <summary>
        /// 2D Constructor
        /// NOTE: this constructor only takes X and Z coordinates NOT X and *Y*.
        /// </summary>
        /// <param name="xWorld"></param>
        /// <param name="zWorld"></param>
        public Block_BasicInfo_Location(int xWorld, int zWorld)
        {
            this.XWorld = xWorld;
            this.ZWorld = zWorld;
        }
        #endregion

        #region Coordinates
        /// <summary>
        /// The x-coordinate in the game world.
        /// </summary>
        public int? XWorld { get; set; }

        /// <summary>
        /// The y-coordinate in the game world.
        /// </summary>
        public int? YWorld { get; set; }

        /// <summary>
        /// The z-coordinate in the game world.
        /// </summary>
        public int? ZWorld { get; set; }

        #endregion

        #region Distance Functions
        private double Distance(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            return Math.Sqrt(
                (x1 - x2) * (x1 - x2)
                + (y1 - y2) * (y1 - y2)
                + (z1 - z2) * (z1 - z2)
                );
        }

        /// <summary>
        /// Computes distance from the origin point in the xz-plane.
        /// </summary>
        /// <returns>-1.0 if XWorld or ZWorld is null; otherwise, the absolute distance.</returns>
        public double Distance2D()
        {
            if (!this.XWorld.HasValue || !this.ZWorld.HasValue)
                return -1.0;
            return this.Distance(this.XWorld.GetValueOrDefault(), 0, this.ZWorld.GetValueOrDefault(), 0, 0, 0);
        }

        /// <summary>
        /// Computes distance from an arbitary block in the xz-plane.
        /// </summary>
        /// <param name="block">An arbitrary block with XWorld and ZWorld not null.</param>
        /// <returns>-1.0 if XWorld or ZWorld is null; otherwise the absolute distance.</returns>
        public double Distance2D(Block_BasicInfo_Location block)
        {
            if (!this.XWorld.HasValue || !this.ZWorld.HasValue || !block.XWorld.HasValue || !block.ZWorld.HasValue)
                return -1.0;
            return this.Distance(this.XWorld.GetValueOrDefault(), 0, this.ZWorld.GetValueOrDefault(),
                block.XWorld.GetValueOrDefault(), 0, block.ZWorld.GetValueOrDefault());
        }

        /// <summary>
        /// Computes distance from the origin point in the xyz-space.
        /// </summary>
        /// <returns>-1.0 if XWorld, YWorld, or ZWorld is null; otherwise the absolute distance.</returns>
        public double Distance3D()
        {
            if (!this.XWorld.HasValue || !this.ZWorld.HasValue || !this.YWorld.HasValue)
                return -1.0;
            return this.Distance(this.XWorld.GetValueOrDefault(), this.YWorld.GetValueOrDefault(), this.ZWorld.GetValueOrDefault(), 0, 0, 0);
        }

        /// <summary>
        /// Computes absolute distance from an arbitrary block.
        /// </summary>
        /// <param name="block"></param>
        /// <returns>-1.0 if either this object's or the passed in block object's XWorld, YWorld, or ZWorld is null; otherwise the absolute distance.</returns>
        public double Distance3D(Block_BasicInfo_Location block)
        {
            if (!this.XWorld.HasValue || !this.ZWorld.HasValue || !this.YWorld.HasValue || !block.XWorld.HasValue || !block.ZWorld.HasValue || !block.YWorld.HasValue)
                return -1.0;
            return this.Distance(this.XWorld.GetValueOrDefault(), this.YWorld.GetValueOrDefault(), this.ZWorld.GetValueOrDefault(),
                block.XWorld.GetValueOrDefault(), block.YWorld.GetValueOrDefault(), block.ZWorld.GetValueOrDefault());
        }

        /// <summary>
        /// Computes the distance from an arbitrary point in xyz-space.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns>-1.0 if XWorld, YWorld, or ZWorld is null; otherwise the absolute distance.</returns>
        public double Distance3D(int X, int Y, int Z)
        {
            if (!this.XWorld.HasValue || !this.ZWorld.HasValue || !this.YWorld.HasValue)
                return -1.0;
            return this.Distance(this.XWorld.GetValueOrDefault(), this.YWorld.GetValueOrDefault(), this.ZWorld.GetValueOrDefault(), X, Y, Z);
        }
        #endregion
        #region IEquatityComparer Implementation
        /// <summary>
        /// Matches exactly where this block's chunk is in the world, where in that chunk it is located, and where in the world it is.
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns>Returns true if l1 is in the same location as l2.</returns>
        public static bool Equals(Block_BasicInfo_Location l1, Block_BasicInfo_Location l2)
        {
            return (
                   l1.XWorld == l2.XWorld
                && l1.YWorld == l2.YWorld
                && l1.ZWorld == l2.ZWorld
                );
        }

        public static int GetHashCode(Block_BasicInfo_Location obj)
        {
            // Bitwise OR these together.
            // The y is put in the high order 8 bits
            // OPTIMIZE: Might be able to come up with a better hashing function.
            int hCode = obj.YWorld.GetValueOrDefault() << 24
                      ^ obj.XWorld.GetValueOrDefault() << 8
                      ^ obj.ZWorld.GetValueOrDefault();
            return hCode;
        }
        #endregion
        #region IEquatable Implementation
        public bool Equals(Block_BasicInfo_Location other)
        {
            return Equals(this, other);
        }
        #endregion
        #region IComparable Implmentation
        /// <summary>
        /// Compares based on the absolute distance between two blocks.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Returns -1 if this block has a smaller distance from the origin than the other block, 0 if they are equal, 1 if greater.</returns>
        public int CompareTo(Block_BasicInfo_Location other)
        {
            return Compare(this, other);
        }
        #endregion
        #region IComparer Implementation
        public int Compare(Block_BasicInfo_Location x, Block_BasicInfo_Location y)
        {
            return x.Distance3D().CompareTo(y.Distance3D());
        }
        #endregion
    }
}
