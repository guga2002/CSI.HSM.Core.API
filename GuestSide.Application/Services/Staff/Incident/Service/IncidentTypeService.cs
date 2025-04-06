using AutoMapper;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff.Incident;
using Core.Core.Entities.Staff;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Staff.Incident.Service;

public class IncidentTypeService : GenericService<IncidentTypeDto, IncidentTypeResponseDto, long, IncidentType>, IIncidentTypeService
{
    public IncidentTypeService(IMapper mapper, IGenericRepository<IncidentType> repository,
        ILogger<GenericService<IncidentTypeDto, IncidentTypeResponseDto, long, IncidentType>> logger,
        IAdditionalFeaturesRepository<IncidentType> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
