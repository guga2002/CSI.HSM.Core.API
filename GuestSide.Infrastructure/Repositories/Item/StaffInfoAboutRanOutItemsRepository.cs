using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Enums;
using Domain.Core.Entities.Item;
using Domain.Core.Interfaces.Item;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Item
{
    public class StaffInfoAboutRanOutItemsRepository : GenericRepository<StaffInfoAboutRanOutItems>, IStaffInfoAboutRanOutItemsRepository
    {
        private readonly GuestSideDb _context;
        private readonly IRedisCash _redisCache;
        private readonly ILogger<StaffInfoAboutRanOutItems> _logger;

        public StaffInfoAboutRanOutItemsRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<StaffInfoAboutRanOutItems> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
            _context = context;
            _redisCache = redisCache;
            _logger = logger;
        }

        #region Lookup & Filtering
        public async Task<IEnumerable<StaffInfoAboutRanOutItems>> GetRequestsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default)
        {
            return await _context.StaffInfoAboutRanOutItems.AsNoTracking()
                .Where(r => r.StaffId == staffId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<StaffInfoAboutRanOutItems>> GetRequestsByPriorityAsync(PriorityEnum priority, CancellationToken cancellationToken = default)
        {
            return await _context.StaffInfoAboutRanOutItems.AsNoTracking()
                .Where(r => r.Priority == priority)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<StaffInfoAboutRanOutItems>> GetUnresolvedRequestsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.StaffInfoAboutRanOutItems.AsNoTracking()
                .Where(r => !r.Resolved)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<StaffInfoAboutRanOutItems>> GetUrgentRequestsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.StaffInfoAboutRanOutItems.AsNoTracking()
                .Where(r => r.Priority == PriorityEnum.High)
                .ToListAsync(cancellationToken);
        }
        #endregion

        #region  Request Management
        public async Task<bool> MarkRequestResolvedAsync(long requestId, string? notes, CancellationToken cancellationToken = default)
        {
            var request = await _context.StaffInfoAboutRanOutItems.FindAsync(new object[] { requestId }, cancellationToken);
            if (request == null) return false;

            request.Resolved = true;
            request.HandledDate = DateTime.UtcNow;
            request.Notes = notes ?? request.Notes;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(requestId);
            return true;
        }
        #endregion

        #region Analytics & Reporting
        public async Task<int> CountUnresolvedRequestsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.StaffInfoAboutRanOutItems
                .CountAsync(r => !r.Resolved, cancellationToken);
        }

        public async Task<int> CountHighPriorityRequestsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.StaffInfoAboutRanOutItems
                .CountAsync(r => r.Priority == PriorityEnum.High, cancellationToken);
        }
        #endregion

        #region Caching Helpers
        private async Task<bool> InvalidateCache(long requestId)
        {
            var cacheKey = $"StaffInfoAboutRanOutItems_GetById_{requestId}";
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
