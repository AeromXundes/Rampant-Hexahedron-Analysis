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

using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using RHA.Analyzers;
using System.Reflection;

namespace RHA
{
    internal class PluginsComposer
    {
        /*
         * Pretty much this entire class uses things from http://randomactsofcoding.blogspot.com/2009/11/working-with-managed-extensibility.html.
         * If you don't know MEF, go read that tutorial. It's great.
         */

        public PluginsComposer ()
            :this(@"Analyzers\")
	    {
            
	    }
        public PluginsComposer(string PluginsFolder)
        {
            this.PluginsFolder = PluginsFolder;
            this.Compose();
        }

        [ImportMany(typeof(IAnalyzer))]
        public IEnumerable<IAnalyzer> Analyzers { get; set; }
        public string PluginsFolder { get; private set; }

        private void Compose()
        {
            var catalog = new AggregateCatalog(new DirectoryCatalog(this.PluginsFolder), new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
}
