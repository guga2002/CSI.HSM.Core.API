namespace Core.Application.DTOs.Response.Item;

public class OrderableItemResponseDto
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? WhatWillRobotSay { get; set; }

    public decimal? Price { get; set; } = 0;

    public long LanguageId { get; set; }

    public long ItemCategoryId { get; set; }
}
