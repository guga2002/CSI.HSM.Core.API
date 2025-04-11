using Core.Application.DTOs.Request.Promo;
using Core.Application.DTOs.Response.Promo;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Promo;
using Core.Application.Services.Promo.Mapper;
using Core.Application.Services.Promo.Service;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Promo;
using Domain.Core.Entities.Promo;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Promo;
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
