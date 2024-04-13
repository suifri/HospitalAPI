using System.Linq.Expressions;

namespace HospitalAPI.Repositories.Interfaces
{
    public interface BaseIRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        void Remove(T entity);

        void Update(T entity);

        Task SaveChanges();
    }
}
