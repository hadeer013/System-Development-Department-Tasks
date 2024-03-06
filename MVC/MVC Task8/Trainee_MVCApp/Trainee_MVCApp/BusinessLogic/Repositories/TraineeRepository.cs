using Microsoft.EntityFrameworkCore;
using Trainee_MVCApp.BusinessLogic.Interfaces;
using Trainee_MVCApp.Data;
using Trainee_MVCApp.Models;

namespace Trainee_MVCApp.BusinessLogic.Repositories
{
    public class TraineeRepository : GenericRepository<Trainee>, ITraineeRepository
    {
        private readonly TraineeContext context;

        public TraineeRepository(TraineeContext context) : base(context)
        {
            this.context = context;
        }

        public List<Trainee> GetAllWithTrack()
        {
            return context.Trainees.Include(t => t.Track).ToList();
        }

        public Trainee GetByIdAllInc(int id)
        {
            return context.Trainees
                    .Include(t => t.Track)
                    .Include(t => t.Courses)
                    .Where(t => t.Id == id)
                    .FirstOrDefault();
        }
    }
}
