using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Guest;
using GuestSide.Core.Interfaces.Guest;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories.Guest
{
    public class GuestRepository : GenericRepository<Guests>, IGuestRepository
    {
        public GuestRepository(GuestSideDb context, IRedisCash redisCache) : base(context, redisCache)
        {
        }
    }
}
