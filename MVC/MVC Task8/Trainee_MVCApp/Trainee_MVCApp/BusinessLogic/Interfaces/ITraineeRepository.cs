using Trainee_MVCApp.Models;

namespace Trainee_MVCApp.BusinessLogic.Interfaces
{
    public interface ITraineeRepository
    {
        List<Trainee> GetAllWithTrack();
        Trainee GetByIdAllInc(int id);
    }
}
