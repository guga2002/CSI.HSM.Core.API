using GuestSide.API.Response;
using GuestSide.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.CustomExtendControllerBase
{
    [ApiController]
    [Route("api/[controller]")]
    public class CSIControllerBase<TModel, TKey, TDatabase> : ControllerBase
    {
        private readonly IService<TModel, TKey, TDatabase> _serviceProvider;

        public CSIControllerBase(IService<TModel, TKey, TDatabase> serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<Response<IEnumerable<TModel>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _serviceProvider.GetAllAsync(cancellationToken);
            if (result.Any())
            {
                return Response<IEnumerable<TModel>>.SuccessResponse(result);
            }
            return Response<IEnumerable<TModel>>.ErrorResponse("No records found.");
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<Response<TModel>> GetByIdAsync([FromRoute] TKey id, CancellationToken cancellationToken = default)
        {
            var result = await _serviceProvider.GetByIdAsync(id, cancellationToken);
            if (result != null)
            {
                return Response<TModel>.SuccessResponse(result);
            }
            return Response<TModel>.ErrorResponse("Record not found.", 404);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<Response<TModel>> CreateAsync([FromBody] TModel entityDto, CancellationToken cancellationToken = default)
        {
           

            if (entityDto == null)
            {
                return Response<TModel>.ErrorResponse("Invalid input data.", 400);
            }

            var isCreated = await _serviceProvider.CreateAsync(entityDto, cancellationToken);
            if (isCreated)
            {
                return Response<TModel>.SuccessResponse(entityDto, "Record created successfully.");
            }
            return Response<TModel>.ErrorResponse("Failed to create the record.");
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<Response<TModel>> UpdateAsync([FromRoute]TKey id, [FromBody] TModel entityDto, CancellationToken cancellationToken = default)
        {

            if (entityDto == null)
            {
                return Response<TModel>.ErrorResponse("Invalid input data.", 400);
            }

            var isUpdated = await _serviceProvider.UpdateAsync(id, entityDto, cancellationToken);
            if (isUpdated)
            {
                return Response<TModel>.SuccessResponse(entityDto, "Record updated successfully.");
            }
            return Response<TModel>.ErrorResponse("Failed to update the record.");
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<Response<bool>> DeleteAsync([FromRoute]TKey id, CancellationToken cancellationToken = default)
        {
            var isDeleted = await _serviceProvider.DeleteAsync(id, cancellationToken);
            if (isDeleted)
            {
                return Response<bool>.SuccessResponse(true, "Record deleted successfully.");
            }
            return Response<bool>.ErrorResponse("Failed to delete the record or record not found.", 404);
        }
    }
}
