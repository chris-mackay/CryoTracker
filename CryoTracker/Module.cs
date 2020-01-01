//    CryoTracker is a cryo/freezer box contents tracker
//    Copyright(C) 2018-2019 Christopher Ryan Mackay

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;

namespace CryoTracker
{
    public static class Module
    {
        public static string ToHexValue(Color _Color)
        {
            return "#" + _Color.R.ToString("X2") +
                         _Color.G.ToString("X2") +
                         _Color.B.ToString("X2");
        }

        public static void SetTextColorBasedOnBrightness(Color _TestColor, Label _Label)
        {
            if (_TestColor.GetBrightness() > 0.5)
            {
                _Label.ForeColor = Color.Black;
            }
            else
            {
                _Label.ForeColor = Color.White;
            }
        }

        public static void CreateCryoTrackerSettings_SetDefaults()
        {
            StringCollection cryoTrackerSettings = new StringCollection();

            string settingsFile = string.Empty;
            settingsFile = CryoTracker + "\\" + "Settings.cts";

            // General
            cryoTrackerSettings.Add("DefaultBoxSize,9x9");
            cryoTrackerSettings.Add("SearchAsYouType,True");

            // Application colors
            cryoTrackerSettings.Add("AppBackgroundColor,#ECEEF0");
            cryoTrackerSettings.Add("AppTextColor,#15428B");
            cryoTrackerSettings.Add("AppBorderColor,#729DCE");
            cryoTrackerSettings.Add("AppToolBarColor,#D3E2F4");
            cryoTrackerSettings.Add("AppGridViewCellBorderColor,#DCDCDC");
            cryoTrackerSettings.Add("AppGridViewAlternatingRowColor,#EEEEFF");
            cryoTrackerSettings.Add("AppGridViewRowSelectionColor,#0078D7");
            cryoTrackerSettings.Add("AppColorTheme,CryoTracker Default");

            // Slots colors
            cryoTrackerSettings.Add("SlotNoItemsColor,#FAF0E6");
            cryoTrackerSettings.Add("SlotHasContentsColor,#66CCFF");
            cryoTrackerSettings.Add("SlotHoverColor,#D7CFE2");
            cryoTrackerSettings.Add("SlotSelectedColor,#71EA93");

            // Grid settings
            cryoTrackerSettings.Add("ShowGridLines,True");
            cryoTrackerSettings.Add("ShowCellBorders,True");
            cryoTrackerSettings.Add("ShowRowGridLines,False");
            cryoTrackerSettings.Add("ShowColumnGridLines,False");
            cryoTrackerSettings.Add("ShowAlternatingRowColor,True");

            if (!SettingsFileExists())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter XmlWrt = XmlWriter.Create(settingsFile, settings);

                {
                    var withBlock = XmlWrt;
                    withBlock.WriteStartDocument();

                    withBlock.WriteComment("CryoTracker Settings");
                    withBlock.WriteStartElement("Settings");

                    string[] arr;

                    foreach (string setting in cryoTrackerSettings)
                    {
                        arr = setting.Split(',');

                        string settingName = arr[0];
                        string defaultValue = arr[1];

                        withBlock.WriteStartElement(settingName);
                        withBlock.WriteString(defaultValue);
                        withBlock.WriteEndElement();
                    }

                    withBlock.WriteEndDocument();
                    withBlock.Close();
                }

                XmlWrt = null;
            }
            else
            {
                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.Load(settingsFile);
                XmlElement elm = xmlDoc.DocumentElement;
                XmlNodeList lstSettings = elm.ChildNodes;
                string[] arr;
                StringCollection nodeNames = new StringCollection();

                foreach (XmlNode node in lstSettings)
                {
                    nodeNames.Add(node.Name);
                }

                foreach (string setting in cryoTrackerSettings)
                {
                    arr = setting.Split(',');

                    string settingName = arr[0];
                    string defaultValue = arr[1];

                    if (!nodeNames.Contains(settingName))
                    {
                        XmlNode newSetting = xmlDoc.CreateElement(settingName);
                        newSetting.InnerText = defaultValue;
                        xmlDoc.DocumentElement.AppendChild(newSetting);
                        xmlDoc.Save(settingsFile);
                    }
                }
            }
        }

