using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Attendance_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Attendance_System.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Course Course { get; set; }

        // CONSTRUCTORS
        public Enrollment() { }

        public Enrollment(int enrollmentId, Course course, ApplicationUser applicationUser)
        {
            EnrollmentId = enrollmentId;
            Course = course;
            ApplicationUser = applicationUser;
        }
    } 
}