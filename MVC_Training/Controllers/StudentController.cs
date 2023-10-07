using MVC_Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Training.Controllers
{
    public class StudentController : Controller
    {
        MVCtrainingDbContext myDB = new MVCtrainingDbContext();

        public ActionResult Index()
        {
            List<Student> studentList = new List<Student>();
            studentList = (from obj in myDB.students
                           select obj).ToList();

            return View(studentList);
        }

        [HttpGet]
        public ActionResult InsertStudent()
        {


            return View();
        }

        [HttpPost]
        public ActionResult InsertStudent(Student student)
        {

            myDB.students.Add(student);
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteStudent(int id)
        {
           Student obj = new Student();
            obj = (from data in myDB.students
                   where data.studentId == id
                   select data).FirstOrDefault();

            myDB.students.Remove(obj);
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetDetails(int id)
        {
           Student obj = new Student();
            obj = (from data in myDB.students
                   where data.studentId == id
                   select data).FirstOrDefault();

            return View("Details", obj);
        }
    }
}