using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestSide.Application.DTOs.Request.Hotel
{
    public class HotelRequestDto
    {
        public required string Name { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int Stars { get; set; }

        public string? Description { get; set; }

    }
}
