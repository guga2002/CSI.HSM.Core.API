using Core.Application.DTOs.Request.Audio;
using Core.Application.DTOs.Response.Audio;
using Core.Application.Interface.GenericContracts;
using Domain.Core.Entities.Audio;

namespace Core.Application.Interface.Audio
{
    public interface IAudioResponseCategoryService : IService<AudioResponseCategoryRequestDto, AudioResponseCategoryResponseDto, long, AudioResponseCategory>,
        IAdditionalFeatures<AudioResponseCategoryRequestDto, AudioResponseCategoryResponseDto, long, AudioResponseCategory>
    {
        /// <summary>
        /// Get category by name.
        /// </summary>
        Task<AudioResponseCategoryResponseDto?> GetCategoryByNameAsync(string categoryName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all available categories.
        /// </summary>
        Task<IEnumerable<AudioResponseCategoryResponseDto>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Update category description.
        /// </summary>
        Task<bool> UpdateCategoryDescriptionAsync(long categoryId, string newDescription, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete a category by ID.
        /// </summary>
        Task<bool> DeleteCategoryByIdAsync(long categoryId, CancellationToken cancellationToken = default);
    }
}