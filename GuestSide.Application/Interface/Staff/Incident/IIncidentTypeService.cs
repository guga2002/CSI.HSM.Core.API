using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Domain.Core.Entities.Staff;

namespace Core.Application.Interface.Staff.Incident;

public interface IIncidentTypeService : IService<IncidentTypeDto, IncidentTypeResponseDto, long, IncidentType>,
    IAdditionalFeatures<IncidentTypeDto, IncidentTypeResponseDto, long, IncidentType>
{
}
