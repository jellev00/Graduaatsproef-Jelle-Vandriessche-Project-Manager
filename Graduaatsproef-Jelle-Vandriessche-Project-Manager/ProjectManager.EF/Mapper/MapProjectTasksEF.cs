using ProjectManager.BL.Models;
using ProjectManager.EF.Models;
using ProjectManager.EF.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.EF.Mapper
{
    public class MapProjectTasksEF
    {
        public static ProjectTasks MapToDomain(ProjectTasksEF db)
        {
            try
            {
                User user = new User(db.Project.User.User_ID, db.Project.User.First_Name, db.Project.User.Last_Name, db.Project.User.Email, db.Project.User.Password);

                Project project = new Project(db.Project.Project_ID, user, db.Project.Name, db.Project.Description, db.Project.Color);

                return new ProjectTasks(db.Project_Task_ID, project, db.Task_Name, db.Task_Description, db.Color);
            } catch (Exception ex)
            {
                throw new MapEFException("MapProjectTasksEF - MapToDomain", ex);
            }
        }

        public static ProjectTasksEF MapToDB(ProjectTasks pT, ContextEF ctx)
        {
            try
            {
                ProjectsEF project = ctx.Projects.Where(x => x.Project_ID == pT.Project.ProjectId).Include(x => x.User).FirstOrDefault();

                return new ProjectTasksEF(project, pT.TaskName, pT.TaskDescription, pT.Color);
            } catch (Exception ex)
            {
                throw new MapEFException("MapProjectTasksEF - MapToDB", ex);
            }
        }
    }
}
