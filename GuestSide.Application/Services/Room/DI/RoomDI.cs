using Microsoft.Extensions.DependencyInjection;
using Core.Application.Services.Room.Service;
using Core.Application.Interface.Room;
using Core.Application.Services.Room.Mapper;
using Core.Application.DTOs.Request.Room;
using Core.Application.Interface.GenericContracts;
using Core.Application.DTOs.Response.Room;
using Common.Data.Interfaces.Room;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Repositories.Room;
using Common.Data.Repositories.AbstractRepository;

namespace Core.Application.Services.Room.DI;

public static class RoomDI
{
    public static void InjectRoom(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Common.Data.Entities.Room.Room>, RoomRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IService<RoomsDto, RoomsResponseDto, long, Common.Data.Entities.Room.Room>, RoomService>();
        services.AddScoped<IAdditionalFeatures<RoomsDto, RoomsResponseDto, long, Common.Data.Entities.Room.Room>, RoomService>();
        services.AddScoped<IAdditionalFeaturesRepository<Common.Data.Entities.Room.Room>, AdditionalFeaturesRepository<Common.Data.Entities.Room.Room>>();
        services.AddAutoMapper(typeof(RoomMapper));
    }
}
