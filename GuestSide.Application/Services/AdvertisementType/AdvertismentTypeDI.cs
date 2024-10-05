using GuestSide.Application.Interface.AdvertiementType;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Advertisement;
using GuestSide.Infrastructure.Repositories.Advertisement;
using Microsoft.Extensions.DependencyInjection;

namespace GuestSide.Application.Services.AdvertisementType
{
    public static class AdvertismentTypeDI
    {
        public static void  AddAdvertisementType(this IServiceCollection collect)
        {
            collect.AddScoped<IGenericRepository<GuestSide.Core.Entities.Advertisments.AdvertisementType>,AdvertisementTypeRepository>();
            collect.AddScoped<IAdvertisementTypeRepository,AdvertisementTypeRepository>();
            collect.AddScoped<IAdvertisementTypeService,AdvertisementTypeService>();
        }
    }
}
