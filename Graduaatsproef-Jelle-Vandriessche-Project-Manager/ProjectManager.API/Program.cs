using ProjectManager.BL.Interfaces;
using ProjectManager.BL.Managers;
using ProjectManager.EF.Repositories;

namespace ProjectManager.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ProjectManager;Integrated Security=True";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IUserRepo>(r => new RepoUserEF(connectionString));
            builder.Services.AddSingleton<UserManager>();
            builder.Services.AddSingleton<IProjectRepo>(r => new RepoProjectsEF(connectionString));
            builder.Services.AddSingleton<ProjectManager.BL.Managers.ProjectManager>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}