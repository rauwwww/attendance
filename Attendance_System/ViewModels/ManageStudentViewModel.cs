using Attendance_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Attendance_System.ViewModels
{
    public class ManageStudentViewModel
    {

        public string ApplicationUserID { get; set; }
        public List<string> Courses { get; set; }
        public string UserName { set; get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}