        public sealed class CryoTrackerSettings
        {
            // General
            public const string DefaultBoxSize = "//Settings/DefaultBoxSize";
            public const string SearchAsYouType = "//Settings/SearchAsYouType";

            // Grid settings
            public const string ShowGridLines = "//Settings/ShowGridLines";
            public const string ShowCellBorders = "//Settings/ShowCellBorders";
            public const string ShowRowGridLines = "//Settings/ShowRowGridLines";
            public const string ShowColumnGridLines = "//Settings/ShowColumnGridLines";
            public const string ShowAlternatingRowColor = "//Settings/ShowAlternatingRowColor";

            // Application colors
            public const string AppBackgroundColor = "//Settings/AppBackgroundColor";
            public const string AppTextColor = "//Settings/AppTextColor";
            public const string AppBorderColor = "//Settings/AppBorderColor";
            public const string AppToolBarColor = "//Settings/AppToolBarColor";
            public const string AppGridViewCellBorderColor = "//Settings/AppGridViewCellBorderColor";
            public const string AppGridViewAlternatingRowColor = "//Settings/AppGridViewAlternatingRowColor";
            public const string AppGridViewRowSelectionColor = "//Settings/AppGridViewRowSelectionColor";
            public const string AppColorTheme = "//Settings/AppColorTheme";

            // Slot colors
            public const string SlotNoItemsColor = "//Settings/SlotNoItemsColor";
            public const string SlotHasContentsColor = "//Settings/SlotHasContentsColor";
            public const string SlotHoverColor = "//Settings/SlotHoverColor";
            public const string SlotSelectedColor = "//Settings/SlotSelectedColor";
        }

        public static string CryoTracker = @"C:\Users\" + Environment.UserName + @"\Documents\CryoTracker";

        public static string CurrentProject = string.Empty;
        public static string CurrentLocation = string.Empty;
        public static string CurrentRack = string.Empty;
        public static string CurrentBoxFile = string.Empty;
        public static string BoxAttachmentFileToCopy = string.Empty;
        public static string BoxAttachmentNameToDelete = string.Empty;
        public static string SlotAttachmentFileToCopy = string.Empty;
        public static string SlotAttachmentNameToDelete = string.Empty;

        #region Functions

        public static string GetHexColor(System.Drawing.Color colorObj)
        {
            string hexColor = string.Empty;

            string R = colorObj.R.ToString("X");
            string G = colorObj.G.ToString("X");
            string B = colorObj.B.ToString("X");
            if (R.Length == 1)
            {
                R = 0 + R;
            }

            if (G.Length == 1)
            {
                G = 0 + G;
            }

            if (B.Length == 1)
            {
                B = 0 + B;
            }

            hexColor = "#" + R + G + B;

            return hexColor;
        }

        public static bool BoxExists(string _BoxName, string _Rack)
        {
            bool exists = false;
            List<string> boxes = new List<string>();
            boxes = Directory.GetDirectories(CryoTracker + "\\" + CurrentLocation + "\\" + _Rack).ToList();

            foreach (string box in boxes)
            {
                DirectoryInfo dInfo = new DirectoryInfo(box);

                if (dInfo.Name == _BoxName)
                {
                    exists = true;
                    return true;
                }
                else
                {
                    exists = false;
                }

            }

            return exists;
        }

        public static bool LocationExists(string _Location)
        {
            bool exists = false;

            foreach (string location in Directory.GetDirectories(CryoTracker))
            {
                DirectoryInfo dInfo = new DirectoryInfo(location);

                if (dInfo.Name == _Location)
                {
                    exists = true;
                    break;
                }
                else
                {
                    exists = false;
                }
            }

            return exists;
        }

