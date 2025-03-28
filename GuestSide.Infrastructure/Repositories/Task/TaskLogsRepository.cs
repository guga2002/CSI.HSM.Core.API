using Core.Core.Data;
using Core.Core.Entities.Task;
using Core.Core.Interfaces.Task;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Task;

public class TaskLogsRepository : GenericRepository<TaskLogs>, ITaskLogsRepository
{
    public TaskLogsRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<TaskLogs> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
