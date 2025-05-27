using Common.Data.Entities.Task;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Interfaces.Task;
using Common.Data.Repositories.AbstractRepository;
using Common.Data.Repositories.Task;
using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Task.Comments;
using Core.Application.Services.Task.Comments.Mapper;
using Core.Application.Services.Task.Comments.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Task.Comments.DI;

public static class CommentDi
{
    public static void InjectComment(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Comment>, CommentRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IService<CommentDto, CommentResponseDto, long, Comment>, CommentService>();
        services.AddScoped<IAdditionalFeatures<CommentDto, CommentResponseDto, long, Comment>, CommentService>();
        services.AddScoped<IAdditionalFeaturesRepository<Comment>, AdditionalFeaturesRepository<Comment>>();
        services.AddAutoMapper(typeof(CommentMapper));
    }
}
