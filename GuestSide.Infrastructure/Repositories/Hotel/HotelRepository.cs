using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Interfaces.Hotel;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace GuestSide.Infrastructure.Repositories.Hotel
{
    public class HotelRepository : GenericRepository<GuestSide.Core.Entities.Hotel.Hotel>, IHotelRepository
    {
        public HotelRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Core.Entities.Hotel.Hotel> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
