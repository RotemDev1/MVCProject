using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjectMVC.Models;

namespace ProjectMVC.Dal
{
    public class StudentsDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Students>().ToTable("StudentsNew");
        }
        public DbSet<Students> students { get; set; }
        //public object Course { get; internal set; }
        //public System.Data.Entity.DbSet<ProjectMVC.Models.Courses> Courses { get; set; }
    }
}
