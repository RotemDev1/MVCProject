using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Models
{
    public class Courses
    {
        [Key]
        [Required]
        public string CourseId { get; set; }

        [Required]
        public string Course { get; set; }

        [Required]
        public string LecturerId { get; set; }

        [Required]
        public string Day { get; set; }

        [Required]
        public string NumHours { get; set; }

        [Required]
        public string SHour { get; set; }

        [Required]
        public string EHour { get; set; }

        [Required]
        public string Classroom { get; set; }
    }
}

