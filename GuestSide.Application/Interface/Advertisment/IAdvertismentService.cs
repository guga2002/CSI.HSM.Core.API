using Common.Data.Entities.Advertisements;
using Core.Application.DTOs.Request.Advertisment;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Advertisment
{
    public interface IAdvertisementService : IService<AdvertismentDto, AdvertismentResponseDto, long, Advertisement>,
        IAdditionalFeatures<AdvertismentDto, AdvertismentResponseDto, long, Advertisement>
    {
        /// <summary>
        /// Get all active advertisements.
        /// </summary>
        Task<IEnumerable<AdvertismentResponseDto>> GetActiveAdvertisementsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get advertisements by type.
        /// </summary>
        Task<IEnumerable<AdvertismentResponseDto>> GetAdvertisementsByTypeAsync(long advertisementTypeId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get advertisements within a specific date range.
        /// </summary>
        Task<IEnumerable<AdvertismentResponseDto>> GetAdvertisementsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get advertisements by language.
        /// </summary>
        Task<IEnumerable<AdvertismentResponseDto>> GetAdvertisementsByLanguageAsync(string languageCode, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get an advertisement by title.
        /// </summary>
        Task<AdvertismentResponseDto?> GetAdvertisementByTitleAsync(string title, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update advertisement start and end dates.
        /// </summary>
        Task<bool> UpdateAdvertisementDatesAsync(long id, DateTime? newStartDate, DateTime? newEndDate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete an advertisement by ID.
        /// </summary>
        Task<bool> DeleteAdvertisementByIdAsync(long id, CancellationToken cancellationToken = default);
    }
}
