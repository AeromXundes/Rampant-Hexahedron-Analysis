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
