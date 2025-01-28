using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Item;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Item
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCategoryToStaffCategoryController :
        CSIControllerBase<ItemCategoryToStaffCategoryDto,
            ItemCategoryToStaffCategoryResponseDto, long,
            ItemCategoryToStaffCategory>
    {
        public ItemCategoryToStaffCategoryController(IService<ItemCategoryToStaffCategoryDto,
            ItemCategoryToStaffCategoryResponseDto, long, ItemCategoryToStaffCategory> serviceProvider,
            IAdditionalFeatures<ItemCategoryToStaffCategoryDto,
                ItemCategoryToStaffCategoryResponseDto, long, ItemCategoryToStaffCategory> additionalFeatures) : base(serviceProvider, additionalFeatures)
        {
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve all ItemCategoryToStaffCategory records", Description = "Returns all ItemCategoryToStaffCategory records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<ItemCategoryToStaffCategoryResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public override async Task<Response<IEnumerable<ItemCategoryToStaffCategoryResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        [HttpGet("{id:long}")]
        [SwaggerOperation(Summary = "Retrieve a ItemCategoryToStaffCategory by ID", Description = "Fetches a specific ItemCategoryToStaffCategory record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<ItemCategoryToStaffCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<ItemCategoryToStaffCategoryResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.GetByIdAsync(id, cancellationToken);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new ItemCategoryToStaffCategory record", Description = "Adds a new ItemCategoryToStaffCategory record to the system.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<ItemCategoryToStaffCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<ItemCategoryToStaffCategoryResponseDto>> CreateAsync([FromBody] ItemCategoryToStaffCategoryDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.CreateAsync(entityDto, cancellationToken);
        }

        [HttpPut("{id:long}")]
        [SwaggerOperation(Summary = "Update an existing ItemCategoryToStaffCategory record", Description = "Updates an existing ItemCategoryToStaffCategory record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<ItemCategoryToStaffCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<ItemCategoryToStaffCategoryResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] ItemCategoryToStaffCategoryDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.UpdateAsync(id, entityDto, cancellationToken);
        }

        [HttpDelete("{id:long}")]
        [SwaggerOperation(Summary = "Delete a ItemCategoryToStaffCategory record", Description = "Deletes a ItemCategoryToStaffCategory record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<ItemCategoryToStaffCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
        public override async Task<Response<ItemCategoryToStaffCategoryResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.DeleteAsync(id, cancellationToken);
        }

        [HttpDelete("bulk")]
        [SwaggerOperation(Summary = "Bulk delete ItemCategoryToStaffCategory records", Description = "Deletes multiple ItemCategoryToStaffCategory records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<ItemCategoryToStaffCategoryDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkDeleteAsync(entities, cancellationToken);
        }

        [HttpPut("bulk")]
        [SwaggerOperation(Summary = "Bulk update ItemCategoryToStaffCategory records", Description = "Updates multiple ItemCategoryToStaffCategory records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<ItemCategoryToStaffCategoryDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkUpdateAsync(entities, cancellationToken);
        }

        [HttpPost("bulk")]
        [SwaggerOperation(Summary = "Bulk add ItemCategoryToStaffCategory records", Description = "Adds multiple ItemCategoryToStaffCategory records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<ItemCategoryToStaffCategoryDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkAddAsync(entities, cancellationToken);
        }

        [HttpPatch("soft-delete/{id:long}")]
        [SwaggerOperation(Summary = "Soft delete a ItemCategoryToStaffCategory record", Description = "Marks a ItemCategoryToStaffCategory record as deleted without removing it from the database.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<TaskItemResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<ItemCategoryToStaffCategoryResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.SoftDeleteAsync(id, cancellationToken);
        }
    }
}