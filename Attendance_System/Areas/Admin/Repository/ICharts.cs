using Attendance_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Attendance_System.Areas.Admin.Repository
{
    public interface ICharts
    {
        void AdminChart(out string StudentList, out string LectureList);
    }
}