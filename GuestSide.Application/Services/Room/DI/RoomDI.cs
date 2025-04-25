using Microsoft.Extensions.DependencyInjection;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Room;
using Domain.Core.Entities.Room;
using Core.Application.Services.Room.Service;
using Core.Application.Interface.Room;
using Core.Application.Services.Room.Mapper;
using Core.Application.DTOs.Request.Room;
using Core.Application.Interface.GenericContracts;
using Core.Application.DTOs.Response.Room;
using Core.Infrastructure.Repositories.Room;
using Core.Infrastructure.Repositories.AbstractRepository;

namespace Core.Application.Services.Room.DI;

public static class RoomDI
{
    public static void InjectRoom(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Domain.Core.Entities.Room.Room>, RoomRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IService<RoomsDto, RoomsResponseDto, long, Domain.Core.Entities.Room.Room>, RoomService>();
        services.AddScoped<IAdditionalFeatures<RoomsDto, RoomsResponseDto, long, Domain.Core.Entities.Room.Room>, RoomService>();
        services.AddScoped<IAdditionalFeaturesRepository<Domain.Core.Entities.Room.Room>, AdditionalFeaturesRepository<Domain.Core.Entities.Room.Room>>();
        services.AddAutoMapper(typeof(RoomMapper));
    }
}
