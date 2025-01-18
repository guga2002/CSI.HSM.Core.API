using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Core.Core.Interfaces.AbstractInterface;
public interface IAdditioalFeatures<T> where T : class
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
}
