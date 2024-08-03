using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Interfaces.Staff;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories.Staff
{
    public class StaffRepository : GenericRepository<Staffs>, IStaffRepository
    {
        public StaffRepository(DbContext context) : base(context)
        {
        }
    }
}
