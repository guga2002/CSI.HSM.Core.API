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
    }
}
