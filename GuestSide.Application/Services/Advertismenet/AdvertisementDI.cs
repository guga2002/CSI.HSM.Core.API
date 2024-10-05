using GuestSide.Application.DTOs.Advertisment;
using GuestSide.Application.DTOs.FeedBacks;
using GuestSide.Application.Interface;
using GuestSide.Application.Interface.Advertisment;
using GuestSide.Core.Entities.Advertisements;
using GuestSide.Core.Entities.Feedbacks;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Advertisement;
using GuestSide.Infrastructure.Repositories.Advertisement;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Advertismenet
{
    public static class AdvertisementDI
    {
        public static void InjectAdvertisment(this IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<IGenericRepository<Advertisements>,AdvertisementRepository>();
            serviceProvider.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
            serviceProvider.AddScoped<IAdvertismentService, AdvertisementService>();
            serviceProvider.AddScoped<ILogger<GenericService<AdvertismentDto, long, Advertisements>>>();
        }
    }
}
