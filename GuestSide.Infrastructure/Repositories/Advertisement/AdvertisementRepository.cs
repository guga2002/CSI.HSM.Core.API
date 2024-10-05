using GuestSide.Core.Data;
using GuestSide.Core.Entities.Advertisements;
using GuestSide.Core.Interfaces.Advertisement;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories.Advertisement
{
    public class AdvertisementRepository : GenericRepository<Advertisements>, IAdvertisementRepository
    {
        public AdvertisementRepository(GuestSideDb context) : base(context)
        {
        }
    }
}
