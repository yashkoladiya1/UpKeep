namespace DLL.PropertyClasses
{
    public class Ledger_Master_Property
    {
        public long Ledger_Code { get; set; }
        public string Ledger_Name { get; set; }
        public string Party_Address { get; set; }
        public string Party_Pincode { get; set; }

        public int? Party_City_Code { get; set; }
        public int? Party_State_Code { get; set; }
        public int? Party_Country_Code { get; set; }
        public string Party_Phone { get; set; }
        public string Party_Mobile { get; set; }
        public string Party_Email { get; set; }
        public string Bank_Name { get; set; }
        public string Bank_Branch { get; set; }
        public string Bank_IFSC { get; set; }

        public string Bank_AccountNo { get; set; }
        public string Party_PanNo { get; set; }
        public string Party_Type { get; set; }
        public string Remarks { get; set; }
        public int? Active { get; set; }
        public string GSTIN { get; set; }
        public string GSTIN_Effective_Date { get; set; }



    }
}
