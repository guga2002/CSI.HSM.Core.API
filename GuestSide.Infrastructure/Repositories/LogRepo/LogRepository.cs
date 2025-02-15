using Core.Core.Data;
using Core.Core.Entities.LogEntities;
using Core.Core.Interfaces.LogEntities;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.LogRepo
{
    public class LogsRepository : GenericRepository<Logs>, ILogsRepository
    {
        public LogsRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Logs> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        #region Get Logs By Severity
        public async Task<IEnumerable<Logs>> GetLogsBySeverity(string logLevel)
        {

            var logs = await DbSet
                .Where(log => log.LogLevel == logLevel)
                .OrderByDescending(log => log.Timestamp)
                .ToListAsync();
            return logs;
        }
        #endregion

        #region  Get Logs By User
        public async Task<IEnumerable<Logs>> GetLogsByUser(long loggerId)
        {
            var logs = await DbSet
                .Where(log => log.LoggerId == loggerId)
                .OrderByDescending(log => log.Timestamp)
                .ToListAsync();
            return logs;
        }
        #endregion

        #region Get Logs By Request ID
        public async Task<IEnumerable<Logs>> GetLogsByRequestId(string requestId)
        {
            var logs = await DbSet
                .Where(log => log.RequestId == requestId)
                .OrderByDescending(log => log.Timestamp)
                .ToListAsync();

            return logs;
        }
        #endregion

        #region  Delete Old Logs
        public async Task<bool> DeleteOldLogs(int days)
        {
            var cutOffDate = DateTime.UtcNow.AddDays(-days);
            var oldLogs = await DbSet.Where(log => log.Timestamp < cutOffDate).ToListAsync();

            if (!oldLogs.Any()) return false;

            DbSet.RemoveRange(oldLogs);
            await Context.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get All Logs (Overridden)
        public override async Task<IEnumerable<Logs>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet
                .OrderByDescending(log => log.Timestamp)
                .ToListAsync(cancellationToken);
        }
        #endregion

        #region Get Log By ID (Overridden)
        public override async Task<Logs> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(log => log.Id == long.Parse(id.ToString()))
                .FirstOrDefaultAsync(cancellationToken);
        }
        #endregion
    }
}
