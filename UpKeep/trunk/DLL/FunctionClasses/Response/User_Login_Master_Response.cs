using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.FunctionClasses.Response
{
    public class User_Login_Master_Response
    {
        public bool success { get; set; }
        public string msg { get; set; }
        public User_Login_Master_Property data { get; set; }
    }
}
