using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjectMVC.Models;

namespace ProjectMVC.Dal
{
    public class CoursesDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Courses>().ToTable("Courses");
        }
        public DbSet<Courses> courses { get; set; }
    }
}
