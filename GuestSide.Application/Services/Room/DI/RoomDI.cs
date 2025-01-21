using GuestSide.Application.Interface.Room;
using GuestSide.Application.Services.Room.Service;
using GuestSide.Core.Entities.Room;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Room;
using GuestSide.Infrastructure.Repositories.Room;
using Microsoft.Extensions.DependencyInjection;
using GuestSide.Application.DTOs.Request.Room;
using GuestSide.Application.DTOs.Response.Room;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Room.Mapper;
using Core.Core.Interfaces.AbstractInterface;
using Core.Infrastructure.Repositories.AbstractRepository;

namespace GuestSide.Application.Services.Room.DI;

public static class RoomDI
{
    public static void InjectRoom(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Rooms>, RoomRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IService<RoomsDto,RoomsResponseDto, long, Rooms>, RoomService>();
        services.AddScoped<IAdditionalFeatures<RoomsDto, RoomsResponseDto, long, Rooms>, RoomService>();
        services.AddScoped<IAdditionalFeaturesRepository<Rooms>, AdditionalFeaturesRepository<Rooms>>();
        services.AddAutoMapper(typeof(RoomMapper));
    }
}
