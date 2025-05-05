using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Task;
using Domain.Core.Interfaces.Task;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Task;

public class TaskLogsRepository : GenericRepository<TaskLogs>, ITaskLogsRepository
{
    public TaskLogsRepository(CoreSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<TaskLogs> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
