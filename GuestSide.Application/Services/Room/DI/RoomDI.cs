using Microsoft.Extensions.DependencyInjection;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Room.Mapper;
using Core.Core.Interfaces.AbstractInterface;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Core.Interfaces.Room;
using Core.Core.Entities.Room;
using Core.Application.Services.Room.Service;
using Core.Application.Interface.Room;
using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Room;
using Core.Infrastructure.Repositories.Room;

namespace Core.Application.Services.Room.DI;

public static class RoomDI
{
    public static void InjectRoom(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Rooms>, RoomRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IService<RoomsDto, RoomsResponseDto, long, Rooms>, RoomService>();
        services.AddScoped<IAdditionalFeatures<RoomsDto, RoomsResponseDto, long, Rooms>, RoomService>();
        services.AddScoped<IAdditionalFeaturesRepository<Rooms>, AdditionalFeaturesRepository<Rooms>>();
        services.AddAutoMapper(typeof(RoomMapper));
    }
}
