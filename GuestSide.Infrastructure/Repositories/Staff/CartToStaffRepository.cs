using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Interfaces.Staff;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GuestSide.Infrastructure.Repositories.Staff
{
    public class CartToStaffRepository : GenericRepository<TaskToStaff>, ICartToStaffRepository
    {
        public CartToStaffRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<TaskToStaff> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
