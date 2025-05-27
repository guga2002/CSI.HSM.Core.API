using Microsoft.Extensions.DependencyInjection;
using Core.Application.Services.Room.Service;
using Core.Application.Interface.Room;
using Core.Application.DTOs.Request.Room;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Room.Mapper;
using Core.Application.DTOs.Response.Room;
using Common.Data.Entities.Room;
using Common.Data.Interfaces.Room;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Repositories.Room;
using Common.Data.Repositories.AbstractRepository;

namespace Core.Application.Services.Room.DI;

public static class RoomCategoryDI
{
    public static void InjectRoomCategory(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<RoomCategory>, RoomCategoryRepository>();
        services.AddScoped<IRoomCategoryRepository, RoomCategoryRepository>();
        services.AddScoped<IRoomCategoryService, RoomCategoryService>();
        services.AddScoped<IService<RoomCategoryDto, RoomCategoryResponseDto, long, RoomCategory>, RoomCategoryService>();
        services.AddScoped<IAdditionalFeatures<RoomCategoryDto, RoomCategoryResponseDto, long, RoomCategory>, RoomCategoryService>();
        services.AddAutoMapper(typeof(RoomCategoryMapper));
        services.AddScoped<IAdditionalFeaturesRepository<RoomCategory>, AdditionalFeaturesRepository<RoomCategory>>();
    }
}
