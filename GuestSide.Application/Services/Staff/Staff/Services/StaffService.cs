using AutoMapper;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff.staf;
using Core.Application.Services;
using Domain.Core.Entities.Item;
using Domain.Core.Entities.Staff;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Staff;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Staff.Staff.Services
{
    public class StaffService : GenericService<StaffDto, StaffResponseDto, long, Staffs>, IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<StaffService> _logger;

        public StaffService(
            IMapper mapper,
            IStaffRepository staffRepository,
            ILogger<StaffService> logger,
            IAdditionalFeaturesRepository<Staffs> additionalFeatures)
            : base(mapper, staffRepository, logger, additionalFeatures)
        {
            _staffRepository = staffRepository;
            _mapper = mapper;
            _logger = logger;
        }

        private void ValidateNotNull<T>(T value, string paramName)
        {
            if (value == null)
            {
                _logger.LogWarning("{ParameterName} cannot be null.", paramName);
                throw new ArgumentNullException(paramName, $"{paramName} cannot be null.");
            }
        }

        private void ValidatePositiveId(long id, string paramName)
        {
            if (id <= 0)
            {
                _logger.LogWarning("{ParameterName} must be a positive number.", paramName);
                throw new ArgumentException($"{paramName} must be greater than zero.", paramName);
            }
        }

        private void ValidateString(string value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _logger.LogWarning("{ParameterName} cannot be empty or whitespace.", paramName);
                throw new ArgumentException($"{paramName} cannot be empty or whitespace.", paramName);
            }
        }

        public async Task<StaffResponseDto?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            ValidateString(email, nameof(email));

            var staff = await _staffRepository.GetByEmailAsync(email, cancellationToken);
            return staff is null ? null : _mapper.Map<StaffResponseDto>(staff);
        }

        public async Task<IEnumerable<StaffResponseDto>> GetByPositionAsync(string position, CancellationToken cancellationToken = default)
        {
            ValidateString(position, nameof(position));

            var staffList = await _staffRepository.GetByPositionAsync(position, cancellationToken);
            return _mapper.Map<IEnumerable<StaffResponseDto>>(staffList);
        }

        public async Task<IEnumerable<StaffResponseDto>> GetBySupervisorIdAsync(long supervisorId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(supervisorId, nameof(supervisorId));

            var staffList = await _staffRepository.GetBySupervisorIdAsync(supervisorId, cancellationToken);
            return _mapper.Map<IEnumerable<StaffResponseDto>>(staffList);
        }

        public async Task<IEnumerable<StaffResponseDto>> GetStaffHiredBetweenDatesAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            if (startDate > endDate)
            {
                _logger.LogWarning("Start date cannot be after end date.");
                throw new ArgumentException("Start date cannot be after end date.");
            }

            var staffList = await _staffRepository.GetStaffHiredBetweenDatesAsync(startDate, endDate, cancellationToken);
            return _mapper.Map<IEnumerable<StaffResponseDto>>(staffList);
        }

        public async Task<IEnumerable<StaffResponseDto>> GetActiveStaffAsync(CancellationToken cancellationToken = default)
        {
            var staffList = await _staffRepository.GetActiveStaffAsync(cancellationToken);
            return _mapper.Map<IEnumerable<StaffResponseDto>>(staffList);
        }

        public async Task<IEnumerable<StaffResponseDto>> GetInactiveStaffAsync(CancellationToken cancellationToken = default)
        {
            var staffList = await _staffRepository.GetInactiveStaffAsync(cancellationToken);
            return _mapper.Map<IEnumerable<StaffResponseDto>>(staffList);
        }

        public async Task<bool> UpdatePositionAsync(long staffId, string newPosition, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffId, nameof(staffId));
            ValidateString(newPosition, nameof(newPosition));

            return await _staffRepository.UpdatePositionAsync(staffId, newPosition, cancellationToken);
        }

        public async Task<bool> UpdateSalaryAsync(long staffId, decimal newSalary, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffId, nameof(staffId));

            if (newSalary <= 0)
            {
                _logger.LogWarning("Salary must be greater than zero.");
                throw new ArgumentException("Salary must be greater than zero.");
            }

            return await _staffRepository.UpdateSalaryAsync(staffId, newSalary, cancellationToken);
        }

        public async Task<bool> AssignSupervisorAsync(long staffId, long newSupervisorId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffId, nameof(staffId));
            ValidatePositiveId(newSupervisorId, nameof(newSupervisorId));

            if (staffId == newSupervisorId)
            {
                _logger.LogWarning("A staff member cannot be their own supervisor.");
                throw new ArgumentException("A staff member cannot be their own supervisor.");
            }

            return await _staffRepository.AssignSupervisorAsync(staffId, newSupervisorId, cancellationToken);
        }

        public async Task<IEnumerable<TaskToStaff>> GetTasksByStaffIdAsync(long staffId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffId, nameof(staffId));

            return await _staffRepository.GetTasksByStaffIdAsync(staffId, cancellationToken);
        }

        public async Task<IEnumerable<StaffReserveItem>> GetReservedItemsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffId, nameof(staffId));

            return await _staffRepository.GetReservedItemsByStaffIdAsync(staffId, cancellationToken);
        }

        public async Task<IEnumerable<StaffIncident>> GetIncidentsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffId, nameof(staffId));

            return await _staffRepository.GetIncidentsByStaffIdAsync(staffId, cancellationToken);
        }

        public async Task<double?> GetStaffSentimentScoreAsync(long staffId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffId, nameof(staffId));

            return await _staffRepository.GetStaffSentimentScoreAsync(staffId, cancellationToken);
        }

        public async Task<bool> CheckIsOnDuteAsync(long staffId, bool Status, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffId, nameof(staffId));

            return await _staffRepository.CheckIsOnDute(staffId, Status, cancellationToken);
        }

        public async Task<StaffLoginDate> GetLastLoginDateAsync(long staffId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffId, nameof(staffId));

            var result = await _staffRepository.GetLastLoginDate(staffId, cancellationToken);

            return new StaffLoginDate
            {
                Id = result.Item1,
                LastLoginTime = result.Item2
            };
        }
    }
}
