using Core.Core.Interfaces.UniteOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure.Repositories.UniteOfWork.Injection;

public static class InjectUniteOfWork
{

    public static void Active_Unite_Of_Work(this IServiceCollection service)
    {
        service.AddScoped<IUniteOfWork, UniteOfWorkRepository>();
    }
}
