using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Response.Audio;

public class AudioResponseCategoryResponseDto
{
    public long Id { get; set; }

    public required string CategoryName { get; set; }

    public string? Description { get; set; }
}

