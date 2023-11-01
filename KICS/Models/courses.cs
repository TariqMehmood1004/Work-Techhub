using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KICS.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string description { get; set; }
        public string instructor { get; set; }
        public string dues { get; set; }
        public string created_date { get; set; }
    }

}