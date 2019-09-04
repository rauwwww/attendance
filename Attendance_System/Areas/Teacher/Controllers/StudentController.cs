using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Attendance_System.Models;
using Attendance_System.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Attendance_System.DTO;
using System.Threading.Tasks;
using System.Net;

namespace Attendance_System.Areas.Teacher.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Teacher/Student
        public ActionResult Index()
        {
            return View();
        }
        // Loads Student - Applicationuser into json on /LoadData

        public ActionResult LoadData()
        {       
            var data = (from u in db.Users
                        from ur in db.Set<IdentityUserRole>()
                        where ur.UserId.Equals(u.Id)
                        where ur.RoleId == "3"
                        join ro in db.Roles on ur.RoleId equals ro.Id

                        select new UserDto
                        {
                            UserName = u.UserName,
                            FirstName = u.FirstName,
                            Email = u.Email,
                            LastName = u.LastName,
                            ApplicationUserId = u.Id,

                        }).ToList();

            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(string id)
        {
            var model = new UserDto();

            var student = db.Users.First(u => u.Id == id);
            model.UserName = student.UserName;
            model.FirstName = student.FirstName;
            model.LastName = student.LastName;
            model.Email = student.Email;
            model.PhoneNumber = student.PhoneNumber;

            return View(model);
        }
    }
}
