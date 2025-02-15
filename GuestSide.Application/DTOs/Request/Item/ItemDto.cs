namespace Core.Application.DTOs.Request.Item;

public class ItemDto
{

    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? Information { get; set; }

    public bool IsOrderAble { get; set; }

    public decimal? Price { get; set; }

    public int Quantity { get; set; }

    public string? WhatWillRobotSay { get; set; }

    public long ItemCategoryId { get; set; }

    public string? LanguageCode { get; set; }
}
