using GuestSide.Application.DTOs.Request.FeedBacks;
using GuestSide.Application.DTOs.Response.FeedBacks;
using GuestSide.Application.Interface.Feadback;
using GuestSide.Application.Interface;
using GuestSide.Application.Services.Feadback;
using GuestSide.Core.Entities.Feedbacks;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.FeedBack;
using GuestSide.Infrastructure.Repositories.FeedBack;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuestSide.Core.Entities.Hotel;
using GuestSide.Core.Interfaces.Hotel;
using GuestSide.Infrastructure.Repositories.Hotel;
using GuestSide.Application.Interface.Hotel;
using GuestSide.Application.DTOs.Request.Hotel;
using GuestSide.Application.DTOs.Response.Hotel;

namespace GuestSide.Application.Services.Hotel
{
    public static  class HotelDi
    {
        public static void InjectHotel(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<GuestSide.Core.Entities.Hotel.Hotel>, HotelRepository>();

            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IService<HotelRequestDto, HotelResponse, long, GuestSide.Core.Entities.Hotel.Hotel>, HotelService>();
        }
    }
}
