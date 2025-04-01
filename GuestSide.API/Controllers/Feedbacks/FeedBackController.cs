using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.FeedBacks;
using Core.Application.DTOs.Response.FeedBacks;
using Core.Application.Interface.FeedBack;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.FeedBacks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Feedbacks;

[ApiController]
[Route("api/[controller]")]
public class FeedBackController : CSIControllerBase<FeedbackDto, FeedbackResponseDto, long, Feedback>
{
    private readonly IFeadbackService _feedbackService;
    public FeedBackController(
        IService<FeedbackDto, FeedbackResponseDto, long, Feedback> serviceProvider,
        IAdditionalFeatures<FeedbackDto, FeedbackResponseDto, long, Feedback> additionalFeatures,
        IFeadbackService feedbackService)
        : base(serviceProvider, additionalFeatures)
    {
        _feedbackService = feedbackService;
    }

    [HttpGet("GuestFeedbacks/{guestId:long}")]
    [SwaggerOperation(Summary = "Get feedbacks by guest ID", Description = "Retrieves feedbacks associated with a specific Guest ID.")]
    [ProducesResponseType(typeof(Response<IEnumerable<FeedbackResponseDto>>), StatusCodes.Status200OK)]
    public async Task<Response<IEnumerable<FeedbackResponseDto>>> GuestFeedbacks([FromRoute] long guestId, CancellationToken cancellationToken = default)
    {
        var result = await _feedbackService.GetFeedbacksByUserId(guestId);
        return new Response<IEnumerable<FeedbackResponseDto>>(result.Any() ? true : false, result);
    }

    [HttpGet("task/{taskId:long}")]
    [SwaggerOperation(Summary = "Get feedbacks by task ID", Description = "Retrieves feedbacks associated with a specific task ID.")]
    [ProducesResponseType(typeof(Response<IEnumerable<FeedbackResponseDto>>), StatusCodes.Status200OK)]
    public async Task<Response<IEnumerable<FeedbackResponseDto>>> GetFeedbacksByTaskIdAsync([FromRoute] long taskId, CancellationToken cancellationToken = default)
    {
        var result = await _feedbackService.GetFeedbacksByTaskIdAsync(taskId, cancellationToken);
        return new Response<IEnumerable<FeedbackResponseDto>>(result.Any() ? true : false, result);
    }

    [HttpGet("rating-range")]
    [SwaggerOperation(Summary = "Get feedbacks by rating range", Description = "Retrieves feedbacks within the specified rating range.")]
    [ProducesResponseType(typeof(Response<IEnumerable<FeedbackResponseDto>>), StatusCodes.Status200OK)]
    public async Task<Response<IEnumerable<FeedbackResponseDto>>> GetFeedbacksByRatingAsync([FromQuery] int minRating, [FromQuery] int maxRating, CancellationToken cancellationToken = default)
    {
        var result = await _feedbackService.GetFeedbacksByRatingAsync(minRating, maxRating, cancellationToken);
        return new Response<IEnumerable<FeedbackResponseDto>>(result.Any() ? true : false, result);
    }

