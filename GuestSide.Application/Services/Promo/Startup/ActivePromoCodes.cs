using Common.Data.Entities.Promo;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Interfaces.Promo;
using Common.Data.Repositories.AbstractRepository;
using Common.Data.Repositories.Promo;
using Core.Application.DTOs.Request.Promo;
using Core.Application.DTOs.Response.Promo;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Promo;
using Core.Application.Services.Promo.Mapper;
using Core.Application.Services.Promo.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Promo.Startup;

public static class ActivePromoCodes
{
    public static void ActivatePromoCode(this IServiceCollection service)
    {
        service.AddScoped<IGenericRepository<PromoCode>, PromoCodeRepository>();
        service.AddScoped<IPromoCodeRepository, PromoCodeRepository>();
        service.AddScoped<IPromoCodeService, PromoCodeService>();
        service.AddScoped<IService<PromoCodeDto, PromoCodeResponse, long, PromoCode>, PromoCodeService>();
        service.AddScoped<IAdditionalFeatures<PromoCodeDto, PromoCodeResponse, long, PromoCode>, PromoCodeService>();
        service.AddAutoMapper(typeof(PromoCodeMapper));
        service.AddScoped<IAdditionalFeaturesRepository<PromoCode>, AdditionalFeaturesRepository<PromoCode>>();
    }
}
