using Core.Application.DTOs.Request.Language;
using Core.Application.DTOs.Response.Language;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Language;
using Core.Application.Services.Language.Mapper;
using Core.Application.Services.Language.Service;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Language;
using Domain.Core.Entities.Language;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Language;
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
