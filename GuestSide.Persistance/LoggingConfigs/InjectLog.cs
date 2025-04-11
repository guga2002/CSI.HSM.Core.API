using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Domain.Core.Interfaces.LogInterfaces;

namespace Core.Persistance.LoggingConfigs
{
    public static class InjectLog
    {
        public static void InjectSeriLog(this IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                builder.AddProvider(new LoggerProvider(services.BuildServiceProvider().GetRequiredService<ILogsRepository>()));
            });
        }
    }
}
