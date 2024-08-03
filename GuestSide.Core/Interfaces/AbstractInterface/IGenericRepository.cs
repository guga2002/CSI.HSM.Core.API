using System.Linq.Expressions;

namespace GuestSide.Core.Interfaces.AbstractInterface
{

    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(object id);
        Task<bool> Delete(T entityToDelete);
    }
}
