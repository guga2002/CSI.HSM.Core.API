using Core.Core.Data;
using Core.Core.Interfaces.Advertisement;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Advertisement
{
    public class AdvertisementRepository : GenericRepository<Core.Entities.Advertisements.Advertisement>, IAdvertisementRepository
    {
        public AdvertisementRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Core.Entities.Advertisements.Advertisement> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        /// <summary>
        /// Get all active advertisements (current date falls within the start and end date)
        /// </summary>
        public async Task<IEnumerable<Core.Entities.Advertisements.Advertisement>> GetActiveAdvertisementsAsync()
        {
            var currentDate = DateTime.UtcNow;
            return await DbSet
                .Where(a => a.StartDate <= currentDate && (a.EndDate == null || a.EndDate >= currentDate))
                .OrderByDescending(a => a.StartDate)
                .ToListAsync();
        }

        /// <summary>
        /// Get advertisements by type
        /// </summary>
        public async Task<IEnumerable<Core.Entities.Advertisements.Advertisement>> GetAdvertisementsByTypeAsync(long advertisementTypeId)
        {
            return await DbSet
                .Where(a => a.AdvertisementTypeId == advertisementTypeId)
                .OrderByDescending(a => a.StartDate)
                .ToListAsync();
        }

        /// <summary>
        /// Get advertisements within a specific date range
        /// </summary>
        public async Task<IEnumerable<Core.Entities.Advertisements.Advertisement>> GetAdvertisementsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await DbSet
                .Where(a => a.StartDate >= startDate && a.EndDate <= endDate)
                .OrderByDescending(a => a.StartDate)
                .ToListAsync();
        }

        /// <summary>
        /// Get advertisements by language
        /// </summary>
        public async Task<IEnumerable<Core.Entities.Advertisements.Advertisement>> GetAdvertisementsByLanguageAsync(string languageCode)
        {
            return await DbSet
                .Where(a => a.LanguageCode == languageCode)
                .OrderByDescending(a => a.StartDate)
                .ToListAsync();
        }

        /// <summary>
        /// Get an advertisement by its title
        /// </summary>
        public async Task<Core.Entities.Advertisements.Advertisement> GetAdvertisementByTitleAsync(string title)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Title == title);
        }

        /// <summary>
        /// Update the start and end dates of an advertisement
        /// </summary>
        public async Task<bool> UpdateAdvertisementDatesAsync(long id, DateTime? newStartDate, DateTime? newEndDate)
        {
            var advertisement = await DbSet.FindAsync(id);
            if (advertisement == null) return false;

            advertisement.StartDate = newStartDate;
            advertisement.EndDate = newEndDate;

            Context.Update(advertisement);
            await Context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Delete an advertisement by ID
        /// </summary>
        public async Task<bool> DeleteAdvertisementByIdAsync(long id)
        {
            var advertisement = await DbSet.FindAsync(id);
            if (advertisement == null) return false;

            DbSet.Remove(advertisement);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
