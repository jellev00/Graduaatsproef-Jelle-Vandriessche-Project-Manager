using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDatalayerProvider.Exceptions;
using ProjectManager.EF.Repositories;
using ProjectManager.BL.Interfaces;

namespace EFDatalayerProvider
{
    public class EFRepositories
    {
        public EFRepositories(string connectionString, RepositoryType repositoryType)
        {
            try
            {
                switch (repositoryType)
                {
                    case RepositoryType.EFCore:
                        userRepo = new RepoUserEF(connectionString);
                        projectRepo = new RepoProjectsEF(connectionString);
                        //userTasksRepo = new RepoUserTasksEF(connectionString);
                        //projectTasksRepo = new RepoProjectTasksEF(connectionString);
                        //projectCalendarRepo = new RepoProjectCalendarEF(connectionString);

                        break;
                    default: throw new EFDatalayerFactoryException("GetRepo");

                }
            } catch (Exception ex)
            {
                throw new EFDatalayerFactoryException("GetRepo", ex);
            }
        }

        public IUserRepo userRepo { get; set; }
        public IProjectRepo projectRepo { get; set; }
        public IUserTasksRepo userTasksRepo { get; set; }
        public IProjectTasksRepo projectTasksRepo { get; set; }
        public IProjectCalendarRepo projectCalendarRepo { get; set; }
    }
}
