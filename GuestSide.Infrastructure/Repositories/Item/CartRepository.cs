using System.Transactions;
using Core.Persistance.Cashing;
using Core.Persistance.LoggingConfigs;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Interfaces.Item;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GuestSide.Infrastructure.Repositories.Item
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Cart> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        public async override Task<IEnumerable<Cart>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Context.Carts.Include(io => io.Tasks).ToListAsync(cancellationToken);
        }

        public async Task<bool> ClearCart(long cartId)
        {
            var cart = await DbSet.Include(c => c.Tasks)
                                  .FirstOrDefaultAsync(io => io.Id == cartId);
            if (cart == null || cart.Tasks is null)
                return false;
            cart.Tasks.ToList().ForEach(task => Context.Remove(task));
            return await Context.SaveChangesAsync() > 0;
        }

        public async Task<Cart?> CartSymmary(long cartId)
        {
            var cart = await DbSet.Include(c => c.Tasks).Include(io => io.guest).FirstOrDefaultAsync(
                io => io.Id == cartId && io.IsActive);

            return cart;
        }


        public async Task<Cart> RemoveItemFromCart(long cartId, long itemId)
        {
            var cart = await DbSet
                .Include(c => c.Tasks)
                .ThenInclude(t => t.TaskItems)
                .FirstOrDefaultAsync(c => c.Id == cartId);

            if (cart == null)
                return null; 

            var taskWithItem = cart.Tasks.FirstOrDefault(t => t.TaskItems.Any(i => i.ItemId == itemId));

            if (taskWithItem is not null)
            {
                var itemToRemove = taskWithItem.TaskItems.FirstOrDefault(i => i.ItemId == itemId);
                if (itemToRemove is not null)
                {
                    taskWithItem.TaskItems.Remove(itemToRemove);
                    Context.Remove(itemToRemove); 
                    await Context.SaveChangesAsync();
                }
            }
            return cart;
        }


        public async Task<Cart> UpdateItemQuantityInCart(long cartId, long itemId, int newQuantity)
        {
            var cart = await DbSet
               .Include(c => c.Tasks)
               .ThenInclude(t => t.TaskItems)
               .FirstOrDefaultAsync(c => c.Id == cartId);

            if (cart == null)
                return null; 

            var taskItem = cart.Tasks
                .SelectMany(t => t.TaskItems) 
                .FirstOrDefault(i => i.ItemId == itemId);

            if (taskItem is not null)
            {
                taskItem.Quantity = newQuantity;
                await Context.SaveChangesAsync();
            }

            return cart;
        }

        public async Task<List<Items>> ValidateCartItemsAvailability(long cartId)
        {
            List<Items> exceptionalItems = new List<Items>();

            var cart = await DbSet
                .Include(c => c.Tasks)
                .ThenInclude(t => t.TaskItems)
                .FirstOrDefaultAsync(c => c.Id == cartId);

            if (cart == null || cart.Tasks == null)
                return exceptionalItems;

            var taskItems = cart.Tasks
                .SelectMany(t => t.TaskItems)
                .ToList();

            var itemIds = taskItems
                .Select(ti => ti.ItemId)
                .Distinct()
                .ToList();

            var items = await Context.Items
                .Where(io => itemIds.Contains(io.Id) && io.IsOrderable && io.IsActive)
                .ToDictionaryAsync(io => io.Id);

            bool requiresUpdate = false;

            foreach (var taskItem in taskItems)
            {
                if (items.TryGetValue(taskItem.ItemId, out var item))
                {
                    if (taskItem.Quantity > item.Quantity)
                    {
                        exceptionalItems.Add(item);
                    }
                    else
                    {
                        item.Quantity -= taskItem.Quantity;
                        requiresUpdate = true;
                    }
                }
            }

            if (requiresUpdate && exceptionalItems.Count == 0)
            {
                await using var transaction = await Context.Database.BeginTransactionAsync();
                try
                {
                    await Context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine($"Transaction rolled back: {ex.Message}");
                }
            }

            return exceptionalItems;
        }

        public async Task<IEnumerable<Cart>> GetCartByGuestId(long guestId, bool status)
        {
            var carts = await DbSet.Include(c => c.Tasks)
                .ThenInclude(c => c.TaskItems).Where(guest => guest.GuestId == guestId && guest.IsComplete == status).ToListAsync();
            return carts ?? new List<Cart>();
        }
    }
}
