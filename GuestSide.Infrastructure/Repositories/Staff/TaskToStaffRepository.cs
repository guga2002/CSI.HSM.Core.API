using Core.Core.Data;
using Core.Core.Entities.Staff;
using Core.Core.Interfaces.Staff;
using Core.Core.Sheared;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Staff
{
    public class TaskToStaffRepository : GenericRepository<TaskToStaff>, ITaskToStaffRepository
    {
        public TaskToStaffRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<TaskToStaff> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        /// <summary>
        /// statusis gasagebad, taskid-is mixedvit momaqvs chanawerebi shemdgom ki vnaxav statuss
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public async Task<TaskToStaff> GetByTaskId(long taskId)
        {
            var taskToStaff = await DbSet.Where(task => task.TaskId == taskId).FirstOrDefaultAsync();
            if (taskToStaff != null) return taskToStaff;
            throw new ArgumentException("No info found by this taskId");
        }

        public async Task<IEnumerable<GroupTasksStatusByCard>> GetTasksStatusByCard(long cardId)
        {
            var res = DbSet
                .Include(io => io.Task)
                .Include(io => io.Status)
                .Where(io => io.Task.CartId == cardId)
                .GroupBy(io => io.Status.Name)
                .Select(group => new GroupTasksStatusByCard
                {
                    Status = group.Key,
                    Tasks = group.Select(io => io.Task).ToList()
                });
            return await res.ToListAsync();
        }
    }
}
