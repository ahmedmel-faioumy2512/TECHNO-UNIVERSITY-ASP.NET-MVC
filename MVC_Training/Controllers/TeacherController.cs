using MVC_Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Training.Controllers
{
    public class TeacherController : Controller
    {
        MVCtrainingDbContext myDB = new MVCtrainingDbContext();

        public ActionResult Index()
        {
            List<Teacher> teacherList = new List<Teacher>();
            teacherList = (from obj in myDB.teachers
                           select obj).ToList();

            return View(teacherList);
        }

        [HttpGet]
        public ActionResult InsertTeacher()
        {


            return View();
        }

        [HttpPost]
        public ActionResult InsertTeacher(Teacher teacher)
        {

            myDB.teachers.Add(teacher);
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTeacher(int id)
        {
            Teacher obj = new Teacher();
            obj = (from data in myDB.teachers
                   where data.teacherId == id
                   select data).FirstOrDefault();

            myDB.teachers.Remove(obj);
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetDetails(int id)
        {
            Teacher obj = new Teacher();
            obj = (from data in myDB.teachers
                   where data.teacherId == id
                   select data).FirstOrDefault();

            return View("Details", obj);
        }
    }
}