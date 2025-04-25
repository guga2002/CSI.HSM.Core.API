using Core.Application.DTOs.Response;

namespace Core.Application.DTOs.Response.Room;

public class RoomCategoryResponseDto : AbstractResponse
{
    public required string Name { get; set; }

    public string? WhatWillRobotSay { get; set; }

    public string? Description { get; set; }

    public string? LanguageCode { get; set; }
}
