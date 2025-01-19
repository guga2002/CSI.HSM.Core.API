namespace Core.Application.Interface.GenericContracts
{
    public interface IService<RequestDto, ResponseDto, TKey, DatabaseEntity>
    {
        Task<IEnumerable<ResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ResponseDto> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
        Task<ResponseDto> CreateAsync(RequestDto entityDto, CancellationToken cancellationToken = default);
        Task<ResponseDto> UpdateAsync(TKey id, RequestDto entityDto, CancellationToken cancellationToken = default);
        Task<ResponseDto> DeleteAsync(TKey id, CancellationToken cancellationToken = default);
    }

}
