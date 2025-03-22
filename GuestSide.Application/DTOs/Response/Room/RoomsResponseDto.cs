
using Core.Core.Entities.Guest;
using Core.Core.Entities.Room;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Response.Room
{
    public class RoomsResponseDto
    {
        public long Id { get; set; }

        public bool  IsActive { get; set; }
        public int RoomNumber { get; set; }

        public int Floor { get; set; }

        public string? WhatWillRobotSay { get; set; }

        public bool IsAvailable { get; set; } 

        public int MaxOccupancy { get; set; }

        public decimal PricePerNight { get; set; } 

        public List<string>? Pictures
        {
            get ;
            set ;
        }

        public long RoomCategoryId { get; set; }


        public long HotelId { get; set; }


        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; } 

        public virtual RoomCategoryResponseDto? RoomCategory { get; set; }

        public virtual QRCodeResponseDto? QRCode { get; set; }
    }
}
