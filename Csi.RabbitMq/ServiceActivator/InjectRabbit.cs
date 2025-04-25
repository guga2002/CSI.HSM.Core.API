using Csi.RabbitMq.Interface;
using Csi.RabbitMq.Models;
using Csi.RabbitMq.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Csi.RabbitMq.ServiceActivator
{
    public static class RabbitMqServiceCollectionExtensions
    {
        public static IServiceCollection AddRabbitMqService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMqOptions>(configuration.GetSection("RabbitMq"));
            services.AddSingleton<IRabbitMqService, RabbitMqService>();

            return services;
        }
    }
}
