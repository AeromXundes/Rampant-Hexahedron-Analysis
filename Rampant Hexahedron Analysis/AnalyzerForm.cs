using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RHA.Analyzers;

namespace RHA
{
    public partial class AnalyzerForm : Form
    {
        public AnalyzerForm(IAnalyzer Analyzer)
        {
            InitializeComponent();
            this.Analyzer = Analyzer;

            this.UpdateTimer = new System.Timers.Timer(500);
            this.UpdateTimer.AutoReset = true;
            this.UpdateTimer.Elapsed += UpdateTimer_Elapsed;
            this.UpdateTimer.SynchronizingObject = this;

            try
            {
                this.Analyzer.FinishedCallback += this.FinishedCallback;
                this.Text = Analyzer.AnalyzerInfo.Name;
                this.label_AnalyzerName.Text = Analyzer.AnalyzerInfo.Name;
                this.toolTip1.SetToolTip(this.label_AnalyzerName, Analyzer.AnalyzerInfo.Version);
                this.button_SpecialConfig.Enabled = this.Analyzer.HasSpecialConfig;
                this.button_Results.Enabled = this.Analyzer.ResultsAvailable;
                this.label_ProgressText.Text = this.Analyzer.Stage;
                this.textBox_Path.Text = this.Analyzer.WorldFolderPath;
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("This analyzer does not properly implement the IAnalyzer interface.\n\nThings may not behave correctly.");
            }
        }

        private IAnalyzer Analyzer;
        private bool Running;
        private string Path;
        private System.Timers.Timer UpdateTimer;

        void UpdateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(this.UpdateProgress));
            else
                this.UpdateProgress();
        }

        void UpdateProgress()
        {
            this.progressBar1.Value = (int)(this.Analyzer.Progress * 100.0);
            this.label_ProgressText.Text = this.Analyzer.Stage;
            this.button_Results.Enabled = this.Analyzer.ResultsAvailable;
        }

        private void SwitchRunning(bool RunningState)
        {
            if (RunningState)
            {
                this.button_SpecialConfig.Enabled = false;
                this.textBox_Path.ReadOnly = true;
                this.button_Browse.Enabled = false;
                this.button_StartStop.Text = "Stop";
                this.Running = true;
                this.label_ProgressText.Text = "Starting...";
                
            }
            else
            {
                this.button_SpecialConfig.Enabled = this.Analyzer.HasSpecialConfig;
                this.textBox_Path.ReadOnly = false;
                this.button_Browse.Enabled = true;
                this.button_StartStop.Text = "Start!";
                this.Running = false;
            }
        }

        private void FinishedCallback(AnalyzerFinishState State, IAnalyzer Analyzer, string Message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<AnalyzerFinishState, IAnalyzer, string>(this.FinishedCallback), State, Analyzer, Message);
                return;
            }
            if (this.IsDisposed || this.Disposing)
                return;
            this.UpdateTimer.Stop();
            this.UpdateProgress();
            switch (State)
            {
                case AnalyzerFinishState.Faulted:
                    MessageBox.Show(Message);
                    this.label_ProgressText.Text = "Analysis encountered an error.";
                    break;
                case AnalyzerFinishState.Cancelled:
                    this.label_ProgressText.Text = "Analysis cancelled.";
                    break;
                case AnalyzerFinishState.Complete:
                    this.label_ProgressText.Text = "Analysis complete!";
                    break;
                default:
                    MessageBox.Show("Analysis returned with an unknown state.\n\nPerhaps RHA is out of date?");
                    this.label_ProgressText.Text = "Analysis returned with an unknown state.";
                    break;
            }
            // StopAnalysis set this to false to prevent spamming.
            this.button_StartStop.Enabled = true;
            SwitchRunning(false);
            this.button_Results.Enabled = this.Analyzer.ResultsAvailable;
        }

        private bool AskIfSure(string Question)
        {
            var result = MessageBox.Show(Question, "Are you sure?", MessageBoxButtons.YesNoCancel);
            switch (result)
            {
                case System.Windows.Forms.DialogResult.Yes:
                    return true;
                case System.Windows.Forms.DialogResult.Cancel:
                case System.Windows.Forms.DialogResult.No:
                default:
                    return false;
            }
        }

        private void StopAnalysis()
        {
            this.button_StartStop.Text = "Stopping...";
            this.button_StartStop.Enabled = false;
            try
            {
                this.Analyzer.Stop();
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("This analyzer does not implement the IAnalyzer.Stop() function!");
                this.button_StartStop.Text = "Can't stop!";
            }
        }

        private void StartAnalysis()
        {
            try
            {
                this.SwitchRunning(true);
                this.Analyzer.Start();
                this.UpdateTimer.Start();
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("This analyzer does not implement IAnalyzer.Start().");
                this.SwitchRunning(false);
                this.UpdateTimer.Stop();
            }
        }

        #region GUI Event Handlers
        private void button_SpecialConfig_Click(object sender, EventArgs e)
        {
            bool hasConfig;
            try
            {
                hasConfig = Analyzer.HasSpecialConfig;
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("This analyzer does not implement IAnalyzer.HasSpecialConfig.");
                return;
            }

            if (hasConfig)
            {
                try
                {
                    Form form = this.Analyzer.GetConfigForm();
                    if (form != null)
                        form.Show();
                }
                catch (NotImplementedException)
                {
                    MessageBox.Show("This analyzer does not implement IAnalyzer.GetConfigForm().");
                }
            }
        }

        private void button_Browse_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Path = folderBrowserDialog1.SelectedPath;
                this.textBox_Path.Text = this.Path;
            }
        }

        private void button_StartStop_Click(object sender, EventArgs e)
        {
            if (Running)
            {
                if (!AskIfSure("Are you sure you want to stop analysis?"))
                    return;
                this.StopAnalysis();
            }
            else
                this.StartAnalysis();
        }

        private void button_Results_Click(object sender, EventArgs e)
        {
            bool resultsAvail;
            try
            {
                resultsAvail = this.Analyzer.ResultsAvailable;
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("This analyzer does not implement IAnalyzer.ResultsAvailable.");
                return;
            }
            Form form;
            if (resultsAvail)
            {
                try
                {
                    form = this.Analyzer.GetResultsForm();
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    MessageBox.Show("An exception occurred. Could not find a file. Perhaps you are missing a .dll or other file?\n\n" +
                        "Source:\n" +
                        ex.Source +
                        "\n\nMessage:\n" +
                        ex.Message,
                        "Could not find file",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                if (form != null)
                    form.Show();
                else
                    MessageBox.Show("The analyzer reports results are ready, but it isn't providing a form (via IAnalyzer.GetResultsForm()) to show the results.");
            }
            else
                MessageBox.Show("The analyzer says there's no results ready!");
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AnalyzerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Running)
            {
                if (AskIfSure("Are you sure you want to close this analyzer?"))
                    this.StopAnalysis();
                else
                    e.Cancel = true;
            }
        }

        private void AnalyzerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.Analyzer.Reset();
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("This analyzer does not implement the IAnalyzer.Reset() function!\n\nThis analyzer may not function properly if you run it again without restarting the RHA application.");
            }
        }

        private void textBox_Path_TextChanged(object sender, EventArgs e)
        {
            this.Analyzer.WorldFolderPath = this.textBox_Path.Text;
        }
        #endregion
    }
}
