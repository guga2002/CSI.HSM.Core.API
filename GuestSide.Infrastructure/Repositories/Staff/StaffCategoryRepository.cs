using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Interfaces.Staff;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories.Staff
{
    public class StaffCategoryRepository : GenericRepository<StaffCategory>, IStaffCategoryRepository
    {
        public StaffCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
