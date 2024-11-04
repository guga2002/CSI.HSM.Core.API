namespace GuestSide.Application.Interface
{
    public interface IService<RequestDto, ResponseDto, TKey, DatabaseEntity>
    {
        Task<IEnumerable<ResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ResponseDto> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
        Task<bool> CreateAsync(RequestDto entityDto, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(TKey id, RequestDto entityDto, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default);
    }

}
