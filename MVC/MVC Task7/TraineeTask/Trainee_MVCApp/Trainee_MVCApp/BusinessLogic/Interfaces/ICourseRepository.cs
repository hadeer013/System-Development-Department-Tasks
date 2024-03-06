using Trainee_MVCApp.Models;

namespace Trainee_MVCApp.BusinessLogic.Interfaces
{
    public interface ICourseRepository:IGenericRepository<Course>
    {
        Course GetCourseWithTrainee(int id);
        List<Course> GetAllCoursesWithTrainee();
    }
}
