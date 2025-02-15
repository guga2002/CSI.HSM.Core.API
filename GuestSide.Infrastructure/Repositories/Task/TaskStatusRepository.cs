using Core.Core.Data;
using Core.Core.Entities.Task;
using Core.Core.Interfaces.Task;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Task
{
    public class TaskStatusRepository : GenericRepository<TasksStatus>, ITaskStatusRepository
    {
        public TaskStatusRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<TasksStatus> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
