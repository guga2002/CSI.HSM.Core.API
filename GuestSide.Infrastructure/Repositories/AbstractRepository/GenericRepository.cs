using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace GuestSide.Infrastructure.Repositories.AbstractRepository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly GuestSideDb Context;
        protected readonly DbSet<T> DbSet;
        private readonly IRedisCash _redisCache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<T> _logger;

        protected GenericRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<T> logger)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            DbSet = context.Set<T>();
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _logger = logger;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var regionName = GetHotelRegion();
            var cacheKey = $"{typeof(T).Name}_GetAll_{regionName}";
            var cachedData = await _redisCache.GetCache<IEnumerable<T>>(cacheKey);

            if (cachedData != null)
            {
                return cachedData;
            }

            var data = await DbSet.ToListAsync(cancellationToken);

            try
            {
                await _redisCache.SetCache(cacheKey, data, TimeSpan.FromMinutes(10));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error caching data for key {CacheKey}", cacheKey);
            }

            return data.AsEnumerable();
        }

        public virtual async Task<T> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            var regionName = GetHotelRegion();
            var cacheKey = $"{typeof(T).Name}_GetById_{id}_{regionName}";
            var cachedData = await _redisCache.GetCache<T>(cacheKey);

            if (cachedData != null)
            {
                return cachedData;
            }

            var entity = await DbSet.FindAsync(new object[] { id }, cancellationToken);

            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }

            try
            {
                await _redisCache.SetCache(cacheKey, entity, TimeSpan.FromMinutes(10));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error caching data for key {CacheKey}", cacheKey);
            }

            return entity;
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var regionName = GetHotelRegion();
            var cacheKey = $"{typeof(T).Name}_Find_{Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(predicate.ToString()))}_{regionName}";
            var cachedData = await _redisCache.GetCache<IEnumerable<T>>(cacheKey);

            if (cachedData != null)
            {
                return cachedData;
            }

            var data = await DbSet.Where(predicate).ToListAsync(cancellationToken);

            try
            {
                await _redisCache.SetCache(cacheKey, data, TimeSpan.FromMinutes(10));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error caching data for key {CacheKey}", cacheKey);
            }

            return data;
        }

        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var regionName = GetHotelRegion();

            await DbSet.AddAsync(entity, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);

            try
            {
                await InvalidateCache($"{typeof(T).Name}_GetAll_{regionName}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error invalidating cache for key {CacheKey}", $"{typeof(T).Name}_GetAll_{regionName}");
            }

            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var regionName = GetHotelRegion();
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync(cancellationToken);

            try
            {
                await InvalidateCache($"{typeof(T).Name}_GetAll_{regionName}");
                await InvalidateCache($"{typeof(T).Name}_GetById_{entity.GetHashCode()}__{regionName}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error invalidating cache for key(s) {CacheKey}", $"{typeof(T).Name}_GetAll_{regionName}");
            }
            return entity;
        }

        public virtual async Task<T> DeleteAsync(object id, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var regionName = GetHotelRegion();
            var entityToDelete = await DbSet.FindAsync(new object[] { id }, cancellationToken);

            if (entityToDelete == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }

            DbSet.Remove(entityToDelete);
            await Context.SaveChangesAsync(cancellationToken);
            try
            {
                await InvalidateCache($"{typeof(T).Name}_GetAll_{regionName}");
                await InvalidateCache($"{typeof(T).Name}_GetById_{id}_{regionName}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error invalidating cache for key(s) {CacheKey}", $"{typeof(T).Name}_GetAll_{regionName}");
            }

            return entityToDelete;
        }

        public async Task<T> Delete(T entityToDelete, CancellationToken cancellationToken = default)
        {
            if (entityToDelete == null)
            {
                throw new KeyNotFoundException("Entity is null.");
            }

            var regionName = GetHotelRegion();
            DbSet.Remove(entityToDelete);
            await Context.SaveChangesAsync(cancellationToken);
            try
            {
                await InvalidateCache($"{typeof(T).Name}_GetAll_{regionName}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error invalidating cache for key(s) {CacheKey}", $"{typeof(T).Name}_GetAll_{regionName}");
            }

            return entityToDelete;
        }

        private async Task<bool> InvalidateCache(string cacheKey)
        {
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

        private string GetHotelRegion()
        {
            _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("X-Hotel-Id", out var regionName);
            return regionName.ToString();
        }
    }
}
