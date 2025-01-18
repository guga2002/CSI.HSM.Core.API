using System.ComponentModel.DataAnnotations;

namespace GuestSide.Application.DTOs.Request.Staff;

public class StaffDto
{
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
