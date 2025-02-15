using Core.Core.Data;
using Core.Core.Entities.Staff;
using Core.Core.Interfaces.Staff;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Staff
{
    public class StaffCategoryRepository : GenericRepository<StaffCategory>, IStaffCategoryRepository
    {
        public StaffCategoryRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<StaffCategory> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
