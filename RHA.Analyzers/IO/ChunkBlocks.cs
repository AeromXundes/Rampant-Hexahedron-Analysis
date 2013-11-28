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
// Website: http://RampantIntelligence.blogspot.com/RHA
// GitHub project: https://github.com/AeromXundes/Rampant-Hexahedron-Analysis
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RHA.Analyzers.DataPoints.Blocks;

namespace RHA.Analyzers.IO
{
    public class ChunkBlocks<T> : IEnumerable<T>
    {
        public static int DefaultXDim = 16;
        public static int DefaultYDim = 256;
        public static int DefaultZDim = 16;

        #region Constructors
        public ChunkBlocks()
        {
            this.XDim = DefaultXDim;
            this.YDim = DefaultYDim;
            this.ZDim = DefaultZDim;

            this.Blocks = new T[XDim, YDim, ZDim];
            this.ChunkX = -1;
            this.ChunkZ = -1;
        }
        /// <summary>
        /// Deep-copy constructor. Copies the whole Blocks array, so be careful when using this.
        /// </summary>
        /// <param name="blocks"></param>
        public ChunkBlocks(ChunkBlocks<T> blocks)
        {
            this.XDim = blocks.XDim;
            this.YDim = blocks.YDim;
            this.ZDim = blocks.ZDim;

            this.Blocks = new T[XDim, YDim, ZDim];
            for (int x = 0; x < XDim; x += 1)
            {
                for (int y = 0; y < YDim; y += 1)
                {
                    for (int z = 0; z < ZDim; z += 1)
                    {
                        this.Blocks[x, y, z] = blocks.Blocks[x, y, z];
                    }
                }
            }

            this.ChunkX = blocks.ChunkX;
            this.ChunkZ = blocks.ChunkZ;
        }
        public ChunkBlocks(int ChunkX, int ChunkZ)
        {
            this.XDim = DefaultXDim;
            this.YDim = DefaultYDim;
            this.ZDim = DefaultZDim;

            this.Blocks = new T[XDim, YDim, ZDim];
            this.ChunkX = ChunkX;
            this.ChunkZ = ChunkZ;
        }
        public ChunkBlocks(int XDim, int YDim, int ZDim)
        {
            this.XDim = XDim;
            this.YDim = YDim;
            this.ZDim = ZDim;

            this.Blocks = new T[XDim, YDim, ZDim];
            this.ChunkX = -1;
            this.ChunkZ = -1;
        }
        public ChunkBlocks(int XDim, int YDim, int ZDim, int ChunkX, int ChunkY)
        {
            this.XDim = XDim;
            this.YDim = YDim;
            this.ZDim = ZDim;

            this.Blocks = new T[XDim, YDim, ZDim];
            this.ChunkX = ChunkX;
            this.ChunkZ = ChunkY;
        }
        #endregion

        public int XDim { get; protected set; }
        public int YDim { get; protected set; }
        public int ZDim { get; protected set; }

        public T[, ,] Blocks { get; protected set; }

        public int ChunkX { get; protected set; }
        public int ChunkZ { get; protected set; }

