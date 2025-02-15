using Core.Application.DTOs.Request.Guest;
using Core.Application.DTOs.Response.Guest;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Guest;
using Core.Application.Services.Guest.Mapper;
using Core.Application.Services.Guest.Service;
using Core.Core.Entities.Guest;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Guest;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Guest;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Guest.Injection;

public static class GuestActiveLanguageDi
{
    public static void AddGuestActiveLanguage(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<GuestActiveLanguage>, GuestActiveLanguageRepository>();
        services.AddScoped<IGuestActiveLanguageRepository, GuestActiveLanguageRepository>();
        services.AddScoped<IGuestActiveLanguageService, GuestActiveLanguageService>();
        services.AddScoped<IService<GuestActiveLanguageDto, GuestActiveLanguageResponseDto, long, GuestActiveLanguage>, GuestActiveLanguageService>();
        services.AddScoped<IAdditionalFeatures<GuestActiveLanguageDto, GuestActiveLanguageResponseDto, long, GuestActiveLanguage>, GuestActiveLanguageService>();
        services.AddScoped<IAdditionalFeaturesRepository<GuestActiveLanguage>, AdditionalFeaturesRepository<GuestActiveLanguage>>();
        services.AddAutoMapper(typeof(GuestActiveLanguageMapper));
    }
}
