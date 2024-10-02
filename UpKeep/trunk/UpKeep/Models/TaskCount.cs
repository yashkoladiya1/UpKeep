using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UpKeep.Models
{
    public class TaskCount
    {
        public string ModuleName { get; set; }
        public string TotalTask { get; set; }
        public string CompletedTask { get; set; }
    }
}