namespace Core.Application.DTOs.Request.Audio;

public class AudioRequestDto
{
    public required string TextContent { get; set; }

    public long LanguageId { get; set; }

    public string? VoiceType { get; set; }

    public required string AudioFilePath { get; set; }

    public TimeSpan Duration { get; set; }

    public DateTime CreatedDate { get; set; }

    public long CategoryId { get; set; }
}
