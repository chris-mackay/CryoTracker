//    CryoTracker is a cryo/freezer box contents tracker
//    Copyright(C) 2018-2019 Christopher Ryan Mackay

using ADOX;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace CryoTracker
{
    class DBConnector
    {
        private OleDbConnection con = new OleDbConnection();
        private string dbProvider;
        private string dbSource;
        private DataTable dt = new DataTable();
        private OleDbDataAdapter da;
        private string sql;

        public void OpenBox(string _Box)
        {
            con.Close();
            con.Dispose();
            OleDbConnection.ReleaseObjectPool();

            dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;";
            dbSource = "Data Source = " + _Box;

            con.ConnectionString = dbProvider + dbSource;

            con.Open();
        }

        public void CloseBox()
        {
            con.Close();
            con.Dispose();
            OleDbConnection.ReleaseObjectPool();
        }

        public int SQLRowCount(string _Slot)
        {
            int count = 0;

            OleDbCommand cmd = new OleDbCommand(@"select count(*) from " + _Slot, con);
            count = int.Parse(cmd.ExecuteScalar().ToString());

            return count;
        }

        public void SQLCommand(string _SqlString)
        {
            OleDbCommand cmd = new OleDbCommand(_SqlString, con);
            cmd.ExecuteNonQuery();
        }

        public void SQLSelect(string _SqlString)
        {
            sql = _SqlString;
            da = new OleDbDataAdapter(sql, con);
        }

        public void LoadTableContents(DataGridView _DataGridView)
        {
            Module.DrawingControl.SetDoubleBuffered(_DataGridView);
            Module.DrawingControl.SuspendDrawing(_DataGridView);

            _DataGridView.DataSource = null;
            _DataGridView.Columns.Clear();

            dt.Clear();
            da.Fill(dt);

            _DataGridView.DataSource = dt.DefaultView;
            Module.FormatDataGridView(_DataGridView);

            Module.DrawingControl.ResumeDrawing(_DataGridView);
        }

        public void SQLFillList(string _SqlString, List<string> _List, string _ColumnName)
        {
            OleDbCommand da = new OleDbCommand(_SqlString, con);
            OleDbDataReader dr;
            dr = da.ExecuteReader();

            _List.Clear();

            while (dr.Read())
            {
                _List.Add(dr[_ColumnName].ToString());
            }
            dr.Close();
        }

        public void CreateBox(string _Box)
        {
            Catalog cat = new Catalog();
            OleDbConnection connection = new OleDbConnection();

            string conString = string.Empty;
            string dbProvider = string.Empty;
            string dbSource = string.Empty;

            dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;";
            dbSource = "Data Source = " + _Box;

            conString = dbProvider + dbSource;
            connection.ConnectionString = conString;

            cat.Create(conString);

            connection.Open();

            for (int i = 1; i <= 10; i++)
            {
                CreateSlotTable(cat, "A" + i);
            }

            for (int i = 1; i <= 10; i++)
            {
                CreateSlotTable(cat, "B" + i);
            }

            for (int i = 1; i <= 10; i++)
            {
                CreateSlotTable(cat, "C" + i);
            }

            for (int i = 1; i <= 10; i++)
            {
                CreateSlotTable(cat, "D" + i);
            }

            for (int i = 1; i <= 10; i++)
            {
                CreateSlotTable(cat, "E" + i);
            }

            for (int i = 1; i <= 10; i++)
            {
                CreateSlotTable(cat, "F" + i);
            }

            for (int i = 1; i <= 10; i++)
            {
                CreateSlotTable(cat, "G" + i);
            }

            for (int i = 1; i <= 10; i++)
            {
                CreateSlotTable(cat, "H" + i);
            }

            for (int i = 1; i <= 10; i++)
            {
                CreateSlotTable(cat, "I" + i);
            }

            for (int i = 1; i <= 10; i++)
            {
                CreateSlotTable(cat, "J" + i);
            }

            CreateBoxInfoTable(cat);
            CreateArchiveTable(cat);

            connection.Close();
            connection.Dispose();
            OleDbConnection.ReleaseObjectPool();

        }

        private void CreateArchiveTable(Catalog _Catalog)
        {
            Table tblArchive = new Table();

            Key ID = new Key();

            Column colID = new Column();
            Column colSlot = new Column();
            Column colSlotDate = new Column();
            Column colArchiveDate = new Column();
            Column colName = new Column();
            Column colMaterial = new Column();
            Column colIsHazardous = new Column();
            Column colHazardType = new Column();
            Column colDescription = new Column();
            Column colRtf = new Column();
            Column colAttachment = new Column();

            colID.Name = "ID";
            colID.Type = DataTypeEnum.adInteger;
            colID.ParentCatalog = _Catalog;
            colID.Properties["AutoIncrement"].Value = true;

            ID.Name = "Primary Key";
            ID.Columns.Append("ID");
            ID.Type = KeyTypeEnum.adKeyPrimary;

            colSlot.Name = "Slot";
            colSlot.Type = DataTypeEnum.adLongVarWChar;
            colSlot.Attributes = ColumnAttributesEnum.adColNullable;
            colSlot.ParentCatalog = _Catalog;

            colSlotDate.Name = "SlotDate";
            colSlotDate.Type = DataTypeEnum.adDate;
            colSlotDate.Attributes = ColumnAttributesEnum.adColNullable;
            colSlotDate.ParentCatalog = _Catalog;

            colArchiveDate.Name = "ArchiveDate";
            colArchiveDate.Type = DataTypeEnum.adDate;
            colArchiveDate.Attributes = ColumnAttributesEnum.adColNullable;
            colArchiveDate.ParentCatalog = _Catalog;

            colName.Name = "Name";
            colName.Type = DataTypeEnum.adLongVarWChar;
            colName.Attributes = ColumnAttributesEnum.adColNullable;
            colName.ParentCatalog = _Catalog;

            colMaterial.Name = "Material";
            colMaterial.Type = DataTypeEnum.adLongVarWChar;
            colMaterial.Attributes = ColumnAttributesEnum.adColNullable;
            colMaterial.ParentCatalog = _Catalog;

            colIsHazardous.Name = "IsHazardous";
            colIsHazardous.Type = DataTypeEnum.adLongVarWChar;
            colIsHazardous.Attributes = ColumnAttributesEnum.adColNullable;
            colIsHazardous.ParentCatalog = _Catalog;

            colHazardType.Name = "HazardType";
            colHazardType.Type = DataTypeEnum.adLongVarWChar;
            colHazardType.Attributes = ColumnAttributesEnum.adColNullable;
            colHazardType.ParentCatalog = _Catalog;

            colDescription.Name = "Description";
            colDescription.Type = DataTypeEnum.adLongVarWChar;
            colDescription.Attributes = ColumnAttributesEnum.adColNullable;
            colDescription.ParentCatalog = _Catalog;

            colRtf.Name = "Rtf";
            colRtf.Type = DataTypeEnum.adLongVarWChar;
            colRtf.Attributes = ColumnAttributesEnum.adColNullable;
            colRtf.ParentCatalog = _Catalog;

            colAttachment.Name = "Attachment";
            colAttachment.Type = DataTypeEnum.adLongVarWChar;
            colAttachment.Attributes = ColumnAttributesEnum.adColNullable;
            colAttachment.ParentCatalog = _Catalog;

            tblArchive.Name = "tblArchive";
            tblArchive.Columns.Append(colID);
            tblArchive.Columns.Append(colSlot);
            tblArchive.Columns.Append(colName);
            tblArchive.Columns.Append(colSlotDate);
            tblArchive.Columns.Append(colArchiveDate);
            tblArchive.Columns.Append(colMaterial);
            tblArchive.Columns.Append(colIsHazardous);
            tblArchive.Columns.Append(colHazardType);
            tblArchive.Columns.Append(colDescription);
            tblArchive.Columns.Append(colRtf);
            tblArchive.Columns.Append(colAttachment);

            _Catalog.Tables.Append(tblArchive);
        }

        private void CreateBoxInfoTable(Catalog _Catalog)
        {
            Table tbl = new Table();

            Key ID = new Key();

            Column colID = new Column();
            Column colProject = new Column();
            Column colLocation = new Column();
            Column colRack = new Column();
            Column colBox = new Column();
            Column colAttachment = new Column();

            colID.Name = "ID";
            colID.Type = DataTypeEnum.adInteger;
            colID.ParentCatalog = _Catalog;
            colID.Properties["AutoIncrement"].Value = true;

            ID.Name = "Primary Key";
            ID.Columns.Append("ID");
            ID.Type = KeyTypeEnum.adKeyPrimary;

            colProject.Name = "Project";
            colProject.Type = DataTypeEnum.adLongVarWChar;
            colProject.Attributes = ColumnAttributesEnum.adColNullable;
            colProject.ParentCatalog = _Catalog;

            colLocation.Name = "Location";
            colProject.Type = DataTypeEnum.adLongVarWChar;
            colLocation.Attributes = ColumnAttributesEnum.adColNullable;
            colLocation.ParentCatalog = _Catalog;

            colRack.Name = "Rack";
            colRack.Type = DataTypeEnum.adLongVarWChar;
            colRack.Attributes = ColumnAttributesEnum.adColNullable;
            colRack.ParentCatalog = _Catalog;

            colBox.Name = "Box";
            colBox.Type = DataTypeEnum.adLongVarWChar;
            colBox.Attributes = ColumnAttributesEnum.adColNullable;
            colBox.ParentCatalog = _Catalog;

            colAttachment.Name = "Attachment";
            colAttachment.Type = DataTypeEnum.adLongVarWChar;
            colAttachment.Attributes = ColumnAttributesEnum.adColNullable;
            colAttachment.ParentCatalog = _Catalog;

            tbl.Name = "tblBoxInfo";
            tbl.Columns.Append(colID);
            tbl.Columns.Append(colProject);
            tbl.Columns.Append(colLocation);
            tbl.Columns.Append(colRack);
            tbl.Columns.Append(colBox);
            tbl.Columns.Append(colAttachment);

            _Catalog.Tables.Append(tbl);

        }

        public void CreateSlotTable(Catalog _Catalog, string _TableName)
        {
            Table tblSlot = new Table();

            Key ID = new Key();

            Column colID = new Column();
            Column colSlot = new Column();
            Column colName = new Column();
            Column colSlotDate = new Column();
            Column colMaterial = new Column();
            Column colIsHazardous = new Column();
            Column colHazardType = new Column();
            Column colDescription = new Column();
            Column colRtf = new Column();
            Column colAttachment = new Column();

            colID.Name = "ID";
            colID.Type = DataTypeEnum.adInteger;
            colID.ParentCatalog = _Catalog;
            colID.Properties["AutoIncrement"].Value = true;

            ID.Name = "Primary Key";
            ID.Columns.Append("ID");
            ID.Type = KeyTypeEnum.adKeyPrimary;

            colSlot.Name = "Slot";
            colSlot.Type = DataTypeEnum.adLongVarWChar;
            colSlot.Attributes = ColumnAttributesEnum.adColNullable;
            colSlot.ParentCatalog = _Catalog;

            colSlotDate.Name = "SlotDate";
            colSlotDate.Type = DataTypeEnum.adDate;
            colSlotDate.Attributes = ColumnAttributesEnum.adColNullable;
            colSlotDate.ParentCatalog = _Catalog;

            colName.Name = "Name";
            colName.Type = DataTypeEnum.adLongVarWChar;
            colName.Attributes = ColumnAttributesEnum.adColNullable;
            colName.ParentCatalog = _Catalog;

            colMaterial.Name = "Material";
            colMaterial.Type = DataTypeEnum.adLongVarWChar;
            colMaterial.Attributes = ColumnAttributesEnum.adColNullable;
            colMaterial.ParentCatalog = _Catalog;

            colIsHazardous.Name = "IsHazardous";
            colIsHazardous.Type = DataTypeEnum.adLongVarWChar;
            colIsHazardous.Attributes = ColumnAttributesEnum.adColNullable;
            colIsHazardous.ParentCatalog = _Catalog;

            colHazardType.Name = "HazardType";
            colHazardType.Type = DataTypeEnum.adLongVarWChar;
            colHazardType.Attributes = ColumnAttributesEnum.adColNullable;
            colHazardType.ParentCatalog = _Catalog;

            colDescription.Name = "Description";
            colDescription.Type = DataTypeEnum.adLongVarWChar;
            colDescription.Attributes = ColumnAttributesEnum.adColNullable;
            colDescription.ParentCatalog = _Catalog;

            colRtf.Name = "Rtf";
            colRtf.Type = DataTypeEnum.adLongVarWChar;
            colRtf.Attributes = ColumnAttributesEnum.adColNullable;
            colRtf.ParentCatalog = _Catalog;

            colAttachment.Name = "Attachment";
            colAttachment.Type = DataTypeEnum.adLongVarWChar;
            colAttachment.Attributes = ColumnAttributesEnum.adColNullable;
            colAttachment.ParentCatalog = _Catalog;

            tblSlot.Name = _TableName;
            tblSlot.Columns.Append(colID);
            tblSlot.Columns.Append(colSlot);
            tblSlot.Columns.Append(colName);
            tblSlot.Columns.Append(colSlotDate);
            tblSlot.Columns.Append(colMaterial);
            tblSlot.Columns.Append(colIsHazardous);
            tblSlot.Columns.Append(colHazardType);
            tblSlot.Columns.Append(colDescription);
            tblSlot.Columns.Append(colRtf);
            tblSlot.Columns.Append(colAttachment);

            _Catalog.Tables.Append(tblSlot);
        }
    }
}
