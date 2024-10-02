using System;

namespace DLL.FunctionClasses
{
    public class User_Catogry_Master_Property
    {
        public long Catogry_ID { get; set; }
        public string Catogry_Name { get; set; }
        public int? Active { get; set; }
        public DateTime? Entry_Date { get; set; }
        public DateTime? Entry_Time { get; set; }
        public string Entry_By { get; set; }
        public string Computer_IP { get; set; }
        public string Computer_Name { get; set; }
        public string Remark { get; set; }
    }
}
