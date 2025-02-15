using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Response.Audio;

public class AudioResponseDto
{
    public long Id { get; set; }

    public required string TextContent { get; set; }

    public string? LanguageCode { get; set; }

    public string? VoiceType { get; set; }

    public required string AudioFilePath { get; set; }

    public TimeSpan Duration { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public long CategoryId { get; set; }
}
