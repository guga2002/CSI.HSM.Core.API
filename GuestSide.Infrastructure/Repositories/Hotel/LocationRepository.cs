using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Hotel.GeoLocation;
using Domain.Core.Interfaces.Hotel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Hotel
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(CoreSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Location> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        public override Task<Location> AddAsync(Location entity, CancellationToken cancellationToken = default)
        {
            entity.MapUrl = $"https://www.google.com/maps?q={entity.Latitude},{entity.Longitude}";
            return base.AddAsync(entity, cancellationToken);
        }

        public override Task<Location> UpdateAsync(Location entity, CancellationToken cancellationToken = default)
        {
            entity.MapUrl = $"https://www.google.com/maps?q={entity.Latitude},{entity.Longitude}";
            return base.UpdateAsync(entity, cancellationToken);
        }

        #region Get All Locations
        public async Task<IEnumerable<Location>> GetAllLocationsAsync()
        {
            var locations = await DbSet
                .Include(l => l.Hotel)
                .OrderBy(l => l.Address)
                .ToListAsync();
            return locations;
        }
        #endregion

        #region Get Location by Hotel ID
        public async Task<Location?> GetLocationByHotelId(long hotelId)
        {
            var location = await DbSet
                .Include(l => l.Hotel)
                .FirstOrDefaultAsync(l => l.Hotel.Id == hotelId);

            return location;
        }
        #endregion

        #region Find Nearest Hotel
        public async Task<Location?> FindNearestHotel(double latitude, double longitude)
        {
            return await DbSet
                .OrderBy(l => (l.Latitude - latitude) * (l.Latitude - latitude) + (l.Longitude - longitude) * (l.Longitude - longitude))
                .FirstOrDefaultAsync();
        }
        #endregion

        #region Update Hotel Location
        public async Task<bool> UpdateHotelLocation(long hotelId, double latitude, double longitude)
        {
            var location = await DbSet.Include(i => i.Hotel).FirstOrDefaultAsync(l => l.Hotel.Id == hotelId);

            if (location == null) return false;

            location.Latitude = latitude;
            location.Longitude = longitude;

            await Context.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get All (Overridden)
        public override async Task<IEnumerable<Location>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.Include(l => l.Hotel).OrderBy(l => l.Address).ToListAsync(cancellationToken);
        }
        #endregion

        #region Get By ID (Overridden)
        public override async Task<Location> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Include(l => l.Hotel)
                .FirstOrDefaultAsync(l => l.Id == long.Parse(id.ToString()), cancellationToken);
        }
        #endregion
    }
}
