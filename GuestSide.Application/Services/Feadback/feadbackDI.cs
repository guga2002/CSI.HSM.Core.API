using GuestSide.Application.DTOs.FeedBacks;
using GuestSide.Application.Interface;
using GuestSide.Application.Interface.Feadback;
using GuestSide.Core.Entities.Feedbacks;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.FeedBack;
using GuestSide.Infrastructure.Repositories.FeedBack;
using Microsoft.Extensions.DependencyInjection;

namespace GuestSide.Application.Services.Feadback
{
    public static class feadbackDI
    {
        public static void InjectFeadbacks(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<Feedback>, FeedbackRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IFeadbackService,feadbackService>();
            services.AddScoped<IService<FeedbackDto, long, Feedback>, feadbackService>();
            /// services.AddScoped<ILogger<GenericService<FeedbackDto, long, Feedback>>>();
        }
    }
}
