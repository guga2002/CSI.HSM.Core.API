using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Item;
using Domain.Core.Interfaces.Item;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Item
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(CoreSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Cart> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        public async override Task<IEnumerable<Cart>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Context.Carts.Include(io => io.Tasks).ToListAsync(cancellationToken);
        }

        #region  Get Latest Active Cart for Guest
        public async Task<Cart> GetLatestActiveCartForGuestAsync(long guestId)
        {
            var latestCart = await DbSet
                .Where(c => c.GuestId == guestId && !c.IsComplete)
                .OrderByDescending(c => c.Id)
                .FirstOrDefaultAsync();

            if (latestCart != null) return latestCart;

            var newCart = new Cart
            {
                GuestId = guestId,
                WhatWillRobotSay = $"Hi Guest {guestId}, your new cart is ready!",
                LanguageCode = "en",
                IsComplete = false
            };

            await DbSet.AddAsync(newCart);
            await Context.SaveChangesAsync();

            return newCart;
        }
        #endregion

        public async Task<bool> ClearCart(long cartId)
        {
            var cart = await DbSet.Include(c => c.Tasks)
                                  .FirstOrDefaultAsync(io => io.Id == cartId);
            if (cart?.Tasks is null)
                return false;

            cart.Tasks.ToList().ForEach(task => Context.Remove(task));
            return await Context.SaveChangesAsync() > 0;
        }

        public async Task<Cart?> CartSymmary(long cartId)
        {
            return await DbSet
                .Include(c => c.Tasks)
                .Include(io => io.Guest)
                .FirstOrDefaultAsync(io => io.Id == cartId && io.IsActive);
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

            var itemToRemove = taskWithItem?.TaskItems.FirstOrDefault(i => i.ItemId == itemId);
            if (itemToRemove != null)
            {
                taskWithItem.TaskItems.Remove(itemToRemove);
                Context.Remove(itemToRemove);
                await Context.SaveChangesAsync();
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

            if (taskItem is null) return cart;
            taskItem.Quantity = newQuantity;
            await Context.SaveChangesAsync();

            return cart;
        }

        //public async Task<List<Items>> ValidateCartItemsAvailability(long cartId)
        //{
        //    var exceptionalItems = new List<Items>();

        //    var cart = await DbSet
        //        .Include(c => c.Tasks)
        //        .ThenInclude(t => t.TaskItems)
        //        .FirstOrDefaultAsync(c => c.Id == cartId);

        //    if (cart?.Tasks == null)
        //        return exceptionalItems;

        //    var taskItems = cart.Tasks
        //        .SelectMany(t => t.TaskItems)
        //        .ToList();

        //    var itemIds = taskItems
        //        .Select(ti => ti.ItemId)
        //        .Distinct()
        //        .ToList();

        //    var items = await Context.Items
        //        .Where(io => itemIds.Contains(io.Id) && io.IsOrderAble && io.IsActive)
        //        .ToDictionaryAsync(io => io.Id);

        //    bool requiresUpdate = false;

        //    foreach (var taskItem in taskItems)
        //    {
        //        if (items.TryGetValue(taskItem.ItemId, out var item))
        //        {
        //            if (taskItem.Quantity > item.Quantity)
        //            {
        //                exceptionalItems.Add(item);
        //            }
        //            else
        //            {
        //                item.Quantity -= taskItem.Quantity;
        //                requiresUpdate = true;
        //            }
        //        }
        //    }

        //    if (requiresUpdate && exceptionalItems.Count == 0)
        //    {
        //        await using var transaction = await Context.Database.BeginTransactionAsync();
        //        try
        //        {
        //            await Context.SaveChangesAsync();
        //            await transaction.CommitAsync();
        //        }
        //        catch (Exception ex)
        //        {
        //            await transaction.RollbackAsync();
        //            Console.WriteLine($"Transaction rolled back: {ex.Message}");
        //        }
        //    }

        //    return exceptionalItems;
        //}

        public async Task<IEnumerable<Cart>> GetCartByGuestId(long guestId, bool status)
        {
            return await DbSet
                .Include(c => c.Tasks)
                .ThenInclude(c => c.TaskItems)
                .Where(guest => guest.GuestId == guestId && guest.IsComplete == status)
                .ToListAsync() ?? new List<Cart>();
        }
    }
}
