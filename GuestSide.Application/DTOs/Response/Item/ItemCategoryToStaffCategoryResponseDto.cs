namespace Core.Application.DTOs.Response.Item;

public class ItemCategoryToStaffCategoryResponseDto : AbstractResponse
{
    public long ItemCategoryId { get; set; }

    public long? StaffCategoryId { get; set; } 
}
