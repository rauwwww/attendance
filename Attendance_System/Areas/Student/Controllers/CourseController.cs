using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Attendance_System.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Attendance_System.DTO;
using Attendance_System.ViewModels;
using System.Data;
using System.Data.Entity;

namespace Attendance_System.Areas.Student.Controllers
{
    [Authorize(Roles = "Student")]
    public class CourseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Student/Course
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var studentCourse = new StudentCourseDTO();

            studentCourse.Enrollment = db.Enrollment
                .Include(e => e.Course)
                .Include(e => e.ApplicationUser)
                .Where(e => e.ApplicationUserId.Equals(userId));


            return View(studentCourse);

            /*var enrollments = db.Enrollment.Where(r => r.ApplicationUserId == userId).Where(r => r.CourseId == );
            IEnumerable<Course> course = new List<Course>();
            ViewBag.Invoices = enrollments;
             StudentCourse Course = new StudentCourse();
            Course.ApplicationUserID = userId;
            Course.Course = new List<Course>();
            ViewBag.Course = course;
                return View(orders.ToList());

            return View(users);*/
        }
    }
}       

