using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjectMVC.Models;

namespace ProjectMVC.Dal
{
    public class UsersDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>().ToTable("Users");
        }
        public DbSet<Users> users { get; set; }
    }
}
