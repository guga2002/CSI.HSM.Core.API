using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Domain.Core.Entities.Staff;

namespace Core.Application.Interface.Staff.Category
{
    public interface IStaffCategoryService : IService<StaffCategoryDto, StaffCategoryResponseDto, long, StaffCategory>,
        IAdditionalFeatures<StaffCategoryDto, StaffCategoryResponseDto, long, StaffCategory>
    {
        /// <summary>
        /// Get category details by name.
        /// </summary>
        Task<StaffCategoryResponseDto?> GetByCategoryNameAsync(string categoryName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all active staff categories.
        /// </summary>
        Task<IEnumerable<StaffCategoryResponseDto>> GetActiveCategoriesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all inactive staff categories.
        /// </summary>
        Task<IEnumerable<StaffCategoryResponseDto>> GetInactiveCategoriesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get categories created between two dates.
        /// </summary>
        Task<IEnumerable<StaffCategoryResponseDto>> GetCategoriesCreatedBetweenDatesAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update category name.
        /// </summary>
        Task<bool> UpdateCategoryNameAsync(long categoryId, string newName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update category description.
        /// </summary>
        Task<bool> UpdateCategoryDescriptionAsync(long categoryId, string newDescription, CancellationToken cancellationToken = default);

        /// <summary>
        /// Check if a category is assigned to any staff.
        /// </summary>
        Task<bool> IsCategoryAssignedToStaffAsync(long categoryId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get staff members assigned to a specific category.
        /// </summary>
        Task<IEnumerable<Staffs>> GetStaffByCategoryIdAsync(long categoryId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get tasks associated with a specific category.
        /// </summary>
        Task<IEnumerable<TaskToStaff>> GetTasksByCategoryIdAsync(long categoryId, CancellationToken cancellationToken = default);
    }
}
