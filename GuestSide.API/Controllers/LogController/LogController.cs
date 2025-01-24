using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Request.LogModel;
using GuestSide.Application.DTOs.Response.LogModel;
using GuestSide.Core.Entities.LogEntities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.LogController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : CSIControllerBase<LogDto, LogResponseDto, long, Logs>
    {
        public LogController(
            IService<LogDto, LogResponseDto, long, Logs> serviceProvider,
            IAdditionalFeatures<LogDto, LogResponseDto, long, Logs> additionalFeatures)
            : base(serviceProvider, additionalFeatures)
        {
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve all Logs", Description = "Returns all log records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<LogResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public override async Task<Response<IEnumerable<LogResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        [HttpGet("{id:long}")]
        [SwaggerOperation(Summary = "Retrieve a Log by ID", Description = "Fetches a specific log record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<LogResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<LogResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.GetByIdAsync(id, cancellationToken);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new Log", Description = "Adds a new log record to the system.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<LogResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<LogResponseDto>> CreateAsync([FromBody] LogDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.CreateAsync(entityDto, cancellationToken);
        }

        [HttpPut("{id:long}")]
        [SwaggerOperation(Summary = "Update an existing Log", Description = "Updates an existing log record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<LogResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<LogResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] LogDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.UpdateAsync(id, entityDto, cancellationToken);
        }

        [HttpDelete("{id:long}")]
        [SwaggerOperation(Summary = "Delete a Log", Description = "Deletes a log record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<LogResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
        public override async Task<Response<LogResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.DeleteAsync(id, cancellationToken);
        }

        [HttpDelete("bulk")]
        [SwaggerOperation(Summary = "Bulk delete Logs", Description = "Deletes multiple log records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<LogDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkDeleteAsync(entities, cancellationToken);
        }

        [HttpPut("bulk")]
        [SwaggerOperation(Summary = "Bulk update Logs", Description = "Updates multiple log records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<LogDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkUpdateAsync(entities, cancellationToken);
        }

        [HttpPost("bulk")]
        [SwaggerOperation(Summary = "Bulk add Logs", Description = "Adds multiple log records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<LogDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkAddAsync(entities, cancellationToken);
        }

        [HttpPatch("soft-delete/{id:long}")]
        [SwaggerOperation(Summary = "Soft delete a Log", Description = "Marks a log record as deleted without removing it from the database.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<LogResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<LogResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.SoftDeleteAsync(id, cancellationToken);
        }
    }
}
