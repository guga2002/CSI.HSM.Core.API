

namespace Core.Application.DTOs.Response.Notification;

public class NotificationResponseDto
{
    public long Id { get; set; }

    public required string Title { get; set; }

    public required string Message { get; set; }

    public DateTime NotificationDate { get; set; }

    public bool IsRead { get; set; }

    public string? WhatWillRobotSay { get; set; }

    public long LanguageId { get; set; }
}
