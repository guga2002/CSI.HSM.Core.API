namespace Core.Application.DTOs.Response.Item;

public class ItemCategoryToStaffCategoryResponseDto
{
    public long Id { get; set; }

    public long ItemCategoryId { get; set; }

    public long? StaffCategoryId { get; set; }
}
