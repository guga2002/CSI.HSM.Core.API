namespace GuestSide.Application.Interface
{
    public interface IService<TEntityDto, TKey, DatabaseEntity>
    {
        Task<IEnumerable<TEntityDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TEntityDto> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
        Task<bool> CreateAsync(TEntityDto entityDto, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(TKey id, TEntityDto entityDto, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default);
    }

}
