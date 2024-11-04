using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Request.Advertisment;
using GuestSide.Application.DTOs.Response.Advertisment;
using GuestSide.Application.Interface;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Advertisements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Advertisement
{
    [ApiController]
    public class AdvertisementController : CSIControllerBase<AdvertismentResponseDto, long, Advertisements>
    {
        private readonly GuestSideDb _db;
        public AdvertisementController(IService<AdvertismentResponseDto, long, Advertisements> serviceProvider,GuestSideDb db) : base(serviceProvider)
        {
            _db = db;
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("GetTasksByCartId/{CartId}")]
        public async Task<GuestSide.Core.Entities.Task.Tasks> Gettasks(long CartId)
        {
           var res=await _db.GetTaskByCartId(CartId);
            return res;
        }
        /// <summary>
        /// Retrieves all records.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all models.</returns>
        [HttpGet("GetAdvertisements")]
        [SwaggerOperation(Summary = "Retrieve all records", Description = "Returns all the records of type AdvertismentDto.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved records.", typeof(Response<IEnumerable<AdvertismentResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public override Task<Response<IEnumerable<AdvertismentResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a record by its ID.
        /// </summary>
        /// <param name="id">The record ID.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The record matching the specified ID.</returns>
        [HttpGet("GetAdvertisementById/{id}")]
        [SwaggerOperation(Summary = "Retrieve a record by ID", Description = "Returns a specific record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the record.", typeof(Response<AdvertismentResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override Task<Response<AdvertismentResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Creates a new record.
        /// </summary>
        /// <param name="entityDto">The entity to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created record.</returns>
        [HttpPost("CreateAdvertisement")]
        [SwaggerOperation(Summary = "Create a new record", Description = "Creates a new record of type AdvertismentDto.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<AdvertismentResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<AdvertismentResponseDto>> CreateAsync([FromBody] AdvertismentResponseDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(entityDto, cancellationToken);
        }


        /// <summary>
        /// Updates an existing record.
        /// </summary>
        /// <param name="id">The ID of the record to update.</param>
        /// <param name="entityDto">The updated entity data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated record.</returns>
        [HttpPut("UpdateAdvertisement/{id}")]
        [SwaggerOperation(Summary = "Update an existing record", Description = "Updates the record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<AdvertismentResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<AdvertismentResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] AdvertismentResponseDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, entityDto, cancellationToken);
        }

        /// <summary>
        /// Deletes a record by its ID.
        /// </summary>
        /// <param name="id">The ID of the record to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteA/{id}")]
        [SwaggerOperation(Summary = "Delete a record", Description = "Deletes the record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
        public override Task<Response<bool>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        //add more functions if need also  can inject other interfaces
    }
}
