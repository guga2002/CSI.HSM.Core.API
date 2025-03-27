using Core.Core.Data;
using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Hotel.GeoLocation;
using Core.Core.Interfaces.AbstractInterface;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Core.Infrastructure.Repositories.AbstractRepository;
/// <summary>
/// Generic Repository for CRUD operations
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
    #region Constructor
    protected readonly GuestSideDb Context;
    protected readonly DbSet<T> DbSet;
    private readonly IRedisCash _redisCache;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<T> _logger;
    private readonly IExistable<T> _checkExistance;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="context"></param>
    /// <param name="redisCache"></param>
    /// <param name="httpContextAccessor"></param>
    /// <param name="logger"></param>
    /// <exception cref="ArgumentNullException"></exception>
    protected GenericRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<T> logger, IExistable<T> checkExistance)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
        DbSet = context.Set<T>();
        _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _logger = logger;
        _checkExistance = checkExistance;
    }
    #endregion

    #region Get
    /// <summary>
    /// Get all entities
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var regionName = GetHotelRegion();
        var cacheKey = $"{typeof(T).Name}_GetAll_{regionName}";
        var cachedData = await _redisCache.GetCache<IEnumerable<T>>(cacheKey);

        if (cachedData is not null)
        {
            return cachedData;
        }

        var data = await DbSet.Where(e => EF.Property<bool>(e, "IsActive")).ToListAsync(cancellationToken);

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

    /// <summary>
    /// Get entity by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public virtual async Task<T> GetByIdAsync(object id, CancellationToken cancellationToken = default)
    {
        var regionName = GetHotelRegion();
        var cacheKey = $"{typeof(T).Name}_GetById_{id}_{regionName}";
        var cachedData = await _redisCache.GetCache<T>(cacheKey);

        if (cachedData is not null)
        {
            return cachedData;
        }

        var entity = await DbSet.Where(e => EF.Property<bool>(e, "IsActive"))
                            .FirstOrDefaultAsync(e => EF.Property<object>(e, "Id").Equals(id), cancellationToken);

        if (entity is null)
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
    #endregion

    #region Find
    /// <summary>
    /// Find entity by predicate
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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
    #endregion

    #region Add
    /// <summary>
    /// Add entity
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        if (entity is IExistable<T> existable)
        {
            var predicate = existable.GetExistencePredicate();
            bool exists = await ExistsAsync(predicate);
            if (exists)
            {
                throw new ArgumentException("Value is already in Db try different value");
            }
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
    #endregion

    #region Update
    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public virtual async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        var regionName = GetHotelRegion();
        DbSet.Update(entity);
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
    #endregion

    #region Delete
    /// <summary>
    /// Delete entity by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="KeyNotFoundException"></exception>
    public virtual async Task<T> DeleteAsync(object id, CancellationToken cancellationToken = default)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id));
        }


        var regionName = GetHotelRegion();

        var idValue = id.GetType().GetProperty("Id")?.GetValue(id) as long?;
        if (idValue is null)
        {
            throw new InvalidOperationException("Id property is missing or not a valid long.");
        }

        var entityToDelete = await DbSet.FindAsync(idValue, cancellationToken);

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

    /// <summary>
    /// Delete entity by entity
    /// </summary>
    /// <param name="entityToDelete"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task<T> Delete(T entityToDelete, CancellationToken cancellationToken = default)
    {
        if (entityToDelete is null)
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

    #endregion

    #region Helper Methods
    /// <summary>
    /// Invalidate cache for a given key
    /// </summary>
    /// <param name="cacheKey"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Get hotel region from request header
    /// </summary>
    /// <returns></returns>
    private string GetHotelRegion()
    {
        _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("X-Hotel-Id", out var regionName);
        return regionName.ToString();
    }

    private Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return Context.Set<T>().AnyAsync(predicate, cancellationToken);
    }
    #endregion
}
