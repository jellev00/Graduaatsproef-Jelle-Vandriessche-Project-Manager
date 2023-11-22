using Microsoft.EntityFrameworkCore;
using ProjectManager.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EF
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
            modelBuilder.Entity<ProjectTasksEF>()
                .HasOne(pt => pt.project)
                .WithMany(p => p.ProjectTasks)
                .HasForeignKey(pt => pt.Project_ID);

            modelBuilder.Entity<UserTasksEF>()
                .HasOne(t => t.user)
                .WithMany(u => u.UserTasks)
                .HasForeignKey(t => t.User_ID);

            modelBuilder.Entity<ProjectCalendarEF>()
                .HasOne(c => c.project)
                .WithMany(p => p.ProjectCalendar)
                .HasForeignKey(c => c.Project_ID);

            modelBuilder.Entity<ProjectsEF>()
                .HasOne(p => p.user)
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.User_ID);
        }

        public void SeedData()
        {
            // Add some dummy data here
            var user1 = new UserEF { Name = "Jelle Vandriessche", Email = "jelle.vandriessche@gmail.com", Password = "Root1234" };
            var user2 = new UserEF { Name = "John Doe", Email = "john.doe@example.com", Password = "password1" };

            Users.AddRange(user1, user2);

            var project1 = new ProjectsEF { Name = "Project A", Description = "Description for Project A", user = user1 };
            var project2 = new ProjectsEF { Name = "Project B", Description = "Description for Project B", user = user2 };

            Projects.AddRange(project1, project2);

            var task1 = new UserTasksEF { Task_Description = "Task 1 for John Doe", user = user1 };
            var task2 = new UserTasksEF { Task_Description = "Task 2 for John Doe", user = user1 };
            var task3 = new UserTasksEF { Task_Description = "Task 1 for Jane Doe", user = user2 };

            UserTasks.AddRange(task1, task2, task3);

            var projectTask1 = new ProjectTasksEF { Task_Description = "Task 1 for Project A", project = project1 };
            var projectTask2 = new ProjectTasksEF { Task_Description = "Task 2 for Project A", project = project1 };
            var projectTask3 = new ProjectTasksEF { Task_Description = "Task 1 for Project B", project = project2 };

            ProjectTasks.AddRange(projectTask1, projectTask2, projectTask3);

            var calendar1 = new ProjectCalendarEF { Name = "Calendar for Project A", Description = "Calendar Description", Date = DateTime.Now, project = project1 };
            var calendar2 = new ProjectCalendarEF { Name = "Calendar for Project B", Description = "Calendar Description", Date = DateTime.Now, project = project2 };

            ProjectCalendar.AddRange(calendar1, calendar2);

            SaveChanges();
        }
    }
}
