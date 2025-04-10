using System.Linq.Expressions;

namespace Domain.Core.Interfaces.AbstractInterface
{

    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(object id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> DeleteAsync(object id, CancellationToken cancellationToken = default);
        Task<T> Delete(T entityToDelete, CancellationToken cancellationToken = default);
    }
}