        public static bool RackExists(string _Location, string _RackName)
        {
            bool exists = false;

            foreach (string rack in Directory.GetDirectories(SetLocation(_Location)))
            {
                DirectoryInfo dInfo = new DirectoryInfo(rack);

                if (dInfo.Name == _RackName)
                {
                    exists = true;
                    break;
                }
                else
                {
                    exists = false;
                }
            }

            return exists;
        }

        public static string GetSettingsValue(string _Field)
        {
            string file = string.Empty;
            file = CryoTracker + "\\" + "Settings.cts";

            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            XmlNode node = null;
            node = doc.SelectSingleNode(_Field);

            string value = string.Empty;

            if (node == null)
            {
                value = string.Empty;
            }
            else
            {
                value = node.InnerText;
            }

            return value;
        }

        public static string GetBoxSettingsValue(string _Location, string _Rack, string _BoxName, string _Field)
        {
            string file = string.Empty;
            file = SetBoxSettingsFile(_Location, _Rack, _BoxName);

            _Field = @"//Settings/" + _Field;

            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            XmlNode node = null;
            node = doc.SelectSingleNode(_Field);

            string value = node.InnerText;

            return value;
        }

        public static List<string> GetTables(string _ConString)
        {
            System.Data.DataTable tables;
            using (System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection(_ConString))
            {
                connection.Open();
                tables = connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            }
            System.Collections.Generic.List<string> Tables = new System.Collections.Generic.List<string>();
            for (int i = 0; i < tables.Rows.Count; i++)
            {
                Tables.Add(tables.Rows[i][2].ToString());
            }
            return Tables;
        }

        public static string SetLocation(string _Location)
        {
            string location = string.Empty;
            location = CryoTracker + "\\" + _Location;

            return location;
        }

        public static string SetRack(string _Location, string _Rack)
        {
            string rack = string.Empty;
            rack = CryoTracker + "\\" + _Location + "\\" + _Rack;

            return rack;
        }

        public static string SetBoxFile(string _Location, string _Rack, string _BoxName)
        {
            string file = string.Empty;
            file = CryoTracker + "\\" + _Location + "\\" + _Rack + "\\" + _BoxName + "\\" + _BoxName + ".box";

            return file;
        }

        public static string SetBoxDirectory(string _Location, string _Rack, string _BoxName)
        {
            string dir = string.Empty;
            dir = CryoTracker + "\\" + _Location + "\\" + _Rack + "\\" + _BoxName;

            return dir;
        }

        public static string SetBoxSettingsFile(string _Location, string _Rack, string _BoxName)
        {
            string file = string.Empty;
            file = CryoTracker + "\\" + _Location + "\\" + _Rack + "\\" + _BoxName + "\\" + _BoxName + ".bxs";

            return file;
        }

        public static string SetBoxConfigurationFile(string _Location, string _Rack, string _BoxName)
        {
            string file = string.Empty;
            file = CryoTracker + "\\" + _Location + "\\" + _Rack + "\\" + _BoxName + "\\" + _BoxName + ".bxc";

            return file;
        }

        public static string SetSlotAttachmentFile(string _Location, string _Rack, string _BoxName, string _Name)
        {
            string file = string.Empty;
            file = CryoTracker + "\\" + _Location + "\\" + _Rack + "\\" + _BoxName + "\\" + "SlotAttachments\\" + _Name;

            return file;
        }

        public static string SetBoxAttachmentFile(string _Location, string _Rack, string _BoxName, string _Name)
        {
            string file = string.Empty;
            file = CryoTracker + "\\" + _Location + "\\" + _Rack + "\\" + _BoxName + "\\" + _Name;

            return file;
        }

        public static bool SettingsFileExists()
        {
            bool flag = false;

            string settingsFile = string.Empty;
            settingsFile = CryoTracker + "\\" + "Settings.cts";

            if (File.Exists(settingsFile))
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }

