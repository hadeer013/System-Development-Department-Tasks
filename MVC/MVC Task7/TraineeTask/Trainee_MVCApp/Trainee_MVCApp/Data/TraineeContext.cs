using Microsoft.EntityFrameworkCore;
using Trainee_MVCApp.Models;

namespace Trainee_MVCApp.Data
{
    public class TraineeContext : DbContext
    {
        public TraineeContext(DbContextOptions<TraineeContext> options) : base(options)
        {
        }

        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
