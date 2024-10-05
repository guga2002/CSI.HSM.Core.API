using AutoMapper;
using GuestSide.Application.CustomExceptions;
using GuestSide.Application.Interface;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services
{
    public class GenericService<Tmodel, Key, DatabaseEntity> : IService<Tmodel, Key, DatabaseEntity>
        where DatabaseEntity : class
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<DatabaseEntity> _repository;
        private readonly ILogger<GenericService<Tmodel, Key, DatabaseEntity>> _logger;

        public GenericService(IMapper mapper, IGenericRepository<DatabaseEntity> repository, ILogger<GenericService<Tmodel, Key, DatabaseEntity>> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(Tmodel entityDto)
        {
            var mapped = _mapper.Map<DatabaseEntity>(entityDto);
            if (mapped is not null)
            {
                var result = await _repository.AddAsync(mapped);
                return result;
            }
            throw new BusinessRuleViolationException(ErrorSuccessKeys.ErrorKeys.INVALID_FORMAT);
        }

        public async Task<bool> DeleteAsync(Key id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new BusinessRuleViolationException(ErrorSuccessKeys.ErrorKeys.INVALID_INPUT);
            }
            return await _repository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Tmodel>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<Tmodel>>(entities);
        }

        public async Task<Tmodel> GetByIdAsync(Key id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new BusinessRuleViolationException(ErrorSuccessKeys.ErrorKeys.ACCESS_DENIED);
            }
            return _mapper.Map<Tmodel>(entity);
        }

        public async Task<bool> UpdateAsync(Key id, Tmodel entityDto)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null)
            {
                throw new BusinessRuleViolationException(ErrorSuccessKeys.ErrorKeys.ACCESS_DENIED);
            }
            var mappedEntity = _mapper.Map(entityDto, existingEntity);
            return await _repository.UpdateAsync(mappedEntity);
        }
    }
}
