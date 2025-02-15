using Core.Core.Data;
using Core.Core.Entities.Guest;
using Core.Core.Interfaces.Guest;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Guest
{
    public class GuestActiveLanguageRepository : GenericRepository<GuestActiveLanguage>, IGuestActiveLanguageRepository
    {
        public GuestActiveLanguageRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<GuestActiveLanguage> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        /// <summary>
        /// Get the active language for a specific guest
        /// </summary>
        public async Task<GuestActiveLanguage> GetActiveLanguageByGuestIdAsync(long guestId)
        {
            return await DbSet
                .Where(l => l.GuestId == guestId)
                .OrderByDescending(l => l.SetDate) // Fetch the latest set language
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get the full language history of a guest
        /// </summary>
        public async Task<IEnumerable<GuestActiveLanguage>> GetGuestLanguageHistoryAsync(long guestId)
        {
            return await DbSet
                .Where(l => l.GuestId == guestId)
                .OrderByDescending(l => l.SetDate)
                .ToListAsync();
        }

        /// <summary>
        /// Set or update a guest's active language
        /// </summary>
        public async Task<bool> SetGuestActiveLanguageAsync(long guestId, string languageCode)
        {
            var guestLanguage = new GuestActiveLanguage
            {
                GuestId = guestId,
                LanguageCode = languageCode,
                SetDate = DateTime.UtcNow
            };

            await DbSet.AddAsync(guestLanguage);
            await Context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Remove a guest's active language (soft delete for record tracking)
        /// </summary>
        public async Task<bool> RemoveGuestActiveLanguageAsync(long guestId)
        {
            var guestLanguages = await DbSet
                .Where(l => l.GuestId == guestId)
                .ToListAsync();

            if (!guestLanguages.Any())
                return false;

            DbSet.RemoveRange(guestLanguages);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
