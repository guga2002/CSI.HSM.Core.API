namespace Core.Application.DTOs.Request.Staff;

public class StaffCategoryDto
{
    public required string CategoryName { get; set; }

    public string? Description { get; set; }

    public string? LanguageCode { get; set; }
}
