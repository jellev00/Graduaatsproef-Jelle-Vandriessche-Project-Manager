using Microsoft.EntityFrameworkCore;
using ProjectManager.BL.Models;
using ProjectManager.EF.Exceptions;
using ProjectManager.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EF.Mapper
{
    public class MapProjectEF
    {
        public static Project MapToDomain(ProjectsEF db)
        {
            try
            {
                User user = new User(db.User.User_ID, db.User.First_Name, db.User.Last_Name, db.User.Email, db.User.Password);

                List<ProjectTasks> projectTasks = new List<ProjectTasks>();

                if (db.ProjectTasks != null)
                {
                    foreach (ProjectTasksEF pT in db.ProjectTasks)
                    {
                        Project project = new Project(pT.Project.Project_ID, user, pT.Project.Name, pT.Project.Description, pT.Project.Color);

                        ProjectTasks projectTask = new ProjectTasks(pT.Project_Task_ID, project, pT.Task_Name, pT.Task_Description, pT.Color, pT.Date);

                        projectTasks.Add(projectTask);
                    }
                }

                return new Project(db.Project_ID, user, db.Name, db.Description, db.Color, projectTasks);
            }
            catch (Exception ex)
            {
                throw new MapEFException("MapProject - MapToDomain", ex);
            }
        }

        public static ProjectsEF MapToDB(Project p, ContextEF ctx)
        {
            try
            {
                //UserEF user = new UserEF(p.User.UserId, p.User.First_Name, p.User.Last_Name, p.User.Email, p.User.Password);

                // Assuming User.Id is the primary key in UserEF
                UserEF user = ctx.Users.Find(p.User.UserId);

                if (user == null)
                {
                    // Handle the case where the user is not found in the database
                    throw new MapEFException($"User with ID {p.User.UserId} not found.");
                }

                List<ProjectTasksEF> projectTasks = new List<ProjectTasksEF>();

                if (p.ProjectTasks != null)
                {
                    foreach (ProjectTasks pT in p.ProjectTasks.ToList())
                    {
                        ProjectTasksEF projectTask = MapProjectTasksEF.MapToDB(pT, ctx);

                        projectTasks.Add(projectTask);
                    }
                }

                ProjectsEF project = ctx.Projects
                    .Include(proj => proj.User) // Include the User property
                    .FirstOrDefault(proj => proj.Project_ID == p.ProjectId);

                if (p.ProjectId > 0)
                {
                    project = new ProjectsEF(p.ProjectId, user, p.Name, p.Description, p.Color, projectTasks);
                } else
                {
                    project = new ProjectsEF(user, p.Name, p.Description, p.Color, projectTasks);

                }

                return project;
            }
            catch (Exception ex)
            {
                throw new MapEFException("MapProject - MapToDB", ex);
            }
        }
    }
}
