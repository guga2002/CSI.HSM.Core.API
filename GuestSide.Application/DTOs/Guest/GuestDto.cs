using System.ComponentModel.DataAnnotations;

namespace GuestSide.Application.DTOs.NewFolder
{
    public class GuestDto
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }


        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public string? Address { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CheckOutDate { get; set; }

        public long RoomId { get; set; }

    }
}
