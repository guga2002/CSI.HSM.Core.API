using Core.Core.Data;
using Core.Core.Entities.Guest;
using Core.Core.Interfaces.Guest;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Guest;

public class StatusRepository : GenericRepository<Status>, IStatusRepository
{
    public StatusRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Status> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
