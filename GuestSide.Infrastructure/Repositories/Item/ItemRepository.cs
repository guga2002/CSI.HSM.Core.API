using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Interfaces.Item;
using GuestSide.Infrastructure.Repositories.AbstractRepository;

namespace GuestSide.Infrastructure.Repositories.Item
{
    public class ItemRepository : GenericRepository<Items>, IItemRepository
    {
        public ItemRepository(GuestSideDb context, IRedisCash redisCache) : base(context, redisCache)
        {
        }
    }
}
