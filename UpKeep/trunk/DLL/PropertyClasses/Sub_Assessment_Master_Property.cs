using System;

namespace DLL.FunctionClasses
{
    public class Sub_Assessment_Master_Property
    {
        public long Sub_Assessment_ID { get; set; }
        public long? Module_ID { get; set; }
        public long? Assesment_ID { get; set; }
        public long? Location_ID { get; set; }
        public string Sub_Assessment_Name { get; set; }
        public int? Active { get; set; }
        public DateTime? Entry_Date { get; set; }
        public DateTime? Entry_Time { get; set; }
        public string Entry_By { get; set; }
        public string Computer_IP { get; set; }
        public string Computer_Name { get; set; }
        public string Remark { get; set; }

    }
}
