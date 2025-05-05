using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Promo;
using Domain.Core.Interfaces.Promo;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Core.Infrastructure.Repositories.Promo
{
    public class PromoCodeRepository : GenericRepository<PromoCode>, IPromoCodeRepository
    {
        public PromoCodeRepository(
            CoreSideDb context,
            IRedisCash redisCache,
            IHttpContextAccessor httpContextAccessor,
            ILogger<PromoCode> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        public async Task<PromoCode> ValidatePromoCodeAsync(string code, long? guestId = null, long? cartId = null, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(p =>
                p.Code == code &&
                p.IsActive &&
                DateTime.UtcNow >= p.ValidFrom &&
                DateTime.UtcNow <= p.ValidUntil,
                cancellationToken);
        }

        public async Task<int> GetUsageCountAsync(string code, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(p => p.Code == code)
                .Select(p => p.TimesUsed)
                .FirstOrDefaultAsync(cancellationToken);
        }


        public async Task<IEnumerable<PromoCode>> GetAvailableForGuestAsync(long guestId, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(p => p.IsActive &&
                            DateTime.UtcNow >= p.ValidFrom &&
                            DateTime.UtcNow <= p.ValidUntil &&
                            (!p.ApplicableGuestIds.Any() || p.ApplicableGuestIds.Contains(guestId)))
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<PromoCode>> GetAvailableForItemAsync(long itemId, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(p => p.IsActive &&
                            DateTime.UtcNow >= p.ValidFrom &&
                            DateTime.UtcNow <= p.ValidUntil &&
                            (!p.ApplicableItemIds.Any() || p.ApplicableItemIds.Contains(itemId)))
                .ToListAsync(cancellationToken);
        }

        public async Task<int> DeactivateExpiredPromoCodesAsync(CancellationToken cancellationToken = default)
        {
            var expiredPromos = await DbSet
                .Where(p => p.ValidUntil < DateTime.UtcNow && p.IsActive)
                .ToListAsync(cancellationToken);

            foreach (var promo in expiredPromos)
            {
                promo.IsActive = false;
            }

            await Context.SaveChangesAsync(cancellationToken);
            return expiredPromos.Count;
        }

        public async Task<(IEnumerable<PromoCode>, int)> GetPagedAsync(
            Expression<Func<PromoCode, bool>> predicate,
            int pageNumber,
            int pageSize,
            Expression<Func<PromoCode, object>> orderBy,
            bool isAscending = true,
            CancellationToken cancellationToken = default)
        {
            var query = DbSet.Where(predicate);

            var totalCount = await query.CountAsync(cancellationToken);

            var items = isAscending
                ? await query.OrderBy(orderBy).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken)
                : await query.OrderByDescending(orderBy).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

            return (items, totalCount);
        }

        public async Task<PromoCode> SoftDelete(object id, CancellationToken cancellationToken = default)
        {
            var entity = await DbSet.FindAsync(new object[] { id }, cancellationToken);
            if (entity != null)
            {
                entity.IsActive = false;
                await Context.SaveChangesAsync(cancellationToken);
            }
            return entity;
        }

        public System.Threading.Tasks.Task BulkAddAsync(IEnumerable<PromoCode> entities, CancellationToken cancellationToken = default)
        {
            DbSet.AddRange(entities);
            return Context.SaveChangesAsync(cancellationToken);
        }

        public System.Threading.Tasks.Task BulkDeleteAsync(IEnumerable<PromoCode> entities, CancellationToken cancellationToken = default)
        {
            DbSet.RemoveRange(entities);
            return Context.SaveChangesAsync(cancellationToken);
        }

        public System.Threading.Tasks.Task BulkUpdateAsync(IEnumerable<PromoCode> entities, CancellationToken cancellationToken = default)
        {
            DbSet.UpdateRange(entities);
            return Context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsAsync(Expression<Func<PromoCode, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await DbSet.AnyAsync(predicate, cancellationToken);
        }

        public async Task<IEnumerable<PromoCode>> ExecuteRawSql<TResult>(string query, object[] parameters, CancellationToken cancellationToken = default)
        {
            return await DbSet.FromSqlRaw(query, parameters).ToListAsync(cancellationToken);
        }

        public async System.Threading.Tasks.Task ExecuteInTransaction(Func<System.Threading.Tasks.Task> action)
        {
            using var transaction = await Context.Database.BeginTransactionAsync();
            try
            {
                await action();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
