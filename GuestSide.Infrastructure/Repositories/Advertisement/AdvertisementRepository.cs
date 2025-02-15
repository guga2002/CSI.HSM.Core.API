using Core.Core.Data;
using Core.Core.Entities.Advertisements;
using Core.Core.Interfaces.Advertisement;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Advertisement
{
    public class AdvertisementRepository : GenericRepository<Core.Entities.Advertisements.Advertisement>, IAdvertisementRepository
    {
        public AdvertisementRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Core.Entities.Advertisements.Advertisement> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
