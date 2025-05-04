using Microsoft.EntityFrameworkCore;
using Task_Management_System.Models;
using Task_Management_System.Repository.Pro;
using Task_Management_System.Services.projects;

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

            // repo
            builder.Services.AddScoped<ITeamRepo, ProjectRepo>();

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
