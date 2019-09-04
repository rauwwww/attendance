using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Attendance_System.DTO
{
    public class UserDto
    {
        public string ApplicationUserId { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { set; get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Roles { set; get; }
    
    }
}