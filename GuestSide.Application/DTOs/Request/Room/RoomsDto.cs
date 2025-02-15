namespace Core.Application.DTOs.Request.Room
{
    public class RoomsDto
    {
        public int RoomNumber { get; set; }

        public int Floor { get; set; }

        public string? WhatWillRobotSay { get; set; }

        public bool IsAvailable { get; set; }

        public int MaxOccupancy { get; set; }

        public decimal PricePerNight { get; set; }

        public string? PictureUrlsSerialized { get; set; }


        public List<string>? Pictures
        {
            get;
            set;
        }

        public long RoomCategoryId { get; set; }


        public long HotelId { get; set; }


        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
