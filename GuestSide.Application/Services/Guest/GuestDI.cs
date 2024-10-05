using GuestSide.Application.DTOs.NewFolder;
using GuestSide.Application.Interface;
using GuestSide.Application.Interface.Guest;
using GuestSide.Core.Entities.Guest;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Guest;
using GuestSide.Infrastructure.Repositories.Guest;
using Microsoft.Extensions.DependencyInjection;

namespace GuestSide.Application.Services.Guest
{
    public static class GuestDI
    {
        public static void InjectGuest(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<Guests>,GuestRepository>();
            services.AddScoped<IGuestRepository,GuestRepository>();
            services.AddScoped<IGuestService,GuestService>();
            services.AddScoped<IService<GuestDto,long,Guests>,GuestService>();
            //services.AddScoped<ILogger<GenericService<GuestDto, long, Guests>>>();
        }
    }
}
