using Core.Core.Interfaces.Guest;
using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Guest;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Guest;

public class StatusRepository : GenericRepository<Status>, IStatusRepository
{
    public StatusRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Status> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
