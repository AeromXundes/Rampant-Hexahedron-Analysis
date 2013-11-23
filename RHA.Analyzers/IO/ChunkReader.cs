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
using Substrate;
using Substrate.Core;

using RHA.Analyzers.DataPoints.Blocks;

namespace RHA.Analyzers.IO
{
    public static class ChunkReader
    {
        public static ChunkBlocks<Block_BasicInfo> ReadChunk(Substrate.ChunkRef Chunk)
        {
            ChunkBlocks<Block_BasicInfo> blocks = new ChunkBlocks<Block_BasicInfo>(Chunk.Blocks.XDim, Chunk.Blocks.YDim, Chunk.Blocks.ZDim, Chunk.X, Chunk.Z);

            int xdim = Chunk.Blocks.XDim;
            int ydim = Chunk.Blocks.YDim;
            int zdim = Chunk.Blocks.ZDim;

            for (int x = 0; x < xdim; x += 1)
            {
                for (int z = 0; z < zdim; z += 1)
                {
                    for (int y = 0; y < ydim; y += 1)
                    {
                        blocks[x, y, z] = new Block_BasicInfo(
                            Chunk.Blocks.GetID(x, y, z),
                            Chunk.Blocks.GetData(x, y, z),
                            Chunk.Blocks.GetInfo(x, y, z).Name
                            );
                    }
                }
            }
            return blocks;
        }
    }
}
