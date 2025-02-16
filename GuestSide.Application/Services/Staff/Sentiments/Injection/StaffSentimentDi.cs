using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Staff;
using Core.Application.Services.Staff.Incident.Mapper;
using Core.Application.Services.Staff.Incident.Service;
using Core.Application.Services.Staff.Sentiments.Mapper;
using Core.Application.Services.Staff.Sentiments.Service;
using Core.Core.Entities.Staff;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Staff;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Staff;
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
