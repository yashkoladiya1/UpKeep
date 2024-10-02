using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLL.PropertyClasses
{
    public class PurchaseMaster_Property
    {
        public Int64 Purchase_Master_ID { get; set; }
        public Int64 Purchase_Detail_ID { get; set; }
        public string Invoice_Date { get; set; }
        public string Tran_Date { get; set; }
        public string Invoice_No { get; set; }
        public string Payment_Type { get; set; }
        public string Challan_No { get; set; }
        public int Party_Code { get; set; }
        public string Terms { get; set; }
        public string DueDate { get; set; }
        public bool IsTaxPayable { get; set; }
        public int Item_Code { get; set; }
        public int Unit { get; set; }
        public int QTY { get; set; }
        public int HSN { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public double Disc { get; set; }
        public double SGSTAmt { get; set; }
        public double SGSTRate { get; set; }
        public double CGSTAmt { get; set; }
        public double CGSTRate { get; set; }
        public double IGSTAmt { get; set; }
        public double IGSTRate { get; set; }
        public double Net_Amt { get; set; }
        public string Remarks { get; set; }
    }
}
