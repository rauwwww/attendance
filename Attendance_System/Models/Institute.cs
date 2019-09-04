using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Attendance_System.Models
{
    public class Institute
    {
        public int InstituteId { get; set; }
        public string InstituteName { get; set; }
        public string ILogo { get; set; }

        public virtual ICollection<Course> Course { get; set; }

        public Institute(){}

        public Institute(int instituteId, string instituteName, string iLogo)
        {
            InstituteId = instituteId;
            InstituteName = instituteName;
            ILogo = iLogo;
        }
    }
}