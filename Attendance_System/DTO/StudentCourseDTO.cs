using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Attendance_System.Models;

namespace Attendance_System.DTO
{
    public class StudentCourseDTO
    {
        public string ApplicationUserID { get; set; }
        public List<Course> courses = new List<Course>();

        public virtual ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<Enrollment> Enrollment { get; set; }
        public IEnumerable<Course> Course { get; set; }
    }
}