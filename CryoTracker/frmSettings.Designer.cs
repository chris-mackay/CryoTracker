//    CryoTracker is a cryo/freezer box contents tracker
//    Copyright(C) 2018-2019 Christopher Ryan Mackay

namespace CryoTracker
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.dgvGeneral = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbBoxSizes = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxSearch = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxShowGridLines = new System.Windows.Forms.CheckBox();
            this.rbShowColumnGridLines = new System.Windows.Forms.RadioButton();
            this.rbShowRowGridLines = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.rbShowCellBorders = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlOptions = new System.Windows.Forms.TabControl();
            this.tpColors = new System.Windows.Forms.TabPage();
            this.cbThemes = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsButton2 = new System.Windows.Forms.ToolStripButton();
            this.tsButton3 = new System.Windows.Forms.ToolStripButton();
            this.lblAppTest = new System.Windows.Forms.Label();
            this.dgvColors = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSlotsDefault = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGridViewDefault = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.AppGridViewRowSelectionColor = new System.Windows.Forms.TextBox();
            this.AppGridViewAlternatingRowColor = new System.Windows.Forms.TextBox();
            this.SlotSelectedColor = new System.Windows.Forms.TextBox();
            this.AppGridViewCellBorderColor = new System.Windows.Forms.TextBox();
            this.SlotHoverColor = new System.Windows.Forms.TextBox();
            this.AppToolBarColor = new System.Windows.Forms.TextBox();
            this.AppBorderColor = new System.Windows.Forms.TextBox();
            this.SlotHasContentsColor = new System.Windows.Forms.TextBox();
            this.AppTextColor = new System.Windows.Forms.TextBox();
            this.SlotNoItemsColor = new System.Windows.Forms.TextBox();
            this.AppBackgroundColor = new System.Windows.Forms.TextBox();
            this.lblAppGridViewRowSelectionColor = new System.Windows.Forms.Label();
            this.lblAppGridViewAlternatingRowColor = new System.Windows.Forms.Label();
            this.lblSlotSelectedColor = new System.Windows.Forms.Label();
            this.lblAppGridViewCellBorderColor = new System.Windows.Forms.Label();
            this.lblSlotHoverColor = new System.Windows.Forms.Label();
            this.lblAppTestBorder = new System.Windows.Forms.Label();
            this.lblAppToolBarColor = new System.Windows.Forms.Label();
            this.lblAppBorderColor = new System.Windows.Forms.Label();
            this.lblSlotHasContentsColor = new System.Windows.Forms.Label();
            this.lblAppTextColor = new System.Windows.Forms.Label();
            this.lblSlotNoItemsColor = new System.Windows.Forms.Label();
            this.lblAppBackgroundColor = new System.Windows.Forms.Label();
            this.lblColorThemes = new System.Windows.Forms.Label();
            this.lblSlotColors = new System.Windows.Forms.Label();
            this.lblGridViewColors = new System.Windows.Forms.Label();
            this.lblApplicationColors = new System.Windows.Forms.Label();
            this.tpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneral)).BeginInit();
            this.tabControlOptions.SuspendLayout();
            this.tpColors.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColors)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(546, 598);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(465, 598);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tpGeneral
            // 
            this.tpGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(238)))), ((int)(((byte)(240)))));
            this.tpGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpGeneral.Controls.Add(this.dgvGeneral);
            this.tpGeneral.Controls.Add(this.cbBoxSizes);
            this.tpGeneral.Controls.Add(this.label6);
            this.tpGeneral.Controls.Add(this.label5);
            this.tpGeneral.Controls.Add(this.label4);
            this.tpGeneral.Controls.Add(this.cbxSearch);
            this.tpGeneral.Controls.Add(this.label2);
            this.tpGeneral.Controls.Add(this.cbxShowGridLines);
            this.tpGeneral.Controls.Add(this.rbShowColumnGridLines);
            this.tpGeneral.Controls.Add(this.rbShowRowGridLines);
            this.tpGeneral.Controls.Add(this.label3);
            this.tpGeneral.Controls.Add(this.rbShowCellBorders);
            this.tpGeneral.Controls.Add(this.label1);
            this.tpGeneral.Location = new System.Drawing.Point(4, 27);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(603, 549);
            this.tpGeneral.TabIndex = 2;
            this.tpGeneral.Text = "General";
            this.tpGeneral.Paint += new System.Windows.Forms.PaintEventHandler(this.tpGeneral_Paint);
            // 
            // dgvGeneral
            // 
            this.dgvGeneral.AllowUserToAddRows = false;
            this.dgvGeneral.AllowUserToDeleteRows = false;
            this.dgvGeneral.AllowUserToResizeColumns = false;
            this.dgvGeneral.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvGeneral.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGeneral.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGeneral.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvGeneral.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGeneral.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGeneral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvGeneral.Enabled = false;
            this.dgvGeneral.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvGeneral.Location = new System.Drawing.Point(323, 20);
            this.dgvGeneral.MultiSelect = false;
            this.dgvGeneral.Name = "dgvGeneral";
            this.dgvGeneral.ReadOnly = true;
            this.dgvGeneral.RowHeadersVisible = false;
            this.dgvGeneral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGeneral.Size = new System.Drawing.Size(262, 86);
            this.dgvGeneral.TabIndex = 48;
            this.dgvGeneral.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Column3";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // cbBoxSizes
            // 
            this.cbBoxSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxSizes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbBoxSizes.FormattingEnabled = true;
            this.cbBoxSizes.Items.AddRange(new object[] {
            "Empty Box",
            "2x2",
            "3x3",
            "4x4",
            "5x5",
            "6x6",
            "7x7",
            "8x8",
            "9x9",
            "10x10"});
            this.cbBoxSizes.Location = new System.Drawing.Point(23, 282);
            this.cbBoxSizes.Name = "cbBoxSizes";
            this.cbBoxSizes.Size = new System.Drawing.Size(117, 23);
            this.cbBoxSizes.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(20, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(266, 45);
            this.label6.TabIndex = 9;
            this.label6.Text = "Choose the default box size when creating\r\na new box";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(20, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Box size";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(20, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(266, 45);
            this.label4.TabIndex = 6;
            this.label4.Text = "Choose whether the search or filter functions are activated by typing or clicking" +
    " a button\r\n\r\n";
            // 
            // cbxSearch
            // 
            this.cbxSearch.AutoSize = true;
            this.cbxSearch.Location = new System.Drawing.Point(23, 405);
            this.cbxSearch.Name = "cbxSearch";
            this.cbxSearch.Size = new System.Drawing.Size(155, 19);
            this.cbxSearch.TabIndex = 3;
            this.cbxSearch.Text = "Search/Filter as you type";
            this.cbxSearch.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(20, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 45);
            this.label2.TabIndex = 6;
            this.label2.Text = "Choose between three types of grid line display,\r\nor don\'t show grids at all";
            // 
            // cbxShowGridLines
            // 
            this.cbxShowGridLines.AutoSize = true;
            this.cbxShowGridLines.Location = new System.Drawing.Point(23, 91);
            this.cbxShowGridLines.Name = "cbxShowGridLines";
            this.cbxShowGridLines.Size = new System.Drawing.Size(106, 19);
            this.cbxShowGridLines.TabIndex = 3;
            this.cbxShowGridLines.Text = "Show grid lines";
            this.cbxShowGridLines.UseVisualStyleBackColor = true;
            this.cbxShowGridLines.CheckedChanged += new System.EventHandler(this.cbxShowGridLines_CheckedChanged);
            // 
            // rbShowColumnGridLines
            // 
            this.rbShowColumnGridLines.AutoSize = true;
            this.rbShowColumnGridLines.Location = new System.Drawing.Point(45, 164);
            this.rbShowColumnGridLines.Name = "rbShowColumnGridLines";
            this.rbShowColumnGridLines.Size = new System.Drawing.Size(95, 19);
            this.rbShowColumnGridLines.TabIndex = 5;
            this.rbShowColumnGridLines.TabStop = true;
            this.rbShowColumnGridLines.Text = "Column lines";
            this.rbShowColumnGridLines.UseVisualStyleBackColor = true;
            this.rbShowColumnGridLines.CheckedChanged += new System.EventHandler(this.rbGrids_CheckedChanged);
            // 
            // rbShowRowGridLines
            // 
            this.rbShowRowGridLines.AutoSize = true;
            this.rbShowRowGridLines.Location = new System.Drawing.Point(45, 139);
            this.rbShowRowGridLines.Name = "rbShowRowGridLines";
            this.rbShowRowGridLines.Size = new System.Drawing.Size(75, 19);
            this.rbShowRowGridLines.TabIndex = 5;
            this.rbShowRowGridLines.TabStop = true;
            this.rbShowRowGridLines.Text = "Row lines";
            this.rbShowRowGridLines.UseVisualStyleBackColor = true;
            this.rbShowRowGridLines.CheckedChanged += new System.EventHandler(this.rbGrids_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(20, 334);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Search/Filter as you type";
            // 
            // rbShowCellBorders
            // 
            this.rbShowCellBorders.AutoSize = true;
            this.rbShowCellBorders.Location = new System.Drawing.Point(45, 114);
            this.rbShowCellBorders.Name = "rbShowCellBorders";
            this.rbShowCellBorders.Size = new System.Drawing.Size(88, 19);
            this.rbShowCellBorders.TabIndex = 5;
            this.rbShowCellBorders.TabStop = true;
            this.rbShowCellBorders.Text = "Cell borders";
            this.rbShowCellBorders.UseVisualStyleBackColor = true;
            this.rbShowCellBorders.CheckedChanged += new System.EventHandler(this.rbGrids_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Table display";
            // 
            // tabControlOptions
            // 
            this.tabControlOptions.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControlOptions.Controls.Add(this.tpGeneral);
            this.tabControlOptions.Controls.Add(this.tpColors);
            this.tabControlOptions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlOptions.Location = new System.Drawing.Point(13, 12);
            this.tabControlOptions.Name = "tabControlOptions";
            this.tabControlOptions.SelectedIndex = 0;
            this.tabControlOptions.Size = new System.Drawing.Size(611, 580);
            this.tabControlOptions.TabIndex = 0;
            // 
            // tpColors
            // 
            this.tpColors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(238)))), ((int)(((byte)(240)))));
            this.tpColors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpColors.Controls.Add(this.cbThemes);
            this.tpColors.Controls.Add(this.toolStrip1);
            this.tpColors.Controls.Add(this.lblAppTest);
            this.tpColors.Controls.Add(this.dgvColors);
            this.tpColors.Controls.Add(this.btnSlotsDefault);
            this.tpColors.Controls.Add(this.button1);
            this.tpColors.Controls.Add(this.btnGridViewDefault);
            this.tpColors.Controls.Add(this.label12);
            this.tpColors.Controls.Add(this.AppGridViewRowSelectionColor);
            this.tpColors.Controls.Add(this.AppGridViewAlternatingRowColor);
            this.tpColors.Controls.Add(this.SlotSelectedColor);
            this.tpColors.Controls.Add(this.AppGridViewCellBorderColor);
            this.tpColors.Controls.Add(this.SlotHoverColor);
            this.tpColors.Controls.Add(this.AppToolBarColor);
            this.tpColors.Controls.Add(this.AppBorderColor);
            this.tpColors.Controls.Add(this.SlotHasContentsColor);
            this.tpColors.Controls.Add(this.AppTextColor);
            this.tpColors.Controls.Add(this.SlotNoItemsColor);
            this.tpColors.Controls.Add(this.AppBackgroundColor);
            this.tpColors.Controls.Add(this.lblAppGridViewRowSelectionColor);
            this.tpColors.Controls.Add(this.lblAppGridViewAlternatingRowColor);
            this.tpColors.Controls.Add(this.lblSlotSelectedColor);
            this.tpColors.Controls.Add(this.lblAppGridViewCellBorderColor);
            this.tpColors.Controls.Add(this.lblSlotHoverColor);
            this.tpColors.Controls.Add(this.lblAppTestBorder);
            this.tpColors.Controls.Add(this.lblAppToolBarColor);
            this.tpColors.Controls.Add(this.lblAppBorderColor);
            this.tpColors.Controls.Add(this.lblSlotHasContentsColor);
            this.tpColors.Controls.Add(this.lblAppTextColor);
            this.tpColors.Controls.Add(this.lblSlotNoItemsColor);
            this.tpColors.Controls.Add(this.lblAppBackgroundColor);
            this.tpColors.Controls.Add(this.lblColorThemes);
            this.tpColors.Controls.Add(this.lblSlotColors);
            this.tpColors.Controls.Add(this.lblGridViewColors);
            this.tpColors.Controls.Add(this.lblApplicationColors);
            this.tpColors.Location = new System.Drawing.Point(4, 27);
            this.tpColors.Name = "tpColors";
            this.tpColors.Padding = new System.Windows.Forms.Padding(3);
            this.tpColors.Size = new System.Drawing.Size(603, 549);
            this.tpColors.TabIndex = 3;
            this.tpColors.Text = "Colors";
            this.tpColors.Paint += new System.Windows.Forms.PaintEventHandler(this.tpColors_Paint);
            // 
            // cbThemes
            // 
            this.cbThemes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbThemes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbThemes.FormattingEnabled = true;
            this.cbThemes.Items.AddRange(new object[] {
            "<Custom>",
            "CryoTracker Default",
            "Arctic",
            "Classic OS",
            "Soft Purple",
            "Retrobright"});
            this.cbThemes.Location = new System.Drawing.Point(312, 268);
            this.cbThemes.Name = "cbThemes";
            this.cbThemes.Size = new System.Drawing.Size(186, 23);
            this.cbThemes.TabIndex = 49;
            this.cbThemes.TabStop = false;
            this.cbThemes.SelectedIndexChanged += new System.EventHandler(this.cbThemes_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(244)))));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButton1,
            this.tsButton2,
            this.tsButton3});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(31, 230);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(1);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(191, 31);
            this.toolStrip1.TabIndex = 48;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsButton1
            // 
            this.tsButton1.AutoToolTip = false;
            this.tsButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.tsButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton1.Margin = new System.Windows.Forms.Padding(4);
            this.tsButton1.Name = "tsButton1";
            this.tsButton1.Padding = new System.Windows.Forms.Padding(1);
            this.tsButton1.Size = new System.Drawing.Size(55, 21);
            this.tsButton1.Text = "Button1";
            // 
            // tsButton2
            // 
            this.tsButton2.AutoToolTip = false;
            this.tsButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.tsButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton2.Margin = new System.Windows.Forms.Padding(4);
            this.tsButton2.Name = "tsButton2";
            this.tsButton2.Padding = new System.Windows.Forms.Padding(1);
            this.tsButton2.Size = new System.Drawing.Size(55, 21);
            this.tsButton2.Text = "Button2";
            // 
            // tsButton3
            // 
            this.tsButton3.AutoToolTip = false;
            this.tsButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.tsButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton3.Margin = new System.Windows.Forms.Padding(4);
            this.tsButton3.Name = "tsButton3";
            this.tsButton3.Padding = new System.Windows.Forms.Padding(1);
            this.tsButton3.Size = new System.Drawing.Size(55, 21);
            this.tsButton3.Text = "Button3";
            // 
            // lblAppTest
            // 
            this.lblAppTest.BackColor = System.Drawing.Color.White;
            this.lblAppTest.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAppTest.Location = new System.Drawing.Point(33, 267);
            this.lblAppTest.Margin = new System.Windows.Forms.Padding(2);
            this.lblAppTest.Name = "lblAppTest";
            this.lblAppTest.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblAppTest.Size = new System.Drawing.Size(184, 23);
            this.lblAppTest.TabIndex = 41;
            this.lblAppTest.Text = "Sample";
            this.lblAppTest.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvColors
            // 
            this.dgvColors.AllowUserToAddRows = false;
            this.dgvColors.AllowUserToDeleteRows = false;
            this.dgvColors.AllowUserToResizeColumns = false;
            this.dgvColors.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvColors.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvColors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvColors.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvColors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvColors.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvColors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvColors.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvColors.Location = new System.Drawing.Point(32, 442);
            this.dgvColors.MultiSelect = false;
            this.dgvColors.Name = "dgvColors";
            this.dgvColors.ReadOnly = true;
            this.dgvColors.RowHeadersVisible = false;
            this.dgvColors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColors.Size = new System.Drawing.Size(262, 86);
            this.dgvColors.TabIndex = 47;
            this.dgvColors.TabStop = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnSlotsDefault
            // 
            this.btnSlotsDefault.Location = new System.Drawing.Point(311, 199);
            this.btnSlotsDefault.Name = "btnSlotsDefault";
            this.btnSlotsDefault.Size = new System.Drawing.Size(75, 23);
            this.btnSlotsDefault.TabIndex = 46;
            this.btnSlotsDefault.TabStop = false;
            this.btnSlotsDefault.Text = "Defaults";
            this.btnSlotsDefault.UseVisualStyleBackColor = true;
            this.btnSlotsDefault.Click += new System.EventHandler(this.btnSlotsDefault_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 45;
            this.button1.TabStop = false;
            this.button1.Text = "Defaults";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAppDefault_Click);
            // 
            // btnGridViewDefault
            // 
            this.btnGridViewDefault.Location = new System.Drawing.Point(31, 413);
            this.btnGridViewDefault.Name = "btnGridViewDefault";
            this.btnGridViewDefault.Size = new System.Drawing.Size(75, 23);
            this.btnGridViewDefault.TabIndex = 44;
            this.btnGridViewDefault.TabStop = false;
            this.btnGridViewDefault.Text = "Defaults";
            this.btnGridViewDefault.UseVisualStyleBackColor = true;
            this.btnGridViewDefault.Click += new System.EventHandler(this.btnGridViewDefault_Click);
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(35, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(487, 34);
            this.label12.TabIndex = 43;
            this.label12.Text = "Select the application component label to select the desired color, or enter the " +
    "RGB hex value into the textbox";
            // 
            // AppGridViewRowSelectionColor
            // 
            this.AppGridViewRowSelectionColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppGridViewRowSelectionColor.Location = new System.Drawing.Point(221, 385);
            this.AppGridViewRowSelectionColor.Name = "AppGridViewRowSelectionColor";
            this.AppGridViewRowSelectionColor.ReadOnly = true;
            this.AppGridViewRowSelectionColor.Size = new System.Drawing.Size(73, 23);
            this.AppGridViewRowSelectionColor.TabIndex = 40;
            this.AppGridViewRowSelectionColor.TabStop = false;
            this.AppGridViewRowSelectionColor.Text = "#FFFFFF";
            this.AppGridViewRowSelectionColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AppGridViewRowSelectionColor.TextChanged += new System.EventHandler(this.Color_TextChanged);
            // 
            // AppGridViewAlternatingRowColor
            // 
            this.AppGridViewAlternatingRowColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppGridViewAlternatingRowColor.Location = new System.Drawing.Point(221, 358);
            this.AppGridViewAlternatingRowColor.Name = "AppGridViewAlternatingRowColor";
            this.AppGridViewAlternatingRowColor.ReadOnly = true;
            this.AppGridViewAlternatingRowColor.Size = new System.Drawing.Size(73, 23);
            this.AppGridViewAlternatingRowColor.TabIndex = 39;
            this.AppGridViewAlternatingRowColor.TabStop = false;
            this.AppGridViewAlternatingRowColor.Text = "#FFFFFF";
            this.AppGridViewAlternatingRowColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AppGridViewAlternatingRowColor.TextChanged += new System.EventHandler(this.Color_TextChanged);
            // 
            // SlotSelectedColor
            // 
            this.SlotSelectedColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SlotSelectedColor.Location = new System.Drawing.Point(501, 171);
            this.SlotSelectedColor.Name = "SlotSelectedColor";
            this.SlotSelectedColor.ReadOnly = true;
            this.SlotSelectedColor.Size = new System.Drawing.Size(73, 23);
            this.SlotSelectedColor.TabIndex = 38;
            this.SlotSelectedColor.TabStop = false;
            this.SlotSelectedColor.Text = "#FFFFFF";
            this.SlotSelectedColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SlotSelectedColor.TextChanged += new System.EventHandler(this.Color_TextChanged);
            // 
            // AppGridViewCellBorderColor
            // 
            this.AppGridViewCellBorderColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppGridViewCellBorderColor.Location = new System.Drawing.Point(221, 331);
            this.AppGridViewCellBorderColor.Name = "AppGridViewCellBorderColor";
            this.AppGridViewCellBorderColor.ReadOnly = true;
            this.AppGridViewCellBorderColor.Size = new System.Drawing.Size(73, 23);
            this.AppGridViewCellBorderColor.TabIndex = 37;
            this.AppGridViewCellBorderColor.TabStop = false;
            this.AppGridViewCellBorderColor.Text = "#FFFFFF";
            this.AppGridViewCellBorderColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AppGridViewCellBorderColor.TextChanged += new System.EventHandler(this.Color_TextChanged);
            // 
            // SlotHoverColor
            // 
            this.SlotHoverColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SlotHoverColor.Location = new System.Drawing.Point(501, 144);
            this.SlotHoverColor.Name = "SlotHoverColor";
            this.SlotHoverColor.ReadOnly = true;
            this.SlotHoverColor.Size = new System.Drawing.Size(73, 23);
            this.SlotHoverColor.TabIndex = 36;
            this.SlotHoverColor.TabStop = false;
            this.SlotHoverColor.Text = "#FFFFFF";
            this.SlotHoverColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SlotHoverColor.TextChanged += new System.EventHandler(this.Color_TextChanged);
            // 
            // AppToolBarColor
            // 
            this.AppToolBarColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppToolBarColor.Location = new System.Drawing.Point(221, 170);
            this.AppToolBarColor.Name = "AppToolBarColor";
            this.AppToolBarColor.ReadOnly = true;
            this.AppToolBarColor.Size = new System.Drawing.Size(73, 23);
            this.AppToolBarColor.TabIndex = 35;
            this.AppToolBarColor.TabStop = false;
            this.AppToolBarColor.Text = "#FFFFFF";
            this.AppToolBarColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AppToolBarColor.TextChanged += new System.EventHandler(this.Color_TextChanged);
            // 
            // AppBorderColor
            // 
            this.AppBorderColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppBorderColor.Location = new System.Drawing.Point(221, 144);
            this.AppBorderColor.Name = "AppBorderColor";
            this.AppBorderColor.ReadOnly = true;
            this.AppBorderColor.Size = new System.Drawing.Size(73, 23);
            this.AppBorderColor.TabIndex = 34;
            this.AppBorderColor.TabStop = false;
            this.AppBorderColor.Text = "#FFFFFF";
            this.AppBorderColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AppBorderColor.TextChanged += new System.EventHandler(this.Color_TextChanged);
            // 
            // SlotHasContentsColor
            // 
            this.SlotHasContentsColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SlotHasContentsColor.Location = new System.Drawing.Point(501, 117);
            this.SlotHasContentsColor.Name = "SlotHasContentsColor";
            this.SlotHasContentsColor.ReadOnly = true;
            this.SlotHasContentsColor.Size = new System.Drawing.Size(73, 23);
            this.SlotHasContentsColor.TabIndex = 33;
            this.SlotHasContentsColor.TabStop = false;
            this.SlotHasContentsColor.Text = "#FFFFFF";
            this.SlotHasContentsColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SlotHasContentsColor.TextChanged += new System.EventHandler(this.Color_TextChanged);
            // 
            // AppTextColor
            // 
            this.AppTextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppTextColor.Location = new System.Drawing.Point(221, 117);
            this.AppTextColor.Name = "AppTextColor";
            this.AppTextColor.ReadOnly = true;
            this.AppTextColor.Size = new System.Drawing.Size(73, 23);
            this.AppTextColor.TabIndex = 42;
            this.AppTextColor.TabStop = false;
            this.AppTextColor.Text = "#FFFFFF";
            this.AppTextColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AppTextColor.TextChanged += new System.EventHandler(this.Color_TextChanged);
            // 
            // SlotNoItemsColor
            // 
            this.SlotNoItemsColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SlotNoItemsColor.Location = new System.Drawing.Point(501, 90);
            this.SlotNoItemsColor.Name = "SlotNoItemsColor";
            this.SlotNoItemsColor.ReadOnly = true;
            this.SlotNoItemsColor.Size = new System.Drawing.Size(73, 23);
            this.SlotNoItemsColor.TabIndex = 16;
            this.SlotNoItemsColor.TabStop = false;
            this.SlotNoItemsColor.Text = "#FFFFFF";
            this.SlotNoItemsColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SlotNoItemsColor.TextChanged += new System.EventHandler(this.Color_TextChanged);
            // 
            // AppBackgroundColor
            // 
            this.AppBackgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppBackgroundColor.Location = new System.Drawing.Point(221, 90);
            this.AppBackgroundColor.Name = "AppBackgroundColor";
            this.AppBackgroundColor.ReadOnly = true;
            this.AppBackgroundColor.Size = new System.Drawing.Size(73, 23);
            this.AppBackgroundColor.TabIndex = 30;
            this.AppBackgroundColor.TabStop = false;
            this.AppBackgroundColor.Text = "#FFFFFF";
            this.AppBackgroundColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AppBackgroundColor.TextChanged += new System.EventHandler(this.Color_TextChanged);
            // 
            // lblAppGridViewRowSelectionColor
            // 
            this.lblAppGridViewRowSelectionColor.BackColor = System.Drawing.Color.White;
            this.lblAppGridViewRowSelectionColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAppGridViewRowSelectionColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAppGridViewRowSelectionColor.Location = new System.Drawing.Point(32, 385);
            this.lblAppGridViewRowSelectionColor.Margin = new System.Windows.Forms.Padding(2);
            this.lblAppGridViewRowSelectionColor.Name = "lblAppGridViewRowSelectionColor";
            this.lblAppGridViewRowSelectionColor.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblAppGridViewRowSelectionColor.Size = new System.Drawing.Size(186, 23);
            this.lblAppGridViewRowSelectionColor.TabIndex = 29;
            this.lblAppGridViewRowSelectionColor.Text = "Selection";
            this.lblAppGridViewRowSelectionColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAppGridViewRowSelectionColor.Click += new System.EventHandler(this.Label_Click);
            // 
            // lblAppGridViewAlternatingRowColor
            // 
            this.lblAppGridViewAlternatingRowColor.BackColor = System.Drawing.Color.White;
            this.lblAppGridViewAlternatingRowColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAppGridViewAlternatingRowColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAppGridViewAlternatingRowColor.Location = new System.Drawing.Point(32, 358);
            this.lblAppGridViewAlternatingRowColor.Margin = new System.Windows.Forms.Padding(2);
            this.lblAppGridViewAlternatingRowColor.Name = "lblAppGridViewAlternatingRowColor";
            this.lblAppGridViewAlternatingRowColor.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblAppGridViewAlternatingRowColor.Size = new System.Drawing.Size(186, 23);
            this.lblAppGridViewAlternatingRowColor.TabIndex = 28;
            this.lblAppGridViewAlternatingRowColor.Text = "Alternating Rows";
            this.lblAppGridViewAlternatingRowColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAppGridViewAlternatingRowColor.Click += new System.EventHandler(this.Label_Click);
            // 
            // lblSlotSelectedColor
            // 
            this.lblSlotSelectedColor.BackColor = System.Drawing.Color.White;
            this.lblSlotSelectedColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSlotSelectedColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSlotSelectedColor.Location = new System.Drawing.Point(312, 171);
            this.lblSlotSelectedColor.Margin = new System.Windows.Forms.Padding(2);
            this.lblSlotSelectedColor.Name = "lblSlotSelectedColor";
            this.lblSlotSelectedColor.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblSlotSelectedColor.Size = new System.Drawing.Size(186, 23);
            this.lblSlotSelectedColor.TabIndex = 27;
            this.lblSlotSelectedColor.Text = "Selected";
            this.lblSlotSelectedColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSlotSelectedColor.Click += new System.EventHandler(this.Label_Click);
            // 
            // lblAppGridViewCellBorderColor
            // 
            this.lblAppGridViewCellBorderColor.BackColor = System.Drawing.Color.White;
            this.lblAppGridViewCellBorderColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAppGridViewCellBorderColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAppGridViewCellBorderColor.Location = new System.Drawing.Point(32, 331);
            this.lblAppGridViewCellBorderColor.Margin = new System.Windows.Forms.Padding(2);
            this.lblAppGridViewCellBorderColor.Name = "lblAppGridViewCellBorderColor";
            this.lblAppGridViewCellBorderColor.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblAppGridViewCellBorderColor.Size = new System.Drawing.Size(186, 23);
            this.lblAppGridViewCellBorderColor.TabIndex = 26;
            this.lblAppGridViewCellBorderColor.Text = "Cell Borders";
            this.lblAppGridViewCellBorderColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAppGridViewCellBorderColor.Click += new System.EventHandler(this.Label_Click);
            // 
            // lblSlotHoverColor
            // 
            this.lblSlotHoverColor.BackColor = System.Drawing.Color.White;
            this.lblSlotHoverColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSlotHoverColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSlotHoverColor.Location = new System.Drawing.Point(312, 144);
            this.lblSlotHoverColor.Margin = new System.Windows.Forms.Padding(2);
            this.lblSlotHoverColor.Name = "lblSlotHoverColor";
            this.lblSlotHoverColor.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblSlotHoverColor.Size = new System.Drawing.Size(186, 23);
            this.lblSlotHoverColor.TabIndex = 25;
            this.lblSlotHoverColor.Text = "Hover";
            this.lblSlotHoverColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSlotHoverColor.Click += new System.EventHandler(this.Label_Click);
            // 
            // lblAppTestBorder
            // 
            this.lblAppTestBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(157)))), ((int)(((byte)(206)))));
            this.lblAppTestBorder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAppTestBorder.Location = new System.Drawing.Point(32, 266);
            this.lblAppTestBorder.Margin = new System.Windows.Forms.Padding(2);
            this.lblAppTestBorder.Name = "lblAppTestBorder";
            this.lblAppTestBorder.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblAppTestBorder.Size = new System.Drawing.Size(186, 25);
            this.lblAppTestBorder.TabIndex = 24;
            this.lblAppTestBorder.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblAppToolBarColor
            // 
            this.lblAppToolBarColor.BackColor = System.Drawing.Color.White;
            this.lblAppToolBarColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAppToolBarColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAppToolBarColor.Location = new System.Drawing.Point(32, 171);
            this.lblAppToolBarColor.Margin = new System.Windows.Forms.Padding(2);
            this.lblAppToolBarColor.Name = "lblAppToolBarColor";
            this.lblAppToolBarColor.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblAppToolBarColor.Size = new System.Drawing.Size(186, 23);
            this.lblAppToolBarColor.TabIndex = 23;
            this.lblAppToolBarColor.Text = "Toolbar";
            this.lblAppToolBarColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAppToolBarColor.Click += new System.EventHandler(this.Label_Click);
            // 
            // lblAppBorderColor
            // 
            this.lblAppBorderColor.BackColor = System.Drawing.Color.White;
            this.lblAppBorderColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAppBorderColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAppBorderColor.Location = new System.Drawing.Point(32, 144);
            this.lblAppBorderColor.Margin = new System.Windows.Forms.Padding(2);
            this.lblAppBorderColor.Name = "lblAppBorderColor";
            this.lblAppBorderColor.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblAppBorderColor.Size = new System.Drawing.Size(186, 23);
            this.lblAppBorderColor.TabIndex = 22;
            this.lblAppBorderColor.Text = "Borders";
            this.lblAppBorderColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAppBorderColor.Click += new System.EventHandler(this.Label_Click);
            // 
            // lblSlotHasContentsColor
            // 
            this.lblSlotHasContentsColor.BackColor = System.Drawing.Color.White;
            this.lblSlotHasContentsColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSlotHasContentsColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSlotHasContentsColor.Location = new System.Drawing.Point(312, 117);
            this.lblSlotHasContentsColor.Margin = new System.Windows.Forms.Padding(2);
            this.lblSlotHasContentsColor.Name = "lblSlotHasContentsColor";
            this.lblSlotHasContentsColor.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblSlotHasContentsColor.Size = new System.Drawing.Size(186, 23);
            this.lblSlotHasContentsColor.TabIndex = 21;
            this.lblSlotHasContentsColor.Text = "Has Contents";
            this.lblSlotHasContentsColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSlotHasContentsColor.Click += new System.EventHandler(this.Label_Click);
            // 
            // lblAppTextColor
            // 
            this.lblAppTextColor.BackColor = System.Drawing.Color.White;
            this.lblAppTextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAppTextColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAppTextColor.Location = new System.Drawing.Point(32, 117);
            this.lblAppTextColor.Margin = new System.Windows.Forms.Padding(2);
            this.lblAppTextColor.Name = "lblAppTextColor";
            this.lblAppTextColor.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblAppTextColor.Size = new System.Drawing.Size(186, 23);
            this.lblAppTextColor.TabIndex = 20;
            this.lblAppTextColor.Text = "Text";
            this.lblAppTextColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAppTextColor.Click += new System.EventHandler(this.Label_Click);
            // 
            // lblSlotNoItemsColor
            // 
            this.lblSlotNoItemsColor.BackColor = System.Drawing.Color.White;
            this.lblSlotNoItemsColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSlotNoItemsColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSlotNoItemsColor.Location = new System.Drawing.Point(312, 90);
            this.lblSlotNoItemsColor.Margin = new System.Windows.Forms.Padding(2);
            this.lblSlotNoItemsColor.Name = "lblSlotNoItemsColor";
            this.lblSlotNoItemsColor.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblSlotNoItemsColor.Size = new System.Drawing.Size(186, 23);
            this.lblSlotNoItemsColor.TabIndex = 19;
            this.lblSlotNoItemsColor.Text = "No Items";
            this.lblSlotNoItemsColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSlotNoItemsColor.Click += new System.EventHandler(this.Label_Click);
            // 
            // lblAppBackgroundColor
            // 
            this.lblAppBackgroundColor.BackColor = System.Drawing.Color.White;
            this.lblAppBackgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAppBackgroundColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAppBackgroundColor.Location = new System.Drawing.Point(32, 90);
            this.lblAppBackgroundColor.Margin = new System.Windows.Forms.Padding(2);
            this.lblAppBackgroundColor.Name = "lblAppBackgroundColor";
            this.lblAppBackgroundColor.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblAppBackgroundColor.Size = new System.Drawing.Size(186, 23);
            this.lblAppBackgroundColor.TabIndex = 18;
            this.lblAppBackgroundColor.Text = "Background";
            this.lblAppBackgroundColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAppBackgroundColor.Click += new System.EventHandler(this.Label_Click);
            // 
            // lblColorThemes
            // 
            this.lblColorThemes.AutoSize = true;
            this.lblColorThemes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorThemes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblColorThemes.Location = new System.Drawing.Point(309, 244);
            this.lblColorThemes.Name = "lblColorThemes";
            this.lblColorThemes.Size = new System.Drawing.Size(56, 17);
            this.lblColorThemes.TabIndex = 17;
            this.lblColorThemes.Text = "Themes";
            // 
            // lblSlotColors
            // 
            this.lblSlotColors.AutoSize = true;
            this.lblSlotColors.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlotColors.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSlotColors.Location = new System.Drawing.Point(309, 68);
            this.lblSlotColors.Name = "lblSlotColors";
            this.lblSlotColors.Size = new System.Drawing.Size(38, 17);
            this.lblSlotColors.TabIndex = 17;
            this.lblSlotColors.Text = "Slots";
            // 
            // lblGridViewColors
            // 
            this.lblGridViewColors.AutoSize = true;
            this.lblGridViewColors.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGridViewColors.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGridViewColors.Location = new System.Drawing.Point(29, 312);
            this.lblGridViewColors.Name = "lblGridViewColors";
            this.lblGridViewColors.Size = new System.Drawing.Size(47, 17);
            this.lblGridViewColors.TabIndex = 31;
            this.lblGridViewColors.Text = "Tables";
            // 
            // lblApplicationColors
            // 
            this.lblApplicationColors.AutoSize = true;
            this.lblApplicationColors.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationColors.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblApplicationColors.Location = new System.Drawing.Point(29, 68);
            this.lblApplicationColors.Name = "lblApplicationColors";
            this.lblApplicationColors.Size = new System.Drawing.Size(79, 17);
            this.lblApplicationColors.TabIndex = 32;
            this.lblApplicationColors.Text = "Application";
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(238)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(637, 633);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControlOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.tpGeneral.ResumeLayout(false);
            this.tpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneral)).EndInit();
            this.tabControlOptions.ResumeLayout(false);
            this.tpColors.ResumeLayout(false);
            this.tpColors.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabPage tpGeneral;
        public System.Windows.Forms.ComboBox cbBoxSizes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbxShowGridLines;
        private System.Windows.Forms.RadioButton rbShowColumnGridLines;
        private System.Windows.Forms.RadioButton rbShowRowGridLines;
        private System.Windows.Forms.RadioButton rbShowCellBorders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControlOptions;
        private System.Windows.Forms.TabPage tpColors;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsButton1;
        private System.Windows.Forms.ToolStripButton tsButton2;
        private System.Windows.Forms.ToolStripButton tsButton3;
        private System.Windows.Forms.Label lblAppTest;
        public System.Windows.Forms.DataGridView dgvColors;
        private System.Windows.Forms.Button btnSlotsDefault;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGridViewDefault;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox AppGridViewRowSelectionColor;
        private System.Windows.Forms.TextBox AppGridViewAlternatingRowColor;
        private System.Windows.Forms.TextBox SlotSelectedColor;
        private System.Windows.Forms.TextBox AppGridViewCellBorderColor;
        private System.Windows.Forms.TextBox SlotHoverColor;
        private System.Windows.Forms.TextBox AppToolBarColor;
        private System.Windows.Forms.TextBox AppBorderColor;
        private System.Windows.Forms.TextBox SlotHasContentsColor;
        private System.Windows.Forms.TextBox AppTextColor;
        private System.Windows.Forms.TextBox SlotNoItemsColor;
        private System.Windows.Forms.TextBox AppBackgroundColor;
        private System.Windows.Forms.Label lblAppGridViewRowSelectionColor;
        private System.Windows.Forms.Label lblAppGridViewAlternatingRowColor;
        private System.Windows.Forms.Label lblSlotSelectedColor;
        private System.Windows.Forms.Label lblAppGridViewCellBorderColor;
        private System.Windows.Forms.Label lblSlotHoverColor;
        private System.Windows.Forms.Label lblAppTestBorder;
        private System.Windows.Forms.Label lblAppToolBarColor;
        private System.Windows.Forms.Label lblAppBorderColor;
        private System.Windows.Forms.Label lblSlotHasContentsColor;
        private System.Windows.Forms.Label lblAppTextColor;
        private System.Windows.Forms.Label lblSlotNoItemsColor;
        private System.Windows.Forms.Label lblAppBackgroundColor;
        private System.Windows.Forms.Label lblSlotColors;
        private System.Windows.Forms.Label lblGridViewColors;
        private System.Windows.Forms.Label lblApplicationColors;
        public System.Windows.Forms.DataGridView dgvGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label lblColorThemes;
        public System.Windows.Forms.ComboBox cbThemes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbxSearch;
        private System.Windows.Forms.Label label3;
    }
}