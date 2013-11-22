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

namespace RHA.Analyzers.DataPoints.Blocks
{
    public class Block_BasicInfo
        : IEquatable<Block_BasicInfo>,
        IComparable<Block_BasicInfo>
    {
        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Block_BasicInfo()
        {
            this.Id = null;
            this.Data = null;
            this.Name = string.Empty;
        }
        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="block">The BlockBasicInfo object to copy from.</param>
        public Block_BasicInfo(Block_BasicInfo Block)
        {
            this.Id = Block.Id;
            this.Data = Block.Data;
            this.Name = Block.Name;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Id">The block Id.</param>
        public Block_BasicInfo(int Id)
        {
            this.Id     = Id;
            this.Data   = null;
            this.Name   = string.Empty;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Id">The block Id.</param>
        /// <param name="Name">The name of this block.</param>
        public Block_BasicInfo(int Id, string Name)
        {
            this.Id     = Id;
            this.Data   = null;
            this.Name   = Name;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Id">The block Id.</param>
        /// <param name="Data">The block's data value.</param>
        public Block_BasicInfo(int Id, int Data)
        {
            this.Id     = Id;
            this.Data   = Data;
            this.Name   = string.Empty;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Id">The block Id.</param>
        /// <param name="Data">The block's data value.</param>
        /// <param name="Name">The name of this block.</param>
        public Block_BasicInfo(int Id, int Data, string Name)
        {
            this.Id     = Id;
            this.Data   = Data;
            this.Name   = Name;
        }
        #endregion

        /// <summary>
        /// This block's ID.
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// The block's data value.
        /// </summary>
        public int? Data { get; set; }
        /// <summary>
        /// The name of this block.
        /// </summary>
        public string Name;

        #region IEquatable Implementation
        public bool Equals(Block_BasicInfo other)
        {
            return (this.Id == other.Id && this.Data == other.Data);
        }
        #endregion
        #region IComparable Implementation
        /// <summary>
        /// Compares based on ID, then on Data. Ignores Name.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Returns null if either has nulled Ids, or if Ids are the same, if either Data is null.
        /// Otherwise, it returns the comparison of Id, or in the case Id is the same, the comparison of Data.</returns>
        public int? CompareTo(Block_BasicInfo other)
        {
            if (!this.Id.HasValue || !other.Id.HasValue)
                return null;
            int result = this.Id.GetValueOrDefault().CompareTo(other.Id.GetValueOrDefault());
            if (result == 0)
                if (!this.Data.HasValue || !other.Data.HasValue)
                    return null;
                else
                    return this.Data.GetValueOrDefault().CompareTo(other.Id.GetValueOrDefault());
            else
                return result;
        }
        #endregion
    }
}
