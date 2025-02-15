using Core.Core.Entities.Advertisements;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Advertisement;

public interface IAdvertisementTypeRepository : IGenericRepository<AdvertisementType>
{
    Task<AdvertisementType> GetAdvertisementTypeByNameAsync(string name);
    Task<IEnumerable<AdvertisementType>> GetAllAdvertisementTypesAsync();
    Task<IEnumerable<AdvertisementType>> GetAdvertisementTypesByLanguageAsync(string languageCode);
    Task<bool> UpdateAdvertisementTypeDescriptionAsync(long advertisementTypeId, string newDescription);
    Task<bool> DeleteAdvertisementTypeByIdAsync(long advertisementTypeId);
}