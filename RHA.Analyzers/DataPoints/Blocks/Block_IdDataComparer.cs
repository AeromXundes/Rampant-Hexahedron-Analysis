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
