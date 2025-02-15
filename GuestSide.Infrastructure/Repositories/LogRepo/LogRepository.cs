using Core.Core.Data;
using Core.Core.Entities.LogEntities;
using Core.Core.Interfaces.LogInterfaces;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.LogRepo
{
    public class LogRepository : GenericRepository<Logs>, ILogRepository
    {
        public LogRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Logs> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
