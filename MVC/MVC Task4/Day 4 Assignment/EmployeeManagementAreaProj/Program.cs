using Microsoft.AspNetCore.Builder;

namespace EmployeeManagementAreaProj
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapAreaControllerRoute(
            name: "area_1",
            areaName: "Admin",
            pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

            app.MapAreaControllerRoute(
            name: "area_2",
            areaName: "Finance",
            pattern: "Finance/{controller=Home}/{action=Index}/{id?}");

            app.MapAreaControllerRoute(
            name: "area_3",
            areaName: "HR",
            pattern: "HR/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}",
                defaults: new { controller = "Home", action = "Index" });


			app.Run();
        }
    }
}
