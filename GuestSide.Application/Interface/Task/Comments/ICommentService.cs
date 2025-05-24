using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Task.Comments;

public interface ICommentService : IService<CommentDto, CommentResponseDto, long, Domain.Core.Entities.Task.Comment>,
    IAdditionalFeatures<CommentDto, CommentResponseDto, long, Domain.Core.Entities.Task.Comment>
{
}
