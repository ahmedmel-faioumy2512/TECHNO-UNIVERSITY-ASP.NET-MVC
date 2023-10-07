using MVC_Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Training.Controllers
{
    public class RoomController : Controller
    {
        MVCtrainingDbContext myDB = new MVCtrainingDbContext();

        public ActionResult Index()
        {
            List<Room> roomList = new List<Room>();

            roomList = (from obj in myDB.rooms
                          select obj).ToList();

            return View(roomList);
        }

        public ActionResult GetDetails(int id)
        {
            Room obj = new Room();
            obj = (from room in myDB.rooms
                   where room.roomID == id
                   select room).FirstOrDefault();

            return View("RoomDetails",obj);
        }

        [HttpGet]
        public ActionResult InsertRoom()
        {
            

            return View();
        }

        [HttpPost]
        public ActionResult InsertRoom(Room room)
        {
            myDB.rooms.Add(room);
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteRoom(int id)
        {
            Room obj = new Room();
            obj = (from course in myDB.rooms
                   where course.roomID == id
                   select course).FirstOrDefault();

            myDB.rooms.Remove(obj);
            myDB.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult UpdateRoom(int id)
        {
            Room obj = new Room();
            obj = (from room in myDB.rooms
                   where room.roomID == id
                   select room).FirstOrDefault();

            obj.roomName = "Text";
            obj.isAvailable= false;

            myDB.SaveChanges();
            return View("Index");
        }
    }
}