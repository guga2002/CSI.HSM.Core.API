using Core.Core.Data;
using Core.Core.Entities.Audio;
using Core.Core.Interfaces.Audio;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Audio
{
    public class AudioResponseCategoryRepository : GenericRepository<AudioResponseCategory>, IAudioResponseCategoryRepository
    {
        public AudioResponseCategoryRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<AudioResponseCategory> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        /// <summary>
        /// Get a category by its name
        /// </summary>
        public async Task<AudioResponseCategory> GetCategoryByNameAsync(string categoryName)
        {
            return await DbSet
                .FirstOrDefaultAsync(c => c.CategoryName == categoryName);
        }

        /// <summary>
        /// Get all available categories
        /// </summary>
        public async Task<IEnumerable<AudioResponseCategory>> GetAllCategoriesAsync()
        {
            return await DbSet
                .OrderBy(c => c.CategoryName)
                .ToListAsync();
        }

        /// <summary>
        /// Update the description of an existing category
        /// </summary>
        public async Task<bool> UpdateCategoryDescriptionAsync(long categoryId, string newDescription)
        {
            var category = await DbSet.FindAsync(categoryId);
            if (category == null) return false;

            category.Description = newDescription;
            Context.Update(category);
            await Context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Delete a category by ID
        /// </summary>
        public async Task<bool> DeleteCategoryByIdAsync(long categoryId)
        {
            var category = await DbSet.FindAsync(categoryId);
            if (category == null) return false;

            DbSet.Remove(category);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
