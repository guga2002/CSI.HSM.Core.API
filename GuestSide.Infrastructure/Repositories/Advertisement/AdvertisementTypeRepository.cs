using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Advertisments;
using GuestSide.Core.Interfaces.Advertisement;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories.Advertisement
{
    public class AdvertisementTypeRepository : GenericRepository<AdvertisementType>, IAdvertisementTypeRepository
    {
        public AdvertisementTypeRepository(GuestSideDb context, IRedisCash redisCache) : base(context, redisCache)
        {
        }
    }
}
