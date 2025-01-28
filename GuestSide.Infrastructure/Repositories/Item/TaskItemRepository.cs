using Core.Core.Entities.Item;
using Core.Core.Interfaces.Item;
using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Item;

public class TaskItemRepository : GenericRepository<TaskItem>, ITaskItem
{
    private readonly GuestSideDb _context;
    public TaskItemRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<TaskItem> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
        _context = context;
    }

    public  async Task<IEnumerable<TaskItem>> GetTaskItemsByCartId(long CartId)
    {
       return await _context.TaskItems.
            Include(io => io.Task)
            .Where(io => io.Task.CartId == CartId).ToListAsync();
    }
}
