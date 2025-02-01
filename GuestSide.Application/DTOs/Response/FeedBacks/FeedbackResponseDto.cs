using GuestSide.Application.DTOs.Response.Task;

namespace GuestSide.Application.DTOs.Response.FeedBacks;

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
