using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Guest;
using Domain.Core.Interfaces.Guest;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Guest;

public class StatusRepository : GenericRepository<Status>, IStatusRepository
{
    public StatusRepository(CoreSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Status> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
