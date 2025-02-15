﻿using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Response.Item;

public class ItemCategoryResponseDto
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public string? WhatWillRobotSay { get; set; } 

    public string? Description { get; set; }

    public string? LanguageCode { get; set; }
}
