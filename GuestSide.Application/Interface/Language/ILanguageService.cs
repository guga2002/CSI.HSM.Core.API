using Core.Application.DTOs.Request.Language;
using Core.Application.DTOs.Response.Language;
using Core.Application.Interface.GenericContracts;
using Domain.Core.Entities.Language;

namespace Core.Application.Interface.Language
{
    public interface ILanguageService : IService<LanguagePackDto, LanguagePackResponseDto, long, LanguagePack>,
        IAdditionalFeatures<LanguagePackDto, LanguagePackResponseDto, long, LanguagePack>
    {
        /// <summary>
        /// Get all active languages.
        /// </summary>
        Task<IEnumerable<LanguagePackResponseDto>> GetAllActiveLanguages(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a language by its code.
        /// </summary>
        Task<LanguagePackResponseDto?> GetLanguageByCode(string code, CancellationToken cancellationToken = default);

        /// <summary>
        /// Soft delete a language.
        /// </summary>
        Task<bool> SoftDeleteLanguage(long languageId, CancellationToken cancellationToken = default);
    }
}