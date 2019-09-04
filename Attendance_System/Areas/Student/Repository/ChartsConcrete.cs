using Attendance_System.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Data;



namespace Attendance_System.Areas.Student.Repository
{
    public class ChartsConcrete : ICharts
    {
        public void StudentChart( out string LectureList)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
               
                /*var CourseName = (from temp in db.Course
                                         select temp.CourseId).ToList();*/
                

                /*Selects the number of lectures you have pr. course*/
                var LectureCount = (from temp in db.Lecture
                                    group temp.LectureId by temp.CourseId into tempg
                                    select tempg.Count()).ToList();

                /*CourseList = string.Join(",", CourseName); */

                 LectureList = string.Join(",", LectureCount);
            }
        }


    }
}