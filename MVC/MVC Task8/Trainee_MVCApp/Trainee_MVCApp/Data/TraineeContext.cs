using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using Trainee_MVCApp.Models;

namespace Trainee_MVCApp.Data
{
    public class TraineeContext : IdentityDbContext<AppUser>
    {
        public TraineeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