        public static bool SettingExists(string _Field)
        {
            bool flag = false;
            string file = string.Empty;
            file = CryoTracker + "\\" + "Settings.cts";

            _Field = @"//Settings/" + _Field;

            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            if (doc.SelectSingleNode(_Field) == null)
            {
                flag = false;
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        public static bool AccessIsInstalled()
        {
            RegistryKey key;
            RegistryKey reader;
            bool accessIsInstalled = false;

            List<string> progList = new List<string>();

            key = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall", false);

            foreach (string subKeyName in key.GetSubKeyNames())
            {
                reader = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\" + subKeyName, false);

                if (reader.GetValueNames().Contains("DisplayName"))
                {
                    string displayName = reader.GetValue("DisplayName").ToString();

                    if (!progList.Contains(displayName))
                        progList.Add(displayName);
                }
            }

            foreach (string prog in progList)
            {
                if (prog.Contains("Access") && prog.Contains("2007"))
                {
                    accessIsInstalled = true;
                    return true;
                 
                }
                else if(prog.Contains("Access") && prog.Contains("2010"))
                {
                    accessIsInstalled = true;
                    return true;
                }
                else
                {
                    accessIsInstalled = false;
                }
            }

            return accessIsInstalled;
        }

        public static string GetSafeFilename(string filename)
        {
            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
        }

        #endregion

        #region Voids

        public static void RenameBoxFiles(string _Location, string _Rack, string _OldName, string _NewName)
        {
            List<string> files = new List<string>();
            files = Directory.GetFiles(SetBoxDirectory(_Location, _Rack, _NewName), "*").ToList();

            foreach (string file in files)
            {
                FileInfo oldFile = new FileInfo(file);
                FileInfo newFile = new FileInfo(SetBoxDirectory(_Location, _Rack, _NewName) + "\\" + _NewName + oldFile.Extension);

                File.Move(oldFile.FullName, newFile.FullName);
            }
        }

        public static void SetToolStripForeColor(ToolStrip _ToolStrip, Color _Color)
        {
            ToolStripItemCollection col = _ToolStrip.Items;

            foreach (ToolStripItem item in col)
            {
                item.ForeColor = _Color;
            }
        }

        public static void SetToolStripForeColor(ToolStrip _ToolStrip)
        {
            ToolStripItemCollection col = _ToolStrip.Items;

            foreach (ToolStripItem item in col)
            {
                item.ForeColor = ColorTranslator.FromHtml(GetSettingsValue(CryoTrackerSettings.AppTextColor));
            }
        }

        public static void SetFormColors(Form _Form)
        {
            _Form.BackColor = ColorTranslator.FromHtml(GetSettingsValue(CryoTrackerSettings.AppBackgroundColor));

            foreach (Control ctrl in _Form.Controls)
            {
                if (ctrl is DataGridView && ctrl.Name == "dgvBoxInfo")
                {
                    DataGridView dgv = ctrl as DataGridView;
                    dgv.BackgroundColor = ColorTranslator.FromHtml(GetSettingsValue(CryoTrackerSettings.AppBackgroundColor));
                }

                if (ctrl is Label || ctrl is CheckBox)
                {
                    ctrl.ForeColor = ColorTranslator.FromHtml(GetSettingsValue(CryoTrackerSettings.AppTextColor));
                }

                if (ctrl is ToolStrip)
                {
                    ctrl.BackColor = ColorTranslator.FromHtml(GetSettingsValue(CryoTrackerSettings.AppToolBarColor));

                    ToolStrip ts = ctrl as ToolStrip;
                    SetToolStripForeColor(ts);
                }
            }
        }

        public static void LoadAllBoxContents(DataGridView _DataGridView)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbConnection con = new OleDbConnection();
            DataTable dt = new DataTable();

            string dbProvider;
            string dbSource;

            con.Close();
            con.Dispose();
            OleDbConnection.ReleaseObjectPool();

            dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;";
            dbSource = "Data Source = " + Module.CurrentBoxFile;

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

            DrawingControl.SetDoubleBuffered(_DataGridView);
            DrawingControl.SuspendDrawing(_DataGridView);

            _DataGridView.DataSource = null;
            _DataGridView.DataSource = dt.DefaultView;
            FormatDataGridView(_DataGridView);

            DrawingControl.ResumeDrawing(_DataGridView);
        }

        public static void FormatDataGridView(DataGridView _DataGridView)
        {

            /*
            ID
            Slot
            Name
            SlotDate
            Material
            IsHazardous
            HazardType
            Description
            Rtf
            Attachment
            */

            _DataGridView.RowHeadersWidth = 25;

            #region ColumnWidths

            foreach (DataGridViewColumn column in _DataGridView.Columns)
            {
                if (column != null)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 100;
                }

                if (column.Name == "Slot")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 50;
                }
            }

