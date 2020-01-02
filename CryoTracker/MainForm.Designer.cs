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

namespace CryoTracker
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lstRacks = new System.Windows.Forms.ListView();
            this.lstLocations = new System.Windows.Forms.ListBox();
            this.lblLocations = new System.Windows.Forms.Label();
            this.lblRacks = new System.Windows.Forms.Label();
            this.dgvAllContents = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.fileMenu = new System.Windows.Forms.MenuItem();
            this.settingsMenu = new System.Windows.Forms.MenuItem();
            this.exitMenu = new System.Windows.Forms.MenuItem();
            this.locationMenu = new System.Windows.Forms.MenuItem();
            this.menuAddLocation = new System.Windows.Forms.MenuItem();
            this.menuRenameLocation = new System.Windows.Forms.MenuItem();
            this.menuDeleteLocation = new System.Windows.Forms.MenuItem();
            this.boxMenu = new System.Windows.Forms.MenuItem();
            this.menuOpenBox = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuAddBox = new System.Windows.Forms.MenuItem();
            this.menuEditBox = new System.Windows.Forms.MenuItem();
            this.menuDeleteBox = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuViewAttachment = new System.Windows.Forms.MenuItem();
            this.menuRemoveAttachment = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuDeleteRack = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuAbout = new System.Windows.Forms.MenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllContents)).BeginInit();
            this.SuspendLayout();
            // 
            // lstRacks
            // 
            this.lstRacks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRacks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstRacks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstRacks.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lstRacks.FullRowSelect = true;
            this.lstRacks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstRacks.HideSelection = false;
            this.lstRacks.Location = new System.Drawing.Point(219, 35);
            this.lstRacks.MultiSelect = false;
            this.lstRacks.Name = "lstRacks";
            this.lstRacks.Size = new System.Drawing.Size(658, 240);
            this.lstRacks.TabIndex = 5;
            this.lstRacks.TabStop = false;
            this.lstRacks.UseCompatibleStateImageBehavior = false;
            this.lstRacks.View = System.Windows.Forms.View.Details;
            this.lstRacks.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OpenBoxFromRack_DoubleClick);
            this.lstRacks.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Box_MouseUp);
            // 
            // lstLocations
            // 
            this.lstLocations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLocations.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLocations.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lstLocations.FormattingEnabled = true;
            this.lstLocations.ItemHeight = 15;
            this.lstLocations.Location = new System.Drawing.Point(12, 35);
            this.lstLocations.Name = "lstLocations";
            this.lstLocations.Size = new System.Drawing.Size(188, 240);
            this.lstLocations.TabIndex = 1;
            this.lstLocations.TabStop = false;
            this.lstLocations.SelectedIndexChanged += new System.EventHandler(this.lstLocations_SelectedIndexChanged);
            this.lstLocations.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Location_MouseUp);
            // 
            // lblLocations
            // 
            this.lblLocations.AutoSize = true;
            this.lblLocations.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblLocations.Location = new System.Drawing.Point(12, 17);
            this.lblLocations.Name = "lblLocations";
            this.lblLocations.Size = new System.Drawing.Size(58, 15);
            this.lblLocations.TabIndex = 0;
            this.lblLocations.Text = "Locations";
            // 
            // lblRacks
            // 
            this.lblRacks.AutoSize = true;
            this.lblRacks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRacks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblRacks.Location = new System.Drawing.Point(219, 17);
            this.lblRacks.Name = "lblRacks";
            this.lblRacks.Size = new System.Drawing.Size(37, 15);
            this.lblRacks.TabIndex = 4;
            this.lblRacks.Text = "Racks";
            // 
            // dgvAllContents
            // 
            this.dgvAllContents.AllowUserToAddRows = false;
            this.dgvAllContents.AllowUserToDeleteRows = false;
            this.dgvAllContents.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvAllContents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAllContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAllContents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvAllContents.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvAllContents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAllContents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllContents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAllContents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllContents.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAllContents.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvAllContents.Location = new System.Drawing.Point(12, 385);
            this.dgvAllContents.MultiSelect = false;
            this.dgvAllContents.Name = "dgvAllContents";
            this.dgvAllContents.ReadOnly = true;
            this.dgvAllContents.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvAllContents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllContents.Size = new System.Drawing.Size(865, 241);
            this.dgvAllContents.TabIndex = 7;
            this.dgvAllContents.TabStop = false;
            this.dgvAllContents.DoubleClick += new System.EventHandler(this.OpenSlot);
            this.dgvAllContents.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Search_MouseUp);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.DimGray;
            this.txtSearch.Location = new System.Drawing.Point(12, 315);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(865, 23);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.TabStop = false;
            this.txtSearch.Text = "Enter search criteria...";
            this.txtSearch.Enter += new System.EventHandler(this.TxtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.TxtSearch_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(12, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(865, 2);
            this.label1.TabIndex = 13;
            this.label1.Text = "label1";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClear.Location = new System.Drawing.Point(802, 349);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 15;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.ClearSearch);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.Location = new System.Drawing.Point(721, 349);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.fileMenu,
            this.locationMenu,
            this.boxMenu,
            this.menuItem1});
            // 
            // fileMenu
            // 
            this.fileMenu.Index = 0;
            this.fileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.settingsMenu,
            this.exitMenu});
            this.fileMenu.Text = "File";
            // 
            // settingsMenu
            // 
            this.settingsMenu.Index = 0;
            this.settingsMenu.Text = "Settings";
            this.settingsMenu.Click += new System.EventHandler(this.tsSettings_Click);
            // 
            // exitMenu
            // 
            this.exitMenu.Index = 1;
            this.exitMenu.Text = "Exit";
            this.exitMenu.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // locationMenu
            // 
            this.locationMenu.Index = 1;
            this.locationMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuAddLocation,
            this.menuRenameLocation,
            this.menuDeleteLocation});
            this.locationMenu.Text = "Location";
            // 
            // menuAddLocation
            // 
            this.menuAddLocation.Index = 0;
            this.menuAddLocation.Text = "Add Location";
            this.menuAddLocation.Click += new System.EventHandler(this.AddLocation);
            // 
            // menuRenameLocation
            // 
            this.menuRenameLocation.Index = 1;
            this.menuRenameLocation.Text = "Rename Location";
            this.menuRenameLocation.Click += new System.EventHandler(this.RenameLocation);
            // 
            // menuDeleteLocation
            // 
            this.menuDeleteLocation.Index = 2;
            this.menuDeleteLocation.Text = "Delete Location";
            this.menuDeleteLocation.Click += new System.EventHandler(this.DeleteLocation);
            // 
            // boxMenu
            // 
            this.boxMenu.Index = 2;
            this.boxMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuOpenBox,
            this.menuItem11,
            this.menuAddBox,
            this.menuEditBox,
            this.menuDeleteBox,
            this.menuItem15,
            this.menuViewAttachment,
            this.menuRemoveAttachment,
            this.menuItem2,
            this.menuDeleteRack});
            this.boxMenu.Text = "Box";
            // 
            // menuOpenBox
            // 
            this.menuOpenBox.Index = 0;
            this.menuOpenBox.Text = "Open Box";
            this.menuOpenBox.Click += new System.EventHandler(this.OpenBox);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 1;
            this.menuItem11.Text = "-";
            // 
            // menuAddBox
            // 
            this.menuAddBox.Index = 2;
            this.menuAddBox.Text = "Add Box";
            this.menuAddBox.Click += new System.EventHandler(this.AddBox);
            // 
            // menuEditBox
            // 
            this.menuEditBox.Index = 3;
            this.menuEditBox.Text = "Edit Box";
            this.menuEditBox.Click += new System.EventHandler(this.EditBox);
            // 
            // menuDeleteBox
            // 
            this.menuDeleteBox.Index = 4;
            this.menuDeleteBox.Text = "Delete Box";
            this.menuDeleteBox.Click += new System.EventHandler(this.DeleteBox);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 5;
            this.menuItem15.Text = "-";
            // 
            // menuViewAttachment
            // 
            this.menuViewAttachment.Index = 6;
            this.menuViewAttachment.Text = "View Attachment";
            this.menuViewAttachment.Click += new System.EventHandler(this.ViewBoxAttachment);
            // 
            // menuRemoveAttachment
            // 
            this.menuRemoveAttachment.Index = 7;
            this.menuRemoveAttachment.Text = "Remove Attachment";
            this.menuRemoveAttachment.Click += new System.EventHandler(this.RemoveBoxAttachment);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 8;
            this.menuItem2.Text = "-";
            // 
            // menuDeleteRack
            // 
            this.menuDeleteRack.Index = 9;
            this.menuDeleteRack.Text = "Delete Rack";
            this.menuDeleteRack.Click += new System.EventHandler(this.DeleteRack);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuAbout});
            this.menuItem1.Text = "Help";
            // 
            // menuAbout
            // 
            this.menuAbout.Index = 0;
            this.menuAbout.Text = "About CryoTracker";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 637);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(889, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(238)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(889, 659);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvAllContents);
            this.Controls.Add(this.lblRacks);
            this.Controls.Add(this.lblLocations);
            this.Controls.Add(this.lstLocations);
            this.Controls.Add(this.lstRacks);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimumSize = new System.Drawing.Size(750, 650);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CryoTracker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllContents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ListView lstRacks;
        private System.Windows.Forms.Label lblLocations;
        private System.Windows.Forms.Label lblRacks;
        public System.Windows.Forms.ListBox lstLocations;
        public System.Windows.Forms.DataGridView dgvAllContents;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem locationMenu;
        private System.Windows.Forms.MenuItem menuAddLocation;
        private System.Windows.Forms.MenuItem menuRenameLocation;
        private System.Windows.Forms.MenuItem menuDeleteLocation;
        private System.Windows.Forms.MenuItem boxMenu;
        private System.Windows.Forms.MenuItem menuOpenBox;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuAddBox;
        private System.Windows.Forms.MenuItem menuEditBox;
        private System.Windows.Forms.MenuItem menuDeleteBox;
        private System.Windows.Forms.MenuItem menuItem15;
        private System.Windows.Forms.MenuItem menuDeleteRack;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuAbout;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.MenuItem menuViewAttachment;
        private System.Windows.Forms.MenuItem menuRemoveAttachment;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuItem fileMenu;
        private System.Windows.Forms.MenuItem settingsMenu;
        private System.Windows.Forms.MenuItem exitMenu;
    }
}

