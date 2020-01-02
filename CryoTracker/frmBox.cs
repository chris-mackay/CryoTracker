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
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CryoTracker
{
    public partial class frmBox : Form
    {
        private Color prevColor;
        private List<Label> slots;
        private int timerInterval = 0;
        Slot firstSelectedSlot = new Slot();
        private bool contentsIsBeingFiltered;
        private List<string> tempSlotsWithContents = new List<string>();

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        private enum CombineOptions
        {
            CombineContents,
            DeleteContents,
            CombineEmpty
        }

        public frmBox()
        {
            InitializeComponent();
        }

        #region Voids

        private void UpdateBoxInformation()
        {
            string boxName = Path.GetFileNameWithoutExtension(Module.CurrentBoxFile);
            string rack = Module.CurrentRack;
            string location = Module.CurrentLocation;
            string project = Module.GetBoxSettingsValue(location, rack, boxName, "Project");

            Module.DrawingControl.SetDoubleBuffered(dgvBoxInfo);
            Module.DrawingControl.SuspendDrawing(dgvBoxInfo);

            dgvBoxInfo.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.AppBackgroundColor));
            dgvBoxInfo.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.AppTextColor));

            dgvBoxInfo.Rows.Add("Box Name:", boxName);
            dgvBoxInfo.Rows.Add("Location:", location);
            dgvBoxInfo.Rows.Add("Rack:", rack);
            dgvBoxInfo.Rows.Add("Project:", project);

            Module.DrawingControl.ResumeDrawing(dgvBoxInfo);
            dgvBoxInfo.ClearSelection();
        }

        private void CombineSlots(List<Label> _Slots, CombineOptions _CombineOption)
        {
            List<int> Xs = new List<int>();
            List<int> Ys = new List<int>();
            List<int> Widths = new List<int>();
            List<int> Heights = new List<int>();

            int X = 0;
            int Y = 0;
            int selectionWidth = 0;
            int selectionHeight = 0;

            List<string> slotsWithContents = new List<string>();
            slotsWithContents = SlotsWithContents();

            foreach (Label slot in _Slots)
            {
                Xs.Add(slot.Location.X);
                Ys.Add(slot.Location.Y);
                Widths.Add(slot.Width);
                Heights.Add(slot.Height);
            }

            X = Xs.Min();
            Y = Ys.Min();

            selectionWidth = GetSelectionWidth();
            selectionHeight = GetSelectionHeight();

            string slotName = DetermineCombinedSlotName(_Slots);

            Slot combinedSlot = new Slot();
            combinedSlot.Name = slotName;
            combinedSlot.LocationX = X;
            combinedSlot.LocationY = Y;
            combinedSlot.Width = selectionWidth;
            combinedSlot.Height = selectionHeight;

            Point slotLocation = new Point();
            slotLocation.X = combinedSlot.LocationX;
            slotLocation.Y = combinedSlot.LocationY;

            Size slotSize = new Size();
            slotSize.Width = selectionWidth;
            slotSize.Height = selectionHeight;

            CreateSlot(combinedSlot.Name, slotLocation, slotSize);

            this.Cursor = Cursors.WaitCursor;

            // Create new table in database
            DBConnector db = new DBConnector();
            db.CloseBox();

            if (_CombineOption == CombineOptions.CombineContents)
            {
                // Combine contents
                foreach (Label slot in _Slots)
                {
                    if (slotsWithContents.Contains(slot.Name) && slot.Name != combinedSlot.Name)
                    {
                        db.OpenBox(Module.CurrentBoxFile);
                        db.SQLCommand(@"insert into " + combinedSlot.Name + " select [Slot], [Name], [SlotDate], [Material], [Description], [Rtf], [IsHazardous], [HazardType], [Attachment] from " + slot.Name);
                        db.SQLCommand(@"update " + combinedSlot.Name + " set Slot = '" + combinedSlot.Name + "'");
                        db.SQLCommand(@"delete * from " + slot.Name);
                        db.CloseBox();
                    }
                }

                List<Control> lst1 = new List<Control>();
                foreach (Label lbl in _Slots)
                {
                    Control ctrl = lbl as Control;
                    lst1.Add(ctrl);
                }

                Module.DrawingControl.SetDoubleBuffered_ListControls(lst1);
                Module.DrawingControl.SuspendDrawing_ListControls(lst1);

                foreach (Label lbl in _Slots)
                {
                    pnlBox.Controls.Remove(lbl);
                }

                RefreshSlots();

                List<Control> lst2 = new List<Control>();
                foreach (Label lbl in slots)
                {
                    Control ctrl = lbl as Control;
                    lst2.Add(ctrl);
                }

                Module.DrawingControl.ResumeDrawing_ListControls(lst2);
                Module.LoadAllBoxContents(dgvAllContents);
                FormatSlots();
                this.Cursor = Cursors.Default;
            }
            else if (_CombineOption == CombineOptions.DeleteContents)
            {
                foreach (Label slot in _Slots)
                {
                    if (slotsWithContents.Contains(slot.Name))
                    {
                        db.OpenBox(Module.CurrentBoxFile);
                        db.SQLCommand(@"delete * from " + slot.Name);
                        db.CloseBox();
                    }
                }

                List<Control> lst1 = new List<Control>();
                foreach (Label lbl in _Slots)
                {
                    Control ctrl = lbl as Control;
                    lst1.Add(ctrl);
                }

                Module.DrawingControl.SetDoubleBuffered_ListControls(lst1);
                Module.DrawingControl.SuspendDrawing_ListControls(lst1);

                foreach (Label lbl in _Slots)
                {
                    pnlBox.Controls.Remove(lbl);
                }

                RefreshSlots();

                List<Control> lst2 = new List<Control>();
                foreach (Label lbl in slots)
                {
                    Control ctrl = lbl as Control;
                    lst2.Add(ctrl);
                }

                Module.DrawingControl.ResumeDrawing_ListControls(lst2);
                Module.LoadAllBoxContents(dgvAllContents);
                FormatSlots();
                this.Cursor = Cursors.Default;
            }
            else if (_CombineOption == CombineOptions.CombineEmpty)
            {
                List<Control> lst1 = new List<Control>();
                foreach (Label lbl in _Slots)
                {
                    Control ctrl = lbl as Control;
                    lst1.Add(ctrl);
                }

                Module.DrawingControl.SetDoubleBuffered_ListControls(lst1);
                Module.DrawingControl.SuspendDrawing_ListControls(lst1);

                foreach (Label lbl in _Slots)
                {
                    pnlBox.Controls.Remove(lbl);
                }

                RefreshSlots();

                List<Control> lst2 = new List<Control>();
                foreach (Label lbl in slots)
                {
                    Control ctrl = lbl as Control;
                    lst2.Add(ctrl);
                }

                Module.DrawingControl.ResumeDrawing_ListControls(lst2);
                Module.LoadAllBoxContents(dgvAllContents);
                FormatSlots();
                this.Cursor = Cursors.Default;
            }
        }

        private void ClearSelection(object sender, EventArgs e)
        {
            FormatSlots();
        }

        private void RefreshSlots()
        {
            slots.Clear();
            List<Label> list = new List<Label>();
            foreach (Label item in pnlBox.Controls)
            {
                slots.Add(item as Label);
            }

            string boxConfig = string.Empty;
            boxConfig = Module.SetBoxConfigurationFile(Module.CurrentLocation, Module.CurrentRack, Path.GetFileNameWithoutExtension(Module.CurrentBoxFile));

            StreamWriter writer = new StreamWriter(boxConfig);

            foreach (Label item in slots)
            {
                Slot slot = new Slot();
                slot.Name = item.Name;
                slot.LocationX = item.Location.X;
                slot.LocationY = item.Location.Y;
                slot.Width = item.Width;
                slot.Height = item.Height;

                string line = slot.Name + "\t" + slot.LocationX + "\t" + slot.LocationY + "\t" + slot.Width + "\t" + slot.Height;
                writer.WriteLine(line);
            }

            string pnl = pnlBox.Name + "\t" + pnlBox.Location.X + "\t" + pnlBox.Location.Y + "\t" + pnlBox.Width + "\t" + pnlBox.Height;
            writer.WriteLine(pnl);

            writer.Close();
            writer = null;
        }

        private void CreateBox()
        {
            string boxConfig = string.Empty;
            boxConfig = Module.SetBoxConfigurationFile(Module.CurrentLocation, Module.CurrentRack, Path.GetFileNameWithoutExtension(Module.CurrentBoxFile));

            if (!File.Exists(boxConfig))
            {
                CreateStandardBox();
            }
            else
            {
                List<int> incr = new List<int>();
                StreamReader reader = new StreamReader(boxConfig);
                string tabLine = string.Empty;
                slots = new List<Label>();

                while ((tabLine = reader.ReadLine()) != null)
                {
                    char[] separator = new char[] { '\t' };
                    string[] values = tabLine.Split(separator, StringSplitOptions.None);

                    string name = values[0];
                    int locX = int.Parse(values[1]);
                    int locY = int.Parse(values[2]);
                    int width = int.Parse(values[3]);
                    int height = int.Parse(values[4]);

                    if (name != "pnlBox")
                    {
                        Point loc = new Point(locX, locY);
                        Size size = new Size(width, height);
                        CreateSlot(name, loc, size);
                    }

                    if (name == "pnlBox")
                    {
                        pnlBox.Location = new Point(locX, locY);
                        pnlBox.Height = height;
                        pnlBox.Width = width;
                        pnlBox.Invalidate();
                    }
                }

                reader.Close();
                reader = null;
            }
        }

        private void CreateStandardBox()
        {
            slots = new List<Label>();
            int square = pnlBox.Width;
            int prevX = 0; // Starting X
            int prevY = 0; // Starting Y

            int divisions = 0; // The number of slots to split the box into
            string boxSize = string.Empty;
            boxSize = Module.GetBoxSettingsValue(Module.CurrentLocation, Module.CurrentRack, Path.GetFileNameWithoutExtension(Module.CurrentBoxFile), "BoxSize");

            switch (boxSize)
            {
                case "Empty Box":
                    divisions = 1;
                    break;
                case "2x2":
                    divisions = 2;
                    break;
                case "3x3":
                    divisions = 3;
                    break;
                case "4x4":
                    divisions = 4;
                    break;
                case "5x5":
                    divisions = 5;
                    break;
                case "6x6":
                    divisions = 6;
                    break;
                case "7x7":
                    divisions = 7;
                    break;
                case "8x8":
                    divisions = 8;
                    break;
                case "9x9":
                    divisions = 9;
                    break;
                case "10x10":
                    divisions = 10;
                    break;
                default:
                    break;
            }

            int offset = 0;

            for (int i = 1; i <= divisions; i++)
            {
                for (int j = 1; j <= divisions; j++)
                {
                    string name = string.Empty;

                    switch (i)
                    {
                        case 1:
                            name = "A";
                            break;
                        case 2:
                            name = "B";
                            break;
                        case 3:
                            name = "C";
                            break;
                        case 4:
                            name = "D";
                            break;
                        case 5:
                            name = "E";
                            break;
                        case 6:
                            name = "F";
                            break;
                        case 7:
                            name = "G";
                            break;
                        case 8:
                            name = "H";
                            break;
                        case 9:
                            name = "I";
                            break;
                        case 10:
                            name = "J";
                            break;
                        default:
                            break;
                    }

                    Size size = new Size();

                    double mod = square % divisions;

                    if (mod == 0)
                    {
                        size.Width = square / divisions;
                        size.Height = square / divisions;
                    }
                    else
                    {
                        double box = (double)square / divisions;
                        size.Width = (int)Math.Round(box, 0);
                        size.Height = (int)Math.Round(box, 0);
                    }

                    offset = size.Height;

                    int boxPanelSize = offset * divisions;

                    pnlBox.Height = boxPanelSize;
                    pnlBox.Width = boxPanelSize;
                    pnlBox.Invalidate();

                    CreateSlot(name + j.ToString(), new Point(prevX, prevY), size);
                    prevX += offset;
                }
                // Reset X
                prevX = 0;
                prevY += offset;
            }
        }

        private void CreateSlot(string _Name, Point _Location, Size _Size)
        {
            Label slot = new Label();
            slot.Parent = pnlBox;
            slot.Name = _Name;
            slot.Location = _Location;
            slot.Size = _Size;
            slot.Font = new Font("Segoe UI", 9);
            slot.BackColor = Color.FromArgb(250, 240, 230);
            slot.BorderStyle = BorderStyle.FixedSingle;
            slot.ForeColor = Color.DimGray;
            slot.Text = _Name;
            slot.Margin = new Padding(0);
            slot.AutoSize = false;

            slot.Click += new EventHandler(Slot_LeftClick);
            slot.DoubleClick += new EventHandler(Slot_LeftDoubleClick);
            slot.MouseEnter += new EventHandler(Slot_Enter);
            slot.MouseLeave += new EventHandler(Slot_Leave);
            slot.MouseHover += new EventHandler(Slot_Hover);
            slot.MouseUp += new MouseEventHandler(Slot_RightClick);
            slot.DragEnter += new DragEventHandler(Slot_DragEnter);
            slot.DragDrop += new DragEventHandler(Slot_DragDrop);
            slot.AllowDrop = true;

            slots.Add(slot);
            pnlBox.Controls.Add(slot);

            slot.BringToFront();
            slot.Invalidate();

        }

        public void FormatSlots()
        {
            if (!contentsIsBeingFiltered)
            {
                foreach (Label ctrl in slots)
                {
                    string slot = string.Empty;
                    slot = ctrl.Name;

                    List<string> slotsWithContents = new List<string>();
                    slotsWithContents = SlotsWithContents();

                    if (slotsWithContents.Contains(slot))
                    {
                        ctrl.BackColor = ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.SlotHasContentsColor));
                    }
                    else
                    {
                        ctrl.BackColor = ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.SlotNoItemsColor));
                    }
                }
            }
            else
            {
                foreach (Label ctrl in slots)
                {
                    string slot = string.Empty;
                    slot = ctrl.Name;

                    if (tempSlotsWithContents.Contains(slot))
                    {
                        ctrl.BackColor = ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.SlotHasContentsColor));
                    }
                    else
                    {
                        ctrl.BackColor = ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.SlotNoItemsColor));
                    }
                }

            }
        }

        public void RetainFilter()
        {
            if (txtFilter.Text != "Enter search criteria...")
            {
                contentsIsBeingFiltered = true;
                Filter();
            }
            else
            {
                contentsIsBeingFiltered = false;
                Module.LoadAllBoxContents(dgvAllContents);
            }
        }

        private void Filter()
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbConnection con = new OleDbConnection();

            string dbProvider;
            string dbSource;
            DataTable dt = new DataTable();

            con.Close();
            con.Dispose();
            OleDbConnection.ReleaseObjectPool();

            dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;";
            dbSource = "Data Source = " + Module.CurrentBoxFile;

            con.ConnectionString = dbProvider + dbSource;
            con.Open();

            List<string> tableList = new List<string>();

            tableList = Module.GetTables(con.ConnectionString);
            string searchWord = txtFilter.Text.Replace("'", "");

            foreach (string tableName in tableList)
            {
                if (tableName != "tblBoxInfo" && tableName != "tblArchive")
                {
                    string select = string.Empty;
                    select = "select * from " + tableName + " where Slot like '%" + searchWord + "%' " +
                                "or Name like '%" + searchWord + "%' " +
                                "or CStr(SlotDate) like '%" + searchWord + "%' " +
                                "or Material like '%" + searchWord + "%' " +
                                "or Description like '%" + searchWord + "%' " +
                                "or IsHazardous like '%" + searchWord + "%' " +
                                "or HazardType like '%" + searchWord + "%' " +
                                "or Attachment like '%" + searchWord + "%'";

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

        private void ClearFilter()
        {
            contentsIsBeingFiltered = false;
            tempSlotsWithContents.Clear();
            txtFilter.Text = string.Empty;
            Module.LoadAllBoxContents(dgvAllContents);

            txtFilter.Font = new Font(txtFilter.Font, FontStyle.Italic);
            txtFilter.ForeColor = Color.DimGray;
            txtFilter.Text = "Enter search criteria...";
        }

        #endregion

        #region Events

        private void OpenSlot(object sender, EventArgs e)
        {
            if (dgvAllContents.Focused)
            {
                if (dgvAllContents.SelectedRows.Count == 1)
                {
                    string slot = dgvAllContents.CurrentRow.Cells["Slot"].Value.ToString();

                    frmSlot new_frmSlot = new frmSlot();
                    new_frmSlot.caller_frmBox = this;
                    new_frmSlot.currentSlot = slot;
                    new_frmSlot.Text = "Slot " + slot;
                    new_frmSlot.ShowDialog();
                }
                else if (dgvAllContents.SelectedRows.Count > 1)
                {
                    MessageBox.Show("You can only open one slot at a time", "Open Slot", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    return;
                }
            }
            else
            {
                List<Label> slots = new List<Label>();
                slots = GetAllSelectedSlots();
                string slot = string.Empty;

                if (slots.Count == 1)
                {
                    slot = slots[0].Name;
                    frmSlot new_frmSlot = new frmSlot();
                    new_frmSlot.caller_frmBox = this;
                    new_frmSlot.currentSlot = slot;
                    new_frmSlot.Text = "Slot " + slot;
                    new_frmSlot.ShowDialog();
                }
                else if (slots.Count > 1)
                {
                    MessageBox.Show("You can only open one slot at a time", "Open Slot", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    return;
                }
            }
        }

        private void CombineSlots(object sender, EventArgs e)
        {
            List<Label> selectedSlots = new List<Label>();
            selectedSlots = GetAllSelectedSlots();

            List<string> slotsWithContents = new List<string>();
            slotsWithContents = SlotsWithContents();

            bool combinedSlotIsSelected = CombinedSlotIsSelected(selectedSlots);

            if (selectedSlots.Count > 1)
            {
                if (!combinedSlotIsSelected)
                {
                    if (SelectedSlotsAreValid())
                    {
                        List<Label> selectedSlotsWithContents = new List<Label>();
                        StringBuilder sb1 = new StringBuilder();
                        StringBuilder sb2 = new StringBuilder();

                        foreach (Label slot in selectedSlots)
                        {
                            if (slotsWithContents.Contains(slot.Name))
                            {
                                selectedSlotsWithContents.Add(slot);
                                sb2.Append(slot.Name + "\n");
                            }
                            sb1.Append(slot.Name + "\n");
                        }

                        if (selectedSlotsWithContents.Count > 0)
                        {
                            DialogResult result = MessageBox.Show("The following slots have contents:\n\n" + sb2.ToString() +
                                                                  "\nDo you want to insert all the contents into the new combined slot?\n\nSelecting No will delete all the contents and create a new empty slot.\n\n",
                                                                  "Combine Slots", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

                            if (result == DialogResult.Yes)
                            {
                                CombineSlots(selectedSlots, CombineOptions.CombineContents);
                            }
                            else if (result == DialogResult.No)
                            {
                                CombineSlots(selectedSlots, CombineOptions.DeleteContents);
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure you want to combine the following slots?\n\n" + sb1.ToString(), "Combine Slots", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                CombineSlots(selectedSlots, CombineOptions.CombineEmpty);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("This is an invalid selection. Select slots that will create a rectangle or a square.", "Combine Slots", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The selection already contains a combined slot", "Combine Slots", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("More than one slot must be selected to combine", "Combine Slots", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ClearSlot(object sender, EventArgs e)
        {
            List<Label> slots = new List<Label>();
            slots = GetAllSelectedSlots();

            if (slots.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to clear all the contents from the selected slots?", "Clear Slot", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        DBConnector db = new DBConnector();

                        foreach (Label slot in slots)
                        {
                            db.OpenBox(Module.CurrentBoxFile);
                            db.SQLCommand("DELETE * FROM " + slot.Name);
                            db.CloseBox();
                        }

                        RetainFilter();
                        FormatSlots();
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

        private void Slot_LeftClick(object sender, EventArgs e)
        {
            Label slot = sender as Label;
            slot.Focus();

            MouseEventArgs me = (MouseEventArgs)e;

            if (me.Button == MouseButtons.Left)
            {
                if (ModifierKeys.HasFlag(Keys.Control))
                {
                    if (sender is Label)
                    {
                        slot.BackColor = ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.SlotSelectedColor));
                    }
                }
                else if (ModifierKeys.HasFlag(Keys.Shift))
                {
                    Slot secondSelectedSlot = new Slot();
                    secondSelectedSlot.Name = slot.Name;
                    secondSelectedSlot.Row = slot.Name[0];
                    secondSelectedSlot.Column = int.Parse(slot.Name.Substring(slot.Name.LastIndexOf(secondSelectedSlot.Row) + 1));

                    // Left to Right, moving up
                    if (secondSelectedSlot.Row <= firstSelectedSlot.Row && secondSelectedSlot.Column >= firstSelectedSlot.Column)
                    {
                        // Select all the slots in between
                        foreach (Label label in slots)
                        {
                            Slot testSlot = new Slot();
                            testSlot.Name = label.Name;
                            testSlot.Row = label.Name[0];
                            testSlot.Column = int.Parse(label.Name.Substring(label.Name.LastIndexOf(testSlot.Row) + 1));

                            if (testSlot.Row <= firstSelectedSlot.Row &&
                                testSlot.Row >= secondSelectedSlot.Row &&
                                testSlot.Column >= firstSelectedSlot.Column &&
                                testSlot.Column <= secondSelectedSlot.Column)
                            {
                                label.BackColor = ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.SlotSelectedColor));
                            }
                        }
                    }

                    // Left to Right, moving down
                    if (secondSelectedSlot.Row >= firstSelectedSlot.Row && secondSelectedSlot.Column >= firstSelectedSlot.Column)
                    {
                        // Select all the slots in between
                        foreach (Label label in slots)
                        {
                            Slot testSlot = new Slot();
                            testSlot.Name = label.Name;
                            testSlot.Row = label.Name[0];
                            testSlot.Column = int.Parse(label.Name.Substring(label.Name.LastIndexOf(testSlot.Row) + 1));

                            if (testSlot.Row >= firstSelectedSlot.Row &&
                                testSlot.Row <= secondSelectedSlot.Row &&
                                testSlot.Column >= firstSelectedSlot.Column &&
                                testSlot.Column <= secondSelectedSlot.Column)
                            {
                                label.BackColor = ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.SlotSelectedColor));
                            }
                        }
                    }

                    // Right to Left, moving up
                    if (secondSelectedSlot.Row <= firstSelectedSlot.Row && secondSelectedSlot.Column <= firstSelectedSlot.Column)
                    {
                        // Select all the slots in between
                        foreach (Label label in slots)
                        {
                            Slot testSlot = new Slot();
                            testSlot.Name = label.Name;
                            testSlot.Row = label.Name[0];
                            testSlot.Column = int.Parse(label.Name.Substring(label.Name.LastIndexOf(testSlot.Row) + 1));

                            if (testSlot.Row <= firstSelectedSlot.Row &&
                                testSlot.Row >= secondSelectedSlot.Row &&
                                testSlot.Column <= firstSelectedSlot.Column &&
                                testSlot.Column >= secondSelectedSlot.Column)
                            {
                                label.BackColor = ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.SlotSelectedColor));
                            }
                        }
                    }

                    // Right to Left, moving down
                    if (secondSelectedSlot.Row >= firstSelectedSlot.Row && secondSelectedSlot.Column <= firstSelectedSlot.Column)
                    {
                        // Select all the slots in between
                        foreach (Label label in slots)
                        {
                            Slot testSlot = new Slot();
                            testSlot.Name = label.Name;
                            testSlot.Row = label.Name[0];
                            testSlot.Column = int.Parse(label.Name.Substring(label.Name.LastIndexOf(testSlot.Row) + 1));

                            if (testSlot.Row >= firstSelectedSlot.Row &&
                                testSlot.Row <= secondSelectedSlot.Row &&
                                testSlot.Column <= firstSelectedSlot.Column &&
                                testSlot.Column >= secondSelectedSlot.Column)
                            {
                                label.BackColor = ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.SlotSelectedColor));
                            }
                        }
                    }
                }
                else
                {
                    FormatSlots();
                    slot.BackColor = ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.SlotSelectedColor));

                    firstSelectedSlot.Name = slot.Name;
                    firstSelectedSlot.Row = slot.Name[0];
                    firstSelectedSlot.Column = int.Parse(slot.Name.Substring(slot.Name.LastIndexOf(firstSelectedSlot.Row) + 1));
                }
            }
        }

        private void Slot_LeftDoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;

            if (me.Button == MouseButtons.Left)
            {
                Label slot = sender as Label;

                frmSlot new_frmSlot = new frmSlot();
                new_frmSlot.caller_frmBox = this;
                new_frmSlot.currentSlot = slot.Name;
                new_frmSlot.Text = "Slot " + slot.Name;
                new_frmSlot.ShowDialog();
            }
        }

        private void Slot_Enter(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                Label slot = sender as Label;

                if (ModifierKeys.HasFlag(Keys.Control) && ModifierKeys.HasFlag(Keys.Shift))
                {
                    prevColor = slot.BackColor;
                    slot.BackColor = ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.SlotSelectedColor));
                }
                else
                {
                    prevColor = slot.BackColor;
                    slot.BackColor = ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.SlotHoverColor));
                }
            }
        }

        private void Slot_Leave(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                Label slot = sender as Label;

                if (slot.BackColor == ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.SlotSelectedColor)))
                {
                    return;
                }
                else
                {
                    slot.BackColor = prevColor;
                }
            }
        }

        private void AddItem(object sender, EventArgs e)
        {
            if (MultipleSlotsSelected())
            {
                frmSlotItem new_frmItem = new frmSlotItem();
                new_frmItem.Text = "Add Item(s)";
                new_frmItem.ckbIsHazardous.Checked = false;
                new_frmItem.txtHazardType.Text = string.Empty;
                new_frmItem.txtAttachment.Text = string.Empty;

                if (new_frmItem.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        SlotItem item = new SlotItem();
                        item.Name = new_frmItem.txtName.Text;
                        item.StoredDate = new_frmItem.dtpDate.Value.Date;
                        item.Material = new_frmItem.txtMaterial.Text;
                        item.Description = new_frmItem.txtDescription.Text;
                        item.Rtf = new_frmItem.txtDescription.Rtf;
                        item.IsHazardous = new_frmItem.ckbIsHazardous.Checked;
                        item.HazardType = new_frmItem.txtHazardType.Text;
                        item.Attachment = new_frmItem.txtAttachment.Text;

                        List<Label> slots = new List<Label>();
                        slots = GetAllSelectedSlots();

                        string currentBox = System.IO.Path.GetFileNameWithoutExtension(Module.CurrentBoxFile);
                        DBConnector db = new DBConnector();

                        if (new_frmItem.txtAttachment.Text != string.Empty)
                        {
                            File.Copy(Module.SlotAttachmentFileToCopy, Module.SetSlotAttachmentFile(Module.CurrentLocation, Module.CurrentRack, currentBox, item.Attachment));
                        }

                        foreach (Label slot in slots)
                        {
                            db.OpenBox(Module.CurrentBoxFile);
                            db.SQLCommand("insert into " + slot.Name +
                                                    " (Slot,Name,SlotDate,Material,Description,Rtf,IsHazardous,HazardType,Attachment)" +
                                                    " values('" + slot.Name + "','" + item.Name + "','" + item.StoredDate + "','" + item.Material + "','" + item.Description + "','" + item.Rtf + "','" + item.IsHazardous + "','" + item.HazardType + "','" + item.Attachment + "')");
                            db.CloseBox();
                        }

                        RetainFilter();
                        FormatSlots();

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
            else
            {
                MessageBox.Show("There are no slots selected to add items", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void EditItem(object sender, EventArgs e)
        {
            if (dgvAllContents.SelectedRows.Count != 0)
            {
                if (dgvAllContents.SelectedRows.Count == 1)
                {
                    frmSlotItem new_frmItem = new frmSlotItem();

                    int id = 0;
                    DateTime old_date;
                    string slot = string.Empty;

                    foreach (DataGridViewRow row in dgvAllContents.SelectedRows)
                    {
                        id = Convert.ToInt32(dgvAllContents.CurrentRow.Cells["ID"].Value);
                        slot = dgvAllContents.CurrentRow.Cells["Slot"].Value.ToString();
                        old_date = Convert.ToDateTime(dgvAllContents.CurrentRow.Cells["SlotDate"].Value);
                        string old_material = dgvAllContents.CurrentRow.Cells["Material"].Value.ToString();
                        string old_name = dgvAllContents.CurrentRow.Cells["Name"].Value.ToString();
                        string old_description = dgvAllContents.CurrentRow.Cells["Description"].Value.ToString();
                        string old_rtf = dgvAllContents.CurrentRow.Cells["Rtf"].Value.ToString();
                        bool old_isHazardous = bool.Parse(dgvAllContents.CurrentRow.Cells["IsHazardous"].Value.ToString());
                        string old_hazardType = dgvAllContents.CurrentRow.Cells["HazardType"].Value.ToString();
                        string old_attachment = dgvAllContents.CurrentRow.Cells["Attachment"].Value.ToString();

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

                    new_frmItem.Text = "Edit Item in " + slot;

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

                                string currentBox = System.IO.Path.GetFileNameWithoutExtension(Module.CurrentBoxFile);

                                string slotAttachmentFile = Module.SetSlotAttachmentFile(Module.CurrentLocation, Module.CurrentRack, currentBox, item.Attachment);

                                if (!File.Exists(slotAttachmentFile) && item.Attachment != string.Empty)
                                {
                                    File.Copy(Module.SlotAttachmentFileToCopy, Module.SetSlotAttachmentFile(Module.CurrentLocation, Module.CurrentRack, currentBox, item.Attachment));
                                }

                                DBConnector db = new DBConnector();
                                db.OpenBox(Module.CurrentBoxFile);
                                db.SQLCommand("update " + slot +
                                                      " set Name = '" + item.Name + "', " +
                                                           "SlotDate = '" + item.StoredDate + "'," +
                                                           "Material = '" + item.Material + "'," +
                                                           "Description = '" + item.Description + "'," +
                                                           "Rtf = '" + item.Rtf + "'," +
                                                           "IsHazardous = '" + item.IsHazardous + "'," +
                                                           "HazardType = '" + item.HazardType + "'," +
                                                           "Attachment = '" + item.Attachment + "' " +
                                                           "where ID = " + id + "");

                                db.CloseBox();
                                RetainFilter();
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
            if (dgvAllContents.SelectedRows.Count != 0)
            {
                if (MessageBox.Show("Are you sure you want to delete the selected item(s)?", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        foreach (DataGridViewRow row in dgvAllContents.SelectedRows)
                        {
                            DBConnector db = new DBConnector();
                            int id = Convert.ToInt32(row.Cells["ID"].Value);
                            string slot = row.Cells["Slot"].Value.ToString();

                            db.OpenBox(Module.CurrentBoxFile);
                            db.SQLCommand("DELETE FROM " + slot + "  WHERE ID = " + id + "");
                            db.CloseBox();
                        }

                        RetainFilter();
                        FormatSlots();
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

        private void ArchiveItem(object sender, EventArgs e)
        {
            if (dgvAllContents.SelectedRows.Count != 0)
            {
                if (MessageBox.Show("Are you sure you want to archive the selected item(s)?", "Archive Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        foreach (DataGridViewRow row in dgvAllContents.SelectedRows)
                        {
                            DBConnector db = new DBConnector();

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
                                                    " VALUES('" + slot + "','" + name + "','" + date + "','" + archiveDate + "','" + material + "','" + description + "','" + rtf + "','" + isHazardous + "','" + hazardType + "','" + attachment + "')");


                            // Delete from current slot after inserting into tblArchive
                            db.SQLCommand("DELETE FROM " + slot + "  WHERE ID = " + id + "");
                            db.CloseBox();
                        }

                        RetainFilter();
                        FormatSlots();
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

        private void ViewArchive(object sender, EventArgs e)
        {
            frmArchive new_frmArchive = new frmArchive();
            new_frmArchive.caller_frmBox = this;
            new_frmArchive.ShowDialog();
        }

        private void ViewSlotAttachment(object sender, EventArgs e)
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

            if (dgvAllContents.SelectedRows.Count != 0)
            {
                if (MessageBox.Show("Are you sure you want to remove the attachment from the selected items?", "Remove Attachment", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        // Remove all the files from the selected items in the database
                        foreach (DataGridViewRow row in dgvAllContents.SelectedRows)
                        {
                            selectedSlot = row.Cells["Slot"].Value.ToString();
                            int id = Convert.ToInt32(row.Cells["ID"].Value);
                            string currentBox = Path.GetFileNameWithoutExtension(Module.CurrentBoxFile);

                            DBConnector db = new DBConnector();
                            db.OpenBox(Module.SetBoxFile(Module.CurrentLocation, Module.CurrentRack, currentBox));
                            db.SQLCommand("update " + selectedSlot + " set Attachment = '' where id = " + id);

                            db.CloseBox();
                        }

                        RetainFilter();

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void Slot_Hover(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                Label slot = sender as Label;
                List<string> nameList = new List<string>();

                toolTip1.AutoPopDelay = 5000;
                toolTip1.InitialDelay = 200;
                toolTip1.ReshowDelay = 500;
                toolTip1.ShowAlways = true;

                DBConnector db = new DBConnector();
                db.OpenBox(Module.CurrentBoxFile);
                db.SQLFillList("select * from " + slot.Name, nameList, "Name");
                db.CloseBox();

                StringBuilder sb = new StringBuilder();

                foreach (string name in nameList.Distinct().ToList())
                {
                    sb.Append(name + "\n");
                }

                if (sb.Length != 0)
                {
                    toolTip1.SetToolTip(slot, sb.ToString());
                }
                else
                {
                    toolTip1.SetToolTip(slot, "No items");
                }
            }
        }

        private void frmBox_Load(object sender, EventArgs e)
        {
            try
            {
                CreateBox();

                Module.LoadAllBoxContents(dgvAllContents);
                FormatSlots();
                UpdateBoxInformation();

                if (bool.Parse(Module.GetSettingsValue(Module.CryoTrackerSettings.SearchAsYouType)))
                {
                    btnFilter.Visible = false;
                }
                else
                {
                    btnFilter.Visible = true;
                }
            }
            catch (Exception ex)
            {
                frmErrorReport errorReport = new frmErrorReport();
                errorReport.txtError.Text = ex.ToString();
                errorReport.ShowDialog();
            }
        }

        private void frmBox_Shown(object sender, EventArgs e)
        {
            dgvAllContents.ClearSelection();
        }

        private void Slot_RightClick(object sender, MouseEventArgs e)
        {
            Label slot = sender as Label;

            if (e.Button == MouseButtons.Right)
            {
                ContextMenu contextMenu = new ContextMenu();
                contextMenu = SlotContextMenu();
                contextMenu.Show(slot, new System.Drawing.Point(e.X, e.Y));
            }
        }

        private void TableContents_RightClick(object sender, MouseEventArgs e)
        {
            if (dgvAllContents.Rows.Count != 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    ContextMenu contextMenu = new ContextMenu();
                    contextMenu = TableContextMenu();
                    contextMenu.Show(dgvAllContents, new System.Drawing.Point(e.X, e.Y));
                }
            }
        }

        private void frmBox_Paint(object sender, PaintEventArgs e)
        {
            Module.SetFormColors(this);

            Color borderColor = ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.AppBorderColor));

            Rectangle rect1 = new Rectangle(dgvAllContents.Location.X, dgvAllContents.Location.Y, dgvAllContents.ClientSize.Width, dgvAllContents.ClientSize.Height);
            rect1.Inflate(1, 1);
            ControlPaint.DrawBorder(e.Graphics, rect1, borderColor, ButtonBorderStyle.Solid);

            Rectangle rect11 = new Rectangle(dgvAllContents.Location.X, dgvAllContents.Location.Y, dgvAllContents.ClientSize.Width, dgvAllContents.ClientSize.Height);
            rect11.Inflate(3, 3);
            ControlPaint.DrawBorder(e.Graphics, rect11, borderColor, ButtonBorderStyle.Solid);

            Rectangle rect2 = new Rectangle(pnlBox.Location.X, pnlBox.Location.Y, pnlBox.ClientSize.Width, pnlBox.ClientSize.Height);
            rect2.Inflate(1, 1);
            ControlPaint.DrawBorder(e.Graphics, rect2, borderColor, ButtonBorderStyle.Solid);

            Rectangle rect22 = new Rectangle(pnlBox.Location.X, pnlBox.Location.Y, pnlBox.ClientSize.Width, pnlBox.ClientSize.Height);
            rect22.Inflate(3, 3);
            ControlPaint.DrawBorder(e.Graphics, rect22, borderColor, ButtonBorderStyle.Solid);

            Rectangle rect3 = new Rectangle(dgvBoxInfo.Location.X, dgvBoxInfo.Location.Y, dgvBoxInfo.ClientSize.Width, dgvBoxInfo.ClientSize.Height);
            rect3.Inflate(1, 1);
            ControlPaint.DrawBorder(e.Graphics, rect3, borderColor, ButtonBorderStyle.Solid);

            Rectangle rect33 = new Rectangle(dgvBoxInfo.Location.X, dgvBoxInfo.Location.Y, dgvBoxInfo.ClientSize.Width, dgvBoxInfo.ClientSize.Height);
            rect33.Inflate(3, 3);
            ControlPaint.DrawBorder(e.Graphics, rect33, borderColor, ButtonBorderStyle.Solid);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                Filter();
            }
            catch (Exception ex)
            {
                frmErrorReport errorReport = new frmErrorReport();
                errorReport.txtError.Text = ex.ToString();
                errorReport.ShowDialog();
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFilter();
            }
            catch (Exception ex)
            {
                frmErrorReport errorReport = new frmErrorReport();
                errorReport.txtError.Text = ex.ToString();
                errorReport.ShowDialog();
            }
        }

        private void frmBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (bool.Parse(Module.GetSettingsValue(Module.CryoTrackerSettings.SearchAsYouType)))
            {
                if (txtFilter.Focused)
                {
                    timerInterval = 0;
                    timer1.Start();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerInterval += 1;

            if (timerInterval == 25)
            {
                if (txtFilter.Text != string.Empty && txtFilter.Text != "Enter search criteria...")
                {
                    if (tempSlotsWithContents.Count == 0)
                    {
                        tempSlotsWithContents = SlotsWithContents();
                    }

                    try
                    {
                        Filter();
                        timer1.Stop();
                        contentsIsBeingFiltered = true;
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
                    try
                    {
                        tempSlotsWithContents.Clear();
                        timer1.Stop();
                        Module.LoadAllBoxContents(dgvAllContents);
                        contentsIsBeingFiltered = false;
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

        private void DgvAllContents_MouseDown(object sender, MouseEventArgs e)
        {
            if (!contentsIsBeingFiltered)
            {
                if (e.Button == MouseButtons.Left && ModifierKeys == Keys.Control)
                {
                    if (e.Clicks == 1)
                    {
                        DataTable table = new DataTable();

                        foreach (DataGridViewColumn column in dgvAllContents.Columns)
                        {
                            DataColumn col = new DataColumn();
                            col.ColumnName = column.Name;

                            table.Columns.Add(col);
                        }

                        foreach (DataGridViewRow row in dgvAllContents.SelectedRows)
                        {
                            DataRow dRow = table.NewRow();

                            foreach (DataGridViewColumn col in dgvAllContents.Columns)
                            {
                                dRow[col.Name] = row.Cells[col.Name].Value.ToString();
                            }

                            table.Rows.Add(dRow);
                        }

                        dgvAllContents.DoDragDrop(table, DragDropEffects.Move);
                    }
                }
            }
        }

        private void Slot_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void Slot_DragDrop(object sender, DragEventArgs e)
        {
            string newSlot = string.Empty;
            string oldSlot = string.Empty;

            if (sender is Label)
            {
                Label slot = sender as Label;
                newSlot = slot.Name;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to transfer the selected items to " + newSlot + "?" +
                                "\n\nSelect Yes if you want to transfer the items. Select No if you want to make copies of the items into " + newSlot + ".",
                                "Transfer Item(s)", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

            if (result == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    if (e.Data.GetDataPresent(typeof(DataTable)))
                    {
                        DataTable table = (DataTable)e.Data.GetData(typeof(DataTable));

                        DBConnector db = new DBConnector();

                        foreach (DataRow row in table.Rows)
                        {
                            SlotItem item = new SlotItem();
                            item.ID = Convert.ToInt32(row["ID"]);
                            oldSlot = Convert.ToString(row["Slot"]);
                            item.Slot = newSlot;
                            item.Name = Convert.ToString(row["Name"]);
                            item.StoredDate = Convert.ToDateTime(row["SlotDate"]);
                            item.Material = Convert.ToString(row["Material"]);
                            item.Description = Convert.ToString(row["Description"]);
                            item.Rtf = Convert.ToString(row["Rtf"]);
                            item.IsHazardous = Convert.ToBoolean(row["IsHazardous"]);
                            item.HazardType = Convert.ToString(row["HazardType"]);
                            item.Attachment = Convert.ToString(row["Attachment"]);

                            db.OpenBox(Module.CurrentBoxFile);
                            db.SQLCommand("insert into " + item.Slot +
                                                    " (Slot,Name,SlotDate,Material,Description,Rtf,IsHazardous,HazardType,Attachment)" +
                                                    " values('" + item.Slot + "','" + item.Name + "','" + item.StoredDate + "','" + item.Material + "','" + item.Description + "','" + item.Rtf + "','" + item.IsHazardous + "','" + item.HazardType + "','" + item.Attachment + "')");

                            db.SQLCommand("DELETE FROM " + oldSlot + "  WHERE ID = " + item.ID + "");
                            db.CloseBox();
                        }

                        RetainFilter();
                        FormatSlots();

                        uint X = (uint)Cursor.Position.X;
                        uint Y = (uint)Cursor.Position.Y;
                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);

                        this.Cursor = Cursors.Default;
                    }
                }
                catch (Exception ex)
                {
                    frmErrorReport errorReport = new frmErrorReport();
                    errorReport.txtError.Text = ex.ToString();
                    errorReport.ShowDialog();
                }
            }
            else if (result == DialogResult.No)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    if (e.Data.GetDataPresent(typeof(DataTable)))
                    {
                        DataTable table = (DataTable)e.Data.GetData(typeof(DataTable));

                        DBConnector db = new DBConnector();

                        foreach (DataRow row in table.Rows)
                        {
                            SlotItem item = new SlotItem();
                            item.ID = Convert.ToInt32(row["ID"]);
                            oldSlot = Convert.ToString(row["Slot"]);
                            item.Slot = newSlot;
                            item.Name = Convert.ToString(row["Name"]);
                            item.StoredDate = Convert.ToDateTime(row["SlotDate"]);
                            item.Material = Convert.ToString(row["Material"]);
                            item.Description = Convert.ToString(row["Description"]);
                            item.Rtf = Convert.ToString(row["Rtf"]);
                            item.IsHazardous = Convert.ToBoolean(row["IsHazardous"]);
                            item.HazardType = Convert.ToString(row["HazardType"]);
                            item.Attachment = Convert.ToString(row["Attachment"]);

                            db.OpenBox(Module.CurrentBoxFile);
                            db.SQLCommand("insert into " + item.Slot +
                                                    " (Slot,Name,SlotDate,Material,Description,Rtf,IsHazardous,HazardType,Attachment)" +
                                                    " values('" + item.Slot + "','" + item.Name + "','" + item.StoredDate + "','" + item.Material + "','" + item.Description + "','" + item.Rtf + "','" + item.IsHazardous + "','" + item.HazardType + "','" + item.Attachment + "')");

                            db.CloseBox();
                        }

                        RetainFilter();
                        FormatSlots();

                        uint X = (uint)Cursor.Position.X;
                        uint Y = (uint)Cursor.Position.Y;
                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);

                        this.Cursor = Cursors.Default;
                    }
                }
                catch (Exception ex)
                {
                    frmErrorReport errorReport = new frmErrorReport();
                    errorReport.txtError.Text = ex.ToString();
                    errorReport.ShowDialog();
                }
            }
        }

        private void TxtFilter_Enter(object sender, EventArgs e)
        {
            if (txtFilter.Text == "Enter search criteria...")
            {
                txtFilter.Text = string.Empty;
                txtFilter.Font = new Font(txtFilter.Font, FontStyle.Regular);
                txtFilter.ForeColor = Color.Black;
            }
        }

        private void TxtFilter_Leave(object sender, EventArgs e)
        {
            if (txtFilter.Text.Length == 0)
            {
                txtFilter.Font = new Font(txtFilter.Font, FontStyle.Italic);
                txtFilter.ForeColor = Color.DimGray;
                txtFilter.Text = "Enter search criteria...";
            }
        }

        #endregion

        #region Functions

        private bool CombinedSlotIsSelected(List<Label> slots)
        {
            bool result = false;

            string boxSize = Module.GetBoxSettingsValue(Module.CurrentLocation, Module.CurrentRack, Path.GetFileNameWithoutExtension(Module.CurrentBoxFile), "BoxSize");
            int testWidth = 0;

            switch (boxSize)
            {
                case "Empty Box":
                    testWidth = 450;
                    break;
                case "2x2":
                    testWidth = 225;
                    break;
                case "3x3":
                    testWidth = 150;
                    break;
                case "4x4":
                    testWidth = 112;
                    break;
                case "5x5":
                    testWidth = 90;
                    break;
                case "6x6":
                    testWidth = 75;
                    break;
                case "7x7":
                    testWidth = 64;
                    break;
                case "8x8":
                    testWidth = 56;
                    break;
                case "9x9":
                    testWidth = 50;
                    break;
                case "10x10":
                    testWidth = 45;
                    break;
                default:
                    break;
            }

            foreach (Label slot in slots)
            {
                if (slot.Width > testWidth || slot.Height > testWidth)
                {
                    result = true;
                    return result;
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }

        private string DetermineCombinedSlotName(List<Label> slots)
        {
            string result = string.Empty;
            List<char> rows = new List<char>();
            List<int> columns = new List<int>();

            foreach (Label lbl in slots)
            {
                string name = lbl.Text;
                rows.Add(name[0]);
                columns.Add(Convert.ToInt32(name.Remove(0, 1)));
            }

            char minRow = rows.Min();
            int minCol = columns.Min();

            result = minRow + minCol.ToString();

            return result;
        }

        private List<string> SlotsWithContents()
        {
            List<string> list = new List<string>();

            foreach (DataGridViewRow row in dgvAllContents.Rows)
            {
                string slot = string.Empty;
                slot = row.Cells["Slot"].Value.ToString();

                if (!list.Contains(slot))
                {
                    list.Add(slot);
                }
            }

            return list;
        }

        private bool SequencesMatch(List<char[]> charList)
        {
            foreach (char[] rows1 in charList)
            {
                foreach (char[] rows2 in charList)
                {
                    if (!rows1.SequenceEqual(rows2))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool ColumnsAreSequential(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] != array[i - 1] + 1)
                {
                    return false;
                }
            }

            return true;
        }

        private bool RowsAreSequential(char[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] != array[i - 1] + 1)
                {
                    return false;
                }
            }

            return true;
        }

        private bool SelectedSlotsAreValid()
        {
            List<Label> slots = new List<Label>();
            slots = GetAllSelectedSlots();

            List<Slot> lstSlots = new List<Slot>();

            // Fills a list of clsSlot so we have access to easily accessible information about the slot
            foreach (Label item in slots)
            {
                Slot slot = new Slot();
                slot.Name = item.Name;
                slot.Row = item.Name[0];
                slot.Column = int.Parse(slot.Name.Substring(slot.Name.LastIndexOf(slot.Row) + 1));
                lstSlots.Add(slot);
            }

            List<int> columns = new List<int>();

            // Get all the selected columns
            foreach (Slot slot in lstSlots)
            {
                int col = 0;
                col = slot.Column;

                if (!columns.Contains(col))
                {
                    columns.Add(col);
                }
            }

            List<char> rows = new List<char>();

            // Get all the selected rows
            foreach (Slot slot in lstSlots)
            {
                char row;
                row = slot.Row;

                if (!rows.Contains(row))
                {
                    rows.Add(row);
                }
            }

            rows.Sort();
            columns.Sort();

            bool slotsAreInTheSameRow = rows.All(x => x == rows.First());
            bool slotsAreInTheSameColumn = columns.All(x => x == columns.First());

            if (slotsAreInTheSameRow)
            {
                return true;
            }
            else if (slotsAreInTheSameColumn)
            {
                return true;
            }
            else
            {
                int[] cols;
                cols = columns.ToArray();

                bool columnsAreSequential = ColumnsAreSequential(cols);

                if (columnsAreSequential)
                {
                    List<char[]> rowSequences = new List<char[]>();

                    foreach (int col in columns)
                    {
                        List<char> rowss = new List<char>();

                        foreach (Slot slot in lstSlots)
                        {
                            if (slot.Column == col)
                            {
                                rowss.Add(slot.Row);
                            }
                        }
                        rowss.Sort();
                        rowSequences.Add(rowss.ToArray());
                    }

                    bool rowsAreSequential = false;

                    foreach (char[] item in rowSequences)
                    {
                        rowsAreSequential = RowsAreSequential(item);

                        if (!rowsAreSequential)
                        {
                            return false;
                        }
                    }

                    bool sequencesMatch = SequencesMatch(rowSequences);

                    if (!rowsAreSequential || !sequencesMatch)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        private int GetSelectionWidth()
        {
            int width = 0;

            List<Label> selectedSlots = new List<Label>();
            selectedSlots = GetAllSelectedSlots();

            List<int> Xs = new List<int>();
            List<int> widths = new List<int>();

            int minX = 0;
            int maxX = 0;
            int selectionWidth = 0;

            foreach (Label slot in selectedSlots)
            {
                Xs.Add(slot.Location.X);
                widths.Add(slot.Width);
                selectionWidth = slot.Width;
            }

            minX = Xs.Min();
            maxX = Xs.Max() + selectionWidth;

            width = maxX - minX;

            return width;
        }

        private int GetSelectionHeight()
        {
            int height = 0;

            List<Label> selectedSlots = new List<Label>();
            selectedSlots = GetAllSelectedSlots();

            List<int> Ys = new List<int>();
            List<int> heights = new List<int>();

            int minY = 0;
            int maxY = 0;
            int selectionHeight = 0;

            foreach (Label slot in selectedSlots)
            {
                Ys.Add(slot.Location.Y);
                heights.Add(slot.Height);
                selectionHeight = slot.Height;
            }

            minY = Ys.Min();
            maxY = Ys.Max() + selectionHeight;

            height = maxY - minY;

            return height;
        }

        private List<Label> GetAllSelectedSlots()
        {
            List<Label> list = new List<Label>();
            foreach (Label item in slots)
            {
                if (item is Label)
                {
                    if (item.BackColor == ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.SlotSelectedColor)))
                    {
                        list.Add(item);
                    }
                }
            }

            return list;
        }

        private bool MultipleSlotsSelected()
        {
            bool flag = false;
            int count = 0;

            foreach (Label slot in slots)
            {
                if (slot is Label)
                {
                    if (slot.BackColor == ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.SlotSelectedColor)))
                    {
                        count++;
                    }
                }
            }

            if (count >= 1)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }

        private ContextMenu TableContextMenu()
        {
            ContextMenu mnu = new ContextMenu();
            MenuItem cxmnuOpenSlot = new MenuItem("Open Slot");
            MenuItem cxmnuEditItem = new MenuItem("Edit Item");
            MenuItem cxmnuDeleteItem = new MenuItem("Delete Item");
            MenuItem cxmnuArchiveItem = new MenuItem("Archive Item");
            MenuItem cxmnuViewAttachment = new MenuItem("View Attachment");
            MenuItem cxmnuRemoveAttachment = new MenuItem("Remove Attachment");

            cxmnuOpenSlot.Click += new EventHandler(OpenSlot);
            cxmnuEditItem.Click += new EventHandler(EditItem);
            cxmnuDeleteItem.Click += new EventHandler(DeleteItem);
            cxmnuArchiveItem.Click += new EventHandler(ArchiveItem);
            cxmnuViewAttachment.Click += new EventHandler(ViewSlotAttachment);
            cxmnuRemoveAttachment.Click += new EventHandler(RemoveSlotAttachment);

            mnu.MenuItems.Add(cxmnuOpenSlot);
            mnu.MenuItems.Add("-");
            mnu.MenuItems.Add(cxmnuEditItem);
            mnu.MenuItems.Add(cxmnuDeleteItem);
            mnu.MenuItems.Add("-");
            mnu.MenuItems.Add(cxmnuArchiveItem);
            mnu.MenuItems.Add("-");
            mnu.MenuItems.Add(cxmnuViewAttachment);
            mnu.MenuItems.Add(cxmnuRemoveAttachment);

            return mnu;
        }

        private ContextMenu SlotContextMenu()
        {
            ContextMenu mnu = new ContextMenu();
            MenuItem cxmnuAddItem = new MenuItem("Add Item");
            MenuItem cxmnuOpenSlot = new MenuItem("Open Slot");
            MenuItem cxmnuCombineSlots = new MenuItem("Combine Slots");
            MenuItem cxmnuClearSlot = new MenuItem("Clear Slot");

            cxmnuAddItem.Click += new EventHandler(AddItem);
            cxmnuOpenSlot.Click += new EventHandler(OpenSlot);
            cxmnuCombineSlots.Click += new EventHandler(CombineSlots);
            cxmnuClearSlot.Click += new EventHandler(ClearSlot);

            mnu.MenuItems.Add(cxmnuAddItem);
            mnu.MenuItems.Add(cxmnuOpenSlot);
            mnu.MenuItems.Add(cxmnuCombineSlots);
            mnu.MenuItems.Add("-");
            mnu.MenuItems.Add(cxmnuClearSlot);

            return mnu;
        }

        #endregion

    }
}
