namespace Core.Application.DTOs.Request.Room;

public class RoomCategoryDto
{
    public required string Name { get; set; }

    public string? WhatWillRobotSay { get; set; }

    public string? Description { get; set; }

    public string? LanguageCode { get; set; }
}
