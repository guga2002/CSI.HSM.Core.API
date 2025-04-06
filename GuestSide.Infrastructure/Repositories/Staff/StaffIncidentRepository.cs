using Core.Core.Data;
using Core.Core.Entities.Enums;
using Core.Core.Entities.Staff;
using Core.Core.Interfaces.Staff;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Staff;

public class StaffIncidentRepository : GenericRepository<StaffIncident>, IStaffIncidentRepository
{
    private readonly GuestSideDb _context;
    private readonly IRedisCash _redisCache;
    private readonly ILogger<StaffIncident> _logger;

    public StaffIncidentRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<StaffIncident> logger)
        : base(context, redisCache, httpContextAccessor, logger)
    {
        _context = context;
        _redisCache = redisCache;
        _logger = logger;
    }

    #region Incident Lookup & Filtering
    public async Task<IEnumerable<StaffIncident>> GetIncidentsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default)
    {
        return await _context.StaffIncidents.AsNoTracking()
            .Where(i => i.ReportedByStaffId == staffId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<StaffIncident>> GetIncidentsBySeverityAsync(PriorityEnum severity, CancellationToken cancellationToken = default)
    {
        return await _context.StaffIncidents.AsNoTracking()
            .Where(i => i.Severity == severity)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<StaffIncident>> GetIncidentsByStatusAsync(StatusEnum status, CancellationToken cancellationToken = default)
    {
        return await _context.StaffIncidents.AsNoTracking()
            .Where(i => i.Status == status)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<StaffIncident>> GetIncidentsByTypeAsync(long incidentTypeId, CancellationToken cancellationToken = default)
    {
        return await _context.StaffIncidents.AsNoTracking()
            .Where(i => i.IncidentTypeId == incidentTypeId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<StaffIncident>> GetUrgentIncidentsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.StaffIncidents.AsNoTracking()
            .Where(i => i.RequiresImmediateAction)
            .ToListAsync(cancellationToken);
    }
    #endregion

    #region Incident Management
    public async Task<bool> UpdateIncidentStatusAsync(long incidentId, StatusEnum newStatus, CancellationToken cancellationToken = default)
    {
        var incident = await _context.StaffIncidents.FindAsync(new object[] { incidentId }, cancellationToken);
        if (incident == null) return false;

        incident.Status = newStatus;
        incident.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync(cancellationToken);

        await InvalidateCache(incidentId);
        return true;
    }

    public async Task<bool> ResolveIncidentAsync(long incidentId, string resolutionNotes, CancellationToken cancellationToken = default)
    {
        var incident = await _context.StaffIncidents.FindAsync(new object[] { incidentId }, cancellationToken);
        if (incident == null) return false;

        incident.Status = StatusEnum.Resolved;
        incident.ResolutionNotes = resolutionNotes;
        incident.ResolvedAt = DateTime.UtcNow;
        incident.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync(cancellationToken);

        await InvalidateCache(incidentId);
        return true;
    }
    #endregion

    #region Incident Analysis
    public async Task<int> CountOpenIncidentsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.StaffIncidents
            .CountAsync(i => i.Status == StatusEnum.Open, cancellationToken);
    }

    public async Task<int> CountResolvedIncidentsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.StaffIncidents
            .CountAsync(i => i.Status == StatusEnum.Resolved, cancellationToken);
    }

    public async Task<int> CountUrgentIncidentsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.StaffIncidents
            .CountAsync(i => i.RequiresImmediateAction, cancellationToken);
    }
    #endregion

    #region  Caching Helpers
    private async Task<bool> InvalidateCache(long incidentId)
    {
        var cacheKey = $"StaffIncident_GetById_{incidentId}";
        try
        {
            await _redisCache.RemoveCache(cacheKey);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error invalidating cache for key {CacheKey}", cacheKey);
            return false;
        }
    }
    #endregion
}
