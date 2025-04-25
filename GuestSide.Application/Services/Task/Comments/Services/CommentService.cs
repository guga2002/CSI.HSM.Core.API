using AutoMapper;
using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.Task.Comment;
using Domain.Core.Entities.Task;
using Domain.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Task.Comments.Services;

public class CommentService : GenericService<CommentDto, CommentResponseDto, long, Domain.Core.Entities.Task.Comment>, ICommentService
{
    public CommentService(IMapper mapper,
        IGenericRepository<Comment> repository, 
        ILogger<GenericService<CommentDto, CommentResponseDto, long, Comment>> logger, 
        IAdditionalFeaturesRepository<Comment> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
