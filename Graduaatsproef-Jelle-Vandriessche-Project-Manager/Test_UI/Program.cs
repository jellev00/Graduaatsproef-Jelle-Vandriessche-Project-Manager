using EFDatalayerProvider;
using Microsoft.IdentityModel.Protocols;
using ProjectManager.BL.Models;
using System.Configuration;
using Test_UI.Manager;

namespace Test_UI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string dataLayer = ConfigurationManager.AppSettings["DataLayer"];
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            EFRepositories repo = null;
            switch (dataLayer)
            {
                case "EFCore":
                    repo = EFDatalayerFactory.GEtRepo(connectionString, RepositoryType.EFCore);
                    break;
            }

            InserManager manager = new InserManager();
            List<User> users = manager.InsertUsers();
            List<Project> projects = manager.InsertProjects();
            List<UserTasks> userTasks = manager.InsertUserTasks();
            List<ProjectTasks> projectTasks = manager.InsertProjectTasks();
            List<ProjectCalendar> projectCalendars = manager.InsertProjectCalendar();

            //foreach (var u in users)
            //{
            //    User user = new User(u.UserId, u.First_Name, u.Last_Name, u.Email, u.Password);
            //    repo.userRepo.AddUser(user);
            //}

            //foreach (var p in projects)
            //{
            //    Project project = new Project(p.ProjectId, p.UserId, p.Name, p.Description, p.Color);
            //    repo.projectRepo.AddProject(project);
            //}

            //foreach (var uT in userTasks)
            //{
            //    UserTasks userTask = new UserTasks(uT.TaskId, uT.UserId, uT.TaskName, uT.TaskDescription, uT.Color);
            //    repo.userTasksRepo.AddTask(userTask);
            //}

            //foreach (var pT in projectTasks)
            //{
            //    ProjectTasks projectTask = new ProjectTasks(pT.TaskId, pT.ProjectId, pT.TaskName, pT.TaskDescription, pT.Color);
            //    repo.projectTasksRepo.AddTask(projectTask);
            //}

            foreach (var pC in projectCalendars)
            {
                ProjectCalendar projectCalendar = new ProjectCalendar(pC.CalendarId, pC.ProjectId, pC.Name, pC.Description, pC.Date);
                repo.projectCalendarRepo.AddCalendar(projectCalendar);
            }

            Console.WriteLine("Users");
            Console.ForegroundColor = ConsoleColor.Green;
            var u1 = repo.userRepo.GetUser(1);
            var u2 = repo.userRepo.GetUser(2);
            Console.WriteLine($"User ID: {u1.UserId}, First_Name: {u1.First_Name}, Last_Name: {u1.Last_Name}, Email: {u1.Email}, Pass: {u1.Password}");
            Console.WriteLine($"User ID: {u2.UserId}, First_Name: {u2.First_Name}, Last_Name: {u2.Last_Name}, Email: {u2.Email}, Pass: {u2.Password}");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");

            Console.WriteLine("Projects");
            Console.ForegroundColor = ConsoleColor.Green;
            var Projects = await repo.projectRepo.GetAllProjects(1);
            foreach (var p in Projects)
            {
                Console.WriteLine($"Project_Id: {p.ProjectId}, User_Id: {p.UserId}, Name: {p.Name}, Description: {p.Description}, Color: {p.Color}");
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");

            Console.WriteLine("User Task");
            Console.ForegroundColor = ConsoleColor.Green;
            var UserTasks = await repo.userTasksRepo.GetAllTasks(1);
            foreach (var uT in UserTasks)
            {
                Console.WriteLine($"UserTask_Id: {uT.TaskId}, User_Id: {uT.UserId}, Task_Name: {uT.TaskName}, Description: {uT.TaskDescription}, Color: {uT.Color}");
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");

            Console.WriteLine("Project Task");
            Console.ForegroundColor = ConsoleColor.Green;
            var ProjectTasks = await repo.projectTasksRepo.GetAllTasks(1);
            foreach (var pT in ProjectTasks)
            {
                Console.WriteLine($"ProjectTask_Id: {pT.TaskId}, Project_Id: {pT.ProjectId}, Task_Name: {pT.TaskName}, Description: {pT.TaskDescription}, Color: {pT.Color}");
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");

            Console.WriteLine("Project Calendar");
            Console.ForegroundColor = ConsoleColor.Green;
            var ProjectCalendar = await repo.projectCalendarRepo.GetAllCalendars(1);
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