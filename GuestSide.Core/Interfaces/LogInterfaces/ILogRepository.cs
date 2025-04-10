using Domain.Core.Entities.LogEntities;
using Domain.Core.Interfaces.AbstractInterface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces.LogInterfaces
{
    public interface ILogsRepository : IGenericRepository<Logs>
    {
        Task<IEnumerable<Logs>> GetLogsBySeverity(string logLevel);
        Task<IEnumerable<Logs>> GetLogsByUser(long loggerId);
        Task<IEnumerable<Logs>> GetLogsByRequestId(string requestId);
        Task<bool> DeleteOldLogs(int days);
    }
}