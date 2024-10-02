using System;

namespace DLL.FunctionClasses
{
    public class Task_Master_Property
    {
        public long Task_ID { get; set; }
        public long? Module_ID { get; set; }
        public long? Assessment_ID { get; set; }
        public long? Location_ID { get; set; }
        public long? Sub_Assessment_ID { get; set; }
        public string Task_Name { get; set; }
        public string Description { get; set; }
        public long? Login_ID { get; set; }
        public long? Task_Login_ID { get; set; }
        public long? Frequency_ID { get; set; }
        public long? Priority_ID { get; set; }
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
        public int Flaged { get; set; }
        public string Task_Image_1 { get; set; }
        public string Task_Image_2 { get; set; }
        public string Task_Image_3 { get; set; }
        public string Task_Image_4 { get; set; }
        public string Task_Image_5 { get; set; }
    }
}
