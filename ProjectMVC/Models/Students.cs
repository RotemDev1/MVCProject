using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjectMVC.Models
{
    public class Students
    {
        [Key]
        [Required]

        public string Id { get; set; }
        

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string CourseId { get; set; }

        //[Required]
        //public string Course { get; set; }

        [Required]
        public string MoedA { get; set; }

        [Required]
        public string MoedB { get; set; }

        [Required]
        public string FinalGrade { get; set; }
    }
}
