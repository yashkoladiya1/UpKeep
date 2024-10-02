using System;

namespace DLL.PropertyClasses
{
    public class Ledger_Opening_Property
    {
        public long Ledger_Opening_ID { get; set; }
        public long Ledger_Code { get; set; }

        public long Company_Code { get; set; }

        public long Branch_Code { get; set; }

        public long Location_Code { get; set; }

        public long FIN_Year_Code { get; set; }
        public float Debit_AMT { get; set; }
        public float Credit_AMT { get; set; }
        public DateTime Opening_Date { get; set; }
    }
}
