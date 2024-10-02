using DLL.PropertyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.FunctionClasses.Response
{
    public class User_Working_Hour_Response
    {
        public bool success { get; set; }
        public string msg { get; set; }
        //public User_Working_Hour_Property data { get; set; }
        public List<User_Working_Hour_Property> data { get; set; }
    }
}
