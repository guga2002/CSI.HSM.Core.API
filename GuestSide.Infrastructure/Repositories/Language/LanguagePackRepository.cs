using Core.Core.Data;
using Core.Core.Entities.Language;
using Core.Core.Interfaces.Language;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Language
{
    public class LanguagePackRepository : GenericRepository<LanguagePack>, ILanguagePackRepository
    {
        public LanguagePackRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<LanguagePack> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        #region Get All Active Languages
        public async Task<IEnumerable<LanguagePack>> GetAllActiveLanguages()
        {
            var languages = await DbSet
                .Where(lang => lang.IsActive)
                .OrderBy(lang => lang.Name)
                .ToListAsync();
            return languages;
        }
        #endregion

        #region Get Language by Code
        public async Task<LanguagePack?> GetLanguageByCode(string code)
        {

            var language = await DbSet
                .Where(lang => lang.Code == code && lang.IsActive)
                .FirstOrDefaultAsync();
            return language;
        }
        #endregion

        #region Soft Delete Language
        public async Task<bool> SoftDeleteLanguage(long languageId)
        {
            var language = await DbSet.FirstOrDefaultAsync(lang => lang.Id == languageId);

            if (language == null) return false;

            language.IsActive = false;
            language.UpdateTimestamp();

            await Context.SaveChangesAsync();
            return true;
        }
        #endregion

        #region  Get All (Overridden)
        public override async Task<IEnumerable<LanguagePack>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.OrderBy(lang => lang.Name).ToListAsync(cancellationToken);
        }
        #endregion

        #region Get By ID (Overridden)
        public override async Task<LanguagePack> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(lang => lang.Id == long.Parse(id.ToString()))
                .FirstOrDefaultAsync(cancellationToken);
        }
        #endregion
    }
}
