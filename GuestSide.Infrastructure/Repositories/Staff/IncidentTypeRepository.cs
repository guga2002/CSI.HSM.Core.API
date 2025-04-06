using Core.Core.Data;
using Core.Core.Entities.Staff;
using Core.Core.Interfaces.Staff;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Staff;

public class IncidentTypeRepository : GenericRepository<IncidentType>, IIncidentTypeRepository
{
    public IncidentTypeRepository(GuestSideDb context, IRedisCash redisCache, 
        IHttpContextAccessor httpContextAccessor, ILogger<IncidentType> logger)
        : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
