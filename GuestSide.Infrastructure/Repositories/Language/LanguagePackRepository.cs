using Core.Core.Interfaces.Language;
using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Language;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Language;

public class LanguagePackRepository : GenericRepository<LanguagePack>, ILanguagePackRepository
{
    public LanguagePackRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<LanguagePack> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
