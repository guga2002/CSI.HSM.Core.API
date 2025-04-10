using Domain.Core.Interfaces.AbstractInterface;

namespace Domain.Core.Interfaces.Hotel
{
    public interface IHotelRepository : IGenericRepository<Entities.Hotel.Hotel>
    {
        Task<IEnumerable<Entities.Hotel.Hotel>> GetAllHotelsAsync();
        Task<Entities.Hotel.Hotel?> GetHotelById(long hotelId);
        Task<IEnumerable<Entities.Hotel.Hotel>> GetHotelsByCity(string city);
        Task<IEnumerable<Entities.Hotel.Hotel>> GetHotelsByStars(int stars);
        Task<bool> UpdateHotelDetails(long hotelId, string? description, List<string>? pictures, List<string>? facilities);
        Task<Entities.Hotel.Hotel?> GetFullHotelDetails(long hotelId);
    }
}