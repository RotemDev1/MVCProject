using ProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMVC.ViewModel
{
    public class StudentsViewModel
    {
        public Students student { get; set; }
        public List<Students> students { get; set; }

    }
}