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
    public class LecturerController : Controller
    {
        string connectionString = @"Data Source=DESKTOP-CUQJIQL;Initial Catalog=tempdb;Integrated Security=True";

        // GET: Lecturer
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult ErrorMessage()
        {
            return View();
        }

        public ActionResult LecturerPage()
        {


            var id = Session["Id"];
            List<Courses> sch = new List<Courses>();
            List<Users> use = new List<Users>();


            string mainconn = ConfigurationManager.ConnectionStrings["CoursesDal"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select Courses.CourseId, Courses.Course ,Courses.Day, Courses.SHour, Courses.EHour from Courses where Courses.LecturerId = " + id;
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
            DataTable dl = new DataTable();
            sda.Fill(dl);
            foreach (DataRow dr in dl.Rows)
            {
                Courses ctable = new Courses();

                ctable.CourseId = dr["CourseId"].ToString();
                ctable.Course = dr["Course"].ToString();
                ctable.Day = dr["Day"].ToString();
                ctable.SHour = dr["SHour"].ToString();
                ctable.EHour = dr["EHour"].ToString();
                sch.Add(ctable);
            }
            return View("ScheduleLecturerView", sch);
        }

        public ActionResult StudentsList()
        {


            string courId = Request.QueryString["value"].ToString();
            List<Students> sch = new List<Students>();

            string mainconn = ConfigurationManager.ConnectionStrings["StudentsDal"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select StudentsNew.Id ,StudentsNew.FirstName,StudentsNew.LastName,StudentsNew.CourseId, StudentsNew.MoedA, StudentsNew.MoedB ,StudentsNew.FinalGrade, Courses.Course from StudentsNew join Courses ON (Courses.CourseId=StudentsNew.CourseId) where StudentsNew.CourseId = " + courId;
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
            DataTable dl = new DataTable();
            sda.Fill(dl);
            foreach (DataRow dr in dl.Rows)
            {
                Students ctable = new Students();
                Courses cctable = new Courses();


                ctable.Id = dr["Id"].ToString();
                ctable.FirstName = dr["FirstName"].ToString();
                ctable.LastName = dr["LastName"].ToString();
                ctable.CourseId = dr["CourseId"].ToString();
                ctable.MoedA = dr["MoedA"].ToString();
                ctable.MoedB = dr["MoedB"].ToString();
                ctable.FinalGrade = dr["FinalGrade"].ToString();
                cctable.Course = dr["Course"].ToString();
                sch.Add(ctable);
            }
            return View("StudentsList", sch);
        }


        [HttpGet]
        public ActionResult Create()
        {
            var stuId = Request.QueryString["value"];
            StudentsDal dal = new StudentsDal();
            Students cr = dal.students.Find(stuId);
            dal.students.Remove(cr);
            dal.SaveChanges();

            return View(new Students());
        }

        [HttpPost]
        public ActionResult Create(Students students)
        {

            //tempdbEntities db = new tempdbEntities();

            //var a = db.StudentsNew.Where(x => x.MoedA == students.MoedA).FirstOrDefault();

            var stuId = Request.QueryString["value"];
            var Moed1= Request.QueryString["MoedA"];
            var Moed2 = Request.QueryString["MoedB"];

            var name = Request.QueryString["FirstName"];
            var lastname = Request.QueryString["LastName"];
            var courseId = Request.QueryString["CourseId"];

            List<Students> sch = new List<Students>();
         
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                
                sqlCon.Open();
                string query = "Insert Into StudentsNew Values(@Id,@FirstName,@LastName,@CourseId, @MoedA,@MoedB,@FinalGrade)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@Id", stuId);
                sqlCmd.Parameters.AddWithValue("@FirstName", name);
                sqlCmd.Parameters.AddWithValue("@LastName", lastname);
                sqlCmd.Parameters.AddWithValue("@CourseId", courseId);
                sqlCmd.Parameters.AddWithValue("@MoedA", students.MoedA);
               
                if (Moed1 != null)
                {
                sqlCmd.Parameters.AddWithValue("@MoedB", students.MoedB);
                sqlCmd.Parameters.AddWithValue("@FinalGrade", students.FinalGrade);
                sqlCmd.ExecuteNonQuery();
                return RedirectToAction("Login", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "MoedA not found";
                    sqlCmd.Parameters.AddWithValue("@MoedB", "NULL");
                    sqlCmd.Parameters.AddWithValue("@FinalGrade", "NULL");
                    sqlCmd.ExecuteNonQuery();
                    return RedirectToAction("ErrorMessage", "Lecturer");
                }

                
            }
        }

        }
    
}