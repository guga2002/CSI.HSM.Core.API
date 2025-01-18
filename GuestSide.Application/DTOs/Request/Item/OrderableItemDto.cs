﻿namespace Core.Application.DTOs.Request.Item;

public class OrderableItemDto
{
    public required string Name { get; set; }

    public string? Description { get; set; }
    public string? WhatWillRobotSay { get; set; }

    public decimal? Price { get; set; } = 0;

    public long LanguageId { get; set; }

    public long ItemCategoryId { get; set; }
}
