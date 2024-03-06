using Microsoft.EntityFrameworkCore;
using ProductOrderManagement.ApplicationContext;

namespace ProductOrderManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CustomerOrderContext>(OPTIONS =>
            {
                OPTIONS.UseSqlServer("server=DESKTOP-0054Q2J\\SQLEXPRESS;database=CustomerOrder_TaskD7;trusted_connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
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
