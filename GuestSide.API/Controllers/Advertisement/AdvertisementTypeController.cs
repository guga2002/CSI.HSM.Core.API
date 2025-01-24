using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Request.Advertisment;
using GuestSide.Application.DTOs.Response.Advertisment;
using GuestSide.Core.Entities.Advertisments;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Advertisement
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdvertisemenetTypeController : CSIControllerBase<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, AdvertisementType>
    {
        public AdvertisemenetTypeController(
            IService<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, AdvertisementType> serviceProvider,
            IAdditionalFeatures<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, AdvertisementType> additionalFeatures)
            : base(serviceProvider, additionalFeatures)
        {
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve all Advertisement Types", Description = "Returns all advertisement type records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<AdvertisementTypeResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public override async Task<Response<IEnumerable<AdvertisementTypeResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        [HttpGet("{id:long}")]
        [SwaggerOperation(Summary = "Retrieve an Advertisement Type by ID", Description = "Fetches a specific advertisement type record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<AdvertisementTypeResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<AdvertisementTypeResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.GetByIdAsync(id, cancellationToken);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new Advertisement Type", Description = "Adds a new advertisement type record to the system.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<AdvertisementTypeResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<AdvertisementTypeResponseDto>> CreateAsync([FromBody] AdvertisementTypeDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.CreateAsync(entityDto, cancellationToken);
        }

        [HttpPut("{id:long}")]
        [SwaggerOperation(Summary = "Update an existing Advertisement Type", Description = "Updates an existing advertisement type record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<AdvertisementTypeResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<AdvertisementTypeResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] AdvertisementTypeDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.UpdateAsync(id, entityDto, cancellationToken);
        }

        [HttpDelete("{id:long}")]
        [SwaggerOperation(Summary = "Delete an Advertisement Type", Description = "Deletes an advertisement type record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<AdvertisementTypeResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<AdvertisementTypeResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.DeleteAsync(id, cancellationToken);
        }

        [HttpDelete("bulk")]
        [SwaggerOperation(Summary = "Bulk delete Advertisement Types", Description = "Deletes multiple advertisement type records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<AdvertisementTypeDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkDeleteAsync(entities, cancellationToken);
        }

        [HttpPut("bulk")]
        [SwaggerOperation(Summary = "Bulk update Advertisement Types", Description = "Updates multiple advertisement type records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<AdvertisementTypeDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkUpdateAsync(entities, cancellationToken);
        }

        [HttpPost("bulk")]
        [SwaggerOperation(Summary = "Bulk add Advertisement Types", Description = "Adds multiple advertisement type records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<AdvertisementTypeDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkAddAsync(entities, cancellationToken);
        }

        [HttpPatch("soft-delete/{id:long}")]
        [SwaggerOperation(Summary = "Soft delete an Advertisement Type", Description = "Marks an advertisement type record as deleted without removing it from the database.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<AdvertisementTypeResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<AdvertisementTypeResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.SoftDeleteAsync(id, cancellationToken);
        }
    }
}
