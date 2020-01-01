//    CryoTracker is a cryo/freezer box contents tracker
//    Copyright(C) 2018-2019 Christopher Ryan Mackay

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CryoTracker
{
    public partial class frmSlot : Form
    {
        public frmBox caller_frmBox;
        public string currentSlot = string.Empty;
        public MainForm caller_MainForm;

        public frmSlot()
        {
            InitializeComponent();
        }

        private ContextMenu SlotContextMenu()
        {
            ContextMenu mnu = new ContextMenu();

            MenuItem cxmnuAddItem = new MenuItem("Add Item");
            MenuItem cxmnuEditItem = new MenuItem("Edit Item");
            MenuItem cxmnuDeleteItem = new MenuItem("Delete Item");
            MenuItem cxmnuArchiveItem = new MenuItem("Archive Item");
            MenuItem cxmnuClearSlot = new MenuItem("Clear Slot");
            MenuItem cxmnuViewSlotAttachment = new MenuItem("View Attachmnet");
            MenuItem cxmnuRemoveSlotAttachment = new MenuItem("Remove Attachmnet");

            cxmnuAddItem.Click += new EventHandler(AddItem);
            cxmnuEditItem.Click += new EventHandler(EditItem);
            cxmnuDeleteItem.Click += new EventHandler(DeleteItem);
            cxmnuArchiveItem.Click += new EventHandler(ArchiveItem);
            cxmnuClearSlot.Click += new EventHandler(ClearSlot);
            cxmnuViewSlotAttachment.Click += new EventHandler(ViewSlotAttachment);
            cxmnuRemoveSlotAttachment.Click += new EventHandler(RemoveSlotAttachment);

            mnu.MenuItems.Add(cxmnuAddItem);
            mnu.MenuItems.Add(cxmnuEditItem);
            mnu.MenuItems.Add(cxmnuDeleteItem);
            mnu.MenuItems.Add("-");
            mnu.MenuItems.Add(cxmnuArchiveItem);
            mnu.MenuItems.Add("-");
            mnu.MenuItems.Add(cxmnuClearSlot);
            mnu.MenuItems.Add("-");
            mnu.MenuItems.Add(cxmnuViewSlotAttachment);
            mnu.MenuItems.Add(cxmnuRemoveSlotAttachment);

            return mnu;
        }

        private void ViewSlotAttachment(object sender, EventArgs e)
        {
            string selectedAttachment = string.Empty;

            if (dgvSlot.SelectedRows.Count != 0)
            {
                if (dgvSlot.SelectedRows.Count == 1)
                {
                    foreach (DataGridViewRow row in dgvSlot.SelectedRows)
                    {
                        selectedAttachment = row.Cells["Attachment"].Value.ToString();
                    }

                    string currentBox = Path.GetFileNameWithoutExtension(Module.CurrentBoxFile);
                    string file = Module.SetSlotAttachmentFile(Module.CurrentLocation, Module.CurrentRack, currentBox, selectedAttachment);

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

        private void RemoveSlotAttachment(object sender, EventArgs e)
        {
            string selectedSlot = string.Empty;
            string selectedAttachment = string.Empty;
            DBConnector db = new DBConnector();

            if (dgvSlot.SelectedRows.Count != 0)
            {
                if (MessageBox.Show("Are you sure you want to remove the attachment from the selected items?", "Remove Attachment", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        // Remove all the files from the selected items in the database
                        foreach (DataGridViewRow row in dgvSlot.SelectedRows)
                        {
                            selectedSlot = row.Cells["Slot"].Value.ToString();
                            int id = Convert.ToInt32(row.Cells["ID"].Value);

                            string currentBox = Path.GetFileNameWithoutExtension(Module.CurrentBoxFile);

                            db.OpenBox(Module.SetBoxFile(Module.CurrentLocation, Module.CurrentRack, currentBox));
                            db.SQLCommand("update " + selectedSlot + " set Attachment = '' where id = " + id);
                            db.CloseBox();
                        }

                        db.OpenBox(Module.CurrentBoxFile);
                        db.SQLSelect("select * from " + currentSlot);
                        db.LoadTableContents(dgvSlot);
                        db.CloseBox();

                        this.Cursor = Cursors.Default;
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

        private void frmSlot_Load(object sender, EventArgs e)
        {
            try
            {
                Module.MySystemRenderer renderer = new Module.MySystemRenderer();
                toolStrip1.Renderer = renderer;

                DBConnector db = new DBConnector();
                db.OpenBox(Module.CurrentBoxFile);
                db.SQLSelect("select * from " + currentSlot);
                db.LoadTableContents(dgvSlot);
                db.CloseBox();
            }
            catch (Exception ex)
            {
                frmErrorReport errorReport = new frmErrorReport();
                errorReport.txtError.Text = ex.ToString();
                errorReport.ShowDialog();
            }
        }

        private void CloseSlot(object sender, FormClosedEventArgs e)
        {
            if (caller_frmBox != null)
            {
                caller_frmBox.RetainFilter();
                caller_frmBox.FormatSlots();
            }
        }

        private void CloseSlot(object sender, EventArgs e)
        {
            if (caller_frmBox != null)
            {
                caller_frmBox.RetainFilter();
                caller_frmBox.FormatSlots();
            }

            this.Close();
            this.Dispose();
        }

        private void AddItem(object sender, EventArgs e)
        {
            frmSlotItem new_frmItem = new frmSlotItem();
            new_frmItem.Text = "Add Item to " + currentSlot;
            new_frmItem.ckbIsHazardous.Checked = false;
            new_frmItem.txtHazardType.Text = string.Empty;
            new_frmItem.txtAttachment.Text = string.Empty;

            if (new_frmItem.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SlotItem item = new SlotItem();
                    item.Name = new_frmItem.txtName.Text;
                    item.StoredDate = new_frmItem.dtpDate.Value.Date;
                    item.Material = new_frmItem.txtMaterial.Text;
                    item.Description = new_frmItem.txtDescription.Text;
                    item.Rtf = new_frmItem.txtDescription.Rtf;
                    item.IsHazardous = new_frmItem.ckbIsHazardous.Checked;
                    item.HazardType = new_frmItem.txtHazardType.Text;
                    item.Attachment = new_frmItem.txtAttachment.Text;

                    string currentBox = System.IO.Path.GetFileNameWithoutExtension(Module.CurrentBoxFile);

                    if (new_frmItem.txtAttachment.Text != string.Empty)
                    {
                        File.Copy(Module.SlotAttachmentFileToCopy, Module.SetSlotAttachmentFile(Module.CurrentLocation, Module.CurrentRack, currentBox, item.Attachment));
                    }

                    DBConnector db = new DBConnector();
                    db.OpenBox(Module.CurrentBoxFile);
                    db.SQLCommand("insert into " + currentSlot +
                                               " (Slot,Name,SlotDate,Material,Description,Rtf,IsHazardous,HazardType,Attachment)" +
                                               " values('" + currentSlot + "','" + item.Name + "','" + item.StoredDate + "','" + item.Material + "','" + item.Description + "','" + item.Rtf + "','" + item.IsHazardous + "','" + item.HazardType + "','" + item.Attachment + "')");
                    db.SQLSelect("select * from " + currentSlot);
                    db.LoadTableContents(dgvSlot);
                    db.CloseBox();
                }
                catch (Exception ex)
                {
                    frmErrorReport errorReport = new frmErrorReport();
                    errorReport.txtError.Text = ex.ToString();
                    errorReport.ShowDialog();
                }
            }
        }

        private void EditItem(object sender, EventArgs e)
        {
            if (dgvSlot.SelectedRows.Count != 0)
            {
                if (dgvSlot.SelectedRows.Count == 1)
                {
                    frmSlotItem new_frmItem = new frmSlotItem();
                    new_frmItem.Text = "Edit Item in " + currentSlot;

                    int id = 0;

                    foreach (DataGridViewRow row in dgvSlot.SelectedRows)
                    {
                        id = Convert.ToInt32(dgvSlot.CurrentRow.Cells["ID"].Value);
                        DateTime old_date = Convert.ToDateTime(dgvSlot.CurrentRow.Cells["SlotDate"].Value);
                        string old_material = dgvSlot.CurrentRow.Cells["Material"].Value.ToString();
                        string old_name = dgvSlot.CurrentRow.Cells["Name"].Value.ToString();
                        string old_description = dgvSlot.CurrentRow.Cells["Description"].Value.ToString();
                        string old_rtf = dgvSlot.CurrentRow.Cells["Rtf"].Value.ToString();
                        bool old_isHazardous = bool.Parse(dgvSlot.CurrentRow.Cells["IsHazardous"].Value.ToString());
                        string old_hazardType = dgvSlot.CurrentRow.Cells["HazardType"].Value.ToString();
                        string old_attachment = dgvSlot.CurrentRow.Cells["Attachment"].Value.ToString();

                        if (old_isHazardous)
                        {
                            new_frmItem.ckbIsHazardous.Checked = true;
                        }
                        else
                        {
                            new_frmItem.ckbIsHazardous.Checked = false;
                        }

                        new_frmItem.dtpDate.Value = old_date;
                        new_frmItem.txtMaterial.Text = old_material;
                        new_frmItem.txtName.Text = old_name;
                        new_frmItem.txtDescription.Text = old_description;
                        new_frmItem.txtDescription.Rtf = old_rtf;
                        new_frmItem.txtHazardType.Text = old_hazardType;
                        new_frmItem.txtAttachment.Text = old_attachment;
                    }

                    if (new_frmItem.ShowDialog() == DialogResult.OK)
                    {
                        if (MessageBox.Show("Are you sure you want to edit the selected item?", "Edit Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            try
                            {
                                SlotItem item = new SlotItem();

                                item.Name = new_frmItem.txtName.Text;
                                item.StoredDate = new_frmItem.dtpDate.Value.Date;
                                item.Material = new_frmItem.txtMaterial.Text;
                                item.Description = new_frmItem.txtDescription.Text;
                                item.Rtf = new_frmItem.txtDescription.Rtf;
                                item.IsHazardous = new_frmItem.ckbIsHazardous.Checked;
                                item.HazardType = new_frmItem.txtHazardType.Text;
                                item.Attachment = new_frmItem.txtAttachment.Text;

                                string currentBox = Path.GetFileNameWithoutExtension(Module.CurrentBoxFile);
                                string slotAttachmentFile = Module.SetSlotAttachmentFile(Module.CurrentLocation, Module.CurrentRack, currentBox, item.Attachment);

                                if (!File.Exists(slotAttachmentFile) && item.Attachment != string.Empty)
                                {
                                    File.Copy(Module.SlotAttachmentFileToCopy, Module.SetSlotAttachmentFile(Module.CurrentLocation, Module.CurrentRack, currentBox, item.Attachment));
                                }

                                DBConnector db = new DBConnector();
                                db.OpenBox(Module.CurrentBoxFile);
                                db.SQLCommand("update " + currentSlot +
                                                      " set Name = '" + item.Name + "', " +
                                                           "SlotDate = '" + item.StoredDate + "'," +
                                                           "Material = '" + item.Material + "'," +
                                                           "Description = '" + item.Description + "'," +
                                                           "Rtf = '" + item.Rtf + "'," +
                                                           "IsHazardous = '" + item.IsHazardous + "'," +
                                                           "HazardType = '" + item.HazardType + "'," +
                                                           "Attachment = '" + item.Attachment + "' " +
                                                           "where ID = " + id + "");

                                db.SQLSelect("select * from " + currentSlot);
                                db.LoadTableContents(dgvSlot);
                                db.CloseBox();
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
                else
                {
                    MessageBox.Show("You can only edit one item at a time", "Edit Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void DeleteItem(object sender, EventArgs e)
        {
            if (dgvSlot.SelectedRows.Count != 0)
            {
                if (MessageBox.Show("Are you sure you want to delete the selected item(s)?", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        DBConnector db = new DBConnector();
                        db.OpenBox(Module.CurrentBoxFile);

                        foreach (DataGridViewRow row in dgvSlot.SelectedRows)
                        {
                            int id = Convert.ToInt32(row.Cells["ID"].Value);

                            db.SQLCommand("delete from " + currentSlot + "  where id = " + id + "");
                        }

                        db.SQLSelect("select * from " + currentSlot);
                        db.LoadTableContents(dgvSlot);
                        db.CloseBox();
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

        private void ArchiveItem(object sender, EventArgs e)
        {
            DBConnector db = new DBConnector();

            if (dgvSlot.SelectedRows.Count != 0)
            {
                if (MessageBox.Show("Are you sure you want to archive the selected item(s)?", "Archive Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        foreach (DataGridViewRow row in dgvSlot.SelectedRows)
                        {
                            int id = Convert.ToInt32(row.Cells["ID"].Value);
                            string slot = row.Cells["Slot"].Value.ToString();
                            DateTime date = Convert.ToDateTime(row.Cells["SlotDate"].Value);
                            DateTime archiveDate = DateTime.Now;
                            string material = row.Cells["Material"].Value.ToString();
                            string name = row.Cells["Name"].Value.ToString();
                            string description = row.Cells["Description"].Value.ToString();
                            string rtf = row.Cells["Rtf"].Value.ToString();
                            string isHazardous = row.Cells["IsHazardous"].Value.ToString();
                            string hazardType = row.Cells["HazardType"].Value.ToString();
                            string attachment = row.Cells["Attachment"].Value.ToString();

                            // Insert into tblArchive
                            db.OpenBox(Module.CurrentBoxFile);
                            db.SQLCommand("insert into tblArchive" +
                                                    " (Slot,Name,SlotDate,ArchiveDate,Material,Description,Rtf,IsHazardous,HazardType,Attachment)" +
                                                    " values('" + slot + "','" + name + "','" + date + "','" + archiveDate + "','" + material + "','" + description + "','" + rtf + "','" + isHazardous + "','" + hazardType + "','" + attachment + "')");

                            // Delete from current slot after inserting into tblArchive
                            db.SQLCommand("delete from " + slot + "  where id = " + id + "");
                            db.CloseBox();
                        }

                        db.OpenBox(Module.CurrentBoxFile);
                        db.SQLSelect("select * from " + currentSlot);
                        db.LoadTableContents(dgvSlot);
                        db.CloseBox();
                        this.Cursor = Cursors.Default;
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

        private void ClearSlot(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all contents?", "Clear Slot", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    DBConnector db = new DBConnector();

                    db.OpenBox(Module.CurrentBoxFile);
                    db.SQLCommand("delete * from " + currentSlot);
                    db.SQLSelect("select * from " + currentSlot);
                    db.LoadTableContents(dgvSlot);
                    db.CloseBox();
                }
                catch (Exception ex)
                {
                    frmErrorReport errorReport = new frmErrorReport();
                    errorReport.txtError.Text = ex.ToString();
                    errorReport.ShowDialog();
                }
            }
        }

        private void Table_RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu contextMenu = new ContextMenu();
                contextMenu = SlotContextMenu();
                contextMenu.Show(dgvSlot, new System.Drawing.Point(e.X, e.Y));
            }
        }

        private void frmSlot_Paint(object sender, PaintEventArgs e)
        {
            Module.SetFormColors(this);

            Color borderColor = ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.AppBorderColor));

            Rectangle rect1 = new Rectangle(dgvSlot.Location.X, dgvSlot.Location.Y, dgvSlot.ClientSize.Width, dgvSlot.ClientSize.Height);
            rect1.Inflate(1, 1);
            ControlPaint.DrawBorder(e.Graphics, rect1, borderColor, ButtonBorderStyle.Solid);

            Rectangle rect11 = new Rectangle(dgvSlot.Location.X, dgvSlot.Location.Y, dgvSlot.ClientSize.Width, dgvSlot.ClientSize.Height);
            rect11.Inflate(3, 3);
            ControlPaint.DrawBorder(e.Graphics, rect11, borderColor, ButtonBorderStyle.Solid);
        }
    }
}
