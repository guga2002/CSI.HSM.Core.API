using AutoMapper;
using GuestSide.Application.CustomExceptions;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;
using Core.Application.ErrorSuccessKeys;
using Core.Core.Interfaces.AbstractInterface;
using Core.Application.Interface.GenericContracts;
using System.Linq.Expressions;

namespace GuestSide.Application.Services
{
    public abstract class GenericService<RequestDto, ResponseDto, TKey, TDatabaseEntity> :IService<RequestDto,ResponseDto, TKey, TDatabaseEntity>, IAdditionalFeatures<RequestDto, ResponseDto, TKey, TDatabaseEntity>
        where TDatabaseEntity : class
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<TDatabaseEntity> _repository;
        private readonly IAdditioalFeatures<TDatabaseEntity> _additioalFeatures;
        private readonly ILogger<GenericService<RequestDto, ResponseDto, TKey, TDatabaseEntity>> _logger;

        public GenericService(IMapper mapper, IGenericRepository<TDatabaseEntity> repository, ILogger<GenericService<RequestDto, ResponseDto, TKey, TDatabaseEntity>> logger, IAdditioalFeatures<TDatabaseEntity> additioalFeatures)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
            _additioalFeatures = additioalFeatures;
        }

        public Task BulkAddAsync(IEnumerable<RequestDto> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task BulkDeleteAsync(IEnumerable<RequestDto> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task BulkUpdateAsync(IEnumerable<RequestDto> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> CreateAsync(RequestDto entityDto, CancellationToken cancellationToken = default)
        {
            var mappedEntity = _mapper.Map<TDatabaseEntity>(entityDto);
            var result = await _repository.AddAsync(mappedEntity, cancellationToken);
            var MappedResponse = _mapper.Map<ResponseDto>(result);
            return MappedResponse;
        }

        public async Task<ResponseDto> DeleteAsync(TKey id, CancellationToken cancellationToken = default)
        {
            if(id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var entity = await _repository.GetByIdAsync(id, cancellationToken);
            if (entity is null)
            {
                throw new BusinessRuleViolationException(ErrorKeys.INVALID_INPUT);
            }
            var res=await _repository.DeleteAsync(entity, cancellationToken);

            var mappedResponse=_mapper.Map<ResponseDto>(res);
            return mappedResponse;
        }

        public Task<IEnumerable<ResponseDto>> ExecuteRawSql<TResult>(string query, object[] parameters, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Expression<Func<RequestDto, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = await _repository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<ResponseDto>>(entities);
        }

        public async Task<ResponseDto> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var entity = await _repository.GetByIdAsync(id, cancellationToken);
            if (entity is null)
            {
                throw new BusinessRuleViolationException(ErrorKeys.ACCESS_DENIED);
            }
            return _mapper.Map<ResponseDto>(entity);
        }

        public Task<(IEnumerable<ResponseDto>, int)> GetPagedAsync(Expression<Func<TDatabaseEntity, bool>> predicate, int pageNumber, int pageSize, Expression<Func<TDatabaseEntity, object>> orderBy, bool isAscending = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> SoftDelete(TKey id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> UpdateAsync(TKey id, RequestDto entityDto, CancellationToken cancellationToken = default)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var existingEntity = await _repository.GetByIdAsync(id, cancellationToken);
            if (existingEntity is null)
            {
                throw new BusinessRuleViolationException(ErrorKeys.ACCESS_DENIED);
            }
            var mappedEntity = _mapper.Map<TDatabaseEntity>(existingEntity);
            var responseFromUpdate= await _repository.UpdateAsync(mappedEntity, cancellationToken);
            var mappedResponse = _mapper.Map<ResponseDto>(responseFromUpdate);
            return mappedResponse;
        }
    }
}
