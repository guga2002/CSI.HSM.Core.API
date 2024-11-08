using GuestSide.Core.Data;
using GuestSide.Core.Interfaces.Hotel;
using GuestSide.Infrastructure.Repositories.AbstractRepository;

namespace GuestSide.Infrastructure.Repositories.Hotel
{
    public class HotelRepository : GenericRepository<GuestSide.Core.Entities.Hotel.Hotel>, IHotelRepository
    {
        public HotelRepository(GuestSideDb context) : base(context)
        {
        }
    }
}
