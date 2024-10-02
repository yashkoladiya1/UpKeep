using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.PropertyClasses
{
    public class Task_Transaction_User_Property
    {

        public long Transaction_ID { get; set; }
        public int? Imp { get; set; }
        public string Main { get; set; }
        public string Sub { get; set; }
        public string Module { get; set; }
        public string Loc { get; set; }
        public string Task_Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public Int64 Given_By { get; set; }
        public String StartDate { get; set; } 
        public String EndDate { get; set; }  
        public TimeSpan StartTime { get; set; }  
        public TimeSpan EndTime { get; set; } 
        public Boolean Start_Stop { get; set; } 
        public int? Hours_Spend { get; set; }  
        public int? ExpCompletionHours { get; set; }
        public Boolean Start_Stop_Flag { get; set; }
        public Decimal EmpExpectedHours { get; set; }
        public string Task_Image_1 { get; set; }
        public string Task_Image_2 { get; set; }
        public string Task_Image_3 { get; set; }
        public string Task_Image_4 { get; set; }
        public string Task_Image_5 { get; set; }
        public Int64 Login_ID { get; set; }
    }
}
