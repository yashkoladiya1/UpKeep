using System;

namespace DLL.FunctionClasses
{
    public class Visitor_Master_Property
    {
        public long Visitor_ID { get; set; }
        public long? Module_ID { get; set; }
        public long? Assessment_ID { get; set; }
        public long? Location_ID { get; set; }
        public long? Sub_Assessment_ID { get; set; }
        public string Visitor_Name { get; set; }
        public long? IDProof_ID { get; set; }
        public string IDProff_Detail { get; set; }
        public string IDProff_Image { get; set; }
        public string Visitor_Image { get; set; }
        public long? Mobile_No { get; set; }
        public DateTime? Visit_In_Date { get; set; }
        public DateTime? Visit_Out_Date { get; set; }
        public DateTime? Intime { get; set; }
        public DateTime? OutTime { get; set; }
        public string Address { get; set; }
        public long? City_ID { get; set; }
        public long? State_ID { get; set; }
        public long? Country_ID { get; set; }
        public long? Pincode { get; set; }
        public string Contact_Person { get; set; }
        public string Remarks { get; set; }
        public int? Active { get; set; }
        public DateTime? Entry_Date { get; set; }
        public DateTime? Entry_Time { get; set; }
        public string Entry_By { get; set; }
        public string Computer_IP { get; set; }
        public string Computer_Name { get; set; }
    }
}
