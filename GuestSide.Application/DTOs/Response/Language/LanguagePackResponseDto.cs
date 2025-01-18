namespace Core.Application.DTOs.Response.Language;

public class LanguagePackResponseDto
{
    public long Id { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }
}
