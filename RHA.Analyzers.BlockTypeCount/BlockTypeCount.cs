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
using RHA.Analyzers.DataPoints.Blocks;
using RHA.Analyzers.BaseImplementations;

namespace RHA.Analyzers.BlockTypeCount
{
    public class BlockTypeCount : ParallelChunkAnalyzer<Dictionary<Block_BasicInfo, long>>
    {
        protected BlockTypeCountResults __Results;

        protected override object GetResults()
        {
            return this.Results();
        }

        public new BlockTypeCountResults Results()
        {
            return __Results;
        }

        protected override Dictionary<Block_BasicInfo,long> Analyze(IO.ChunkBlocks Chunk, System.Threading.CancellationToken CancelToken)
        {
            Dictionary<Block_BasicInfo, long> data = new Dictionary<Block_BasicInfo, long>(new Block_IdDataComparer());

            foreach (Block_BasicInfo b in Chunk)
            {
                if (!data.ContainsKey(b))
                    data.Add(b, 1);
                else
                    data[b] += 1;
            }

            System.Threading.Interlocked.Increment(ref this.NumberOfChunksAnalyzed);

            return data;
        }

        protected override void Summarize(Dictionary<Block_BasicInfo,long>[] Data, System.Threading.CancellationToken CancelToken)
        {
            var t = Data.GetType();
            Dictionary<Block_BasicInfo, long>[] castedData = Data;
            //Dictionary<Block_BasicInfo, long>[] castedData = (Dictionary<Block_BasicInfo, long>[])Data;
            Dictionary<Block_BasicInfo, long> tempResults = new Dictionary<Block_BasicInfo, long>(castedData[0].Count * castedData.Length, new Block_IdDataComparer());

            long TotalNumberOfBlocks = 0;
            long TotalNumberOfChunks = 0;

            foreach (var countArray in castedData)
            {
                TotalNumberOfChunks += 1;
                foreach (var count in countArray)
                {
                    TotalNumberOfBlocks += count.Value;
                    if (!tempResults.ContainsKey(count.Key))
                        tempResults.Add(count.Key, count.Value);
                    else
                        tempResults[count.Key] += count.Value;
                }
            }

            List<BlockTypeCountDataPoint> results = new List<BlockTypeCountDataPoint>(tempResults.Count);

            foreach (var val in tempResults)
            {
                results.Add(new BlockTypeCountDataPoint(val.Key, val.Value));
            }

            this.__Results = new BlockTypeCountResults(results, TotalNumberOfBlocks, TotalNumberOfChunks);
        }

        protected BlockTypeCountResultsForm ResultsForm;
        public override System.Windows.Forms.Form GetResultsForm()
        {
            if (this.__Results == null)
                return null;
            else
                return new BlockTypeCountResultsForm(__Results);
        }

        private AnalyzerInfo _AnalyzerInfo = new AnalyzerInfo("BlockTypeCount", "v0.5.0", "Aerom Xundes", "Counts each type of block in the game.");
        public override AnalyzerInfo AnalyzerInfo
        {
            get { return _AnalyzerInfo; }
        }

        public override bool ResultsAvailable
        {
            get { return true; }
        }

        public override bool ResultsFinal
        {
            get { return false; }
        }
    }
}
