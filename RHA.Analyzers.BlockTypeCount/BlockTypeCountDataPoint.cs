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

using RHA.Analyzers.DataPoints.Blocks;

namespace RHA.Analyzers.BlockTypeCount
{
    public class BlockTypeCountDataPoint : Block_BasicInfo
    {
        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public BlockTypeCountDataPoint()
            : base()
        {
            this.Count = 0;
        }
        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="Block"></param>
        public BlockTypeCountDataPoint(Block_BasicInfo Block)
            : base(Block)
        {
            this.Count = 0;
        }
        public BlockTypeCountDataPoint(Block_BasicInfo Block, long Count)
            : base(Block)
        {
            this.Count = Count;
        }
        public BlockTypeCountDataPoint(BlockTypeCountDataPoint Block)
            : base((Block_BasicInfo)Block)
        {
            this.Count = Block.Count;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Id">The block Id.</param>
        /// <param name="Data">The block's data value.</param>
        public BlockTypeCountDataPoint(int Id, int Data)
            : base(Id, Data)
        {
            this.Count = 0;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Id">The block Id.</param>
        /// <param name="Data">The block's data value.</param>
        /// <param name="Count">Count of this block type.</param>
        public BlockTypeCountDataPoint(int Id, int Data, long Count)
            : base(Id, Data)
        {
            this.Count = Count;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Id">The block Id.</param>
        /// <param name="Data">The block's data value.</param>
        /// <param name="Name">The name of this block.</param>
        public BlockTypeCountDataPoint(int Id, int Data, string Name)
            : base(Id, Data, Name)
        {
            this.Count = 0;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Id">The block Id.</param>
        /// <param name="Data">The block's data value.</param>
        /// <param name="Name">The name of this block.</param>
        /// <param name="Count">Count of this block type.</param>
        public BlockTypeCountDataPoint(int Id, int Data, string Name, long Count)
            : base(Id, Data, Name)
        {
            this.Count = Count;
        }
        #endregion

        /// <summary>
        /// Count of this block type.
        /// </summary>
        public long Count { get; set; }
    }
}
