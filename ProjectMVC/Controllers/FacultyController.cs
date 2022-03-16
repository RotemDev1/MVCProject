using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectMVC.Models;
using ProjectMVC.ViewModel;
using ProjectMVC.Dal;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace ProjectMVC.Controllers
{
    public class FacultyController : Controller
    {
        // GET: Faculty
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FacultyPage()
        {

            return View();
        }


        [HttpPost]
        public ActionResult FacultyPage(Courses obj)
        {
            //add new course to db
            Courses courses = new Courses()
            {
                CourseId = obj.LecturerId,
                Course = obj.Course,
                LecturerId = obj.LecturerId,
                Day = obj.Day,
                NumHours = obj.NumHours,
                SHour = obj.SHour,
                EHour = obj.EHour,
                Classroom = obj.Classroom
            };

            CoursesDal cd = new CoursesDal();
            cd.courses.Add(obj);
            cd.SaveChanges();


            return RedirectToAction("FacultyPage");
            //return View();
        }



        [HttpGet]
        public ActionResult FacultyManage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FacultyManage(Courses obj)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CoursesDal"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            // cmd.CommandText="UPDATE Courses SET Course= '" +txtCourse.

            return View();
        }

        public ActionResult getUsersByJson()
        {
            CoursesDal ud = new CoursesDal();
            return Json(ud.courses.ToList<Courses>(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteCourse()
        {
            if (Session["Log"] == null)
            {
                ViewBag.Error = "not logged";
                return View("~/Views/Home/NotLogged.cshtml");
            }
            if (Session["Log"].ToString() == "1")
            {
                CoursesDal cd = new CoursesDal();
                Courses co = new Courses()
                {
                    Course = Request.Form["Course"].ToString()

                };
                var customer = cd.courses.Single(o => o.Course == co.Course);

                cd.courses.Remove(customer);
                cd.SaveChanges();
            }
            return null;
        }

        public ActionResult FacultyAssignStudent()
        {
            return View();
        }
    }
}