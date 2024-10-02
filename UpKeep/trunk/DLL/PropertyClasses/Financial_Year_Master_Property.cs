using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLL.PropertyClasses
{
   public class Financial_Year_Master_Property
    {
        public long FIN_Year_Code { get; set; }
        public string Financial_Year { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public string Short_Name { get; set; }
        public int? Active { get; set; }
        public long Start_Yearmonth { get; set; }
        public long End_Yearmonth { get; set; }
   }
}
