using GuestSide.Core.Data;
using GuestSide.Core.Entities.Task;
using GuestSide.Core.Interfaces.Task;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories.Task
{
    public class TaskRepository : GenericRepository<Tasks>, ITaskRepository
    {
        public TaskRepository(GuestSideDb context) : base(context)
        {
        }

        public async Task<Tasks> GetTaskbycartId(long CartId, CancellationToken cancellationToken = default)
        {
            return await Context.Tasks.Where(io => io.CartId == CartId).FirstOrDefaultAsync()??throw new ArgumentException("No  item found on  this card");
        }
    }
}
