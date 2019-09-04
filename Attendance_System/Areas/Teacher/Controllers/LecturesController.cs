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

namespace Attendance_System.Areas.Teacher.Controllers
{
    public class LecturesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teacher/Lectures
        public async Task<ActionResult> Index()
        {
            var lecture = db.Lecture.Include(l => l.Course);
            return View(await lecture.ToListAsync());
        }

        // GET: Teacher/Lectures/Details/5
        public async Task<ActionResult> Details(int? id)
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
            return View(lecture);
        }

        // GET: Teacher/Lectures/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "CourseName");
            return View();
        }

        // POST: Teacher/Lectures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LectureId,LectureName,Date,CourseId")] Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                db.Lecture.Add(lecture);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "CourseName", lecture.CourseId);
            return View(lecture);
        }

        // GET: Teacher/Lectures/Edit/5
        public async Task<ActionResult> Edit(int? id)
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
            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "CourseName", lecture.CourseId);
            return View(lecture);
        }

        // POST: Teacher/Lectures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LectureId,LectureName,Date,CourseId")] Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecture).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "CourseName", lecture.CourseId);
            return View(lecture);
        }

        // GET: Teacher/Lectures/Delete/5
        public async Task<ActionResult> Delete(int? id)
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
            return View(lecture);
        }

        // POST: Teacher/Lectures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Lecture lecture = await db.Lecture.FindAsync(id);
            db.Lecture.Remove(lecture);
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
