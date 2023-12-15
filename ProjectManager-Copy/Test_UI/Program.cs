using EFDatalayerProvider;
using Microsoft.IdentityModel.Protocols;
using ProjectManager.BL.Interfaces;
using ProjectManager.BL.Managers;
using ProjectManager.BL.Models;
using ProjectManager.EF.Models;
using ProjectManager.EF.Repositories;
using System.Configuration;
using Test_UI.Manager;

namespace Test_UI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ProjectManager;Integrated Security=True;TrustServerCertificate=True";
            ContextEF ctx = new ContextEF(connectionString);

            Console.WriteLine("Deleted DataBase");
            ctx.Database.EnsureDeleted();
            Console.WriteLine("Created DataBase");
            ctx.Database.EnsureCreated();

            IUserRepo uRepo = new RepoUserEF(connectionString);
            IUserTasksRepo uTRepo = new RepoUserTasksEF(connectionString);
            IProjectRepo pRepo = new RepoProjectsEF(connectionString);
            IProjectTasksRepo pTRepo = new RepoProjectTasksEF(connectionString);
            IProjectCalendarRepo pCRepo = new RepoProjectCalendarEF(connectionString);

            UserManager uM = new UserManager(uRepo);
            UserTasksManager uTM = new UserTasksManager(uTRepo);
            ProjectManager.BL.Managers.ProjectManager pM = new ProjectManager.BL.Managers.ProjectManager(pRepo);
            ProjectTasksManager pTM = new ProjectTasksManager(pTRepo);
            ProjectCalendarManager pCM = new ProjectCalendarManager(pCRepo);

            InserManager manager = new InserManager();
            List<User> users = manager.InsertUsers();
            List<Project> projects = manager.InsertProjects();
            List<UserTasks> userTasks = manager.InsertUserTasks();
            List<ProjectTasks> projectTasks = manager.InsertProjectTasks();
            List<ProjectCalendar> projectCalendars = manager.InsertProjectCalendar();

            foreach (var u in users)
            {
                User user = new User(u.UserId, u.First_Name, u.Last_Name, u.Email, u.Password);
                uM.AddUser(user);
            }

            foreach (var p in projects)
            {
                Project project = new Project(p.ProjectId, p.UserId, p.Name, p.Description, p.Color);
                pM.AddProject(project);
            }

            foreach (var uT in userTasks)
            {
                UserTasks userTask = new UserTasks(uT.TaskId, uT.UserId, uT.TaskName, uT.TaskDescription, uT.Color);
                uTM.AddTask(userTask);
            }

            foreach (var pT in projectTasks)
            {
                ProjectTasks projectTask = new ProjectTasks(pT.TaskId, pT.ProjectId, pT.TaskName, pT.TaskDescription, pT.Color);
                pTM.AddTask(projectTask);
            }

            foreach (var pC in projectCalendars)
            {
                ProjectCalendar projectCalendar = new ProjectCalendar(pC.CalendarId, pC.ProjectId, pC.Name, pC.Description, pC.Date);
                pCM.AddCalendar(projectCalendar);
            }

            Console.WriteLine("Users");
            Console.ForegroundColor = ConsoleColor.Green;
            var u1 = uM.GetUser(1);
            var u2 = uM.GetUser(2);
            Console.WriteLine($"User ID: {u1.UserId}, First_Name: {u1.First_Name}, Last_Name: {u1.Last_Name}, Email: {u1.Email}, Pass: {u1.Password}");
            Console.WriteLine($"User ID: {u2.UserId}, First_Name: {u2.First_Name}, Last_Name: {u2.Last_Name}, Email: {u2.Email}, Pass: {u2.Password}");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");

            Console.WriteLine("Projects");
            Console.ForegroundColor = ConsoleColor.Green;
            var Projects = pM.GetAllProjects(1);
            foreach (var p in Projects)
            {
                Console.WriteLine($"Project_Id: {p.ProjectId}, User_Id: {p.UserId}, Name: {p.Name}, Description: {p.Description}, Color: {p.Color}");
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");

            Console.WriteLine("User Task");
            Console.ForegroundColor = ConsoleColor.Green;
            var UserTasks = uTM.GetAllTasks(1);
            foreach (var uT in UserTasks)
            {
                Console.WriteLine($"UserTask_Id: {uT.TaskId}, User_Id: {uT.UserId}, Task_Name: {uT.TaskName}, Description: {uT.TaskDescription}, Color: {uT.Color}");
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");

            Console.WriteLine("Project Task");
            Console.ForegroundColor = ConsoleColor.Green;
            var ProjectTasks = pTM.GetAllTasks(1);
            foreach (var pT in ProjectTasks)
            {
                Console.WriteLine($"ProjectTask_Id: {pT.TaskId}, Project_Id: {pT.ProjectId}, Task_Name: {pT.TaskName}, Description: {pT.TaskDescription}, Color: {pT.Color}");
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");

            Console.WriteLine("Project Calendar");
            Console.ForegroundColor = ConsoleColor.Green;
            var ProjectCalendar = pCM.GetAllProjectCalendars(1);
            foreach (var pC in ProjectCalendar)
            {
                Console.WriteLine($"ProjectCalendar_Id: {pC.CalendarId}, Project_Id: {pC.ProjectId}, Name: {pC.Name}, Description: {pC.Description}, Date: {pC.Date}");
            }
            Console.ForegroundColor = ConsoleColor.White;

            //Console.WriteLine("Login");
            //Console.WriteLine("----------------------------");
            //Console.WriteLine("UserName: ");
            //string userName = Console.ReadLine();
            //Console.WriteLine("Password: ");
            //string password = Console.ReadLine();
            //var user = repo.userRepo.GetUserByName(userName);

            //Console.WriteLine("----------------------------");

            //if (user.Password == password)
            //{
            //    Console.WriteLine($"{user.Name} Is logged in");
            //} else
            //{
            //    Console.WriteLine("Password is incorect");
            //}

        }
    }
}