using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.DTOs.Request.Staff;

public class StaffDto
{
    [StringLength(100)] 
    public required string FirstName { get; set; }

    [StringLength(100)] 
    public required string LastName { get; set; }

    [StringLength(100)] 
    public required string Email { get; set; }

    [StringLength(100)] 
    public required string PhoneNumber { get; set; }

    [StringLength(50)] 
    public required string Position { get; set; }

    [DataType(DataType.Date)] 
    public DateTime? DateOfBirth { get; set; }

    [DataType(DataType.Date)] 
    public DateTime? HireDate { get; set; } = DateTime.UtcNow;

    [Precision(18, 2)] 
    public decimal? Salary { get; set; }

    [StringLength(150)] 
    public string? ProfilePictureUrl { get; set; }

    public long StaffCategoryId { get; set; }

    public long? SupervisorId { get; set; }

    [StringLength(200)] 
    public string? EmergencyContact { get; set; }

    [StringLength(500)] 
    public string? Bio { get; set; }
}
