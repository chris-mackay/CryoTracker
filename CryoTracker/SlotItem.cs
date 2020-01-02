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
