using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestSide.Application.DTOs.Request.Hotel
{
    public class LocationrequestDto
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public long HotelId { get; set; }
    }
}
