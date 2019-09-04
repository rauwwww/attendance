using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Attendance_System.Models
{
    public class Lecture
    {
        public int LectureId { get; set; }
        public string LectureName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        public int CourseId { get; set; }
        public virtual ICollection<Attendance> Attendance { get;set; }
        public virtual Course Course { get; set; }
    }
}