    [HttpGet("date-range")]
    [SwaggerOperation(Summary = "Get feedbacks within a specific date range", Description = "Retrieves feedbacks created within the specified date range.")]
    [ProducesResponseType(typeof(Response<IEnumerable<FeedbackResponseDto>>), StatusCodes.Status200OK)]
    public async Task<Response<IEnumerable<FeedbackResponseDto>>> GetFeedbacksByDateRangeAsync([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, CancellationToken cancellationToken = default)
    {
        var result = await _feedbackService.GetFeedbacksByDateRangeAsync(startDate, endDate, cancellationToken);
        return new Response<IEnumerable<FeedbackResponseDto>>(result.Any() ? true : false, result);
    }

    [HttpGet("language/{languageCode}")]
    [SwaggerOperation(Summary = "Get feedbacks by language", Description = "Retrieves feedbacks filtered by a specific language code.")]
    [ProducesResponseType(typeof(Response<IEnumerable<FeedbackResponseDto>>), StatusCodes.Status200OK)]
    public async Task<Response<IEnumerable<FeedbackResponseDto>>> GetFeedbacksByLanguageAsync([FromRoute] string languageCode, CancellationToken cancellationToken = default)
    {
        var result = await _feedbackService.GetFeedbacksByLanguageAsync(languageCode, cancellationToken);
        return new Response<IEnumerable<FeedbackResponseDto>>(result.Any() ? true : false, result);
    }

    [HttpGet("correlation/{correlationId}")]
    [SwaggerOperation(Summary = "Get feedback by correlation ID", Description = "Fetches a feedback using its unique correlation ID.")]
    [ProducesResponseType(typeof(Response<FeedbackResponseDto>), StatusCodes.Status200OK)]
    public async Task<Response<FeedbackResponseDto?>> GetFeedbackByCorrelationIdAsync([FromRoute] Guid correlationId, CancellationToken cancellationToken = default)
    {
        var result = await _feedbackService.GetFeedbackByCorrelationIdAsync(correlationId, cancellationToken);
        return new Response<FeedbackResponseDto?>(result is not null ? true : false, result);
    }

    [HttpPut("update-rating/{correlationId}")]
    [SwaggerOperation(Summary = "Update feedback rating", Description = "Updates the rating of a feedback by its correlation ID.")]
    [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
    public async Task<Response<bool>> UpdateFeedbackRatingAsync([FromRoute] Guid correlationId, [FromBody] int newRating, CancellationToken cancellationToken = default)
    {
        var result = await _feedbackService.UpdateFeedbackRatingAsync(correlationId, newRating, cancellationToken);
        return new Response<bool>(result ? true : false, result);
    }

    [HttpDelete("delete/{correlationId}")]
    [SwaggerOperation(Summary = "Delete feedback by correlation ID", Description = "Deletes a feedback record by its unique correlation ID.")]
    [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
    public async Task<Response<bool>> DeleteFeedbackByCorrelationIdAsync([FromRoute] Guid correlationId, CancellationToken cancellationToken = default)
    {
        var result = await _feedbackService.DeleteFeedbackByCorrelationIdAsync(correlationId, cancellationToken);
        return new Response<bool>(result ? true : false, result);
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all Feedbacks", Description = "Returns all feedback records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<FeedbackResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public override async Task<Response<IEnumerable<FeedbackResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:long}")]
    [SwaggerOperation(Summary = "Retrieve a Feedback by ID", Description = "Fetches a specific feedback record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<FeedbackResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<FeedbackResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Feedback", Description = "Adds a new feedback record to the system.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<FeedbackResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<FeedbackResponseDto>> CreateAsync([FromBody] FeedbackDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(entityDto, cancellationToken);
    }

    [HttpPut("{id:long}")]
    [SwaggerOperation(Summary = "Update an existing Feedback", Description = "Updates an existing feedback record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<FeedbackResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<FeedbackResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] FeedbackDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(id, entityDto, cancellationToken);
    }

    [HttpDelete("{id:long}")]
    [SwaggerOperation(Summary = "Delete a Feedback", Description = "Deletes a feedback record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<FeedbackResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<FeedbackResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(id, cancellationToken);
    }

    [HttpDelete("bulk")]
    [SwaggerOperation(Summary = "Bulk delete Feedbacks", Description = "Deletes multiple feedback records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<FeedbackDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkDeleteAsync(entities, cancellationToken);
    }

    [HttpPut("bulk")]
    [SwaggerOperation(Summary = "Bulk update Feedbacks", Description = "Updates multiple feedback records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<FeedbackDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkUpdateAsync(entities, cancellationToken);
    }

    [HttpPost("bulk")]
    [SwaggerOperation(Summary = "Bulk add Feedbacks", Description = "Adds multiple feedback records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<FeedbackDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkAddAsync(entities, cancellationToken);
    }

    [HttpPatch("soft-delete/{id:long}")]
    [SwaggerOperation(Summary = "Soft delete a Feedback", Description = "Marks a feedback record as deleted without removing it from the database.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<FeedbackResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<FeedbackResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.SoftDeleteAsync(id, cancellationToken);
    }
}
