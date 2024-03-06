using Microsoft.EntityFrameworkCore;
using Trainee_MVCApp.BusinessLogic.Interfaces;
using Trainee_MVCApp.BusinessLogic.Repositories;
using Trainee_MVCApp.Data;

namespace Trainee_MVCApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(ITraineeRepository),typeof(TraineeRepository));
            builder.Services.AddScoped(typeof(ICourseRepository), typeof(CourseRepository));

            builder.Services.AddDbContext<TraineeContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });







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
