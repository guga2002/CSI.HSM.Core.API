using Core.Core.Data;
using Core.Core.Entities.Language;
using Core.Core.Interfaces.Language;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Language;

public class LanguagePackRepository : GenericRepository<LanguagePack>, ILanguagePackRepository
{
    public LanguagePackRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<LanguagePack> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
