using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Training.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int courseId { get; set; }
        public string courseName { get; set; }
        public string CourseCode { get; set; }
        public bool isavailable { get; set; }
    }
}