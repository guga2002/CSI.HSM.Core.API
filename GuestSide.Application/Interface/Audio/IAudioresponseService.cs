using Core.Application.DTOs.Request.Audio;
using Core.Application.DTOs.Response.Audio;
using Core.Application.Interface.GenericContracts;
using Domain.Core.Entities.Audio;

namespace Core.Application.Interface.Audio
{
    public interface IAudioResponseService : IService<AudioRequestDto, AudioResponseDto, long, AudioResponse>,
        IAdditionalFeatures<AudioRequestDto, AudioResponseDto, long, AudioResponse>
    {
        /// <summary>
        /// Get audio responses by language.
        /// </summary>
        Task<IEnumerable<AudioResponseDto>> GetAudioResponsesByLanguageAsync(string languageCode, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get audio responses by voice type.
        /// </summary>
        Task<IEnumerable<AudioResponseDto>> GetAudioResponsesByVoiceTypeAsync(string voiceType, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get audio responses by category.
        /// </summary>
        Task<IEnumerable<AudioResponseDto>> GetAudioResponsesByCategoryAsync(long categoryId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get audio responses within a specific date range.
        /// </summary>
        Task<IEnumerable<AudioResponseDto>> GetAudioResponsesByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get an audio response by matching text content.
        /// </summary>
        Task<AudioResponseDto?> GetAudioResponseByTextContentAsync(string textContent, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update the file path of an audio response.
        /// </summary>
        Task<bool> UpdateAudioResponsePathAsync(long id, string newAudioFilePath, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete an audio response by ID.
        /// </summary>
        Task<bool> DeleteAudioResponseByIdAsync(long id, CancellationToken cancellationToken = default);
    }
}
