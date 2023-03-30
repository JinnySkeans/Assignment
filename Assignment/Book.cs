using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    //class to set and get the stroing for future use
    public class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public string year { get; set; }
        public string publisher { get; set; }
        public int isbn { get; set; }
        public string category { get; set; }
        public string checked_out_by { get; set; }
        public string due_date { get; set; }
        public string renew { get; set; }

    }
}
