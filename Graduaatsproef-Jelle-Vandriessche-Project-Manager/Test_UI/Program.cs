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

            //InserManager manager = new InserManager();
            //List<User> users = manager.InsertUsers();
            //List<Project> projects = manager.InsertProjects();
            //List<UserTasks> userTasks = manager.InsertUserTasks();
            //List<ProjectTasks> projectTasks = manager.InsertProjectTasks();
            //List<ProjectCalendar> projectCalendars = manager.InsertProjectCalendar();

            //foreach (var u in users)
            //{
            //    User user = new User(u.UserId, u.First_Name, u.Last_Name, u.Email, u.Password);
            //    uM.AddUser(user);
            //}

            //foreach (var p in projects)
            //{
            //    Project project = new Project(p.ProjectId, p.User, p.Name, p.Description, p.Color);
            //    pM.AddProject(project);
            //}

            //foreach (var uT in userTasks)
            //{
            //    UserTasks userTask = new UserTasks(uT.TaskId, uT.User, uT.TaskName, uT.TaskDescription, uT.Color);
            //    uTM.AddTask(userTask);
            //}

            //foreach (var pT in projectTasks)
            //{
            //    ProjectTasks projectTask = new ProjectTasks(pT.TaskId, pT.Project, pT.TaskName, pT.TaskDescription, pT.Color);
            //    pTM.AddTask(projectTask);
            //}

            //foreach (var pC in projectCalendars)
            //{
            //    ProjectCalendar projectCalendar = new ProjectCalendar(pC.CalendarId, pC.Project, pC.Name, pC.Description, pC.Date);
            //    pCM.AddCalendar(projectCalendar);
            //}

            //Console.WriteLine("Users");
            //Console.ForegroundColor = ConsoleColor.Green;
            //var u1 = uM.GetUser(1);
            //var u2 = uM.GetUser(2);
            //Console.WriteLine($"User ID: {u1.UserId}, First_Name: {u1.First_Name}, Last_Name: {u1.Last_Name}, Email: {u1.Email}, Pass: {u1.Password}");
            //Console.WriteLine($"User ID: {u2.UserId}, First_Name: {u2.First_Name}, Last_Name: {u2.Last_Name}, Email: {u2.Email}, Pass: {u2.Password}");

            //Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine(" ");

            //Console.WriteLine("Projects");
            //Console.ForegroundColor = ConsoleColor.Green;
            //var Projects = pM.GetAllProjects(1);
            //foreach (var p in Projects)
            //{
            //    Console.WriteLine($"Project_Id: {p.ProjectId}, User_Id: {p.User.UserId}, Name: {p.Name}, Description: {p.Description}, Color: {p.Color}");
            //}
            //Console.ForegroundColor = ConsoleColor.White;

            //Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine(" ");

            //Console.WriteLine("User Task");
            //Console.ForegroundColor = ConsoleColor.Green;
            //var UserTasks = uTM.GetAllTasks(1);
            //foreach (var uT in UserTasks)
            //{
            //    Console.WriteLine($"UserTask_Id: {uT.TaskId}, User_Id: {uT.User.UserId}, Task_Name: {uT.TaskName}, Description: {uT.TaskDescription}, Color: {uT.Color}");
            //}
            //Console.ForegroundColor = ConsoleColor.White;

            //Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine(" ");

            //Console.WriteLine("Project Task");
            //Console.ForegroundColor = ConsoleColor.Green;
            //var ProjectTasks = pTM.GetAllTasks(1);
            //foreach (var pT in ProjectTasks)
            //{
            //    Console.WriteLine($"ProjectTask_Id: {pT.TaskId}, Project_Id: {pT.Project.ProjectId}, Task_Name: {pT.TaskName}, Description: {pT.TaskDescription}, Color: {pT.Color}");
            //}
            //Console.ForegroundColor = ConsoleColor.White;

            //Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine(" ");

            //Console.WriteLine("Project Calendar");
            //Console.ForegroundColor = ConsoleColor.Green;
            //var ProjectCalendar = pCM.GetAllProjectCalendars(1);
            //foreach (var pC in ProjectCalendar)
            //{
            //    Console.WriteLine($"ProjectCalendar_Id: {pC.CalendarId}, Project_Id: {pC.Project.ProjectId}, Name: {pC.Name}, Description: {pC.Description}, Date: {pC.Date}");
            //}
            //Console.ForegroundColor = ConsoleColor.White;

            //Console.WriteLine("Login");
            //Console.WriteLine("----------------------------");
            //Console.WriteLine("Email: ");
            //string Email = Console.ReadLine();
            //Console.WriteLine("Password: ");
            //string password = Console.ReadLine();
            //var user1 = uM.GetUserByEmail(Email);

            //Console.WriteLine("----------------------------");

            //if (user1.Password == password)
            //{
            //    Console.WriteLine($"{user1.Email} Is logged in");
            //}
            //else
            //{
            //    Console.WriteLine("Password is incorect");
            //}



            // Initialize your repositories and managers with appropriate implementations
            // e.g., IProjectRepo projectRepo = new ProjectRepository();

            // Create instances of your managers using the repositories
            // e.g., ProjectManager projectManager = new ProjectManager(projectRepo);

            try
            {
                // Test User Manager
                TestUserManager(uM);

                // Test User Tasks Manager
                TestUserTasksManager(uTM);

                // Test Project Manager
                TestProjectManager(pM);

                // Test Project Calendar Manager
                TestProjectCalendarManager(pCM);

                // Test Project Tasks Manager
                TestProjectTasksManager(pTM);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadLine(); // Keep console window open
        }

        // ... (previous code)

        static void TestUserManager(UserManager uM)
        {
            // Replace with your actual logic
            // Example:
            User user1 = new User("Jelle", "Vandriessche", "jelle.vandriessche@gmail.com", "Root1234");
            uM.AddUser(user1);
            Console.WriteLine($"Added User: {user1.First_Name} {user1.Last_Name}");

            User user2 = new User("John", "Doe", "john.doe@example.com", "Password123");
            uM.AddUser(user2);
            Console.WriteLine($"Added User: {user2.First_Name} {user2.Last_Name}");

            User user3 = new User("Jane", "Smith", "jane.smith@example.com", "Password456");
            uM.AddUser(user3);
            Console.WriteLine($"Added User: {user3.First_Name} {user3.Last_Name}");
        }

        static void TestUserTasksManager(UserTasksManager uTM)
        {
            // Replace with your actual logic
            // Example:
            User user = new User(1, "John", "Doe", "john.doe@example.com", "Password123");
            UserTasks userTask1 = new UserTasks(user, "User Task 1", "Task Description 1", "Blue");
            uTM.AddTask(userTask1);
            Console.WriteLine($"Added User Task: {userTask1.TaskName}");

            UserTasks userTask2 = new UserTasks(user, "User Task 2", "Task Description 2", "Green");
            uTM.AddTask(userTask2);
            Console.WriteLine($"Added User Task: {userTask2.TaskName}");
        }

        static void TestProjectManager(ProjectManager.BL.Managers.ProjectManager pM)
        {
            //Replace with your actual logic
            //Example:
            User user = new User(1, "John", "Doe", "john.doe@example.com", "Password123");
            Project project1 = new Project(user, "Project 1", "Description 1", "Blue");
            pM.AddProject(project1);
            Console.WriteLine($"Added Project: {project1.Name}");

            Project project2 = new Project(user, "Project 2", "Description 2", "Green");
            pM.AddProject(project2);
            Console.WriteLine($"Added Project: {project2.Name}");
        }

        static void TestProjectCalendarManager(ProjectCalendarManager pCM)
        {
            // Replace with your actual logic
            // Example:
            User user = new User(1, "John", "Doe", "john.doe@example.com", "Password123");
            Project project = new Project(1, user, "Project 1", "Description 1", "Blue");
            ProjectCalendar calendar1 = new ProjectCalendar(project, "Calendar 1", "Description 1", DateTime.Now);
            pCM.AddCalendar(calendar1);
            Console.WriteLine($"Added Project Calendar: {calendar1.Name}");

            ProjectCalendar calendar2 = new ProjectCalendar(project, "Calendar 2", "Description 2", DateTime.Now);
            pCM.AddCalendar(calendar2);
            Console.WriteLine($"Added Project Calendar: {calendar2.Name}");
        }

        static void TestProjectTasksManager(ProjectTasksManager pTM)
        {
            // Replace with your actual logic
            // Example:
            User user = new User(1, "John", "Doe", "john.doe@example.com", "Password123");
            Project project = new Project(1, user, "Project 1", "Description 1", "Blue");
            ProjectTasks task1 = new ProjectTasks(project, "Task 1", "Task Description 1", "Red");
            pTM.AddTask(task1);
            Console.WriteLine($"Added Project Task: {task1.TaskName}");

            ProjectTasks task2 = new ProjectTasks(project, "Task 2", "Task Description 2", "Yellow");
            pTM.AddTask(task2);
            Console.WriteLine($"Added Project Task: {task2.TaskName}");
        }
    }
}