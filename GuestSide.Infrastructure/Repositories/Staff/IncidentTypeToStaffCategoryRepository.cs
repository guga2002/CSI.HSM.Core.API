using Core.Core.Data;
using Core.Core.Entities.Staff;
using Core.Core.Interfaces.Staff;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Staff;

public class IncidentTypeToStaffCategoryRepository : GenericRepository<IncidentTypeToStaffCategory>, IIncidentTypeToStaffCategoryRepository
{
    public IncidentTypeToStaffCategoryRepository(GuestSideDb context,
        IRedisCash redisCache, IHttpContextAccessor httpContextAccessor,
        ILogger<IncidentTypeToStaffCategory> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
