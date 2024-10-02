using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.PropertyClasses
{
    public class User_Task_Assigned_Hour_Property
    {
        public string UserName { get; set; }
        public int TotalHours { get; set; } 
        public decimal AssignedHours { get; set; }
        public decimal Per { get; set; }
        public int WorkingStatus { get; set; }

    }
}
