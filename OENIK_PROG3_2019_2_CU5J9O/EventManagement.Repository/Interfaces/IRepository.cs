using System.Linq;

namespace EventManagement.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        T GetOne(int id);

        void Insert(T entity);

        bool Remove(int id);

        bool Remove(T entity);
    }
}
