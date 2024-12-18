using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Advertisments;
using GuestSide.Core.Interfaces.Advertisement;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GuestSide.Infrastructure.Repositories.Advertisement
{
    public class AdvertisementTypeRepository : GenericRepository<AdvertisementType>, IAdvertisementTypeRepository
    {
        public AdvertisementTypeRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<AdvertisementType> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
