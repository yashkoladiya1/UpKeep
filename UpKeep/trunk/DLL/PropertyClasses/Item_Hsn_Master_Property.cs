using System;

namespace DLL.PropertyClasses
{
    public class Item_Hsn_Master_Property
    {
        public long Hsn_ID { get; set; }
        public string Hsn_Code { get; set; }
        public string Hsn_Name { get; set; }
        public DateTime? Igst_Date { get; set; }
        public float Igst_Rate { get; set; }
        public DateTime? Sgst_Date { get; set; }
        public float Sgst_Rate { get; set; }
        public DateTime? Cgst_Date { get; set; }
        public float Cgst_Rate { get; set; }
        public int? Active { get; set; }
        public string Remark { get; set; }

    }
}
