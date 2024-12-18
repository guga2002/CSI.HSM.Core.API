using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GuestSide.Infrastructure.Repositories.AbstractRepository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly GuestSideDb Context;
        protected readonly DbSet<T> DbSet;
        private readonly IRedisCash _redisCache;

        protected GenericRepository(GuestSideDb context, IRedisCash redisCache)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            DbSet = context.Set<T>();
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var cacheKey = $"{typeof(T).Name}_GetAll";
            var cachedData = await _redisCache.GetCache<IEnumerable<T>>(cacheKey);

            if (cachedData != null)
            {
                return cachedData;
            }
            var data = await DbSet.ToListAsync(cancellationToken);
            await _redisCache.SetCache(cacheKey, data, TimeSpan.FromMinutes(10));
            return data;
        }

        public virtual async Task<T> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            var cacheKey = $"{typeof(T).Name}_GetById_{id}";
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

            await _redisCache.SetCache(cacheKey, entity, TimeSpan.FromMinutes(10));
            return entity;
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var cacheKey = $"{typeof(T).Name}_Find_{Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(predicate.ToString()))}";
            var cachedData = await _redisCache.GetCache<IEnumerable<T>>(cacheKey);

            if (cachedData != null)
            {
                return cachedData;
            }

            var data = await DbSet.Where(predicate).ToListAsync(cancellationToken);

            await _redisCache.SetCache(cacheKey, data, TimeSpan.FromMinutes(10));
            return data;
        }

        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await DbSet.AddAsync(entity, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);

            await InvalidateCache($"{typeof(T).Name}_GetAll");
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync(cancellationToken);

            await InvalidateCache($"{typeof(T).Name}_GetAll");
            await InvalidateCache($"{typeof(T).Name}_GetById_{entity.GetHashCode()}");
            return entity;
        }

        public virtual async Task<T> DeleteAsync(object id, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var entityToDelete = await DbSet.FindAsync(new object[] { id }, cancellationToken);

            if (entityToDelete == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }

            DbSet.Remove(entityToDelete);
            await Context.SaveChangesAsync(cancellationToken);

            await InvalidateCache($"{typeof(T).Name}_GetAll");
            await InvalidateCache($"{typeof(T).Name}_GetById_{id}");
            return entityToDelete;
        }

        public async Task<T> Delete(T entityToDelete, CancellationToken cancellationToken = default)
        {
            if (entityToDelete == null)
            {
                throw new KeyNotFoundException($"Entity is null.");
            }

            DbSet.Remove(entityToDelete);
            await Context.SaveChangesAsync(cancellationToken);
            await InvalidateCache($"{typeof(T).Name}_GetAll");
            return entityToDelete;
        }

        private async Task<bool> InvalidateCache(string cacheKey)
        {
            await _redisCache.RemoveCache(cacheKey);
            return true;
        }

       
    }
}
