using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Advertisements;
using Domain.Core.Interfaces.Advertisement;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Advertisement
{
    public class AdvertisementTypeRepository : GenericRepository<AdvertisementType>, IAdvertisementTypeRepository
    {
        public AdvertisementTypeRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<AdvertisementType> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        /// <summary>
        /// Get an advertisement type by name
        /// </summary>
        public async Task<AdvertisementType> GetAdvertisementTypeByNameAsync(string name)
        {
            return await DbSet.FirstOrDefaultAsync(at => at.Name == name);
        }

        /// <summary>
        /// Get all advertisement types
        /// </summary>
        public async Task<IEnumerable<AdvertisementType>> GetAllAdvertisementTypesAsync()
        {
            return await DbSet
                .OrderBy(at => at.Name)
                .ToListAsync();
        }

        /// <summary>
        /// Get advertisement types by language code
        /// </summary>
        public async Task<IEnumerable<AdvertisementType>> GetAdvertisementTypesByLanguageAsync(string languageCode)
        {
            return await DbSet
                .Where(at => at.LanguageCode == languageCode)
                .OrderBy(at => at.Name)
                .ToListAsync();
        }

        /// <summary>
        /// Update the description of an advertisement type
        /// </summary>
        public async Task<bool> UpdateAdvertisementTypeDescriptionAsync(long advertisementTypeId, string newDescription)
        {
            var advertisementType = await DbSet.FindAsync(advertisementTypeId);
            if (advertisementType == null) return false;

            advertisementType.Description = newDescription;
            await Context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Delete an advertisement type by ID
        /// </summary>
        public async Task<bool> DeleteAdvertisementTypeByIdAsync(long advertisementTypeId)
        {
            var advertisementType = await DbSet.FindAsync(advertisementTypeId);
            if (advertisementType == null) return false;

            DbSet.Remove(advertisementType);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
