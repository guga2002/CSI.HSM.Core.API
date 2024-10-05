using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace GuestSide.Application.Interface
{
    public interface IService<TEntityDto, TKey>
    {
        Task<IEnumerable<TEntityDto>> GetAllAsync();
        Task<TEntityDto> GetByIdAsync(TKey id);
        Task<bool> CreateAsync(TEntityDto entityDto);
        Task<bool> UpdateAsync(TKey id, TEntityDto entityDto);
        Task<bool> DeleteAsync(TKey id);
    }

}
