using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Task;
using GuestSide.Core.Interfaces.Task;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GuestSide.Infrastructure.Repositories.Task
{
    public class TaskRepository : GenericRepository<Tasks>, ITaskRepository
    {
        public TaskRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Tasks> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        public async Task<Tasks> GetTaskbycartId(long CartId, CancellationToken cancellationToken = default)
        {
            return await Context.Tasks.Where(io => io.CartId == CartId).FirstOrDefaultAsync()??throw new ArgumentException("No  item found on  this card");
        }
    }
}
