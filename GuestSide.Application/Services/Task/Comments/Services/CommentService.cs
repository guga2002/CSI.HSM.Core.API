using AutoMapper;
using Common.Data.Entities.Task;
using Common.Data.Interfaces.AbstractInterface;
using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.Task.Comments;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Task.Comments.Services;

public class CommentService : GenericService<CommentDto, CommentResponseDto, long, Comment>, ICommentService
{
    public CommentService(IMapper mapper,
        IGenericRepository<Comment> repository, 
        ILogger<GenericService<CommentDto, CommentResponseDto, long, Comment>> logger, 
        IAdditionalFeaturesRepository<Comment> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
