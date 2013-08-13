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
