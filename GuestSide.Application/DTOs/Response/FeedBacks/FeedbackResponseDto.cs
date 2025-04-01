using Core.Application.DTOs.Response.Task;

namespace Core.Application.DTOs.Response.FeedBacks;

public class FeedbackResponseDto
{
    public required string Title { get; set; }

    public required string Content { get; set; }

    public string? WhatWillRobotSay { get; set; }

    public Guid CorrelationId { get; set; } //= Guid.NewGuid();

    public int Rating { get; set; }

    public DateTime FeedbackDate { get; set; } //= DateTime.UtcNow;

    public string? LanguageCode { get; set; }

    public long TaskId { get; set; }

    public virtual TaskResponseDto? Task { get; set; }

    public long Id { get; set; }

    public bool IsActive { get; set; } 

}
