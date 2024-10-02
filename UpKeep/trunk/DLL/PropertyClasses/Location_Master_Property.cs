using System;

namespace DLL.PropertyClasses
{
    public class Location_Master_Property
    {
        public long Location_ID { get; set; }
        public string Location_Name { get; set; }
        public int? Active { get; set; }
        public DateTime? Entry_Date { get; set; }
        public DateTime? Entry_Time { get; set; }
        public string Entry_By { get; set; }
        public string Computer_IP { get; set; }
        public string Computer_Name { get; set; }
        public string Remark { get; set; }

    }
}
