using Attendance_System.Areas.Admin.Repository;
using Attendance_System.DTO;
using Attendance_System.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Attendance_System.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult NextLecture()
        {
            var lectures = db.Lecture.Include(l => l.Course).Where(l => l.StartTime > DateTime.Now).OrderBy(l => l.StartTime).FirstOrDefault();

            return PartialView("_NextLecture", lectures);
        }

        public ActionResult LoadStudents()
        {
            var data = (from u in db.Users
                        from ur in db.Set<IdentityUserRole>()
                        where ur.UserId.Equals(u.Id)
                        where ur.RoleId == "3"
                        join ro in db.Roles on ur.RoleId equals ro.Id

                        select new UserDto
                        {
                            ApplicationUserId = u.Id,

                        }).Count();

            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadTeachers()
        {
            var data = (from u in db.Users
                        from ur in db.Set<IdentityUserRole>()
                        where ur.UserId.Equals(u.Id)
                        where ur.RoleId == "2"
                        join ro in db.Roles on ur.RoleId equals ro.Id

                        select new UserDto
                        {
                            ApplicationUserId = u.Id,

                        }).Count();

            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadAdmins()
        {
            var data = (from u in db.Users
                        from ur in db.Set<IdentityUserRole>()
                        where ur.UserId.Equals(u.Id)
                        where ur.RoleId == "1"
                        join ro in db.Roles on ur.RoleId equals ro.Id

                        select new UserDto
                        {
                            ApplicationUserId = u.Id,

                        }).Count();

            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadAllUsers()
        {
            var data = (from u in db.Users
                        from ur in db.Set<IdentityUserRole>()
                        where ur.UserId.Equals(u.Id)
                        join ro in db.Roles on ur.RoleId equals ro.Id

                        select new UserDto
                        {
                            ApplicationUserId = u.Id,

                        }).Count();

            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        ICharts _ICharts;
        public DashboardController()
        {
            _ICharts = new ChartsConcrete();
        }

        [HttpGet]
        public ActionResult _AdminChart()
        {
            try
            {
                string tempCourse = string.Empty;
                string tempStudent = string.Empty;
                _ICharts.AdminChart(out tempCourse, out tempStudent);
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