using Newtonsoft.Json;
using StackExchange.Redis;

namespace Core.Persistance.Cashing
{
    public class RedisCasheService:IRedisCash
    {

        public  readonly ConnectionMultiplexer redisConnection;
        private  readonly StackExchange.Redis.IDatabase database;

        public RedisCasheService(string redisConnectionString)
        {
            redisConnection = ConnectionMultiplexer.Connect(redisConnectionString);
            database = redisConnection.GetDatabase();
        }

        public async Task<bool> SetCache<T>(string key, T value, TimeSpan? expiry = null)
        {
            var serializedValue = JsonConvert.SerializeObject(value);
            return await database.StringSetAsync(key, serializedValue, expiry);
        }

        public async Task<T> GetCache<T>(string key)
        {
            var cachedData = await database.StringGetAsync(key);

            if (!cachedData.IsNullOrEmpty)
            {
                return JsonConvert.DeserializeObject<T>(cachedData);
            }
            return default;
        }

        public async Task RemoveCache(string key)
        {
            await database.KeyDeleteAsync(key);
        }
    }
}
