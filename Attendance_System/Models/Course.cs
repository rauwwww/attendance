using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Attendance_System.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string EducationName { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public virtual Institute Institute { get; set; }
        public virtual ICollection<Lecture> Lecture { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }

        public Course (){}
    }

}