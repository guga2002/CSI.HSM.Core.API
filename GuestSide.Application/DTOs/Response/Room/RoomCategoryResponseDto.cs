using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Response.Room;

public class RoomCategoryResponseDto
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public string? WhatWillRobotSay { get; set; } 

    public string? Description { get; set; }

    public string? LanguageCode { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
