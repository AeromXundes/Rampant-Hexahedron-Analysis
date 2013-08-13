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
        public static ChunkBlocks ReadChunk(Substrate.ChunkRef Chunk)
        {
            ChunkBlocks blocks = new ChunkBlocks(Chunk.Blocks.XDim, Chunk.Blocks.YDim, Chunk.Blocks.ZDim, Chunk.X, Chunk.Z);

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
