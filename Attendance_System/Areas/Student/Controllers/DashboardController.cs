using Attendance_System.Areas.Student.Repository;
using Attendance_System.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Attendance_System.Areas.Student.Controllers
{
    [Authorize(Roles = "Student")]
    public class DashboardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Student/Lectures
        public async Task<ActionResult> Dashboard()
        {

            DateTime dtNow = DateTime.Now;
            var startDt = dtNow.AddMinutes(-300);
            var endDt = dtNow.AddMinutes(300);

            //12/12/2019 7:00:00 PM
            //12 / 12 / 2019 9:00:00 PM

            var lecture = db.Lecture.Include(l => l.Course).Where(l => l.StartTime >= startDt && l.EndTime <= endDt);

            if (!lecture.Any())
            {
                ViewBag.message = null;
                return View();
            }

            ViewBag.message = "there is something to attend";

            return View(await lecture.ToListAsync());
           
        }

        public async Task<ActionResult> Attend(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = await db.Lecture.FindAsync(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");

        }

        [HttpPost, ActionName("Attend")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AttendConfirmed(int id)
        {
            var userId = User.Identity.GetUserId();

            Attendance atn = new Attendance()
            {
                ApplicationUserId = userId,
                LectureId = id,
                ArrivalTime = DateTime.Now

            };

            db.Attendance.Add(atn);
            await db.SaveChangesAsync();
            return RedirectToAction("Dashboard");
        }

        [ChildActionOnly]
        public ActionResult NextLecture()
        {
            var lectures = db.Lecture.Include(l => l.Course).Where(l => l.StartTime > DateTime.Now).OrderBy(l => l.StartTime).FirstOrDefault();

            return PartialView("_NextLecture", lectures);
        }

        /*Instantiate ChartsConcrete*/
        ICharts _ICharts;
        public DashboardController()
        {
            _ICharts = new ChartsConcrete();
        }

        [HttpGet]
        public ActionResult _StudentChart()
        {
            try
            {
                
                string tempLecture = string.Empty;
                _ICharts.StudentChart(out tempLecture);
                ViewBag.LectureCount_List = tempLecture.Trim();

                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }


        // This controller calc user attendance but should be a stored procedure based on coursename 
        /* 
        [ChildActionOnly]
        public ActionResult MyAttendance()
        {
            // this sql should be added as a stored procedure with userId and CourseName as @parameters

            string query = "SELECT CAST(COUNT(Attendances.LectureId) as FLOAT) / CAST(8 AS FLOAT) as UserBackEndAttendance, " +
                "Courses.CourseName " +
                "FROM Lectures " +
                "JOIN Attendances ON Attendances.LectureId = Lectures.LectureId " +
                "JOIN AspNetUsers ON AspNetUsers.Id = Attendances.ApplicationUserId " +
                "JOIN Courses ON Lectures.CourseId = Courses.CourseId " +
                "WHERE Courses.CourseId = 1 " +
                "AND AspNetUsers.Id = '6' " +
                "GROUP BY Courses.CourseName";

            IEnumerable<BackendAttendPercentageViewModel> data = db.Database.SqlQuery<BackendAttendPercentageViewModel>(query);

            return View(data.ToList());
        }*/

    }
}