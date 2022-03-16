using ProjectMVC.Dal;
using ProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectMVC.Controllers
{
public class CourseController : Controller
{
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }
}
}

