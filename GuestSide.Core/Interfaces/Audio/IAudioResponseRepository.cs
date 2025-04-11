using Domain.Core.Entities.Audio;
using Domain.Core.Interfaces.AbstractInterface;

namespace Domain.Core.Interfaces.Audio
{
    public interface IAudioResponseRepository : IGenericRepository<AudioResponse>
    {
        Task<IEnumerable<AudioResponse>> GetAudioResponsesByLanguageAsync(string languageCode);
        Task<IEnumerable<AudioResponse>> GetAudioResponsesByVoiceTypeAsync(string voiceType);
        Task<IEnumerable<AudioResponse>> GetAudioResponsesByCategoryAsync(long categoryId);
        Task<IEnumerable<AudioResponse>> GetAudioResponsesByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<AudioResponse> GetAudioResponseByTextContentAsync(string textContent);
        Task<bool> UpdateAudioResponsePathAsync(long id, string newAudioFilePath);
        Task<bool> DeleteAudioResponseByIdAsync(long id);
    }
}