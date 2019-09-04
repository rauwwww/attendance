using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Attendance_System.ViewModels
{
    public class AttendanceViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}