using GuestSide.Application.Interface;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.DependencyInjection;
using GuestSide.Infrastructure.Repositories.Room;
using GuestSide.Application.Services.Room.Service;
using GuestSide.Core.Entities.Room;
using GuestSide.Core.Interfaces.Room;
using GuestSide.Application.Interface.Room;
using GuestSide.Application.DTOs.Request.Room;
using GuestSide.Application.DTOs.Response.Room;

namespace GuestSide.Application.Services.Room.DI
{
    public static class QrCodeDI
    {
        public static void InjectQrCode(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<QRCode>, QRCodeRepository>();
            services.AddScoped<IQRCodeRepository, QRCodeRepository>();
            services.AddScoped<IQrCodeService, QrCodeService>();
            services.AddScoped<IService<QRCodeDto,QRCodeResponseDto, long, QRCode>, QrCodeService>();
        }
    }
}
