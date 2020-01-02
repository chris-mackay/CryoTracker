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
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Net;

namespace CryoTracker
{
    public partial class MainForm : Form
    {
        private string BoxTemplate = Module.CryoTracker + @"\BoxTemplate.box";
        private string BoxSettingsTemplate = Module.CryoTracker + @"\BoxSettingsTemplate.bxs";
        private bool OpenFromSearch = false;
        private string tempRack = string.Empty;
        private string tempBox = string.Empty;
        private int timerInterval = 0;
        private string attachmentToCopy = string.Empty;

        public MainForm()
        {
            InitializeComponent();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Module.SetFormColors(this);

            Color borderColor = ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.AppBorderColor));

            Rectangle rect1 = new Rectangle(lstLocations.Location.X, lstLocations.Location.Y, lstLocations.ClientSize.Width, lstLocations.ClientSize.Height);
            rect1.Inflate(1, 1);
            ControlPaint.DrawBorder(e.Graphics, rect1, borderColor, ButtonBorderStyle.Solid);

            Rectangle rect11 = new Rectangle(lstLocations.Location.X, lstLocations.Location.Y, lstLocations.ClientSize.Width, lstLocations.ClientSize.Height);
            rect11.Inflate(3, 3);
            ControlPaint.DrawBorder(e.Graphics, rect11, borderColor, ButtonBorderStyle.Solid);

            Rectangle rect2 = new Rectangle(lstRacks.Location.X, lstRacks.Location.Y, lstRacks.ClientSize.Width, lstRacks.ClientSize.Height);
            rect2.Inflate(1, 1);
            ControlPaint.DrawBorder(e.Graphics, rect2, borderColor, ButtonBorderStyle.Solid);

            Rectangle rect22 = new Rectangle(lstRacks.Location.X, lstRacks.Location.Y, lstRacks.ClientSize.Width, lstRacks.ClientSize.Height);
            rect22.Inflate(3, 3);
            ControlPaint.DrawBorder(e.Graphics, rect22, borderColor, ButtonBorderStyle.Solid);

            Rectangle rect3 = new Rectangle(dgvAllContents.Location.X, dgvAllContents.Location.Y, dgvAllContents.ClientSize.Width, dgvAllContents.ClientSize.Height);
            rect3.Inflate(1, 1);
            ControlPaint.DrawBorder(e.Graphics, rect3, borderColor, ButtonBorderStyle.Solid);

