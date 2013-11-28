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
        public List<HashSet<Block_BasicInfo>> Ids;
        public int XAbsMaxDist;
        public int YAbsMaxDist;
        public int ZAbsMaxDist;
    }
}
