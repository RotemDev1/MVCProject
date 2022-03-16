using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Models
{
    public class Users
    {
        [Key]
        [Required]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "Id must have 9 digits")]
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 15")]
        public string Password { get; set; }

        [Required]
        public string Permission { get; set; }
    }
}
