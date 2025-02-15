using System.ComponentModel.DataAnnotations;
using Core.Application.DTOs.Response.Task;
using Core.Core.Entities.Guest;
using Core.Core.Entities.Task;

namespace Core.Application.DTOs.Response.Item;

public class CartResponseDto
{
    public long Id { get; set; }

    public long GuestId { get; set; }

    public string? WhatWillRobotSay { get; set; } 

    public string? LanguageCode { get; set; }

    public bool IsComplete { get; set; }

    public IEnumerable<TaskResponseDto> Tasks { get; set; }
}

