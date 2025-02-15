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

public static class QrCodeDI
{
    public static void InjectQrCode(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<QRCode>, QRCodeRepository>();
        services.AddScoped<IQRCodeRepository, QRCodeRepository>();
        services.AddScoped<IQrCodeService, QrCodeService>();
        services.AddScoped<IService<QRCodeDto, QRCodeResponseDto, long, QRCode>, QrCodeService>();
        services.AddScoped<IAdditionalFeatures<QRCodeDto, QRCodeResponseDto, long, QRCode>, QrCodeService>();
        services.AddScoped<IAdditionalFeaturesRepository<QRCode>, AdditionalFeaturesRepository<QRCode>>();
        services.AddAutoMapper(typeof(QrCodeMapper));
    }
}
