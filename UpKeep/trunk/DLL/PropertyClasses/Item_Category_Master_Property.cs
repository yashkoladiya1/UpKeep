namespace DLL.PropertyClasses
{
    public class Item_Category_Master_Property
    {
        public long Item_Category_Code { get; set; }
        public string Item_Category_Name { get; set; }
        public int? Active { get; set; }
        public int? IS_Consumable { get; set; }
        public int? IS_Repairable { get; set; }
        public string Remark { get; set; }
    }
}
