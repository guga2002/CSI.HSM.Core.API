using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Staff;
using Domain.Core.Interfaces.Staff;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Staff
{
    public class StaffSupportResponseRepository : GenericRepository<StaffSupportResponse>, IStaffSupportResponseRepository
    {
        private readonly GuestSideDb _context;
        private readonly IRedisCash _redisCache;
        private readonly ILogger<StaffSupportResponse> _logger;

        public StaffSupportResponseRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<StaffSupportResponse> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
            _context = context;
            _redisCache = redisCache;
            _logger = logger;
        }

        #region Response Lookup & Filtering
        public async Task<IEnumerable<StaffSupportResponse>> GetResponsesByTicketIdAsync(long ticketId, CancellationToken cancellationToken = default)
        {
            return await _context.StaffSupportResponses.AsNoTracking()
                .Where(r => r.TicketId == ticketId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<StaffSupportResponse>> GetSupportTeamResponsesAsync(bool isFromSupportTeam, CancellationToken cancellationToken = default)
        {
            return await _context.StaffSupportResponses.AsNoTracking()
                .Where(r => r.IsFromSupportTeam == isFromSupportTeam)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<StaffSupportResponse>> GetRecentResponsesAsync(int days, CancellationToken cancellationToken = default)
        {
            var fromDate = DateTime.UtcNow.AddDays(-days);
            return await _context.StaffSupportResponses.AsNoTracking()
                .Where(r => r.CreatedAt >= fromDate)
                .ToListAsync(cancellationToken);
        }
        #endregion

        #region Response Management
        public async Task<bool> UpdateResponseMessageAsync(long responseId, string newMessage, CancellationToken cancellationToken = default)
        {
            var response = await _context.StaffSupportResponses.FindAsync(new object[] { responseId }, cancellationToken);
            if (response == null) return false;

            response.ResponseMessage = newMessage;
            response.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(responseId);
            return true;
        }

        public async Task<bool> AddAttachmentToResponseAsync(long responseId, List<string> attachments, CancellationToken cancellationToken = default)
        {
            var response = await _context.StaffSupportResponses.FindAsync(new object[] { responseId }, cancellationToken);
            if (response == null) return false;

            response.AttachmentUrls = (response.AttachmentUrls ?? new List<string>()).Concat(attachments).ToList();
            response.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(responseId);
            return true;
        }

        public async Task<bool> MarkResponseAsSupportTeamAsync(long responseId, bool isFromSupportTeam, CancellationToken cancellationToken = default)
        {
            var response = await _context.StaffSupportResponses.FindAsync(new object[] { responseId }, cancellationToken);
            if (response == null) return false;

            response.IsFromSupportTeam = isFromSupportTeam;
            response.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(responseId);
            return true;
        }
        #endregion

        #region Response Analytics
        public async Task<int> CountResponsesPerTicketAsync(long ticketId, CancellationToken cancellationToken = default)
        {
            return await _context.StaffSupportResponses
                .CountAsync(r => r.TicketId == ticketId, cancellationToken);
        }

        public async Task<int> CountSupportTeamResponsesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.StaffSupportResponses
                .CountAsync(r => r.IsFromSupportTeam, cancellationToken);
        }
        #endregion

        #region Caching Helpers
        private async Task<bool> InvalidateCache(long responseId)
        {
            var cacheKey = $"StaffSupportResponse_GetById_{responseId}";
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
