using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Training.Models
{
    public class MVCtrainingDbContext :DbContext 
    {
        public MVCtrainingDbContext() :base("MVCtrainingConnectionString")
        {

        }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Course> courses { get; set; }
    }
}