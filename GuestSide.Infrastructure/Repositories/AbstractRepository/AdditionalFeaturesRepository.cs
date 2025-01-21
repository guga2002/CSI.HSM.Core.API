using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Infrastructure.Repositories.AbstractRepository;

/// <summary>
/// Additional features for generic Repository
/// </summary>
/// <typeparam name="T"></typeparam>
public class AdditionalFeaturesRepository<T> : IAdditionalFeaturesRepository<T> where T : class
{
    #region Constructor
    private readonly GuestSideDb _context;
    private readonly DbSet<T> DbSet;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="Context"></param>
    public AdditionalFeaturesRepository(GuestSideDb Context)
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

    #region BulkInsert
    public async Task BulkAddAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        if (entities == null || !entities.Any())
        {
            throw new ArgumentException("Entities collection cannot be null or empty.", nameof(entities));
        }

        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            await DbSet.AddRangeAsync(entities, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw new InvalidOperationException("An error occurred while performing bulk addition.", ex);
        }
    }

    #endregion

    #region BulkUpdate
    public async Task BulkUpdateAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        if (entities == null || !entities.Any())
        {
            throw new ArgumentException("Entities collection cannot be null or empty.", nameof(entities));
        }

        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            DbSet.UpdateRange(entities);
            await _context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);

            throw new InvalidOperationException("An error occurred while performing bulk update.", ex);
        }
    }

    #endregion

    #region BulkDelete
    public async Task BulkDeleteAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        if (entities == null || !entities.Any())
        {
            throw new ArgumentException("Entities collection cannot be null or empty.", nameof(entities));
        }

        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            DbSet.RemoveRange(entities);
            await _context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw new InvalidOperationException("An error occurred while performing bulk deletion.", ex);
        }
    }
    #endregion

    #region Paggination
    public virtual async Task<(IEnumerable<T>, int)> GetPagedAsync(
    Expression<Func<T, bool>> predicate,
    int pageNumber,
    int pageSize,
    Expression<Func<T, object>> orderBy,
    bool isAscending = true,
    CancellationToken cancellationToken = default)
    {
        var query = DbSet.Where(predicate);

        var totalCount = await query.CountAsync(cancellationToken);

        query = isAscending
            ? query.OrderBy(orderBy)
            : query.OrderByDescending(orderBy);

        var data = await query.Skip((pageNumber - 1) * pageSize)
                              .Take(pageSize)
                              .ToListAsync(cancellationToken);

        return (data, totalCount);
    }
    #endregion

    #region Exist
    /// <summary>
    /// check if  record exist
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await DbSet.AnyAsync(predicate, cancellationToken);
    }
    #endregion
}
