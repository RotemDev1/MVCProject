using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Models
{
    public class Exams
    {
        [Key]
        [Required]
        public string CourseId { get; set; }
        [Required]
        public string Course { get; set; }
        [Required]
        public string DateMoedA { get; set; }

        [Required]
        public string ShouerExamA { get; set; }

        [Required]
        public string EhouerExamA { get; set; }

        [Required]
        public string DateMoedB { get; set; }

        [Required]
        public string ShouerExamB { get; set; }

        [Required]
        public string EhouerExamB { get; set; }

        [Required]
        public string Classroom { get; set; }



    }
}