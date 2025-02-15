using Core.Application.DTOs.Request.Guest;
using Core.Application.DTOs.Response.Guest;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Guest;

namespace Core.Application.Interface.Guest
{
    public interface IGuestActiveLanguageService : IService<GuestActiveLanguageDto, GuestActiveLanguageResponseDto, long, GuestActiveLanguage>,
        IAdditionalFeatures<GuestActiveLanguageDto, GuestActiveLanguageResponseDto, long, GuestActiveLanguage>
    {
        /// <summary>
        /// Get the active language of a guest by guest ID.
        /// </summary>
        Task<GuestActiveLanguageResponseDto?> GetActiveLanguageByGuestIdAsync(long guestId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the history of languages used by a guest.
        /// </summary>
        Task<IEnumerable<GuestActiveLanguageResponseDto>> GetGuestLanguageHistoryAsync(long guestId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Set a new active language for a guest.
        /// </summary>
        Task<bool> SetGuestActiveLanguageAsync(long guestId, string languageCode, CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove the active language of a guest.
        /// </summary>
        Task<bool> RemoveGuestActiveLanguageAsync(long guestId, CancellationToken cancellationToken = default);
    }
}