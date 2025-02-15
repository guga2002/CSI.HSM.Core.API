﻿namespace Core.Application.DTOs.Response.Advertisment;

public class AdvertisementTypeResponseDto
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public long LanguageId { get; set; }
}
