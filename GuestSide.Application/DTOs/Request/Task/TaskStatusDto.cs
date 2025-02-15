﻿namespace Core.Application.DTOs.Request.Task;

public class TaskStatusDto
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? LanguageCode { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
