using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Attendance_System.Models;
using Microsoft.AspNet.Identity;

namespace Attendance_System.Areas.Student.Controllers
{
    public class LecturesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

        // GET: Student/Lectures
        public async Task<ActionResult> Index()
        {
            DateTime dtNow = DateTime.Now;
            var startDt = dtNow.AddMinutes(-300);
            var endDt = dtNow.AddMinutes(300);
            //12/12/2019 7:00:00 PM
            //12 / 12 / 2019 9:00:00 PM
            var lecture = db.Lecture.Include(l => l.Course).Where(l => l.StartTime >= startDt && l.EndTime <= endDt);
            return View(await lecture.ToListAsync());
        }

        public async Task<ActionResult> Attend(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = await db.Lecture.FindAsync(id);
            if (lecture== null)
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
            return RedirectToAction("Index");
        }

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
