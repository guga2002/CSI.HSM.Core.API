using GuestSide.Core.Entities.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestSide.Application.DTOs.Response.Room
{
    public class RoomCategoryResponseDto
    {
        public long Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }
    }
}
