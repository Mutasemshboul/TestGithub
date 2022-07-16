using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.DTO
{
    public class emp_all_date
    {
        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public float salary { get; set; }
        public DateTime checkin { get; set; }
        public DateTime checkout { get; set; }
        public string departmentname { get; set; }
    }
}
