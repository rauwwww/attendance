﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Attendance_System.Controllers
{
    
    public class StudentController : Controller
    {
        // GET: Student/Student
        public ActionResult Index()
        {
            return View();
        }
    }
}