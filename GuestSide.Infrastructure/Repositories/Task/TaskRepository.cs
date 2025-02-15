using Core.Core.Data;
using Core.Core.Entities.Task;
using Core.Core.Interfaces.Task;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Task
{
    public class TaskRepository : GenericRepository<Tasks>, ITaskRepository
    {
        public TaskRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Tasks> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        public async Task<IEnumerable<Tasks>> GetTasksbycartId(long CartId, CancellationToken cancellationToken = default)
        {
            return await Context.Tasks.Where(io => io.CartId == CartId).ToListAsync()
                ?? throw new ArgumentException("No  item found on  this card");
        }
    }
}
