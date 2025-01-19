using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Request.FeedBacks;
using GuestSide.Application.DTOs.Response.FeedBacks;
using GuestSide.Core.Entities.Feedbacks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Feadbacks
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : CSIControllerBase<FeedbackDto,FeedbackResponseDto, long, Feedback>
    {
        public FeedBackController(IService<FeedbackDto,FeedbackResponseDto, long, Feedback> serviceProvider) : base(serviceProvider)
        {
        }

        /// <summary>
        /// Retrieves all feedback records.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all feedback records.</returns>
        [HttpGet("GetFeedbacks")]
        [SwaggerOperation(Summary = "Retrieve all feedback records", Description = "Returns a list of all feedback records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved feedback records.", typeof(Response<IEnumerable<FeedbackResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No feedback records found.")]
        public override Task<Response<IEnumerable<FeedbackResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a specific feedback record by its ID.
        /// </summary>
        /// <param name="id">The ID of the feedback record.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The feedback record matching the specified ID.</returns>
        [HttpGet("GetFeedbackById/{id}")]
        [SwaggerOperation(Summary = "Retrieve feedback record by ID", Description = "Returns a specific feedback record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the feedback record.", typeof(Response<FeedbackResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Feedback record not found.")]
        public override Task<Response<FeedbackResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Creates a new feedback record.
        /// </summary>
        /// <param name="entityDto">The feedback record to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created feedback record.</returns>
        [HttpPost("CreateFeedback")]
        [SwaggerOperation(Summary = "Create a new feedback record", Description = "Creates a new feedback record.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Feedback record created successfully.", typeof(Response<FeedbackResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<FeedbackResponseDto>> CreateAsync([FromBody] FeedbackDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(entityDto, cancellationToken);
        }

        /// <summary>
        /// Updates an existing feedback record.
        /// </summary>
        /// <param name="id">The ID of the feedback record to update.</param>
        /// <param name="entityDto">The updated feedback record data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated feedback record.</returns>
        [HttpPut("UpdateFeedback/{id}")]
        [SwaggerOperation(Summary = "Update an existing feedback record", Description = "Updates the feedback record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Feedback record updated successfully.", typeof(Response<FeedbackResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<FeedbackResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] FeedbackDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, entityDto, cancellationToken);
        }

        /// <summary>
        /// Deletes a feedback record by its ID.
        /// </summary>
        /// <param name="id">The ID of the feedback record to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteFeedback/{id}")]
        [SwaggerOperation(Summary = "Delete a feedback record", Description = "Deletes the feedback record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Feedback record deleted successfully.", typeof(Response<FeedbackResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Feedback record not found or failed to delete.")]
        public override Task<Response<FeedbackResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }
    }
}
