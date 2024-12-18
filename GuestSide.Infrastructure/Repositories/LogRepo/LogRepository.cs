using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.LogEntities;
using GuestSide.Core.Interfaces.LogInterfaces;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace GuestSide.Infrastructure.Repositories.LogRepo
{
    public class LogRepository : GenericRepository<Logs>, ILogRepository
    {
        public LogRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Logs> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
