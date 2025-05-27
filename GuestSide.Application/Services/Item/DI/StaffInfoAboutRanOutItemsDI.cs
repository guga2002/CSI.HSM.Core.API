using Common.Data.Entities.Item;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Interfaces.Item;
using Common.Data.Repositories.AbstractRepository;
using Common.Data.Repositories.Item;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Item;
using Core.Application.Services.Item.Mapper;
using Core.Application.Services.Item.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Item.DI
{
    public static class StaffInfoAboutRanOutItemsDI
    {
        public static void ActiveStaffInfoAboutRanOutItems(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<StaffInfoAboutRanOutItems>, StaffInfoAboutRanOutItemsRepository>();
            services.AddScoped<IStaffInfoAboutRanOutItemsRepository, StaffInfoAboutRanOutItemsRepository>();
            services.AddScoped<IStaffInfoAboutRanOutItemsService, StaffInfoAboutRanOutItemsService>();
            services.AddScoped<IService<StaffInfoAboutRanOutItemsDto, StaffInfoAboutRanOutItemsResponseDto, long, StaffInfoAboutRanOutItems>, StaffInfoAboutRanOutItemsService>();
            services.AddScoped<IAdditionalFeatures<StaffInfoAboutRanOutItemsDto, StaffInfoAboutRanOutItemsResponseDto, long, StaffInfoAboutRanOutItems>, StaffInfoAboutRanOutItemsService>();
            services.AddAutoMapper(typeof(StaffInfoAboutRanOutItemsMapper));
            services.AddScoped<IAdditionalFeaturesRepository<StaffInfoAboutRanOutItems>, AdditionalFeaturesRepository<StaffInfoAboutRanOutItems>>();
        }
    }
}
