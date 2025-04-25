using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Task.Comment;
using Core.Application.Services.Task.Comments.Mapper;
using Core.Application.Services.Task.Comments.Services;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Task;
using Domain.Core.Entities.Staff;
using Domain.Core.Entities.Task;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Task;
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
        services.AddScoped<IAdditionalFeatures<CommentDto, CommentResponseDto, long, Domain.Core.Entities.Task.Comment>, CommentService>();
        services.AddScoped<IAdditionalFeaturesRepository<Comment>, AdditionalFeaturesRepository<Comment>>();
        services.AddAutoMapper(typeof(CommentMapper));
    }
}
