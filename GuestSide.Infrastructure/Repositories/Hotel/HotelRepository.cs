using Core.Core.Data;
using Core.Core.Interfaces.Hotel;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Hotel
{
    public class HotelRepository : GenericRepository<Core.Entities.Hotel.Hotel>, IHotelRepository
    {
        public HotelRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Core.Entities.Hotel.Hotel> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
