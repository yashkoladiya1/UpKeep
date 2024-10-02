using System;
namespace DLL.FunctionClasses
{
    public class Country_Master_Property
    {
        public int Country_ID { get; set; }
        public string Country_Name { get; set; }
        public int Active { get; set; }
        public string Remark { get; set; }

        public Int64 ID { get; set; }
        public string Bank_Name { get; set; }
        public string Bank_IFSC { get; set; }
        public string Bank_Address { get; set; }
        public string Bank_Branch { get; set; }
    }
}
