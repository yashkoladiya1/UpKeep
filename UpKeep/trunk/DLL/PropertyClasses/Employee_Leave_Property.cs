using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.PropertyClasses
{
    public class Employee_Leave_Property
    {
        public int Employee_Leave_Id {get;set;}
        public int User_Id {get;set;}
        public DateTime Leave_Date {get;set;}
        public string Leave_Reason {get;set;}
        public string Leave_Type {get;set;}
        public int Active {get;set; }
        public int Add_By { get; set; }
        public int Edit_By { get; set; }
        public DateTime Add_Date {get;set;}
        public DateTime Edit_Date {get;set;}
    }
}
