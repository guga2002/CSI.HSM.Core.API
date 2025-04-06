using Core.Application.DTOs.Response.Task;

namespace Core.Application.DTOs.Response.Item;

public class CartResponseDto : AbstractResponse
{
    public long GuestId { get; set; }

    public string? WhatWillRobotSay { get; set; }

    public string? LanguageCode { get; set; }

    public bool IsComplete { get; set; }

    public virtual IEnumerable<TaskResponseDto>? Tasks { get; set; }
}

