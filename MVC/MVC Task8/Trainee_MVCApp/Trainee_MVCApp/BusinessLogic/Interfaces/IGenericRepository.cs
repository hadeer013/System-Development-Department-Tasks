using Trainee_MVCApp.Models;

namespace Trainee_MVCApp.BusinessLogic.Interfaces
{
    public interface IGenericRepository<T> where T:BaseEntity
    {
        List<T> GetAll();
        T GetById(int id);
        int Add(T entity);
        int Delete(T entity);
        int Update(T entity);
        

    }
}
