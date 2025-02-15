using Core.Core.Data;
using Core.Core.Entities.Guest;
using Core.Core.Interfaces.Guest;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Guest;

public class GuestActiveLanguageRepository : GenericRepository<GuestActiveLanguage>, IGuestActiveLanguageRepository
{
    public GuestActiveLanguageRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<GuestActiveLanguage> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
