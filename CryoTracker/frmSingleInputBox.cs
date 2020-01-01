//    CryoTracker is a cryo/freezer box contents tracker
//    Copyright(C) 2018-2019 Christopher Ryan Mackay

using System.Windows.Forms;

namespace CryoTracker
{
    public partial class frmSingleInputBox : Form
    {
        public frmSingleInputBox()
        {
            InitializeComponent();
        }

        private void frmSingleInputBox_Paint(object sender, PaintEventArgs e)
        {
            Module.SetFormColors(this);
        }

        private void BtnOK_Click(object sender, System.EventArgs e)
        {
            //Remove the illegal characters
            txtInput.Text = Module.GetSafeFilename(txtInput.Text);
        }
    }
}
