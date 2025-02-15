using Core.Core.Data;
using Core.Core.Entities.Staff;
using Core.Core.Interfaces.Staff;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Staff
{
    public class StaffSupportRepository : GenericRepository<StaffSupport>, IStaffSupportRepository
    {
        private readonly GuestSideDb _context;
        private readonly IRedisCash _redisCache;
        private readonly ILogger<StaffSupport> _logger;

        public StaffSupportRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<StaffSupport> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
            _context = context;
            _redisCache = redisCache;
            _logger = logger;
        }

        #region Support Ticket Lookup & Filtering
        public async Task<IEnumerable<StaffSupport>> GetTicketsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default)
        {
            return await _context.StaffSupports.AsNoTracking()
                .Where(s => s.StaffId == staffId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<StaffSupport>> GetTicketsByPriorityAsync(SupportTicketPriority priority, CancellationToken cancellationToken = default)
        {
            return await _context.StaffSupports.AsNoTracking()
                .Where(s => s.Priority == priority)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<StaffSupport>> GetTicketsByStatusAsync(SupportTicketStatus status, CancellationToken cancellationToken = default)
        {
            return await _context.StaffSupports.AsNoTracking()
                .Where(s => s.Status == status)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<StaffSupport>> GetTicketsByCategoryAsync(string category, CancellationToken cancellationToken = default)
        {
            return await _context.StaffSupports.AsNoTracking()
                .Where(s => s.Category == category)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<StaffSupport>> GetRecentTicketsAsync(int days, CancellationToken cancellationToken = default)
        {
            var fromDate = DateTime.UtcNow.AddDays(-days);
            return await _context.StaffSupports.AsNoTracking()
                .Where(s => s.CreatedDate >= fromDate)
                .ToListAsync(cancellationToken);
        }
        #endregion

        #region Ticket Management
        public async Task<bool> UpdateTicketStatusAsync(long ticketId, SupportTicketStatus newStatus, CancellationToken cancellationToken = default)
        {
            var ticket = await _context.StaffSupports.FindAsync(new object[] { ticketId }, cancellationToken);
            if (ticket == null) return false;

            ticket.Status = newStatus;
            ticket.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(ticketId);
            return true;
        }

        public async Task<bool> ResolveTicketAsync(long ticketId, string resolutionNotes, CancellationToken cancellationToken = default)
        {
            var ticket = await _context.StaffSupports.FindAsync(new object[] { ticketId }, cancellationToken);
            if (ticket == null) return false;

            ticket.Status = SupportTicketStatus.Resolved;
            ticket.UpdatedAt = DateTime.UtcNow;
            ticket.ResolvedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(ticketId);
            return true;
        }

        public async Task<bool> AddAttachmentToTicketAsync(long ticketId, List<string> attachments, CancellationToken cancellationToken = default)
        {
            var ticket = await _context.StaffSupports.FindAsync(new object[] { ticketId }, cancellationToken);
            if (ticket == null) return false;

            ticket.AttachmentUrls = (ticket.AttachmentUrls ?? new List<string>()).Concat(attachments).ToList();
            ticket.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(ticketId);
            return true;
        }
        #endregion

        #region Support Ticket Analysis
        public async Task<int> CountOpenTicketsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.StaffSupports
                .CountAsync(s => s.Status == SupportTicketStatus.Open, cancellationToken);
        }

        public async Task<int> CountResolvedTicketsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.StaffSupports
                .CountAsync(s => s.Status == SupportTicketStatus.Resolved, cancellationToken);
        }

        public async Task<int> CountHighPriorityTicketsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.StaffSupports
                .CountAsync(s => s.Priority == SupportTicketPriority.High || s.Priority == SupportTicketPriority.Critical, cancellationToken);
        }
        #endregion

        #region Caching Helpers
        private async Task<bool> InvalidateCache(long ticketId)
        {
            var cacheKey = $"StaffSupport_GetById_{ticketId}";
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
}
