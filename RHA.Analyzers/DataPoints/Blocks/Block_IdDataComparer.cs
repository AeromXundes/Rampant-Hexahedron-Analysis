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
    /// <summary>
    /// Comparer for BlockBasicInfo (and derived classes). It only compares Id and Data.
    /// </summary>
    public class Block_IdDataComparer : System.Collections.Generic.IEqualityComparer<Block_BasicInfo>
    {
        public bool Equals(Block_BasicInfo b1, Block_BasicInfo b2)
        {
            return (b1.Id == b2.Id && b1.Data == b2.Data);
        }

        public int GetHashCode(Block_BasicInfo b)
        {
            int hCode = (int)b.Id ^ (int)b.Data;
            return hCode.GetHashCode();
        }
    }
}
