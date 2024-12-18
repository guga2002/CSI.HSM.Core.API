using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Interfaces.Staff;
using GuestSide.Infrastructure.Repositories.AbstractRepository;

namespace GuestSide.Infrastructure.Repositories.Staff
{
    public class StaffRepository : GenericRepository<Staffs>, IStaffRepository
    {
        public StaffRepository(GuestSideDb context, IRedisCash redisCache) : base(context, redisCache)
        {
        }
    }
}
