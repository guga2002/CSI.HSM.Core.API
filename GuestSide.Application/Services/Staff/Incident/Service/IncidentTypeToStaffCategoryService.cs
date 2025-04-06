using AutoMapper;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff.Incident;
using Core.Core.Entities.Staff;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Staff.Incident.Service;

public class IncidentTypeToStaffCategoryService : GenericService<IncidentTypeToStaffCategoryDto,
    IncidentTypeToStaffCategoryResponseDto, long, IncidentTypeToStaffCategory>,
    IIncidentTypeToStaffCategoryService
{
    public IncidentTypeToStaffCategoryService(IMapper mapper, IGenericRepository<IncidentTypeToStaffCategory> repository,
        ILogger<GenericService<IncidentTypeToStaffCategoryDto, IncidentTypeToStaffCategoryResponseDto,
            long, IncidentTypeToStaffCategory>> logger, IAdditionalFeaturesRepository<IncidentTypeToStaffCategory> additioalFeatures)
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
