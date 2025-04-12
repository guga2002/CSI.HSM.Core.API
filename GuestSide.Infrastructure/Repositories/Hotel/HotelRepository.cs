using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Interfaces.Hotel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Core.Infrastructure.Repositories.Hotel;

public class HotelRepository : GenericRepository<Domain.Core.Entities.Hotel.Hotel>, IHotelRepository
{
    public HotelRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Domain.Core.Entities.Hotel.Hotel> logger)
        : base(context, redisCache, httpContextAccessor, logger)
    {
    }

    #region  Get All Hotels
    public async Task<IEnumerable<Domain.Core.Entities.Hotel.Hotel>> GetAllHotelsAsync()
    {

        var hotels = await DbSet
            .Include(h => h.Location)
            .Include(h => h.Rooms)
            .OrderBy(h => h.Name)
            .ToListAsync();
        return hotels;
    }
    #endregion

    #region  Get Hotel by ID
    public async Task<Domain.Core.Entities.Hotel.Hotel?> GetHotelById(long hotelId)
    {

        var hotel = await DbSet
            .Include(h => h.Location)
            .Include(h => h.Rooms)
            .FirstOrDefaultAsync(h => h.Id == hotelId);
        return hotel;
    }
    #endregion

    #region Get Hotels by City
    public async Task<IEnumerable<Domain.Core.Entities.Hotel.Hotel>> GetHotelsByCity(string city)
    {
        return await DbSet
            .Where(predicate: h => h.Location.City == city)
            .OrderBy(h => h.Name)
            .ToListAsync();
    }
    #endregion

    #region Get Hotels by Stars
    public async Task<IEnumerable<Domain.Core.Entities.Hotel.Hotel>> GetHotelsByStars(int stars)
    {
        return await DbSet
            .Where(h => h.Stars == stars)
            .OrderBy(h => h.Name)
            .ToListAsync();
    }
    #endregion

    #region Update Hotel Details
    public async Task<bool> UpdateHotelDetails(long hotelId, string? description, List<string>? pictures, List<string>? facilities)
    {
        var hotel = await DbSet.FirstOrDefaultAsync(h => h.Id == hotelId);

        if (hotel == null) return false;

        if (description != null) hotel.Description = description;
        if (pictures != null) hotel.PicturesSerialized = JsonSerializer.Serialize(pictures);
        if (facilities != null) hotel.FacilitiesSerialized = JsonSerializer.Serialize(facilities);

        await Context.SaveChangesAsync();
        return true;
    }
    #endregion

    #region  Get Full Hotel Details
    public async Task<Domain.Core.Entities.Hotel.Hotel?> GetFullHotelDetails(long hotelId)
    {
        return await DbSet
            .Include(h => h.Location)
            .Include(h => h.Rooms)
            .FirstOrDefaultAsync(h => h.Id == hotelId);
    }
    #endregion

    #region  Get All (Overridden)
    public override async Task<IEnumerable<Domain.Core.Entities.Hotel.Hotel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(h => h.Location)
            .Include(h => h.Rooms)
            .OrderBy(h => h.Name)
            .ToListAsync(cancellationToken);
    }
    #endregion

    #region Get By ID (Overridden)
    public override async Task<Domain.Core.Entities.Hotel.Hotel> GetByIdAsync(object id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(h => h.Location)
            .Include(h => h.Rooms)
            .FirstOrDefaultAsync(h => h.Id == long.Parse(id.ToString()), cancellationToken);
    }
    #endregion
}
