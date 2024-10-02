using System;

namespace DLL.FunctionClasses
{
    public class Work_Request_Property
    {
        public long Request_ID { get; set; }
        public string Request_Name { get; set; }
        public string Request_By { get; set; }
        public string Request_To { get; set; }
        public string Request_Module_By { get; set; }
        public string Request_Module_To { get; set; }
        public long? Category_ID { get; set; }
        public long? Priority_ID { get; set; }
        public long? Request_Status_ID { get; set; }
        public string Remarks { get; set; }
        public DateTime? Complete_Date { get; set; }
        public DateTime? Complete_Time { get; set; }
        public int? Active { get; set; }
        public DateTime? Entry_Date { get; set; }
        public DateTime? Entry_Time { get; set; }
        public string Entry_By { get; set; }
        public string Computer_IP { get; set; }
        public string Computer_Name { get; set; }
        public string Remark { get; set; }
    }
}
