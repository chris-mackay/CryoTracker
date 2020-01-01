//    CryoTracker is a cryo/freezer box contents tracker
//    Copyright(C) 2018-2019 Christopher Ryan Mackay

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CryoTracker
{
    public partial class frmSettings : Form
    {
        public MainForm caller_MainForm;

        public frmSettings()
        {
            InitializeComponent();
        }

        private void Color_TextChanged(object sender, EventArgs e)
        {
            string color = string.Empty;
            TextBox txt = sender as TextBox;
            color = txt.Text;

            string txtName = string.Empty;
            txtName = txt.Name;

            try
            {
                switch (txtName)
                {
                    case "AppBackgroundColor":
                        lblAppBackgroundColor.BackColor = ColorTranslator.FromHtml(color);
                        Module.SetTextColorBasedOnBrightness(ColorTranslator.FromHtml(color), lblAppBackgroundColor);
                        break;
                    case "AppTextColor":
                        lblAppTextColor.BackColor = ColorTranslator.FromHtml(color);
                        Module.SetTextColorBasedOnBrightness(ColorTranslator.FromHtml(color), lblAppTextColor);
                        break;
                    case "AppBorderColor":
                        lblAppBorderColor.BackColor = ColorTranslator.FromHtml(color);
                        Module.SetTextColorBasedOnBrightness(ColorTranslator.FromHtml(color), lblAppBorderColor);
                        break;
                    case "AppToolBarColor":
                        lblAppToolBarColor.BackColor = ColorTranslator.FromHtml(color);
                        Module.SetTextColorBasedOnBrightness(ColorTranslator.FromHtml(color), lblAppToolBarColor);
                        break;
                    case "AppGridViewCellBorderColor":
                        lblAppGridViewCellBorderColor.BackColor = ColorTranslator.FromHtml(color);
                        Module.SetTextColorBasedOnBrightness(ColorTranslator.FromHtml(color), lblAppGridViewCellBorderColor);
                        break;
                    case "AppGridViewAlternatingRowColor":
                        lblAppGridViewAlternatingRowColor.BackColor = ColorTranslator.FromHtml(color);
                        Module.SetTextColorBasedOnBrightness(ColorTranslator.FromHtml(color), lblAppGridViewAlternatingRowColor);
                        break;
                    case "AppGridViewRowSelectionColor":
                        lblAppGridViewRowSelectionColor.BackColor = ColorTranslator.FromHtml(color);
                        Module.SetTextColorBasedOnBrightness(ColorTranslator.FromHtml(color), lblAppGridViewRowSelectionColor);
                        break;
                    case "SlotNoItemsColor":
                        lblSlotNoItemsColor.BackColor = ColorTranslator.FromHtml(color);
                        Module.SetTextColorBasedOnBrightness(ColorTranslator.FromHtml(color), lblSlotNoItemsColor);
                        break;
                    case "SlotHasContentsColor":
                        lblSlotHasContentsColor.BackColor = ColorTranslator.FromHtml(color);
                        Module.SetTextColorBasedOnBrightness(ColorTranslator.FromHtml(color), lblSlotHasContentsColor);
                        break;
                    case "SlotHoverColor":
                        lblSlotHoverColor.BackColor = ColorTranslator.FromHtml(color);
                        Module.SetTextColorBasedOnBrightness(ColorTranslator.FromHtml(color), lblSlotHoverColor);
                        break;
                    case "SlotSelectedColor":
                        lblSlotSelectedColor.BackColor = ColorTranslator.FromHtml(color);
                        Module.SetTextColorBasedOnBrightness(ColorTranslator.FromHtml(color), lblSlotSelectedColor);
                        break;

                    default:
                        break;
                }
            }
            catch (Exception)
            {
                return;
            }

            // Set test controls
            lblAppTest.BackColor = lblAppBackgroundColor.BackColor;
            lblAppTest.ForeColor = lblAppTextColor.BackColor;
            lblAppTestBorder.BackColor = lblAppBorderColor.BackColor;
            toolStrip1.BackColor = lblAppToolBarColor.BackColor;
            Module.SetToolStripForeColor(toolStrip1, lblAppTextColor.BackColor);

            FormatDataGridView(dgvColors);
            FormatDataGridView(dgvGeneral);
            tpColors.Refresh();
            tpGeneral.Refresh();

            SetThemeIfMatch();
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            string lblName = lbl.Name;

            ColorDialog clrDlg = new ColorDialog();
            clrDlg.FullOpen = true;

            Color currentColor;

            currentColor = lbl.BackColor;
            clrDlg.Color = currentColor;

            if (clrDlg.ShowDialog() == DialogResult.OK)
            {
                Color color = clrDlg.Color;
                try
                {
                    switch (lblName)
                    {
                        case "lblAppBackgroundColor":
                            lblAppBackgroundColor.BackColor = color;
                            AppBackgroundColor.Text = Module.ToHexValue(color);
                            Module.SetTextColorBasedOnBrightness(color, lblAppBackgroundColor);
                            break;
                        case "lblAppTextColor":
                            lblAppTextColor.BackColor = color;
                            AppTextColor.Text = Module.ToHexValue(color);
                            Module.SetTextColorBasedOnBrightness(color, lblAppTextColor);
                            break;
                        case "lblAppBorderColor":
                            lblAppBorderColor.BackColor = color;
                            AppBorderColor.Text = Module.ToHexValue(color);
                            Module.SetTextColorBasedOnBrightness(color, lblAppBorderColor);
                            break;
                        case "lblAppToolBarColor":
                            lblAppToolBarColor.BackColor = color;
                            AppToolBarColor.Text = Module.ToHexValue(color);
                            Module.SetTextColorBasedOnBrightness(color, lblAppToolBarColor);
                            break;
                        case "lblAppGridViewCellBorderColor":
                            lblAppGridViewCellBorderColor.BackColor = color;
                            AppGridViewCellBorderColor.Text = Module.ToHexValue(color);
                            Module.SetTextColorBasedOnBrightness(color, lblAppGridViewCellBorderColor);
                            break;
                        case "lblAppGridViewAlternatingRowColor":
                            lblAppGridViewAlternatingRowColor.BackColor = color;
                            AppGridViewAlternatingRowColor.Text = Module.ToHexValue(color);
                            Module.SetTextColorBasedOnBrightness(color, lblAppGridViewAlternatingRowColor);
                            break;
                        case "lblAppGridViewRowSelectionColor":
                            lblAppGridViewRowSelectionColor.BackColor = color;
                            AppGridViewRowSelectionColor.Text = Module.ToHexValue(color);
                            Module.SetTextColorBasedOnBrightness(color, lblAppGridViewRowSelectionColor);
                            break;
                        case "lblSlotNoItemsColor":
                            lblSlotNoItemsColor.BackColor = color;
                            SlotNoItemsColor.Text = Module.ToHexValue(color);
                            Module.SetTextColorBasedOnBrightness(color, lblSlotNoItemsColor);
                            break;
                        case "lblSlotHasContentsColor":
                            lblSlotHasContentsColor.BackColor = color;
                            SlotHasContentsColor.Text = Module.ToHexValue(color);
                            Module.SetTextColorBasedOnBrightness(color, lblSlotHasContentsColor);
                            break;
                        case "lblSlotHoverColor":
                            lblSlotHoverColor.BackColor = color;
                            SlotHoverColor.Text = Module.ToHexValue(color);
                            Module.SetTextColorBasedOnBrightness(color, lblSlotHoverColor);
                            break;
                        case "lblSlotSelectedColor":
                            lblSlotSelectedColor.BackColor = color;
                            SlotSelectedColor.Text = Module.ToHexValue(color);
                            Module.SetTextColorBasedOnBrightness(color, lblSlotSelectedColor);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    return;
                }

                // Set test controls
                lblAppTest.BackColor = lblAppBackgroundColor.BackColor;
                lblAppTest.ForeColor = lblAppTextColor.BackColor;
                lblAppTestBorder.BackColor = lblAppBorderColor.BackColor;
                toolStrip1.BackColor = lblAppToolBarColor.BackColor;
                Module.SetToolStripForeColor(toolStrip1, lblAppTextColor.BackColor);

                FormatDataGridView(dgvColors);
                FormatDataGridView(dgvGeneral);
                tpColors.Refresh();
                tpGeneral.Refresh();

                SetThemeIfMatch();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                // General
                Module.SetSettingsValue(Module.CryoTrackerSettings.ShowGridLines, cbxShowGridLines.Checked.ToString());
                Module.SetSettingsValue(Module.CryoTrackerSettings.ShowCellBorders, rbShowCellBorders.Checked.ToString());
                Module.SetSettingsValue(Module.CryoTrackerSettings.ShowRowGridLines, rbShowRowGridLines.Checked.ToString());
                Module.SetSettingsValue(Module.CryoTrackerSettings.ShowColumnGridLines, rbShowColumnGridLines.Checked.ToString());
                Module.SetSettingsValue(Module.CryoTrackerSettings.DefaultBoxSize, cbBoxSizes.SelectedItem.ToString());
                Module.SetSettingsValue(Module.CryoTrackerSettings.SearchAsYouType, cbxSearch.Checked.ToString());

                if (cbThemes.Text != "<Custom>")
                {
                    Module.SetSettingsValue(Module.CryoTrackerSettings.AppColorTheme, cbThemes.SelectedItem.ToString());
                }
                else
                {
                    Module.SetSettingsValue(Module.CryoTrackerSettings.AppColorTheme, "<Custom>");
                }

                // Colors
                foreach (Control control in tpColors.Controls)
                {
                    if (control is TextBox)
                    {
                        string setting = string.Empty;
                        setting = control.Name;

                        string value = string.Empty;
                        value = control.Text;
                        Module.SetSettingsValue("//Settings/" + setting, value);
                    }
                }

                caller_MainForm.Refresh();

                if (cbxSearch.Checked)
                {
                    caller_MainForm.btnSearch.Visible = false;
                }
                else
                {
                    caller_MainForm.btnSearch.Visible = true;
                }
            }
            catch (Exception ex)
            {
                frmErrorReport errorReport = new frmErrorReport();
                errorReport.txtError.Text = ex.ToString();
                errorReport.ShowDialog();
            }
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            try
            {
                Module.MySystemRenderer renderer = new Module.MySystemRenderer();
                toolStrip1.Renderer = renderer;

                // General
                cbxShowGridLines.Checked = bool.Parse(Module.GetSettingsValue(Module.CryoTrackerSettings.ShowGridLines));
                cbBoxSizes.SelectedIndex = cbBoxSizes.FindStringExact(Module.GetSettingsValue(Module.CryoTrackerSettings.DefaultBoxSize));
                cbxSearch.Checked = bool.Parse(Module.GetSettingsValue(Module.CryoTrackerSettings.SearchAsYouType));

                if (cbxShowGridLines.Checked)
                {
                    rbShowCellBorders.Checked = bool.Parse(Module.GetSettingsValue(Module.CryoTrackerSettings.ShowCellBorders));
                    rbShowRowGridLines.Checked = bool.Parse(Module.GetSettingsValue(Module.CryoTrackerSettings.ShowRowGridLines));
                    rbShowColumnGridLines.Checked = bool.Parse(Module.GetSettingsValue(Module.CryoTrackerSettings.ShowColumnGridLines));

                    rbShowCellBorders.Enabled = true;
                    rbShowRowGridLines.Enabled = true;
                    rbShowColumnGridLines.Enabled = true;
                }
                else
                {
                    rbShowCellBorders.Checked = false;
                    rbShowRowGridLines.Checked = false;
                    rbShowColumnGridLines.Checked = false;

                    rbShowCellBorders.Enabled = false;
                    rbShowRowGridLines.Enabled = false;
                    rbShowColumnGridLines.Enabled = false;
                }

                // Colors
                foreach (Control control in tpColors.Controls)
                {
                    if (control is TextBox)
                    {
                        string setting = string.Empty;
                        setting = control.Name;

                        control.Text = Module.GetSettingsValue("//Settings/" + control.Name);
                    }
                }

                if (Module.GetSettingsValue(Module.CryoTrackerSettings.AppColorTheme) == "<Custom>")
                {
                    cbThemes.Text = "<Custom>";
                }
                else
                {
                    cbThemes.SelectedIndex = cbThemes.FindStringExact(Module.GetSettingsValue(Module.CryoTrackerSettings.AppColorTheme));
                }

                // Application test label
                lblAppTest.BackColor = lblAppBackgroundColor.BackColor;
                lblAppTest.ForeColor = lblAppTextColor.BackColor;
                lblAppTestBorder.BackColor = lblAppBorderColor.BackColor;
                toolStrip1.BackColor = lblAppToolBarColor.BackColor;
                Module.SetToolStripForeColor(toolStrip1, lblAppTextColor.BackColor);

                // DataGridView test
                dgvColors.Rows.Add("Value", "Value", "Value");
                dgvColors.Rows.Add("Value", "Value", "Value");
                dgvColors.Rows.Add("Value", "Value", "Value");
                FormatDataGridView(dgvColors);

                dgvGeneral.Rows.Add("Value", "Value", "Value");
                dgvGeneral.Rows.Add("Value", "Value", "Value");
                dgvGeneral.Rows.Add("Value", "Value", "Value");
                FormatDataGridView(dgvGeneral);

                tpColors.Refresh();
                tpGeneral.Refresh();

                SetThemeIfMatch();
            }
            catch (Exception ex)
            {
                frmErrorReport errorReport = new frmErrorReport();
                errorReport.txtError.Text = ex.ToString();
                errorReport.ShowDialog();
            }
        }

        private void SetDefaultAppColors()
        {
            AppBackgroundColor.Text = "#ECEEF0";
            AppTextColor.Text = "#15428B";
            AppBorderColor.Text = "#729DCE";
            AppToolBarColor.Text = "#D3E2F4";

            lblAppTest.BackColor = ColorTranslator.FromHtml(AppBackgroundColor.Text);
            lblAppTest.ForeColor = ColorTranslator.FromHtml(AppTextColor.Text);
            lblAppTestBorder.BackColor = ColorTranslator.FromHtml(AppBorderColor.Text);

            SetThemeIfMatch();
        }

        private void SetDefaultDataGridViewColors()
        {
            AppGridViewCellBorderColor.Text = "#DCDCDC";
            AppGridViewAlternatingRowColor.Text = "#EEEEFF";
            AppGridViewRowSelectionColor.Text = "#0078D7";

            FormatDataGridView(dgvColors);
            FormatDataGridView(dgvGeneral);

            SetThemeIfMatch();
        }

        private void SetDefaultSlotColors()
        {
            SlotNoItemsColor.Text = "#FAF0E6";
            SlotHasContentsColor.Text = "#66CCFF";
            SlotHoverColor.Text = "#D7CFE2";
            SlotSelectedColor.Text = "#71EA93";

            SetThemeIfMatch();
        }

        private void btnAppDefault_Click(object sender, EventArgs e)
        {
            SetDefaultAppColors();
        }

        private void btnGridViewDefault_Click(object sender, EventArgs e)
        {
            SetDefaultDataGridViewColors();
        }

        private void btnSlotsDefault_Click(object sender, EventArgs e)
        {
            SetDefaultSlotColors();
        }

        private void cbxShowGridLines_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxShowGridLines.Checked)
            {
                rbShowCellBorders.Checked = true;
                rbShowRowGridLines.Checked = false;
                rbShowColumnGridLines.Checked = false;

                rbShowCellBorders.Enabled = true;
                rbShowRowGridLines.Enabled = true;
                rbShowColumnGridLines.Enabled = true;
            }
            else
            {
                rbShowCellBorders.Checked = false;
                rbShowRowGridLines.Checked = false;
                rbShowColumnGridLines.Checked = false;

                rbShowCellBorders.Enabled = false;
                rbShowRowGridLines.Enabled = false;
                rbShowColumnGridLines.Enabled = false;
            }

            FormatDataGridView(dgvColors);
            FormatDataGridView(dgvGeneral);
        }

        private void FormatDataGridView(DataGridView _DataGridView)
        {
            try
            {
                _DataGridView.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml(AppGridViewRowSelectionColor.Text);
                _DataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
                _DataGridView.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml(AppGridViewAlternatingRowColor.Text);
                _DataGridView.GridColor = ColorTranslator.FromHtml(AppGridViewCellBorderColor.Text);

                if (!cbxShowGridLines.Checked)
                {
                    _DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
                }
                else if (rbShowCellBorders.Checked)
                {
                    _DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                }
                else if (rbShowRowGridLines.Checked)
                {
                    _DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                }
                else
                {
                    _DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
                }

                _DataGridView.ClearSelection();
            }
            catch (Exception)
            {

                return;
            }
        }

        private void rbGrids_CheckedChanged(object sender, EventArgs e)
        {
            FormatDataGridView(dgvColors);
            FormatDataGridView(dgvGeneral);
        }

        private void tpColors_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect1 = new Rectangle(dgvColors.Location.X, dgvColors.Location.Y, dgvColors.ClientSize.Width, dgvColors.ClientSize.Height);
            rect1.Inflate(1, 1);
            ControlPaint.DrawBorder(e.Graphics, rect1, lblAppBorderColor.BackColor, ButtonBorderStyle.Solid);
        }

        private void tpGeneral_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect1 = new Rectangle(dgvGeneral.Location.X, dgvGeneral.Location.Y, dgvGeneral.ClientSize.Width, dgvGeneral.ClientSize.Height);
            rect1.Inflate(1, 1);
            ControlPaint.DrawBorder(e.Graphics, rect1, lblAppBorderColor.BackColor, ButtonBorderStyle.Solid);
        }

        private void SetTheme(string _SelectedTheme)
        {
            Module.DrawingControl.SetDoubleBuffered(tpColors);
            Module.DrawingControl.SuspendDrawing(tpColors);

            switch (_SelectedTheme)
            {
                case "Arctic":
                    AppBackgroundColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#FFFFFF"));
                    AppTextColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#000000"));
                    AppBorderColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#000000"));
                    AppToolBarColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#F3F3F3"));
                    AppGridViewCellBorderColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#C0C0C0"));
                    AppGridViewAlternatingRowColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#F3F3F3"));
                    AppGridViewRowSelectionColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#79BCFF"));
                    SlotNoItemsColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#FFFFFF"));
                    SlotHasContentsColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#CCE6FF"));
                    SlotHoverColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#D7CFE2"));
                    SlotSelectedColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#BFFFBF"));
                    break;
                case "Classic OS":
                    AppBackgroundColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#F0F0F0"));
                    AppTextColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#000000"));
                    AppBorderColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#396CA5"));
                    AppToolBarColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#F0F0F0"));
                    AppGridViewCellBorderColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#DCDCDC"));
                    AppGridViewAlternatingRowColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#F0F0F0"));
                    AppGridViewRowSelectionColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#77A2D0"));
                    SlotNoItemsColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#FAF0E6"));
                    SlotHasContentsColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#77A2D0"));
                    SlotHoverColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#BFBFBF"));
                    SlotSelectedColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#00CCCC"));
                    break;
                case "Soft Purple":
                    AppBackgroundColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#F5F5F5"));
                    AppTextColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#333333"));
                    AppBorderColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#705697"));
                    AppToolBarColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#D7CFE2"));
                    AppGridViewCellBorderColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#DCDCDC"));
                    AppGridViewAlternatingRowColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#EEEEFF"));
                    AppGridViewRowSelectionColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#0078D7"));
                    SlotNoItemsColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#FAF0E6"));
                    SlotHasContentsColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#9FE0FF"));
                    SlotHoverColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#D7CFE2"));
                    SlotSelectedColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#97F0AF"));
                    break;
                case "Retrobright":
                    AppBackgroundColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#FDF6E3"));
                    AppTextColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#237893"));
                    AppBorderColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#8D8464"));
                    AppToolBarColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#EEE8D5"));
                    AppGridViewCellBorderColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#8D8464"));
                    AppGridViewAlternatingRowColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#EEE8D5"));
                    AppGridViewRowSelectionColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#C0BCB0"));
                    SlotNoItemsColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#FAF0E6"));
                    SlotHasContentsColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#B0E6FF"));
                    SlotHoverColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#DDD9C1"));
                    SlotSelectedColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#9EF1B5"));
                    break;
                case "CryoTracker Default":
                    AppBackgroundColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#ECEEF0"));
                    AppTextColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#15428B"));
                    AppBorderColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#729DCE"));
                    AppToolBarColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#D3E2F4"));
                    AppGridViewCellBorderColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#DCDCDC"));
                    AppGridViewAlternatingRowColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#EEEEFF"));
                    AppGridViewRowSelectionColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#0078D7"));
                    SlotNoItemsColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#FAF0E6"));
                    SlotHasContentsColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#66CCFF"));
                    SlotHoverColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#D7CFE2"));
                    SlotSelectedColor.Text = ColorTranslator.ToHtml(ColorTranslator.FromHtml("#71EA93"));
                    break;
                default:
                    break;
            }

            Module.DrawingControl.ResumeDrawing(tpColors);
        }

        private void cbThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbThemes.Text != "<Custom>")
            {
                SetTheme(cbThemes.SelectedItem.ToString());
            }
        }

        private void SetThemeIfMatch()
        {
            Dictionary<string, Color> ctDefault = new Dictionary<string, Color>();
            ctDefault.Add("AppBackgroundColor", ColorTranslator.FromHtml("#ECEEF0"));
            ctDefault.Add("AppTextColor", ColorTranslator.FromHtml("#15428B"));
            ctDefault.Add("AppBorderColor", ColorTranslator.FromHtml("#729DCE"));
            ctDefault.Add("AppToolBarColor", ColorTranslator.FromHtml("#D3E2F4"));
            ctDefault.Add("AppGridViewCellBorderColor", ColorTranslator.FromHtml("#DCDCDC"));
            ctDefault.Add("AppGridViewAlternatingRowColor", ColorTranslator.FromHtml("#EEEEFF"));
            ctDefault.Add("AppGridViewRowSelectionColor", ColorTranslator.FromHtml("#0078D7"));
            ctDefault.Add("SlotNoItemsColor", ColorTranslator.FromHtml("#FAF0E6"));
            ctDefault.Add("SlotHasContentsColor", ColorTranslator.FromHtml("#66CCFF"));
            ctDefault.Add("SlotHoverColor", ColorTranslator.FromHtml("#D7CFE2"));
            ctDefault.Add("SlotSelectedColor", ColorTranslator.FromHtml("#71EA93"));

            Dictionary<string, Color> classicOS = new Dictionary<string, Color>();
            classicOS.Add("AppBackgroundColor", ColorTranslator.FromHtml("#F0F0F0"));
            classicOS.Add("AppTextColor", ColorTranslator.FromHtml("#000000"));
            classicOS.Add("AppBorderColor", ColorTranslator.FromHtml("#396CA5"));
            classicOS.Add("AppToolBarColor", ColorTranslator.FromHtml("#F0F0F0"));
            classicOS.Add("AppGridViewCellBorderColor", ColorTranslator.FromHtml("#DCDCDC"));
            classicOS.Add("AppGridViewAlternatingRowColor", ColorTranslator.FromHtml("#F0F0F0"));
            classicOS.Add("AppGridViewRowSelectionColor", ColorTranslator.FromHtml("#77A2D0"));
            classicOS.Add("SlotNoItemsColor", ColorTranslator.FromHtml("#FAF0E6"));
            classicOS.Add("SlotHasContentsColor", ColorTranslator.FromHtml("#77A2D0"));
            classicOS.Add("SlotHoverColor", ColorTranslator.FromHtml("#BFBFBF"));
            classicOS.Add("SlotSelectedColor", ColorTranslator.FromHtml("#00CCCC"));

            Dictionary<string, Color> arctic = new Dictionary<string, Color>();
            arctic.Add("AppBackgroundColor", ColorTranslator.FromHtml("#FFFFFF"));
            arctic.Add("AppTextColor", ColorTranslator.FromHtml("#000000"));
            arctic.Add("AppBorderColor", ColorTranslator.FromHtml("#000000"));
            arctic.Add("AppToolBarColor", ColorTranslator.FromHtml("#F3F3F3"));
            arctic.Add("AppGridViewCellBorderColor", ColorTranslator.FromHtml("#C0C0C0"));
            arctic.Add("AppGridViewAlternatingRowColor", ColorTranslator.FromHtml("#F3F3F3"));
            arctic.Add("AppGridViewRowSelectionColor", ColorTranslator.FromHtml("#79BCFF"));
            arctic.Add("SlotNoItemsColor", ColorTranslator.FromHtml("#FFFFFF"));
            arctic.Add("SlotHasContentsColor", ColorTranslator.FromHtml("#CCE6FF"));
            arctic.Add("SlotHoverColor", ColorTranslator.FromHtml("#D7CFE2"));
            arctic.Add("SlotSelectedColor", ColorTranslator.FromHtml("#BFFFBF"));

            Dictionary<string, Color> softPurple = new Dictionary<string, Color>();
            softPurple.Add("AppBackgroundColor", ColorTranslator.FromHtml("#F5F5F5"));
            softPurple.Add("AppTextColor", ColorTranslator.FromHtml("#333333"));
            softPurple.Add("AppBorderColor", ColorTranslator.FromHtml("#705697"));
            softPurple.Add("AppToolBarColor", ColorTranslator.FromHtml("#D7CFE2"));
            softPurple.Add("AppGridViewCellBorderColor", ColorTranslator.FromHtml("#DCDCDC"));
            softPurple.Add("AppGridViewAlternatingRowColor", ColorTranslator.FromHtml("#EEEEFF"));
            softPurple.Add("AppGridViewRowSelectionColor", ColorTranslator.FromHtml("#0078D7"));
            softPurple.Add("SlotNoItemsColor", ColorTranslator.FromHtml("#FAF0E6"));
            softPurple.Add("SlotHasContentsColor", ColorTranslator.FromHtml("#9FE0FF"));
            softPurple.Add("SlotHoverColor", ColorTranslator.FromHtml("#D7CFE2"));
            softPurple.Add("SlotSelectedColor", ColorTranslator.FromHtml("#97F0AF"));

            Dictionary<string, Color> retroBright = new Dictionary<string, Color>();
            retroBright.Add("AppBackgroundColor", ColorTranslator.FromHtml("#FDF6E3"));
            retroBright.Add("AppTextColor", ColorTranslator.FromHtml("#237893"));
            retroBright.Add("AppBorderColor", ColorTranslator.FromHtml("#8D8464"));
            retroBright.Add("AppToolBarColor", ColorTranslator.FromHtml("#EEE8D5"));
            retroBright.Add("AppGridViewCellBorderColor", ColorTranslator.FromHtml("#8D8464"));
            retroBright.Add("AppGridViewAlternatingRowColor", ColorTranslator.FromHtml("#EEE8D5"));
            retroBright.Add("AppGridViewRowSelectionColor", ColorTranslator.FromHtml("#C0BCB0"));
            retroBright.Add("SlotNoItemsColor", ColorTranslator.FromHtml("#FAF0E6"));
            retroBright.Add("SlotHasContentsColor", ColorTranslator.FromHtml("#B0E6FF"));
            retroBright.Add("SlotHoverColor", ColorTranslator.FromHtml("#DDD9C1"));
            retroBright.Add("SlotSelectedColor", ColorTranslator.FromHtml("#9EF1B5"));

            Dictionary<string, Color> currentColors = new Dictionary<string, Color>();

            // Check if all the current color settings match to a default theme
            foreach (Control control in tpColors.Controls)
            {
                if (control is TextBox)
                {
                    string setting = string.Empty;
                    setting = control.Name;
                    currentColors.Add(control.Name, ColorTranslator.FromHtml(control.Text));
                }
            }

            bool equalsArctic = currentColors.OrderBy(kvp => kvp.Key).SequenceEqual(arctic.OrderBy(kvp => kvp.Key));
            bool equalsDefault = currentColors.OrderBy(kvp => kvp.Key).SequenceEqual(ctDefault.OrderBy(kvp => kvp.Key));
            bool equalsClassicOS = currentColors.OrderBy(kvp => kvp.Key).SequenceEqual(classicOS.OrderBy(kvp => kvp.Key));
            bool equalsSoftPurple = currentColors.OrderBy(kvp => kvp.Key).SequenceEqual(softPurple.OrderBy(kvp => kvp.Key));
            bool equalsRetroBright = currentColors.OrderBy(kvp => kvp.Key).SequenceEqual(retroBright.OrderBy(kvp => kvp.Key));

            string themeMatch = string.Empty;

            if (equalsArctic)
            {
                themeMatch = "Arctic";
            }
            else if (equalsDefault)
            {
                themeMatch = "CryoTracker Default";
            }
            else if (equalsClassicOS)
            {
                themeMatch = "Classic OS";
            }
            else if (equalsSoftPurple)
            {
                themeMatch = "Soft Purple";
            }
            else if (equalsRetroBright)
            {
                themeMatch = "Retrobright";
            }
            else
            {
                themeMatch = string.Empty;
            }

            if (themeMatch != string.Empty)
            {
                cbThemes.SelectedIndex = cbThemes.FindStringExact(themeMatch);
            }
            else
            {
                cbThemes.Text = "<Custom>";
            }
        }
    }
}
