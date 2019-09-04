using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Attendance_System.DTO
{
    public class CourseDTO
    {
        public string ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string CourseName { set; get; }
        public string Lecture { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public List<string> Courses { set; get; }
    }
}