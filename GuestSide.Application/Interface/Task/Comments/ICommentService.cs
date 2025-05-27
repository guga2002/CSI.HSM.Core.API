using Common.Data.Entities.Task;
using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Task.Comments;

public interface ICommentService : IService<CommentDto, CommentResponseDto, long, Comment>,
    IAdditionalFeatures<CommentDto, CommentResponseDto, long, Comment>
{
}
