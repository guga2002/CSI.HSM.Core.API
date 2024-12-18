using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Advertisements;
using GuestSide.Core.Interfaces.Advertisement;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace GuestSide.Infrastructure.Repositories.Advertisement
{
    public class AdvertisementRepository : GenericRepository<Advertisements>, IAdvertisementRepository
    {
        public AdvertisementRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Advertisements> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
