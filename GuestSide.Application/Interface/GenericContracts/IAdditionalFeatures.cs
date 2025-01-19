using System.Linq.Expressions;

namespace Core.Application.Interface.GenericContracts;

public interface IAdditionalFeatures<RequestDto, ResponseDto, TKey, DatabaseEntity>
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
    Task<IEnumerable<ResponseDto>> ExecuteRawSql<TResult>(string query, object[] parameters, CancellationToken cancellationToken = default);
    #endregion

    #region Soft Delete
    Task<ResponseDto> SoftDelete(TKey id, CancellationToken cancellationToken = default);
    #endregion


    /// <summary>
    /// check if record exist
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> ExistsAsync(Expression<Func<RequestDto, bool>> predicate, CancellationToken cancellationToken = default);

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
    Task<(IEnumerable<ResponseDto>, int)> GetPagedAsync(
    Expression<Func<DatabaseEntity, bool>> predicate,
    int pageNumber,
    int pageSize,
    Expression<Func<DatabaseEntity, object>> orderBy,
    bool isAscending = true,
    CancellationToken cancellationToken = default);

    /// <summary>
    /// Bulk Delete
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task BulkDeleteAsync(IEnumerable<RequestDto> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Bulk Update
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task BulkUpdateAsync(IEnumerable<RequestDto> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Bulk Add
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task BulkAddAsync(IEnumerable<RequestDto> entities, CancellationToken cancellationToken = default);
}
