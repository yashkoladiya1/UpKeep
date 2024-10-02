namespace DLL.PropertyClasses
{
    public class Item_Master_Property
    {
        public long Item_Code { get; set; }
        public long Company_Code { get; set; }

        public long Branch_Code { get; set; }

        public long Location_Code { get; set; }
        public string Item_Name { get; set; }
        public string Item_Shortname { get; set; }
        public long Item_Group_Code { get; set; }
        public long Item_Category_Code { get; set; }
        public int? Active { get; set; }
        public string Remark { get; set; }
        public float Reorder_Level { get; set; }
        public string Unit_Code { get; set; }
        public float Last_Purchase_Rate { get; set; }
        public string Item_Codification { get; set; }
        public float Disc_Per { get; set; }
        public long Hsn_ID { get; set; }
        public float Sale_Rate { get; set; }
        public int? Stock_Limit { get; set; }
        public int? Pcs_In_Box { get; set; }

    }
}
