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

namespace RHA.Analyzers.DataPoints.Blocks
{
    /// <summary>
    /// This class extends the Block_BasicInfo to include location information that can be compared.
    /// Compares based on location within the global game world, and will not match a block in another location. It doesn't care about ID:Data when comparing.
    /// </summary>
    public class Block_BasicInfo_Location
        : Block_BasicInfo, IEquatable<Block_BasicInfo_Location>,
        IComparable<Block_BasicInfo_Location>
    {
        #region Constructors
        /// <summary>
        /// Default constructor. Sets all coordinates to null.
        /// </summary>
        public Block_BasicInfo_Location()
        {
            this._XWorld = null;
            this._YWorld = null;
            this._ZWorld = null;
        }
        public Block_BasicInfo_Location(Block_BasicInfo BasicBlock, int xWorld, int yWorld, int zWorld)
            :base(BasicBlock)
        {
            this._XWorld = xWorld;
            this._YWorld = yWorld;
            this._ZWorld = zWorld;
        }
        public Block_BasicInfo_Location(int? xWorld, int? yWorld, int? zWorld)
        {
            this._XWorld = xWorld;
            this._YWorld = yWorld;
            this._ZWorld = zWorld;
        }
        /// <summary>
        /// 2D Constructor
        /// NOTE: this constructor only takes X and Z coordinates NOT X and *Y*.
        /// Sets YWorld to null.
        /// </summary>
        /// <param name="xWorld"></param>
        /// <param name="zWorld"></param>
        public Block_BasicInfo_Location(int xWorld, int zWorld)
        {
            this._XWorld = xWorld;
            this._YWorld = null;
            this._ZWorld = zWorld;
        }
        #endregion

        #region Coordinates
        private readonly int? _XWorld;
        /// <summary>
        /// The x-coordinate in the game world.
        /// </summary>
        public int? XWorld { get { return _XWorld; } }
        private readonly int? _YWorld;
        /// <summary>
        /// The y-coordinate in the game world.
        /// </summary>
        public int? YWorld { get { return _YWorld; } }
        private readonly int? _ZWorld;
        /// <summary>
        /// The z-coordinate in the game world.
        /// </summary>
        public int? ZWorld { get { return _ZWorld; } }

        #endregion

        /// <summary>
        /// Because C# implements the % operator as remainder and not modulo division...
        /// </summary>
        /// <param name="x"></param>
        /// <param name="m"></param>
        /// <returns>Returns a true modulo division.</returns>
        protected int mod(int x, int m)
        {
            int r = x % m;
            return r < 0 ? r + m : r;
        }

        #region Chunk Coordinates
        /// <summary>
        /// This block's coordinate within a chunk.
        /// </summary>
        public int? XChunk { get { return (XWorld.HasValue) ? (int?)mod(XWorld.Value, 16) : null; } }
        //public int? XChunk { get { return (XWorld.HasValue) ? (int?)Math.Abs(XWorld.Value % 16) + ((XWorld < 0) ? 15 : 0) : null; } }
        /// <summary>
        /// This block's coordinate within a chunk.
        /// </summary>
        public int? ZChunk { get { return (ZWorld.HasValue) ? (int?)mod(ZWorld.Value, 16) : null; } }
        /// <summary>
        /// The chunk coordinate this block is in.
        /// </summary>
        public int? ChunkX 
        { 
            get 
            { 
                return (XWorld.HasValue) ? (int?)Math.Floor(XWorld.Value / 16.0) : null;
            }
        }
        /// <summary>
        /// The chunk coordinate this block is in.
        /// </summary>
        public int? ChunkZ 
        { 
            get 
            { 
                return (ZWorld.HasValue) ? (int?)Math.Floor(ZWorld.Value / 16.0) : null; 
            } 
        }
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
        #region IEquatable Implementation
        /// <summary>
        /// Compares the x,y, and z coordinates for equality.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Returns true when the x, y, and z coordinates are an exact match.</returns>
        public bool Equals(Block_BasicInfo_Location other)
        {
            return (
                   this.XWorld == other.XWorld
                && this.YWorld == other.YWorld
                && this.ZWorld == other.ZWorld
                );
        }
        #endregion
        #region IComparable Implmentation
        /// <summary>
        /// Compares based on the absolute distance between two blocks.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Returns -1 if this block has a smaller distance from the origin than the other block, 0 if they are equal, 1 if greater.</returns>
        /// <exception cref="InvalidOperationException">Thrown when either location has null coordinates.</exception>
        public int CompareTo(Block_BasicInfo_Location other)
        {
            double d1 = this.Distance3D();
            double d2 = this.Distance3D();
            if (d1.Equals(-1.0) || d2.Equals(-1.0))
                throw new InvalidOperationException("Can't operate on null coordinates!");
            return d1.CompareTo(d2);
        }
        #endregion
        #region Object Overrides
        /// <summary>
        /// Hashes the coordinate values.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            // Bitwise OR these together.
            // The y is put in the high order 8 bits
            // OPTIMIZE: Might be able to come up with a better hashing function.

            // The idea is that the y-level will never be above 255, so shift that over to the last 2 bytes (<< 24)
            // Most x and z coordinates are within 4096, so AND off anything higher. Move the the x coord inbetween the y and z coords.
            // Remember, we're making a hashcode with an acceptable amount of colisions.
            /*
             * With each letter representing a 4-bit section, the format is:
             * YYXX XZZZ
             */
            int hCode = this.YWorld.GetValueOrDefault() << 24
                      | (this.XWorld.GetValueOrDefault() & 0xFFF) << 8
                      | (this.ZWorld.GetValueOrDefault() & 0xFFF);
            return hCode;
        }
        public override string ToString()
        {
            return "X: " + (this.XWorld.HasValue ? this.XWorld.GetValueOrDefault().ToString() : "?")
                + " Y: " + (this.YWorld.HasValue ? this.YWorld.GetValueOrDefault().ToString() : "?")
                + " Z: " + (this.ZWorld.HasValue ? this.ZWorld.GetValueOrDefault().ToString() : "?");
        }
        /// <summary>
        /// Compares the x,y, and z coordinates for equality.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Returns true when the x, y, and z coordinates are an exact match.</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Block_BasicInfo_Location);
        }
        #endregion
    }
}
