using System.ComponentModel.DataAnnotations;

namespace GuestSide.Application.DTOs.Response.Staff
{
    public class StaffResponseDto
    {
        public long Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }


        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }

        public long StaffCategoryId { get; set; }

    }
}
