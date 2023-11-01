using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KICS.Models
{
    public class ApplicationForm
    {
        public string formId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Dob { get; set; }
        public string StudentImages { get; set; }
        public string Qualifications { get; set; }
        public string FatherNames { get; set; }
        public string StudentAddress { get; set; }
        public int StudentCourseId { get; set; }
        public string StudentPhones { get; set; }
        public string FatherPhones { get; set; }
        public string Timings { get; set; }
        public int OfficeFees { get; set; }
        public int Discount { get; set; }
        public int UsersId { get; set; }
    }
}