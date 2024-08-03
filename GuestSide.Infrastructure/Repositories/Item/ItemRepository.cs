using GuestSide.Core.Entities.Item;
using GuestSide.Core.Interfaces.Item;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories.Item
{
    public class ItemRepository : GenericRepository<Items>, IItemRepository
    {
        public ItemRepository(DbContext context) : base(context)
        {
        }
    }
}
