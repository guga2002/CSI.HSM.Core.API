using Core.Core.Interfaces.LogInterfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistance.LoggingConfigs
{
    public static class InjectLog
    {
        public static void InjectSeriLog(this IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                builder.AddProvider(new LoggerProvider(services.BuildServiceProvider().GetRequiredService<ILogRepository>()));
            });
        }
    }
}
