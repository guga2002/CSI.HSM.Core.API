using Core.Application.DTOs.Request.Language;
using Core.Application.DTOs.Response.Language;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Language;
using Core.Application.Services.Guest.Mapper;
using Core.Application.Services.Language.Mapper;
using Core.Application.Services.Language.Service;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Language;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Language;
using GuestSide.Application.DTOs.Request.Guest;
using GuestSide.Application.DTOs.Response.Guest;
using GuestSide.Application.Interface.Guest;
using GuestSide.Application.Services.Guest;
using GuestSide.Core.Entities.Guest;
using GuestSide.Core.Entities.Language;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Guest;
using GuestSide.Infrastructure.Repositories.Guest;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Language.Di;

public static class LanguagePackDi
{

    public static void AddLanguagePack(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<LanguagePack>, LanguagePackRepository>();
        services.AddScoped<ILanguagePackRepository, LanguagePackRepository>();
        services.AddScoped<ILanguageService, LanguageService>();
        services.AddScoped<IService<LanguagePackDto, LanguagePackResponseDto, long, LanguagePack>, LanguageService>();
        services.AddScoped<IAdditionalFeatures<LanguagePackDto, LanguagePackResponseDto, long, LanguagePack>, LanguageService>();
        services.AddScoped<IAdditionalFeaturesRepository<LanguagePack>, AdditionalFeaturesRepository<LanguagePack>>();
        services.AddAutoMapper(typeof(LanguagePackMapper));
    }
}
