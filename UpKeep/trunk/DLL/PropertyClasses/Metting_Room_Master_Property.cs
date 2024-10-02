using System;

namespace DLL.FunctionClasses
{
    public class Metting_Room_Master_Property
    {
        public long Metting_ID { get; set; }
        public long? Module_ID { get; set; }
        public long? Assessment_ID { get; set; }
        public long? Location_ID { get; set; }
        public long? Sub_Assessment_ID { get; set; }
        public string Metting_Name { get; set; }
        public long? Login_ID { get; set; }
        public string Description { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public DateTime? Start_Time { get; set; }
        public DateTime? End_Time { get; set; }
        public int? Active { get; set; }
        public DateTime? Entry_Date { get; set; }
        public DateTime? Entry_Time { get; set; }
        public string Entry_By { get; set; }
        public string Computer_IP { get; set; }
        public string Computer_Name { get; set; }
        public string Remark { get; set; }
    }
}
