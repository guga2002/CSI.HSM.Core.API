using AutoMapper;
using GuestSide.Application.CustomExceptions;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;
using Core.Application.ErrorSuccessKeys;
using Core.Core.Interfaces.AbstractInterface;
using Core.Application.Interface.GenericContracts;
using System.Linq.Expressions;
using Core.Application.CustomExceptions;

namespace GuestSide.Application.Services;

public abstract class GenericService<RequestDto, ResponseDto, TKey, TDatabaseEntity>
    (IMapper mapper, IGenericRepository<TDatabaseEntity> repository, 
    ILogger<GenericService<RequestDto, ResponseDto, TKey, TDatabaseEntity>> logger, 
    IAdditioalFeatures<TDatabaseEntity> additioalFeatures) 
    : IService<RequestDto,ResponseDto, TKey, TDatabaseEntity>,
    IAdditionalFeatures<RequestDto, ResponseDto, TKey, TDatabaseEntity>
    where TDatabaseEntity : class
{
    public async Task BulkAddAsync(IEnumerable<RequestDto> entities, CancellationToken cancellationToken = default)
    {
        var mappedEntity = mapper.Map<IEnumerable<TDatabaseEntity>>(entities);
        if (!mappedEntity.Any()) throw new MappingException();
        await additioalFeatures.BulkAddAsync(mappedEntity, cancellationToken);
    }

    public async Task BulkDeleteAsync(IEnumerable<RequestDto> entities, CancellationToken cancellationToken = default)
    {
        var mappedEntity = mapper.Map<IEnumerable<TDatabaseEntity>>(entities);
        if (!mappedEntity.Any()) throw new MappingException();
        await additioalFeatures.BulkDeleteAsync(mappedEntity, cancellationToken);
    }

    public async Task BulkUpdateAsync(IEnumerable<RequestDto> entities, CancellationToken cancellationToken = default)
    {
        var mappedEntity = mapper.Map<IEnumerable<TDatabaseEntity>>(entities);
        if (!mappedEntity.Any()) throw new MappingException();
        await additioalFeatures.BulkUpdateAsync(mappedEntity, cancellationToken);
    }

    public async Task<ResponseDto> CreateAsync(RequestDto entityDto, CancellationToken cancellationToken = default)
    {
        var mappedEntity = mapper.Map<TDatabaseEntity>(entityDto);
        var result = await repository.AddAsync(mappedEntity, cancellationToken);
        var MappedResponse = mapper.Map<ResponseDto>(result);
        return MappedResponse;
    }

    public async Task<ResponseDto> DeleteAsync(TKey id, CancellationToken cancellationToken = default)
    {
        if(id is null)
        {
            throw new ArgumentNullException(nameof(id));
        }
        var entity = await repository.GetByIdAsync(id, cancellationToken);
        if (entity is null)
        {
            throw new BusinessRuleViolationException(ErrorKeys.INVALID_INPUT);
        }
        var res=await repository.DeleteAsync(entity, cancellationToken);

        var mappedResponse=mapper.Map<ResponseDto>(res);
        return mappedResponse;
    }

    public async Task<IEnumerable<ResponseDto>> ExecuteRawSql<TResult>(string query, object[] parameters, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(query)) throw new ArgumentNullException(nameof(query));

        var result = await additioalFeatures.ExecuteRawSql<TDatabaseEntity>(query, parameters, cancellationToken);

        var mappedEntity = mapper.Map<IEnumerable<ResponseDto>>(result);
        if (!mappedEntity.Any()) throw new MappingException();
        return mappedEntity;
    }

    public async Task<bool> ExistsAsync(Expression<Func<RequestDto, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var mappedPredicate = mapper.Map<Expression<Func<TDatabaseEntity, bool>>>(predicate);
        return await additioalFeatures.ExistsAsync(mappedPredicate, cancellationToken); 
    }

    public async Task<IEnumerable<ResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(cancellationToken);
        return mapper.Map<IEnumerable<ResponseDto>>(entities);
    }

    public async Task<ResponseDto> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        if (id is null)
        {
            throw new ArgumentNullException(nameof(id));
        }
        var entity = await repository.GetByIdAsync(id, cancellationToken);
        if (entity is null)
        {
            throw new BusinessRuleViolationException(ErrorKeys.ACCESS_DENIED);
        }
        return mapper.Map<ResponseDto>(entity);
    }

    public async Task<(IEnumerable<ResponseDto>, int)> GetPagedAsync(Expression<Func<TDatabaseEntity, bool>> predicate, int pageNumber, int pageSize, Expression<Func<TDatabaseEntity, object>> orderBy, bool isAscending = true, CancellationToken cancellationToken = default)
    {
        var result = await additioalFeatures.GetPagedAsync(predicate, pageNumber, pageSize, orderBy, isAscending, cancellationToken);

        if (result.Item1 == null || !result.Item1.Any())
        {
            return (Enumerable.Empty<ResponseDto>(), 0); 
        }

        var mapped = mapper.Map<IEnumerable<ResponseDto>>(result.Item1);

        return (mapped, result.Item2);
    }

    public async Task<ResponseDto> SoftDelete(TKey id, CancellationToken cancellationToken = default)
    {
        if (id is null) throw new ArgumentNullException(nameof(id));
        var result = await additioalFeatures.SoftDelete(id, cancellationToken);

        if(result is null) throw new BusinessRuleViolationException(ErrorKeys.ACCESS_DENIED);
        return mapper.Map<ResponseDto>(result) ?? throw new MappingException();
    }

    public async Task<ResponseDto> UpdateAsync(TKey id, RequestDto entityDto, CancellationToken cancellationToken = default)
    {
        if (id is null)
        {
            throw new ArgumentNullException(nameof(id));
        }
        var existingEntity = await repository.GetByIdAsync(id, cancellationToken);
        if (existingEntity is null)
        {
            throw new BusinessRuleViolationException(ErrorKeys.ACCESS_DENIED);
        }
        var mappedEntity = mapper.Map<TDatabaseEntity>(existingEntity);
        var responseFromUpdate= await repository.UpdateAsync(mappedEntity, cancellationToken);
        var mappedResponse = mapper.Map<ResponseDto>(responseFromUpdate);
        return mappedResponse;
    }
}
