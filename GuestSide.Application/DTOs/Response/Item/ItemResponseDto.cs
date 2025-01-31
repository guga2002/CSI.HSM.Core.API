﻿using GuestSide.Core.Entities.Item;
using GuestSide.Core.Entities.Language;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Application.DTOs.Response.Item;

public class ItemResponseDto
{
    public long Id { get; set; }
    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? Information { get; set; }

    public bool IsOrderable { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public long ItemCategoryId { get; set; }

    public long LanguageId { get; set; }
}
