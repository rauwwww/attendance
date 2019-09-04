using Attendance_System.Areas.Student.Repository;
using Attendance_System.Areas.Teacher.Repository;
using Attendance_System.DTO;
using Attendance_System.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Attendance_System.ViewModels;


namespace Attendance_System.Areas.Teacher.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class DashboardController : Controller
    {
        // GET: Teacher/Dashboard
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

        [ChildActionOnly]
        public ActionResult NextLecture()
        {
            var lectures = db.Lecture.Include(l => l.Course).Where(l => l.StartTime > DateTime.Now).OrderBy(l => l.StartTime).FirstOrDefault();

            return PartialView("_NextLecture", lectures);
        }

        public ActionResult ShowCurrenctLecture()
        {
            var userId = User.Identity.GetUserId();


            return View();
        }

        public ActionResult LoadData()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var data = (from u in db.Attendance
                            orderby u.ArrivalTime ascending

                            select new AttendanceViewModel
                            {
                                FirstName = u.ApplicationUser.FirstName,
                                LastName = u.ApplicationUser.LastName,
                                ArrivalTime = u.ArrivalTime

                            }).ToList();

                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
        }

        Repository.ICharts _ICharts;
            public DashboardController()
            {
                _ICharts = new Repository.ChartsConcrete();
            } 

        [HttpGet]
        public ActionResult _TeacherChart()
        {
            try
            {
                string tempCourse = string.Empty;
                string tempStudent = string.Empty;
                _ICharts.TeacherChart(out tempCourse, out tempStudent);
                ViewBag.CourseName_List = tempCourse.Trim();
                ViewBag.StudentCount_List = tempStudent.Trim();

                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}