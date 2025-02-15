using Core.Core.Data;
using Core.Core.Entities.Advertisements;
using Core.Core.Interfaces.Advertisement;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Advertisement
{
    public class AdvertisementTypeRepository : GenericRepository<AdvertisementType>, IAdvertisementTypeRepository
    {
        public AdvertisementTypeRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<AdvertisementType> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
