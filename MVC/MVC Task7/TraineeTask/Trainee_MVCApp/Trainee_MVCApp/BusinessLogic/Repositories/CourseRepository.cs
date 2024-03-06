using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using Trainee_MVCApp.BusinessLogic.Interfaces;
using Trainee_MVCApp.Data;
using Trainee_MVCApp.Models;

namespace Trainee_MVCApp.BusinessLogic.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly TraineeContext context;

        public CourseRepository(TraineeContext context) : base(context)
        {
            this.context = context;
        }

        public List<Course> GetAllCoursesWithTrainee()
        {
            return context.Courses.Include(c=>c.Trainee).ToList();
        }

        public Course GetCourseWithTrainee(int id)
        {
            return context.Courses.Include(C => C.Trainee).Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
