using AutoMapper;
using Common.Data.Entities.Staff;
using Common.Data.Interfaces.AbstractInterface;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff.Incident;
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
