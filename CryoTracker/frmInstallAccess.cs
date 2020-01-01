using System;
using System.Net;
using System.Windows.Forms;
using System.Diagnostics;

namespace CryoTracker
{
    public partial class frmInstallAccess : Form
    {
        public MainForm caller_MainForm;
        string access = string.Empty;

        public frmInstallAccess()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInstallAccess_FormClosed(object sender, FormClosedEventArgs e)
        {
            caller_MainForm.Close();
        }

        private void btnDownloadAccess_Click(object sender, EventArgs e)
        {
            DownloadAccessRuntime();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (Module.AccessIsInstalled() == true)
            {
                this.Cursor = Cursors.Default;
                this.Hide();

                Module.CreateCryoTrackerSettings_SetDefaults();
                caller_MainForm.LoadLocations();

                if (bool.Parse(Module.GetSettingsValue(Module.CryoTrackerSettings.SearchAsYouType)))
                {
                    caller_MainForm.btnSearch.Visible = false;
                }
                else
                {
                    caller_MainForm.btnSearch.Visible = true;
                }

                caller_MainForm.Show();
                return;
            }
            else
            {
                MessageBox.Show("Microsoft Access 2007 or 2010 must be installed before continuing. Your slot items are stored in Microsoft databases.\n\n" +
                                "If you don't have a copy you can download a standalone runtime engine for 2007 by clicking Download.", "Install Access 2007 or 2010", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Cursor = Cursors.Default;
            }
        }

        private void DownloadAccessRuntime()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            WebClient wbWebClient = new WebClient();
            string accessRuntimeFileToDownload = string.Empty;

            accessRuntimeFileToDownload = "https://cryotracker.github.io/AccessRuntime.exe";

            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = true;
            folderDialog.Description = "Select a location to download the Microsoft Office Access Runtime (English) 2007 installer.";

            string downloadPath = string.Empty;

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string downloadedFile = string.Empty;
                string fileName = string.Empty;
                fileName = "AccessRuntime.exe";

                downloadPath = folderDialog.SelectedPath;

                downloadedFile = downloadPath + "\\" + fileName;

                if (!System.IO.File.Exists(downloadedFile))
                {
                    btnDownloadAccess.Enabled = false;
                    btnFinish.Enabled = false;

                    DownloadAccessProgressBar.Value = 0;
                    DownloadAccessProgressBar.Visible = true;

                    wbWebClient.DownloadProgressChanged += client_ProgressChanged;
                    wbWebClient.DownloadFileCompleted += client_DownloadCompleted;

                    wbWebClient.DownloadFileAsync(new Uri(accessRuntimeFileToDownload), downloadedFile);
                    access = downloadedFile;
                }
                else
                {
                    MessageBox.Show("You already have a copy of this file saved in this location", "'" + fileName + "' already exists.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void client_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double dblBytesIn = 0;
            dblBytesIn = double.Parse(e.BytesReceived.ToString());

            double dblTotalBytes = 0;
            dblTotalBytes = double.Parse(e.TotalBytesToReceive.ToString());

            double dblPercentage = 0;
            dblPercentage = dblBytesIn / dblTotalBytes * 100;

            DownloadAccessProgressBar.Value = Int32.Parse(Math.Truncate(dblPercentage).ToString());
        }

        private void client_DownloadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Before CryoTracker can open you must run 'AccessRuntime.exe' " +
                                                  "to install Microsoft Office Access Runtime (English) 2007.\n\n Start installation?", "Download has completed", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                if (System.IO.File.Exists(access))
                {
                    try
                    {
                        Process.Start(access);
                    }
                    catch (Exception ex)
                    {
                        frmErrorReport errorReport = new frmErrorReport();
                        errorReport.txtError.Text = ex.ToString();
                        errorReport.ShowDialog();
                    }
                }
            }

            DownloadAccessProgressBar.Value = 0;
            DownloadAccessProgressBar.Visible = false;
            btnDownloadAccess.Enabled = true;
            btnFinish.Enabled = true;
        }
    }
}
