using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Attendance_System.Areas;

namespace Attendance_System.Controllers
{
    
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return RedirectToAction("Dashboard", "Dashboard", new { area = "Admin" });
            else if (User.IsInRole("Teacher"))
                return RedirectToAction("Dashboard", "Dashboard", new { area = "Teacher" });
            else if (User.IsInRole("Student"))
                return RedirectToAction("Dashboard", "Dashboard", new { area = "Student" });
            else
                return View("../Account/Login");
        }

    }
}