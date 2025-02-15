﻿namespace Core.Application.DTOs.Request.Hotel;

public class LocationrequestDto
{
    public string? Address { get; set; }

    public string? MapUrl { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public long HotelId { get; set; }
}
