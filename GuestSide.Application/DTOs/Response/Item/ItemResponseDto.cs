using Core.Application.DTOs.Response;

namespace Core.Application.DTOs.Response.Item;

public class ItemResponseDto : AbstractResponse
{
    public virtual ItemCategoryResponseDto? ItemCategory { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? Information { get; set; }

    public bool IsOrderAble { get; set; }

    public decimal? Price { get; set; }

    public string? WhatWillRobotSay { get; set; }

    public long ItemCategoryId { get; set; }

    public string? LanguageCode { get; set; }

    public List<string>? Pictures { get; set; }
}
