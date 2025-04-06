using Core.Application.DTOs.Response.Item;

namespace Core.Application.DTOs.Response.Staff;

public class StaffCategoryResponseDto : AbstractResponse
{
    public required string CategoryName { get; set; }

    public string? Description { get; set; }

    public string? LanguageCode { get; set; }

    public virtual List<StaffResponseDto>? Staff { get; set; }

    public virtual List<TaskToStaffResponseDto>? TaskToStaff { get; set; }

    public virtual List<ItemCategoryToStaffCategoryResponseDto>? ItemCategoryToStaff { get; set; }

    public virtual List<IncidentTypeToStaffCategoryResponseDto>? StaffIncidentTypeToStaffCategories { get; set; }

}
