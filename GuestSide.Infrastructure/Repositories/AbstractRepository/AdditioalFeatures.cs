using Core.Core.Interfaces.AbstractInterface;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Repositories.AbstractRepository;

/// <summary>
/// Additional features for generic Repository
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class AdditioalFeatures<T> : IAdditioalFeatures<T> where T : class
{
    #region Constructor
    private readonly DbContext _context;
    private readonly DbSet<T> DbSet;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="Context"></param>
    public AdditioalFeatures(DbContext Context)
    {
        _context = Context;
        DbSet = _context.Set<T>();
    }
    #endregion

    #region ExecuteInTransaction
    /// <summary>
    /// Execute few function use in services if  you wantinsert  few  records in one transaction
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    public async Task ExecuteInTransaction(Func<Task> action)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            await action();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
    #endregion

    #region ExecuteRawSql
    /// <summary>
    /// Execute raw SQL query
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="query"></param>
    /// <param name="parameters"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<T>> ExecuteRawSql<TResult>(string query, object[] parameters, CancellationToken cancellationToken = default)
    {
        return await DbSet.FromSqlRaw(query, parameters).ToListAsync(cancellationToken);
    }
    #endregion

    #region SoftDelete
    /// <summary>
    /// Soft delete entity
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<T> SoftDelete(object id, CancellationToken cancellationToken = default)
    {
        {
            var entity = await DbSet.FindAsync(id, cancellationToken);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }

            var isActiveProperty = typeof(T).GetProperty("IsActive");
            if (isActiveProperty != null && isActiveProperty.PropertyType == typeof(bool))
            {
                isActiveProperty.SetValue(entity, false);

                _context.Entry(entity).State = EntityState.Modified;

                await _context.SaveChangesAsync(cancellationToken);
                return entity;
            }

            throw new InvalidOperationException("Entity does not support soft deletion.");
        }
    }
    #endregion
}
