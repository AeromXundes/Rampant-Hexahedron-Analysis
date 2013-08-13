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

using Substrate;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RHA.Analyzers.BaseImplementations
{
    /// <summary>
    /// Base class for the default parallel chunk analysis of Minecraft game worlds.
    /// It abstracts away many of the smaller details of chunk analysis so deriving classes can focus on the analysis algorthim.
    /// </summary>
    /// <remarks>
    /// See <see cref="BlockTypeCount"/> to see a simple deriviation of this class.
    /// 
    /// Usage:
    /// Derive this class. Implement <see cref="Analyze"/>, <see cref="Summarize"/>, <see cref="Results"/>, <see cref="Name"/>, and <see cref="GetResultsForm"/>.
    /// Create an instance of the derived class and set <see cref="WorldFolderPath"/>. It is recommended to set the Callback delegates
    /// so your code can be notified when this object has completed analysis, but is not strictly required. Calling <see cref="Start"/>
    /// will start the analysis by calling <see cref="Main"/>.
    /// 
    /// If you need custom config options, override <see cref="RequiresSpecialConfig"/> and return true. Also, override <see cref="GetConfigForm"/>
    /// and return the form you want the user to see.
    /// </remarks>
    /// <seealso cref="BlockTypeCount"/>
    /// <typeparam name="T">The type of data returned by <see cref="Analyze"/> and the array parameter in <see cref="Summerize"/>.</typeparam>
    public abstract class ParallelChunkAnalyzer<T> : IAnalyzer
    {
        #region Constructors
        public ParallelChunkAnalyzer()
        {
        }
        public ParallelChunkAnalyzer(string WorldFolderPath)
        {
            this.WorldFolderPath = WorldFolderPath;
        }
        public ParallelChunkAnalyzer(string WorldFolderPath, AnalysisFinished FinishedCallback)
        {
            this.WorldFolderPath = WorldFolderPath;
            this.FinishedCallback = FinishedCallback;
        }
        #endregion

        #region IAnalyzer Implementation
        /// <summary>
        /// The path to the Minecraft game world folder.
        /// </summary>
        public virtual string WorldFolderPath { get; set; }
        /// <summary>
        /// Delegate that will be called when analysis is complete.
        /// </summary>
        public virtual AnalysisFinished FinishedCallback { get; set; }
        /// <summary>
        /// The state of this object.
        /// </summary>
        public virtual AnalyzerState Status { get; protected set; }
        /// <summary>
        /// Get NumberOfChunksAnalyzed / NumberOfChunksDiscovered
        /// </summary>
        public virtual float Progress
        {
            get
            {
                return this.NumberOfChunksDiscovered == 0 ? 0 : (float)this.NumberOfChunksAnalyzed / (float)this.NumberOfChunksDiscovered;
            }
        }
        /// <summary>
        /// Get a string describing the stage this analyzer is in.
        /// </summary>
        public virtual string Stage { get; set; }

        /// <summary>
        /// Get information regarding this analyzer.
        /// </summary>
        public abstract AnalyzerInfo AnalyzerInfo { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract object GetResults();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual object Results() { return this.GetResults(); }

        /// <summary>
        /// Starts analysis. If already running, throws <see cref="InvalidOperationException"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when analyzer is already running (see <see cref="Status"/>).</exception>
        public virtual void Start()
        {
            if (this.Status == AnalyzerState.Running)
                throw new InvalidOperationException("Analyzer already running.");
            this.Status = AnalyzerState.Running;
            Task.Run(() => Main());
        }
        /// <summary>
        /// Requests cancellation of analysis. Does nothing if the analyzer is not running (see <see cref="Status"/>).
        /// </summary>
        public virtual void Stop()
        {
            if (this.Status != AnalyzerState.Running)
                return;
            this.Status = AnalyzerState.Cancelling;
            this.CancelSource.Cancel();
        }
        /// <summary>
        /// Reset this analyzer to initial state.
        /// Deriving classes should override this and call this function while resetting their own variables.
        /// </summary>
        public virtual void Reset()
        {
            this.CancelSource = null;
            this.CancelToken = default(CancellationToken);
            this.NumberOfChunksRead = 0;
            this.NumberOfChunksDiscovered = 0;
            this.NumberOfChunksAnalyzed = 0;
        }

        /// <summary>
        /// True if this analyzer requires more configuration options than what has been specified in ParallelChunkAnalyzer.
        /// This property implies <see cref="HasSpecialConfig"/>.
        /// </summary>
        public virtual bool RequiresSpecialConfig { get { return false; } }
        /// <summary>
        /// True if this analyzer has other options configuration available. Use <see cref="GetConfigForm"/> to get the form.
        /// </summary>
        public virtual bool HasSpecialConfig { get { return RequiresSpecialConfig; } }
        /// <summary>
        /// If <see cref="<HasSpecialConfig"/> is true, you must use this to get the custom configuration form.
        /// </summary>
        /// <returns>Returns a custom config form. Default return is null, unless overridden.</returns>
        public virtual System.Windows.Forms.Form GetConfigForm() { return null; }
        /// <summary>
        /// Property to determine if there are results ready. This does NOT mean the results are final.
        /// </summary>
        public abstract bool ResultsAvailable { get; }
        /// <summary>
        /// Property to determine if the results are final for this analysis, i.e. there is no more data to process and the results will not change.
        /// </summary>
        public abstract bool ResultsFinal { get; }
        /// <summary>
        /// Get the custom results form for this analyzer.
        /// </summary>
        /// <returns>Returns the custom results form for this analyzer. Can return null if results are not ready.</returns>
        public abstract System.Windows.Forms.Form GetResultsForm();
        #endregion

        #region Important functions
        // Override these functions in your derived classes.
        // In particular, you have to implement Analyze() and Summarize().

        /// <summary>
        /// Called from Start() on a seperate thread.
        /// Calls Initialize().
        /// Handles reading world chunks into Analyze().
        /// Gives resulting data to Summarize().
        /// Finally calls Finish().
        /// 
        /// If you override this function, be sure to increment <see cref="NumberOfChunksRead"/>
        /// </summary>
        protected virtual void Main()
        {
            // Initialize everything. Except world.
            this.Initialize();

            // Get the world...
            NbtWorld world = this.GetWorld();
            // ...check that it isn't null.
            if (world == null)
            {
                // If it is null, error out.
                this.FinishError("World ('" + this.WorldFolderPath + "') could not be opened.");
                return;
            }

            var chunkManager = world.GetChunkManager();

            // Count how many chunks there are total in the game world.
            foreach (var chunk in chunkManager)
            {
                Interlocked.Increment(ref NumberOfChunksDiscovered);
            }

            List<Task<T>> analyzerTasks = new List<Task<T>>();

            // Loop through each chunk in the world.
            foreach (ChunkRef chunk in chunkManager)
            {
                // Check for a cancel request.
                if (this.CancelToken.IsCancellationRequested)
                {
                    FinishCancel();
                    return;
                }

                // Read the chunk blocks from the disk.
                // Called on this thread.
                IO.ChunkBlocks blocks = IO.ChunkReader.ReadChunk(chunk);

                // Queue the chunk blocks just read to be analyzed.
                // Analysis is done on a *seperate thread*.
                analyzerTasks.Add(
                    Task<T>.Factory.StartNew(
                        () => Analyze(blocks, CancelToken),
                        CancelToken)
                    );
                // Atomically increment this number since we're dealing with threads.
                Interlocked.Increment(ref NumberOfChunksRead);
            }

            Task<T>[] analyzerTaskArray = analyzerTasks.ToArray();

            try
            {
                // Wait for all the analyzer tasks to finish.
                Task.WaitAll(analyzerTaskArray, CancelToken);
            }
            catch (AggregateException e)
            {
                throw e.Flatten();
            }

            // Check for cancel request.
            if (CancelToken.IsCancellationRequested)
            {
                FinishCancel();
                return;
            }

            // Copy the results from analysis to a convienent array.
            T[] analyzerResults = new T[analyzerTaskArray.Length];
            for (int i = 0; i < analyzerTaskArray.Length; i += 1)
            {
                analyzerResults[i] = analyzerTaskArray[i].Result;
            }

            // Check for cancel request.
            if (CancelToken.IsCancellationRequested)
            {
                FinishCancel();
                return;
            }

            // Call Summarize on *this thread*.
            // Reasoning is that most of the data will simply need to be copied and/or summed,
            // which would be hard to speed up by concurrent processing.
            this.Summarize(analyzerResults, CancelToken);

            // Check for cancel request.
            if (CancelToken.IsCancellationRequested)
            {
                FinishCancel();
                return;
            }

            // Call the finalizer to clean up anything left over.
            this.FinishComplete();
        }
        /// <summary>
        /// Called first in Main(). Use this to define what happens before anything else, like initializing variables.
        /// </summary>
        protected virtual void Initialize()
        {
            this.NumberOfChunksAnalyzed = 0;
            this.NumberOfChunksDiscovered = 0;
            this.NumberOfChunksRead = 0;
            this.CancelSource = new CancellationTokenSource();
            this.CancelToken = CancelSource.Token;
        }
        /// <summary>
        /// Function to analyze the data from a single chunk.
        /// Default Main() behavior is to call this function as a Task, meaning it will be concurrently processing with other Analyze() calls.
        /// Default Main() behavior is to queue this function as a Task as soon as it reads the chunk from the disk.
        /// Default Main() behavior is to pass all returned values from this function as an array to Summarize().
        /// This function should atomically increment <see cref="NumberOfChunksAnalyzed"/>.
        /// </summary>
        /// <param name="Chunk">The chunk data.</param>
        /// <param name="CancelToken">The CancelToken cancel requests will be passed by.</param>
        /// <returns>Returns the results from analysis.</returns>
        protected abstract T Analyze(IO.ChunkBlocks Chunk, CancellationToken CancelToken);
        /// <summary>
        /// Function to tabulate the data collected by Analyze().
        /// Default Main() behavior is to wait for all Analyze tasks to complete before calling this function.
        /// Default Main() behavior is that this function will called on the same thread as Main() itself.
        /// Results should be set here or in Finish() if you override that function.
        /// </summary>
        /// <param name="Data">Array of data from Analyze tasks. Each element represents the result from a single Analyze() call.</param>
        /// <param name="CancelToken">The CancelToken cancellation requests will be passed by. Check this periodically on long-running calcuations.</param>
        protected abstract void Summarize(T[] Data, CancellationToken CancelToken);
        #endregion

        #region Protected helper functions and variables.
        /// <summary>
        /// Finishes any remaining operations left over from analysis. Sets the object's state to reflect completion. Calls the correct callback to tell the world about the finished analysis.
        /// Default Main() behavior is to only call this function if analysis completes.
        /// </summary>
        protected virtual void FinishComplete()
        {
            this.Status = AnalyzerState.RanToCompletion;
            if (this.FinishedCallback != null)
                this.FinishedCallback(AnalyzerFinishState.Complete, this, string.Empty);
        }
        /// <summary>
        /// Sets object's state to reflect a cancellation request ended analysis. Calls the cancel delegate.
        /// Default Main() behavior is to call this if a cancel request is received.
        /// </summary>
        protected virtual void FinishCancel()
        {
            this.Status = AnalyzerState.Cancelled;
            if (this.FinishedCallback != null)
                this.FinishedCallback(AnalyzerFinishState.Cancelled, this, "Analysis cancelled.");
        }
        /// <summary>
        /// Set's object's state to reflect an error was encountered. Calls the error delegate.
        /// Default Main() behavior does not call this function.
        /// </summary>
        /// <param name="ErrorMessage"></param>
        protected virtual void FinishError(string ErrorMessage)
        {
            this.Status = AnalyzerState.Faulted;
            if (this.FinishedCallback != null)
                this.FinishedCallback(AnalyzerFinishState.Faulted, this, ErrorMessage);
        }

        /// <summary>
        /// Gets a NbtWorld object by calling NbtWorld.Open(). Does NOT do any error checking.
        /// </summary>
        /// <returns>A NbtWorld object pointing to the WorldFolderPath world.</returns>
        protected virtual NbtWorld GetWorld()
        {
            return NbtWorld.Open(this.WorldFolderPath);
        }

        #region Variables set by Initialize()
        /// <summary>
        /// Used to tell the analyze tasks to cancel.
        /// </summary>
        protected CancellationTokenSource CancelSource;
        /// <summary>
        /// Used to tell the analyze tasks to cancel.
        /// </summary>
        protected CancellationToken CancelToken;
        /// <summary>
        /// If not overriden, this variable is incremented each time a new chunk is read from disk in <see cref="Main"/>.
        /// </summary>
        protected int NumberOfChunksRead;
        /// <summary>
        /// If not overriden, this variable is set in <see cref="Main"/> to how many total chunks there are in the game world.
        /// Used in the calculation of <see cref="Progress"/>.
        /// </summary>
        protected int NumberOfChunksDiscovered;
        /// <summary>
        /// Used to keep track of how many chunks have been analyzed. This abstract class does not increment this variable; that must be done in your implementation of <see cref="Analyze"/>.
        /// Used in the calculation of <see cref="Progress"/>.
        /// </summary>
        protected int NumberOfChunksAnalyzed;
        #endregion
        #endregion
    }
}
