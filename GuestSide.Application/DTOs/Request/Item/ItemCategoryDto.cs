namespace Core.Application.DTOs.Request.Item;

public class ItemCategoryDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public long LanguageId { get; set; }
}
