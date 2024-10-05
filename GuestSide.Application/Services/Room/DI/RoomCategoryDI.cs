using GuestSide.Application.DTOs.Room;
using GuestSide.Application.Interface.Room;
using GuestSide.Application.Interface;
using GuestSide.Application.Services.Room.Service;
using GuestSide.Core.Entities.Room;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Room;
using GuestSide.Infrastructure.Repositories.Room;
using Microsoft.Extensions.DependencyInjection;

namespace GuestSide.Application.Services.Room.DI
{
    public static class RoomCategoryDI
    {
        public static void InjectRoomCategory(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<RoomCategory>, RoomCategoryRepository>();
            services.AddScoped<IRoomCategoryRepository, RoomCategoryRepository>();
            services.AddScoped<IRoomCategoryService, RoomCategoryService>();
            services.AddScoped<IService<RoomCategoryDto, long, RoomCategory>, RoomCategoryService>();
        }
    }
}