            Rectangle rect33 = new Rectangle(dgvAllContents.Location.X, dgvAllContents.Location.Y, dgvAllContents.ClientSize.Width, dgvAllContents.ClientSize.Height);
            rect33.Inflate(3, 3);
            ControlPaint.DrawBorder(e.Graphics, rect33, borderColor, ButtonBorderStyle.Solid);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Module.AccessIsInstalled() == false)
            {
                this.Hide();

                frmInstallAccess new_frmInstallAccess = new frmInstallAccess();
                new_frmInstallAccess.caller_MainForm = this;
                new_frmInstallAccess.ShowDialog();
            }
            else
            {
                Module.CreateCryoTrackerSettings_SetDefaults();
                LoadLocations();

                if (bool.Parse(Module.GetSettingsValue(Module.CryoTrackerSettings.SearchAsYouType)))
                {
                    btnSearch.Visible = false;
                }
                else
                {
                    btnSearch.Visible = true;
                }
            }
        }

        #region Functions

        private ContextMenu LocationContextMenu()
        {
            ContextMenu mnu = new ContextMenu();
            MenuItem cxmnuAddLocation = new MenuItem("Add Location");
            MenuItem cxmnuRenameLocation = new MenuItem("Rename Location");
            MenuItem cxmnuDeleteLocation = new MenuItem("Delete Location");

            cxmnuAddLocation.Click += new EventHandler(AddLocation);
            cxmnuRenameLocation.Click += new EventHandler(RenameLocation);
            cxmnuDeleteLocation.Click += new EventHandler(DeleteLocation);

            mnu.MenuItems.Add(cxmnuAddLocation);
            mnu.MenuItems.Add(cxmnuRenameLocation);
            mnu.MenuItems.Add(cxmnuDeleteLocation);

            return mnu;
        }

        private ContextMenu RackContextMenu()
        {
            ContextMenu mnu = new ContextMenu();
            MenuItem cxmnuOpenBox = new MenuItem("Open Box");
            MenuItem cxmnuAddBox = new MenuItem("Add Box");
            MenuItem cxmnuEditBox = new MenuItem("Edit Box");
            MenuItem cxmnuDeleteBox = new MenuItem("Delete Box");
            MenuItem cxmnuDeleteRack = new MenuItem("Delete Rack");
            MenuItem cxmnuLoadBox = new MenuItem("Load Box");
            MenuItem cxmnuViewBoxAttachment = new MenuItem("View Attachment");
            MenuItem cxmnuRemoveBoxAttachment = new MenuItem("Remove Attachment");

            cxmnuOpenBox.Click += new EventHandler(OpenBox);
            cxmnuAddBox.Click += new EventHandler(AddBox);
            cxmnuEditBox.Click += new EventHandler(EditBox);
            cxmnuDeleteBox.Click += new EventHandler(DeleteBox);
            cxmnuDeleteRack.Click += new EventHandler(DeleteRack);
            cxmnuLoadBox.Click += new EventHandler(LoadBox);
            cxmnuViewBoxAttachment.Click += new EventHandler(ViewBoxAttachment);
            cxmnuRemoveBoxAttachment.Click += new EventHandler(RemoveBoxAttachment);

            mnu.MenuItems.Add(cxmnuOpenBox);
            mnu.MenuItems.Add(cxmnuLoadBox);
            mnu.MenuItems.Add("-");
            mnu.MenuItems.Add(cxmnuAddBox);
            mnu.MenuItems.Add(cxmnuEditBox);
            mnu.MenuItems.Add(cxmnuDeleteBox);
            mnu.MenuItems.Add("-");
            mnu.MenuItems.Add(cxmnuViewBoxAttachment);
            mnu.MenuItems.Add(cxmnuRemoveBoxAttachment);
            mnu.MenuItems.Add("-");
            mnu.MenuItems.Add(cxmnuDeleteRack);

            return mnu;
        }

        private ContextMenu SearchContextMenu()
        {
            ContextMenu mnu = new ContextMenu();
            MenuItem cxmnuOpenBox = new MenuItem("Open Box");
            MenuItem cxmnuOpenSlot = new MenuItem("Open Slot");
            MenuItem cxmnuViewBoxAttachment = new MenuItem("View Box Attachment");
            MenuItem cxmnuViewSlotAttachment = new MenuItem("View Slot Attachment");

            cxmnuOpenBox.Click += new EventHandler(OpenBox);
            cxmnuOpenSlot.Click += new EventHandler(OpenSlot);
            cxmnuViewBoxAttachment.Click += new EventHandler(ViewBoxAttachment);
            cxmnuViewSlotAttachment.Click += new EventHandler(ViewSlotAttachment);

            mnu.MenuItems.Add(cxmnuOpenBox);
            mnu.MenuItems.Add(cxmnuOpenSlot);
            mnu.MenuItems.Add("-");
            mnu.MenuItems.Add(cxmnuViewBoxAttachment);
            mnu.MenuItems.Add(cxmnuViewSlotAttachment);

            return mnu;
        }

        #endregion

        #region Events

        private void DeleteLocation(object sender, EventArgs e)
        {
            if (lstLocations.SelectedItems.Count != 0)
            {
                string location = lstLocations.SelectedItem.ToString();

                if (Directory.Exists(Module.SetLocation(location)))
                {
                    if (MessageBox.Show("Are you sure you want to delete " + location + "?\n\n This will delete all racks and boxes. This cannot be undone.", "Delete Location", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        try
                        {
                            Directory.Delete(Module.SetLocation(location), true);
                            lstRacks.Clear();
                            LoadLocations();
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

        private void RenameLocation(object sender, EventArgs e)
        {
            if (lstLocations.SelectedItems.Count != 0)
            {
                string old_location = lstLocations.SelectedItem.ToString();

                frmDoubleInputBox new_frmRename = new frmDoubleInputBox();
                new_frmRename.Text = "Rename Location";
                new_frmRename.txtPreviousName.Text = old_location;
                new_frmRename.txtPreviousName.Enabled = false;

                if (new_frmRename.ShowDialog() == DialogResult.OK)
                {
                    string new_location = new_frmRename.txtNewName.Text.Replace("'", "");

                    if (!Module.LocationExists(new_location))
                    {
                        try
                        {
                            string location = Module.SetLocation(new_location);

                            Directory.Move(Module.SetLocation(old_location), Module.SetLocation(new_location));

                            foreach (string box in Directory.GetFiles(location, "*.box", SearchOption.AllDirectories))
                            {
                                FileInfo fInfo = new FileInfo(box);

                                // Update tblBoxInfo
                                DBConnector db = new DBConnector();
                                db.OpenBox(fInfo.FullName);
                                db.SQLCommand("update tblBoxInfo" +
                                                      " set Location = '" + new_location + "' " +
                                                           "where ID = 1");
                                db.CloseBox();

                            }

                            LoadLocations();
                            lstLocations.SelectedIndex = lstLocations.FindStringExact(new_location);
                        }
                        catch (Exception ex)
                        {
                            frmErrorReport errorReport = new frmErrorReport();
                            errorReport.txtError.Text = ex.ToString();
                            errorReport.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show(new_location + " already exists", "Rename Location", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void AddLocation(object sender, EventArgs e)
        {
            frmSingleInputBox new_frmAddLocation = new frmSingleInputBox();
            new_frmAddLocation.Text = "Add Location";
            new_frmAddLocation.lblPrompt.Text = "Enter the location name";

            if (new_frmAddLocation.ShowDialog() == DialogResult.OK)
            {
                string locationName = new_frmAddLocation.txtInput.Text.Replace("'", "");

                if (!Module.LocationExists(locationName))
                {
                    try
                    {
                        Module.CreateLocation(locationName);
                        LoadLocations();
                    }
                    catch (Exception ex)
                    {
                        frmErrorReport errorReport = new frmErrorReport();
                        errorReport.txtError.Text = ex.ToString();
                        errorReport.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show(locationName + " already exists", "Add Location", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        private void OpenBox(object sender, EventArgs e)
        {
            if (lstRacks.Focused)
            {
                if (lstRacks.SelectedItems.Count != 0)
                {
                    ResetSearchBox();
                    dgvAllContents.DataSource = null;
                    OpenFromSearch = false;

                    Module.CurrentLocation = lstLocations.SelectedItem.ToString();
                    string selectedBox = lstRacks.SelectedItems[0].SubItems[0].Text;
                    Module.CurrentRack = lstRacks.SelectedItems[0].Group.Header.ToString();
                    Module.CurrentBoxFile = Module.SetBoxFile(Module.CurrentLocation, Module.CurrentRack, selectedBox);

                    frmBox new_frmBox = new frmBox();
                    new_frmBox.ShowDialog();
                }
            }
            else if (dgvAllContents.Focused)
            {
                string location = string.Empty;
                string rack = string.Empty;
                string box = string.Empty;

                if (dgvAllContents.SelectedRows.Count != 0)
                {
                    string slot;
                    if (OpenFromSearch)
                    {
                        foreach (DataGridViewRow row in dgvAllContents.SelectedRows)
                        {
                            location = dgvAllContents.CurrentRow.Cells["Location"].Value.ToString();
                            rack = dgvAllContents.CurrentRow.Cells["Rack"].Value.ToString();
                            box = dgvAllContents.CurrentRow.Cells["Box"].Value.ToString();
                            slot = dgvAllContents.CurrentRow.Cells["Slot"].Value.ToString();
                        }

                        Module.CurrentLocation = location;
                        Module.CurrentRack = rack;
                        Module.CurrentBoxFile = Module.SetBoxFile(location, rack, box);

                        ResetSearchBox();
                        dgvAllContents.DataSource = null;
                        OpenFromSearch = false;

                        frmBox new_frmBox = new frmBox();
                        new_frmBox.ShowDialog();

                    }
                    else
                    {
                        if (dgvAllContents.SelectedRows.Count != 0)
                        {
                            foreach (DataGridViewRow row in dgvAllContents.SelectedRows)
                            {
                                location = lstLocations.SelectedItem.ToString();
                                slot = dgvAllContents.CurrentRow.Cells["Slot"].Value.ToString();
                            }

                            Module.CurrentLocation = location;
                            Module.CurrentRack = tempRack;
                            Module.CurrentBoxFile = Module.SetBoxFile(location, tempRack, tempBox);

                            ResetSearchBox();
                            dgvAllContents.DataSource = null;
                            OpenFromSearch = false;

                            frmBox new_frmBox = new frmBox();
                            new_frmBox.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select a slot item to open it's containing box", "Open Box", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void OpenBoxFromRack_DoubleClick(object sender, MouseEventArgs e)
        {
            if (lstRacks.SelectedItems.Count != 0)
            {
                ResetSearchBox();
                dgvAllContents.DataSource = null;
                OpenFromSearch = false;

                string selectedBox = string.Empty;

                Module.CurrentLocation = lstLocations.SelectedItem.ToString();
                selectedBox = lstRacks.SelectedItems[0].SubItems[0].Text;
                Module.CurrentRack = lstRacks.SelectedItems[0].Group.Header.ToString();
                Module.CurrentBoxFile = Module.SetBoxFile(Module.CurrentLocation, Module.CurrentRack, selectedBox);

                frmBox new_frmBox = new frmBox();
                new_frmBox.ShowDialog();
            }
        }

        private void AddBox(object sender, EventArgs e)
        {
            frmAddBox new_frmAddBox = new frmAddBox();
            new_frmAddBox.Text = "Add Box";
            new_frmAddBox.caller_MainForm = this;
            new_frmAddBox.cbBoxSizes.SelectedIndex = new_frmAddBox.cbBoxSizes.FindStringExact(Module.GetSettingsValue(Module.CryoTrackerSettings.DefaultBoxSize));

            Module.LoadRacks(Module.CurrentLocation, new_frmAddBox.cbRacks);

            if (Module.CurrentLocation != string.Empty)
            {
                if (new_frmAddBox.ShowDialog() == DialogResult.OK)
                {
                    string boxName = new_frmAddBox.txtBoxName.Text.Replace("'", "");
                    string boxSize = new_frmAddBox.cbBoxSizes.SelectedItem.ToString();
                    string rack = new_frmAddBox.cbRacks.Text.Replace("'", "");
                    string attachment = new_frmAddBox.txtAttachment.Text.Replace("'", "");

                    if (!Module.RackExists(Module.CurrentLocation, rack))
                    {
                        Module.CreateRack(Module.CurrentLocation, rack);
                    }

                    if (!Module.BoxExists(boxName, rack))
                    {
                        try
                        {
                            string project = new_frmAddBox.txtProject.Text.Replace("'", "");
                            string description = new_frmAddBox.txtDescription.Text.Replace("'", "");
                            string rtf = new_frmAddBox.txtDescription.Rtf.Replace("'", "");

                            // Create the directory to store all box related files
                            if (!Directory.Exists(Module.SetBoxDirectory(Module.CurrentLocation, rack, boxName)))
                            {
                                Directory.CreateDirectory(Module.SetBoxDirectory(Module.CurrentLocation, rack, boxName));
                            }

                            // Create the directory to store all the slot related attachments
                            if (!Directory.Exists(Module.SetBoxDirectory(Module.CurrentLocation, rack, boxName) + "\\SlotAttachments"))
                            {
                                Directory.CreateDirectory(Module.SetBoxDirectory(Module.CurrentLocation, rack, boxName) + "\\SlotAttachments");
                            }

                            File.Copy(BoxTemplate, Module.SetBoxFile(Module.CurrentLocation, rack, boxName));
                            File.Copy(BoxSettingsTemplate, Module.SetBoxSettingsFile(Module.CurrentLocation, rack, boxName));

                            if (attachment != string.Empty)
                            {
                                File.Copy(Module.BoxAttachmentFileToCopy, Module.SetBoxAttachmentFile(Module.CurrentLocation, rack, boxName, attachment));
                            }

                            // Update tblBoxInfo
                            DBConnector db = new DBConnector();
                            db.OpenBox(Module.SetBoxFile(Module.CurrentLocation, rack, boxName));
                            db.SQLCommand("update tblBoxInfo" +
                                                  " set Project = '" + project + "', " +
                                                       "Location = '" + Module.CurrentLocation + "', " +
                                                       "Rack = '" + rack + "', " +
                                                       "Box = '" + boxName + "', " +
                                                       "Attachment = '" + attachment + "' " +
                                                       "where ID = 1");
                            db.CloseBox();

                            Module.SetBoxSettingsValue(Module.CurrentLocation, rack, boxName, "Project", project);
                            Module.SetBoxSettingsValue(Module.CurrentLocation, rack, boxName, "Location", Module.CurrentLocation);
                            Module.SetBoxSettingsValue(Module.CurrentLocation, rack, boxName, "Rack", rack);
                            Module.SetBoxSettingsValue(Module.CurrentLocation, rack, boxName, "Box", boxName);
                            Module.SetBoxSettingsValue(Module.CurrentLocation, rack, boxName, "BoxSize", boxSize);
                            Module.SetBoxSettingsValue(Module.CurrentLocation, rack, boxName, "Description", description);
                            Module.SetBoxSettingsValue(Module.CurrentLocation, rack, boxName, "Rtf", rtf);
                            Module.SetBoxSettingsValue(Module.CurrentLocation, rack, boxName, "Attachment", attachment);

                            LoadListView(Module.CurrentLocation);
                        }
                        catch (Exception ex)
                        {
                            frmErrorReport errorReport = new frmErrorReport();
                            errorReport.txtError.Text = ex.ToString();
                            errorReport.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show(boxName + " already exists", "Add Box", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void EditBox(object sender, EventArgs e)
        {
            if (lstRacks.SelectedItems.Count != 0)
            {
                string selectedBox = lstRacks.SelectedItems[0].SubItems[0].Text;
                string selectedRack = lstRacks.SelectedItems[0].Group.Header.ToString();
                string old_boxName = selectedBox;
                string box_size = lstRacks.SelectedItems[0].SubItems[1].Text;
                string old_project = lstRacks.SelectedItems[0].SubItems[2].Text;
                string old_description = Module.GetBoxSettingsValue(Module.CurrentLocation, selectedRack, selectedBox, "Description");
                string old_rtf = Module.GetBoxSettingsValue(Module.CurrentLocation, selectedRack, selectedBox, "Rtf");
                string old_rack = selectedRack;
                string old_attachment = lstRacks.SelectedItems[0].SubItems[4].Text;

                frmAddBox new_frmAddBox = new frmAddBox();
                new_frmAddBox.Text = "Edit Box";

                Module.LoadRacks(Module.CurrentLocation, new_frmAddBox.cbRacks);

                new_frmAddBox.txtBoxName.Text = old_boxName;
                new_frmAddBox.txtProject.Text = old_project;
                new_frmAddBox.txtDescription.Text = old_description;
                new_frmAddBox.txtDescription.Rtf = old_rtf;
                new_frmAddBox.cbBoxSizes.SelectedIndex = new_frmAddBox.cbBoxSizes.FindStringExact(box_size);
                new_frmAddBox.cbRacks.SelectedIndex = new_frmAddBox.cbRacks.FindStringExact(old_rack);
                new_frmAddBox.txtAttachment.Text = old_attachment;
                new_frmAddBox.caller_MainForm = this;

                new_frmAddBox.cbBoxSizes.Enabled = false;

                if (new_frmAddBox.ShowDialog() == DialogResult.OK)
                {
                    if (MessageBox.Show("Are you sure you want to update the box?", "Edit Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        string new_boxName = new_frmAddBox.txtBoxName.Text.Replace("'", "");
                        string new_project = new_frmAddBox.txtProject.Text.Replace("'", "");
                        string new_description = new_frmAddBox.txtDescription.Text.Replace("'", "");
                        string new_rtf = new_frmAddBox.txtDescription.Rtf.Replace("'", "");
                        string new_rack = new_frmAddBox.cbRacks.Text.Replace("'", "");
                        string new_attachment = new_frmAddBox.txtAttachment.Text.Replace("'", "");

                        if (!Module.RackExists(Module.CurrentLocation, new_rack))
                        {
                            Module.CreateRack(Module.CurrentLocation, new_rack);
                        }

                        try
                        {
                            if (old_rack != new_rack || old_boxName != new_boxName)
                            {
                                Directory.Move(Module.SetBoxDirectory(Module.CurrentLocation, old_rack, old_boxName), Module.SetBoxDirectory(Module.CurrentLocation, new_rack, new_boxName));
                                Module.RenameBoxFiles(Module.CurrentLocation, new_rack, old_boxName, new_boxName);
                            }

                            string boxAttachmentFile = Module.SetBoxAttachmentFile(Module.CurrentLocation, new_rack, new_boxName, new_attachment);

                            if (Module.BoxAttachmentFileToCopy != string.Empty && !File.Exists(boxAttachmentFile) && new_attachment != string.Empty)
                            {
                                File.Copy(Module.BoxAttachmentFileToCopy, Module.SetBoxAttachmentFile(Module.CurrentLocation, new_rack, new_boxName, new_attachment));
                            }

                            if (Module.BoxAttachmentNameToDelete != string.Empty && File.Exists(Module.SetBoxAttachmentFile(Module.CurrentLocation, new_rack, new_boxName, Module.BoxAttachmentNameToDelete)))
                            {
                                File.Delete(Module.SetBoxAttachmentFile(Module.CurrentLocation, new_rack, new_boxName, Module.BoxAttachmentNameToDelete));
                            }

                            DBConnector db = new DBConnector();
                            db.OpenBox(Module.SetBoxFile(Module.CurrentLocation, new_rack, new_boxName));
                            db.SQLCommand("update tblBoxInfo" +
                                                    " set Project = '" + new_project + "', " +
                                                        "Rack = '" + new_rack + "', " +
                                                        "Attachment = '" + new_attachment + "', " +
                                                        "Box = '" + new_boxName + "' " +
                                                        "where ID = 1");
                            db.CloseBox();

                            Module.SetBoxSettingsValue(Module.CurrentLocation, new_rack, new_boxName, "Project", new_project);
                            Module.SetBoxSettingsValue(Module.CurrentLocation, new_rack, new_boxName, "Location", Module.CurrentLocation);
                            Module.SetBoxSettingsValue(Module.CurrentLocation, new_rack, new_boxName, "Rack", new_rack);
                            Module.SetBoxSettingsValue(Module.CurrentLocation, new_rack, new_boxName, "Box", new_boxName);
                            Module.SetBoxSettingsValue(Module.CurrentLocation, new_rack, new_boxName, "Description", new_description);
                            Module.SetBoxSettingsValue(Module.CurrentLocation, new_rack, new_boxName, "Rtf", new_rtf);
                            Module.SetBoxSettingsValue(Module.CurrentLocation, new_rack, new_boxName, "Attachment", new_attachment);

                            LoadListView(Module.CurrentLocation);
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

        private void DeleteBox(object sender, EventArgs e)
        {
            if (lstRacks.SelectedItems.Count != 0)
            {
                string selectedBox = string.Empty;
                selectedBox = lstRacks.SelectedItems[0].SubItems[0].Text;

                string selectedRack = string.Empty;
                selectedRack = lstRacks.SelectedItems[0].Group.Header.ToString();

                if (Directory.Exists(Module.SetBoxDirectory(Module.CurrentLocation, selectedRack, selectedBox)))
                {
                    if (MessageBox.Show("Are you sure you want to delete " + selectedBox + "?", "Delete Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        try
                        {
                            if (Directory.Exists(Module.SetBoxDirectory(Module.CurrentLocation, selectedRack, selectedBox)))
                            {
                                Directory.Delete(Module.SetBoxDirectory(Module.CurrentLocation, selectedRack, selectedBox), true);
                            }
                            LoadListView(Module.CurrentLocation);
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

        private void ViewBoxAttachment(object sender, EventArgs e)
        {
            if (lstRacks.Focused)
            {
                if (lstRacks.SelectedItems.Count != 0)
                {
                    string selectedBox = lstRacks.SelectedItems[0].SubItems[0].Text;
                    string selectedRack = lstRacks.SelectedItems[0].Group.Header.ToString();
                    string selectedAttachment = lstRacks.SelectedItems[0].SubItems[4].Text;

                    string file = Module.SetBoxAttachmentFile(Module.CurrentLocation, selectedRack, selectedBox, selectedAttachment);

                    if (File.Exists(file))
                    {
                        try
                        {
                            Process.Start(file);
                        }
                        catch (Exception ex)
                        {
                            frmErrorReport errorReport = new frmErrorReport();
                            errorReport.txtError.Text = ex.ToString();
                            errorReport.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("A file does not exist to view", "View Attachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (dgvAllContents.Focused)
            {
                if (dgvAllContents.Columns["i.Attachment"] != null)
                {
                    string selectedAttachment = string.Empty;
                    string selectedBox = string.Empty;
                    string selectedRack = string.Empty;
                    string selectedLocation = string.Empty;

                    if (dgvAllContents.SelectedRows.Count != 0)
                    {
                        if (dgvAllContents.SelectedRows.Count == 1)
                        {
                            foreach (DataGridViewRow row in dgvAllContents.SelectedRows)
                            {
                                selectedAttachment = row.Cells["i.Attachment"].Value.ToString();
                                selectedBox = row.Cells["Box"].Value.ToString();
                                selectedRack = row.Cells["Rack"].Value.ToString();
                                selectedLocation = row.Cells["Location"].Value.ToString();
                            }

                            string file = Module.SetBoxAttachmentFile(selectedLocation, selectedRack, selectedBox, selectedAttachment);

                            if (File.Exists(file))
                            {
                                try
                                {
                                    Process.Start(file);
                                }
                                catch (Exception ex)
                                {
                                    frmErrorReport errorReport = new frmErrorReport();
                                    errorReport.txtError.Text = ex.ToString();
                                    errorReport.ShowDialog();
                                }
                            }
                            else
                            {
                                MessageBox.Show("A file does not exist to view", "View Attachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show("You can only view one attachment at a time", "View Attachment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }

        private void ViewSlotAttachment(object sender, EventArgs e)
        {
            if (dgvAllContents.Columns["s.Attachment"] != null)
            {
                string selectedAttachment = string.Empty;
                string selectedBox = string.Empty;
                string selectedRack = string.Empty;
                string selectedLocation = string.Empty;

                if (dgvAllContents.SelectedRows.Count != 0)
                {
                    if (dgvAllContents.SelectedRows.Count == 1)
                    {
                        foreach (DataGridViewRow row in dgvAllContents.SelectedRows)
                        {
                            selectedAttachment = row.Cells["s.Attachment"].Value.ToString();
                            selectedBox = row.Cells["Box"].Value.ToString();
                            selectedRack = row.Cells["Rack"].Value.ToString();
                            selectedLocation = row.Cells["Location"].Value.ToString();
                        }

                        string file = Module.SetSlotAttachmentFile(selectedLocation, selectedRack, selectedBox, selectedAttachment);

                        if (File.Exists(file))
                        {
                            try
                            {
                                Process.Start(file);
                            }
                            catch (Exception ex)
                            {
                                frmErrorReport errorReport = new frmErrorReport();
                                errorReport.txtError.Text = ex.ToString();
                                errorReport.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("A file does not exist to view", "View Attachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You can only view one attachment at a time", "View Attachment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else if (dgvAllContents.Columns["Attachment"] != null)
            {
                string selectedAttachment = string.Empty;

                if (dgvAllContents.SelectedRows.Count != 0)
                {
                    if (dgvAllContents.SelectedRows.Count == 1)
                    {
                        foreach (DataGridViewRow row in dgvAllContents.SelectedRows)
                        {
                            selectedAttachment = row.Cells["Attachment"].Value.ToString();
                        }

                        string file = Module.SetSlotAttachmentFile(Module.CurrentLocation, tempRack, tempBox, selectedAttachment);

                        if (File.Exists(file))
                        {
                            try
                            {
                                Process.Start(file);
                            }
                            catch (Exception ex)
                            {
                                frmErrorReport errorReport = new frmErrorReport();
                                errorReport.txtError.Text = ex.ToString();
                                errorReport.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("A file does not exist to view", "View Attachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You can only view one attachment at a time", "View Attachment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void RemoveBoxAttachment(object sender, EventArgs e)
        {
            if (lstRacks.SelectedItems.Count != 0)
            {
                string selectedBox = lstRacks.SelectedItems[0].SubItems[0].Text;
                string selectedRack = lstRacks.SelectedItems[0].Group.Header.ToString();
                string selectedAttachment = lstRacks.SelectedItems[0].SubItems[4].Text;

                string file = Module.SetBoxAttachmentFile(Module.CurrentLocation, selectedRack, selectedBox, selectedAttachment);

                if (File.Exists(file))
                {
                    if (MessageBox.Show("Are you sure you want to remove the attachment from " + selectedBox + "?", "Remove Attachment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            File.Delete(file);
                            Module.SetBoxSettingsValue(Module.CurrentLocation, selectedRack, selectedBox, "Attachment", "");
                            LoadListView(Module.CurrentLocation);
                        }
                        catch (Exception ex)
                        {
                            frmErrorReport errorReport = new frmErrorReport();
                            errorReport.txtError.Text = ex.ToString();
                            errorReport.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("A file does not exist to remove", "Remove Attachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteRack(object sender, EventArgs e)
        {
            if (lstRacks.SelectedItems.Count != 0)
            {
                string selectedRack = string.Empty;
                selectedRack = lstRacks.SelectedItems[0].Group.Header.ToString();

                if (Directory.Exists(Module.SetRack(Module.CurrentLocation, selectedRack)))
                {
                    if (MessageBox.Show("Are you sure you want to delete " + selectedRack + "?\n\n This will delete all boxes. This cannot be undone.", "Delete Rack", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        try
                        {
                            Directory.Delete(Module.SetRack(Module.CurrentLocation, selectedRack), true);
                            LoadListView(Module.CurrentLocation);
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

        private void Location_MouseUp(object sender, MouseEventArgs e)
        {
            ListBox lstBox = sender as ListBox;

            if (e.Button == MouseButtons.Right)
            {
                ContextMenu contextMenu = new ContextMenu();
                contextMenu = LocationContextMenu();
                contextMenu.Show(lstBox, new System.Drawing.Point(e.X, e.Y));
            }
        }

        private void Box_MouseUp(object sender, MouseEventArgs e)
        {
            if (lstLocations.SelectedItems.Count != 0)
            {
                ListView lstView = sender as ListView;

                if (e.Button == MouseButtons.Right)
                {
                    ContextMenu contextMenu = new ContextMenu();
                    contextMenu = RackContextMenu();
                    contextMenu.Show(lstView, new System.Drawing.Point(e.X, e.Y));
                }
            }
        }

        private void Search_MouseUp(object sender, MouseEventArgs e)
        {
            if (dgvAllContents.Rows.Count != 0)
            {
                DataGridView dgv = sender as DataGridView;

                if (e.Button == MouseButtons.Right)
                {
                    ContextMenu contextMenu = new ContextMenu();
                    contextMenu = SearchContextMenu();
                    contextMenu.Show(dgv, new System.Drawing.Point(e.X, e.Y));
                }
            }
        }

        private void lstLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstLocations.SelectedItems.Count != 0)
            {
                try
                {
                    Module.CurrentLocation = lstLocations.SelectedItem.ToString();
                    LoadListView(Module.CurrentLocation);
                }
                catch (Exception ex)
                {
                    frmErrorReport errorReport = new frmErrorReport();
                    errorReport.txtError.Text = ex.ToString();
                    errorReport.ShowDialog();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerInterval += 1;

            if (timerInterval == 25)
            {
                if (txtSearch.Text != string.Empty)
                {
                    try
                    {
                        Search();
                        timer1.Stop();
                        OpenFromSearch = true;
                    }
                    catch (Exception ex)
                    {
                        frmErrorReport errorReport = new frmErrorReport();
                        errorReport.txtError.Text = ex.ToString();
                        errorReport.ShowDialog();
                    }
                }
                else
                {
                    dgvAllContents.DataSource = null;
                    timer1.Stop();
                    OpenFromSearch = false;
                }
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (bool.Parse(Module.GetSettingsValue(Module.CryoTrackerSettings.SearchAsYouType)))
            {
                if (txtSearch.Focused)
                {
                    timerInterval = 0;
                    timer1.Start();
                }
            }
        }

        private void OpenSlot(object sender, EventArgs e)
        {
            string location = string.Empty;
            string rack = string.Empty;
            string box = string.Empty;
            string slot = string.Empty;

            if (dgvAllContents.SelectedRows.Count != 0)
            {
                if (OpenFromSearch)
                {
                    foreach (DataGridViewRow row in dgvAllContents.SelectedRows)
                    {
                        string project = dgvAllContents.CurrentRow.Cells["Project"].Value.ToString();
                        location = dgvAllContents.CurrentRow.Cells["Location"].Value.ToString();
                        rack = dgvAllContents.CurrentRow.Cells["Rack"].Value.ToString();
                        box = dgvAllContents.CurrentRow.Cells["Box"].Value.ToString();
                        slot = dgvAllContents.CurrentRow.Cells["Slot"].Value.ToString();
                    }

                    Module.CurrentLocation = location;
                    Module.CurrentRack = rack;
                    Module.CurrentBoxFile = Module.SetBoxFile(location, rack, box);

                    frmSlot new_frmSlot = new frmSlot();
                    new_frmSlot.caller_MainForm = this;
                    new_frmSlot.currentSlot = slot;
                    new_frmSlot.Text = "Slot " + slot;
                    new_frmSlot.ShowDialog();
                }
                else
                {
                    if (dgvAllContents.SelectedRows.Count != 0)
                    {
                        foreach (DataGridViewRow row in dgvAllContents.SelectedRows)
                        {
                            location = lstLocations.SelectedItem.ToString();
                            slot = dgvAllContents.CurrentRow.Cells["Slot"].Value.ToString();
                        }

                        Module.CurrentLocation = location;
                        Module.CurrentRack = tempRack;
                        Module.CurrentBoxFile = Module.SetBoxFile(location, tempRack, tempBox);

                        frmSlot new_frmSlot = new frmSlot();
                        new_frmSlot.caller_MainForm = this;
                        new_frmSlot.currentSlot = slot;
                        new_frmSlot.Text = "Slot " + slot;
                        new_frmSlot.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select an item below to open it's containing slot", "Open Slot", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ClearSearch(object sender, EventArgs e)
        {
            ResetSearchBox();
            dgvAllContents.DataSource = null;
            OpenFromSearch = false;

            txtSearch.Font = new Font(txtSearch.Font, FontStyle.Italic);
            txtSearch.ForeColor = Color.DimGray;
            txtSearch.Text = "Enter search criteria...";

        }

        private void tsSettings_Click(object sender, EventArgs e)
        {
            frmSettings new_frmSettings = new frmSettings();
            new_frmSettings.caller_MainForm = this;
            new_frmSettings.ShowDialog();
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            frmAbout new_frmAbout = new frmAbout();
            new_frmAbout.ShowDialog();
        }

        private void CreateBox(object sender, EventArgs e)
        {
            DBConnector db = new DBConnector();
            db.CreateBox(BoxTemplate);
            MessageBox.Show("Box Created");
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void LoadBox(object sender, EventArgs e)
        {
            if (lstRacks.SelectedItems.Count != 0)
            {
                OpenFromSearch = false;

                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbConnection con = new OleDbConnection();
                DataTable dt = new DataTable();

                string dbProvider;
                string dbSource;

                con.Close();
                con.Dispose();
                OleDbConnection.ReleaseObjectPool();

                con.Close();
                con.Dispose();
                OleDbConnection.ReleaseObjectPool();

                string selectedBox = lstRacks.SelectedItems[0].SubItems[0].Text;
                string selectedRack = lstRacks.SelectedItems[0].Group.Header.ToString();
                string location = lstLocations.SelectedItem.ToString();

                tempRack = selectedRack;
                tempBox = selectedBox;

                dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;";
                dbSource = "Data Source = " + Module.SetBoxFile(location, tempRack, tempBox);

                con.ConnectionString = dbProvider + dbSource;
                con.Open();

                List<string> tableList = new List<string>();

                tableList = Module.GetTables(con.ConnectionString);

                foreach (string tableName in tableList)
                {
                    if (tableName != "tblBoxInfo" && tableName != "tblArchive")
                    {
                        string select = "select * from " + tableName;

                        OleDbCommand cmd = new OleDbCommand(select, con);
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                    }
                }

                con.Close();
                con.Dispose();
                OleDbConnection.ReleaseObjectPool();

                Module.DrawingControl.SetDoubleBuffered(dgvAllContents);
                Module.DrawingControl.SuspendDrawing(dgvAllContents);

                dgvAllContents.DataSource = null;
                dgvAllContents.DataSource = dt.DefaultView;

                Module.FormatDataGridView(dgvAllContents);
                Module.DrawingControl.ResumeDrawing(dgvAllContents);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Search();
            }
            catch (Exception ex)
            {
                frmErrorReport errorReport = new frmErrorReport();
                errorReport.txtError.Text = ex.ToString();
                errorReport.ShowDialog();
            }
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Enter search criteria...")
            {
                txtSearch.Text = string.Empty;
                txtSearch.Font = new Font(txtSearch.Font, FontStyle.Regular);
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                ResetSearchBox();
            }
        }

        #endregion

        #region Voids

        private void ResetSearchBox()
        {
            txtSearch.Font = new Font(txtSearch.Font, FontStyle.Italic);
            txtSearch.ForeColor = Color.DimGray;
            txtSearch.Text = "Enter search criteria...";
        }

        public void LoadLocations()
        {
            lstLocations.Items.Clear();
            Module.CurrentLocation = string.Empty;

            foreach (string loc in Directory.GetDirectories(Module.CryoTracker))
            {
                DirectoryInfo dInfo = new DirectoryInfo(loc);
                lstLocations.Items.Add(dInfo.Name);
            }
        }

        public void LoadListView(string _Location)
        {
            Module.DrawingControl.SetDoubleBuffered(lstRacks);
            Module.DrawingControl.SuspendDrawing(lstRacks);
            lstRacks.Columns.Clear();
            lstRacks.Items.Clear();
            lstRacks.View = View.Details;
            lstRacks.LabelEdit = false;
            lstRacks.AllowColumnReorder = false;
            lstRacks.CheckBoxes = false;
            lstRacks.FullRowSelect = true;
            lstRacks.GridLines = false;
            lstRacks.Sorting = SortOrder.Ascending;
            lstRacks.ShowGroups = true;
            lstRacks.MultiSelect = false;

            lstRacks.Columns.Add("Box name", -1, HorizontalAlignment.Left);
            lstRacks.Columns.Add("Box size", -1, HorizontalAlignment.Left);
            lstRacks.Columns.Add("Project", -1, HorizontalAlignment.Left);
            lstRacks.Columns.Add("Description", -1, HorizontalAlignment.Left);
            lstRacks.Columns.Add("Attachment", -1, HorizontalAlignment.Left);

            foreach (string rack in Directory.GetDirectories(Module.SetLocation(_Location)))
            {
                DirectoryInfo dInfo = new DirectoryInfo(rack);
                ListViewGroup lgRack = new ListViewGroup(dInfo.Name);

                lstRacks.Groups.Add(lgRack);

                List<string> boxes = new List<string>();
                boxes = Directory.GetDirectories(Module.CryoTracker + "\\" + Module.CurrentLocation + "\\" + lgRack).ToList();

                foreach (string box in boxes)
                {
                    string project = Module.GetBoxSettingsValue(_Location, dInfo.Name, Path.GetFileNameWithoutExtension(box), "Project");
                    string boxSize = Module.GetBoxSettingsValue(_Location, dInfo.Name, Path.GetFileNameWithoutExtension(box), "BoxSize");
                    string description = Module.GetBoxSettingsValue(_Location, dInfo.Name, Path.GetFileNameWithoutExtension(box), "Description");
                    string attachment = Module.GetBoxSettingsValue(_Location, dInfo.Name, Path.GetFileNameWithoutExtension(box), "Attachment");

                    ListViewItem lvBox = new ListViewItem(Path.GetFileNameWithoutExtension(box));

                    lgRack.Items.Add(lvBox);
                    lvBox.SubItems.Add(boxSize);
                    lvBox.SubItems.Add(project);
                    lvBox.SubItems.Add(description);
                    lvBox.SubItems.Add(attachment);

                    lstRacks.Items.Add(lvBox);
                }
            }

            AutoSizeColumnList(lstRacks);
            this.Controls.Add(lstRacks);

            Module.CurrentRack = string.Empty;
            Module.CurrentBoxFile = string.Empty;
            Module.DrawingControl.ResumeDrawing(lstRacks);
        }

        private void AutoSizeColumnList(ListView listView)
        {
            //Prevents flickering
            listView.BeginUpdate();

            Dictionary<int, int> columnSize = new Dictionary<int, int>();

            //Auto size using header
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            //Grab column size based on header
            foreach (ColumnHeader colHeader in listView.Columns)
            {
                columnSize.Add(colHeader.Index, colHeader.Width);
            }

            //Auto size using data
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            //Grab comumn size based on data and set max width
            foreach (ColumnHeader colHeader in listView.Columns)
            {
                int nColWidth;
                if (columnSize.TryGetValue(colHeader.Index, out nColWidth))
                {
                    colHeader.Width = Math.Max(nColWidth, colHeader.Width);
                }
                else
                {
                    //Default to 50
                    colHeader.Width = Math.Max(50, colHeader.Width);
                }
            }

            listView.EndUpdate();
        }

        private void Search()
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbConnection con = new OleDbConnection();
            DataTable dt = new DataTable();

            string dbProvider;
            string dbSource;

            con.Close();
            con.Dispose();
            OleDbConnection.ReleaseObjectPool();

            List<string> boxFileList = new List<string>();

            boxFileList = System.IO.Directory.GetFiles(Module.CryoTracker, "*.box", System.IO.SearchOption.AllDirectories).ToList();

            foreach (string box in boxFileList)
            {
                if (System.IO.Path.GetFileNameWithoutExtension(box) != "BoxTemplate")
                {
                    con.Close();
                    con.Dispose();
                    OleDbConnection.ReleaseObjectPool();

                    dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;";
                    dbSource = "Data Source = " + box;

                    con.ConnectionString = dbProvider + dbSource;
                    con.Open();

                    List<string> tableList = new List<string>();

                    tableList = Module.GetTables(con.ConnectionString);
                    string searchWord = string.Empty;
                    searchWord = txtSearch.Text.Replace("'", "");

                    foreach (string tableName in tableList)
                    {
                        if (tableName != "tblBoxInfo" && tableName != "tblArchive")
                        {
                            string select = string.Empty;

                            select = "select s.*, i.* from " + tableName + " as s, tblBoxInfo as i where " +
                                     "s.Slot like '%" + searchWord + "%' " +
                                     "or s.Name like '%" + searchWord + "%' " +
                                     "or CStr(s.SlotDate) like '%" + searchWord + "%' " +
                                     "or s.Material like '%" + searchWord + "%' " +
                                     "or s.Description like '%" + searchWord + "%' " +
                                     "or s.IsHazardous like '%" + searchWord + "%' " +
                                     "or s.Attachment like '%" + searchWord + "%' " +
                                     "or i.Project like '%" + searchWord + "%' " +
                                     "or i.Location like '%" + searchWord + "%' " +
                                     "or i.Rack like '%" + searchWord + "%' " +
                                     "or i.Attachment like '%" + searchWord + "%' " +
                                     "or i.Box like '%" + searchWord + "%'";

                            OleDbCommand cmd = new OleDbCommand(select, con);
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                        }
                    }

                    con.Close();
                    con.Dispose();
                    OleDbConnection.ReleaseObjectPool();
                }
            }

            Module.DrawingControl.SetDoubleBuffered(dgvAllContents);
            Module.DrawingControl.SuspendDrawing(dgvAllContents);

            dgvAllContents.DataSource = null;
            dgvAllContents.DataSource = dt.DefaultView;

            Module.FormatDataGridView(dgvAllContents);

            Module.DrawingControl.ResumeDrawing(dgvAllContents);
        }

        #endregion
    }
}

