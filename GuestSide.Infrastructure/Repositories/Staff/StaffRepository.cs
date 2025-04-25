using Domain.Core.Data;
using Domain.Core.Entities.Item;
using Domain.Core.Entities.Staff;
using Domain.Core.Interfaces.Staff;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;

namespace Core.Infrastructure.Repositories.Staff
{
    public class StaffRepository : GenericRepository<Staffs>, IStaffRepository
    {
        private readonly GuestSideDb _context;
        private readonly IRedisCash _redisCache;
        private readonly ILogger<Staffs> _logger;

        public StaffRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Staffs> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
            _context = context;
            _redisCache = redisCache;
            _logger = logger;
        }

        #region Staff Lookup & Filtering
        public async Task<Staffs?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _context.Staffs.AsNoTracking()
                .FirstOrDefaultAsync(s => s.Email == email, cancellationToken);
        }

        public async Task<IEnumerable<Staffs>> GetByPositionAsync(string position, CancellationToken cancellationToken = default)
        {
            return await _context.Staffs.AsNoTracking()
                .Where(s => s.Position == position)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Staffs>> GetBySupervisorIdAsync(long supervisorId, CancellationToken cancellationToken = default)
        {
            return await _context.Staffs.AsNoTracking()
                .Where(s => s.SupervisorId == supervisorId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Staffs>> GetStaffHiredBetweenDatesAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            return await _context.Staffs.AsNoTracking()
                .Where(s => s.HireDate >= startDate && s.HireDate <= endDate)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Staffs>> GetActiveStaffAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Staffs.AsNoTracking()
                .Where(s => s.IsActive)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Staffs>> GetInactiveStaffAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Staffs.AsNoTracking()
                .Where(s => !s.IsActive)
                .ToListAsync(cancellationToken);
        }
        #endregion

        #region Staff Management
        public async Task<bool> UpdatePositionAsync(long staffId, string newPosition, CancellationToken cancellationToken = default)
        {
            var staff = await _context.Staffs.FindAsync(new object[] { staffId }, cancellationToken);
            if (staff == null) return false;

            staff.Position = newPosition;
            staff.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(staffId);
            return true;
        }

        public async Task<bool> UpdateSalaryAsync(long staffId, decimal newSalary, CancellationToken cancellationToken = default)
        {
            var staff = await _context.Staffs.FindAsync(new object[] { staffId }, cancellationToken);
            if (staff == null) return false;

            staff.Salary = newSalary;
            staff.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(staffId);
            return true;
        }

        public async Task<bool> AssignSupervisorAsync(long staffId, long newSupervisorId, CancellationToken cancellationToken = default)
        {
            var staff = await _context.Staffs.FindAsync(new object[] { staffId }, cancellationToken);
            if (staff == null) return false;

            staff.SupervisorId = newSupervisorId;
            staff.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(staffId);
            return true;
        }
        #endregion

        #region Workload & Assignments
        public async Task<IEnumerable<TaskToStaff>> GetTasksByStaffIdAsync(long staffId, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TaskToStaff>().AsNoTracking()
                .Where(t => t.AssignedByStaff.Id == staffId)
                .Include(t => t.AssignedByStaff)
                .Include(t => t.Task)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<StaffReserveItem>> GetReservedItemsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException("THis feature is removed");
        }
        #endregion

        #region HR & Sentiment Monitoring
        public async Task<IEnumerable<StaffIncident>> GetIncidentsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default)
        {
            return await _context.Set<StaffIncident>().AsNoTracking()
                .Where(i => i.ReportedByStaffId == staffId)
                .ToListAsync(cancellationToken);
        }

        public async Task<double?> GetStaffSentimentScoreAsync(long staffId, CancellationToken cancellationToken = default)
        {
            return await _context.Set<StaffSentiment>().AsNoTracking()
                .Where(s => s.StaffId == staffId)
                .Select(s => s.SentimentScore)
                .AverageAsync(cancellationToken);
        }
        #endregion

        #region StaffStatus
        public async Task<bool> CheckIsOnDute(long staffId, bool Status, CancellationToken cancellationToken = default)
        {
            var staff = await _context.Staffs.FirstOrDefaultAsync(id => id.Id == staffId);
            if (staff == null) return false;
            staff.IsOnDuty = Status;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<(long, DateTime)> GetLastLoginDate(long staffId, CancellationToken cancellationToken = default)
        {
            var staff = await _context.Staffs.FirstOrDefaultAsync(id => id.Id == staffId);
            if (staff is null) return (0, DateTime.MinValue);

            return (staff.Id, staff.LastCheckedLoginTime ?? DateTime.MinValue);
        }
        #endregion

        #region Caching Helpers
        private async Task<bool> InvalidateCache(long staffId)
        {
            var cacheKey = $"Staff_GetById_{staffId}";
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
