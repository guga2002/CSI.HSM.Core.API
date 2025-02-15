using Core.Core.Data;
using Core.Core.Entities.Room;
using Core.Core.Interfaces.Room;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Room
{
    public class RoomCategoryRepository : GenericRepository<RoomCategory>, IRoomCategoryRepository
    {
        public RoomCategoryRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<RoomCategory> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        #region Get Category by Name
        public async Task<RoomCategory?> GetCategoryByName(string categoryName)
        {
            return await DbSet
                .Where(category => category.Name == categoryName)
                .FirstOrDefaultAsync();
        }
        #endregion

        #region Get All Active Categories
        public async Task<IEnumerable<RoomCategory>> GetAllActiveCategories()
        {
            return await DbSet
                .Where(category => category.IsActive)
                .OrderBy(category => category.CreatedAt)
                .ToListAsync();
        }
        #endregion

        #region Update Room Category Name
        public async Task<bool> UpdateRoomCategoryName(long categoryId, string newName)
        {
            var category = await DbSet.FindAsync(categoryId);
            if (category == null) return false;

            category.Name = newName;
            category.UpdatedAt = DateTime.UtcNow;
            await Context.SaveChangesAsync();

            return true;
        }
        #endregion
    }
}