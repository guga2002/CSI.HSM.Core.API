namespace GuestSide.Application.DTOs.Response.Item;

public class ItemResponseDto
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; } = 0;

    public long ItemCategoryId { get; set; }

    public byte ItemCount { get; set; }

    public long LanguageId { get; set; }
}
