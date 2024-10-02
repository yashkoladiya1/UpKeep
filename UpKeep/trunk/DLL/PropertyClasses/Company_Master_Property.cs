namespace DLL.PropertyClasses
{
    public class Company_Master_Property
    {
        public long Company_code { get; set; }

        public string Company_name { get; set; }
        public string Contact_Person { get; set; }
        public string Website { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
        public int? Country_Code { get; set; }

        public int? State_Code { get; set; }
        public int? City_Code { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Remark { get; set; }
        public string Active { get; set; }

    }
}
