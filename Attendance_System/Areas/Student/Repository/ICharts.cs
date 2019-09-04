using Attendance_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Attendance_System.Areas.Student.Repository
{
    /*No parameters and Returns Void*/
    public interface ICharts
    {
        void StudentChart(out string LectureList);
    }
}