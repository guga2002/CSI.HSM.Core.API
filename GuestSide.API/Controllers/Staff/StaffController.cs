using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using GuestSide.Core.Entities.Staff;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Staff
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : CSIControllerBase<StaffDto,StaffResponseDto, long, Staffs>
    {
        public StaffController(IService<StaffDto,StaffResponseDto, long, Staffs> serviceProvider) : base(serviceProvider)
        {
        }

        /// <summary>
        /// Retrieves all staff members.
        /// </summary>
        /// <returns>A list of all staff members.</returns>
        [HttpGet("CurrentStaffMember")]
        [SwaggerOperation(Summary = "Retrieve staff member", Description = "Returns  staff members.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved staff member.", typeof(Response<StaffResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No staff member found.")]
        public async Task<Response<StaffResponseDto>> GetCurrentStaffMember()
        {
            var email = User.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;

            var all = await base.GetAllAsync();

            var user = all.Data.FirstOrDefault(io => io.Email == email) ??
                 throw new UnauthorizedAccessException("user is not authorized");
            if(user is null)
            {
                return Response<StaffResponseDto>.ErrorResponse("No data found", 404);
            }
            return Response<StaffResponseDto>.SuccessResponse(user, "Success");
        }


        /// <summary>
        /// Retrieves all staff members.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all staff members.</returns>
        [HttpGet("GetAllStaff")]
        [SwaggerOperation(Summary = "Retrieve all staff members", Description = "Returns a list of all staff members.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved staff members.", typeof(Response<IEnumerable<StaffResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No staff members found.")]
        public override async Task<Response<IEnumerable<StaffResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await  base.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a staff member by their ID.
        /// </summary>
        /// <param name="id">The ID of the staff member.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The staff member matching the specified ID.</returns>
        [HttpGet("GetStaffById/{id}")]
        [SwaggerOperation(Summary = "Retrieve staff member by ID", Description = "Returns a specific staff member by their ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the staff member.", typeof(Response<StaffResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Staff member not found.")]
        public override Task<Response<StaffResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Creates a new staff member.
        /// </summary>
        /// <param name="entityDto">The staff member to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created staff member.</returns>
        [HttpPost("CreateStaff")]
        [SwaggerOperation(Summary = "Create a new staff member", Description = "Creates a new staff member.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Staff member created successfully.", typeof(Response<StaffResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<StaffResponseDto>> CreateAsync([FromBody] StaffDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(entityDto, cancellationToken);
        }

        /// <summary>
        /// Updates an existing staff member.
        /// </summary>
        /// <param name="id">The ID of the staff member to update.</param>
        /// <param name="entityDto">The updated staff member data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated staff member.</returns>
        [HttpPut("UpdateStaff/{id}")]
        [SwaggerOperation(Summary = "Update an existing staff member", Description = "Updates the staff member with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Staff member updated successfully.", typeof(Response<StaffResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<StaffResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] StaffDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, entityDto, cancellationToken);
        }

        /// <summary>
        /// Deletes a staff member by their ID.
        /// </summary>
        /// <param name="id">The ID of the staff member to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteStaff/{id}")]
        [SwaggerOperation(Summary = "Delete a staff member", Description = "Deletes the staff member with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Staff member deleted successfully.", typeof(Response<StaffResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Staff member not found or failed to delete.")]
        public override Task<Response<StaffResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        // Add more methods or features as needed.
    }
}
