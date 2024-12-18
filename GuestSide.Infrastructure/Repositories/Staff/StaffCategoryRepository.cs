using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Interfaces.Staff;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories.Staff
{
    public class StaffCategoryRepository : GenericRepository<StaffCategory>, IStaffCategoryRepository
    {
        public StaffCategoryRepository(GuestSideDb context, IRedisCash redisCache) : base(context, redisCache)
        {
        }
    }
}
