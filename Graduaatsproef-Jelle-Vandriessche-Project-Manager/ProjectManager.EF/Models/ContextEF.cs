using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EF.Models
{
    public class ContextEF : DbContext
    {
        private string _connectionstring;

        public ContextEF(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public DbSet<UserEF> Users { get; set; }
        public DbSet<UserTasksEF> UserTasks { get; set; }
        public DbSet<ProjectsEF> Projects { get; set; }
        public DbSet<ProjectTasksEF> ProjectTasks { get; set; }
        public DbSet<ProjectCalendarEF> ProjectCalendar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionstring);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProjectTasksEF>()
            //    .HasOne(pt => pt.project)
            //    .WithMany(p => p.ProjectTasks)
            //    .HasForeignKey(pt => pt.Project_ID);

            //modelBuilder.Entity<UserTasksEF>()
            //    .HasOne(t => t.user)
            //    .WithMany(u => u.UserTasks)
            //    .HasForeignKey(t => t.User_ID);

            //modelBuilder.Entity<ProjectCalendarEF>()
            //    .HasOne(c => c.project)
            //    .WithMany(p => p.ProjectCalendar)
            //    .HasForeignKey(c => c.Project_ID);

            //modelBuilder.Entity<ProjectsEF>()
            //    .HasOne(p => p.user)
            //    .WithMany(u => u.Projects)
            //    .HasForeignKey(p => p.User_ID);
        }
    }
}
