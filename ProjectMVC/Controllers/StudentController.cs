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
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudentPage()
        {
            var id = Session["Id"];
            List<Courses> sch = new List<Courses>();
            string mainconn = ConfigurationManager.ConnectionStrings["CoursesDal"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select Courses.CourseId ,Courses.Course,Courses.Day, Courses.SHour, Courses.EHour from Courses, StudentsNew where StudentsNew.Id=" + id + " and StudentsNew.CourseId = Courses.CourseId";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Courses ctable = new Courses();

                ctable.CourseId = dr["CourseId"].ToString();
                ctable.Course = dr["Course"].ToString();
                ctable.Day = dr["Day"].ToString();
                ctable.SHour = dr["SHour"].ToString();
                ctable.EHour = dr["EHour"].ToString();
                sch.Add(ctable);
            }
            return View("ScheduleView", sch);
          
        }

        public ActionResult ExamsList()
        {

            string courId = Request.QueryString["value"].ToString();
            List<Exams> sch = new List<Exams>();

            string mainconn = ConfigurationManager.ConnectionStrings["ExamsDal"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select Exam.CourseId ,Exam.Course ,Exam.DateMoedA,Exam.ShouerExamA,Exam.EhouerExamA, Exam.DateMoedB, Exam.ShouerExamB ,Exam.EhouerExamB, Exam.Classroom from Exam where Exam.CourseId = " + courId;
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
            DataTable dl = new DataTable();
            sda.Fill(dl);
            foreach (DataRow dr in dl.Rows)
            {
                Exams ctable = new Exams();
                Courses cctable = new Courses();

                ctable.CourseId = dr["CourseId"].ToString();
                ctable.Course = dr["Course"].ToString();
                ctable.DateMoedA = dr["DateMoedA"].ToString();
                ctable.ShouerExamA = dr["ShouerExamA"].ToString();
                ctable.EhouerExamA = dr["EhouerExamA"].ToString();
                ctable.DateMoedB = dr["DateMoedB"].ToString();
                ctable.ShouerExamB = dr["ShouerExamB"].ToString();
                ctable.EhouerExamB = dr["EhouerExamB"].ToString();
                ctable.Classroom = dr["Classroom"].ToString();
                sch.Add(ctable);
            }
            return View("ExamsList", sch);
        }
    }
}
















//namespace ProjectMVC.Controllers
//{
//    public class StudentController : Controller
//    {
//        // GET: Student
//        public ActionResult Index()
//        {
//            return View();
//        }
//        public ActionResult StudentPage()
//        {
//            StudentsDal dal = new StudentsDal();
//            List<Students> objStudents = dal.students.ToList<Students>();

//            StudentsViewModel svm = new StudentsViewModel();
//            svm.student = new Students();
//            svm.students = objStudents;
//            //svm.students = new List<Students>();
//            return View("StudentPage", svm);
//        }
//    }
//}