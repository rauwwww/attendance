using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Attendance_System.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int LectureId { get; set; }
        public string ApplicationUserId { get; set; }
        public DateTime ArrivalTime { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Lecture Lecture { get; set; }     
    }
}
