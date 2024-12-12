using GuestSide.Core.Data;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Interfaces.Staff;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories.Staff
{
    public class CartToStaffRepository : GenericRepository<TaskToStaff>, ICartToStaffRepository
    {
        public CartToStaffRepository(GuestSideDb context) : base(context)
        {
        }
    }
}
