using AutoMapper;
using Common.Data.Entities.Task;
using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;

namespace Core.Application.Services.Task.Comments.Mapper;

public class CommentMapper:Profile
{
    public CommentMapper()
    {
        CreateMap<CommentDto,Comment>().ReverseMap();
        CreateMap<Comment,CommentResponseDto>().ReverseMap();
    }
}
