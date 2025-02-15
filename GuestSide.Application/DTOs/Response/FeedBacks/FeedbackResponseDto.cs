using Core.Application.DTOs.Response.Task;

namespace Core.Application.DTOs.Response.FeedBacks;

public class FeedbackResponseDto
{
    public long Id { get; set; }

    public required string Title { get; set; }
    public required string Content { get; set; }

    public string? WhatWillRobotSay { get; set; }

    public Guid CorrelationId { get; set; }

    public int Rating { get; set; }

    public DateTime FeedbackDate { get; set; }

    public long LanguageId { get; set; }

    public long TasksId { get; set; }
    public virtual TaskResponseDto? Task { get; set; }

}
