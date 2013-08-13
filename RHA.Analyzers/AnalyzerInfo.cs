using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHA.Analyzers
{
    public class AnalyzerInfo
    {
        /// <summary>
        /// Constructor with optional parameters.
        /// </summary>
        /// <param name="Name">The name of the analyzer.</param>
        /// <param name="Version">The version of the analyzer.</param>
        /// <param name="Author">The author(s) of the analyzer.</param>
        /// <param name="Description">Description of the analyzer.</param>
        /// <param name="Url">Web link.</param>
        /// <param name="AdditionalInfo">Catch-all for anything that doesn't fit elsewhere.</param>
        public AnalyzerInfo(string Name, string Version, string Author, string Description = "", string Url = "", string AdditionalInfo = "")
        {
            this.Name = Name;
            this.Description = Description;
            this.Version = Version;
            this.Author = Author;
            this.Url = Url;
            this.AdditionalInfo = AdditionalInfo;
        }
        /// <summary>
        /// The name of this analyzer.
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// A description of what this analyzer does.
        /// </summary>
        public string Description { get; protected set; }
        /// <summary>
        /// Version string of this analyzer.
        /// </summary>
        public string Version { get; protected set; }
        /// <summary>
        /// Author(s) of this analyzer.
        /// </summary>
        public string Author { get; protected set; }
        /// <summary>
        /// Web link to more info or something...
        /// </summary>
        public string Url { get; protected set; }
        /// <summary>
        /// Additional information.
        /// 
        /// ...What? You expected something different?
        /// </summary>
        public string AdditionalInfo { get; protected set; }
    }
}
