using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Attendance_System.Models;

namespace Attendance_System.ViewModels
{
    public class CourseIndexData
    {
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Lecture> Lectures { get; set; }
        public IEnumerable<Attendance> Attendances { get; set; }
    }
}