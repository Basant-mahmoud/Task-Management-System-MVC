using Microsoft.EntityFrameworkCore;
using Task_Management_System.Models;
using Task_Management_System.Repository.Pro;
using Task_Management_System.Repository.Team;
using Task_Management_System.Repository.User;
using Task_Management_System.Services.Mappings;
using Task_Management_System.Services.projects;
using Task_Management_System.Services.Teams;
using Task_Management_System.Services.User;
using AutoMapper;
//using AutoMapper.Extensions.Microsoft.DependencyInjection;


namespace Task_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //connection to database 
            builder.Services.AddDbContext<TaskManagmentContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("con")));
            // services
            // تسجيل الخدمة في الـ Dependency Injection Container
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<ITeamService, TeamService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddAutoMapper(typeof(TeamMappingProfile));
            builder.Services.AddAutoMapper(typeof(TeamMappingProfile));



            // repo
            builder.Services.AddScoped<IProjectRepo, ProjectRepo>();
            builder.Services.AddScoped<ITeamRepo, TeamRepo>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
