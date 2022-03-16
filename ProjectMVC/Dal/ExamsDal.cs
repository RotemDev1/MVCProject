using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjectMVC.Models;

namespace ProjectMVC.Dal
{
    public class ExamsDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Exams>().ToTable("Exam");
        }
        public DbSet<Exams> exams { get; set; }


    }
}