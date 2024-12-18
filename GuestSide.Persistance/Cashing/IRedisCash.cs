namespace Core.Persistance.Cashing
{
    public interface IRedisCash
    {
        Task<bool> SetCache<T>(string key, T value, TimeSpan? expiry = null);
        Task<T> GetCache<T>(string key);
        Task RemoveCache(string key);
    }
}
