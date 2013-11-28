using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RHA.Analyzers.DataPoints;

namespace ClusterStatistics
{
    public class AggregateClusterStats
    {
        public double BlocksPerClusterAvg;
        public double ClustersPerChunkAvg;
        public double BlocksPerChunkAvg;
        public Dictionary<Tuple<int, int>, int> CentroidHeatMapChunkXZPlane;
        public Dictionary<Tuple<int, int>, int> CentroidHeatMapChunkXYPlane;
        public Dictionary<Tuple<int, int>, int> CentroidHeatMapChunkYZPlane;
        public double ClusterYLengthAvg;
        public double ClusterXLengthAvg;
        public double ClusterZLengthAvg;

        public List<ClusterDataPoint> Clusters;
        public Dictionary<Tuple<int, int>, bool> ChunkMap;
        public Dictionary<Tuple<int, int>, Biome> BiomeMap;
    }
}
