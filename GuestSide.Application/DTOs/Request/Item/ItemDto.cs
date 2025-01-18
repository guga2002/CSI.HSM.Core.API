namespace GuestSide.Application.DTOs.Request.Item;

public class ItemDto
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? Information { get; set; }

    public string? WhatWillRobotSay { get; set; }

    public long ItemCategoryId { get; set; }

    public long LanguageId { get; set; }
}
