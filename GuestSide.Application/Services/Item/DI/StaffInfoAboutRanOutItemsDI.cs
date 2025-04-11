using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Item;
using Core.Application.Services.Item.Mapper;
using Core.Application.Services.Item.Services;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Item;
using Domain.Core.Entities.Item;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Item;
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
