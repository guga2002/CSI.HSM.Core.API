namespace GuestSide.Application.DTOs.Response.Item
{
    public class ItemCategoryResponseDto
    {
        public long Id { get; set; }

        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
