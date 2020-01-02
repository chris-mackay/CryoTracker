//    CryoTracker is a cryo/freezer box contents tracker
//    Copyright(C) 2020 Christopher Ryan Mackay

//    This program Is free software: you can redistribute it And/Or modify
//    it under the terms Of the GNU General Public License As published by
//    the Free Software Foundation, either version 3 Of the License, Or
//    (at your option) any later version.

//    This program Is distributed In the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty Of
//    MERCHANTABILITY Or FITNESS FOR A PARTICULAR PURPOSE. See the
//    GNU General Public License For more details.

//    You should have received a copy Of the GNU General Public License
//    along with this program. If Not, see <http: //www.gnu.org/licenses/>.

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
