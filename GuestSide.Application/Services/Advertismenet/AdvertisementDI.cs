using GuestSide.Application.Interface.Advertisment;
using GuestSide.Core.Interfaces.Advertisement;
using GuestSide.Infrastructure.Repositories.Advertisement;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestSide.Application.Services.Advertismenet
{
    public static class AdvertisementDI
    {
        public static void InjectAdvertisment(this IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
            serviceProvider.AddScoped<IAdvertismentService, AdvertisementService>();
        }
    }
}
