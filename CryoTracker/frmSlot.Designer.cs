//    CryoTracker is a cryo/freezer box contents tracker
//    Copyright(C) 2018-2019 Christopher Ryan Mackay

namespace CryoTracker
{
    partial class frmSlot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSlot));
            this.dgvSlot = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsAddItem = new System.Windows.Forms.ToolStripButton();
            this.tsEditItem = new System.Windows.Forms.ToolStripButton();
            this.tsDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.tsClearSlot = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsArchiveItem = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlot)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSlot
            // 
            this.dgvSlot.AllowUserToAddRows = false;
            this.dgvSlot.AllowUserToDeleteRows = false;
            this.dgvSlot.AllowUserToResizeRows = false;
            this.dgvSlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSlot.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvSlot.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvSlot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSlot.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSlot.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSlot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSlot.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSlot.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvSlot.Location = new System.Drawing.Point(12, 48);
            this.dgvSlot.Name = "dgvSlot";
            this.dgvSlot.ReadOnly = true;
            this.dgvSlot.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSlot.RowHeadersWidth = 25;
            this.dgvSlot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSlot.Size = new System.Drawing.Size(910, 575);
            this.dgvSlot.TabIndex = 5;
            this.dgvSlot.TabStop = false;
            this.dgvSlot.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Table_RightClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(244)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAddItem,
            this.tsEditItem,
            this.tsDeleteItem,
            this.tsClearSlot,
            this.toolStripSeparator2,
            this.tsArchiveItem});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(1);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(934, 33);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsAddItem
            // 
            this.tsAddItem.AutoToolTip = false;
            this.tsAddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsAddItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.tsAddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAddItem.Margin = new System.Windows.Forms.Padding(4);
            this.tsAddItem.Name = "tsAddItem";
            this.tsAddItem.Padding = new System.Windows.Forms.Padding(1);
            this.tsAddItem.Size = new System.Drawing.Size(62, 21);
            this.tsAddItem.Text = "Add Item";
            this.tsAddItem.Click += new System.EventHandler(this.AddItem);
            // 
            // tsEditItem
            // 
            this.tsEditItem.AutoToolTip = false;
            this.tsEditItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsEditItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.tsEditItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEditItem.Margin = new System.Windows.Forms.Padding(4);
            this.tsEditItem.Name = "tsEditItem";
            this.tsEditItem.Padding = new System.Windows.Forms.Padding(1);
            this.tsEditItem.Size = new System.Drawing.Size(60, 21);
            this.tsEditItem.Text = "Edit Item";
            this.tsEditItem.Click += new System.EventHandler(this.EditItem);
            // 
            // tsDeleteItem
            // 
            this.tsDeleteItem.AutoToolTip = false;
            this.tsDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsDeleteItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.tsDeleteItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDeleteItem.Margin = new System.Windows.Forms.Padding(4);
            this.tsDeleteItem.Name = "tsDeleteItem";
            this.tsDeleteItem.Padding = new System.Windows.Forms.Padding(1);
            this.tsDeleteItem.Size = new System.Drawing.Size(73, 21);
            this.tsDeleteItem.Text = "Delete Item";
            this.tsDeleteItem.Click += new System.EventHandler(this.DeleteItem);
            // 
            // tsClearSlot
            // 
            this.tsClearSlot.AutoToolTip = false;
            this.tsClearSlot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsClearSlot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.tsClearSlot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsClearSlot.Margin = new System.Windows.Forms.Padding(4);
            this.tsClearSlot.Name = "tsClearSlot";
            this.tsClearSlot.Padding = new System.Windows.Forms.Padding(1);
            this.tsClearSlot.Size = new System.Drawing.Size(63, 21);
            this.tsClearSlot.Text = "Clear Slot";
            this.tsClearSlot.Click += new System.EventHandler(this.ClearSlot);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // tsArchiveItem
            // 
            this.tsArchiveItem.AutoToolTip = false;
            this.tsArchiveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsArchiveItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.tsArchiveItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsArchiveItem.Margin = new System.Windows.Forms.Padding(4);
            this.tsArchiveItem.Name = "tsArchiveItem";
            this.tsArchiveItem.Padding = new System.Windows.Forms.Padding(1);
            this.tsArchiveItem.Size = new System.Drawing.Size(80, 21);
            this.tsArchiveItem.Text = "Archive Item";
            this.tsArchiveItem.Click += new System.EventHandler(this.ArchiveItem);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Location = new System.Drawing.Point(0, 639);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(934, 22);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // frmSlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(238)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(934, 661);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvSlot);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(750, 600);
            this.Name = "frmSlot";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Slot";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CloseSlot);
            this.Load += new System.EventHandler(this.frmSlot_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSlot_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlot)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvSlot;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsAddItem;
        private System.Windows.Forms.ToolStripButton tsEditItem;
        private System.Windows.Forms.ToolStripButton tsDeleteItem;
        private System.Windows.Forms.ToolStripButton tsArchiveItem;
        private System.Windows.Forms.ToolStripButton tsClearSlot;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}