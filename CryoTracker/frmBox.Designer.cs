//    CryoTracker is a cryo/freezer box contents tracker
//    Copyright(C) 2018-2019 Christopher Ryan Mackay

namespace CryoTracker
{
    partial class frmBox
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBox));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dgvAllContents = new System.Windows.Forms.DataGridView();
            this.pnlBox = new System.Windows.Forms.Panel();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.fileMenu = new System.Windows.Forms.MenuItem();
            this.menuAddItem = new System.Windows.Forms.MenuItem();
            this.menuDeleteItem = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuCloseBox = new System.Windows.Forms.MenuItem();
            this.editMenu = new System.Windows.Forms.MenuItem();
            this.menuEditItem = new System.Windows.Forms.MenuItem();
            this.menuOpenSlot = new System.Windows.Forms.MenuItem();
            this.menuCombineSlots = new System.Windows.Forms.MenuItem();
            this.menuClearSlot = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuRemoveAttachment = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuArchiveItem = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuClearFilter = new System.Windows.Forms.MenuItem();
            this.menuView = new System.Windows.Forms.MenuItem();
            this.menuViewAttachment = new System.Windows.Forms.MenuItem();
            this.menuViewArchive = new System.Windows.Forms.MenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBoxInfo = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllContents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoxInfo)).BeginInit();
            this.SuspendLayout();
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
            this.dgvAllContents.Location = new System.Drawing.Point(486, 92);
            this.dgvAllContents.Name = "dgvAllContents";
            this.dgvAllContents.ReadOnly = true;
            this.dgvAllContents.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllContents.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAllContents.RowHeadersWidth = 25;
            this.dgvAllContents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllContents.Size = new System.Drawing.Size(801, 578);
            this.dgvAllContents.TabIndex = 4;
            this.dgvAllContents.TabStop = false;
            this.dgvAllContents.Click += new System.EventHandler(this.ClearSelection);
            this.dgvAllContents.DoubleClick += new System.EventHandler(this.EditItem);
            this.dgvAllContents.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvAllContents_MouseDown);
            this.dgvAllContents.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TableContents_RightClick);
            // 
            // pnlBox
            // 
            this.pnlBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlBox.Location = new System.Drawing.Point(21, 16);
            this.pnlBox.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBox.Name = "pnlBox";
            this.pnlBox.Size = new System.Drawing.Size(450, 450);
            this.pnlBox.TabIndex = 17;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.fileMenu,
            this.editMenu,
            this.menuView});
            // 
            // fileMenu
            // 
            this.fileMenu.Index = 0;
            this.fileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuAddItem,
            this.menuDeleteItem,
            this.menuItem2,
            this.menuCloseBox});
            this.fileMenu.Text = "File";
            // 
            // menuAddItem
            // 
            this.menuAddItem.Index = 0;
            this.menuAddItem.Text = "Add Item";
            this.menuAddItem.Click += new System.EventHandler(this.AddItem);
            // 
            // menuDeleteItem
            // 
            this.menuDeleteItem.Index = 1;
            this.menuDeleteItem.Text = "Delete Item";
            this.menuDeleteItem.Click += new System.EventHandler(this.DeleteItem);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "-";
            // 
            // menuCloseBox
            // 
            this.menuCloseBox.Index = 3;
            this.menuCloseBox.Text = "Close Box";
            this.menuCloseBox.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // editMenu
            // 
            this.editMenu.Index = 1;
            this.editMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuEditItem,
            this.menuOpenSlot,
            this.menuCombineSlots,
            this.menuClearSlot,
            this.menuItem5,
            this.menuRemoveAttachment,
            this.menuItem1,
            this.menuArchiveItem,
            this.menuItem3,
            this.menuClearFilter});
            this.editMenu.Text = "Edit";
            // 
            // menuEditItem
            // 
            this.menuEditItem.Index = 0;
            this.menuEditItem.Text = "Edit Item";
            this.menuEditItem.Click += new System.EventHandler(this.EditItem);
            // 
            // menuOpenSlot
            // 
            this.menuOpenSlot.Index = 1;
            this.menuOpenSlot.Text = "Open Slot";
            this.menuOpenSlot.Click += new System.EventHandler(this.OpenSlot);
            // 
            // menuCombineSlots
            // 
            this.menuCombineSlots.Index = 2;
            this.menuCombineSlots.Text = "Combine Slots";
            this.menuCombineSlots.Click += new System.EventHandler(this.CombineSlots);
            // 
            // menuClearSlot
            // 
            this.menuClearSlot.Index = 3;
            this.menuClearSlot.Text = "Clear Slot";
            this.menuClearSlot.Click += new System.EventHandler(this.ClearSlot);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 4;
            this.menuItem5.Text = "-";
            // 
            // menuRemoveAttachment
            // 
            this.menuRemoveAttachment.Index = 5;
            this.menuRemoveAttachment.Text = "Remove Attachment";
            this.menuRemoveAttachment.Click += new System.EventHandler(this.RemoveSlotAttachment);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 6;
            this.menuItem1.Text = "-";
            // 
            // menuArchiveItem
            // 
            this.menuArchiveItem.Index = 7;
            this.menuArchiveItem.Text = "Archive Item";
            this.menuArchiveItem.Click += new System.EventHandler(this.ArchiveItem);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 8;
            this.menuItem3.Text = "-";
            // 
            // menuClearFilter
            // 
            this.menuClearFilter.Index = 9;
            this.menuClearFilter.Text = "Clear Search";
            this.menuClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // menuView
            // 
            this.menuView.Index = 2;
            this.menuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuViewAttachment,
            this.menuViewArchive});
            this.menuView.Text = "View";
            // 
            // menuViewAttachment
            // 
            this.menuViewAttachment.Index = 0;
            this.menuViewAttachment.Text = "Attachment";
            this.menuViewAttachment.Click += new System.EventHandler(this.ViewSlotAttachment);
            // 
            // menuViewArchive
            // 
            this.menuViewArchive.Index = 1;
            this.menuViewArchive.Text = "Archive";
            this.menuViewArchive.Click += new System.EventHandler(this.ViewArchive);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Location = new System.Drawing.Point(0, 684);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1299, 22);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Click += new System.EventHandler(this.ClearSelection);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.ForeColor = System.Drawing.Color.DimGray;
            this.txtFilter.Location = new System.Drawing.Point(486, 16);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(801, 23);
            this.txtFilter.TabIndex = 24;
            this.txtFilter.TabStop = false;
            this.txtFilter.Text = "Enter search criteria...";
            this.txtFilter.Enter += new System.EventHandler(this.TxtFilter_Enter);
            this.txtFilter.Leave += new System.EventHandler(this.TxtFilter_Leave);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(1212, 45);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 25;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Location = new System.Drawing.Point(1131, 45);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 25;
            this.btnFilter.Text = "Search";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(486, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(801, 1);
            this.label1.TabIndex = 26;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.ClearSelection);
            // 
            // dgvBoxInfo
            // 
            this.dgvBoxInfo.AllowUserToAddRows = false;
            this.dgvBoxInfo.AllowUserToDeleteRows = false;
            this.dgvBoxInfo.AllowUserToResizeColumns = false;
            this.dgvBoxInfo.AllowUserToResizeRows = false;
            this.dgvBoxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvBoxInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBoxInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(238)))), ((int)(((byte)(240)))));
            this.dgvBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBoxInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBoxInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBoxInfo.ColumnHeadersVisible = false;
            this.dgvBoxInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(238)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(238)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(238)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBoxInfo.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBoxInfo.Enabled = false;
            this.dgvBoxInfo.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvBoxInfo.Location = new System.Drawing.Point(21, 480);
            this.dgvBoxInfo.Name = "dgvBoxInfo";
            this.dgvBoxInfo.ReadOnly = true;
            this.dgvBoxInfo.RowHeadersVisible = false;
            this.dgvBoxInfo.RowTemplate.Height = 25;
            this.dgvBoxInfo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvBoxInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBoxInfo.Size = new System.Drawing.Size(450, 190);
            this.dgvBoxInfo.TabIndex = 20;
            this.dgvBoxInfo.TabStop = false;
            this.dgvBoxInfo.Click += new System.EventHandler(this.ClearSelection);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // frmBox
            // 
            this.AcceptButton = this.btnFilter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(238)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1299, 706);
            this.Controls.Add(this.dgvBoxInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlBox);
            this.Controls.Add(this.dgvAllContents);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "frmBox";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CryoTracker";
            this.Load += new System.EventHandler(this.frmBox_Load);
            this.Shown += new System.EventHandler(this.frmBox_Shown);
            this.Click += new System.EventHandler(this.ClearSelection);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmBox_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmBox_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllContents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoxInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.DataGridView dgvAllContents;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem fileMenu;
        private System.Windows.Forms.MenuItem menuAddItem;
        private System.Windows.Forms.MenuItem menuDeleteItem;
        private System.Windows.Forms.MenuItem editMenu;
        private System.Windows.Forms.MenuItem menuOpenSlot;
        private System.Windows.Forms.MenuItem menuCombineSlots;
        private System.Windows.Forms.MenuItem menuClearSlot;
        private System.Windows.Forms.MenuItem menuEditItem;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuClearFilter;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuCloseBox;
        private System.Windows.Forms.MenuItem menuArchiveItem;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.Panel pnlBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuItem menuView;
        private System.Windows.Forms.MenuItem menuViewAttachment;
        private System.Windows.Forms.MenuItem menuViewArchive;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuRemoveAttachment;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dgvBoxInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}