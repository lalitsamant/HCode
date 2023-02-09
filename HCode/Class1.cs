using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCode
{
    public class Activity
    {
        public string ActRef { get; set; }
        public string ActDate { get; set; }
        public string ActActivity { get; set; }
    }

    public class ActClass
    {
        public string ActRef { get; set; }
        public string ActStartdate { get; set; }
        public string ActEnddate { get; set; }
        public string ActWeekPattern { get; set; }
        public string Activity { get; set; }

    }
}
