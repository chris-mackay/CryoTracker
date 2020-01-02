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
    partial class frmSlotItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSlotItem));
            this.lblMaterial = new System.Windows.Forms.Label();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.ckbIsHazardous = new System.Windows.Forms.CheckBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtHazardType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtAttachment = new System.Windows.Forms.TextBox();
            this.lblAttachment = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsUndo = new System.Windows.Forms.ToolStripButton();
            this.tsRedo = new System.Windows.Forms.ToolStripButton();
            this.tsCut = new System.Windows.Forms.ToolStripButton();
            this.tsCopy = new System.Windows.Forms.ToolStripButton();
            this.tsPaste = new System.Windows.Forms.ToolStripButton();
            this.tsBulletList = new System.Windows.Forms.ToolStripButton();
            this.tsFontColor = new System.Windows.Forms.ToolStripButton();
            this.tsFont = new System.Windows.Forms.ToolStripButton();
            this.tsBold = new System.Windows.Forms.ToolStripButton();
            this.tsItalic = new System.Windows.Forms.ToolStripButton();
            this.tsUnderline = new System.Windows.Forms.ToolStripButton();
            this.tsStrike = new System.Windows.Forms.ToolStripButton();
            this.tsSymbols = new System.Windows.Forms.ToolStripButton();
            this.tsSuper = new System.Windows.Forms.ToolStripButton();
            this.tsSub = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaterial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblMaterial.Location = new System.Drawing.Point(12, 71);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(50, 15);
            this.lblMaterial.TabIndex = 4;
            this.lblMaterial.Text = "Material";
            this.lblMaterial.Enter += new System.EventHandler(this.EnableTabStop);
            // 
            // txtMaterial
            // 
            this.txtMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaterial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaterial.Location = new System.Drawing.Point(133, 64);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(356, 23);
            this.txtMaterial.TabIndex = 5;
            this.txtMaterial.Enter += new System.EventHandler(this.EnableTabStop);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.Location = new System.Drawing.Point(414, 493);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Enter += new System.EventHandler(this.EnableTabStop);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnOK.Location = new System.Drawing.Point(333, 493);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Enter += new System.EventHandler(this.EnableTabStop);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblDate.Location = new System.Drawing.Point(12, 45);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(31, 13);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date";
            this.lblDate.Enter += new System.EventHandler(this.EnableTabStop);
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDate.Location = new System.Drawing.Point(133, 38);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(356, 23);
            this.dtpDate.TabIndex = 3;
            this.dtpDate.Enter += new System.EventHandler(this.EnableTabStop);
            // 
            // ckbIsHazardous
            // 
            this.ckbIsHazardous.AutoSize = true;
            this.ckbIsHazardous.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ckbIsHazardous.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.ckbIsHazardous.Location = new System.Drawing.Point(15, 195);
            this.ckbIsHazardous.Name = "ckbIsHazardous";
            this.ckbIsHazardous.Size = new System.Drawing.Size(82, 19);
            this.ckbIsHazardous.TabIndex = 12;
            this.ckbIsHazardous.Text = "Hazardous";
            this.ckbIsHazardous.UseVisualStyleBackColor = true;
            this.ckbIsHazardous.CheckedChanged += new System.EventHandler(this.ckbIsHazardous_CheckedChanged);
            this.ckbIsHazardous.Enter += new System.EventHandler(this.EnableTabStop);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblName.Location = new System.Drawing.Point(12, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(36, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            this.lblName.Enter += new System.EventHandler(this.EnableTabStop);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.Location = new System.Drawing.Point(133, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(356, 23);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.CheckUserInput);
            this.txtName.Enter += new System.EventHandler(this.EnableTabStop);
            // 
            // txtHazardType
            // 
            this.txtHazardType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHazardType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtHazardType.Location = new System.Drawing.Point(133, 192);
            this.txtHazardType.Name = "txtHazardType";
            this.txtHazardType.Size = new System.Drawing.Size(356, 23);
            this.txtHazardType.TabIndex = 13;
            this.txtHazardType.TextChanged += new System.EventHandler(this.TxtHazardType_TextChanged);
            this.txtHazardType.Enter += new System.EventHandler(this.EnableTabStop);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(15, 473);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(474, 2);
            this.label1.TabIndex = 14;
            this.label1.Text = "label1";
            this.label1.Enter += new System.EventHandler(this.EnableTabStop);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemove.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRemove.Location = new System.Drawing.Point(214, 144);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            this.btnRemove.Enter += new System.EventHandler(this.EnableTabStop);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Location = new System.Drawing.Point(133, 144);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.Enter += new System.EventHandler(this.EnableTabStop);
            // 
            // txtAttachment
            // 
            this.txtAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttachment.Enabled = false;
            this.txtAttachment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAttachment.Location = new System.Drawing.Point(133, 115);
            this.txtAttachment.Name = "txtAttachment";
            this.txtAttachment.ReadOnly = true;
            this.txtAttachment.Size = new System.Drawing.Size(356, 23);
            this.txtAttachment.TabIndex = 9;
            this.txtAttachment.TabStop = false;
            this.txtAttachment.Enter += new System.EventHandler(this.EnableTabStop);
            // 
            // lblAttachment
            // 
            this.lblAttachment.AutoSize = true;
            this.lblAttachment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAttachment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblAttachment.Location = new System.Drawing.Point(12, 122);
            this.lblAttachment.Name = "lblAttachment";
            this.lblAttachment.Size = new System.Drawing.Size(70, 15);
            this.lblAttachment.TabIndex = 8;
            this.lblAttachment.Text = "Attachment";
            this.lblAttachment.Enter += new System.EventHandler(this.EnableTabStop);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(15, 263);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 190);
            this.panel1.TabIndex = 21;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(0, 25);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(472, 163);
            this.txtDescription.TabIndex = 21;
            this.txtDescription.Text = "";
            this.txtDescription.Enter += new System.EventHandler(this.DisableTabStop);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsUndo,
            this.tsRedo,
            this.tsCut,
            this.tsCopy,
            this.tsPaste,
            this.tsBulletList,
            this.tsFontColor,
            this.tsFont,
            this.tsBold,
            this.tsItalic,
            this.tsUnderline,
            this.tsStrike,
            this.tsSymbols,
            this.tsSuper,
            this.tsSub});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(472, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Enter += new System.EventHandler(this.DisableTabStop);
            // 
            // tsUndo
            // 
            this.tsUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsUndo.Image = ((System.Drawing.Image)(resources.GetObject("tsUndo.Image")));
            this.tsUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUndo.Name = "tsUndo";
            this.tsUndo.Size = new System.Drawing.Size(23, 22);
            this.tsUndo.Text = "Undo";
            this.tsUndo.Click += new System.EventHandler(this.TsUndo_Click);
            // 
            // tsRedo
            // 
            this.tsRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsRedo.Image = ((System.Drawing.Image)(resources.GetObject("tsRedo.Image")));
            this.tsRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRedo.Name = "tsRedo";
            this.tsRedo.Size = new System.Drawing.Size(23, 22);
            this.tsRedo.Text = "Redo";
            this.tsRedo.Click += new System.EventHandler(this.TsRedo_Click);
            // 
            // tsCut
            // 
            this.tsCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsCut.Image = ((System.Drawing.Image)(resources.GetObject("tsCut.Image")));
            this.tsCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCut.Name = "tsCut";
            this.tsCut.Size = new System.Drawing.Size(23, 22);
            this.tsCut.Text = "Cut";
            this.tsCut.Click += new System.EventHandler(this.TsCut_Click);
            // 
            // tsCopy
            // 
            this.tsCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsCopy.Image")));
            this.tsCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCopy.Name = "tsCopy";
            this.tsCopy.Size = new System.Drawing.Size(23, 22);
            this.tsCopy.Text = "Copy";
            this.tsCopy.Click += new System.EventHandler(this.TsCopy_Click);
            // 
            // tsPaste
            // 
            this.tsPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPaste.Image = ((System.Drawing.Image)(resources.GetObject("tsPaste.Image")));
            this.tsPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPaste.Name = "tsPaste";
            this.tsPaste.Size = new System.Drawing.Size(23, 22);
            this.tsPaste.Text = "Paste";
            this.tsPaste.Click += new System.EventHandler(this.TsPaste_Click);
            // 
            // tsBulletList
            // 
            this.tsBulletList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBulletList.Image = ((System.Drawing.Image)(resources.GetObject("tsBulletList.Image")));
            this.tsBulletList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBulletList.Name = "tsBulletList";
            this.tsBulletList.Size = new System.Drawing.Size(23, 22);
            this.tsBulletList.Text = "Bullet List";
            this.tsBulletList.Click += new System.EventHandler(this.TsBulletList_Click);
            // 
            // tsFontColor
            // 
            this.tsFontColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsFontColor.Image = ((System.Drawing.Image)(resources.GetObject("tsFontColor.Image")));
            this.tsFontColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFontColor.Name = "tsFontColor";
            this.tsFontColor.Size = new System.Drawing.Size(23, 22);
            this.tsFontColor.Text = "Font Color";
            this.tsFontColor.Click += new System.EventHandler(this.TsFontColor_Click);
            // 
            // tsFont
            // 
            this.tsFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsFont.Image = ((System.Drawing.Image)(resources.GetObject("tsFont.Image")));
            this.tsFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFont.Name = "tsFont";
            this.tsFont.Size = new System.Drawing.Size(23, 22);
            this.tsFont.Text = "Font Style";
            this.tsFont.Click += new System.EventHandler(this.TsFont_Click);
            // 
            // tsBold
            // 
            this.tsBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBold.Image = ((System.Drawing.Image)(resources.GetObject("tsBold.Image")));
            this.tsBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBold.Name = "tsBold";
            this.tsBold.Size = new System.Drawing.Size(23, 22);
            this.tsBold.Text = "Bold";
            this.tsBold.Click += new System.EventHandler(this.TsBold_Click);
            // 
            // tsItalic
            // 
            this.tsItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsItalic.Image = ((System.Drawing.Image)(resources.GetObject("tsItalic.Image")));
            this.tsItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsItalic.Name = "tsItalic";
            this.tsItalic.Size = new System.Drawing.Size(23, 22);
            this.tsItalic.Text = "Italic";
            this.tsItalic.Click += new System.EventHandler(this.TsItalic_Click);
            // 
            // tsUnderline
            // 
            this.tsUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsUnderline.Image = ((System.Drawing.Image)(resources.GetObject("tsUnderline.Image")));
            this.tsUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUnderline.Name = "tsUnderline";
            this.tsUnderline.Size = new System.Drawing.Size(23, 22);
            this.tsUnderline.Text = "Underline";
            this.tsUnderline.Click += new System.EventHandler(this.TsUnderline_Click);
            // 
            // tsStrike
            // 
            this.tsStrike.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsStrike.Image = ((System.Drawing.Image)(resources.GetObject("tsStrike.Image")));
            this.tsStrike.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsStrike.Name = "tsStrike";
            this.tsStrike.Size = new System.Drawing.Size(23, 22);
            this.tsStrike.Text = "Strikethrough";
            this.tsStrike.Click += new System.EventHandler(this.TsStrike_Click);
            // 
            // tsSymbols
            // 
            this.tsSymbols.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSymbols.Image = ((System.Drawing.Image)(resources.GetObject("tsSymbols.Image")));
            this.tsSymbols.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSymbols.Name = "tsSymbols";
            this.tsSymbols.Size = new System.Drawing.Size(23, 22);
            this.tsSymbols.Text = "Symbols";
            this.tsSymbols.Click += new System.EventHandler(this.TsSymbols_Click);
            // 
            // tsSuper
            // 
            this.tsSuper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSuper.Image = ((System.Drawing.Image)(resources.GetObject("tsSuper.Image")));
            this.tsSuper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSuper.Name = "tsSuper";
            this.tsSuper.Size = new System.Drawing.Size(23, 22);
            this.tsSuper.Text = "Superscript";
            this.tsSuper.Click += new System.EventHandler(this.TsSuper_Click);
            // 
            // tsSub
            // 
            this.tsSub.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSub.Image = ((System.Drawing.Image)(resources.GetObject("tsSub.Image")));
            this.tsSub.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSub.Name = "tsSub";
            this.tsSub.Size = new System.Drawing.Size(23, 22);
            this.tsSub.Text = "Subscript";
            this.tsSub.Click += new System.EventHandler(this.TsSub_Click);
            // 
            // frmSlotItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(238)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(501, 528);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtAttachment);
            this.Controls.Add(this.lblAttachment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHazardType);
            this.Controls.Add(this.ckbIsHazardous);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtMaterial);
            this.Controls.Add(this.lblMaterial);
            this.Controls.Add(this.lblDate);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSlotItem";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Slot Item";
            this.Load += new System.EventHandler(this.frmSlotItem_Load);
            this.SizeChanged += new System.EventHandler(this.Frm_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSlotItem_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblName;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.DateTimePicker dtpDate;
        public System.Windows.Forms.CheckBox ckbIsHazardous;
        public System.Windows.Forms.TextBox txtHazardType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.TextBox txtAttachment;
        private System.Windows.Forms.Label lblAttachment;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsUndo;
        private System.Windows.Forms.ToolStripButton tsRedo;
        private System.Windows.Forms.ToolStripButton tsCut;
        private System.Windows.Forms.ToolStripButton tsCopy;
        private System.Windows.Forms.ToolStripButton tsPaste;
        private System.Windows.Forms.ToolStripButton tsBulletList;
        private System.Windows.Forms.ToolStripButton tsFontColor;
        private System.Windows.Forms.ToolStripButton tsFont;
        private System.Windows.Forms.ToolStripButton tsBold;
        private System.Windows.Forms.ToolStripButton tsItalic;
        private System.Windows.Forms.ToolStripButton tsUnderline;
        private System.Windows.Forms.ToolStripButton tsStrike;
        private System.Windows.Forms.ToolStripButton tsSymbols;
        private System.Windows.Forms.ToolStripButton tsSuper;
        private System.Windows.Forms.ToolStripButton tsSub;
    }
}