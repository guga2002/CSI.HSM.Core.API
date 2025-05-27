using Common.Data.Entities.LogEntities;
using Core.Application.DTOs.Request.LogModel;
using Core.Application.DTOs.Response.LogModel;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.LogInterfaces
{
    public interface ILogService : IService<LogDto, LogResponseDto, long, Logs>,
        IAdditionalFeatures<LogDto, LogResponseDto, long, Logs>
    {
        /// <summary>
        /// Get logs filtered by severity.
        /// </summary>
        Task<IEnumerable<LogResponseDto>> GetLogsBySeverity(string logLevel, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get logs related to a specific user.
        /// </summary>
        Task<IEnumerable<LogResponseDto>> GetLogsByUser(long loggerId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get logs based on a request ID.
        /// </summary>
        Task<IEnumerable<LogResponseDto>> GetLogsByRequestId(string requestId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete logs older than a specified number of days.
        /// </summary>
        Task<bool> DeleteOldLogs(int days, CancellationToken cancellationToken = default);
    }
}