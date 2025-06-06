﻿using AutoMapper;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Domain.Core.Entities.Item;

namespace Core.Application.Services.Item.Mapper;

public class TaskItemMapper:Profile
{
    public TaskItemMapper()
    {
        CreateMap<TaskItemDto, TaskItem>().ReverseMap();
        CreateMap<TaskItem, TaskItemResponseDto>().ReverseMap();
    }
}
