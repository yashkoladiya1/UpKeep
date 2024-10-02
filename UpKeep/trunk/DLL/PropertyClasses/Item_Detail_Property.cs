namespace DLL.PropertyClasses
{
    public class Item_Detail_Property
    {
        public long Item_Detail_ID { get; set; }
        public long Item_Code { get; set; }

        public long Location_Code { get; set; }
        public float Reorder_Level { get; set; }
        public float Maximum_Reorder_Period { get; set; }
        public long Maximum_Consumption { get; set; }
        public long Noofdaysofstock { get; set; }
        public long Ordring_Qty { get; set; }
        public long Fin_Year_Code { get; set; }
    }
}
