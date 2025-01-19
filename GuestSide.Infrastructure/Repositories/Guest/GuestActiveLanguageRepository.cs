using Core.Core.Entities.Guest;
using Core.Core.Interfaces.Guest;
using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Guest;

public class GuestActiveLanguageRepository : GenericRepository<GuestActiveLanguage>, IGuestActiveLanguageRepository
{
    public GuestActiveLanguageRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<GuestActiveLanguage> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
