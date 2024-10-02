using System;

namespace DLL.FunctionClasses
{
    public class User_Login_Master_Property
    {
        public long Login_ID { get; set; }
        public long? Client_ID { get; set; }
        public string UserName { get; set; }
        //public long? UserID { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string EmailID { get; set; }
        public string Mac_ID { get; set; }
        public string Tokan { get; set; }
        public long? Mobile { get; set; }
        public long? Category_ID { get; set; }
        public string Category_Name { get; set; }
        public string User_Image { get; set; }
        public int? Active { get; set; }
        public DateTime? Entry_Date { get; set; }
        public DateTime? Entry_Time { get; set; }
        public string Entry_By { get; set; }
        public string Computer_IP { get; set; }
        public string Computer_Name { get; set; }
        public int Emp_ID { get; set; }
        public long? Module_ID { get; set; }
    }
}
