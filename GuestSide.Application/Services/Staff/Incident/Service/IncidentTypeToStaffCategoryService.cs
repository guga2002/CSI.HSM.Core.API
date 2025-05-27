using AutoMapper;
using Common.Data.Entities.Staff;
using Common.Data.Interfaces.AbstractInterface;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff.Incident;
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
