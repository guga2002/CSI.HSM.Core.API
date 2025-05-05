using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Audio;
using Domain.Core.Interfaces.Audio;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Audio
{
    public class AudioResponseRepository : GenericRepository<AudioResponse>, IAudioResponseRepository
    {
        public AudioResponseRepository(CoreSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<AudioResponse> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        /// <summary>
        /// Get all audio responses for a specific language
        /// </summary>
        public async Task<IEnumerable<AudioResponse>> GetAudioResponsesByLanguageAsync(string languageCode)
        {
            return await DbSet
                .Where(a => a.LanguageCode == languageCode)
                .OrderByDescending(a => a.CreatedDate)
                .ToListAsync();
        }

        /// <summary>
        /// Get all audio responses for a specific voice type
        /// </summary>
        public async Task<IEnumerable<AudioResponse>> GetAudioResponsesByVoiceTypeAsync(string voiceType)
        {
            return await DbSet
                .Where(a => a.VoiceType == voiceType)
                .OrderByDescending(a => a.CreatedDate)
                .ToListAsync();
        }

        /// <summary>
        /// Get all audio responses in a specific category
        /// </summary>
        public async Task<IEnumerable<AudioResponse>> GetAudioResponsesByCategoryAsync(long categoryId)
        {
            return await DbSet
                .Where(a => a.CategoryId == categoryId)
                .OrderByDescending(a => a.CreatedDate)
                .ToListAsync();
        }

        /// <summary>
        /// Get audio responses within a specific date range
        /// </summary>
        public async Task<IEnumerable<AudioResponse>> GetAudioResponsesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await DbSet
                .Where(a => a.CreatedDate >= startDate && a.CreatedDate <= endDate)
                .OrderByDescending(a => a.CreatedDate)
                .ToListAsync();
        }

        /// <summary>
        /// Get an audio response based on the text content
        /// </summary>
        public async Task<AudioResponse> GetAudioResponseByTextContentAsync(string textContent)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.TextContent == textContent);
        }

        /// <summary>
        /// Update the file path of an audio response
        /// </summary>
        public async Task<bool> UpdateAudioResponsePathAsync(long id, string newAudioFilePath)
        {
            var audioResponse = await DbSet.FindAsync(id);
            if (audioResponse == null) return false;

            audioResponse.AudioFilePath = newAudioFilePath;
            Context.Update(audioResponse);
            await Context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Delete an audio response by ID
        /// </summary>
        public async Task<bool> DeleteAudioResponseByIdAsync(long id)
        {
            var audioResponse = await DbSet.FindAsync(id);
            if (audioResponse == null) return false;

            DbSet.Remove(audioResponse);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
