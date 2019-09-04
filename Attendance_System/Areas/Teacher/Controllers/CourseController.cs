using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Attendance_System.Models;
using Attendance_System.ViewModels;

namespace Attendance_System.Areas.Teacher.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int? id, int? lectureID)
        {
            var viewModel = new CourseIndexData();
            viewModel.Courses = db.Course
                .Include(i => i.Institute);

            if (id != null)
            {
                ViewBag.CourseId = id.Value;
                viewModel.Lectures = db.Lecture.Where(
                    i => i.CourseId == id.Value);
            }

            if (lectureID != null)
            {
                ViewBag.LectureId = lectureID.Value;
                viewModel.Attendances = db.Attendance.Where(
                    i => i.LectureId == lectureID.Value);
            }

            return View(viewModel);
        }

        // Apparently not required
        //.Include(i => i.Lecture.Select(c => c.Course

        //if (id != null)
        //{
        //    ViewBag.CourseId = id.Value;
        //    viewModel.Lectures = viewModel.Courses.Where(
        //        i => i.CourseId == id.Value).Single().Lecture;
        //}

        // Does same as above but in simpler code


        //if (lectureID != null)
        //{
        //    ViewBag.LectureId = lectureID.Value;
        //    viewModel.Attendances = viewModel.Lectures.Where(
        //        i => i.LectureId == lectureID.Value).Single().Attendance;
        //}

        // Does same as above but in simpler code

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
