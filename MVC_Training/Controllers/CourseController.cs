using MVC_Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Training.Controllers
{
    
    public class CourseController : Controller
    {
        MVCtrainingDbContext myDB = new MVCtrainingDbContext();

        public ActionResult Index()
        {
            List<Course> courseList = new List<Course>();

            courseList = (from obj in myDB.courses
                          select obj).ToList();

            return View(courseList);
        }

        public ActionResult GetCourse(int id)
        {
            Course obj = new Course();
            obj = (from xyz in myDB.courses
                   where xyz.courseId == id
                   select xyz).FirstOrDefault();

            return View("Details", obj);
        }

        [HttpGet]
        public ActionResult InsertCourse()
        {
            

            return View();
        }

        [HttpPost]
        public ActionResult InsertCourse(Course course)
        {
            myDB.courses.Add(course);
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCourse(int id)
        {
            Course obj = new Course();
            obj = (from course in myDB.courses
                   where course.courseId == id
                   select course).FirstOrDefault();

            myDB.courses.Remove(obj);
            myDB.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult UpdateCourse(int id)
        {
            Course obj = new Course();
            obj = (from course in myDB.courses
                   where course.courseId == id
                   select course).FirstOrDefault();

            obj.courseName = "Text";
            obj.isavailable = false;

            myDB.SaveChanges();
            return View("Index");
        }
    }
}