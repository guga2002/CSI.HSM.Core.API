using Core.Application.DTOs.Request.Advertisment;
using Core.Application.DTOs.Response.Advertisment;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Advertisements;

namespace Core.Application.Interface.AdvertiementType
{
    public interface IAdvertisementTypeService : IService<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, AdvertisementType>,
        IAdditionalFeatures<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, AdvertisementType>
    {
        /// <summary>
        /// Get advertisement type by name.
        /// </summary>
        Task<AdvertisementTypeResponseDto?> GetAdvertisementTypeByNameAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all advertisement types.
        /// </summary>
        Task<IEnumerable<AdvertisementTypeResponseDto>> GetAllAdvertisementTypesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get advertisement types by language.
        /// </summary>
        Task<IEnumerable<AdvertisementTypeResponseDto>> GetAdvertisementTypesByLanguageAsync(string languageCode, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update advertisement type description.
        /// </summary>
        Task<bool> UpdateAdvertisementTypeDescriptionAsync(long advertisementTypeId, string newDescription, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete an advertisement type by ID.
        /// </summary>
        Task<bool> DeleteAdvertisementTypeByIdAsync(long advertisementTypeId, CancellationToken cancellationToken = default);
    }
}