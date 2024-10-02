using System;

namespace DLL.FunctionClasses
{
    public class Task_Transaction_Property
    {
        public long Transaction_ID { get; set; }
        public long? Task_ID { get; set; }
        public long? Module_ID { get; set; }
        public long? Schedule_ID { get; set; }
        public long? Status_ID { get; set; }
        public string Remarks { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public DateTime? Complete_Date { get; set; }
        public DateTime? Complete_Time { get; set; }
        public int? Active { get; set; }
        public DateTime? Entry_Date { get; set; }
        public DateTime? Entry_Time { get; set; }
        public string Entry_By { get; set; }
        public string Computer_By { get; set; }
        public string Computer_Name { get; set; }
        public int? Flaged { get; set; }
        public string EmpExpectedHours { get; set; }
        public int? Tested { get; set; }
        public string UserName { get; set; }
        public int Login_ID { get; set; }
        public int Testing_Done { get; set; }
    }
}
