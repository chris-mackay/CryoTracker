//    CryoTracker is a cryo/freezer box contents tracker
//    Copyright(C) 2018-2019 Christopher Ryan Mackay

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CryoTracker
{
    public partial class frmArchive : Form
    {
        public frmBox caller_frmBox;

        public frmArchive()
        {
            InitializeComponent();
        }

        private void frmArchive_Load(object sender, EventArgs e)
        {
            Module.MySystemRenderer renderer = new Module.MySystemRenderer();
            toolStrip1.Renderer = renderer;

            try
            {
                DBConnector db = new DBConnector();
                db.OpenBox(Module.CurrentBoxFile);
                db.SQLSelect("select * from tblArchive");
                db.LoadTableContents(dgvArchive);
                db.CloseBox();
            }
            catch (Exception ex)
            {
                frmErrorReport errorReport = new frmErrorReport();
                errorReport.txtError.Text = ex.ToString();
                errorReport.ShowDialog();
            }
        }

        private void CloseArchive(object sender, FormClosedEventArgs e)
        {
            if (caller_frmBox != null)
            {
                caller_frmBox.RetainFilter();
                caller_frmBox.FormatSlots();
            }
        }

        private void CloseArchive(object sender, EventArgs e)
        {
            if (caller_frmBox != null)
            {
                caller_frmBox.RetainFilter();
                caller_frmBox.FormatSlots();
            }

            this.Close();
            this.Dispose();
        }

        private void RestoreItem(object sender, EventArgs e)
        {
            if (dgvArchive.SelectedRows.Count != 0)
            {
                if (MessageBox.Show("Are you sure you want to restore the selected item(s)?", "Restore Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        DBConnector db = new DBConnector();
                        db.OpenBox(Module.CurrentBoxFile);

                        this.Cursor = Cursors.WaitCursor;
                        foreach (DataGridViewRow row in dgvArchive.SelectedRows)
                        {
                            int id = 0;
                            id = Convert.ToInt32(row.Cells["ID"].Value);

                            string slot = row.Cells["Slot"].Value.ToString();
                            DateTime date = Convert.ToDateTime(row.Cells["SlotDate"].Value);
                            string material = row.Cells["Material"].Value.ToString();
                            string name = row.Cells["Name"].Value.ToString();
                            string description = row.Cells["Description"].Value.ToString();
                            string rtf = row.Cells["Rtf"].Value.ToString();
                            string isHazardous = row.Cells["IsHazardous"].Value.ToString();
                            string hazardType = row.Cells["HazardType"].Value.ToString();
                            string attachment = row.Cells["Attachment"].Value.ToString();

                            db.SQLCommand("insert into " + slot +
                                                    " (Slot,Name,SlotDate,Material,Description,Rtf,IsHazardous,HazardType,Attachment)" +
                                                    " values('" + slot + "','" + name + "','" + date + "','" + material + "','" + description + "','" + rtf + "','" + isHazardous + "','" + hazardType + "','" + attachment + "')");

                            db.SQLCommand("delete from tblArchive where ID = " + id + "");
                        }

                        db.SQLSelect("select * from tblArchive");
                        db.LoadTableContents(dgvArchive);
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

        private void DeleteItem(object sender, EventArgs e)
        {
            if (dgvArchive.SelectedRows.Count != 0)
            {
                if (MessageBox.Show("Are you sure you want to PERMANENTLY DELETE the selected item(s)?", "Permanently Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        DBConnector db = new DBConnector();
                        db.OpenBox(Module.CurrentBoxFile);

                        foreach (DataGridViewRow row in dgvArchive.SelectedRows)
                        {
                            int id = Convert.ToInt32(row.Cells["ID"].Value);
                            db.SQLCommand("delete from tblArchive where ID = " + id + "");
                        }

                        db.SQLSelect("select * from tblArchive");
                        db.LoadTableContents(dgvArchive);
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

        private void frmArchive_Paint(object sender, PaintEventArgs e)
        {
            Module.SetFormColors(this);

            Color borderColor = ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.AppBorderColor));

            Rectangle rect1 = new Rectangle(dgvArchive.Location.X, dgvArchive.Location.Y, dgvArchive.ClientSize.Width, dgvArchive.ClientSize.Height);
            rect1.Inflate(1, 1);
            ControlPaint.DrawBorder(e.Graphics, rect1, borderColor, ButtonBorderStyle.Solid);

            Rectangle rect11 = new Rectangle(dgvArchive.Location.X, dgvArchive.Location.Y, dgvArchive.ClientSize.Width, dgvArchive.ClientSize.Height);
            rect11.Inflate(3, 3);
            ControlPaint.DrawBorder(e.Graphics, rect11, borderColor, ButtonBorderStyle.Solid);
        }

        private void ViewSlotAttachment(object sender, EventArgs e)
        {
            string selectedAttachment = string.Empty;

            if (dgvArchive.SelectedRows.Count != 0)
            {
                if (dgvArchive.SelectedRows.Count == 1)
                {
                    foreach (DataGridViewRow row in dgvArchive.SelectedRows)
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
    }
}
