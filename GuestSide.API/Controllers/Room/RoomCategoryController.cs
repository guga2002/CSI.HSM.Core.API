using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Room;
using GuestSide.Application.DTOs.Response.Room;
using GuestSide.Core.Entities.Room;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Room;

[Route("api/[controller]")]
[ApiController]
public class RoomCategoryController : CSIControllerBase<RoomCategoryDto, RoomCategoryResponseDto, long, RoomCategory>
{
    public RoomCategoryController(IService<RoomCategoryDto, RoomCategoryResponseDto, long, RoomCategory> serviceProvider, IAdditionalFeatures<RoomCategoryDto, RoomCategoryResponseDto, long, RoomCategory> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
