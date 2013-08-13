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

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RHA.Analyzers.BlockTypeCount
{
    public class BlockTypeCountResults : IEnumerable<BlockTypeCountDataPoint>
    {
        #region Constructors
        public BlockTypeCountResults()
        {

        }
        public BlockTypeCountResults(List<BlockTypeCountDataPoint> Data, long TotalNumberOfBlocks, long TotalNumberOfChunks)
        {
            this.__Data = Data;
            this.__TotalNumberOfBlocks = TotalNumberOfBlocks;
            this.__TotalNumberOfChunks = TotalNumberOfChunks;
        }
        #endregion

        #region IEnumerable Implementation
        public IEnumerator<BlockTypeCountDataPoint> GetEnumerator()
        {
            return this.__Data.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        protected List<BlockTypeCountDataPoint> __Data;
        public ReadOnlyCollection<BlockTypeCountDataPoint> Data
        {
            get
            {
                if (__Data == null)
                    return null;
                else
                    return __Data.AsReadOnly();
            }
        }
        public void SetData(List<BlockTypeCountDataPoint> value)
        {
            this.__Data = value;
        }

        protected long __TotalNumberOfBlocks;
        public long TotalNumberOfBlocks
        {
            get
            {
                return __TotalNumberOfBlocks;
            }
        }
        public void SetTotalNumberOfBlocks(long value)
        {
            this.__TotalNumberOfBlocks = value;
        }

        public long NumberOfUniqueTypesOfBlocks
        {
            get
            {
                if (this.__Data == null)
                    return 0;
                else
                    return this.__Data.Count;
            }
        }

        private long __TotalNumberOfChunks;
        public long TotalNumberOfChunks
        {
            get { return __TotalNumberOfChunks; }
        }
        public void SetTotalNumberOfChunks(long value)
        {
            this.__TotalNumberOfChunks = value;
        }
    }
}
