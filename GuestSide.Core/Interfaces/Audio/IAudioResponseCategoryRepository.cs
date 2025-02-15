using Core.Core.Entities.Audio;
using Core.Core.Interfaces.AbstractInterface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Core.Interfaces.Audio
{
    public interface IAudioResponseCategoryRepository : IGenericRepository<AudioResponseCategory>
    {
        Task<AudioResponseCategory> GetCategoryByNameAsync(string categoryName);
        Task<IEnumerable<AudioResponseCategory>> GetAllCategoriesAsync();
        Task<bool> UpdateCategoryDescriptionAsync(long categoryId, string newDescription);
        Task<bool> DeleteCategoryByIdAsync(long categoryId);
    }
}