        /// <summary>
        /// Get the Nth X plane of the chunk.
        /// </summary>
        /// <param name="X">The nth X-plane of the chunk. Zero indexed. Must be 0 &lt;= X &lt; XDim.</param>
        /// <returns>T[YDim, ZDim]</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when X &gt; XDim or X &lt; 0.</exception>
        public T[,] GetSliceX(int X)
        {
            if (X > XDim)
                throw new ArgumentOutOfRangeException("X", "X cannot exceed BlocksFromChunk.XDim (" + this.XDim + ").");
            if (X < 0)
                throw new ArgumentOutOfRangeException("X", "X cannot be less than zero.");

            T[,] data = new T[YDim, ZDim];
            for (int i = 0; i < YDim; i += 1)
            {
                for (int j = 0; j < ZDim; j += 1)
                {
                    data[i, j] = Blocks[X, i, j];
                }
            }
            return data;
        }
        /// <summary>
        /// Get the Nth Y plane of the chunk.
        /// </summary>
        /// <param name="Y">The nth Y-plane of the chunk. Zero indexed. Must be 0 &lt;= Y &lt; YDim.</param>
        /// <returns>T[XDim, ZDim].</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Y &gt; YDim or Y &lt; 0.</exception>
        public T[,] GetSliceY(int Y)
        {
            if (Y > YDim)
                throw new ArgumentOutOfRangeException("Y", "Y cannot exceed BlocksFromChunk.YDim (" + this.YDim + ").");
            if (Y < 0)
                throw new ArgumentOutOfRangeException("Y", "Y cannot be less than zero.");

            T[,] data = new T[XDim, ZDim];
            for (int i = 0; i < XDim; i += 1)
            {
                for (int j = 0; j < ZDim; j += 1)
                {
                    data[i, j] = Blocks[i, Y, j];
                }
            }
            return data;
        }
        /// <summary>
        /// Get the Nth Z plane of the chunk.
        /// </summary>
        /// <param name="Z">The nth Z-plane of the chunk. Zero indexed. Must be 0 &lt;= Z &lt; ZDim.</param>
        /// <returns>T[XDim, YDim].</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Z &gt; ZDim or Z &lt; 0.</exception>
        public T[,] GetSliceZ(int Z)
        {
            if (Z > ZDim)
                throw new ArgumentOutOfRangeException("Z", "Z cannot exceed BlocksFromChunk.ZDim (" + this.ZDim + ").");
            if (Z < 0)
                throw new ArgumentOutOfRangeException("Z", "Z cannot be less than zero.");

            T[,] data = new T[XDim, YDim];
            for (int i = 0; i < XDim; i += 1)
            {
                for (int j = 0; j < YDim; j += 1)
                {
                    data[i, j] = Blocks[i, j, Z];
                }
            }
            return data;
        }

        private int Distance(int x, int y)
        {
            int result = x - y;
            return result;
        }
        
        /// <summary>
        /// Get a volume bounded by x, y, and z (each independant of each other) inclusive.
        /// </summary>
        /// <param name="xMinBound"></param>
        /// <param name="xMaxBound"></param>
        /// <param name="yMinBound"></param>
        /// <param name="yMaxBound"></param>
        /// <param name="zMinBound"></param>
        /// <param name="zMaxBound"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfBounds">Thrown when the min bounds are less than 0, or max bounds are more than the chunk dimensions.</exception>
        public T[,,] GetVolume(int xMinBound, int xMaxBound, int yMinBound, int yMaxBound, int zMinBound, int zMaxBound)
        {
            #region Bounds Checking
            if (xMinBound < 0)
                throw new ArgumentOutOfRangeException("xMinBound", "xMinBound can't be less than 0.");
            if (yMinBound < 0)
                throw new ArgumentOutOfRangeException("yMinBound", "yMinBound can't be less than 0.");
            if (zMinBound < 0)
                throw new ArgumentOutOfRangeException("zMinBound", "zMinBound can't be less than 0.");
            if (xMaxBound > this.XDim)
                throw new ArgumentOutOfRangeException("xMaxBound", "xMaxBound can't be more than this chunk's XDim.");
            if (yMaxBound > this.YDim)
                throw new ArgumentOutOfRangeException("yMaxBound", "yMaxBound can't be more than this chunk's YDim.");
            if (zMaxBound > this.ZDim)
                throw new ArgumentOutOfRangeException("zMaxBound", "zMaxBound can't be more than this chunk's ZDim.");
            #endregion
            T[, ,] result = new T[Distance(xMaxBound, xMinBound) + 1, Distance(yMaxBound, yMinBound) + 1, Distance(zMaxBound, zMinBound) + 1];

            for (int x = xMinBound, i = 0; x <= xMaxBound; x++, i++)
            {
                for (int y = yMinBound, j = 0; y <= yMaxBound; y++, j++)
                {
                    for (int z = zMinBound, k = 0; z <= zMaxBound; z++, k++)
                    {
                        result[i, j, k] = this.Blocks[x, y, z];
                    }
                }
            }

            return result;
        }

        public T this[int x, int y, int z]
        {
            get
            {
                return GetBlock(x, y, z);
            }
            set
            {
                SetBlock(x, y, z, value);
            }
        }

        public T GetBlock(int x, int y, int z)
        {
            return this.Blocks[x, y, z];
        }
        public void SetBlock(int x, int y, int z, T block)
        {
            this.Blocks[x, y, z] = block;
        }

        #region IEnumerable Interface Implementations
        public IEnumerator<T> GetEnumerator()
        {
            for (int x = 0; x < XDim; x += 1)
            {
                for (int y = 0; y < YDim; y += 1)
                {
                    for (int z = 0; z < ZDim; z += 1)
                    {
                        yield return this[x, y, z];
                    }
                }
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }
}
