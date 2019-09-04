using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Attendance_System.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Attendance_System.DTO;

namespace Attendance_System.Areas.Teacher.Controllers
{
    public class ChartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teacher/Chart
        public ActionResult LoadChartData()
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
    }
}