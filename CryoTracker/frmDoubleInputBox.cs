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

using System.Windows.Forms;

namespace CryoTracker
{
    public partial class frmDoubleInputBox : Form
    {
        public frmDoubleInputBox()
        {
            InitializeComponent();
        }

        private void frmDoubleInputBox_Paint(object sender, PaintEventArgs e)
        {
            Module.SetFormColors(this);
        }

        private void BtnOK_Click(object sender, System.EventArgs e)
        {
            //Remove the illegal characters
            txtNewName.Text = Module.GetSafeFilename(txtNewName.Text);
        }
    }
}
