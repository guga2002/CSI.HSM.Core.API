using AutoMapper;
using Microsoft.Extensions.Logging;
using Core.Application.ErrorSuccessKeys;
using Core.Core.Interfaces.AbstractInterface;
using Core.Application.Interface.GenericContracts;
using System.Linq.Expressions;
using Core.Application.CustomExceptions;
using InvalidOperationException = Core.Application.CustomExceptions.InvalidOperationException;

namespace Core.Application.Services;

public abstract class GenericService<RequestDto, ResponseDto, TKey, TDatabaseEntity>
    (IMapper mapper, IGenericRepository<TDatabaseEntity> repository,
    ILogger<GenericService<RequestDto, ResponseDto, TKey, TDatabaseEntity>> logger,
    IAdditionalFeaturesRepository<TDatabaseEntity> additioalFeatures)
    : IService<RequestDto, ResponseDto, TKey, TDatabaseEntity>,
    IAdditionalFeatures<RequestDto, ResponseDto, TKey, TDatabaseEntity>
    where TDatabaseEntity : class
{
    private void LogException(Exception ex, string message)
    {
        logger.LogError(ex, message);
    }

    private void LogOperation(string message, params object[] args)
    {
        logger.LogInformation(message, args);
    }

    private void ValidateNotNull<T>(T value, string parameterName)
    {
        if (value == null)
        {
            logger.LogWarning("{ParameterName} cannot be null.", parameterName);
            throw new ArgumentNullException(parameterName);
        }
    }

    private void ValidateCollection<T>(IEnumerable<T> collection, string parameterName)
    {
        if (collection == null || !collection.Any())
        {
            logger.LogWarning("{ParameterName} collection is null or empty.", parameterName);
            throw new ArgumentException($"{parameterName} collection cannot be null or empty.", parameterName);
        }
    }

    public async System.Threading.Tasks.Task BulkAddAsync(IEnumerable<RequestDto> entities, CancellationToken cancellationToken = default)
    {
        LogOperation("Starting bulk add operation.");

        try
        {
            ValidateCollection(entities, nameof(entities));

            var mappedEntities = mapper.Map<IEnumerable<TDatabaseEntity>>(entities);
            if (!mappedEntities.Any())
            {
                throw new MappingException("Bulk add mapping failed.");
            }

            await additioalFeatures.BulkAddAsync(mappedEntities, cancellationToken);
            LogOperation("Bulk add operation completed successfully.");
        }
        catch (Exception ex)
        {
            LogException(ex, "Error occurred during bulk add operation.");
            throw;
        }
    }

    public async System.Threading.Tasks.Task BulkDeleteAsync(IEnumerable<RequestDto> entities, CancellationToken cancellationToken = default)
    {
        LogOperation("Starting bulk delete operation.");

        try
        {
            ValidateCollection(entities, nameof(entities));

            var mappedEntities = mapper.Map<IEnumerable<TDatabaseEntity>>(entities);
            if (!mappedEntities.Any())
            {
                throw new MappingException("Bulk delete mapping failed.");
            }

            await additioalFeatures.BulkDeleteAsync(mappedEntities, cancellationToken);
            LogOperation("Bulk delete operation completed successfully.");
        }
        catch (Exception ex)
        {
            LogException(ex, "Error occurred during bulk delete operation.");
            throw;
        }
    }

    public async System.Threading.Tasks.Task BulkUpdateAsync(IEnumerable<RequestDto> entities, CancellationToken cancellationToken = default)
    {
        LogOperation("Starting bulk update operation.");

        try
        {
            ValidateCollection(entities, nameof(entities));

            var mappedEntities = mapper.Map<IEnumerable<TDatabaseEntity>>(entities);
            if (!mappedEntities.Any())
            {
                throw new MappingException("Bulk update mapping failed.");
            }

            await additioalFeatures.BulkUpdateAsync(mappedEntities, cancellationToken);
            LogOperation("Bulk update operation completed successfully.");
        }
        catch (Exception ex)
        {
            LogException(ex, "Error occurred during bulk update operation.");
            throw;
        }
    }

    public async Task<ResponseDto> CreateAsync(RequestDto entityDto, CancellationToken cancellationToken = default)
    {
        LogOperation("Starting create operation.");

        try
        {
            ValidateNotNull(entityDto, nameof(entityDto));

            var mappedEntity = mapper.Map<TDatabaseEntity>(entityDto);
            var result = await repository.AddAsync(mappedEntity, cancellationToken);

            if (result == null)
            {
                throw new Exception("Failed to create entity in the database.");
            }

            LogOperation("Create operation completed successfully.");
            return mapper.Map<ResponseDto>(result);
        }
        catch (Exception ex)
        {
            LogException(ex, "Error occurred during create operation.");
            throw;
        }
    }

    public async Task<ResponseDto> DeleteAsync(TKey id, CancellationToken cancellationToken = default)
    {
        LogOperation("Starting delete operation for ID {Id}.", id);

        try
        {
            ValidateNotNull(id, nameof(id));

            var entity = await repository.GetByIdAsync(id, cancellationToken);
            if (entity == null)
            {
                throw new BusinessRuleViolationException(ErrorKeys.INVALID_INPUT);
            }

            var result = await repository.DeleteAsync(entity, cancellationToken);
            LogOperation("Delete operation for ID {Id} completed successfully.", id);

            return mapper.Map<ResponseDto>(result);
        }
        catch (Exception ex)
        {
            LogException(ex, "Error occurred during delete operation.");
            throw;
        }
    }

    public async Task<ResponseDto> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        LogOperation("Fetching entity by ID {Id}.", id);

        try
        {
            ValidateNotNull(id, nameof(id));

            var entity = await repository.GetByIdAsync(id, cancellationToken);
            if (entity == null)
            {
                throw new BusinessRuleViolationException(ErrorKeys.ACCESS_DENIED);
            }

            LogOperation("Entity with ID {Id} fetched successfully.", id);
            return mapper.Map<ResponseDto>(entity);
        }
        catch (Exception ex)
        {
            LogException(ex, "Error occurred during GetById operation.");
            throw;
        }
    }

    public async Task<IEnumerable<ResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        LogOperation("Fetching all entities.");

        try
        {
            var entities = await repository.GetAllAsync(cancellationToken);
            if (entities == null || !entities.Any())
            {
                LogOperation("No entities found in the database.");
                return Enumerable.Empty<ResponseDto>();
            }

            LogOperation("Fetched {Count} entities from the database.", entities.Count());
            return mapper.Map<IEnumerable<ResponseDto>>(entities);
        }
        catch (Exception ex)
        {
            LogException(ex, "Error occurred during GetAll operation.");
            throw;
        }
    }

    public async Task<(IEnumerable<ResponseDto>, int)> GetPagedAsync(
        Expression<Func<TDatabaseEntity, bool>> predicate,
        int pageNumber, int pageSize,
        Expression<Func<TDatabaseEntity, object>> orderBy,
        bool isAscending = true, CancellationToken cancellationToken = default)
    {
        LogOperation("Starting paginated fetch operation.");

        try
        {
            var result = await additioalFeatures.GetPagedAsync(predicate, pageNumber, pageSize, orderBy, isAscending, cancellationToken);

            if (result.Item1 == null || !result.Item1.Any())
            {
                LogOperation("No entities found for the specified page.");
                return (Enumerable.Empty<ResponseDto>(), 0);
            }

            var mapped = mapper.Map<IEnumerable<ResponseDto>>(result.Item1);
            LogOperation("Fetched {Count} entities for page {PageNumber}.", mapped.Count(), pageNumber);
            return (mapped, result.Item2);
        }
        catch (Exception ex)
        {
            LogException(ex, "Error occurred during paginated fetch operation.");
            throw;
        }
    }

    public async Task<ResponseDto> UpdateAsync(TKey id, RequestDto entityDto, CancellationToken cancellationToken = default)
    {
        LogOperation("Starting update operation for ID {Id}.", id);

        try
        {
            // Validate inputs
            ValidateNotNull(id, nameof(id));
            ValidateNotNull(entityDto, nameof(entityDto));

            var mappedEntity = mapper.Map<TDatabaseEntity>(entityDto);
            if (mappedEntity == null)
            {
                throw new MappingException("Mapping from DTO to entity failed.");
            }

            var idProperty = typeof(TDatabaseEntity).GetProperty("Id");
            if (idProperty != null)
            {
                idProperty.SetValue(mappedEntity, id);
            }
            else
            {
                throw new InvalidOperationException("The entity does not have an 'Id' property.");
            }
            var updatedEntity = await repository.UpdateAsync(mappedEntity, cancellationToken);

            var response = mapper.Map<ResponseDto>(updatedEntity);
            LogOperation("Update operation for ID {Id} completed successfully.", id);
            return response;
        }
        catch (Exception ex)
        {
            LogException(ex, "Error occurred during update operation for ID {Id}.");
            throw;
        }
    }


    public async Task<IEnumerable<ResponseDto>> ExecuteRawSql<TResult>(string query, object[] parameters, CancellationToken cancellationToken = default)
    {
        LogOperation("Executing raw SQL query: {Query}", query);

        try
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("Query cannot be null or empty.", nameof(query));
            }

            var result = await additioalFeatures.ExecuteRawSql<TResult>(query, parameters, cancellationToken);

            if (result == null || !result.Any())
            {
                LogOperation("Raw SQL query returned no results.");
                return Enumerable.Empty<ResponseDto>();
            }

            var mappedResult = mapper.Map<IEnumerable<ResponseDto>>(result);

            LogOperation("Raw SQL query executed successfully.");
            return mappedResult;
        }
        catch (Exception ex)
        {
            LogException(ex, "Error occurred while executing raw SQL query.");
            throw;
        }
    }

    public async Task<ResponseDto> SoftDelete(TKey id, CancellationToken cancellationToken = default)
    {
        LogOperation("Starting soft delete operation for ID {Id}.", id);

        try
        {
            ValidateNotNull(id, nameof(id));

            var entity = await repository.GetByIdAsync(id, cancellationToken);
            if (entity == null)
            {
                throw new BusinessRuleViolationException($"Entity with ID {id} does not exist.");
            }

            var isDeletedProperty = typeof(TDatabaseEntity).GetProperty("IsActive");
            if (isDeletedProperty is not null)
            {
                isDeletedProperty.SetValue(entity, true);
            }
            else
            {
                throw new InvalidOperationException("The entity does not have an 'IsDeleted' property for soft delete.");
            }

            var updatedEntity = await repository.UpdateAsync(entity, cancellationToken);

            var response = mapper.Map<ResponseDto>(updatedEntity);

            LogOperation("Soft delete operation for ID {Id} completed successfully.", id);
            return response;
        }
        catch (Exception ex)
        {
            LogException(ex, "Error occurred during soft delete operation");
            throw;
        }
    }

    public async Task<bool> ExistsAsync(Expression<Func<RequestDto, bool>> predicate, CancellationToken cancellationToken = default)
    {
        LogOperation("Checking if a record exists based on the given predicate.");

        try
        {
            var mappedPredicate = mapper.Map<Expression<Func<TDatabaseEntity, bool>>>(predicate);

            if (mappedPredicate is null)
            {
                throw new MappingException("Failed to map predicate from RequestDto to TDatabaseEntity.");
            }

            var exists = await additioalFeatures.ExistsAsync(mappedPredicate, cancellationToken);

            LogOperation("Existence check completed. Result: {Exists}", exists);
            return exists;
        }
        catch (Exception ex)
        {
            LogException(ex, "Error occurred while checking existence.");
            throw;
        }
    }
}
