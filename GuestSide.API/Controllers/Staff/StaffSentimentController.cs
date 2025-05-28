using Common.Data.Entities.Staff;
using Core.API.CustomExtendControllerBase;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Item;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff.Sentiments;
using Generic.API.ResponseClass;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Staff;

[Route("api/[controller]")]
[ApiController]
public class StaffSentimentController : CSIControllerBase<StaffSentimentDto, StaffSentimentResponseDto, long, StaffSentiment>
{
    private readonly IStaffSentimentService _staffSentimentService;

    public StaffSentimentController(
        IStaffSentimentService staffSentimentService)
        : base(staffSentimentService, staffSentimentService)
    {
        _staffSentimentService = staffSentimentService;
    }

    /// <summary>
    /// Retrieve sentiment records for a specific staff member.
    /// </summary>
    [HttpGet("staff/{staffId:long}")]
    [SwaggerOperation(Summary = "Get Sentiments by Staff ID", Description = "Fetches all sentiment analysis records associated with a staff member.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Sentiments retrieved successfully.", typeof(Response<IEnumerable<StaffSentimentResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No sentiment records found.")]
    public async Task<Response<IEnumerable<StaffSentimentResponseDto>>> GetSentimentsByStaffIdAsync([FromRoute] long staffId, CancellationToken cancellationToken = default)
    {
        var sentiments = await _staffSentimentService.GetSentimentsByStaffIdAsync(staffId, cancellationToken);
        return sentiments.Any()
            ? Response<IEnumerable<StaffSentimentResponseDto>>.SuccessResponse(sentiments)
            : Response<IEnumerable<StaffSentimentResponseDto>>.ErrorResponse("No sentiment records found for the given staff ID.");
    }

    /// <summary>
    /// Retrieve sentiment records by label (e.g., "Positive", "Negative").
    /// </summary>
    [HttpGet("label/{label}")]
    [SwaggerOperation(Summary = "Get Sentiments by Label", Description = "Fetches all sentiment records filtered by a specific label.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Sentiments retrieved successfully.", typeof(Response<IEnumerable<StaffSentimentResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No sentiment records found.")]
    public async Task<Response<IEnumerable<StaffSentimentResponseDto>>> GetSentimentsByLabelAsync([FromRoute] string label, CancellationToken cancellationToken = default)
    {
        var sentiments = await _staffSentimentService.GetSentimentsByLabelAsync(label, cancellationToken);
        return sentiments.Any()
            ? Response<IEnumerable<StaffSentimentResponseDto>>.SuccessResponse(sentiments)
            : Response<IEnumerable<StaffSentimentResponseDto>>.ErrorResponse("No sentiment records found for the specified label.");
    }

    /// <summary>
    /// Retrieve sentiment records by emotion (e.g., "Happy", "Angry").
    /// </summary>
    [HttpGet("emotion/{emotion}")]
    [SwaggerOperation(Summary = "Get Sentiments by Emotion", Description = "Fetches all sentiment records filtered by a specific emotion.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Sentiments retrieved successfully.", typeof(Response<IEnumerable<StaffSentimentResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No sentiment records found.")]
    public async Task<Response<IEnumerable<StaffSentimentResponseDto>>> GetSentimentsByEmotionAsync([FromRoute] string emotion, CancellationToken cancellationToken = default)
    {
        var sentiments = await _staffSentimentService.GetSentimentsByEmotionAsync(emotion, cancellationToken);
        return sentiments.Any()
            ? Response<IEnumerable<StaffSentimentResponseDto>>.SuccessResponse(sentiments)
            : Response<IEnumerable<StaffSentimentResponseDto>>.ErrorResponse("No sentiment records found for the specified emotion.");
    }

    /// <summary>
    /// Retrieve sentiment records created within the last N days.
    /// </summary>
    [HttpGet("recent/{days:int}")]
    [SwaggerOperation(Summary = "Get Recent Sentiments", Description = "Fetches all sentiment records created within the last N days.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Sentiments retrieved successfully.", typeof(Response<IEnumerable<StaffSentimentResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No recent sentiment records found.")]
    public async Task<Response<IEnumerable<StaffSentimentResponseDto>>> GetRecentSentimentsAsync([FromRoute] int days, CancellationToken cancellationToken = default)
    {
        var sentiments = await _staffSentimentService.GetRecentSentimentsAsync(days, cancellationToken);
        return sentiments.Any()
            ? Response<IEnumerable<StaffSentimentResponseDto>>.SuccessResponse(sentiments)
            : Response<IEnumerable<StaffSentimentResponseDto>>.ErrorResponse("No recent sentiment records found.");
    }

    /// <summary>
    /// Update the sentiment label of a specific record.
    /// </summary>
    [HttpPut("update-label/{sentimentId:long}")]
    [SwaggerOperation(Summary = "Update Sentiment Label", Description = "Updates the label of a specific sentiment record.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Sentiment label updated successfully.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input.")]
    public async Task<Response<bool>> UpdateSentimentLabelAsync([FromRoute] long sentimentId, [FromBody] string newLabel, CancellationToken cancellationToken = default)
    {
        var result = await _staffSentimentService.UpdateSentimentLabelAsync(sentimentId, newLabel, cancellationToken);
        return result
            ? Response<bool>.SuccessResponse(result)
            : Response<bool>.ErrorResponse("Failed to update sentiment label.");
    }

    /// <summary>
    /// Update the confidence score of a specific sentiment record.
    /// </summary>
    [HttpPut("update-confidence/{sentimentId:long}")]
    [SwaggerOperation(Summary = "Update Sentiment Confidence Score", Description = "Updates the confidence score of a specific sentiment record.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Sentiment confidence updated successfully.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input.")]
    public async Task<Response<bool>> UpdateSentimentConfidenceAsync([FromRoute] long sentimentId, [FromBody] double newConfidence, CancellationToken cancellationToken = default)
    {
        var result = await _staffSentimentService.UpdateSentimentConfidenceAsync(sentimentId, newConfidence, cancellationToken);
        return result
            ? Response<bool>.SuccessResponse(result)
            : Response<bool>.ErrorResponse("Failed to update sentiment confidence score.");
    }

    /// <summary>
    /// Retrieve the average sentiment score for a specific staff member.
    /// </summary>
    [HttpGet("average-score/{staffId:long}")]
    [SwaggerOperation(Summary = "Get Average Sentiment Score", Description = "Calculates the average sentiment score for a staff member.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Average sentiment score retrieved successfully.", typeof(Response<double>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No sentiment data found.")]
    public async Task<Response<double?>> GetAverageSentimentScoreAsync([FromRoute] long staffId, CancellationToken cancellationToken = default)
    {
        var score = await _staffSentimentService.GetAverageSentimentScoreAsync(staffId, cancellationToken);
        return score.HasValue
            ? Response<double?>.SuccessResponse(score)
            : Response<double?>.ErrorResponse("No sentiment data found for the specified staff member.");
    }

    /// <summary>
    /// Retrieve a list of staff members with negative sentiment scores below a threshold.
    /// </summary>
    [HttpGet("negative-sentiment/{threshold:double}")]
    [SwaggerOperation(Summary = "Get Staff with Negative Sentiments", Description = "Fetches a list of staff members whose sentiment scores fall below a specified threshold.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Negative sentiment staff retrieved successfully.", typeof(Response<IEnumerable<long>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No staff members found.")]
    public async Task<Response<IEnumerable<long>>> GetNegativeSentimentStaffAsync([FromRoute] double threshold, CancellationToken cancellationToken = default)
    {
        var staffIds = await _staffSentimentService.GetNegativeSentimentStaffAsync(threshold, cancellationToken);
        return staffIds.Any()
            ? Response<IEnumerable<long>>.SuccessResponse(staffIds)
            : Response<IEnumerable<long>>.ErrorResponse("No staff members found with sentiment scores below the specified threshold.");
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all Guests", Description = "Returns all guest records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<StaffSentimentResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public override async Task<Response<IEnumerable<StaffSentimentResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "Retrieve a Guest by ID", Description = "Fetches a specific guest record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<StaffSentimentResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<StaffSentimentResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Guest record", Description = "Adds a new guest record to the system.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<StaffSentimentResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<StaffSentimentResponseDto>> CreateAsync([FromBody] StaffSentimentDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(entityDto, cancellationToken);
    }

    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "Update an existing Guest record", Description = "Updates an existing guest record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<StaffInfoAboutRanOutItemsResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<StaffSentimentResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] StaffSentimentDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(id, entityDto, cancellationToken);
    }

    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "Delete a Guest record", Description = "Deletes a guest record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<StaffInfoAboutRanOutItemsResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
    public override async Task<Response<StaffSentimentResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(id, cancellationToken);
    }

    [HttpPatch("soft-delete/{id:int}")]
    [SwaggerOperation(Summary = "Soft delete a Guest record", Description = "Marks a guest record as deleted without removing it from the database.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<StaffInfoAboutRanOutItemsResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<StaffSentimentResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.SoftDeleteAsync(id, cancellationToken);
    }


}
