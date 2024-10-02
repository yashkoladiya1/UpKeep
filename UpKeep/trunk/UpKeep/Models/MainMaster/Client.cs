using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UpKeep.Models.MainMaster
{
    public class Client
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ServerIP { get; set; }
        public string DataBaseName { get; set; }
        public string url { get; set; }
        public string connectionString { get; set; }
        public string Logo_Path { get; set; }
        public int City_ID { get; set; }
        public int State_ID { get; set; }
        public int Country_ID { get; set; }
        public string Client_Name { get; set; }
    }
}
