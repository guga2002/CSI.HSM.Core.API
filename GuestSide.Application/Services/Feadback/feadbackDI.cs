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
        }
    }
}
