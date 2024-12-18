using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Guest;
using GuestSide.Core.Interfaces.Guest;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GuestSide.Infrastructure.Repositories.Guest
{
    public class GuestRepository : GenericRepository<Guests>, IGuestRepository
    {
        public GuestRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Guests> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
