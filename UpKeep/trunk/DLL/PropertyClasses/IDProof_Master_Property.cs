using System;

namespace DLL.FunctionClasses
{
    public class IDProof_Master_Property
    {
        public int IDProof_ID { get; set; }
        public int Module_ID { get; set; }
        public string IDProof_Name { get; set; }
        public int? Active { get; set; }
        public string Remark { get; set; }
        public DateTime? Entry_Date { get; set; }
        public DateTime? Entry_Time { get; set; }
        public string Entry_By { get; set; }
        public string Computer_IP { get; set; }
        public string Computer_Name { get; set; }
    }
}
