using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Interfaces.Staff;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace GuestSide.Infrastructure.Repositories.Staff
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
            var taskToStaff = DbSet.Where(task => task.TaskId == taskId).FirstOrDefault();
            if (taskToStaff != null) return taskToStaff;
            throw new ArgumentException("No info found by this taskId");
        }
    }
}
