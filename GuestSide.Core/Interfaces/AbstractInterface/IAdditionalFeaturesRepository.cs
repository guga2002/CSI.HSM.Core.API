using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Core.Interfaces.AbstractInterface;
public interface IAdditionalFeaturesRepository<T> where T : class
{


    #region Raw SQL
    /// <summary>
    /// Execute raw SQL query
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="query"></param>
    /// <param name="parameters"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> ExecuteRawSql<TResult>(string query, object[] parameters, CancellationToken cancellationToken = default);
    #endregion

    #region Soft Delete
    Task<T> SoftDelete(object id, CancellationToken cancellationToken = default);
    #endregion

    #region Transactions
    /// <summary>
    /// Execute few function use in services if  you wantinsert  few  records in one transaction
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    System.Threading.Tasks.Task ExecuteInTransaction(Func<System.Threading.Tasks.Task> action);
    #endregion

    /// <summary>
    /// check if record exist
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    /// <summary>
    /// Paggination
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="orderBy"></param>
    /// <param name="isAscending"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<(IEnumerable<T>, int)> GetPagedAsync(
    Expression<Func<T, bool>> predicate,
    int pageNumber,
    int pageSize,
    Expression<Func<T, object>> orderBy,
    bool isAscending = true,
    CancellationToken cancellationToken = default);

    /// <summary>
    /// Bulk Delete
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task BulkDeleteAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Bulk Update
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task BulkUpdateAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Bulk Add
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task BulkAddAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
}
