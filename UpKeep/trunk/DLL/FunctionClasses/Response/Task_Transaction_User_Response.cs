using DLL.PropertyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.FunctionClasses.Response
{
    public class Task_Transaction_User_Response
    {
        public bool success { get; set; }
        public string msg { get; set; }
        //public Task_Transaction_Property data { get; set; }
        //public List<Task_Transaction_Property> data { get; set; }
        public List<Task_Transaction_User_Property> data { get; set; }
    }
}
