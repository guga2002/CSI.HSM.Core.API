﻿using Core.Application.DTOs.Request.Hotel;
using Core.Application.DTOs.Response.Hotel;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Hotel.GeoLocation;

namespace Core.Application.Interface.Hotel
{
    public interface ILocationService : IService<LocationrequestDto, LocationResponse, long, Location>,
        IAdditionalFeatures<LocationrequestDto, LocationResponse, long, Location>
    {
        /// <summary>
        /// Get all locations.
        /// </summary>
        Task<IEnumerable<LocationResponse>> GetAllLocationsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get location by hotel ID.
        /// </summary>
        Task<LocationResponse?> GetLocationByHotelId(long hotelId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Find the nearest hotel based on latitude and longitude.
        /// </summary>
        Task<LocationResponse?> FindNearestHotel(double latitude, double longitude, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update the location of a hotel.
        /// </summary>
        Task<bool> UpdateHotelLocation(long hotelId, double latitude, double longitude, CancellationToken cancellationToken = default);
    }
}