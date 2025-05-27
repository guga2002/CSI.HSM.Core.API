using Common.Data.Entities.Staff;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Staff.Incident;

public interface IIncidentTypeService : IService<IncidentTypeDto, IncidentTypeResponseDto, long, IncidentType>,
    IAdditionalFeatures<IncidentTypeDto, IncidentTypeResponseDto, long, IncidentType>
{
}
