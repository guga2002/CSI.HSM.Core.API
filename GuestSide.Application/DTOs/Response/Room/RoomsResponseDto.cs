using Core.Application.DTOs.Response;

namespace Core.Application.DTOs.Response.Room;

public class RoomsResponseDto : AbstractResponse
{
    public int RoomNumber { get; set; }

    public int Floor { get; set; }

    public string? WhatWillRobotSay { get; set; }

    public bool IsAvailable { get; set; }

    public int MaxOccupancy { get; set; }

    public decimal PricePerNight { get; set; }

    public List<string>? Pictures
    {
        get;
        set;
    }

    public long RoomCategoryId { get; set; }

    public long HotelId { get; set; }

    public virtual RoomCategoryResponseDto? RoomCategory { get; set; }

    public virtual QRCodeResponseDto? QRCode { get; set; }
}
