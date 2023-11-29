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

            foreach (var u in users)
            {
                User user = new User(u.UserId, u.Name, u.Email, u.Password);
                repo.userRepo.AddUser(user);
            }

            foreach (var p in projects)
            {
                Project project = new Project(p.ProjectId, p.UserId, p.Name, p.Description);
                repo.projectRepo.AddProject(project);
            }

            //this insert still needs to be done

            foreach (var uT in userTasks)
            {
                UserTasks userTask = new UserTasks(uT.TaskId, uT.UserId, uT.TaskDescription);
                // Repo link for adding
            }

            foreach (var pT in projectTasks)
            {
                ProjectTasks projectTask = new ProjectTasks(pT.TaskId, pT.ProjectId, pT.TaskDescription);
                // Repo link for adding
            }

            foreach (var pC in projectCalendars)
            {
                ProjectCalendar projectCalendar = new ProjectCalendar(pC.CalendarId, pC.ProjectId, pC.Name, pC.Description, pC.Date);
                // Repo link for adding
            }

            Console.WriteLine("Users");
            Console.ForegroundColor = ConsoleColor.Green;
            var u1 = repo.userRepo.GetUser(1);
            var u2 = repo.userRepo.GetUser(2);
            Console.WriteLine($"User ID: {u1.UserId}, Name: {u1.Name}, Email: {u1.Email}, Pass: {u1.Password}");
            Console.WriteLine($"User ID: {u2.UserId}, Name: {u2.Name}, Email: {u2.Email}, Pass: {u2.Password}");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");

            Console.WriteLine("Projects");
            Console.ForegroundColor = ConsoleColor.Green;
            var Projects = await repo.projectRepo.GetAllProjects(1);
            foreach (var p in Projects)
            {
                Console.WriteLine($"Project_Id: {p.ProjectId}, User_Id: {p.UserId}, Name: {p.Name}, Description: {p.Description}");
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