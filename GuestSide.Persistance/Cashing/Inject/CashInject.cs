using Microsoft.Extensions.DependencyInjection;

namespace Core.Persistance.Cashing.Inject
{
    public static class CashInject
    {
        public static void AddRedisCash(this IServiceCollection services, string redisConnectionString)
        {
            services.AddSingleton<IRedisCash, RedisCasheService>(provider =>
                new RedisCasheService(redisConnectionString));
        }
    }
}
