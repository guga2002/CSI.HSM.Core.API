namespace Core.Application.DTOs.Response.Language;

public class LanguagePackResponseDto : AbstractResponse
{
    public required string Code { get; set; }

    public required string Name { get; set; }

    public byte[]? LanguageCountryImage { get; set; }
}
