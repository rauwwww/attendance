using Attendance_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Attendance_System.Areas.Teacher.Repository
{
    public interface ICharts
    {
        void TeacherChart(out string StudentList, out string LectureList);
    }
}