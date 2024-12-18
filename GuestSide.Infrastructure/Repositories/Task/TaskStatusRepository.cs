using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Task;
using GuestSide.Core.Interfaces.Task;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace GuestSide.Infrastructure.Repositories.Task
{
    public class TaskStatusRepository : GenericRepository<TasksStatus>, ITaskStatusRepository
    {
        public TaskStatusRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<TasksStatus> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
