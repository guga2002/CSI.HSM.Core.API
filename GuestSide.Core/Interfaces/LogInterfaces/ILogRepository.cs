using Core.Core.Entities.LogEntities;
using Core.Core.Interfaces.AbstractInterface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Core.Interfaces.LogEntities
{
    public interface ILogsRepository : IGenericRepository<Logs>
    {
        Task<IEnumerable<Logs>> GetLogsBySeverity(string logLevel);
        Task<IEnumerable<Logs>> GetLogsByUser(long loggerId);
        Task<IEnumerable<Logs>> GetLogsByRequestId(string requestId);
        Task<bool> DeleteOldLogs(int days);
    }
}