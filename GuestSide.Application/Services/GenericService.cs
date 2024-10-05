using AutoMapper;
using GuestSide.Application.CustomExceptions;
using GuestSide.Application.Interface;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services
{
    public class GenericService<TModel, TKey, TDatabaseEntity> : IService<TModel, TKey, TDatabaseEntity>
        where TDatabaseEntity : class
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<TDatabaseEntity> _repository;
        private readonly ILogger<GenericService<TModel, TKey, TDatabaseEntity>> _logger;

        public GenericService(IMapper mapper, IGenericRepository<TDatabaseEntity> repository, ILogger<GenericService<TModel, TKey, TDatabaseEntity>> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(TModel entityDto, CancellationToken cancellationToken = default)
        {
            var mappedEntity = _mapper.Map<TDatabaseEntity>(entityDto);
            var result = await _repository.AddAsync(mappedEntity, cancellationToken);
            return result;
        }

        public async Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.GetByIdAsync(id, cancellationToken);
            if (entity == null)
            {
                throw new BusinessRuleViolationException(ErrorSuccessKeys.ErrorKeys.INVALID_INPUT);
            }
            return await _repository.DeleteAsync(entity, cancellationToken);
        }

        public async Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = await _repository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<TModel>>(entities);
        }

        public async Task<TModel> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.GetByIdAsync(id, cancellationToken);
            if (entity == null)
            {
                throw new BusinessRuleViolationException(ErrorSuccessKeys.ErrorKeys.ACCESS_DENIED);
            }
            return _mapper.Map<TModel>(entity);
        }

        public async Task<bool> UpdateAsync(TKey id, TModel entityDto, CancellationToken cancellationToken = default)
        {
            var existingEntity = await _repository.GetByIdAsync(id, cancellationToken);
            if (existingEntity == null)
            {
                throw new BusinessRuleViolationException(ErrorSuccessKeys.ErrorKeys.ACCESS_DENIED);
            }
            var mappedEntity = _mapper.Map(entityDto, existingEntity);
            return await _repository.UpdateAsync(mappedEntity, cancellationToken);
        }
    }
}
