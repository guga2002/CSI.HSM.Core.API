using GuestSide.Core.Entities.Guest;
using GuestSide.Core.Interfaces;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories
{
    public class GuestRepository : GenericRepository<Guests>, IGuestRepository
    {
        public GuestRepository(DbContext context) : base(context)
        {
        }


    }
}