            #endregion

            #region Visible_Header

            if (_DataGridView.Columns["ID"] != null)
            {
                _DataGridView.Columns["ID"].Visible = false;
                _DataGridView.Columns["ID"].ReadOnly = true;
            }

            if (_DataGridView.Columns["s.ID"] != null)
            {
                _DataGridView.Columns["s.ID"].Visible = false;
                _DataGridView.Columns["s.ID"].ReadOnly = true;
            }

            if (_DataGridView.Columns["i.ID"] != null)
            {
                _DataGridView.Columns["i.ID"].Visible = false;
                _DataGridView.Columns["i.ID"].ReadOnly = true;
            }

            if (_DataGridView.Columns["SlotDate"] != null)
            {
                _DataGridView.Columns["SlotDate"].HeaderText = "Date";
            }

            if (_DataGridView.Columns["Rtf"] != null)
            {
                _DataGridView.Columns["Rtf"].Visible = false;
                _DataGridView.Columns["Rtf"].ReadOnly = true;
            }

            if (_DataGridView.Columns["IsHazardous"] != null)
            {
                _DataGridView.Columns["IsHazardous"].HeaderText = "Hazardous";
            }

            if (_DataGridView.Columns["HazardType"] != null)
            {
                _DataGridView.Columns["HazardType"].HeaderText = "Hazard Type";
            }

            if (_DataGridView.Columns["i.Attachment"] != null)
            {
                _DataGridView.Columns["i.Attachment"].HeaderText = "Box File";
            }

            if (_DataGridView.Columns["s.Attachment"] != null)
            {
                _DataGridView.Columns["s.Attachment"].HeaderText = "Slot File";
            }

            if (_DataGridView.Columns["ArchiveDate"] != null)
            {
                _DataGridView.Columns["ArchiveDate"].HeaderText = "Archived";
            }

            #endregion

            // Settings file
            _DataGridView.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml(GetSettingsValue(CryoTrackerSettings.AppGridViewRowSelectionColor));
            _DataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
            _DataGridView.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml(GetSettingsValue(CryoTrackerSettings.AppGridViewAlternatingRowColor));
            _DataGridView.GridColor = ColorTranslator.FromHtml(GetSettingsValue(CryoTrackerSettings.AppGridViewCellBorderColor));

            if (!bool.Parse(GetSettingsValue(CryoTrackerSettings.ShowGridLines)))
            {
                _DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            }
            else if (bool.Parse(GetSettingsValue(CryoTrackerSettings.ShowCellBorders)))
            {
                _DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            }
            else if (bool.Parse(GetSettingsValue(CryoTrackerSettings.ShowRowGridLines)))
            {
                _DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            }
            else
            {
                _DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            }

            if (_DataGridView.Columns["Description"] != null)
            {
                _DataGridView.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            }

