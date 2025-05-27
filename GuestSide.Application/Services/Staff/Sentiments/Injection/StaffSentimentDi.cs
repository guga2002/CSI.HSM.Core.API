using Common.Data.Entities.Staff;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Interfaces.Staff;
using Common.Data.Repositories.AbstractRepository;
using Common.Data.Repositories.Staff;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Staff.Sentiments;
using Core.Application.Services.Staff.Sentiments.Mapper;
using Core.Application.Services.Staff.Sentiments.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Staff.Sentiments.Injection
{
    public static class StaffSentimentDi
    {
        public static void ActiveStaffSentiments(this IServiceCollection services)
        {

            services.AddScoped<IGenericRepository<StaffSentiment>, StaffSentimentRepository>();
            services.AddScoped<IStaffSentimentRepository, StaffSentimentRepository>();
            services.AddScoped<IStaffSentimentService, StaffSentimentService>();
            services.AddScoped<IService<StaffSentimentDto, StaffSentimentResponseDto, long, StaffSentiment>, StaffSentimentService>();
            services.AddScoped<IAdditionalFeatures<StaffSentimentDto, StaffSentimentResponseDto, long, StaffSentiment>, StaffSentimentService>();
            services.AddAutoMapper(typeof(StaffSentimentMapper));
            services.AddScoped<IAdditionalFeaturesRepository<StaffSentiment>, AdditionalFeaturesRepository<StaffSentiment>>();
        }
    }
}
