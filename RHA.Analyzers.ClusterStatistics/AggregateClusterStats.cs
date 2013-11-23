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
        double BlocksPerClusterAvg;
        double ClustersPerChunkAvg;
        double BlocksPerChunkAvg;
        List<int> CentroidHeatMapChunkXZPlane;
        List<int> CentroidHeatMapChunkXYPlane;
        List<int> CentroidHeatMapChunkYZPlane;
        double ClusterYLengthAvg;
        double ClusterXLengthAvg;
        double ClusterZLengthAvg;

        List<ClusterDataPoint> Clusters;
        Dictionary<Tuple<int, int>, bool> ChunkMap;
        Dictionary<Tuple<int, int>, Biome> BiomeMap;
    }
}
