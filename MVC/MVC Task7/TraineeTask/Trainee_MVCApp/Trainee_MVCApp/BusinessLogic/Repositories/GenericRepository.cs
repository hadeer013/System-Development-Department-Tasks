using Trainee_MVCApp.BusinessLogic.Interfaces;
using Trainee_MVCApp.Data;
using Trainee_MVCApp.Models;

namespace Trainee_MVCApp.BusinessLogic.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly TraineeContext context;

        public GenericRepository(TraineeContext context)
        {
            this.context = context;
        }

        public int Add(T entity)
        {
            context.Add(entity);
            return context.SaveChanges();
        }

        public int Delete(T entity)
        {
            context.Remove(entity);
            return context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public int Update(T entity)
        {
            context.Update(entity);
            return context.SaveChanges();
        }
    }
}
