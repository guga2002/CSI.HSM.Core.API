using GuestSide.Core.Entities.Guest;
using GuestSide.Core.Entities.Room;

namespace GuestSide.Application.DTOs.Response.Room
{
    public class RoomsResponseDto
    {
        public long Id { get; set; }

        public int RoomNumber { get; set; }

        public int Floor { get; set; }

        public string? WhatWillRobotSay { get; set; }

        public bool IsAvailable { get; set; } = true;

        public List<byte[]>? Pictures { get; set; }

        public long RoomCategoryId { get; set; }

        public long HotelId { get; set; }

        public long LanguageId { get; set; }

        public virtual RoomCategory? RoomCategory { get; set; }

        public virtual IEnumerable<Guests>? Guests { get; set; }

        public virtual QRCode? QRCode { get; set; }
    }
}
