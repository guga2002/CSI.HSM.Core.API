using Core.Core.Data;
using Core.Core.Entities.Advertisements;
using Core.Core.Interfaces.Advertisement;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Advertisement
{
    public class AdvertisementRepository : GenericRepository<Advertisements>, IAdvertisementRepository
    {
        public AdvertisementRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Advertisements> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
