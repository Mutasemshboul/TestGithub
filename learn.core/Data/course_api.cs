using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace learn.core.Data
{
    public class course_api
    {
        [Key] //Primary key
        public int courseid { get; set; }
        public string coursename { get; set; }
        public float? price { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public string imagename { get; set; }
        public int categoryid { get; set; }
    }
}
