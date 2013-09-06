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

namespace RHA.Analyzers
{
    /// <summary>
    /// This is the base interface for all analyzers. All implementing classes will be exported with MEF (Managed Extensibility Framework).
    /// </summary>
    /// <remarks>
    /// If you do not want your deriving class to be exported and show up in the main window drop-down menu, use the attribute [PartNotDiscoverable].
    /// See http://randomactsofcoding.blogspot.com/2009/11/working-with-managed-extensibility.html for tutorial on MEF.
    /// </remarks>
    [InheritedExport(typeof(IAnalyzer))]
    public interface IAnalyzer
    {
        /// <summary>
        /// The path to the Minecraft game world folder.
        /// </summary>
        string WorldFolderPath { get; set; }
        /// <summary>
        /// Delegate that will be called when analysis is complete.
        /// </summary>
        AnalysisFinished FinishedCallback { get; set; }
        /// <summary>
        /// The state of this object.
        /// </summary>
        AnalyzerState Status { get; }
        /// <summary>
        /// The progress of analysis.
        /// </summary>
        float Progress { get; }
        /// <summary>
        /// Get a string describing the stage this analyzer is in.
        /// </summary>
        string Stage { get; }
        /// <summary>
        /// Get information regarding this analyzer. Author, description, etc.
        /// </summary>
        AnalyzerInfo AnalyzerInfo { get; }
        /// <summary>
        /// Get the results.
        /// </summary
        /// <returns>Returns a generic object representing the results.
        /// There are no guarentees from this interface if there's actually data in there; you will have to look at the implementation.</returns>
        /// <remarks>
        /// Typically, you would implement this, and then hide this function with the new keyword and return a more specific data type in your derived class.
        /// See http://stackoverflow.com/a/5709191/1433521. This is called 'return type covariance' for future reference. C# doesn't explicitly support this, but the link shows a way to do it anyway.
        /// </remarks>
        object Results();

        /// <summary>
        /// Starts the analyzer. This returns immediately.
        /// </summary>
        void Start();
        /// <summary>
        /// Stops analysis if running; else, it does nothing. It returns immediately.
        /// Calling this method does not actually stop the analyzer. Rather, it starts the process of stopping.
        /// When <see cref="FinishedCallback"/> is called from this object, only then has the analyzer fully stopped.
        /// </summary>
        void Stop();
        /// <summary>
        /// Resets the analyzer to initial condition. It does not need to be called unless you are re-using the analyzer object.
        /// It should throw a <see cref="InvalidOperationException"/> when <see cref="Status"/> == <see cref="AnalyzerState"/>.Running.
        /// </summary>
        void Reset();

        /// <summary>
        /// True if this analyzer requires more configuration options than what has been specified in ParallelChunkAnalyzer.
        /// This property implies <see cref="HasSpecialConfig"/>.
        /// </summary>
        bool RequiresSpecialConfig { get; }
        /// <summary>
        /// True if this analyzer has other options configuration available. Use <see cref="GetConfigForm"/> to get the form.
        /// </summary>
        bool HasSpecialConfig { get; }
        /// <summary>
        /// If <see cref="<HasSpecialConfig"/> is true, you must use this to get the custom configuration form.
        /// </summary>
        /// <returns>Returns a custom config form. Default return is null, unless overridden.</returns>
        System.Windows.Forms.Form GetConfigForm();
        /// <summary>
        /// Property to determine if there are results ready. This does NOT mean the results are final.
        /// </summary>
        bool ResultsAvailable { get; }
        /// <summary>
        /// Property to determine if the results are final for this analysis, i.e. there is no more data to process and the results will not change.
        /// </summary>
        bool ResultsFinal { get; }
        /// <summary>
        /// Get the custom results form for this analyzer.
        /// </summary>
        /// <returns>Returns the custom results form for this analyzer. Can return null if results are not ready.</returns>
        System.Windows.Forms.Form GetResultsForm();
    }
}
