using System;

namespace DLL.FunctionClasses
{
    public class Schedule_Master_Property
    {
        public long Schedule_ID { get; set; }
        public long? Task_ID { get; set; }
        public long? Login_ID { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public DateTime? Start_Time { get; set; }
        public DateTime? End_Time { get; set; }
        public string Status { get; set; }
        public int? Active { get; set; }
        public DateTime? Entry_Date { get; set; }
        public DateTime? Entry_Time { get; set; }
        public string Entry_By { get; set; }
        public string Computer_IP { get; set; }
        public string Computer_Name { get; set; }
        public string Remark { get; set; }
    }
}
