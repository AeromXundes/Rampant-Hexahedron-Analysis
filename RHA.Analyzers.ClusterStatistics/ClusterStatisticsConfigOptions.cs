using RHA.Analyzers.DataPoints.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterStatistics
{
    public class ClusterStatisticsConfigOptions
    {
        public List<HashSet<Block_BasicInfo>> Ids = new List<HashSet<Block_BasicInfo>>();
        public int XAbsMaxDist = 1;
        public int YAbsMaxDist = 1;
        public int ZAbsMaxDist = 1;
    }
}
