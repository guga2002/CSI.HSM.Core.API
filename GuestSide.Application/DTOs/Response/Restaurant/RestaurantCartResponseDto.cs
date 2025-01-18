namespace Core.Application.DTOs.Response.Restaurant;

public class RestaurantCartResponseDto
{
    public long Id { get; set; }
    public long GuestId { get; set; }
    public string? WhatWillRobotSay { get; set; }
    public decimal Total {  get; set; }
}
