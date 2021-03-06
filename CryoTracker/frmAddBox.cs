﻿//    CryoTracker is a cryo/freezer box contents tracker
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
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CryoTracker
{
    public partial class frmAddBox : Form
    {
        public MainForm caller_MainForm;

        public frmAddBox()
        {
            InitializeComponent();
        }

        private void CheckUserInput(object sender, EventArgs e)
        {
            if (txtBoxName.Text == string.Empty || cbRacks.Text == string.Empty || cbBoxSizes.SelectedIndex < 0)
            {
                btnOK.Enabled = false;
            }
            else
            {
                btnOK.Enabled = true;
            }
        }

        private void frmAddBox_Load(object sender, EventArgs e)
        {
            Module.BoxAttachmentFileToCopy = string.Empty;
            Module.BoxAttachmentNameToDelete = string.Empty;

            Module.MySystemRenderer renderer = new Module.MySystemRenderer();
            toolStrip1.Renderer = renderer;

            if (txtBoxName.Text == string.Empty || cbRacks.Text == string.Empty)
            {
                btnOK.Enabled = false;
            }
            else
            {
                btnOK.Enabled = true;
            }
        }

        private void DeleteRack(object sender, EventArgs e)
        {
            if (cbRacks.Text != string.Empty)
            {
                string selectedRack = string.Empty;
                selectedRack = cbRacks.Text;

                if (Directory.Exists(Module.SetRack(Module.CurrentLocation, selectedRack)))
                {
                    if (MessageBox.Show("Are you sure you want to delete " + selectedRack + "?\n\n This will delete all boxes. This cannot be undone.", "Delete Rack", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        try
                        {
                            Directory.Delete(Module.SetRack(Module.CurrentLocation, selectedRack), true);
                            Module.LoadRacks(Module.CurrentLocation, cbRacks);
                            cbRacks.Text = string.Empty;
                            caller_MainForm.LoadListView(Module.CurrentLocation);
                        }
                        catch (Exception ex)
                        {
                            frmErrorReport errorReport = new frmErrorReport();
                            errorReport.txtError.Text = ex.ToString();
                            errorReport.ShowDialog();
                        }
                    }
                }
            }
        }

        private void frmAddBox_Paint(object sender, PaintEventArgs e)
        {
            Module.SetFormColors(this);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbRacks.Text != string.Empty)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Select attachment file";
                ofd.Filter = "All Files (*.*)|*.*";
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                ofd.FileName = string.Empty;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string file = Module.SetBoxAttachmentFile(Module.CurrentLocation, cbRacks.Text, txtBoxName.Text, Path.GetFileName(txtAttachment.Text));

                    if (!File.Exists(file))
                    {
                        Module.BoxAttachmentFileToCopy = ofd.FileName;
                        txtAttachment.Text = Path.GetFileName(ofd.FileName);
                    }
                    else
                    {
                        MessageBox.Show("The file provided already exists. Please provide a file with a unique filename.", "File Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("A rack must be selected before attaching a file", "Select Rack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Module.BoxAttachmentNameToDelete = txtAttachment.Text;
            txtAttachment.Text = string.Empty;
        }

        #region DescriptionBox

        private void TsUndo_Click(object sender, EventArgs e)
        {
            txtDescription.Undo();
        }

        private void TsRedo_Click(object sender, EventArgs e)
        {
            txtDescription.Redo();
        }

        private void TsCut_Click(object sender, EventArgs e)
        {
            txtDescription.Cut();
        }

        private void TsCopy_Click(object sender, EventArgs e)
        {
            txtDescription.Copy();
        }

        private void TsPaste_Click(object sender, EventArgs e)
        {
            txtDescription.Paste();
        }

        private void TsFontColor_Click(object sender, EventArgs e)
        {
            ColorDialog clr = new ColorDialog();
            clr.FullOpen = true;

            if (clr.ShowDialog() == DialogResult.OK)
            {
                txtDescription.SelectionColor = clr.Color;
            }
        }

        private void TsSymbols_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Windows\System32\charmap.exe");
        }

        private void TsFont_Click(object sender, EventArgs e)
        {
            FontDialog fnt = new FontDialog();
            fnt.Font = txtDescription.SelectionFont;

            if (fnt.ShowDialog() == DialogResult.OK)
            {
                txtDescription.SelectionFont = fnt.Font;
            }
        }

        private void TsBold_Click(object sender, EventArgs e)
        {
            if (txtDescription.SelectionLength > 0)
            {
                Font fnt = new Font(txtDescription.SelectionFont, FontStyle.Bold);
                txtDescription.SelectionFont = fnt;
            }
        }

        private void TsUnderline_Click(object sender, EventArgs e)
        {
            if (txtDescription.SelectionLength > 0)
            {
                Font fnt = new Font(txtDescription.SelectionFont, FontStyle.Underline);
                txtDescription.SelectionFont = fnt;
            }
        }

        private void TsStrike_Click(object sender, EventArgs e)
        {
            if (txtDescription.SelectionLength > 0)
            {
                Font fnt = new Font(txtDescription.SelectionFont, FontStyle.Strikeout);
                txtDescription.SelectionFont = fnt;
            }
        }

        private void TsItalic_Click(object sender, EventArgs e)
        {
            if (txtDescription.SelectionLength > 0)
            {
                Font fnt = new Font(txtDescription.SelectionFont, FontStyle.Italic);
                txtDescription.SelectionFont = fnt;
            }
        }

        private void TsSuper_Click(object sender, EventArgs e)
        {
            if (txtDescription.SelectionLength > 0)
            {
                txtDescription.SelectionCharOffset = 10;
            }
        }

        private void TsSub_Click(object sender, EventArgs e)
        {
            if (txtDescription.SelectionLength > 0)
            {
                txtDescription.SelectionCharOffset = -10;
            }
        }

        private void TsBulletList_Click(object sender, EventArgs e)
        {
            tsBulletList.Checked = !tsBulletList.Checked;

            if (tsBulletList.Checked)
            {
                txtDescription.SelectionBullet = true;
            }
            else
            {
                txtDescription.SelectionBullet = false;
            }
        }

        private void EnableTabStop(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item.Name != txtDescription.Name)
                {
                    item.TabStop = true;
                }

                if (item is TextBox)
                {
                    TextBox txt = item as TextBox;
                    txt.SelectionLength = 0;
                }

                if (item is ComboBox)
                {
                    ComboBox cb = item as ComboBox;
                    cb.SelectionLength = 0;
                }
            }
        }

        private void DisableTabStop(object sender, EventArgs e)
        {
            txtDescription.Focus();

            foreach (Control item in this.Controls)
            {
                if (item.Name != txtDescription.Name)
                {
                    item.TabStop = false;
                }

                if (item is TextBox)
                {
                    TextBox txt = item as TextBox;
                    txt.SelectionLength = 0;
                }

                if (item is ComboBox)
                {
                    ComboBox cb = item as ComboBox;
                    cb.SelectionLength = 0;
                }
            }
        }

        private void Frm_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = item as TextBox;
                    txt.SelectionLength = 0;
                }

                if (item is ComboBox)
                {
                    ComboBox cb = item as ComboBox;
                    cb.SelectionLength = 0;
                }
            }
        }

        #endregion

        private void BtnOK_Click(object sender, EventArgs e)
        {
            //Remove the illegal characters
            txtBoxName.Text = Module.GetSafeFilename(txtBoxName.Text);
            cbRacks.Text = Module.GetSafeFilename(cbRacks.Text);
        }
    }
}
