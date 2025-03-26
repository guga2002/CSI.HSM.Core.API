namespace Core.Application.DTOs.Response.Staff;

public class StaffCategoryResponseDto
{
    public long Id { get; set; }

    public required string CategoryName { get; set; }

    public string? Description { get; set; }

    public string? LanguageCode { get; set; }
}
