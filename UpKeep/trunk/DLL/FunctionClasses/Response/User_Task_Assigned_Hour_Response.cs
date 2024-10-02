using DLL.PropertyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.FunctionClasses.Response
{
    public class User_Task_Assigned_Hour_Response
    {
        public bool success { get; set; }
        public string msg { get; set; } 
        public List<User_Task_Assigned_Hour_Property> data { get; set; }
    }
}
