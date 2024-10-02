using System;

namespace DLL.FunctionClasses
{
    public class City_Master
    {
        InterfaceLayer Ope = new InterfaceLayer();
        public Int32 Country_Id { get; set; }
        public string Country_Name { get; set; }
        public Int32 State_Id { get; set; }
        public string State_Name { get; set; }
        public Int32 City_Id { get; set; }
        public string City_Name { get; set; }
        public Int32 Location_ID { get; set; }
        public string Location_Name { get; set; }
    }
}
