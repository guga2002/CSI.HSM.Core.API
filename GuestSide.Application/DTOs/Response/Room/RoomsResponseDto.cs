
namespace Core.Application.DTOs.Response.Room
{
    public class RoomsResponseDto
    {
        public long Id { get; set; }

        public int RoomNumber { get; set; }

        public int Floor { get; set; }

        public string? WhatWillRobotSay { get; set; }

        public bool IsAvailable { get; set; } = true;

        public List<string>? Pictures { get; set; }

        public long RoomCategoryId { get; set; }

        public long HotelId { get; set; }

        public long LanguageId { get; set; }

        public virtual RoomCategoryResponseDto? RoomCategory { get; set; }

        public virtual QRCodeResponseDto? QRCode { get; set; }
    }
}
