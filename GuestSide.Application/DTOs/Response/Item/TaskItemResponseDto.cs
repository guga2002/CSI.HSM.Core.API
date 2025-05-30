﻿namespace Core.Application.DTOs.Response.Item;

public class TaskItemResponseDto : AbstractResponse
{
    public long TaskId { get; set; }

    public long ItemId { get; set; }

    public int Quantity { get; set; }

    public bool IsCompleted { get; set; } 

    public DateTime AssignedDate { get; set; } 

    public string? Notes { get; set; }
}
