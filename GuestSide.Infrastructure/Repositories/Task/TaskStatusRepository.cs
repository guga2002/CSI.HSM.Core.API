using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Task;
using Domain.Core.Interfaces.Task;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Task
{
    public class TaskStatusRepository : GenericRepository<TasksStatus>, ITaskStatusRepository
    {
        public TaskStatusRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<TasksStatus> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        #region Get Status by Name
        public async Task<TasksStatus?> GetStatusByName(string statusName)
        {
            return await DbSet
                .Where(status => status.Name == statusName)
                .FirstOrDefaultAsync();
        }
        #endregion

        #region Update Task Status Name
        public async Task<bool> UpdateTaskStatusName(long statusId, string newName)
        {
            var status = await DbSet.FindAsync(statusId);
            if (status == null) return false;

            status.Name = newName;
            status.UpdatedAt = DateTime.UtcNow;
            await Context.SaveChangesAsync();

            return true;
        }
        #endregion

        #region Get All Active Statuses
        public async Task<IEnumerable<TasksStatus>> GetAllActiveStatuses()
        {
            return await DbSet
                .Where(status => status.IsActive)
                .OrderBy(status => status.CreatedAt)
                .ToListAsync();
        }
        #endregion
    }
}