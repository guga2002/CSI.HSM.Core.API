using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Log;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.LogEntities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.LogController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : CSIControllerBase<LogDto, long, Logs>
    {
        public LogController(IService<LogDto, long, Logs> service) : base(service) { }

        /// <summary>
        /// Retrieves all log records.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all log records.</returns>
        [HttpGet("GetLogs")]
        [SwaggerOperation(Summary = "Retrieve all log records", Description = "Returns a list of all log records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved log records.", typeof(Response<IEnumerable<LogDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No log records found.")]
        public override Task<Response<IEnumerable<LogDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a specific log record by its ID.
        /// </summary>
        /// <param name="id">The ID of the log record.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The log record matching the specified ID.</returns>
        [HttpGet("GetLogById/{id}")]
        [SwaggerOperation(Summary = "Retrieve log record by ID", Description = "Returns a specific log record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the log record.", typeof(Response<LogDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Log record not found.")]
        public override Task<Response<LogDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Creates a new log record.
        /// </summary>
        /// <param name="entityDto">The log record to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created log record.</returns>
        [HttpPost("CreateLog")]
        [SwaggerOperation(Summary = "Create a new log record", Description = "Creates a new log record.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Log record created successfully.", typeof(Response<LogDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<LogDto>> CreateAsync([FromBody] LogDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(entityDto, cancellationToken);
        }

        /// <summary>
        /// Updates an existing log record.
        /// </summary>
        /// <param name="id">The ID of the log record to update.</param>
        /// <param name="entityDto">The updated log record data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated log record.</returns>
        [HttpPut("UpdateLog/{id}")]
        [SwaggerOperation(Summary = "Update an existing log record", Description = "Updates the log record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Log record updated successfully.", typeof(Response<LogDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<LogDto>> UpdateAsync([FromRoute] long id, [FromBody] LogDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, entityDto, cancellationToken);
        }

        /// <summary>
        /// Deletes a log record by its ID.
        /// </summary>
        /// <param name="id">The ID of the log record to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteLog/{id}")]
        [SwaggerOperation(Summary = "Delete a log record", Description = "Deletes the log record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Log record deleted successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Log record not found or failed to delete.")]
        public override Task<Response<bool>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        // Add more methods or features as needed.
    }
}
