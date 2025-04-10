using Domain.Core.Entities.Item;
using Domain.Core.Entities.Staff;
using Domain.Core.Interfaces.AbstractInterface;

namespace Domain.Core.Interfaces.Staff
{
    public interface IStaffRepository : IGenericRepository<Staffs>
    {
        Task<Staffs?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<IEnumerable<Staffs>> GetByPositionAsync(string position, CancellationToken cancellationToken = default);
        Task<IEnumerable<Staffs>> GetBySupervisorIdAsync(long supervisorId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Staffs>> GetStaffHiredBetweenDatesAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
        Task<IEnumerable<Staffs>> GetActiveStaffAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Staffs>> GetInactiveStaffAsync(CancellationToken cancellationToken = default);

        Task<bool> UpdatePositionAsync(long staffId, string newPosition, CancellationToken cancellationToken = default);
        Task<bool> UpdateSalaryAsync(long staffId, decimal newSalary, CancellationToken cancellationToken = default);
        Task<bool> AssignSupervisorAsync(long staffId, long newSupervisorId, CancellationToken cancellationToken = default);

        Task<IEnumerable<TaskToStaff>> GetTasksByStaffIdAsync(long staffId, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffReserveItem>> GetReservedItemsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default);

        Task<IEnumerable<StaffIncident>> GetIncidentsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default);
        Task<double?> GetStaffSentimentScoreAsync(long staffId, CancellationToken cancellationToken = default);
    }
}