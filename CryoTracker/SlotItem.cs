using System;

namespace CryoTracker
{
    class SlotItem
    {
        private string _Slot;
        private string _Name;
        private string _Material;
        private string _Description;
        private string _Rtf;
        private string _HazardType;
        private string _Attachment;

        public int ID { get; set; }
        public string Slot { get { return _Slot; } set { _Slot = value.Replace("'", ""); } }
        public string Name { get { return _Name; } set { _Name = value.Replace("'", ""); } }
        public DateTime StoredDate { get; set; }
        public string Material { get { return _Material; } set { _Material = value.Replace("'", ""); } }
        public string Description { get { return _Description; } set { _Description = value.Replace("'", ""); } }
        public string Rtf { get { return _Rtf; } set { _Rtf = value.Replace("'", ""); } }
        public bool IsHazardous { get; set; }
        public string HazardType { get { return _HazardType; } set { _HazardType = value.Replace("'", ""); } }
        public string Attachment
        {
            get { return _Attachment; }
            set
            {
                _Attachment = value.Replace("'", "");
                _Attachment = value.Replace("/", "");
            }
        }
    }
}
