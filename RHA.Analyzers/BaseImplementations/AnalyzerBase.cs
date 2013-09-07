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
// Website: http://RampantIntelligence.blogspot.com/p/RHA
// GitHub project: https://github.com/AeromXundes/Rampant-Hexahedron-Analysis
#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RHA.Analyzers.BaseImplementations
{
    public abstract class AnalyzerBase<P, R>
    {
        protected abstract void Initialize();
        protected abstract void Main();
        void test()
        {
            object o = new object();
            Func<object, R> fr = new Func<object, R>((a) => { Console.WriteLine(a.ToString()); return default(R); });
            TaskFactory<R> tf = new TaskFactory<R>();
            Task<R> task = tf.StartNew(fr, o);
        }
        protected abstract Func<P, R>[] GetAnalyzers { get; }
        protected abstract Func<P, R>[] GetSummarizers { get; }
    }
}
