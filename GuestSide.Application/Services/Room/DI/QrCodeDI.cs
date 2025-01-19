using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.DependencyInjection;
using GuestSide.Infrastructure.Repositories.Room;
using GuestSide.Application.Services.Room.Service;
using GuestSide.Core.Entities.Room;
using GuestSide.Core.Interfaces.Room;
using GuestSide.Application.Interface.Room;
using GuestSide.Application.DTOs.Request.Room;
using GuestSide.Application.DTOs.Response.Room;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Room.Mapper;
using Core.Core.Interfaces.AbstractInterface;
using Core.Infrastructure.Repositories.AbstractRepository;

namespace GuestSide.Application.Services.Room.DI;

public static class QrCodeDI
{
    public static void InjectQrCode(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<QRCode>, QRCodeRepository>();
        services.AddScoped<IQRCodeRepository, QRCodeRepository>();
        services.AddScoped<IQrCodeService, QrCodeService>();
        services.AddScoped<IService<QRCodeDto,QRCodeResponseDto, long, QRCode>, QrCodeService>();
        services.AddScoped<IAdditionalFeatures<QRCodeDto, QRCodeResponseDto, long, QRCode>, QrCodeService>();
        services.AddScoped<IAdditionalFeaturesRepository<QRCode>, AdditionalFeaturesRepository<QRCode>>();
        services.AddAutoMapper(typeof(QrCodeMapper));
    }
}
