//    CryoTracker is a cryo/freezer box contents tracker
//    Copyright(C) 2018-2019 Christopher Ryan Mackay

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CryoTracker
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Version: " + ProductInfo.Version;
        }

        private void lblReleases_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(ProductInfo.Changelog);
            this.Dispose();
        }

        private void LblIconsSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"http://famfamfam.com/lab/icons/silk/");
            this.Dispose();
        }

        private void LblLicenseLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"https://creativecommons.org/licenses/by/2.5/");
            this.Dispose();
        }
    }
}
