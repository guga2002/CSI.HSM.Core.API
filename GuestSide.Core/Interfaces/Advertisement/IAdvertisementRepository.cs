using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Advertisement
{
    public interface IAdvertisementRepository : IGenericRepository<Entities.Advertisements.Advertisement>
    {
        Task<IEnumerable<Entities.Advertisements.Advertisement>> GetActiveAdvertisementsAsync();
        Task<IEnumerable<Entities.Advertisements.Advertisement>> GetAdvertisementsByTypeAsync(long advertisementTypeId);
        Task<IEnumerable<Entities.Advertisements.Advertisement>> GetAdvertisementsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Entities.Advertisements.Advertisement>> GetAdvertisementsByLanguageAsync(string languageCode);
        Task<Entities.Advertisements.Advertisement> GetAdvertisementByTitleAsync(string title);
        Task<bool> UpdateAdvertisementDatesAsync(long id, DateTime? newStartDate, DateTime? newEndDate);
        Task<bool> DeleteAdvertisementByIdAsync(long id);
    }
}