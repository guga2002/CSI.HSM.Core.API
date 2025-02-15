using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Item;
using Core.Core.Entities.Staff;
using GuestSide.Application.DTOs.Response.Staff;

namespace Core.Application.Interface.Staff.staf
{
    public interface IStaffService : IService<StaffDto, StaffResponseDto, long, Staffs>,
        IAdditionalFeatures<StaffDto, StaffResponseDto, long, Staffs>
    {
        /// <summary>
        /// Get staff details by email.
        /// </summary>
        Task<StaffResponseDto?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get staff members by position.
        /// </summary>
        Task<IEnumerable<StaffResponseDto>> GetByPositionAsync(string position, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get staff members supervised by a specific supervisor.
        /// </summary>
        Task<IEnumerable<StaffResponseDto>> GetBySupervisorIdAsync(long supervisorId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get staff members hired between specific dates.
        /// </summary>
        Task<IEnumerable<StaffResponseDto>> GetStaffHiredBetweenDatesAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all active staff members.
        /// </summary>
        Task<IEnumerable<StaffResponseDto>> GetActiveStaffAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all inactive staff members.
        /// </summary>
        Task<IEnumerable<StaffResponseDto>> GetInactiveStaffAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Update staff position.
        /// </summary>
        Task<bool> UpdatePositionAsync(long staffId, string newPosition, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update staff salary.
        /// </summary>
        Task<bool> UpdateSalaryAsync(long staffId, decimal newSalary, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assign a new supervisor to a staff member.
        /// </summary>
        Task<bool> AssignSupervisorAsync(long staffId, long newSupervisorId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get tasks assigned to a specific staff member.
        /// </summary>
        Task<IEnumerable<TaskToStaff>> GetTasksByStaffIdAsync(long staffId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get items reserved by a staff member.
        /// </summary>
        Task<IEnumerable<StaffReserveItem>> GetReservedItemsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get incidents involving a specific staff member.
        /// </summary>
        Task<IEnumerable<StaffIncident>> GetIncidentsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the sentiment score of a staff member based on analysis.
        /// </summary>
        Task<double?> GetStaffSentimentScoreAsync(long staffId, CancellationToken cancellationToken = default);
    }
}