            _DataGridView.ClearSelection();
            _DataGridView.Update();
        }

        public static void LoadRacks(string _Location, ComboBox _ComboBox)
        {
            _ComboBox.Items.Clear();

            foreach (string rack in Directory.GetDirectories(Module.SetLocation(_Location)))
            {
                DirectoryInfo dInfo = new DirectoryInfo(rack);
                _ComboBox.Items.Add(dInfo.Name);
            }
        }

        public static void CreateRack(string _Location, string _RackName)
        {
            Directory.CreateDirectory(CryoTracker + "\\" + _Location + "\\" + _RackName);
        }

        public static void SetSettingsValue(string _Field, string _Value)
        {
            string file = string.Empty;
            file = CryoTracker + "\\" + "Settings.cts";

            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            if (doc.SelectSingleNode(_Field) == null)
            {
                _Field = _Field.Replace("//Settings/", "");
                XmlNode field = doc.CreateElement(_Field);
                field.InnerText = _Value;
                doc.DocumentElement.AppendChild(field);
                doc.Save(file);
            }
            else
            {
                XmlNode node = null;
                node = doc.SelectSingleNode(_Field);
                node.InnerText = _Value;
                doc.Save(file);
            }

        }

        public static void SetBoxSettingsValue(string _Location, string _Rack, string _BoxName, string _Field, string _Value)
        {
            string file = string.Empty;
            file = SetBoxSettingsFile(_Location, _Rack, _BoxName);

            _Field = @"//Settings/" + _Field;

            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            if (doc.SelectSingleNode(_Field) == null)
            {
                _Field = _Field.Replace("//Settings/", "");
                XmlNode field = doc.CreateElement(_Field);
                field.InnerText = _Value;
                doc.DocumentElement.AppendChild(field);
                doc.Save(file);
            }
            else
            {
                XmlNode node = null;
                node = doc.SelectSingleNode(_Field);
                node.InnerText = _Value;
                doc.Save(file);
            }

        }

        public static void CreateLocation(string _Location)
        {
            Directory.CreateDirectory(CryoTracker + "\\" + _Location);
        }

        #endregion

        public class MySystemRenderer : ToolStripSystemRenderer
        {
            protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected)
                {
                    base.OnRenderButtonBackground(e);
                }
                else
                {
                    Rectangle rc = new Rectangle(0, 0, e.Item.Width, e.Item.Height);
                    SolidBrush fillBrush = new SolidBrush(Color.FromArgb(255, 211, 84));
                    LinearGradientBrush gradBrush = new LinearGradientBrush(rc, Color.FromArgb(255, 251, 214), Color.FromArgb(255, 211, 84), LinearGradientMode.Vertical);
                    e.Graphics.FillRectangle(gradBrush, rc);
                }
            }
        }

        public static class DrawingControl
        {
            [DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr _hWnd, Int32 _wMsg, bool _wParam, Int32 _lParam);

            private const int WM_SETREDRAW = 11;

            public static void SetDoubleBuffered(Control _ctrl)
            {
                if (!SystemInformation.TerminalServerSession)
                {
                    typeof(System.Windows.Forms.Control).InvokeMember("DoubleBuffered", (System.Reflection.BindingFlags.SetProperty
                                    | (System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)), null, _ctrl, new object[] {
                            true});
                }
            }

            public static void SetDoubleBuffered_ListControls(List<Control> _ctrlList)
            {
                if (!SystemInformation.TerminalServerSession)
                {
                    foreach (System.Windows.Forms.Control ctrl in _ctrlList)
                    {
                        typeof(System.Windows.Forms.Control).InvokeMember("DoubleBuffered", (System.Reflection.BindingFlags.SetProperty
                                        | (System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)), null, ctrl, new object[] {
                                true});
                    }
                }
            }

            public static void SuspendDrawing(Control _ctrl)
            {
                SendMessage(_ctrl.Handle, WM_SETREDRAW, false, 0);
            }

            public static void SuspendDrawing_ListControls(List<Control> _ctrlList)
            {
                foreach (System.Windows.Forms.Control ctrl in _ctrlList)
                {
                    SendMessage(ctrl.Handle, WM_SETREDRAW, false, 0);
                }
            }

            public static void ResumeDrawing(Control _ctrl)
            {
                SendMessage(_ctrl.Handle, WM_SETREDRAW, true, 0);
                _ctrl.Refresh();
            }

            public static void ResumeDrawing_ListControls(List<Control> _ctrlList)
            {
                foreach (System.Windows.Forms.Control ctrl in _ctrlList)
                {
                    SendMessage(ctrl.Handle, WM_SETREDRAW, true, 0);
                    ctrl.Refresh();
                }
            }
        }
    }

}
