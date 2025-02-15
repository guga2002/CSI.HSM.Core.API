using Core.Core.Entities.Staff;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Staff
{
    public interface IStaffCategoryRepository : IGenericRepository<StaffCategory>
    {
        Task<StaffCategory?> GetByCategoryNameAsync(string categoryName, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffCategory>> GetActiveCategoriesAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffCategory>> GetInactiveCategoriesAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffCategory>> GetCategoriesCreatedBetweenDatesAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

        Task<bool> UpdateCategoryNameAsync(long categoryId, string newName, CancellationToken cancellationToken = default);
        Task<bool> UpdateCategoryDescriptionAsync(long categoryId, string newDescription, CancellationToken cancellationToken = default);
        Task<bool> IsCategoryAssignedToStaffAsync(long categoryId, CancellationToken cancellationToken = default);

        Task<IEnumerable<Staffs>> GetStaffByCategoryIdAsync(long categoryId, CancellationToken cancellationToken = default);
        Task<IEnumerable<TaskToStaff>> GetTasksByCategoryIdAsync(long categoryId, CancellationToken cancellationToken = default);
    }
}